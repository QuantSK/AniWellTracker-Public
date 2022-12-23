Option Explicit On
Option Strict On
Option Infer On

Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices.Marshal
Imports System.Math
Imports System.IO

Public Class CompactImgProcessing

    Declare Function GetPixel Lib "gdi32" (ByVal hDC As Integer,
                                      ByVal x As Integer,
                                      ByVal y As Integer) As Integer

    Structure Def_PixelIndex
        Dim Alpha As Integer
        Dim Red As Integer
        Dim Green As Integer
        Dim Blue As Integer
    End Structure

    Public Const AtGreen As Integer = 1
    Public Const AtRed As Integer = 2


    Dim _IsImageLocked As Boolean = False
    Dim _StartedAt As Date
    Dim _CompletedAt As Date
    Dim _LapseAsMilliSecond As Integer = 0

    Dim _SrcBitmap As Bitmap
    Shared _SrcBitmapWidth, _SrcBitmapHeight As Integer
    Dim Prev_SrcBitmapWidth, Prev_SrcBitmapHeight As Integer
    Dim _SrcBMD As BitmapData
    Shared _SrcPixels(0), _OutPixels(0) As Byte
    Dim _PixelIndexUpper As Integer
    Shared _PixelIndex(0, 0) As Def_PixelIndex
    Dim _GrayImage(0, 0) As Byte
    Dim _MaskBitmap As Bitmap
    Dim _MaskPixels(0) As Byte
    Dim _MaskBMD As BitmapData
    Dim _MaskBMDScan0 As IntPtr
    Dim _IsMaskImageAvailable As Boolean = False


    Dim dx, dy, x1, y1, x2, y2 As Integer
    Dim _BMDScan0 As IntPtr
    Dim _Alpha, _Red, _Green, _Blue, _Gray As Single
    Dim _Buf_Red, _Buf_Green, _Buf_Blue, _Buf_Gray As Single


    Shared LUT_RGB_To_PartialGray(3, 255) As Single


    Public Event Started()
    Public Shared Event Processing(ByVal CurrentPercent As Single)
    Public Event Completed(ByVal LapseAsMilliSecond As Integer)


    Public Sub ImageTo_SrcPixels(ByRef SourceImage As Image, Optional ByRef MaskImage As Image = Nothing)
        _IsImageLocked = True

        RaiseEvent Started()


        _StartedAt = Now

        _SrcBitmap = CType(SourceImage.Clone, Bitmap)
        _SrcBitmapHeight = _SrcBitmap.Height
        _SrcBitmapWidth = _SrcBitmap.Width
        _SrcBMD = _SrcBitmap.LockBits(New Rectangle(0, 0, _SrcBitmapWidth, _SrcBitmapHeight),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
        _BMDScan0 = _SrcBMD.Scan0

        ReDim _SrcPixels(_SrcBitmapWidth * _SrcBitmapHeight * 4 - 1)
        ReDim _OutPixels(_SrcBitmapWidth * _SrcBitmapHeight * 4 - 1)


        _PixelIndexUpper = _SrcPixels.Length - 1
        Copy(_BMDScan0, _SrcPixels, 0, _PixelIndexUpper)
        Copy(_BMDScan0, _OutPixels, 0, _PixelIndexUpper)




        If MaskImage Is Nothing Then
            _IsMaskImageAvailable = False
            ReDim _MaskPixels(_SrcBitmapWidth * _SrcBitmapHeight * 4 - 1)
        Else
            _IsMaskImageAvailable = True
            _MaskBitmap = CType(MaskImage.Clone, Bitmap)
            _MaskBMD = _MaskBitmap.LockBits(New Rectangle(0, 0, _SrcBitmapWidth, _SrcBitmapHeight),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            _MaskBMDScan0 = _MaskBMD.Scan0

            ReDim _MaskPixels(_SrcBitmapWidth * _SrcBitmapHeight * 4 - 1)

            Copy(_MaskBMDScan0, _MaskPixels, 0, _PixelIndexUpper)
        End If




        If Prev_SrcBitmapHeight <> _SrcBitmapHeight _
                            Or Prev_SrcBitmapWidth <> _SrcBitmapWidth Then

            ReDim _PixelIndex(_SrcBitmapWidth - 1, _SrcBitmapHeight - 1)

            Call Build_PixelIndex()

            Prev_SrcBitmapHeight = _SrcBitmapHeight
            Prev_SrcBitmapWidth = _SrcBitmapWidth
        End If
    End Sub


    Public Function OutPixelsToImage() As Bitmap

        Copy(_OutPixels, 0, _BMDScan0, _PixelIndexUpper)
        _SrcBitmap.UnlockBits(_SrcBMD)


        If _IsMaskImageAvailable Then
            _MaskBitmap.UnlockBits(_MaskBMD)
        End If


        _CompletedAt = Now
        Call Process_TimeLapseCalculation()


        RaiseEvent Completed(_LapseAsMilliSecond)


        OutPixelsToImage = CType(_SrcBitmap.Clone, Bitmap)

        _IsImageLocked = False
    End Function


    Private Sub Process_TimeLapseCalculation()
        _LapseAsMilliSecond = CInt((TimeSpan.FromTicks(_CompletedAt.Ticks).TotalMilliseconds _
                            - TimeSpan.FromTicks(_StartedAt.Ticks).TotalMilliseconds))
    End Sub



    Private Sub ColorToARGB(ByVal PixelValue As Integer)
        _Alpha = (PixelValue >> 24) And &HFF
        _Red = (PixelValue >> 16) And &HFF
        _Green = (PixelValue >> 8) And &HFF
        _Blue = PixelValue And &HFF
    End Sub


    Public Shared Function RGBToGray(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As Byte
        Return CByte(LUT_RGB_To_PartialGray(1, r) +
                    LUT_RGB_To_PartialGray(2, g) +
                    LUT_RGB_To_PartialGray(3, b))
    End Function


    Private Sub Build_PixelIndex()
        Dim x, y, z As Integer

        For y = 0 To _SrcBitmapHeight - 1
            For x = 0 To _SrcBitmapWidth - 1

                z = y * _SrcBitmapWidth * 4 + x * 4

                With _PixelIndex(x, y)
                    .Alpha = z + 3
                    .Red = z + 2
                    .Green = z + 1
                    .Blue = z
                End With

            Next
        Next
    End Sub


    Public Function Maximum(ByVal rR As Single,
                            ByVal rG As Single,
                            ByVal rB As Single) As Single
        If (rR > rG) Then
            If (rR > rB) Then
                Maximum = rR
            Else
                Maximum = rB
            End If
        Else
            If (rB > rG) Then
                Maximum = rB
            Else
                Maximum = rG
            End If
        End If
    End Function


    Public Function Minimum(ByVal rR As Single,
                            ByVal rG As Single,
                            ByVal rB As Single) As Single
        If (rR < rG) Then
            If (rR < rB) Then
                Minimum = rR
            Else
                Minimum = rB
            End If
        Else
            If (rB < rG) Then
                Minimum = rB
            Else
                Minimum = rG
            End If
        End If
    End Function


    Protected Friend Function Image_FromFile(ByVal FileName As String) As Image

        Using ImageFileStream As FileStream =
                            New FileStream(FileName, FileMode.Open, FileAccess.Read)


            Dim ImageBytes(CInt(ImageFileStream.Length)) As Byte

            ImageFileStream.Read(ImageBytes, 0, CInt(ImageBytes.Length))
            ImageFileStream.Close()

            Image_FromFile = Image.FromStream(New MemoryStream(ImageBytes))
            If Image_FromFile.PixelFormat <> PixelFormat.Format24bppRgb Then '
                Image_FromFile = Convert_To_24bitmap(CType(Image_FromFile.Clone, Bitmap))
            End If

            ImageBytes = Nothing
        End Using
    End Function


    Public Function Convert_To_24bitmap(ByRef SourceImage As Bitmap) As Bitmap
        Dim r As New Rectangle(0, 0, SourceImage.Width, SourceImage.Height)
        Return DirectCast(SourceImage.Clone(r, Imaging.PixelFormat.Format24bppRgb), Bitmap)
    End Function



    Public Function Resize(ByVal SourceImage As Image,
                      ByVal nWidth As Integer,
                      ByVal nHeight As Integer) As Bitmap

        If SourceImage Is Nothing Then Return Nothing


        _StartedAt = Now


        Dim bm As New Bitmap(SourceImage)

        Dim Temp_bm As New Bitmap(nWidth, nHeight)

        Dim g As Graphics = Graphics.FromImage(Temp_bm)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        g.DrawImage(bm, New Rectangle(0, 0, nWidth, nHeight),
                    New Rectangle(0, 0, bm.Width, bm.Height),
                    GraphicsUnit.Pixel)

        g.Dispose()
        g = Nothing
        bm.Dispose()
        bm = Nothing

        Resize = CType(Temp_bm.Clone, Bitmap)
        Temp_bm.Dispose()
        Temp_bm = Nothing

        _CompletedAt = Now
        Call Process_TimeLapseCalculation()
        RaiseEvent Completed(_LapseAsMilliSecond)

    End Function



    Public Function RegionExtract_RasterScanning(ByVal SourceImage As Image,
                                    ByRef LabelIDMap As Integer(,),
                                    ByRef RegionColorTable As Byte(,),
                                    Optional ByVal BkColor As Integer = 0,
                                    Optional ByVal MaskImage As Image = Nothing,
                                    Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                    Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap


        'RegionColorTable (IDnumber, 0:R  1:G  2:B)
        '                  IDnumber starts from 1
        'LabelIDMap(x,y)        x,y starts from 0
        '


        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)

        Call ImageTo_SrcPixels(SourceImage, MaskImage)

        Dim Linked1D(0) As Short
        Dim Linked2D(0, 0) As Boolean
        Dim CurrentID As Short
        Dim IDCountMax As Integer = 10000
        Dim IDMap(_SrcBitmapWidth - 1, _SrcBitmapHeight - 1) As Integer
        Dim Pixel_Center, Pixel_1, Pixel_2, Pixel_3, Pixel_4 As Integer
        Dim BkColor_Red, BkColor_Green, BKColor_Blue As Byte
        Dim BitmapHeightUpper, BitmapWidthUpper As Integer
        Dim BorderHeightUpper, BorderWidthUpper As Integer
        Dim BoxSizeHalf As Integer = 1


        BitmapHeightUpper = _SrcBitmapHeight - 1
        BitmapWidthUpper = _SrcBitmapWidth - 1
        BorderHeightUpper = _SrcBitmapHeight - BoxSizeHalf - 1
        BorderWidthUpper = _SrcBitmapWidth - BoxSizeHalf - 1


        Call ColorToARGB(BkColor)
        BkColor_Red = CByte(_Red)
        BkColor_Green = CByte(_Green)
        BKColor_Blue = CByte(_Blue)






        'Initialize IDmap
        For y As Integer = 0 To BitmapHeightUpper
            For x As Integer = 0 To BitmapWidthUpper
                IDMap(x, y) = 0
            Next x
        Next


        Dim tempstr As String = ""



        'First pass
        CurrentID = 0
        For y As Integer = BoxSizeHalf To BorderHeightUpper
            For x As Integer = BoxSizeHalf To BorderWidthUpper
                If _MaskPixels(_PixelIndex(x, y).Red) = 0 Then
                    If _SrcPixels(_PixelIndex(x, y).Red) = BkColor_Red And
                        _SrcPixels(_PixelIndex(x, y).Green) = BkColor_Green And
                        _SrcPixels(_PixelIndex(x, y).Blue) = BKColor_Blue Then
                    Else


                        Pixel_Center = IDMap(x, y)
                        Pixel_1 = IDMap(x - 1, y - 1)
                        Pixel_2 = IDMap(x, y - 1)
                        Pixel_3 = IDMap(x + 1, y - 1)
                        Pixel_4 = IDMap(x - 1, y)


                        If Pixel_1 = 0 And Pixel_2 = 0 And
                            Pixel_3 = 0 And Pixel_4 = 0 Then

                            If CurrentID < IDCountMax Then
                                CurrentID = CShort(CurrentID + 1)
                                IDMap(x, y) = CurrentID
                            End If
                        Else
                            IDMap(x, y) =
                                    CShort(Get_MinValue(Pixel_Center, Pixel_1, Pixel_2,
                                                Pixel_3, Pixel_4))
                        End If
                    End If
                End If
            Next x

            RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 20))

        Next y





        Dim Repeat_Twice As Integer
        Dim MinValue As Integer
        ReDim Linked1D(CurrentID)
        ReDim Linked2D(CurrentID, CurrentID)

        For Repeat_Twice = 1 To 2


            'Second pass and record their equivalence relationship


            For y As Integer = 0 To BorderHeightUpper
                For x As Integer = 0 To BorderWidthUpper

                    If _MaskPixels(_PixelIndex(x, y).Red) = 0 Then
                        If IDMap(x, y) <> 0 Then

                            Pixel_Center = IDMap(x, y)
                            Pixel_1 = IDMap(x + 1, y)
                            Pixel_2 = IDMap(x, y + 1)
                            Pixel_3 = IDMap(x + 1, y + 1)
                            Pixel_4 = IDMap(x - 1, y + 1)


                            Linked2D(Pixel_Center, Pixel_Center) = True

                            If Pixel_1 <> 0 Then
                                Linked2D(Pixel_Center, Pixel_1) = True
                                Linked2D(Pixel_1, Pixel_Center) = True
                            End If
                            If Pixel_2 <> 0 Then
                                Linked2D(Pixel_Center, Pixel_2) = True
                                Linked2D(Pixel_2, Pixel_Center) = True
                            End If
                            If Pixel_3 <> 0 Then
                                Linked2D(Pixel_Center, Pixel_3) = True
                                Linked2D(Pixel_3, Pixel_Center) = True
                            End If
                            If Pixel_4 <> 0 Then
                                Linked2D(Pixel_Center, Pixel_4) = True
                                Linked2D(Pixel_4, Pixel_Center) = True
                            End If
                        End If
                    End If
                Next x
                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 20 + Repeat_Twice * 20))

            Next y


            'Reduce equivalence relationship
            For x As Integer = 1 To CurrentID

                MinValue = x
                Linked1D(x) = CShort(x)

                For y As Integer = x To 1 Step -1

                    If Linked2D(x, y) Then
                        If MinValue > y Then
                            MinValue = y
                        End If
                    End If
                Next

                Linked1D(x) = Linked1D(MinValue)
            Next



            'Remove equivalence relationship
            For y As Integer = BoxSizeHalf To BorderHeightUpper
                For x As Integer = BoxSizeHalf To BorderWidthUpper
                    If _MaskPixels(_PixelIndex(x, y).Red) = 0 Then
                        IDMap(x, y) = Linked1D(IDMap(x, y))
                    End If
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 20 + Repeat_Twice * 20 + 20))
            Next y
        Next




        'Setup color code randomly
        Dim q, w As Integer
        Dim IsExistSameColor As Boolean
        Dim ColorCodeTable(CurrentID, 2) As Byte


        For q = 1 To CurrentID
            Do
                Do
                    ColorCodeTable(q, 0) = CByte(Int(Rnd(1) * 255))
                    ColorCodeTable(q, 1) = CByte(Int(Rnd(1) * 255))
                    ColorCodeTable(q, 2) = CByte(Int(Rnd(1) * 255))
                Loop While (ColorCodeTable(q, 0) = 0 And
                            ColorCodeTable(q, 1) = 0 And
                            ColorCodeTable(q, 2) = 0)


                IsExistSameColor = False
                For w = 1 To q - 1
                    If ColorCodeTable(q, 0) = ColorCodeTable(w, 0) And
                        ColorCodeTable(q, 1) = ColorCodeTable(w, 1) And
                            ColorCodeTable(q, 2) = ColorCodeTable(w, 2) Then
                        IsExistSameColor = True
                        Exit For
                    End If
                Next


            Loop Until IsExistSameColor = False
        Next



        'Draw final image
        For y As Integer = BoxSizeHalf To BorderHeightUpper
            For x As Integer = BoxSizeHalf To BorderWidthUpper
                With _PixelIndex(x, y)
                    If _MaskPixels(.Red) = 0 Then
                        _OutPixels(.Alpha) = _SrcPixels(.Alpha)
                        _OutPixels(.Red) = ColorCodeTable(IDMap(x, y), 0)
                        _OutPixels(.Green) = ColorCodeTable(IDMap(x, y), 1)
                        _OutPixels(.Blue) = ColorCodeTable(IDMap(x, y), 2)
                    End If
                End With
            Next x

            RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 20 + 80))
        Next y


        LabelIDMap = IDMap
        RegionColorTable = ColorCodeTable


        Return OutPixelsToImage()

    End Function



    Public Function RegionExtract_Update_LabelIDMap_To_Image(ByVal SourceImage As Image,
                                  ByVal LabelIDMap As Integer(,),
                                  ByVal RegionColorTable As Byte(,),
                                  Optional ByVal IsOverlap As Boolean = True,
                                  Optional ByVal BkColor As Integer = 0,
                                  Optional ByVal MaskImage As Image = Nothing,
                                  Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                  Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap


        'RegionColorTable (IDnumber, 0:R  1:G  2:B)



        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)

        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        Dim BitmapHeightUpper, BitmapWidthUpper As Integer


        BitmapHeightUpper = _SrcBitmapHeight - 1
        BitmapWidthUpper = _SrcBitmapWidth - 1


        If IsOverlap Then
            'Draw final image
            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Red) = 0 Then
                            _OutPixels(.Alpha) = _SrcPixels(.Alpha)

                            If LabelIDMap(x, y) <> 0 Then
                                _OutPixels(.Red) = RegionColorTable(LabelIDMap(x, y), 0)
                                _OutPixels(.Green) = RegionColorTable(LabelIDMap(x, y), 1)
                                _OutPixels(.Blue) = RegionColorTable(LabelIDMap(x, y), 2)
                            End If

                        End If
                    End With
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 20 + 80))
            Next y
        Else


            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Red) = 0 Then
                            _OutPixels(.Alpha) = _SrcPixels(.Alpha)

                            If LabelIDMap(x, y) <> 0 Then
                                _OutPixels(.Red) = RegionColorTable(LabelIDMap(x, y), 0)
                                _OutPixels(.Green) = RegionColorTable(LabelIDMap(x, y), 1)
                                _OutPixels(.Blue) = RegionColorTable(LabelIDMap(x, y), 2)
                            Else
                                _OutPixels(.Red) = 0
                                _OutPixels(.Green) = 0
                                _OutPixels(.Blue) = 0
                            End If

                        End If
                    End With
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 20 + 80))
            Next y
        End If

        Return OutPixelsToImage()

    End Function



    'Return new LabelIDMap
    Public Function RegionExtract_Update_LabelIDMap_ByIncluding(
                                ByVal LabelIDMap As Integer(,),
                                ByVal IDArray As Dictionary(Of Integer, Boolean)) As Integer(,)

        Dim q, w As Integer
        Dim IDMapWidthIndex, IDMapHeightIndex As Integer
        IDMapWidthIndex = LabelIDMap.GetUpperBound(0)
        IDMapHeightIndex = LabelIDMap.GetUpperBound(1)
        Dim retLabelIDMap(IDMapWidthIndex, IDMapHeightIndex) As Integer


        If IDArray.Count = 0 Then
            Return retLabelIDMap
        End If


        For q = 0 To IDMapWidthIndex
            For w = 0 To IDMapHeightIndex
                If LabelIDMap(q, w) = 0 Then
                    retLabelIDMap(q, w) = 0
                Else
                    If IDArray.ContainsKey(LabelIDMap(q, w)) Then
                        retLabelIDMap(q, w) = LabelIDMap(q, w)
                    Else
                        retLabelIDMap(q, w) = 0
                    End If
                End If
            Next
        Next

        Return retLabelIDMap
    End Function

    Public Function RegionExtract_Create_OutlinedOriginalImage(
                                 ByVal SourceImage As Image,
                                 ByVal LabelIDMap As Integer(,),
                                 Optional ByVal ObjectRed As Byte = 255,
                                 Optional ByVal ObjectGreen As Byte = 255,
                                 Optional ByVal ObjectBlue As Byte = 255) As Bitmap

        Return Overlay_Image(SourceImage,
                           Convert_RGBImage_To_RGBByteArray(
                                EdgeDetect_by_ExplicitComp(
                                    Maximize(
                                          RegionExtract_Convert_LabelIDMap_To_Image(
                                            LabelIDMap),
                                            3), False
                                                           )
                                                            ), 0
                             )
    End Function


    Public Function RegionExtract_Convert_LabelIDMap_To_Image(
                                 ByVal LabelIDMap As Integer(,),
                                 Optional ByVal ObjectRed As Byte = 255,
                                 Optional ByVal ObjectGreen As Byte = 255,
                                 Optional ByVal ObjectBlue As Byte = 255) As Bitmap

        Using SourceImage As Image =
                New Bitmap(LabelIDMap.GetUpperBound(0) + 1, LabelIDMap.GetUpperBound(1) + 1)

            Call ImageTo_SrcPixels(SourceImage)

            For y As Integer = 0 To _SrcBitmapHeight - 1

                For x As Integer = 0 To _SrcBitmapWidth - 1

                    With _PixelIndex(x, y)
                        If LabelIDMap(x, y) <> 0 Then
                            _OutPixels(.Blue + AtRed) = ObjectRed
                            _OutPixels(.Blue + AtGreen) = ObjectGreen
                            _OutPixels(.Blue) = ObjectBlue
                        End If
                    End With
                Next x

            Next y

            RegionExtract_Convert_LabelIDMap_To_Image = OutPixelsToImage()

        End Using

    End Function


    Public Function Get_MinValue(ByVal Value1 As Single, ByVal Value2 As Single,
                       ByVal Value3 As Single, ByVal Value4 As Single,
                       ByVal Value5 As Single) As Single
        Dim CurMin As Single


        CurMin = Get_MaxValue(Value1, Value2, Value3, Value4, Value5)
        'If CurMin <> 1 Then Stop
        If Value1 <> 0 Then
            CurMin = Math.Min(CurMin, Value1)
        End If

        If Value2 <> 0 Then
            CurMin = Math.Min(CurMin, Value2)
        End If

        If Value3 <> 0 Then
            CurMin = Math.Min(CurMin, Value3)
        End If

        If Value4 <> 0 Then
            CurMin = Math.Min(CurMin, Value4)
        End If

        If Value5 <> 0 Then
            CurMin = Math.Min(CurMin, Value5)
        End If

        Return CurMin
    End Function


    Public Function Get_MaxValue(ByVal Value1 As Single, ByVal Value2 As Single,
                       ByVal Value3 As Single, ByVal Value4 As Single,
                       ByVal Value5 As Single) As Single
        Dim CurMax As Single

        CurMax = Value1
        CurMax = Math.Max(CurMax, Value2)
        CurMax = Math.Max(CurMax, Value3)
        CurMax = Math.Max(CurMax, Value4)
        CurMax = Math.Max(CurMax, Value5)

        Return CurMax
    End Function



    Public Sub New()
        Dim i As Integer

        'Generate LUT for gray scaling
        'Formula: Gray=(0.299 * r) + (0.587 * g) + (0.114 * b)
        For i = 0 To 255
            LUT_RGB_To_PartialGray(1, i) = CSng(0.299 * i)
            LUT_RGB_To_PartialGray(2, i) = CSng(0.587 * i)
            LUT_RGB_To_PartialGray(3, i) = CSng(0.114 * i)
        Next

    End Sub


    Private Sub Process_BoundaryRegion(ByVal PicWidthUpper As Integer, ByVal PicHeightUpper As Integer,
                                     ByVal BorderWidthUpper As Integer, ByVal BorderHeightUpper As Integer,
                                     ByRef CurX As Integer, ByRef CurY As Integer,
                                     ByVal FilterBoxHalfSize As Integer,
                                     ByRef CellXStart As Integer, ByRef CellXEnd As Integer,
                                     ByRef CellYStart As Integer, ByRef CellYEnd As Integer,
                                     ByRef CellXPixelCount As Integer,
                                     ByRef CellYPixelCount As Integer,
                                     ByRef CellPixelCount As Integer)


        If CurX = FilterBoxHalfSize Then
            If CurY > FilterBoxHalfSize Then
                If CurY < BorderHeightUpper Then
                    CurX = PicWidthUpper - FilterBoxHalfSize + 1
                End If
            End If
        End If


        If CurX < FilterBoxHalfSize Then
            CellXStart = Math.Max(0, CurX - FilterBoxHalfSize)
            CellXEnd = CurX + FilterBoxHalfSize
        Else
            CellXStart = CurX - FilterBoxHalfSize
            CellXEnd = Math.Min(PicWidthUpper, CurX + FilterBoxHalfSize)
        End If

        If CurY < FilterBoxHalfSize Then
            CellYStart = Math.Max(0, CurY - FilterBoxHalfSize)
            CellYEnd = CurY + FilterBoxHalfSize
        Else
            CellYStart = CurY - FilterBoxHalfSize
            CellYEnd = Math.Min(PicHeightUpper, CurY + FilterBoxHalfSize)
        End If


        CellXPixelCount = CellXEnd - CellXStart + 1
        CellYPixelCount = CellYEnd - CellYStart + 1
        CellPixelCount = CellXPixelCount * CellYPixelCount

    End Sub


    Public Function DeepCopy(ByVal SourceImage As Image,
                           Optional ByVal MaskImage As Image = Nothing,
                           Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                           Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap

        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)

        Call ImageTo_SrcPixels(SourceImage, MaskImage)

        Return OutPixelsToImage()
    End Function



    'Default source is _OutPixels
    Public Function Build_IntegralGrayImageMap() As Long(,)


        Dim Temp_IntegralGrayImageMap(_SrcBitmapWidth - 1,
                                      _SrcBitmapHeight - 1) As Long


        x1 = 0
        y1 = 0
        x2 = _SrcBitmapWidth - 1
        y2 = _SrcBitmapHeight - 1



        'Computing integral sum of the first row
        Temp_IntegralGrayImageMap(x1, y1) = _OutPixels(_PixelIndex(x1, y1).Blue)
        For x As Integer = x1 + 1 To x2
            Temp_IntegralGrayImageMap(x, y1) = Temp_IntegralGrayImageMap(x - 1, y1) +
                                             _OutPixels(_PixelIndex(x1, y1).Blue)
        Next
        'Computing integral sum of the first column
        For y As Integer = y1 + 1 To y2
            Temp_IntegralGrayImageMap(x1, y) = Temp_IntegralGrayImageMap(x1, y - 1) +
                                            _OutPixels(_PixelIndex(x1, y1).Blue)
        Next

        'Computing integral sum for the rest of points
        For y As Integer = y1 + 1 To y2
            For x As Integer = x1 + 1 To x2
                Temp_IntegralGrayImageMap(x, y) = _OutPixels(_PixelIndex(x, y).Blue) +
                                                Temp_IntegralGrayImageMap(x - 1, y) +
                                                Temp_IntegralGrayImageMap(x, y - 1) -
                                                Temp_IntegralGrayImageMap(x - 1, y - 1)

            Next
        Next


        Return Temp_IntegralGrayImageMap
    End Function


    Private Shared Function Calculate_LocalGrayAvgValue(ByRef IntegralGrayImageMap(,) As Long,
                                           ByVal LocalBoxSize As Integer,
                                           ByVal CenterX As Integer,
                                           ByVal CenterY As Integer) As Byte
        Dim LocalBoxSum As Long
        Dim LocalBoxAvg As Byte
        Dim LocalBoxX1, LocalBoxX2, LocalBoxY1, LocalBoxY2 As Integer
        Dim LocalBoxHalfSize As Integer = CInt((LocalBoxSize - 1) / 2)

        LocalBoxX1 = Max(CenterX - LocalBoxHalfSize, 1)
        LocalBoxY1 = Max(CenterY - LocalBoxHalfSize, 1)

        LocalBoxX2 = Min(CenterX + LocalBoxHalfSize,
                         IntegralGrayImageMap.GetUpperBound(0))
        LocalBoxY2 = Min(CenterY + LocalBoxHalfSize,
                         IntegralGrayImageMap.GetUpperBound(1))


        LocalBoxSum = IntegralGrayImageMap(LocalBoxX2, LocalBoxY2)
        LocalBoxSum -= IntegralGrayImageMap(LocalBoxX2, LocalBoxY1 - 1)
        LocalBoxSum -= IntegralGrayImageMap(LocalBoxX1 - 1, LocalBoxY2)
        LocalBoxSum += IntegralGrayImageMap(LocalBoxX1 - 1, LocalBoxY1 - 1)

        LocalBoxAvg = CByte(LocalBoxSum / ((LocalBoxX2 - LocalBoxX1 + 1) *
                                          (LocalBoxY2 - LocalBoxY1 + 1)))

        Return LocalBoxAvg
    End Function



    Public Function Build_IntegralGrayImageMap_From2DByteArray(SrcByteArray(,) As Byte) As Long(,)
        x1 = 0
        y1 = 0
        x2 = SrcByteArray.GetUpperBound(0)
        y2 = SrcByteArray.GetUpperBound(1)

        Dim Temp_IntegralGrayImageMap(x2, y2) As Long

        'Computing integral sum of the first row
        Temp_IntegralGrayImageMap(x1, y1) = SrcByteArray(x1, y1)
        For x As Integer = x1 + 1 To x2
            Temp_IntegralGrayImageMap(x, y1) = Temp_IntegralGrayImageMap(x - 1, y1) +
                                             SrcByteArray(x1, y1)
        Next
        'Computing integral sum of the first column
        For y As Integer = y1 + 1 To y2
            Temp_IntegralGrayImageMap(x1, y) = Temp_IntegralGrayImageMap(x1, y - 1) +
                                           SrcByteArray(x1, y1)
        Next

        'Computing integral sum for the rest of points
        For y As Integer = y1 + 1 To y2
            For x As Integer = x1 + 1 To x2
                Temp_IntegralGrayImageMap(x, y) = SrcByteArray(x, y) +
                                                Temp_IntegralGrayImageMap(x - 1, y) +
                                                Temp_IntegralGrayImageMap(x, y - 1) -
                                                Temp_IntegralGrayImageMap(x - 1, y - 1)

            Next
        Next


        Return Temp_IntegralGrayImageMap
    End Function



    Public Function Draw_Rectangles(ByVal Pic_Target As Image,
                          ByVal SourceRectangles() As Rectangle,
                          ByVal LineColor As Color) As Image

        If Pic_Target Is Nothing Then
            Return CType(Pic_Target.Clone, Bitmap)
        End If


        Using bm As New Bitmap(Pic_Target),
                 GraphBox As Graphics = Graphics.FromImage(bm),
                 myPen As New Pen(Color.Black)

            myPen.Color = LineColor
            For Each CurRectangle As Rectangle In SourceRectangles
                GraphBox.DrawRectangle(myPen, CurRectangle)
            Next

            Draw_Rectangles = CType(bm.Clone(), Bitmap)
        End Using

    End Function

    Public Function Draw_Text_Outlined_Image(ByVal SourceImage As Image,
                               ByVal x As Integer,
                               ByVal y As Integer,
                               ByVal TextString As String,
                               ByVal TextFont As Font,
                               ByVal InnerColor As Color,
                               ByVal OuterColor As Color) As Image
        Using bm As New Bitmap(SourceImage),
                 GraphBox As Graphics = Graphics.FromImage(bm)

            Call Draw_Text_Outlined_Graphics(
                    GraphBox, x, y, TextString, TextFont, InnerColor, OuterColor)

            Draw_Text_Outlined_Image = CType(bm.Clone, Bitmap)
        End Using
    End Function


    Public Sub Draw_Text_Outlined_Graphics(SourceGraphics As Graphics,
                               ByVal x As Integer,
                               ByVal y As Integer,
                               ByVal TextString As String,
                               ByVal TextFont As Font,
                               ByVal InnerColor As Color,
                               ByVal OuterColor As Color)



        With SourceGraphics
            Dim DrawingTextBrush As Brush = New SolidBrush(OuterColor)
            .DrawString(TextString, TextFont, DrawingTextBrush, x - 1, y - 1)
            .DrawString(TextString, TextFont, DrawingTextBrush, x - 1, y + 1)
            .DrawString(TextString, TextFont, DrawingTextBrush, x + 1, y + 1)
            .DrawString(TextString, TextFont, DrawingTextBrush, x + 1, y - 1)

            DrawingTextBrush = New SolidBrush(InnerColor)
            .DrawString(TextString, TextFont, DrawingTextBrush, x, y)

            DrawingTextBrush.Dispose()
            DrawingTextBrush = Nothing
        End With
    End Sub


    Public Function StandardFilter(ByVal SourceImage As Image,
                                    ByVal FilterMask(,) As Single,
                                    Optional ByVal WeightFactor As Integer = 0,
                                    Optional ByVal MaskImage As Image = Nothing,
                                    Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                    Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap


        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)

        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        Dim PixelCount As Integer
        Dim BitmapHeightUpper, BitmapWidthUpper As Integer
        Dim BorderHeightUpper, BorderWidthUpper As Integer
        Dim CellHeightStart, CellHeightEnd As Integer
        Dim CellWidthStart, CellWidthEnd As Integer
        Dim CellWidthPixelCount, CellHeightPixelCount As Integer
        Dim SelectRegionWidthStart, SelectRegionWidthEnd As Integer
        Dim SelectRegionHeightStart, SelectRegionHeightEnd As Integer
        Dim BoxSize As Integer = FilterMask.GetUpperBound(0)
        Dim BoxSizePixelCount As Integer = CInt(BoxSize ^ 2)
        Dim BoxSizeHalf As Integer = CInt(Int(BoxSize / 2))
        Dim Multi_Factor As Single

        BitmapHeightUpper = _SrcBitmapHeight - 1
        BitmapWidthUpper = _SrcBitmapWidth - 1
        BorderHeightUpper = _SrcBitmapHeight - BoxSizeHalf - 1
        BorderWidthUpper = _SrcBitmapWidth - BoxSizeHalf - 1


        Call Normalize_StandardFilterMask(FilterMask, WeightFactor)


        If IsMaskAllRegionSelected Then


            PixelCount = BoxSizePixelCount
            For y As Integer = BoxSizeHalf To BorderHeightUpper
                For x As Integer = BoxSizeHalf To BorderWidthUpper

                    _Buf_Red = 0 : _Buf_Green = 0 : _Buf_Blue = 0
                    CellWidthStart = x - BoxSizeHalf
                    CellWidthEnd = x + BoxSizeHalf
                    CellHeightStart = y - BoxSizeHalf
                    CellHeightEnd = y + BoxSizeHalf

                    For y2 As Integer = CellHeightStart To CellHeightEnd
                        For x2 As Integer = CellWidthStart To CellWidthEnd
                            With _PixelIndex(x2, y2)
                                _Buf_Red += (_SrcPixels(.Blue + AtRed)) *
                                                FilterMask(y2 - CellHeightStart + 1,
                                                      x2 - CellWidthStart + 1)

                                _Buf_Green += (_SrcPixels(.Blue + AtGreen)) *
                                                FilterMask(y2 - CellHeightStart + 1,
                                                      x2 - CellWidthStart + 1)

                                _Buf_Blue += (_SrcPixels(.Blue)) *
                                                FilterMask(y2 - CellHeightStart + 1,
                                                      x2 - CellWidthStart + 1)
                            End With
                        Next
                    Next

                    If _Buf_Red < 0 Then
                        _Buf_Red = 0
                    ElseIf _Buf_Red > 255 Then
                        _Buf_Red = 255
                    End If

                    If _Buf_Green < 0 Then
                        _Buf_Green = 0
                    ElseIf _Buf_Green > 255 Then
                        _Buf_Green = 255
                    End If

                    If _Buf_Blue < 0 Then
                        _Buf_Blue = 0
                    ElseIf _Buf_Blue > 255 Then
                        _Buf_Blue = 255
                    End If

                    With _PixelIndex(x, y)
                        _OutPixels(.Blue + AtRed) = CByte(_Buf_Red)
                        _OutPixels(.Blue + AtGreen) = CByte(_Buf_Green)
                        _OutPixels(.Blue) = CByte(_Buf_Blue)
                    End With

                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 90))
            Next y


            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper

                    Call Process_BoundaryRegion(BitmapWidthUpper, BitmapHeightUpper,
                                                BorderWidthUpper, BorderHeightUpper,
                                                x, y, BoxSizeHalf,
                                                CellWidthStart, CellWidthEnd,
                                                CellHeightStart, CellHeightEnd,
                                                CellWidthPixelCount, CellHeightPixelCount,
                                                PixelCount)


                    _Buf_Red = 0 : _Buf_Green = 0 : _Buf_Blue = 0
                    If x < BoxSizeHalf Then
                        dx = BoxSizeHalf - x
                    Else
                        dx = 0
                    End If
                    If y < BoxSizeHalf Then
                        dy = BoxSizeHalf - y
                    Else
                        dy = 0
                    End If

                    For y2 As Integer = CellHeightStart To CellHeightEnd
                        For x2 As Integer = CellWidthStart To CellWidthEnd
                            With _PixelIndex(x2, y2)
                                _Buf_Red += (_SrcPixels(.Blue + AtRed)) *
                                                FilterMask(y2 - CellHeightStart + dy + 1,
                                                      x2 - CellWidthStart + dx + 1)
                                _Buf_Green += (_SrcPixels(.Blue + AtGreen)) *
                                                FilterMask(y2 - CellHeightStart + dy + 1,
                                                      x2 - CellWidthStart + dx + 1)
                                _Buf_Blue += (_SrcPixels(.Blue)) *
                                                FilterMask(y2 - CellHeightStart + dy + 1,
                                                      x2 - CellWidthStart + dx + 1)
                            End With
                        Next
                    Next

                    Multi_Factor = CSng(PixelCount / BoxSizePixelCount)
                    _Buf_Red = _Buf_Red * Multi_Factor
                    _Buf_Green = _Buf_Green * Multi_Factor
                    _Buf_Blue = _Buf_Blue * Multi_Factor

                    If _Buf_Red < 0 Then
                        _Buf_Red = 0
                    ElseIf _Buf_Red > 255 Then
                        _Buf_Red = 255
                    End If

                    If _Buf_Green < 0 Then
                        _Buf_Green = 0
                    ElseIf _Buf_Green > 255 Then
                        _Buf_Green = 255
                    End If

                    If _Buf_Blue < 0 Then
                        _Buf_Blue = 0
                    ElseIf _Buf_Blue > 255 Then
                        _Buf_Blue = 255
                    End If

                    With _PixelIndex(x, y)
                        _OutPixels(.Blue + AtRed) = CByte(_Buf_Red)
                        _OutPixels(.Blue + AtGreen) = CByte(_Buf_Green)
                        _OutPixels(.Blue) = CByte(_Buf_Blue)
                    End With
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 10) + 90)
            Next y


        Else

            With MaskRegionBoundary
                SelectRegionWidthStart = Math.Max(BoxSizeHalf, .Left)
                SelectRegionWidthEnd = Math.Min(BorderWidthUpper, .Right)
                SelectRegionHeightStart = Math.Max(BoxSizeHalf, .Top)
                SelectRegionHeightEnd = Math.Min(BorderHeightUpper, .Bottom)
            End With

            PixelCount = CInt((BoxSizeHalf * 2 + 1) ^ 2)
            For y As Integer = SelectRegionHeightStart To SelectRegionHeightEnd
                For x As Integer = SelectRegionWidthStart To SelectRegionWidthEnd

                    If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) = 0 Then
                        _Buf_Red = 0 : _Buf_Green = 0 : _Buf_Blue = 0
                        CellWidthStart = x - BoxSizeHalf
                        CellWidthEnd = x + BoxSizeHalf
                        CellHeightStart = y - BoxSizeHalf
                        CellHeightEnd = y + BoxSizeHalf

                        For y2 As Integer = CellHeightStart To CellHeightEnd
                            For x2 As Integer = CellWidthStart To CellWidthEnd
                                With _PixelIndex(x2, y2)
                                    _Buf_Red += (_SrcPixels(.Blue + AtRed)) *
                                                    FilterMask(y2 - CellHeightStart + 1,
                                                          x2 - CellWidthStart + 1)

                                    _Buf_Green += (_SrcPixels(.Blue + AtGreen)) *
                                                    FilterMask(y2 - CellHeightStart + 1,
                                                          x2 - CellWidthStart + 1)

                                    _Buf_Blue += (_SrcPixels(.Blue)) *
                                                    FilterMask(y2 - CellHeightStart + 1,
                                                          x2 - CellWidthStart + 1)
                                End With
                            Next
                        Next

                        If _Buf_Red < 0 Then
                            _Buf_Red = 0
                        ElseIf _Buf_Red > 255 Then
                            _Buf_Red = 255
                        End If

                        If _Buf_Green < 0 Then
                            _Buf_Green = 0
                        ElseIf _Buf_Green > 255 Then
                            _Buf_Green = 255
                        End If

                        If _Buf_Blue < 0 Then
                            _Buf_Blue = 0
                        ElseIf _Buf_Blue > 255 Then
                            _Buf_Blue = 255
                        End If


                        With _PixelIndex(x, y)
                            _OutPixels(.Blue + AtRed) = CByte(_Buf_Red)
                            _OutPixels(.Blue + AtGreen) = CByte(_Buf_Green)
                            _OutPixels(.Blue) = CByte(_Buf_Blue)
                        End With
                    End If
                Next x

                RaiseEvent Processing(CSng((y - SelectRegionHeightStart) /
                                      (SelectRegionHeightEnd - SelectRegionHeightStart + 1) * 90))
            Next y



            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    Call Process_BoundaryRegion(BitmapWidthUpper, BitmapHeightUpper,
                                                BorderWidthUpper, BorderHeightUpper,
                                                x, y, BoxSizeHalf,
                                                CellWidthStart, CellWidthEnd,
                                                CellHeightStart, CellHeightEnd,
                                                CellWidthPixelCount, CellHeightPixelCount,
                                                PixelCount)


                    If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) = 0 Then
                        _Buf_Red = 0 : _Buf_Green = 0 : _Buf_Blue = 0
                        If x < BoxSizeHalf Then
                            dx = BoxSizeHalf - x
                        Else
                            dx = 0
                        End If
                        If y < BoxSizeHalf Then
                            dy = BoxSizeHalf - y
                        Else
                            dy = 0
                        End If

                        For y2 As Integer = CellHeightStart To CellHeightEnd
                            For x2 As Integer = CellWidthStart To CellWidthEnd
                                With _PixelIndex(x2, y2)
                                    _Buf_Red += (_SrcPixels(.Blue + AtRed)) *
                                                    FilterMask(y2 - CellHeightStart + dy + 1,
                                                          x2 - CellWidthStart + dx + 1)
                                    _Buf_Green += (_SrcPixels(.Blue + AtGreen)) *
                                                    FilterMask(y2 - CellHeightStart + dy + 1,
                                                          x2 - CellWidthStart + dx + 1)
                                    _Buf_Blue += (_SrcPixels(.Blue)) *
                                                    FilterMask(y2 - CellHeightStart + dy + 1,
                                                          x2 - CellWidthStart + dx + 1)
                                End With
                            Next
                        Next

                        ' Multi_Factor = CSng(BoxSizePixelCount / PixelCount)
                        ' _Buf_Red = _Buf_Red * Multi_Factor
                        ' _Buf_Green = _Buf_Green * Multi_Factor
                        ' _Buf_Blue = _Buf_Blue * Multi_Factor

                        If _Buf_Red < 0 Then
                            _Buf_Red = 0
                        ElseIf _Buf_Red > 255 Then
                            _Buf_Red = 255
                        End If

                        If _Buf_Green < 0 Then
                            _Buf_Green = 0
                        ElseIf _Buf_Green > 255 Then
                            _Buf_Green = 255
                        End If

                        If _Buf_Blue < 0 Then
                            _Buf_Blue = 0
                        ElseIf _Buf_Blue > 255 Then
                            _Buf_Blue = 255
                        End If

                        With _PixelIndex(x, y)
                            _OutPixels(.Blue + AtRed) = CByte(_Buf_Red)
                            _OutPixels(.Blue + AtGreen) = CByte(_Buf_Green)
                            _OutPixels(.Blue) = CByte(_Buf_Blue)
                        End With
                    End If
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 10) + 90)
            Next y
        End If

        Return OutPixelsToImage()

    End Function


    Private Sub Normalize_StandardFilterMask(ByRef SourceFilterMask(,) As Single,
                                             Optional ByVal WeightFactor As Integer = 0)
        Dim ValueCount As Integer = 0
        Dim MaskSize As Integer = SourceFilterMask.GetUpperBound(0)
        Dim IsContainedNegativeValue As Boolean = False
        Dim xValue As Integer

        'Calculate Sum
        If WeightFactor = 0 Then
            For x As Integer = 1 To MaskSize
                For y As Integer = 1 To MaskSize
                    ValueCount = CInt(ValueCount + SourceFilterMask(x, y))
                    If SourceFilterMask(x, y) < 0 Then IsContainedNegativeValue = True
                Next
            Next
        Else
            IsContainedNegativeValue = False
            ValueCount = WeightFactor
        End If




        If IsContainedNegativeValue Then
            xValue = CInt(MaskSize ^ 2)
        Else
            xValue = ValueCount
        End If



        For x As Integer = 1 To MaskSize
            For y As Integer = 1 To MaskSize
                SourceFilterMask(x, y) = SourceFilterMask(x, y) / xValue
            Next
        Next
    End Sub



    Public Function BWLeveling_Using_AdaptiveThreshold(ByVal SourceImage As Image,
                              ByVal LocalBoxSizeValue As Integer,
                              ByVal IsObjectWhite As Boolean,
                              ByVal ThresholdLevel As Integer,
                              Optional ByVal MaskImage As Image = Nothing,
                              Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                              Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap




        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)


        Static LocalBoxSize As Integer = 15

        If LocalBoxSizeValue > 0 Then
            LocalBoxSize = LocalBoxSizeValue
        End If


        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        Dim Temp_IntegralGrayMap(,) As Long
        Dim LocalGrayAvg As Byte
        Dim Gray As Byte
        Dim tPercentValue As Single = CSng(ThresholdLevel / 100)
        Dim Color_Background As Byte
        Dim Color_Object As Byte



        'Grayscaling and inverting...
        If IsObjectWhite Then
            For y As Integer = 0 To _SrcBitmapHeight - 1
                For x As Integer = 0 To _SrcBitmapWidth - 1

                    With _PixelIndex(x, y)
                        Gray = CByte(255 - RGBToGray(_SrcPixels(.Blue + AtRed),
                                             _SrcPixels(.Blue + AtGreen),
                                             _SrcPixels(.Blue)))
                        _OutPixels(.Blue + AtRed) = Gray
                        _OutPixels(.Blue + AtGreen) = Gray
                        _OutPixels(.Blue) = Gray
                    End With

                Next x

            Next y

            Color_Object = 0
            Color_Background = 255
        Else
            For y As Integer = 0 To _SrcBitmapHeight - 1
                For x As Integer = 0 To _SrcBitmapWidth - 1

                    With _PixelIndex(x, y)
                        Gray = RGBToGray(_SrcPixels(.Blue + AtRed),
                                             _SrcPixels(.Blue + AtGreen),
                                             _SrcPixels(.Blue))
                        _OutPixels(.Blue + AtRed) = Gray
                        _OutPixels(.Blue + AtGreen) = Gray
                        _OutPixels(.Blue) = Gray
                    End With

                Next x

            Next y

            Color_Object = 255
            Color_Background = 0
        End If


        Temp_IntegralGrayMap = Build_IntegralGrayImageMap()



        If IsMaskAllRegionSelected Then


            For y As Integer = 0 To _SrcBitmapHeight - 1
                For x As Integer = 0 To _SrcBitmapWidth - 1

                    With _PixelIndex(x, y)
                        LocalGrayAvg = Calculate_LocalGrayAvgValue(Temp_IntegralGrayMap,
                                                          LocalBoxSize, x, y)
                        If _OutPixels(.Blue + AtRed) < LocalGrayAvg * tPercentValue Then
                            _OutPixels(.Blue + AtRed) = Color_Background
                            _OutPixels(.Blue + AtGreen) = Color_Background
                            _OutPixels(.Blue) = Color_Background
                        Else
                            _OutPixels(.Blue + AtRed) = Color_Object
                            _OutPixels(.Blue + AtGreen) = Color_Object
                            _OutPixels(.Blue) = Color_Object
                        End If
                    End With

                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 100))
            Next y

        Else


            For y As Integer = 0 To _SrcBitmapHeight - 1
                For x As Integer = 0 To _SrcBitmapWidth - 1
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Blue) = 0 Then
                            LocalGrayAvg = Calculate_LocalGrayAvgValue(Temp_IntegralGrayMap,
                                                          LocalBoxSize, x, y)
                            If _OutPixels(.Blue + AtRed) < LocalGrayAvg * tPercentValue Then
                                _OutPixels(.Blue + AtRed) = Color_Background
                                _OutPixels(.Blue + AtGreen) = Color_Background
                                _OutPixels(.Blue) = Color_Background
                            Else
                                _OutPixels(.Blue + AtRed) = Color_Object
                                _OutPixels(.Blue + AtGreen) = Color_Object
                                _OutPixels(.Blue) = Color_Object
                            End If
                        Else
                            _OutPixels(.Blue + AtRed) = _SrcPixels(.Blue + AtRed)
                            _OutPixels(.Blue + AtGreen) = _SrcPixels(.Blue + AtGreen)
                            _OutPixels(.Blue) = _SrcPixels(.Blue)

                        End If
                    End With

                Next x

                RaiseEvent Processing(CSng((y - y1) / (y2 - y1 + 1) * 100))
            Next y

        End If




        RaiseEvent Completed(_LapseAsMilliSecond)

        Return OutPixelsToImage()

    End Function



    Public Function BoxAveraging_ByIntegralMap(ByVal SourceImage As Image,
                                    ByVal BoxSizeHalf As Integer,
                                Optional ByVal MaskImage As Image = Nothing,
                                Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap
        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)



        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        Dim CurColorArray(_SrcBitmapWidth - 1, _SrcBitmapHeight - 1) As Byte
        Dim Temp_IntegralGrayMap(,) As Long
        Dim BoxSize As Integer = BoxSizeHalf * 2 + 1



        If IsMaskAllRegionSelected Then

            For CurColorChannel As Integer = 0 To 2
                For y As Integer = 0 To _SrcBitmapHeight - 1
                    For x As Integer = 0 To _SrcBitmapWidth - 1
                        With _PixelIndex(x, y)
                            CurColorArray(x, y) = _OutPixels(.Blue + CurColorChannel)
                        End With
                    Next
                Next

                Temp_IntegralGrayMap =
                    Build_IntegralGrayImageMap_From2DByteArray(CurColorArray)


                For y As Integer = 0 To _SrcBitmapHeight - 1

                    For x As Integer = 0 To _SrcBitmapWidth - 1

                        With _PixelIndex(x, y)
                            _OutPixels(.Blue + CurColorChannel) =
                                Calculate_LocalGrayAvgValue(Temp_IntegralGrayMap,
                                                      BoxSize, x, y)
                        End With
                    Next x

                    RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 33) + CurColorChannel * 33)
                Next y

            Next
        Else


            With MaskRegionBoundary
                x1 = .X
                y1 = .Y
                x2 = .X + .Width - 1
                y2 = .Y + .Height - 1
            End With


            For CurColorChannel As Integer = 0 To 2
                For y As Integer = 0 To _SrcBitmapHeight - 1
                    For x As Integer = 0 To _SrcBitmapWidth - 1
                        With _PixelIndex(x, y)
                            CurColorArray(x, y) = _OutPixels(.Blue + CurColorChannel)
                        End With
                    Next
                Next

                Temp_IntegralGrayMap =
                    Build_IntegralGrayImageMap_From2DByteArray(CurColorArray)


                For y As Integer = y1 To y2
                    For x As Integer = x1 To x2
                        With _PixelIndex(x, y)
                            If _MaskPixels(.Blue) = 0 Then
                                _OutPixels(.Blue + CurColorChannel) =
                                Calculate_LocalGrayAvgValue(Temp_IntegralGrayMap,
                                                      BoxSize, x, y)
                            End If
                        End With
                    Next x

                    RaiseEvent Processing(CSng((y - y1) / _SrcBitmapHeight * 33) + CurColorChannel * 33)
                Next y
            Next
        End If


        RaiseEvent Completed(_LapseAsMilliSecond)

        Return OutPixelsToImage()

    End Function


    'Filter size should be 3, 5, or 7
    Public Function GaussianFilter(ByVal SourceImage As Image,
                                    ByVal FilterSize As Integer,
                                    Optional ByVal WeightFactor As Integer = 0,
                                    Optional ByVal MaskImage As Image = Nothing,
                                    Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                    Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap

        Dim GaussianFilterMask(,) As Single

        Select Case FilterSize
            Case 3
                GaussianFilterMask = {{0, 0, 0, 0},
                                      {0, 1, 2, 1},
                                      {0, 2, 4, 2},
                                      {0, 1, 2, 1}}
            Case 5
                GaussianFilterMask = {{0, 0, 0, 0, 0, 0},
                                      {0, 1, 1, 2, 1, 1},
                                      {0, 1, 2, 4, 2, 1},
                                      {0, 2, 4, 8, 4, 2},
                                      {0, 1, 2, 4, 2, 1},
                                      {0, 1, 1, 2, 1, 1}}
            Case 7
                GaussianFilterMask = {{0, 0, 0, 0, 0, 0, 0, 0},
                                      {0, 1, 1, 2, 2, 2, 1, 1},
                                      {0, 1, 2, 2, 4, 2, 2, 1},
                                      {0, 2, 2, 4, 8, 4, 2, 2},
                                      {0, 2, 4, 8, 16, 8, 4, 2},
                                      {0, 2, 2, 4, 8, 4, 2, 2},
                                      {0, 1, 2, 2, 4, 2, 2, 1},
                                      {0, 1, 1, 2, 2, 2, 1, 1}}
            Case Else
                Return CType(SourceImage, Bitmap)
        End Select



        Return StandardFilter(SourceImage, GaussianFilterMask, WeightFactor, MaskImage, MaskRegionBoundary, IsMaskAllRegionSelected)
    End Function



    Public Function Invert(ByVal SourceImage As Image,
                                Optional ByVal MaskImage As Image = Nothing,
                                Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap


        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)


        Call ImageTo_SrcPixels(SourceImage, MaskImage)

        If IsMaskAllRegionSelected Then

            For y As Integer = 0 To _SrcBitmapHeight - 1
                For x As Integer = 0 To _SrcBitmapWidth - 1

                    With _PixelIndex(x, y)
                        _OutPixels(.Red) = CByte(255 - _SrcPixels(.Red))
                        _OutPixels(.Green) = CByte(255 - _SrcPixels(.Green))
                        _OutPixels(.Blue) = CByte(255 - _SrcPixels(.Blue))
                    End With

                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 100))
            Next y

        Else
            With MaskRegionBoundary
                x1 = .X
                y1 = .Y
                x2 = .X + .Width - 1
                y2 = .Y + .Height - 1
            End With


            For y As Integer = y1 To y2
                For x As Integer = x1 To x2
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Blue) = 0 Then
                            _OutPixels(.Red) = CByte(255 - _SrcPixels(.Red))
                            _OutPixels(.Green) = CByte(255 - _SrcPixels(.Green))
                            _OutPixels(.Blue) = CByte(255 - _SrcPixels(.Blue))
                        End If
                    End With

                Next x

                RaiseEvent Processing(CSng((y - y1) / (y2 - y1 + 1) * 100))
            Next y
        End If


        Return OutPixelsToImage()
    End Function


    Public Function RemoveSinglePixels(ByVal SourceImage As Image,
                                       ByVal PixelColor As Short,
                              Optional ByVal MaskImage As Image = Nothing,
                              Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                              Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap

        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)

        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        If IsMaskAllRegionSelected Then
            For y As Integer = 1 To _SrcBitmapHeight - 2

                For x As Integer = 1 To _SrcBitmapWidth - 2

                    With _PixelIndex(x, y)
                        If _OutPixels(.Red) = 255 Then
                            If _OutPixels(_PixelIndex(x, y - 1).Blue) = 0 AndAlso
                                _OutPixels(_PixelIndex(x, y + 1).Blue) = 0 AndAlso
                                _OutPixels(_PixelIndex(x - 1, y).Blue) = 0 AndAlso
                                _OutPixels(_PixelIndex(x + 1, y).Blue) = 0 Then
                                _OutPixels(.Red) = 0
                                _OutPixels(.Green) = 0
                                _OutPixels(.Blue) = 0
                            End If
                        End If
                    End With

                Next x

            Next y

        Else

            With MaskRegionBoundary
                x1 = Math.Max(.X, 1)
                y1 = Math.Max(.Y, 1)
                x2 = Math.Min(.X + .Width - 1, _SrcBitmapWidth - 2)
                y2 = Math.Min(.Y + .Height - 1, _SrcBitmapHeight - 2)
            End With


            For y As Integer = y1 To y2
                For x As Integer = x1 To x2
                    With _PixelIndex(x, y)
                        If _OutPixels(.Red) = 255 Then
                            If _OutPixels(_PixelIndex(x, y - 1).Blue) = 0 AndAlso
                                _OutPixels(_PixelIndex(x, y + 1).Blue) = 0 AndAlso
                                _OutPixels(_PixelIndex(x - 1, y).Blue) = 0 AndAlso
                                _OutPixels(_PixelIndex(x + 1, y).Blue) = 0 Then
                                _OutPixels(.Red) = 0
                                _OutPixels(.Green) = 0
                                _OutPixels(.Blue) = 0
                            End If
                        End If
                    End With
                Next x

            Next y
        End If


        Return OutPixelsToImage()
    End Function


    Public Function RGBToHex(ByVal RedValue As Integer, ByVal GreenValue As Integer,
                             ByVal BlueValue As Integer) As String

        Dim StrBuf, Hex_R, Hex_G, Hex_B As String

        Hex_R = Hex(RedValue)
        Hex_G = Hex(GreenValue)
        Hex_B = Hex(BlueValue)

        If Hex_R.Length = 1 Then Hex_R = "0" + Hex_R
        If Hex_G.Length = 1 Then Hex_G = "0" + Hex_G
        If Hex_B.Length = 1 Then Hex_B = "0" + Hex_B


        StrBuf = Hex_R + Hex_G + Hex_B

        Return StrBuf
    End Function


    Public Function Create_MaskRectangle(CanvasWidth As Integer,
                               CanvasHeighT As Integer,
                               MaskRect As Rectangle) As Bitmap

        Using Temp_MaskBitmap As Bitmap = New Bitmap(CanvasWidth, CanvasHeighT),
                    Temp_grMaskBitmap As Graphics = Graphics.FromImage(Temp_MaskBitmap)

            Temp_grMaskBitmap.Clear(Color.White)
            Temp_grMaskBitmap.FillRectangle(New SolidBrush(Color.Black), MaskRect)

            Create_MaskRectangle = CType(Temp_MaskBitmap.Clone, Bitmap)
        End Using
    End Function

    Public Function Create_MaskRectangles(CanvasWidth As Integer,
                               CanvasHeighT As Integer,
                               MaskRects() As Rectangle) As Bitmap

        Using Temp_MaskBitmap As Bitmap = New Bitmap(CanvasWidth, CanvasHeighT),
                    Temp_grMaskBitmap As Graphics = Graphics.FromImage(Temp_MaskBitmap)

            Temp_grMaskBitmap.Clear(Color.White)

            For q As Integer = 0 To MaskRects.GetUpperBound(0)
                Temp_grMaskBitmap.FillRectangle(New SolidBrush(Color.Black), MaskRects(q))
            Next

            Create_MaskRectangles = CType(Temp_MaskBitmap.Clone, Bitmap)
        End Using
    End Function


    Public Function Create_MaskEllipse(CanvasWidth As Integer,
                               CanvasHeighT As Integer,
                               MaskRect As Rectangle) As Bitmap

        Using Temp_MaskBitmap As Bitmap = New Bitmap(CanvasWidth, CanvasHeighT),
                    Temp_grMaskBitmap As Graphics = Graphics.FromImage(Temp_MaskBitmap)

            Temp_grMaskBitmap.Clear(Color.White)
            Temp_grMaskBitmap.FillEllipse(New SolidBrush(Color.Black), MaskRect)
            Create_MaskEllipse = CType(Temp_MaskBitmap.Clone, Bitmap)
        End Using
    End Function


    Public Function Create_MaskImage(CanvasWidth As Integer,
                              CanvasHeighT As Integer,
                              MaskRects() As Rectangle,
                              ROIShape() As String) As Bitmap

        Using Temp_MaskBitmap As Bitmap = New Bitmap(CanvasWidth, CanvasHeighT),
                    Temp_grMaskBitmap As Graphics = Graphics.FromImage(Temp_MaskBitmap)

            Temp_grMaskBitmap.Clear(Color.White)
            For q As Integer = 0 To MaskRects.GetUpperBound(0)
                If ROIShape(q) = "rectangle" Then
                    Temp_grMaskBitmap.FillRectangle(New SolidBrush(Color.Black), MaskRects(q))
                ElseIf ROIShape(q) = "ellipse" Or ROIShape(q) = "circle" Then
                    Temp_grMaskBitmap.FillEllipse(New SolidBrush(Color.Black), MaskRects(q))
                End If
            Next
            Create_MaskImage = CType(Temp_MaskBitmap.Clone, Bitmap)
        End Using
    End Function



    'Return color value is BGR order!!!
    Public Function Get_PixelColor_From1PixelInScreen(ByVal TargetX As Integer,
                                   ByVal TargetY As Integer) As Integer

        Dim ColorValue As Integer

        Dim bmp As New Bitmap(1, 1)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.CopyFromScreen(TargetX, TargetY, 0, 0, bmp.Size)
        If bmp.PixelFormat <> PixelFormat.Format24bppRgb Then
            bmp = Convert_To_24bitmap(bmp)
        End If

        Dim pixelColor As Color = bmp.GetPixel(0, 0)
        ColorValue = RGBToColor(pixelColor.R, pixelColor.G, pixelColor.B)

        g.Dispose()
        g = Nothing
        bmp.Dispose()
        bmp = Nothing

        Return ColorValue
    End Function


    Public Function RGBToColor(ByVal _RedValue As Integer,
                                 ByVal _GreenValue As Integer,
                                 ByVal _BlueValue As Integer) As Integer
        Dim Buf_Value As Integer
        Buf_Value = (_RedValue << 16) _
                        Or (_GreenValue << 8) _
                        Or _BlueValue

        Return Buf_Value
    End Function



    Public Function GetX() As Integer
        Return Windows.Forms.Cursor.Position.X
    End Function


    Public Function GetY() As Integer
        Return Windows.Forms.Cursor.Position.Y
    End Function



    Public Function Maximize(ByVal SourceImage As Image,
                                        ByVal BoxSizeHalf As Integer,
                                Optional ByVal MaskImage As Image = Nothing,
                                Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                Optional ByVal IsMaskAllRegionSelected As Boolean = True,
                                Optional ByVal IsDoGrayScaling As Boolean = True) As Bitmap


        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)



        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        Dim PixelCount As Integer
        Dim BitmapHeightUpper, BitmapWidthUpper As Integer
        Dim BorderHeightUpper, BorderWidthUpper As Integer
        Dim CellHeightStart, CellHeightEnd As Integer
        Dim CellWidthStart, CellWidthEnd As Integer
        Dim CellWidthPixelCount, CellHeightPixelCount As Integer
        Dim SelectRegionWidthStart, SelectRegionWidthEnd As Integer
        Dim SelectRegionHeightStart, SelectRegionHeightEnd As Integer
        Dim Cur_GrayMax, Cur_Gray As Byte
        Dim Cur_Red, Cur_Blue, Cur_Green As Byte

        BitmapHeightUpper = _SrcBitmapHeight - 1
        BitmapWidthUpper = _SrcBitmapWidth - 1
        BorderHeightUpper = _SrcBitmapHeight - BoxSizeHalf - 1
        BorderWidthUpper = _SrcBitmapWidth - BoxSizeHalf - 1


        ReDim _GrayImage(BitmapWidthUpper, BitmapHeightUpper)


        If IsMaskAllRegionSelected Then

            If IsDoGrayScaling Then
                'Grayscaling
                For y As Integer = 0 To BitmapHeightUpper
                    For x As Integer = 0 To BitmapWidthUpper
                        With _PixelIndex(x, y)
                            _GrayImage(x, y) = CByte(RGBToGray(_SrcPixels(.Blue + AtRed),
                                              _SrcPixels(.Blue + AtGreen),
                                              _SrcPixels(.Blue)))
                        End With
                    Next x
                Next y
            Else
                For y As Integer = 0 To BitmapHeightUpper
                    For x As Integer = 0 To BitmapWidthUpper
                        With _PixelIndex(x, y)
                            _GrayImage(x, y) = _SrcPixels(.Blue + AtRed)
                        End With
                    Next x
                Next y
            End If



            PixelCount = CInt((BoxSizeHalf * 2 + 1) ^ 2)
            For y As Integer = BoxSizeHalf To BorderHeightUpper
                For x As Integer = BoxSizeHalf To BorderWidthUpper

                    Cur_GrayMax = 0 : Cur_Red = 0 : Cur_Green = 0 : Cur_Blue = 0
                    CellWidthStart = x - BoxSizeHalf
                    CellWidthEnd = x + BoxSizeHalf
                    CellHeightStart = y - BoxSizeHalf
                    CellHeightEnd = y + BoxSizeHalf

                    For y2 As Integer = CellHeightStart To CellHeightEnd
                        For x2 As Integer = CellWidthStart To CellWidthEnd
                            Cur_Gray = _GrayImage(x2, y2)
                            If Cur_Gray > Cur_GrayMax Then
                                With _PixelIndex(x2, y2)
                                    Cur_Red = _SrcPixels(.Blue + AtRed)
                                    Cur_Green = _SrcPixels(.Blue + AtGreen)
                                    Cur_Blue = _SrcPixels(.Blue)
                                End With
                                Cur_GrayMax = Cur_Gray
                            End If
                        Next
                    Next

                    With _PixelIndex(x, y)
                        _OutPixels(.Blue + AtRed) = Cur_Red
                        _OutPixels(.Blue + AtGreen) = Cur_Green
                        _OutPixels(.Blue) = Cur_Blue
                    End With
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 90))
            Next y


            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper

                    Call Process_BoundaryRegion(BitmapWidthUpper, BitmapHeightUpper,
                                                BorderWidthUpper, BorderHeightUpper,
                                                x, y, BoxSizeHalf,
                                                CellWidthStart, CellWidthEnd,
                                                CellHeightStart, CellHeightEnd,
                                                CellWidthPixelCount, CellHeightPixelCount,
                                                PixelCount)


                    Cur_GrayMax = 0 : Cur_Red = 0 : Cur_Green = 0 : Cur_Blue = 0
                    For y2 As Integer = CellHeightStart To CellHeightEnd
                        For x2 As Integer = CellWidthStart To CellWidthEnd
                            Cur_Gray = _GrayImage(x2, y2)
                            If Cur_Gray > Cur_GrayMax Then
                                With _PixelIndex(x2, y2)
                                    Cur_Red = _SrcPixels(.Blue + AtRed)
                                    Cur_Green = _SrcPixels(.Blue + AtGreen)
                                    Cur_Blue = _SrcPixels(.Blue)
                                End With
                                Cur_GrayMax = Cur_Gray
                            End If
                        Next
                    Next

                    With _PixelIndex(x, y)
                        _OutPixels(.Blue + AtRed) = Cur_Red
                        _OutPixels(.Blue + AtGreen) = Cur_Green
                        _OutPixels(.Blue) = Cur_Blue
                    End With
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 10) + 90)
            Next y



        Else


            'Generate gray image
            CellWidthStart = Math.Max(0, MaskRegionBoundary.Left - BoxSizeHalf)
            CellWidthEnd = Math.Min(BitmapWidthUpper, MaskRegionBoundary.Right + BoxSizeHalf)
            CellHeightStart = Math.Max(0, MaskRegionBoundary.Top - BoxSizeHalf)
            CellHeightEnd = Math.Min(BitmapHeightUpper, MaskRegionBoundary.Bottom + BoxSizeHalf)


            If IsDoGrayScaling Then
                For y As Integer = CellHeightStart To CellHeightEnd
                    For x As Integer = CellWidthStart To CellWidthEnd
                        With _PixelIndex(x, y)
                            _GrayImage(x, y) = CByte(RGBToGray(_SrcPixels(.Blue + AtRed),
                                              _SrcPixels(.Blue + AtGreen),
                                              _SrcPixels(.Blue)))
                        End With
                    Next x
                Next y
            Else
                For y As Integer = CellHeightStart To CellHeightEnd
                    For x As Integer = CellWidthStart To CellWidthEnd
                        With _PixelIndex(x, y)
                            _GrayImage(x, y) = _SrcPixels(.Blue + AtRed)
                        End With
                    Next x
                Next y
            End If


            With MaskRegionBoundary
                SelectRegionWidthStart = Math.Max(BoxSizeHalf, .Left)
                SelectRegionWidthEnd = Math.Min(BorderWidthUpper, .Right)
                SelectRegionHeightStart = Math.Max(BoxSizeHalf, .Top)
                SelectRegionHeightEnd = Math.Min(BorderHeightUpper, .Bottom)
            End With


            PixelCount = CInt((BoxSizeHalf * 2 + 1) ^ 2)
            For y As Integer = SelectRegionHeightStart To SelectRegionHeightEnd
                For x As Integer = SelectRegionWidthStart To SelectRegionWidthEnd

                    If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) = 0 Then
                        Cur_GrayMax = 0 : Cur_Red = 0 : Cur_Green = 0 : Cur_Blue = 0
                        CellWidthStart = x - BoxSizeHalf
                        CellWidthEnd = x + BoxSizeHalf
                        CellHeightStart = y - BoxSizeHalf
                        CellHeightEnd = y + BoxSizeHalf

                        For y2 As Integer = CellHeightStart To CellHeightEnd
                            For x2 As Integer = CellWidthStart To CellWidthEnd
                                Cur_Gray = _GrayImage(x2, y2)
                                If Cur_Gray > Cur_GrayMax Then
                                    With _PixelIndex(x2, y2)
                                        Cur_Red = _SrcPixels(.Blue + AtRed)
                                        Cur_Green = _SrcPixels(.Blue + AtGreen)
                                        Cur_Blue = _SrcPixels(.Blue)
                                    End With
                                    Cur_GrayMax = Cur_Gray
                                End If
                            Next
                        Next

                        With _PixelIndex(x, y)
                            _OutPixels(.Blue + AtRed) = Cur_Red
                            _OutPixels(.Blue + AtGreen) = Cur_Green
                            _OutPixels(.Blue) = Cur_Blue
                        End With
                    End If
                Next x

                RaiseEvent Processing(CSng((y - SelectRegionHeightStart) /
                                      (SelectRegionHeightEnd - SelectRegionHeightStart + 1) * 90))
            Next y



            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    Call Process_BoundaryRegion(BitmapWidthUpper, BitmapHeightUpper,
                                                BorderWidthUpper, BorderHeightUpper,
                                                x, y, BoxSizeHalf,
                                                CellWidthStart, CellWidthEnd,
                                                CellHeightStart, CellHeightEnd,
                                                CellWidthPixelCount, CellHeightPixelCount,
                                                PixelCount)


                    If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) = 0 Then

                        Cur_GrayMax = 0 : Cur_Red = 0 : Cur_Green = 0 : Cur_Blue = 0
                        For y2 As Integer = CellHeightStart To CellHeightEnd
                            For x2 As Integer = CellWidthStart To CellWidthEnd
                                Cur_Gray = _GrayImage(x2, y2)
                                If Cur_Gray > Cur_GrayMax Then
                                    With _PixelIndex(x2, y2)
                                        Cur_Red = _SrcPixels(.Blue + AtRed)
                                        Cur_Green = _SrcPixels(.Blue + AtGreen)
                                        Cur_Blue = _SrcPixels(.Blue)
                                    End With
                                    Cur_GrayMax = Cur_Gray
                                End If
                            Next
                        Next

                        With _PixelIndex(x, y)
                            _OutPixels(.Blue + AtRed) = Cur_Red
                            _OutPixels(.Blue + AtGreen) = Cur_Green
                            _OutPixels(.Blue) = Cur_Blue
                        End With
                    End If
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 10) + 90)
            Next y
        End If

        Return OutPixelsToImage()

    End Function


    Public Function EdgeDetect_by_ExplicitComp(ByVal SourceImage As Image,
                                              ByVal IsOverlay As Boolean,
                                Optional ByVal MaskImage As Image = Nothing,
                                Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap


        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)


        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        Dim PixelCount As Integer
        Dim BitmapHeightUpper, BitmapWidthUpper As Integer
        Dim BorderHeightUpper, BorderWidthUpper As Integer
        Dim CellHeightStart, CellHeightEnd As Integer
        Dim CellWidthStart, CellWidthEnd As Integer
        Dim CellWidthPixelCount, CellHeightPixelCount As Integer
        Dim SelectRegionWidthStart, SelectRegionWidthEnd As Integer
        Dim SelectRegionHeightStart, SelectRegionHeightEnd As Integer
        Dim BoxSizeHalf As Integer = 1
        Dim ARGBImage(_SrcBitmapWidth - 1, _SrcBitmapHeight - 1) As Integer


        BitmapHeightUpper = _SrcBitmapHeight - 1
        BitmapWidthUpper = _SrcBitmapWidth - 1
        BorderHeightUpper = _SrcBitmapHeight - BoxSizeHalf - 1
        BorderWidthUpper = _SrcBitmapWidth - BoxSizeHalf - 1



        If IsMaskAllRegionSelected Then

            'Check overlay option
            If IsOverlay = False Then
                For y As Integer = 0 To BitmapHeightUpper
                    For x As Integer = 0 To BitmapWidthUpper
                        With _PixelIndex(x, y)
                            _OutPixels(.Blue + AtRed) = 0
                            _OutPixels(.Blue + AtGreen) = 0
                            _OutPixels(.Blue) = 0
                        End With
                    Next
                Next
            End If


            'Build original ARGB image
            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    With _PixelIndex(x, y)
                        ARGBImage(x, y) = RGBToColor(_SrcPixels(.Blue + AtRed),
                                                      _SrcPixels(.Blue + AtGreen),
                                                       _SrcPixels(.Blue))
                    End With
                Next
            Next



            For y As Integer = BoxSizeHalf To BorderHeightUpper
                For x As Integer = BoxSizeHalf To BorderWidthUpper

                    If ARGBImage(x, y) <> ARGBImage(x, y - 1) Then
                        With _PixelIndex(x, y - 1)
                            If IsOverlay Then
                                _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                            Else
                                _OutPixels(.Blue + AtRed) = 255
                                _OutPixels(.Blue + AtGreen) = 255
                                _OutPixels(.Blue) = 255
                            End If
                        End With
                    End If
                    If ARGBImage(x, y) <> ARGBImage(x, y + 1) Then
                        With _PixelIndex(x, y + 1)
                            If IsOverlay Then
                                _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                            Else
                                _OutPixels(.Blue + AtRed) = 255
                                _OutPixels(.Blue + AtGreen) = 255
                                _OutPixels(.Blue) = 255
                            End If
                        End With
                    End If
                    If ARGBImage(x, y) <> ARGBImage(x - 1, y) Then
                        With _PixelIndex(x - 1, y)
                            If IsOverlay Then
                                _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                            Else
                                _OutPixels(.Blue + AtRed) = 255
                                _OutPixels(.Blue + AtGreen) = 255
                                _OutPixels(.Blue) = 255
                            End If
                        End With
                    End If
                    If ARGBImage(x, y) <> ARGBImage(x + 1, y) Then
                        With _PixelIndex(x + 1, y)
                            If IsOverlay Then
                                _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                            Else
                                _OutPixels(.Blue + AtRed) = 255
                                _OutPixels(.Blue + AtGreen) = 255
                                _OutPixels(.Blue) = 255
                            End If
                        End With
                    End If
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 90))
            Next y



            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper

                    Call Process_BoundaryRegion(BitmapWidthUpper, BitmapHeightUpper,
                                                BorderWidthUpper, BorderHeightUpper,
                                                x, y, BoxSizeHalf,
                                                CellWidthStart, CellWidthEnd,
                                                CellHeightStart, CellHeightEnd,
                                                CellWidthPixelCount, CellHeightPixelCount,
                                                PixelCount)

                    If y > 0 Then
                        If ARGBImage(x, y) <> ARGBImage(x, y - 1) Then
                            With _PixelIndex(x, y - 1)
                                If IsOverlay Then
                                    _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                    _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                    _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                Else
                                    _OutPixels(.Blue + AtRed) = 255
                                    _OutPixels(.Blue + AtGreen) = 255
                                    _OutPixels(.Blue) = 255
                                End If
                            End With
                        End If
                    End If

                    If y < BitmapHeightUpper Then
                        If ARGBImage(x, y) <> ARGBImage(x, y + 1) Then
                            With _PixelIndex(x, y + 1)
                                If IsOverlay Then
                                    _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                    _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                    _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                Else
                                    _OutPixels(.Blue + AtRed) = 255
                                    _OutPixels(.Blue + AtGreen) = 255
                                    _OutPixels(.Blue) = 255
                                End If
                            End With
                        End If
                    End If

                    If x > 0 Then
                        If ARGBImage(x, y) <> ARGBImage(x - 1, y) Then
                            With _PixelIndex(x - 1, y)
                                If IsOverlay Then
                                    _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                    _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                    _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                Else
                                    _OutPixels(.Blue + AtRed) = 255
                                    _OutPixels(.Blue + AtGreen) = 255
                                    _OutPixels(.Blue) = 255
                                End If
                            End With
                        End If
                    End If


                    If x < BitmapWidthUpper Then
                        If ARGBImage(x, y) <> ARGBImage(x + 1, y) Then
                            With _PixelIndex(x + 1, y)
                                If IsOverlay Then
                                    _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                    _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                    _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                Else
                                    _OutPixels(.Blue + AtRed) = 255
                                    _OutPixels(.Blue + AtGreen) = 255
                                    _OutPixels(.Blue) = 255
                                End If
                            End With
                        End If
                    End If
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 10) + 90)
            Next y




        Else


            With MaskRegionBoundary
                SelectRegionWidthStart = Math.Max(BoxSizeHalf, .Left + 1)
                SelectRegionWidthEnd = Math.Min(BitmapWidthUpper, .Right - 2)
                SelectRegionHeightStart = Math.Max(BoxSizeHalf, .Top + 1)
                SelectRegionHeightEnd = Math.Min(BitmapHeightUpper, .Bottom - 2)
            End With


            'Check overlay option
            If IsOverlay = False Then
                For y As Integer = SelectRegionHeightStart - 1 To SelectRegionHeightEnd + 1
                    For x As Integer = SelectRegionWidthStart - 1 To SelectRegionWidthEnd + 1
                        With _PixelIndex(x, y)
                            If _MaskPixels(.Blue) = 0 Then
                                _OutPixels(.Blue + AtRed) = 0
                                _OutPixels(.Blue + AtGreen) = 0
                                _OutPixels(.Blue) = 0
                            End If
                        End With
                    Next
                Next
            End If


            'Build original ARGB image
            Dim YStart, YEnd, XStart, XEnd As Integer
            With MaskRegionBoundary
                XStart = Math.Max(0, .Left - 1)
                XEnd = Math.Min(BitmapWidthUpper, .Right + 1)
                YStart = Math.Max(0, .Top - 1)
                YEnd = Math.Min(BitmapHeightUpper, .Bottom + 1)
            End With


            For y As Integer = YStart To YEnd
                For x As Integer = XStart To XEnd
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Blue) = 0 Then
                            ARGBImage(x, y) = RGBToColor(_SrcPixels(.Blue + AtRed),
                                                          _SrcPixels(.Blue + AtGreen),
                                                           _SrcPixels(.Blue))
                        End If
                    End With
                Next
            Next



            For y As Integer = SelectRegionHeightStart To SelectRegionHeightEnd
                For x As Integer = SelectRegionWidthStart To SelectRegionWidthEnd

                    If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) = 0 Then
                        If ARGBImage(x, y) <> ARGBImage(x, y - 1) Then
                            If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) =
                                        _MaskPixels(_PixelIndex(x, y - 1).Blue + AtRed) Then
                                With _PixelIndex(x, y - 1)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If
                        If ARGBImage(x, y) <> ARGBImage(x, y + 1) Then
                            If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) =
                                        _MaskPixels(_PixelIndex(x, y + 1).Blue + AtRed) Then
                                With _PixelIndex(x, y + 1)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If
                        If ARGBImage(x, y) <> ARGBImage(x - 1, y) Then
                            If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) =
                                        _MaskPixels(_PixelIndex(x - 1, y).Blue + AtRed) Then
                                With _PixelIndex(x - 1, y)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If
                        If ARGBImage(x, y) <> ARGBImage(x + 1, y) Then
                            If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) =
                                        _MaskPixels(_PixelIndex(x + 1, y).Blue + AtRed) Then
                                With _PixelIndex(x + 1, y)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If
                    End If
                Next x

                RaiseEvent Processing(CSng((y - SelectRegionHeightStart) /
                                      (SelectRegionHeightEnd - SelectRegionHeightStart + 1) * 90))
            Next y



            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    Call Process_BoundaryRegion(BitmapWidthUpper, BitmapHeightUpper,
                                                BorderWidthUpper, BorderHeightUpper,
                                                x, y, BoxSizeHalf,
                                                CellWidthStart, CellWidthEnd,
                                                CellHeightStart, CellHeightEnd,
                                                CellWidthPixelCount, CellHeightPixelCount,
                                                PixelCount)


                    If _MaskPixels(_PixelIndex(x, y).Blue + AtRed) = 0 Then
                        If y > 0 Then
                            If ARGBImage(x, y) <> ARGBImage(x, y - 1) Then
                                With _PixelIndex(x, y - 1)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If

                        If y < BitmapHeightUpper Then
                            If ARGBImage(x, y) <> ARGBImage(x, y + 1) Then
                                With _PixelIndex(x, y + 1)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If

                        If x > 0 Then
                            If ARGBImage(x, y) <> ARGBImage(x - 1, y) Then
                                With _PixelIndex(x - 1, y)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If


                        If x < BitmapWidthUpper Then
                            If ARGBImage(x, y) <> ARGBImage(x + 1, y) Then
                                With _PixelIndex(x + 1, y)
                                    If IsOverlay Then
                                        _OutPixels(.Blue + AtRed) = CByte(255 Xor _SrcPixels(.Blue + AtRed))
                                        _OutPixels(.Blue + AtGreen) = CByte(255 Xor _SrcPixels(.Blue + AtGreen))
                                        _OutPixels(.Blue) = CByte(255 Xor _SrcPixels(.Blue))
                                    Else
                                        _OutPixels(.Blue + AtRed) = 255
                                        _OutPixels(.Blue + AtGreen) = 255
                                        _OutPixels(.Blue) = 255
                                    End If
                                End With
                            End If
                        End If
                    End If
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 10) + 90)
            Next y
        End If

        Return OutPixelsToImage()
    End Function



    'SourceImage
    Public Function Overlay_Image(ByRef SourceImage As Image,
                                ByRef SourceMaskImage As Byte(,,),
                                ByVal BackgroundColorRGBInt_InMaskImage As Integer,
                                Optional ByVal MaskImage As Image = Nothing,
                                Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap

        If SourceImage Is Nothing Then Return CType(SourceImage, Bitmap)


        Call ImageTo_SrcPixels(SourceImage, MaskImage)


        If IsMaskAllRegionSelected Then

            Dim BitmapHeightUpper, BitmapWidthUpper As Integer
            BitmapHeightUpper = _SrcBitmapHeight - 1
            BitmapWidthUpper = _SrcBitmapWidth - 1


            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper

                    With _PixelIndex(x, y)
                        If RGBToColor(SourceMaskImage(x, y, 0),
                                    SourceMaskImage(x, y, 1),
                                     SourceMaskImage(x, y, 2)) <> BackgroundColorRGBInt_InMaskImage Then

                            _OutPixels(.Blue + AtRed) = SourceMaskImage(x, y, 0)
                            _OutPixels(.Blue + AtGreen) = SourceMaskImage(x, y, 1)
                            _OutPixels(.Blue) = SourceMaskImage(x, y, 2)
                        End If
                    End With

                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 100))
            Next y
        Else
            With MaskRegionBoundary
                x1 = .X
                y1 = .Y
                x2 = .X + .Width - 1
                y2 = .Y + .Height - 1
            End With


            For y As Integer = y1 To y2
                For x As Integer = x1 To x2
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Blue) = 0 Then
                            If RGBToColor(_SrcPixels(.Blue + AtRed),
                                    _SrcPixels(.Blue + AtGreen),
                                    _SrcPixels(.Blue)) = BackgroundColorRGBInt_InMaskImage Then

                                _OutPixels(.Blue + AtRed) = SourceMaskImage(x, y, 0)
                                _OutPixels(.Blue + AtGreen) = SourceMaskImage(x, y, 1)
                                _OutPixels(.Blue) = SourceMaskImage(x, y, 2)
                            End If
                        End If
                    End With

                Next x

                RaiseEvent Processing(CSng((y - y1) / (y2 - y1 + 1) * 100))
            Next y
        End If


        Return OutPixelsToImage()
    End Function



    Public Function Convert_RGBImage_To_RGBByteArray(ByVal SourceImage As Image,
                             Optional ByVal MaskImage As Image = Nothing,
                             Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                             Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Byte(,,)


        If SourceImage Is Nothing Then Return Nothing

        Call ImageTo_SrcPixels(SourceImage, MaskImage)

        Dim Temp_3DByteArray(_SrcBitmapWidth - 1, _SrcBitmapHeight - 1, 2) As Byte

        If IsMaskAllRegionSelected Then
            For y As Integer = 0 To _SrcBitmapHeight - 1

                For x As Integer = 0 To _SrcBitmapWidth - 1

                    With _PixelIndex(x, y)
                        Temp_3DByteArray(x, y, 0) = _OutPixels(.Blue + AtRed)
                        Temp_3DByteArray(x, y, 1) = _OutPixels(.Blue + AtGreen)
                        Temp_3DByteArray(x, y, 2) = _OutPixels(.Blue)
                    End With
                Next x
            Next y

        Else

            With MaskRegionBoundary
                x1 = .X
                y1 = .Y
                x2 = .X + .Width - 1
                y2 = .Y + .Height - 1
            End With


            For y As Integer = y1 To y2
                For x As Integer = x1 To x2
                    With _PixelIndex(x, y)
                        If _MaskPixels(.Blue) = 0 Then
                            Temp_3DByteArray(x, y, 0) = _OutPixels(.Blue + AtRed)
                            Temp_3DByteArray(x, y, 1) = _OutPixels(.Blue + AtGreen)
                            Temp_3DByteArray(x, y, 2) = _OutPixels(.Blue)
                        End If
                    End With
                Next x

            Next y
        End If

        OutPixelsToImage()


        Return Temp_3DByteArray
    End Function



    Public Function Crop(ByVal SourceImage As Image,
                    ByVal nWidth As Integer,
                    ByVal nHeight As Integer,
                    ByVal TargetX As Integer,
                    ByVal TargetY As Integer) As Bitmap

        Using bm As New Bitmap(SourceImage),
                Temp_bm As New Bitmap(nWidth, nHeight),
                g As Graphics = Graphics.FromImage(Temp_bm)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            g.DrawImage(bm, New Rectangle(0, 0, nWidth, nHeight),
                        TargetX, TargetY, nWidth, nHeight,
                        GraphicsUnit.Pixel)

            Crop = CType(Temp_bm.Clone, Bitmap)
            Crop.Tag = SourceImage.Tag
        End Using
    End Function



    Public Function LevelThreshold(ByVal SourceImage As Image,
                                   ByVal LevelCount_Red As Integer,
                                   ByVal LevelCount_Green As Integer,
                                   ByVal LevelCount_Blue As Integer,
                                    Optional ByVal MaskImage As Image = Nothing,
                                    Optional ByVal MaskRegionBoundary As Rectangle = Nothing,
                                    Optional ByVal IsMaskAllRegionSelected As Boolean = True) As Bitmap

        Dim LUT_Digitization(3, 255) As Byte

        If SourceImage Is Nothing Then Return CType(SourceImage.Clone, Bitmap)

        Call ImageTo_SrcPixels(SourceImage, MaskImage)



        If LevelCount_Red < 1 Then LevelCount_Red = 1
        If LevelCount_Red > 255 Then LevelCount_Red = 255
        If LevelCount_Green < 1 Then LevelCount_Green = 1
        If LevelCount_Green > 255 Then LevelCount_Green = 255
        If LevelCount_Blue < 1 Then LevelCount_Blue = 1
        If LevelCount_Blue > 255 Then LevelCount_Blue = 255


        For i As Integer = 0 To 255
            LUT_Digitization(1, i) = Digitalize(i, LevelCount_Red)
            LUT_Digitization(2, i) = Digitalize(i, LevelCount_Green)
            LUT_Digitization(3, i) = Digitalize(i, LevelCount_Blue)
            Debug.Print(i.ToString + "," + LUT_Digitization(1, i).ToString)
        Next



        Dim BitmapHeightUpper, BitmapWidthUpper As Integer
        BitmapHeightUpper = _SrcBitmapHeight - 1
        BitmapWidthUpper = _SrcBitmapWidth - 1



        If IsMaskAllRegionSelected Then

            For y As Integer = 0 To BitmapHeightUpper
                For x As Integer = 0 To BitmapWidthUpper
                    With _PixelIndex(x, y)
                        _OutPixels(.Blue + AtRed) = LUT_Digitization(1, _SrcPixels(.Blue + AtRed))
                        _OutPixels(.Blue + AtGreen) = LUT_Digitization(2, _SrcPixels(.Blue + AtGreen))
                        _OutPixels(.Blue) = LUT_Digitization(3, _SrcPixels(.Blue))
                    End With
                Next x

                RaiseEvent Processing(CSng(y / _SrcBitmapHeight * 100))
            Next y

        Else

            With MaskRegionBoundary
                x1 = .X
                y1 = .Y
                x2 = .X + .Width - 1
                y2 = .Y + .Height - 1
            End With

            For y As Integer = y1 To y2
                For x As Integer = x1 To x2

                    With _PixelIndex(x, y)
                        If _MaskPixels(.Blue) = 0 Then
                            _OutPixels(.Blue + AtRed) = LUT_Digitization(1, _SrcPixels(.Blue + AtRed))
                            _OutPixels(.Blue + AtGreen) = LUT_Digitization(2, _SrcPixels(.Blue + AtGreen))
                            _OutPixels(.Blue) = LUT_Digitization(3, _SrcPixels(.Blue))
                        End If
                    End With

                Next x

                RaiseEvent Processing(CSng((y - MaskRegionBoundary.Top) / MaskRegionBoundary.Height * 100))

            Next y

        End If


        Return OutPixelsToImage()
    End Function


    Public Function Digitalize(ByVal ColorChannelValue As Single,
                               ByVal LevelCount As Integer) As Byte

        Dim Inv_TotalLevelStep, TotalColorStep, CalculatedValue As Single

        If LevelCount < 2 Then Return 0

        Inv_TotalLevelStep = CSng(LevelCount / 256)
        TotalColorStep = CSng((LevelCount - 1) / 256)
        CalculatedValue = (Int(ColorChannelValue * Inv_TotalLevelStep)) /
                                 TotalColorStep
        If CalculatedValue > 255 Then
            CalculatedValue = 255
        End If

        Return CByte(CalculatedValue)
    End Function

End Class



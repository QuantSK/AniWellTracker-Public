Imports System.ComponentModel

Public Class Frm_RegionExtract

    Private ReadOnly DrawingFont As New Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Pixel)


    Structure Type_LabelIDInfo
        Dim Area As Long
        Dim CenterX As Integer
        Dim CenterY As Integer
        Dim X1 As Integer
        Dim Y1 As Integer
        Dim X2 As Integer
        Dim Y2 As Integer
        Dim Width As Integer
        Dim Height As Integer

        'Dim CenterX_Relative As Integer
        'Dim CenterY_Relative As Integer
        'Dim Distance_From_ROICenter As Integer
        'Dim Angle As Integer
    End Structure
    Dim FoundRegionColorTable(,) As Byte = Nothing
    '           1st: LabelID number,  2nd: R (,0)  G (,1)   B (,2)
    Dim LabelIDMap(,) As Integer = Nothing
    Dim LabelID_Count As Integer
    Dim LabelID_Info() As Type_LabelIDInfo
    Dim LabelIDMap_Screened(,) As Integer

    Dim FoundIDarray As New List(Of Integer)


    Dim IsFormLoading As Boolean = True


    Public _SourceImage As Image


    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True

        Frm_Canvas.Canvas.Image = _SourceImage
        Me.Hide()
    End Sub


    Private Sub Frm_RegionExtract_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Combo_Color_Preset.SelectedIndex = 0


        Combo_SortBy.SelectedIndex = 0
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        '   Me.MdiParent = JIT.MDImain
        '  JIT.MDImain.Show()
    End Sub


    Public Sub Do_RegionExtraction()

        Dim Temp_MaskImage As Image
        Dim Temp_MaskRegionBoundary As Rectangle
        Dim Temp_IsMaskAllRegionSelected As Boolean = False

        Dim MaskRects(ROI.GetUpperBound(0)) As Rectangle
        Dim ROI_Shape(ROI.GetUpperBound(0)) As String
        For q As Integer = 0 To ROI.GetUpperBound(0)
            MaskRects(q) = ROI(q).Boundary
            ROI_Shape(q) = ROI(q).Shape
        Next


        Temp_MaskImage = myImgProcessing.Create_MaskImage(_SourceImage.Width,
                                                            _SourceImage.Height,
                                                            MaskRects,
                                                            ROI_Shape)


        Image_RegionExtracted =
               myImgProcessing.RegionExtract_RasterScanning(
                               _SourceImage,
                               LabelIDMap,
                               FoundRegionColorTable,
                               ,
                               Temp_MaskImage,
                               Temp_MaskRegionBoundary,
                               Temp_IsMaskAllRegionSelected)


        Frm_Canvas.Canvas.Image = CType(Image_RegionExtracted.Clone, Image)
        Image_RegionExtracted = CType(Image_RegionExtracted.Clone, Bitmap)
        Temp_MaskImage.Dispose()

        Call Do_AnalyzeRegions()
        Call Do_DrawLabeledImage()

        Call Check_Preview_CheckedChanged(Nothing, Nothing)
    End Sub

    Public Sub Do_AnalyzeRegions()
        Dim x, y, q As Integer
        LabelID_Count = CShort(FoundRegionColorTable.GetUpperBound(0))
        ReDim LabelID_Info(LabelID_Count)


        Dim ImgWidth, ImgHeight As Integer

        ImgWidth = _SourceImage.Width - 1
        ImgHeight = _SourceImage.Height - 1



        For q = 1 To LabelID_Count
            With LabelID_Info(q)
                .X1 = 100000000
                .Y1 = 100000000
                .X2 = 0
                .Y2 = 0
            End With
        Next



        For y = 0 To CShort(ImgHeight)
            For x = 0 To CShort(ImgWidth)
                With LabelID_Info(LabelIDMap(x, y))
                    .Area += 1
                    .CenterX += x
                    .CenterY += y
                    .X1 = Math.Min(.X1, x)
                    .Y1 = Math.Min(.Y1, y)
                    .X2 = Math.Max(.X2, x)
                    .Y2 = Math.Max(.Y2, y)
                End With
            Next
        Next


        'Calculating average value
        For q = 1 To LabelID_Count
            With LabelID_Info(q)
                If .Area > 0 Then
                    .CenterX = CInt(.CenterX / .Area)

                    .CenterY = CInt(.CenterY / .Area)
                    .Width = .X2 - .X1 + 1
                    .Height = .Y2 - .Y1 + 1
                End If
            End With
        Next


    End Sub



    Private Function IsOKScreeningCondition(AreaMin As Long,
                                            AreaMax As Long,
                                            WidthHeightMin As Integer,
                                            WidthHeightMax As Integer,
                                            AreaValue As Long,
                                            WidthHeightValue As Integer) As Boolean

        If AreaValue >= AreaMin AndAlso AreaValue <= AreaMax AndAlso
           WidthHeightValue >= WidthHeightMin AndAlso WidthHeightValue <= WidthHeightMax Then
            Return True
        Else
            Return False
        End If


    End Function


    Private Sub Do_DrawLabeledImage()

        Dim LabelIDSelected As New Dictionary(Of Integer, Boolean)
        Dim CenterPointSize As Double
        Dim q, w As Integer
        Dim InnerColor As Color
        Dim OuterColor As Color
        Dim ObjectEllipseSize As Integer = 20

        Dim ObjectCount As Integer = 0

        Dim AreaMin, AreaMax, WidthHeightMin, WidthHeightMax, ObjectMax As Integer

        If Check_UseScreenCondition.Checked Then
            Try
                AreaMin = CInt(Val(Text_AreaMin.Text))
            Catch
                AreaMin = 1
                Text_AreaMin.Text = AreaMin.ToString.Trim
            End Try
            Try
                AreaMax = CInt(Val(Text_AreaMax.Text))
            Catch
                AreaMax = 100000
                Text_AreaMax.Text = AreaMax.ToString.Trim
            End Try
            Try
                WidthHeightMin = CInt(Val(Text_WidthHeightMin.Text))
            Catch
                WidthHeightMin = 1
                Text_WidthHeightMin.Text = WidthHeightMin.ToString.Trim
            End Try
            Try
                WidthHeightMax = CInt(Val(Text_WidthHeightMax.Text))
            Catch
                WidthHeightMax = 100000
                Text_WidthHeightMax.Text = WidthHeightMax.ToString.Trim
            End Try
            Try
                ObjectMax = CInt(Val(Text_ObjectMax.Text))
            Catch
                ObjectMax = 3
                Text_ObjectMax.Text = ObjectMax.ToString.Trim
            End Try
        End If

        FoundIDarray.Clear()

        For q = 1 To LabelID_Count
            If (Check_UseScreenCondition.Checked = False AndAlso LabelID_Info(q).Area >= 1) OrElse
               (Check_UseScreenCondition.Checked = True AndAlso
                   IsOKScreeningCondition(AreaMin, AreaMax, WidthHeightMin, WidthHeightMax,
                                           LabelID_Info(q).Area,
                                           LabelID_Info(q).Width)) Then
                FoundIDarray.Add(q)
            End If
        Next

        If Check_UseScreenCondition.Checked AndAlso
           Check_LimitMaxObjects.Checked AndAlso FoundIDarray.Count > 0 Then
            FoundIDarray = RemoveExcessObjects(FoundIDarray, CInt(Text_ObjectMax.Text))
        End If


        With Grid_Statistics
            .SuspendLayout()
            .Rows.Clear()

            For w = 0 To FoundIDarray.Count - 1
                .Rows.Add()
                q = FoundIDarray(w)
                Grid_Statistics(0, w).Value = q
                Grid_Statistics(1, w).Value = LabelID_Info(q).Area
                Grid_Statistics(2, w).Value = LabelID_Info(q).CenterX
                Grid_Statistics(3, w).Value = LabelID_Info(q).CenterY
                Grid_Statistics(4, w).Value = LabelID_Info(q).Width
                Grid_Statistics(5, w).Value = LabelID_Info(q).Height
                Grid_Statistics(6, w).Value =
                                        myImgProcessing.RGBToHex(FoundRegionColorTable(q, 0),
                                                        FoundRegionColorTable(q, 1),
                                                            FoundRegionColorTable(q, 2))
                Grid_Statistics(7, w).Value = LabelID_Info(q).X1
                Grid_Statistics(8, w).Value = LabelID_Info(q).Y1
                Grid_Statistics(9, w).Value = LabelID_Info(q).X2
                Grid_Statistics(10, w).Value = LabelID_Info(q).Y2
                Grid_Statistics(0, w).Tag = q
            Next
        End With

        Grid_Statistics.ResumeLayout()




        For w = 1 To Grid_Statistics.Rows.Count
            LabelIDSelected.Add(CInt(Grid_Statistics(0, w - 1).Tag), True)
        Next



        Using DrawingTextBrush As New SolidBrush(Color.White)
            LabelIDMap_Screened =
                            myImgProcessing.RegionExtract_Update_LabelIDMap_ByIncluding(
                                                 LabelIDMap, LabelIDSelected)

            Image_RegionLabeled =
                        myImgProcessing.RegionExtract_Update_LabelIDMap_To_Image(
                                    Image_RegionExtracted,
                                    LabelIDMap_Screened,
                                    FoundRegionColorTable,
                                    False)
            Image_RegionLabeled.Tag = Image_RegionExtracted.Tag

            'Labeling...
            GraphBox = Graphics.FromImage(Image_RegionLabeled)
            Try
                CenterPointSize = CInt(Text_CenterPointSize.Text)
            Catch
                CenterPointSize = 3
            End Try
            If Check_CenterPoint.Checked Then
                GraphBox.Clear(Color.Black)
            End If


            For w = 1 To Grid_Statistics.Rows.Count
                q = CInt(Grid_Statistics(0, w - 1).Tag)

                'Draw string as outlined text
                If Check_Labeling.Checked Then
                    OuterColor = Color.White
                    InnerColor = Color.FromArgb(255,
                                        FoundRegionColorTable(q, 0),
                                        FoundRegionColorTable(q, 1),
                                        FoundRegionColorTable(q, 2))

                    myImgProcessing.Draw_Text_Outlined_Graphics(GraphBox,
                                                 LabelID_Info(q).CenterX, LabelID_Info(q).CenterY,
                                                 w.ToString, DrawingFont, InnerColor, OuterColor)
                End If


                If Check_CenterPoint.Checked Then
                    GraphBox.FillEllipse(Brushes.White,
                                        New Rectangle(
                                        CInt(LabelID_Info(q).CenterX - Math.Round(CenterPointSize / 2)),
                                        CInt(LabelID_Info(q).CenterY - Math.Round(CenterPointSize / 2)),
                                        CInt(CenterPointSize),
                                        CInt(CenterPointSize)))
                End If


                GraphBox.DrawEllipse(Pens.Red,
                                     New Rectangle(
                                     CInt(LabelID_Info(q).CenterX - Math.Round(ObjectEllipseSize / 2)),
                                        CInt(LabelID_Info(q).CenterY - Math.Round(ObjectEllipseSize / 2)),
                                        CInt(ObjectEllipseSize),
                                        CInt(ObjectEllipseSize)))
            Next

        End Using

        Text_NumbOfRegion.Text = Grid_Statistics.Rows.Count.ToString
    End Sub



    Public Function Convert_ObjectLocationInfo_To_String(outIDarray() As List(Of Integer),
                                                    delimitChar As String,
                                                    maxObject As Integer,
                                                    InfoType As String) As String
        Dim TempStr As String = ""
        Dim q As Integer

        For curRegion As Integer = 0 To ROI.Length - 1
            For q = 0 To maxObject - 1
                If q > outIDarray(curRegion).Count - 1 Then
                    TempStr += "" + delimitChar + "" + delimitChar
                Else
                    Select Case InfoType.ToLower
                        Case "AbsolteCenter".ToLower
                            TempStr += LabelID_Info(CInt(outIDarray(curRegion).Item(q))).CenterX.ToString + delimitChar +
                                       LabelID_Info(CInt(outIDarray(curRegion).Item(q))).CenterY.ToString + delimitChar

                        Case "RelativeCenter".ToLower
                            'TempStr += LabelID_Info(CInt(outIDarray(curRegion).Item(q))).CenterX_Relative.ToString + delimitChar +
                           ' LabelID_Info(CInt(outIDarray(curRegion).Item(q))).CenterY_Relative.ToString + delimitChar
                        Case "RadiusDistance".ToLower
                            'TempStr += LabelID_Info(CInt(outIDarray(curRegion).Item(q))).Distance_From_ROICenter.ToString + delimitChar
                        Case "RadiusAngle".ToLower
                            'TempStr += LabelID_Info(CInt(outIDarray(curRegion).Item(q))).Angle.ToString + delimitChar
                        Case Else

                    End Select
                End If
            Next
        Next
        If TempStr <> "" Then
            TempStr = Strings.Left(TempStr, TempStr.Length - 1)
        End If
        Return TempStr
    End Function

    Public Function Get_ObjectInfoAsString(delimitChar As String,
                                         maxObject As Integer,
                                         InfoType As String) As String

        Dim bufStr As String =
                    Convert_ObjectLocationInfo_To_String(
                           Get_ObjectIDArray_From_ListArray(FoundIDarray),
                                    delimitChar, maxObject, InfoType)

        Return bufStr
    End Function

    Public Function Get_ObjectIDArray_From_ListArray(qIDarray As List(Of Integer)) As List(Of Integer)()

        Dim outIDarray(ROI.Length - 1) As List(Of Integer)
        Dim w, q As Integer
        Dim curRegion As Integer

        For curRegion = 0 To ROI.Length - 1
            outIDarray(curRegion) = New List(Of Integer)
        Next

        For w = 0 To qIDarray.Count - 1
            q = qIDarray.Item(w)

            For curRegion = 0 To ROI.Length - 1
                If ROI(curRegion).Boundary.Contains(
                            New Point(LabelID_Info(q).CenterX, LabelID_Info(q).CenterY)) Then

                    outIDarray(curRegion).Add(q)
                    Exit For
                End If
            Next
        Next

        Return outIDarray
    End Function





    Public Function RemoveExcessObjects(qIDarray As List(Of Integer), ObjectsPerCell As Integer) As List(Of Integer)
        Dim sorted(ROI.Length - 1) As List(Of Tuple(Of Integer, Long))
        Dim sortedScreened(ROI.Length - 1) As List(Of Integer)
        Dim NewqIDarray As New List(Of Integer)
        Dim w, q As Integer
        Dim curRegion As Integer


        For curRegion = 0 To ROI.Length - 1
            sorted(curRegion) = New List(Of Tuple(Of Integer, Long))
            sortedScreened(curRegion) = New List(Of Integer)
        Next


        For w = 0 To qIDarray.Count - 1
            q = qIDarray.Item(w)

            For curRegion = 0 To ROI.Length - 1
                If ROI(curRegion).Boundary.Contains(
                            New Point(LabelID_Info(q).CenterX, LabelID_Info(q).CenterY)) Then

                    sorted(curRegion).Add(Tuple.Create(q, LabelID_Info(q).Area))
                    Exit For
                End If
            Next
        Next


        For curRegion = 0 To ROI.Length - 1

            sorted(curRegion) = sorted(curRegion).OrderBy(Function(i) i.Item2).ToList
            For Each tpl As Tuple(Of Integer, Long) In sorted(curRegion)
                sortedScreened(curRegion).Insert(0, tpl.Item1)
            Next



            For w = 0 To Math.Min(ObjectsPerCell - 1, sortedScreened(curRegion).Count - 1)
                NewqIDarray.Add(sortedScreened(curRegion).Item(w))
            Next
        Next


        Return NewqIDarray
    End Function

    Private Sub Frm_RegionExtract_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        If IsFormLoading Then Exit Sub


        If Me.Visible Then
            If Image_Binarized Is Nothing Then
                Frm_Tracker.Conduct_Binarization()
            End If


            _SourceImage = CType(Image_Binarized.Clone, Image)
            _SourceImage.Tag = CType(Frm_Canvas.Canvas.Image.Tag, String)


            Call Do_RegionExtraction()

            Frm_Canvas.DrawRegions()
            Frm_Canvas.Canvas.Cursor = Cursors.Cross
            Check_Preview.Checked = True

            Me.WindowState = FormWindowState.Normal


        Else

            'CreateShowOutlinedOriginal()
            CreateShowCircledOriginal()

            If GraphBox IsNot Nothing Then
                GraphBox.Dispose()
                GraphBox = Nothing
            End If
            _SourceImage = Nothing

            Frm_Canvas.Canvas.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub CreateShowOutlinedOriginal()
        Image_OverlayOnOriginal =
                  myImgProcessing.RegionExtract_Create_OutlinedOriginalImage(
                                  Image_Original,
                                  LabelIDMap_Screened)
        Frm_Canvas.Canvas.Image = CType(Image_OverlayOnOriginal.Clone, Image)
    End Sub


    Public Sub CreateShowCircledOriginal()
        Dim ObjectEllipseSize As Integer = 20
        Dim q, w As Integer

        Image_OverlayOnOriginal = CType(Image_Original.Clone, Bitmap)
        GraphBox = Graphics.FromImage(Image_OverlayOnOriginal)

        For w = 1 To Grid_Statistics.Rows.Count
            q = CInt(Grid_Statistics(0, w - 1).Tag)
            GraphBox.DrawEllipse(Pens.Yellow,
                                     New Rectangle(
                                     CInt(LabelID_Info(q).CenterX - Math.Round(ObjectEllipseSize / 2)),
                                        CInt(LabelID_Info(q).CenterY - Math.Round(ObjectEllipseSize / 2)),
                                        CInt(ObjectEllipseSize),
                                        CInt(ObjectEllipseSize)))
            GraphBox.DrawEllipse(Pens.Blue,
                                     New Rectangle(
                                     CInt(LabelID_Info(q).CenterX - Math.Round(ObjectEllipseSize / 2) - 1),
                                        CInt(LabelID_Info(q).CenterY - Math.Round(ObjectEllipseSize / 2) - 1),
                                        CInt(ObjectEllipseSize) + 2,
                                        CInt(ObjectEllipseSize) + 2))
        Next

        Frm_Canvas.Canvas.Image = CType(Image_OverlayOnOriginal.Clone, Image)
    End Sub




    Private Sub Cmd_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cmd_Cancel.Click
        Frm_Canvas.Canvas.Image = Image_Binarized
        Frm_Canvas.DrawRegions()
        Me.Hide()
    End Sub

    Private Sub Cmd_OK_Click(sender As System.Object, e As System.EventArgs) Handles Cmd_OK.Click
        Cmd_Analyze_Click(Nothing, Nothing)
        Me.Hide()
    End Sub

    Private Sub Check_Labeling_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Check_Labeling.CheckedChanged
        If IsFormLoading Then Exit Sub

        Dim ee As System.EventArgs = Nothing
        Call Do_DrawLabeledImage()
        Frm_Canvas.DrawRegions()
        Call Check_Preview_CheckedChanged("", ee)
    End Sub

    Private Sub Check_Preview_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Check_Preview.CheckedChanged
        If IsFormLoading Then Exit Sub


        If Check_Preview.Checked Then
            Frm_Canvas.Canvas.Image = Image_RegionLabeled
        Else
            Frm_Canvas.Canvas.Image = _SourceImage
        End If

        Frm_Canvas.DrawRegions()
    End Sub

    Private Sub Cmd_Analyze_Click(sender As System.Object, e As System.EventArgs) Handles Cmd_Analyze.Click
        Call Do_DrawLabeledImage()

        Dim ee As System.EventArgs = Nothing
        Call Check_Preview_CheckedChanged("", ee)
    End Sub

    Public Sub Analyze()
        Dim ee As System.EventArgs = Nothing

        Call Cmd_Analyze_Click("", ee)
    End Sub

    Private Sub Cmd_Copy_Click(sender As System.Object, e As System.EventArgs) Handles Cmd_Copy.Click

        Dim TempStr As New Text.StringBuilder
        Dim q, w, RowCount, ColCount As Integer



        RowCount = Grid_Statistics.Rows.Count - 1
        ColCount = Grid_Statistics.ColumnCount - 2
        For q = 0 To RowCount
            For w = 0 To ColCount
                TempStr.Append(CType(Grid_Statistics(w, q).Value, String) + vbTab)
            Next
            TempStr.Append(CType(Grid_Statistics(ColCount + 1, q).Value, String) + vbCrLf)
        Next


        If TempStr.Length = 0 Then
            MsgBox("No data available", MsgBoxStyle.OkOnly, "Copy")
        Else
            Try
                Clipboard.SetText(TempStr.ToString)
                MsgBox("Tabulated data was transferred to clipboard",
                       MsgBoxStyle.OkOnly, "Copy")
            Catch
                MsgBox("Clipboard is not available at this moment",
                    MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub Check_CenterPoint_CheckedChanged(sender As Object, e As EventArgs) Handles Check_CenterPoint.CheckedChanged
        If IsFormLoading Then Exit Sub


        Text_CenterPointSize.Visible = Check_CenterPoint.Checked
        Label_CenterPointSize.Visible = Check_CenterPoint.Checked


        Dim ee As System.EventArgs = Nothing
        Call Do_DrawLabeledImage()
        Frm_Canvas.DrawRegions()
        Call Check_Preview_CheckedChanged("", ee)
    End Sub

    Public Function Get_TotRegion() As Integer
        _SourceImage = Frm_Canvas.Canvas.Image

        If _SourceImage Is Nothing Then Return 0

        Check_Labeling.Checked = False

        Call Do_RegionExtraction()

        Return CInt(Text_NumbOfRegion.Text)
    End Function



    Private Sub Check_UseScreenCondition_CheckedChanged(sender As Object, e As EventArgs) Handles Check_UseScreenCondition.CheckedChanged
        Group_UseScreeningCondition.Enabled = Check_UseScreenCondition.Checked
    End Sub


    Private Sub Check_LimitMaxObjects_CheckedChanged(sender As Object, e As EventArgs) Handles Check_LimitMaxObjects.CheckedChanged
        Text_ObjectMax.Visible = Check_LimitMaxObjects.Checked
        Label_SortBy.Visible = Check_LimitMaxObjects.Checked
        Combo_SortBy.Visible = Check_LimitMaxObjects.Checked
    End Sub

    Public Sub Find_ColorCodeInTable(ByVal ColorStr As String)
        Dim GridRowCount As Integer

        GridRowCount = Grid_Statistics.RowCount

        If GridRowCount >= 2 Then
            Dim q As Integer

            For q = 0 To GridRowCount - 1
                If Grid_Statistics(6, q).Value.ToString = ColorStr Then
                    Grid_Statistics.CurrentCell = Grid_Statistics(0, q)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub Frm_RegionExtract_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown

    End Sub

    Private Sub Frm_RegionExtract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        IsFormLoading = False
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Frm_RegionExtract_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating

    End Sub
End Class
Public Class Frm_Reviewer

    Dim IsStopProcessing As Boolean = False
    Dim myGraphLib As New GraphLib
    Dim _myColor As New Color
    Dim _ShadowBrush As New SolidBrush(_myColor)


    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        Me.MdiParent = MDIMain
        MDIMain.Show()

    End Sub

    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()
    End Sub


    Private Sub Frm_ReviewMode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo_ImageOrTime.SelectedIndex = 0

        myGraphLib.Load_ColorGradient_File(My.Application.Info.DirectoryPath _
                                        & PathDelimit & "Essential color gradient.vgc")

        Combo_ColorSpectrum_Loc.SelectedIndex = 2
        Combo_ColorSpectrum_Dis.SelectedIndex = 5
        Combo_FilterSize.SelectedIndex = 2
    End Sub

    Private Sub Group_Source_Enter(sender As Object, e As EventArgs) Handles Group_Source.Enter

    End Sub

    Private Sub Cmd_CustomFolder_Set_Click(sender As Object, e As EventArgs) Handles Cmd_CustomFolder_Set.Click

        If myFileSys.FolderExists(Text_SourceFolder.Text) Then
            FolderDialog_SourceImage.SelectedPath = Text_SourceFolder.Text
        End If

        If FolderDialog_SourceImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            Text_SourceFolder.Text =
                        FolderDialog_SourceImage.SelectedPath

            Frm_FileManager.Cmd_Rescan_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_ReviewMode_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            Frm_Tracker.Hide()

            Load_OutputFiles()
        End If
    End Sub





    Public Sub SelectFileName(ByVal FileName As String, ByVal SelectedIndex As Integer)

        If Me.Visible = False Then Exit Sub

        CreateOverlayOnOriginal(SelectedIndex,
                                FileName,
                                Check_ObjectLocation.Checked,
                                Check_AngleLine.Checked,
                                Check_Track.Checked,
                                Check_Track_Location.Checked)

        Frm_Canvas.DrawRegions()
    End Sub


    'Return "" if no error
    Public Function Load_OutputFiles_Core() As String
        Dim SourceFolder As String = Text_SourceFolder.Text
        Dim OutStr As String = ""


        Array_AbsoluteLocation =
                    myTextLib.Get_String2DAarry_From_TextFile(
                                SourceFolder & PathDelimit & Filename_AbsoluteLocation,
                                ",", False)
        If Array_AbsoluteLocation Is Nothing Then
            OutStr = OutStr + Filename_AbsoluteLocation + vbCrLf
        End If



        If OutStr = "" Then
            Return ""
        Else
            Return "Could not open the following files" + vbCrLf + vbCrLf +
                    OutStr
        End If
    End Function




    Public Sub CreateOverlayOnOriginal(FileID As Integer,
                                       Filename As String,
                                       IsShowObjetCircle As Boolean,
                                       IsShowAngularLine As Boolean,
                                       IsShowTrack As Boolean,
                                       IsShowTrakLocation As Boolean)


        Dim ObjectEllipseSize As Integer = 20
        Dim TrackEllipseSize As Integer = 3
        Dim w, q As Integer
        Dim SourceFolder As String = Text_SourceFolder.Text


        If (Array_AbsoluteLocation Is Nothing) Then
            Frm_Canvas.Canvas.Image =
                    MyImgProcessing.Image_FromFile(SourceFolder + PathDelimit + Filename)
            Frm_Canvas.Text = "Canvas - Original image of " & Filename
            Exit Sub
        End If

        If ROI Is Nothing Then Exit Sub


        If FileID + 2 > Array_AbsoluteLocation.GetUpperBound(1) Then
            Frm_Canvas.Canvas.Image =
                    MyImgProcessing.Image_FromFile(SourceFolder + PathDelimit + Filename)
            Frm_Canvas.Text = "Canvas - Original image of " & Filename
            Exit Sub
        End If


        If Filename <> Array_AbsoluteLocation(1, FileID + 2) Then
            Frm_Canvas.Canvas.Image =
                   MyImgProcessing.Image_FromFile(SourceFolder + PathDelimit + Filename)
            Frm_Canvas.Text = "Canvas - Original image of " & Filename
            MsgBox("Incompatible image file name found" + vbCrLf +
                    "Output file vs File manager", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If




        Image_OverlayOnOriginal =
            CType(MyImgProcessing.Image_FromFile(
                            SourceFolder + PathDelimit + Filename).Clone, Bitmap)

        GraphBox = Graphics.FromImage(Image_OverlayOnOriginal)

        Dim CenterX, CenterY, ROI_CenterX, ROI_CenterY As Integer
        Dim BeginFileID As Integer
        Dim TrackLength As Integer = CInt(Text_TrackLength.Text)
        Dim x1, y1, x2, y2 As Integer

        For w = 0 To ROI.Length - 1
            If Array_AbsoluteLocation(5 + w * 2, FileID + 2) = "" Then
                Continue For
            End If


            CenterX = CInt(Array_AbsoluteLocation(5 + w * 2, FileID + 2))
            CenterY = CInt(Array_AbsoluteLocation(5 + w * 2 + 1, FileID + 2))
            ROI_CenterX = CInt(ROI(w).Boundary.Left + ROI(w).Boundary.Width / 2)
            ROI_CenterY = CInt(ROI(w).Boundary.Top + ROI(w).Boundary.Height / 2)

            If IsShowObjetCircle Then
                GraphBox.DrawEllipse(Pens.Yellow,
                                     New Rectangle(
                                     CInt(CenterX - Math.Round(ObjectEllipseSize / 2)),
                                        CInt(CenterY - Math.Round(ObjectEllipseSize / 2)),
                                        CInt(ObjectEllipseSize),
                                        CInt(ObjectEllipseSize)))
                GraphBox.DrawEllipse(Pens.Blue,
                                         New Rectangle(
                                         CInt(CenterX - Math.Round(ObjectEllipseSize / 2) - 1),
                                            CInt(CenterY - Math.Round(ObjectEllipseSize / 2) - 1),
                                            CInt(ObjectEllipseSize) + 2,
                                            CInt(ObjectEllipseSize) + 2))
            End If

            If IsShowAngularLine Then
                GraphBox.DrawLine(Pens.White,
                                     New Point(ROI_CenterX, ROI_CenterY),
                                     New Point(CenterX, CenterY))


            End If



            If IsShowTrack Then
                BeginFileID = Math.Max(2, FileID + 2 - TrackLength)
                For q = BeginFileID To FileID + 2 - 1
                    If Array_AbsoluteLocation(5 + w * 2, q) = "" OrElse
                       Array_AbsoluteLocation(5 + w * 2, q + 1) = "" Then
                        Continue For
                    End If

                    x1 = CInt(Array_AbsoluteLocation(5 + w * 2, q))
                    y1 = CInt(Array_AbsoluteLocation(5 + w * 2 + 1, q))
                    x2 = CInt(Array_AbsoluteLocation(5 + w * 2, q + 1))
                    y2 = CInt(Array_AbsoluteLocation(5 + w * 2 + 1, q + 1))

                    If IsShowTrakLocation Then
                        GraphBox.DrawEllipse(Pens.Black,
                                         New Rectangle(
                                         CInt(x1 - Math.Round(TrackEllipseSize / 2) - 1),
                                            CInt(y1 - Math.Round(TrackEllipseSize / 2) - 1),
                                            CInt(TrackEllipseSize) + 2,
                                            CInt(TrackEllipseSize) + 2))
                    End If


                    GraphBox.DrawLine(Pens.Blue, x1, y1, x2, y2)

                Next
            End If


        Next

        Frm_Canvas.Canvas.Image = CType(Image_OverlayOnOriginal.Clone, Image)
        Frm_Canvas.Text = "Canvas - Original image of " & Filename
    End Sub






    'return "", if not errors
    Public Function Load_LocationHeatmapFile(FullFilename As String,
                                             Optional delimitStr As String = ",") As String

        If myFileSys.FileExists(FullFilename) = False Then
            Return "File not found: " + Filename_LocationHeatmap
        End If


        Dim NumStrArray(,) As String
        NumStrArray = myTextLib.Get_String2DAarry_From_TextFile(FullFilename, delimitStr, False)
        If NumStrArray Is Nothing Then
            Return "Could not open file: " + Filename_LocationHeatmap
        End If



        Dim ColMaxIndex As Integer = NumStrArray.GetUpperBound(0)
        Dim RowMaxIndex As Integer = NumStrArray.GetUpperBound(1)

        Dim x, y, y2 As Integer
        Dim CurWellID, SizeN As Integer
        ReDim Array_LocationHeatmap(ROI.GetUpperBound(0))
        y = 1
        SizeN = ColMaxIndex
        Do

            If NumStrArray(1, y) = "ROI ID" Then
                CurWellID = CInt(NumStrArray(2, y)) - 1
                ReDim Array_LocationHeatmap(CurWellID).LocationHeatmap(SizeN, SizeN)

                For y2 = y + 1 To y + SizeN
                    For x = 1 To SizeN
                        Array_LocationHeatmap(CurWellID).LocationHeatmap(x, y2 - y) =
                                                      CSng(NumStrArray(x, y2))
                    Next
                Next


                y = y + SizeN
            End If

            y += 1
        Loop While (y <= RowMaxIndex)

        Return ""
    End Function

    Public Sub Load_OutputFiles()
        If MyFileSys.FolderExists(Text_SourceFolder.Text) = False Then
            Exit Sub
        End If

        Dim RetMsg As String
        RetMsg = Load_OutputFiles_Core()
        If RetMsg = "" Then
            MsgBox("Output files have been Successfully loaded!", MsgBoxStyle.Exclamation, "Loading output")
        Else
            MsgBox(RetMsg, MsgBoxStyle.Critical, "Loading output")
        End If
    End Sub


    Private Sub Cmd_RePostProcessing_Click(sender As Object, e As EventArgs) Handles Cmd_RePostProcessing.Click

        Dim RetMsg As String
        RetMsg = Frm_Tracker.Do_PostProcessing(Text_SourceFolder.Text,
                                                CInt(Text_BlockDurationMin.Text))
        If RetMsg = "" Then
            MsgBox("Successfully done!", MsgBoxStyle.Exclamation, "Post Processing")
        Else
            MsgBox(RetMsg, MsgBoxStyle.Critical, "Post Processing")
        End If

        Load_OutputFiles()
    End Sub


    Private Sub Cmd_StartSaving_Click(sender As Object, e As EventArgs) Handles Cmd_StartSaving.Click
        Dim myStopWatch As New Stopwatch
        Dim CropMargin As Integer = CInt(Text_CropMargin.Text)

        If Cmd_StartSaving.Text = "Start saving" Then
            Cmd_StartSaving.Text = "Stop processing"
            IsStopProcessing = False
        Else
            IsStopProcessing = True
            Exit Sub
        End If



        Dim q As Integer
        Dim BeginIndex, EndIndex As Integer
        Dim SaveInterval As Integer
        Dim FileName As String
        Dim RenderFileFullName As String
        Dim RenderWellID As Integer

        BeginIndex = Math.Max(CInt(Text_FileFrom.Text) - 1, 0)
        EndIndex = Math.Min(CInt(Text_FileTo.Text) - 1, Frm_FileManager.FileListBox.ListView.Items.Count - 1)
        SaveInterval = CInt(Text_SaveInterval.Text)

        If MyFileSys.FolderExists(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered) Then
            MyFileSys.DeleteMultipleFiles(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered, "*.png")
        Else
            MyFileSys.MkDir(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered)
        End If


        For q = BeginIndex To EndIndex Step SaveInterval

            myStopWatch.Reset()
            myStopWatch.Start()

            FileName = Frm_FileManager.FileListBox.FileName(q)
            SelectFileName(FileName, q)
            RenderFileFullName = Text_SourceFolder.Text + PathDelimit +
                                             SubfolderName_Rendered + PathDelimit +
                                             FileName

            MDIMain.Status_Info2.Text = "Processing " + FileName + "  and  " &
                                (q - BeginIndex + 1).ToString.Trim & "-th image of " &
                                (EndIndex - BeginIndex + 1).ToString.Trim &
                                " images"
            MDIMain.StatusStrip_Status.Update()



            If Radio_EntireImage.Checked Then
                Frm_Canvas.Canvas.Image.Save(RenderFileFullName)
            Else
                RenderWellID = CInt(Combo_Well.Text) - 1
                MyImgProcessing.Crop(Frm_Canvas.Canvas.Image,
                                      ROI(RenderWellID).Boundary.Width + CropMargin + 2,
                                      ROI(RenderWellID).Boundary.Height + CropMargin + 2,
                                      CInt(ROI(RenderWellID).Boundary.Left - CropMargin / 2 - 1),
                                      CInt(ROI(RenderWellID).Boundary.Top - CropMargin / 2 - 1)).Save(RenderFileFullName)
            End If



            If IsStopProcessing Then
                MsgBox("Processing stopped by a user", MsgBoxStyle.Exclamation, "File saving")
                Cmd_StartSaving.Text = "Start saving"
                IsStopProcessing = False
                Exit For
            End If


            myStopWatch.Stop()
            MDIMain.Status_Info3.Text = "Processing time:  " +
                                myStopWatch.ElapsedMilliseconds.ToString + " ms"

            Application.DoEvents()



            'Processing the last image
            If q = EndIndex Then
                Exit For
            End If
            If q + SaveInterval > EndIndex Then
                q = EndIndex - SaveInterval
            End If
        Next



        Cmd_StartSaving.Text = "Start saving"
        IsStopProcessing = False

        MsgBox("Processing has been done!", MsgBoxStyle.Exclamation, "File saving")
    End Sub


    Private Sub Cmd_OpenLogFile_Click(sender As Object, e As EventArgs) Handles Cmd_OpenLogFile.Click
        Dim FolderStr As String =
                Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered

        If MyFileSys.FolderExists(FolderStr) Then
            MyFileSys.BrowseFolder(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered)
        Else
            MsgBox("The folder not created yet", MsgBoxStyle.OkOnly, "Open")
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Cmd_CreateLocationHeatmap_Click(sender As Object, e As EventArgs) Handles Cmd_CreateLocationHeatmap.Click

        If Val(Text_GridSizeN_Loc.Text) < 7 Then
            MsgBox("Grid size N should be larger than 6")
            Exit Sub
        End If

        Dim RetMsg As String
        RetMsg = Frm_Tracker.Process_LocationHeatmap(Text_SourceFolder.Text,, True)
        If RetMsg = "" Then
            MsgBox("Successfully done!", MsgBoxStyle.Exclamation, "Post Processing")
        Else
            MsgBox(RetMsg, MsgBoxStyle.Critical, "Post Processing")
        End If

        DrawLocationHeatmap_OnSourceImage()
    End Sub

    Private Sub Cmd_DrawHeatmap_Location_Click(sender As Object, e As EventArgs) Handles Cmd_DrawHeatmap_Location.Click
        DrawLocationHeatmap_OnSourceImage(",")
        Frm_Canvas.BringToFront()
    End Sub


    Public Sub DrawLocationHeatmap_OnSourceImageOrg(Optional delimitStr As String = ",")
        Dim RetMsg As String

        RetMsg = Load_LocationHeatmapFile(Text_SourceFolder.Text + PathDelimit + Filename_LocationHeatmap)

        If RetMsg <> "" Then
            MsgBox(RetMsg, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim ValueMin As Single = CSng(Text_ValueMin_Loc.Text)
        Dim ValueMax As Single = CSng(Text_ValueMax_Loc.Text)
        Dim SizeN As Integer = Array_LocationHeatmap(0).LocationHeatmap.GetUpperBound(0)
        Dim q, x, y As Integer

        If ValueMin = ValueMax Then
            MsgBox("Activity min and Activity max are identical!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If



        Image_OverlayOnOriginal = CType(Frm_Canvas.Canvas.Image.Clone, Bitmap)


        Using GraphBox As Graphics = Graphics.FromImage(Image_OverlayOnOriginal)

            Dim ColorIndex As Integer
            Dim ColorSpectrumIndex As Integer = Combo_ColorSpectrum_Loc.SelectedIndex + 1

            For q = 0 To ROI.GetUpperBound(0)



                For y = 1 To SizeN
                    For x = 1 To SizeN

                        ColorIndex = CInt((Array_LocationHeatmap(q).LocationHeatmap(x, y) - ValueMin) /
                                            (ValueMax - ValueMin) * 100)
                        ColorIndex = Math.Max(ColorIndex, 0)
                        ColorIndex = Math.Min(ColorIndex, 255)


                        With myGraphLib
                            Select Case ColorSpectrumIndex
                                Case 1, 2
                                    _ShadowBrush.Color = .Get_IndexedBrushColor(ColorSpectrumIndex, ColorIndex)
                                Case 3
                                    _ShadowBrush.Color = .Get_GradientBrushColor_BR(ColorIndex)
                                Case 4
                                    _ShadowBrush.Color = .Get_GradientBrushColor_BW(ColorIndex)
                                Case 5
                                    _ShadowBrush.Color = .Get_GradientBrushColor_BY(ColorIndex)
                                Case 6
                                    _ShadowBrush.Color = .Get_GradientBrushColor_Matlab(ColorIndex)
                                Case Else
                            End Select
                        End With

                        With ROI(q).Boundary
                            GraphBox.FillRectangle(_ShadowBrush, New Rectangle(
                                       CInt(.Left + (.Width / SizeN) * (x - 1)),
                                       CInt(.Top + (.Height / SizeN) * (y - 1)),
                                       CInt((.Width / SizeN)) + 1,
                                       CInt((.Height / SizeN)) + 1))
                        End With
                    Next

                Next
            Next

            Frm_Canvas.Canvas.Image = CType(Image_OverlayOnOriginal.Clone, Bitmap)
        End Using


        If Check_Contour.Checked Then
            With MyImgProcessing
                '.BoxAveraging_Parallel()
            End With
        End If




        If False Then
            '  Picture_Graph.Image.Save(
            '  myFileSys.Get_FullFilenameWithoutExtension_From_FullFileName(
            '  Text_Filename.Text) & "- Heatmap.png")
        End If


        Me.BringToFront()
    End Sub


    Public Sub DrawLocationHeatmap_OnSourceImage(Optional delimitStr As String = ",")
        Dim RetMsg As String

        RetMsg = Load_LocationHeatmapFile(Text_SourceFolder.Text + PathDelimit + Filename_LocationHeatmap)

        If RetMsg <> "" Then
            MsgBox(RetMsg, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim FilterSize As Integer = CInt(Combo_FilterSize.Text)
        Dim ValueMin As Single = CSng(Text_ValueMin_Loc.Text)
        Dim ValueMax As Single = CSng(Text_ValueMax_Loc.Text)
        Dim SizeN As Integer = Array_LocationHeatmap(0).LocationHeatmap.GetUpperBound(0)
        Dim q, x, y As Integer

        If ValueMin = ValueMax Then
            MsgBox("Activity min and Activity max are identical!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If



        Image_OverlayOnOriginal = CType(Frm_Canvas.Canvas.Image.Clone, Bitmap)


        Using GraphBox As Graphics = Graphics.FromImage(Image_OverlayOnOriginal)

            Dim ColorIndex As Integer
            Dim ColorSpectrumIndex As Integer = Combo_ColorSpectrum_Loc.SelectedIndex + 1

            For q = 0 To ROI.GetUpperBound(0)


                Using bm As New Bitmap(ROI(q).Boundary.Width + 1, ROI(q).Boundary.Height + 1),
                        GraphBox2 As Graphics = Graphics.FromImage(bm)

                    For y = 1 To SizeN
                        For x = 1 To SizeN

                            ColorIndex = CInt((Array_LocationHeatmap(q).LocationHeatmap(x, y) - ValueMin) /
                                                (ValueMax - ValueMin) * 100)
                            ColorIndex = Math.Max(ColorIndex, 0)
                            ColorIndex = Math.Min(ColorIndex, 255)


                            With myGraphLib
                                Select Case ColorSpectrumIndex
                                    Case 1, 2
                                        _ShadowBrush.Color = .Get_IndexedBrushColor(ColorSpectrumIndex, ColorIndex)
                                    Case 3
                                        _ShadowBrush.Color = .Get_GradientBrushColor_BR(ColorIndex)
                                    Case 4
                                        _ShadowBrush.Color = .Get_GradientBrushColor_BW(ColorIndex)
                                    Case 5
                                        _ShadowBrush.Color = .Get_GradientBrushColor_BY(ColorIndex)
                                    Case 6
                                        _ShadowBrush.Color = .Get_GradientBrushColor_Matlab(ColorIndex)
                                    Case Else
                                End Select
                            End With

                            With ROI(q).Boundary
                                GraphBox2.FillRectangle(_ShadowBrush, New Rectangle(
                                           CInt((.Width / SizeN) * (x - 1)),
                                           CInt((.Height / SizeN) * (y - 1)),
                                           CInt((.Width / SizeN)) + 1,
                                           CInt((.Height / SizeN)) + 1))
                            End With
                        Next

                    Next



                    If Check_Contour.Checked Then
                        With MyImgProcessing
                            GraphBox.DrawImage(.LevelThreshold(.BoxAveraging_ByIntegralMap(
                                        .BoxAveraging_ByIntegralMap(
                                                .BoxAveraging_ByIntegralMap(bm, FilterSize),
                                                FilterSize), FilterSize), 6, 6, 6),
                                           New Point(ROI(q).Boundary.Left, ROI(q).Boundary.Top))

                        End With
                    Else
                        GraphBox.DrawImage(bm,
                                           New Point(ROI(q).Boundary.Left, ROI(q).Boundary.Top))
                    End If

                End Using
            Next



            Frm_Canvas.Canvas.Image = CType(Image_OverlayOnOriginal.Clone, Bitmap)
        End Using







        If False Then
            '  Picture_Graph.Image.Save(
            '  myFileSys.Get_FullFilenameWithoutExtension_From_FullFileName(
            '  Text_Filename.Text) & "- Heatmap.png")
        End If


        Me.BringToFront()
    End Sub



    Sub UpdateGradientBar(ByRef TargetPictureBox As PictureBox,
                          ColorSpectrumIndex As Integer)
        Using bm As New Bitmap(50, 100),
                        GraphBox As Graphics = Graphics.FromImage(bm)

            For q As Integer = 1 To 100
                Select Case ColorSpectrumIndex
                    Case 1, 2
                        _ShadowBrush.Color = myGraphLib.Get_IndexedBrushColor(ColorSpectrumIndex, q)
                    Case 3
                        _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_BR(q)
                    Case 4
                        _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_BW(q)
                    Case 5
                        _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_BY(q)
                    Case 6
                        _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_Matlab(q)
                    Case Else
                End Select

                GraphBox.FillRectangle(_ShadowBrush, New Rectangle(New Point(0, q - 1), New Size(101, 1)))
            Next

            bm.RotateFlip(RotateFlipType.Rotate270FlipNone)
            TargetPictureBox.Image = CType(bm.Clone, Image)
        End Using
    End Sub

    Private Sub Combo_ColorSpectrum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_ColorSpectrum_Loc.SelectedIndexChanged
        UpdateGradientBar(Pic_Gradientbar_Loc, Combo_ColorSpectrum_Loc.SelectedIndex + 1)
    End Sub

    Private Sub Cmd_CopyWellA_Click(sender As Object, e As EventArgs) Handles Cmd_CopyWellA.Click
        Dim CropMargin As Integer = CInt(Text_CropMargin.Text)
        Dim RenderWellID As Integer

        RenderWellID = CInt(Combo_Well.Text) - 1

        Clipboard.SetImage(MyImgProcessing.Crop(Frm_Canvas.Canvas.Image,
                              ROI(RenderWellID).Boundary.Width + CropMargin + 2,
                              ROI(RenderWellID).Boundary.Height + CropMargin + 2,
                              CInt(ROI(RenderWellID).Boundary.Left - CropMargin / 2 - 1),
                              CInt(ROI(RenderWellID).Boundary.Top - CropMargin / 2 - 1)))

        MsgBox("Well image copy to clipboard")

    End Sub

    Private Sub Cmd_CopyWellB_Click(sender As Object, e As EventArgs) Handles Cmd_CopyWellB.Click
        Dim CropMargin As Integer = 0
        Dim RenderWellID As Integer

        RenderWellID = CInt(Combo_Well.Text) - 1

        Clipboard.SetImage(MyImgProcessing.Crop(Frm_Canvas.Canvas.Image,
                              ROI(RenderWellID).Boundary.Width + CropMargin,
                              ROI(RenderWellID).Boundary.Height + CropMargin,
                              CInt(ROI(RenderWellID).Boundary.Left - CropMargin / 2),
                              CInt(ROI(RenderWellID).Boundary.Top - CropMargin / 2)))

        MsgBox("Well image copy to clipboard")
    End Sub


    Private Sub Cmd_Speed_Click(sender As Object, e As EventArgs) Handles Cmd_TravelSpeed.Click
        ShowTimeSeriesGraph(Filename_TravelSpeed)
    End Sub

    Private Sub Cmd_EveryWell_Click(sender As Object, e As EventArgs) Handles Cmd_EveryWell.Click
        Dim CropMargin As Integer = CInt(Text_CropMargin.Text)
        Dim RenderFileFullName As String
        Dim q As Integer

        If MyFileSys.FolderExists(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered) Then
            MyFileSys.DeleteMultipleFiles(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered, "*.png")
        Else
            MyFileSys.MkDir(Text_SourceFolder.Text + PathDelimit + SubfolderName_Rendered)
        End If

        For q = 0 To ROI.GetUpperBound(0)
            RenderFileFullName = Text_SourceFolder.Text + PathDelimit +
                                             SubfolderName_Rendered + PathDelimit +
                                             "ROI_" + Format(q + 1, "000") + ".png"
            MyImgProcessing.Crop(Frm_Canvas.Canvas.Image,
                              ROI(q).Boundary.Width + CropMargin,
                              ROI(q).Boundary.Height + CropMargin,
                              CInt(ROI(q).Boundary.Left - CropMargin / 2),
                              CInt(ROI(q).Boundary.Top - CropMargin / 2)).Save(RenderFileFullName)
        Next

        MsgBox("File saving has been completed!", MsgBoxStyle.Exclamation, "File saving")
    End Sub


    Private Sub Cmd_TravelDistance_Click(sender As Object, e As EventArgs) Handles Cmd_TravelDistance.Click
        ShowTimeSeriesGraph(Filename_TravelDistance)
    End Sub



    Sub ShowTimeSeriesGraph(Filename As String)
        With Frm_TimeSeriesHeatmapViewer
            .Show()
            .Text_Filename.Text =
                        Text_SourceFolder.Text + PathDelimit + Filename
            .Cmd_Draw_Click(Nothing, Nothing)
            .BringToFront()
        End With
    End Sub

    Private Sub Cmd_TravelSpeed1M_Click(sender As Object, e As EventArgs) Handles Cmd_AverageTravelSpeed1M.Click
        ShowTimeSeriesGraph(Filename_TravelSpeed_TimeBlockMin.Replace("0", Text_BlockDurationMin.Text.Trim))
    End Sub

    Private Sub Cmd_TravelDistance1M_Click(sender As Object, e As EventArgs) Handles Cmd_TotalTravelDistance1M.Click
        ShowTimeSeriesGraph(Filename_TravelDistance_TimeBlockMin.Replace("0", Text_BlockDurationMin.Text.Trim))
    End Sub

    Private Sub Check_UpdateRawHeader_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cmd_CentralAngle_Click(sender As Object, e As EventArgs) Handles Cmd_CentralAngle.Click
        ShowTimeSeriesGraph(Filename_CentralAngle)
    End Sub

    Private Sub Cmd_DistanceFromCenter_Click(sender As Object, e As EventArgs) Handles Cmd_DistanceFromCenter.Click
        ShowTimeSeriesGraph(Filename_DistanceFromCenter)
    End Sub

    Private Sub Cmd_Rotation_Click(sender As Object, e As EventArgs) Handles Cmd_DeltaRotation.Click
        ShowTimeSeriesGraph(Filename_RotationAngle)
    End Sub

    Private Sub Combo_ColorSpectrum_Dis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_ColorSpectrum_Dis.SelectedIndexChanged
        UpdateGradientBar(Pic_Gradientbar_Dis, Combo_ColorSpectrum_Dis.SelectedIndex + 1)
    End Sub

    Private Sub Cmd_CreateDistanceFromCenterHeatmap_Click(sender As Object, e As EventArgs) Handles Cmd_CreateDistanceFromCenterHeatmap.Click
        Dim RetMsg As String
        RetMsg = Frm_Tracker.Process_DistanceFromCenterHeatmap(Text_SourceFolder.Text,, True)
        If RetMsg = "" Then
            MsgBox("Successfully done!", MsgBoxStyle.Exclamation, "Post Processing")
        Else
            MsgBox(RetMsg, MsgBoxStyle.Critical, "Post Processing")
        End If

        Cmd_DrawDistanceFromCenterHeatmap_Click(Nothing, Nothing)
    End Sub

    Private Sub Cmd_DrawDistanceFromCenterHeatmap_Click(sender As Object, e As EventArgs) Handles Cmd_DrawDistanceFromCenterHeatmap.Click
        With Frm_HeatMap_General
            .Show()
            .Text_Filename.Text =
                        Text_SourceFolder.Text + PathDelimit + Filename_DistanceFromCenterHeatmap
            .Combo_ColorSpectrum.SelectedIndex = Combo_ColorSpectrum_Dis.SelectedIndex
            .Cmd_Draw_Click(Nothing, Nothing)
        End With
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class
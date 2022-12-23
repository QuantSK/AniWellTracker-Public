Imports System.IO

Public Class Frm_Tracker
    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()
    End Sub


    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        Me.MdiParent = MDIMain
        MDIMain.Show()
    End Sub

    Private Sub Frm_ActivitySetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo_Binarization_PreblurringSize.SelectedIndex = 0
        Combo_Subtraction_PreblurringSize.SelectedIndex = 0
        Tab_Config.SelectedTab = Tab_Binarization
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

    Private Sub Cmd_SetBinarization_Click(sender As Object, e As EventArgs) Handles Cmd_SetBinarization.Click
        MDIMain.Enabled = False
        Frm_AdaptiveThresholding.Show()
    End Sub

    Public Sub Cmd_TestBinarization_Click(sender As Object, e As EventArgs) Handles Cmd_TestBinarization.Click
        Me.Enabled = False

        Dim myStopWatch As New Stopwatch
        myStopWatch.Reset()
        myStopWatch.Start()


        Conduct_Binarization()
        Frm_Canvas.DrawRegions()

        myStopWatch.Stop()
        MDIMain.Status_Info3.Text = "Processing time:  " +
                                myStopWatch.ElapsedMilliseconds.ToString + " ms"
        Me.Enabled = True
    End Sub


    Public Sub Do_AdaptiveThresholding(ProcessingBoxSize As Integer,
                                       IsObjectBlack As Boolean,
                                       ThresholdLevel As Integer)

        Dim IsCanvasAnimationEnabled As Boolean

        With Frm_Canvas
            IsCanvasAnimationEnabled = .Timer_Animation.Enabled
            .Timer_Animation.Enabled = False


            MDIMain.Status_Progressbar.Value = 0



            MDIMain.Status_Info.Text = "Blurring original image..."
            MDIMain.StatusStrip_Status.Update()

            If Check_Binarization_Preblurring.Checked Then
                If InStr(Combo_Binarization_PreblurringSize.Text, "Gaussian") = 0 Then
                    Image_Binarized = MyImgProcessing.BoxAveraging_ByIntegralMap(
                                        Image_Original,
                                        CInt(Strings.Left(Combo_Binarization_PreblurringSize.Text, 1)))
                Else
                    Image_Binarized = MyImgProcessing.GaussianFilter(
                                        Image_Original,
                                        CInt(Strings.Left(Combo_Binarization_PreblurringSize.Text, 1)))
                End If
            Else
                Image_Binarized = MyImgProcessing.DeepCopy(Image_Original)
            End If




            MDIMain.Status_Progressbar.Value = 40
            MDIMain.Status_Info.Text = "Applying adaptive thresholding..."
            MDIMain.StatusStrip_Status.Update()
            Image_Binarized = MyImgProcessing.BWLeveling_Using_AdaptiveThreshold(
                                              Image_Binarized, ProcessingBoxSize,
                                              Not (IsObjectBlack),
                                              ThresholdLevel)

            If IsObjectBlack Then
                Image_Binarized = MyImgProcessing.Invert(Image_Binarized)
            End If
            Image_Binarized = MyImgProcessing.RemoveSinglePixels(Image_Binarized, 255)


            MDIMain.Status_Progressbar.Value = 90
            .Canvas.Image = MyImgProcessing.DeepCopy(Image_Binarized)

            .Timer_Animation.Enabled = IsCanvasAnimationEnabled
        End With

        MDIMain.Status_Info.Text = "Processing completed!"
        MDIMain.Status_Progressbar.Value = 100
    End Sub

    Private Sub Cmd_TestRegionExtract_Click(sender As Object, e As EventArgs) Handles Cmd_TestRegionExtract.Click

        If ROI Is Nothing Then
            MsgBox(Filename_ROI + " is not found in the source folder" + vbCrLf +
                   "Please create the file first", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Me.Enabled = False

        Dim myStopWatch As New Stopwatch

        myStopWatch.Reset()
        myStopWatch.Start()

        If Image_Binarized Is Nothing Then
            Conduct_Binarization()
        End If
        Conduct_RegionExtraction()

        'Frm_RegionExtract.CreateShowOutlinedOriginal()
        Frm_RegionExtract.CreateShowCircledOriginal()

        Frm_Canvas.DrawRegions()


        myStopWatch.Stop()
        MDIMain.Status_Info3.Text = "Processing time:  " +
                                myStopWatch.ElapsedMilliseconds.ToString + " ms"
        Me.Enabled = True
    End Sub

    Public Sub Conduct_RegionExtraction()

        With Frm_RegionExtract
            ._SourceImage = CType(Image_Binarized.Clone, Image)
            .Do_RegionExtraction()
        End With
    End Sub



    Public Sub Conduct_Binarization()
        With Frm_AdaptiveThresholding

            Do_AdaptiveThresholding(.ProcessingBoxSize,
                                        .IsObjectBlack,
                                        .ThresholdLevel)
        End With

    End Sub


    'Return LastRetMsg
    Function Process_Folders(SourceRootFolder As String, Optional delimitChar As String = ",") As String
        Dim RetMsg As String = ""
        Dim LastRetMsg As String = ""

        'Check if SourceRootFolder exist
        If MyFileSys.FolderExists(SourceRootFolder) = False Then
            RetMsg = "Could not find the root folder: " & delimitChar & SourceRootFolder
            BatchProcessLogfile.WriteLine(RetMsg)
            Return RetMsg
        End If

        'Scan every subfolder
        Dim AllSubFolders() As String
        AllSubFolders = MyFileSys.Get_AllSubFolders(SourceRootFolder)

        'Process every subfolder
        For q As Integer = 0 To AllSubFolders.Count - 1
            MDIMain.Status_Info2.Tag = "Processing " &
                                        (q + 1).ToString.Trim & "-th folder of " &
                                        AllSubFolders.Count.ToString.Trim & " folders"
            RetMsg = Process_Folder(AllSubFolders(q))

            If RetMsg <> "" Then
                LastRetMsg = RetMsg
            End If

            If IsStopProcessing = True Then
                Exit For
            End If

        Next

        Return LastRetMsg
    End Function

    'Return error messsage
    Function Process_Folder(SourceFolder As String, Optional delimitChar As String = ",") As String
        Dim RetMsg As String
        Dim myStopWatch As New Stopwatch
        Dim tempStr As String
        Dim IndexBegin, IndexEnd As Integer

        'Check if SourceFolder exist
        If MyFileSys.FolderExists(SourceFolder) Then
            Text_SourceFolder.Text = SourceFolder
        Else
            RetMsg = "Could not find the folder: " & delimitChar & SourceFolder
            BatchProcessLogfile.WriteLine(RetMsg)
            Return RetMsg
        End If


        'Read RegionInfo file
        RetMsg = Read_ROI(SourceFolder)
        If RetMsg <> "" Then
            BatchProcessLogfile.WriteLine(RetMsg)
            Return RetMsg
        End If


        With Frm_FileManager

            'Scan the source folder
            Call .Set_Folder(SourceFolder)
            Dim ImageCount As Integer
            ImageCount = .FileListBox.FilesCount
            If Check_Confine.Checked Then
                Try
                    IndexBegin = Math.Max(CInt(Text_ConfineFrom.Text) - 1, 0)
                    IndexEnd = CInt(Text_ConfineTo.Text) - 1
                    If IndexEnd > ImageCount - 2 Then
                        IndexEnd = ImageCount - 2
                    End If
                Catch
                    RetMsg = "Wrong file range " & delimitChar & SourceFolder
                    BatchProcessLogfile.WriteLine(RetMsg)
                    Return RetMsg
                End Try
            Else
                IndexBegin = 0
                IndexEnd = ImageCount - 1
            End If

            If ImageCount < 2 Then
                RetMsg = "Total number of images are less than 2 in the " &
                                delimitChar & SourceFolder
                BatchProcessLogfile.WriteLine(RetMsg)
                Return RetMsg
            End If


            'Create RawActivityResult file
            Dim Writer_Raw_AbsoluteLocation As StreamWriter

            Try
                Writer_Raw_AbsoluteLocation = File.CreateText(
                                    SourceFolder & PathDelimit & Filename_AbsoluteLocation)
            Catch
                RetMsg = "Could not create result file(s) in the " &
                                delimitChar & SourceFolder
                BatchProcessLogfile.WriteLine(RetMsg)
                Return RetMsg
            End Try


            'Write header
            Dim OutBufStr_AbsoluteLocation As String


            OutBufStr_AbsoluteLocation = "Filename" & delimitChar &
                                         "Blank" & delimitChar &
                                         "Experiment time (ms)" & delimitChar &
                                         "Time lapse (ms) (n+1 - n)" & delimitChar



            For q As Integer = 0 To ROI.Length - 1
                OutBufStr_AbsoluteLocation &= "[X] " & Get_ChemicalInfoStr(q, True) & delimitChar &
                                              "[Y] " & Get_ChemicalInfoStr(q, True) & delimitChar
            Next

            OutBufStr_AbsoluteLocation = MyTextLib.RemoveRightChar(OutBufStr_AbsoluteLocation, 1)


            Try
                Writer_Raw_AbsoluteLocation.WriteLine(OutBufStr_AbsoluteLocation.ToString)
            Catch
                RetMsg = "Could not write result file(s) in the " & delimitChar & SourceFolder
                BatchProcessLogfile.WriteLine(RetMsg)
                Return RetMsg
            End Try


            'Process every image
            Dim NextImageIndex As Integer
            Dim AnalysisIntervalInSec As Integer = CInt(Text_TimeIntervalSec.Text)
            For CurrentImageIndex As Integer = IndexBegin To IndexEnd
                If IsStopProcessing = True Then
                    Exit For
                End If

                myStopWatch.Reset()
                myStopWatch.Start()


                NextImageIndex = Find_NextImageIndex(.FileListBox, CurrentImageIndex,
                                                     AnalysisIntervalInSec,
                                                     Radio_WithFixedInterval.Checked)

                MDIMain.Status_Info2.Text =
                                MDIMain.Status_Info2.Tag.ToString & "  and  " &
                                CurrentImageIndex.ToString.Trim & "-th image of " &
                                ImageCount.ToString.Trim &
                                " images"
                MDIMain.StatusStrip_Status.Update()


                Text_Image1.Text = .FileListBox.FileName(CurrentImageIndex)
                If NextImageIndex > 0 Then
                    Text_Image2.Text = .FileListBox.FileName(NextImageIndex)
                End If



                Frm_FileManager.FileListBox.ListView.Items(CInt(CurrentImageIndex)).Selected = True
                Frm_FileManager.FileListBox.ListView.EnsureVisible(CInt(CurrentImageIndex))
                Frm_FileManager.FileListBox.Refresh()

                Frm_FileManager.LoadImages()

                'Cleaning spots
                Conduct_Binarization()

                'Process image
                Conduct_Binarization()
                Conduct_RegionExtraction()
                Frm_RegionExtract.CreateShowCircledOriginal()
                Frm_Canvas.DrawRegions()
                Application.DoEvents()


                'Compute time
                Dim ExperimentTimMS As Long
                Dim TimeLapseMS As Long
                Dim TimeLapseMSString As String
                ExperimentTimMS = MyTextLib.Compute_TimeDiffInMS(
                                    .FileListBox.FileName(0),
                                    .FileListBox.FileName(CurrentImageIndex))
                If NextImageIndex > 0 Then
                    TimeLapseMS = MyTextLib.Compute_TimeDiffInMS(
                                    .FileListBox.FileName(CurrentImageIndex),
                                    .FileListBox.FileName(NextImageIndex))
                    TimeLapseMSString = TimeLapseMS.ToString.Trim
                Else
                    TimeLapseMSString = ""
                End If



                'Write a result
                tempStr = .FileListBox.FileName(CurrentImageIndex) & delimitChar &
                            "" & delimitChar &
                            ExperimentTimMS.ToString.Trim & delimitChar &
                            TimeLapseMSString & delimitChar


                With Frm_RegionExtract
                    OutBufStr_AbsoluteLocation = tempStr & .Get_ObjectInfoAsString(
                                                        delimitChar, 1, "AbsolteCenter")
                End With
                Try
                    Writer_Raw_AbsoluteLocation.WriteLine(OutBufStr_AbsoluteLocation)
                Catch
                    RetMsg = "Could not write " & Filename_AbsoluteLocation &
                            " in the " & delimitChar & SourceFolder
                    BatchProcessLogfile.WriteLine(RetMsg)
                    Return RetMsg
                End Try

                If NextImageIndex = 0 Then
                    Exit For
                End If

                CurrentImageIndex = NextImageIndex - 1

                myStopWatch.Stop()
                MDIMain.Status_Info3.Text = "Processing time:  " +
                                myStopWatch.ElapsedMilliseconds.ToString + " ms"
            Next

            Writer_Raw_AbsoluteLocation.Close()
            Writer_Raw_AbsoluteLocation.Dispose()
            Writer_Raw_AbsoluteLocation = Nothing
        End With




        Return Do_PostProcessing(Text_SourceFolder.Text)
    End Function



    'Return "", if no errors
    Public Function Do_PostProcessing(SourceFolder As String,
                                      Optional BlockDurationMin As Integer = 15,
                                      Optional delimitStr As String = ",") As String

        Dim OutStr As String
        Dim RetMsg As String


        'Read RegionInfo file
        RetMsg = Read_ROI(SourceFolder)
        If RetMsg <> "" Then
            BatchProcessLogfile.WriteLine(RetMsg)
            Return RetMsg
        End If



        Array_AbsoluteLocation = MyTextLib.Get_String2DAarry_From_TextFile(
                                                SourceFolder + PathDelimit +
                                                Filename_AbsoluteLocation,
                                                delimitStr, False)
        If Array_AbsoluteLocation Is Nothing Then
            Return "Could not open " + Filename_AbsoluteLocation
        End If



        Array_RelativeLocation = Compute_RelativeLocation(Array_AbsoluteLocation)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_RelativeLocation,
                                                               delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_RelativeLocation,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_RelativeLocation + vbCrLf + vbCrLf +
                         e.ToString
        End Try



        Array_TravelDistance = Compute_TravelDistance(Array_AbsoluteLocation)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_TravelDistance, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_TravelDistance,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_TravelDistance + vbCrLf + vbCrLf +
                         e.ToString
        End Try


        Array_TravelSpeed = Compute_TravelSpeed(Array_AbsoluteLocation)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_TravelSpeed, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_TravelSpeed,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_TravelSpeed + vbCrLf + vbCrLf +
                         e.ToString
        End Try



        Array_TravelSpeed_EveryMin = Compute_TravelSpeed_EveryMin(Array_TravelSpeed,
                                                                  BlockDurationMin)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_TravelSpeed_EveryMin, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit +
                          Filename_TravelSpeed_TimeBlockMin.Replace("0", BlockDurationMin.ToString.Trim),
                          OutStr,
                          False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_TravelSpeed + vbCrLf + vbCrLf +
                         e.ToString
        End Try


        Array_TravelDistance_EveryMin = Compute_TravelDistance_EveryMin(Array_TravelSpeed_EveryMin,
                                                                        BlockDurationMin)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_TravelDistance_EveryMin, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit +
                        Filename_TravelDistance_TimeBlockMin.Replace("0", BlockDurationMin.ToString.Trim), OutStr,
                        False,
                        System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_TravelSpeed + vbCrLf + vbCrLf +
                         e.ToString
        End Try


        Array_CentralAngle = Compute_CentralAngle(Array_AbsoluteLocation)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_CentralAngle, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_CentralAngle,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_CentralAngle + vbCrLf + vbCrLf +
                         e.ToString
        End Try


        Array_DistanceFromCenter = Compute_DistanceFromCenter(Array_AbsoluteLocation)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_DistanceFromCenter, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_DistanceFromCenter,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_DistanceFromCenter + vbCrLf + vbCrLf +
                         e.ToString
        End Try


        Array_Rotation = Compute_Rotation(Array_AbsoluteLocation)
        OutStr = MyTextLib.Convert_String2DArray_To_LongString(Array_Rotation, delimitStr)
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_RotationAngle,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_RotationAngle + vbCrLf + vbCrLf +
                         e.ToString
        End Try


        RetMsg = Process_LocationHeatmap(SourceFolder, delimitStr)
        If RetMsg <> "" Then
            Return RetMsg
        End If


        Return ""
    End Function


    'Return "", if no errors
    Public Function Process_LocationHeatmap(SourceFolder As String,
                                      Optional delimitStr As String = ",",
                                      Optional IsConfineImages As Boolean = False) As String

        Dim OutStr As String
        Dim TotalCount As Integer
        Dim IndexBegin, IndexEnd As Integer

        Try
            LocationHeatmap_GridSizeN = CInt(Frm_Reviewer.Text_GridSizeN_Loc.Text)
            If LocationHeatmap_GridSizeN < 5 Then
                LocationHeatmap_GridSizeN = 15
                Frm_Reviewer.Text_GridSizeN_Loc.Text = "15"
            ElseIf LocationHeatmap_GridSizeN > 50 Then
                LocationHeatmap_GridSizeN = 50
                Frm_Reviewer.Text_GridSizeN_Loc.Text = "50"
            End If
        Catch ex As Exception
            LocationHeatmap_GridSizeN = 15
            Frm_Reviewer.Text_GridSizeN_Loc.Text = "15"
        End Try



        Array_RelativeLocation = MyTextLib.Get_String2DAarry_From_TextFile(
                                                SourceFolder + PathDelimit +
                                                Filename_RelativeLocation,
                                                delimitStr, False)
        If Array_RelativeLocation Is Nothing Then
            Return "Could not open " + Filename_RelativeLocation
        End If


        If IsConfineImages AndAlso Frm_Reviewer.Check_Confine_Loc.Checked Then
            IndexBegin = Math.Max(2, CInt(Frm_Reviewer.Text_ConfineFrom_Loc.Text))
            IndexEnd = Math.Min(CInt(Frm_Reviewer.Text_ConfineTo_Loc.Text),
                                            Array_RelativeLocation.GetUpperBound(1))
        Else
            IndexBegin = 2
            IndexEnd = Array_RelativeLocation.GetUpperBound(1)
        End If


        Dim CurRegion, CurIndex As Integer
        Dim m, n As Double



        'index begin from 1
        Dim LocationHeatmapNum(LocationHeatmap_GridSizeN,
                               LocationHeatmap_GridSizeN) As Integer
        OutStr = ""
        For CurRegion = 0 To ROI.GetUpperBound(0)
            ReDim LocationHeatmapNum(LocationHeatmap_GridSizeN,
                                     LocationHeatmap_GridSizeN)


            TotalCount = 0
            For CurIndex = IndexBegin To IndexEnd
                If Array_RelativeLocation(CurRegion * 2 + 5, CurIndex) <> "" AndAlso
                   Array_RelativeLocation(CurRegion * 2 + 6, CurIndex) <> "" Then

                    m = Val(Array_RelativeLocation(CurRegion * 2 + 5, CurIndex))
                    n = Val(Array_RelativeLocation(CurRegion * 2 + 6, CurIndex))
                    m = Int(m / ROI(CurRegion).Boundary.Width * LocationHeatmap_GridSizeN)
                    n = Int(n / ROI(CurRegion).Boundary.Height * LocationHeatmap_GridSizeN)
                    m = Math.Min(m, LocationHeatmap_GridSizeN - 1)
                    n = Math.Min(n, LocationHeatmap_GridSizeN - 1)
                    LocationHeatmapNum(CInt(m) + 1, CInt(n) + 1) += 1
                    TotalCount += 1
                End If
            Next

            OutStr = OutStr + "ROI ID" + delimitStr + (CurRegion + 1).ToString.Trim +
                     delimitStr + delimitStr + "Total count" + delimitStr + TotalCount.ToString.Trim +
                     delimitStr + delimitStr + Get_ChemicalInfoStr(CurRegion, True) +
                     Strings.StrDup(LocationHeatmap_GridSizeN - 7, delimitStr) + vbCrLf
            OutStr = OutStr + MyTextLib.Convert_Int2DArray_To_LongString(LocationHeatmapNum, delimitStr) +
                    vbCrLf
        Next
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_LocationHeatmap,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_LocationHeatmap + vbCrLf + vbCrLf +
                        e.ToString
        End Try


        Return ""
    End Function



    'Array index starts from 1
    Public Function Compute_TravelDistance(String2DArray(,) As String) As String(,)

        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        Dim DistanceMoved, Speed As Double
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length, RowCountIndex) As String



        'Array index starts from 1
        For q = 1 To RowCountIndex
            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)

            If q = 1 Then
                newString2DArray(4, q) = String2DArray(4, q)
            Else
                If q < RowCountIndex Then
                    newString2DArray(4, q + 1) = String2DArray(4, q)
                End If
            End If

            If q < RowCountIndex Then
                For w = 0 To ROI.Length - 1
                    If q > 1 Then
                        If String2DArray(5 + w * 2, q) <> "" AndAlso
                           String2DArray(5 + w * 2, q + 1) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q + 1) <> "" Then
                            DistanceMoved = Distance(CDbl(String2DArray(5 + w * 2, q)),
                                                CDbl(String2DArray(5 + w * 2 + 1, q)),
                                                CDbl(String2DArray(5 + w * 2, q + 1)),
                                                CDbl(String2DArray(5 + w * 2 + 1, q + 1)))
                            Speed = DistanceMoved / CDbl(String2DArray(4, q)) * 1000
                            newString2DArray(5 + w, q + 1) = Format(DistanceMoved, "0.0")
                        Else
                            newString2DArray(5 + w, q + 1) = ""
                        End If

                    Else
                        newString2DArray(5 + w, q) = Get_ChemicalInfoStr(w, True)
                    End If

                Next
            End If
        Next

        newString2DArray(4, 1) = "Time lapse (ms) (n - n-1)"

        Return newString2DArray
    End Function


    'Array index starts from 1
    Public Function Compute_TravelSpeed(String2DArray(,) As String) As String(,)

        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        Dim DistanceMoved, Speed As Double
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length, RowCountIndex) As String


        'Array index starts from 1
        For q = 1 To RowCountIndex
            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)

            If q = 1 Then
                newString2DArray(4, q) = String2DArray(4, q)
            Else
                If q < RowCountIndex Then
                    newString2DArray(4, q + 1) = String2DArray(4, q)
                End If
            End If


            If q < RowCountIndex Then
                For w = 0 To ROI.Length - 1
                    If q > 1 Then
                        If String2DArray(5 + w * 2, q) <> "" AndAlso
                           String2DArray(5 + w * 2, q + 1) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q + 1) <> "" Then
                            DistanceMoved = Distance(CDbl(String2DArray(5 + w * 2, q)),
                                                    CDbl(String2DArray(5 + w * 2 + 1, q)),
                                                    CDbl(String2DArray(5 + w * 2, q + 1)),
                                                    CDbl(String2DArray(5 + w * 2 + 1, q + 1)))
                            Speed = DistanceMoved / CDbl(String2DArray(4, q)) * 1000
                            newString2DArray(5 + w, q + 1) = Format(Speed, "0.0")
                        Else
                            newString2DArray(5 + w, q + 1) = ""
                        End If

                    Else
                        newString2DArray(5 + w, q) = Get_ChemicalInfoStr(w, True)
                    End If
                Next
            End If
        Next

        newString2DArray(4, 1) = "Time lapse (ms) (n - n-1)"

        Return newString2DArray
    End Function


    Public Function Compute_TravelSpeed_EveryMin(String2DArray(,) As String,
                                                 BlockDurationMin As Integer) As String(,)

        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)


        Dim newString2DArray(4 + ROI.Length,
                             CInt(CInt(String2DArray(3, RowCountIndex)) / 60000 / BlockDurationMin) + 2) As String
        Dim CurRowIndex, IndexBegin, IndexEnd As Integer
        Dim OutCurRowIndex As Integer
        Dim CurMin As Integer



        'Writing header
        For w = 1 To ROI.Length + 4
            newString2DArray(w, 1) = String2DArray(w, 1)
        Next


        OutCurRowIndex = 1
        CurMin = BlockDurationMin
        IndexBegin = 2
        Do
            For CurRowIndex = IndexBegin To RowCountIndex
                If String2DArray(3, CurRowIndex) <> "" AndAlso
                   CDbl(String2DArray(3, CurRowIndex)) > CurMin * 60000 Then
                    IndexEnd = CurRowIndex - 1
                    Exit For
                End If
            Next
            'if not found
            If CurRowIndex = RowCountIndex + 1 Then
                IndexEnd = RowCountIndex
            End If


            OutCurRowIndex += 1
            newString2DArray(1, OutCurRowIndex) = String2DArray(1, IndexEnd)
            newString2DArray(2, OutCurRowIndex) = String2DArray(2, IndexEnd)
            newString2DArray(3, OutCurRowIndex) = String2DArray(3, IndexEnd)

            If CurMin = BlockDurationMin Then
                newString2DArray(4, OutCurRowIndex) = Str(CInt(String2DArray(3, IndexEnd)) -
                                                      CInt(String2DArray(3, IndexBegin)))
            Else
                newString2DArray(4, OutCurRowIndex) = Str(CInt(String2DArray(3, IndexEnd)) -
                                                      CInt(String2DArray(3, IndexBegin)))
            End If


            For w = 1 To ROI.Length

                Dim CurSum As Double = 0
                Dim CurItemCount As Integer = 0
                For q = IndexBegin To IndexEnd
                    If String2DArray(4 + w, q) <> "" Then
                        CurItemCount += 1
                        CurSum += CDbl(String2DArray(4 + w, q))
                    End If
                Next

                If CurItemCount = 0 Then
                    newString2DArray(4 + w, OutCurRowIndex) = ""
                Else
                    newString2DArray(4 + w, OutCurRowIndex) = Format(CurSum / CurItemCount, "0.000")
                End If
            Next

            If IndexEnd >= RowCountIndex - 1 Then Exit Do

            IndexBegin = IndexEnd + 1
            CurMin += BlockDurationMin
        Loop


        If OutCurRowIndex < newString2DArray.GetUpperBound(1) Then
            ReDim Preserve newString2DArray(4 + ROI.Length, OutCurRowIndex)
        End If

        Return newString2DArray
    End Function


    Public Function Compute_TravelDistance_EveryMin(String2DArray(,) As String,
                                                 BlockDurationMin As Integer) As String(,)

        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length, RowCountIndex) As String


        'Writing header
        For w = 1 To ROI.Length + 4
            newString2DArray(w, 1) = String2DArray(w, 1)
        Next


        'Array index starts from 1
        For q = 2 To RowCountIndex

            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)
            newString2DArray(4, q) = String2DArray(4, q)


            Dim TimeLapseSec As Double = CDbl(String2DArray(4, q)) / 1000
            For w = 1 To ROI.Length

                If String2DArray(4 + w, q) = "" Then
                    String2DArray(4 + w, q) = ""
                Else
                    newString2DArray(4 + w, q) = Format(CDbl(String2DArray(4 + w, q)) * TimeLapseSec, "0.00")
                End If

            Next
        Next


        Return newString2DArray
    End Function

    Public Function Compute_RelativeLocation(String2DArray(,) As String) As String(,)
        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length * 2, RowCountIndex) As String


        'Writing header
        For w = 1 To ROI.Length * 2 + 4
            newString2DArray(w, 1) = String2DArray(w, 1)
        Next



        'Array index starts from 1
        For q = 2 To RowCountIndex
            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)
            newString2DArray(4, q) = String2DArray(4, q)

            For w = 0 To ROI.Length - 1
                If String2DArray(5 + w * 2, q) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q) <> "" Then
                    newString2DArray(5 + w * 2, q) = Format(CInt(String2DArray(5 + w * 2, q)) -
                                                                        ROI(w).Boundary.Left, "0")
                    newString2DArray(5 + w * 2 + 1, q) = Format(CInt(String2DArray(5 + w * 2 + 1, q)) -
                                                                        ROI(w).Boundary.Top, "0")
                Else
                    newString2DArray(5 + w * 2, q) = ""
                    newString2DArray(5 + w * 2 + 1, q) = ""
                End If
            Next
        Next

        Return newString2DArray
    End Function

    Public Function Compute_CentralAngle(String2DArray(,) As String) As String(,)
        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        Dim ROICenterX, ROICenterY As Integer
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length, RowCountIndex) As String


        'Array index starts from 1
        For q = 1 To RowCountIndex
            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)
            newString2DArray(4, q) = String2DArray(4, q)


            For w = 0 To ROI.Length - 1
                If q > 1 Then
                    If String2DArray(5 + w * 2, q) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q) <> "" Then
                        ROICenterX = CInt(ROI(w).Boundary.Left + ROI(w).Boundary.Width / 2)
                        ROICenterY = CInt(ROI(w).Boundary.Top + ROI(w).Boundary.Height / 2)

                        newString2DArray(5 + w, q) = Format(Get_AngleInDegreeOfTwoPoints(
                                                                New Point(ROICenterX, ROICenterY),
                                                                New Point(CInt(String2DArray(5 + w * 2, q)),
                                                                          CInt(String2DArray(5 + w * 2 + 1, q)))
                                                                ), "0")


                    Else
                        newString2DArray(5 + w, q) = ""
                    End If

                Else
                    newString2DArray(5 + w, q) = Get_ChemicalInfoStr(w, True)
                End If

            Next
        Next

        Return newString2DArray
    End Function


    Public Function Compute_DistanceFromCenter(String2DArray(,) As String) As String(,)
        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        Dim ROICenterX, ROICenterY As Integer
        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length, RowCountIndex) As String


        'Array index starts from 1
        For q = 1 To RowCountIndex
            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)
            newString2DArray(4, q) = String2DArray(4, q)

            For w = 0 To ROI.Length - 1
                If q > 1 Then
                    If String2DArray(5 + w * 2, q) <> "" AndAlso
                           String2DArray(5 + w * 2 + 1, q) <> "" Then
                        ROICenterX = CInt(ROI(w).Boundary.Left + ROI(w).Boundary.Width / 2)
                        ROICenterY = CInt(ROI(w).Boundary.Top + ROI(w).Boundary.Height / 2)


                        newString2DArray(5 + w, q) = Format(Distance(CInt(String2DArray(5 + w * 2, q)),
                                                                         CInt(String2DArray(5 + w * 2 + 1, q)),
                                                                         ROICenterX,
                                                                         ROICenterY), "0")
                    Else
                        newString2DArray(5 + w, q) = ""
                    End If

                Else
                    newString2DArray(5 + w, q) = Get_ChemicalInfoStr(w, True)
                End If

            Next
        Next

        Return newString2DArray
    End Function


    'Array index starts from 1
    Public Function Compute_Rotation(String2DArray(,) As String) As String(,)
        Dim MaxAllowRotation As Integer = 150
        Dim MinDistanceMoved As Integer = 0
        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer
        Dim AngleChangedAntiClockWise As Double
        Dim Angle1, Angle2 As Double


        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        Dim newString2DArray(4 + ROI.Length, RowCountIndex) As String


        'Array index starts from 1
        For q = 1 To RowCountIndex
            newString2DArray(1, q) = String2DArray(1, q)
            newString2DArray(2, q) = String2DArray(2, q)
            newString2DArray(3, q) = String2DArray(3, q)

            If q = 1 Then
                newString2DArray(4, q) = String2DArray(4, q)
            Else
                If q < RowCountIndex Then
                    newString2DArray(4, q + 1) = String2DArray(4, q)
                End If
            End If


            If q < RowCountIndex Then
                For w = 0 To ROI.Length - 1
                    If q > 1 Then
                        If String2DArray(5 + w, q) <> "" AndAlso
                            String2DArray(5 + w, q + 1) <> "" AndAlso
                            Array_TravelDistance(5 + w, q) <> "" AndAlso
                            CInt(Array_TravelDistance(5 + w, q)) >= MinDistanceMoved Then

                            Angle1 = CDbl(String2DArray(5 + w, q))
                            Angle2 = CDbl(String2DArray(5 + w, q + 1))

                            If Angle2 - Angle1 >= 0 Then
                                AngleChangedAntiClockWise = Angle2 - Angle1
                            Else
                                AngleChangedAntiClockWise = 360 + Angle2 - Angle1
                            End If


                            If AngleChangedAntiClockWise <= MaxAllowRotation Then
                                newString2DArray(5 + w, q + 1) =
                                        Format(AngleChangedAntiClockWise, "0.0")

                            ElseIf AngleChangedAntiClockWise >= (360 - MaxAllowRotation) AndAlso
                               AngleChangedAntiClockWise <= 360 Then

                                newString2DArray(5 + w, q + 1) =
                                        Format(-(360 - AngleChangedAntiClockWise), "0.0")

                            Else
                                newString2DArray(5 + w, q + 1) = "Ambiguous"
                            End If
                        Else
                            newString2DArray(5 + w, q + 1) = ""
                        End If


                    ElseIf q = 2 Then
                        newString2DArray(5 + w, q) = ""

                    Else
                        'q=1
                        newString2DArray(5 + w, q) = Get_ChemicalInfoStr(w, True)
                    End If

                Next
            End If
        Next

        newString2DArray(4, 1) = "Time lapse (ms) (n - n-1)"

        Return newString2DArray
    End Function

    Sub SetUIDisable()
        Group_Source.Enabled = False
        Group_TimeInterval.Enabled = False
        Check_ProcessEverySubfolder.Enabled = False
    End Sub

    Sub SetUIEnable()
        Group_Source.Enabled = True
        Group_TimeInterval.Enabled = True
        Check_ProcessEverySubfolder.Enabled = True
    End Sub

    Private Sub Cmd_Process_Click(sender As Object, e As EventArgs) Handles Cmd_Process.Click
        SetUIDisable()
        If Cmd_Process.Text = "Stop" Then
            IsStopProcessing = True
            Cmd_Process.Enabled = False
            Exit Sub
        End If

        Cmd_Process.Text = "Stop"

        Dim RetMsg As String
        Dim SourceRootFolder As String

        SourceRootFolder = Text_SourceFolder.Text

        Try
            BatchProcessLogfile = File.CreateText(SourceRootFolder & PathDelimit & Filename_BatchProcessLog)
        Catch
            MsgBox("Could not create BatchProcessLog file!", MsgBoxStyle.Critical, "Error")
            SetUIEnable()
            Exit Sub
        End Try

        If Check_ProcessEverySubfolder.Checked Then
            RetMsg = Process_Folders(SourceRootFolder)
        Else
            MDIMain.Status_Info2.Tag = "Processing single folder"
            RetMsg = Process_Folder(SourceRootFolder)
        End If


        BatchProcessLogfile.Close()

        MDIMain.Status_Info2.Text = "Batch processing completed"

        If IsStopProcessing Then
            MsgBox("Processing halted by user!", MsgBoxStyle.Exclamation, "Message")
        End If

        If RetMsg = "" Then
            MyFileSys.DeleteMultipleFiles(SourceRootFolder, Filename_BatchProcessLog)
        Else
            MsgBox("There were errors! Some folders might not be analyzed" & vbCrLf &
                       "Check " & Filename_BatchProcessLog, MsgBoxStyle.Critical, "Error")
        End If


        Cmd_Process.Text = "Process"
        Cmd_Process.Enabled = True
        IsStopProcessing = False
        SetUIEnable()
    End Sub


    Private Sub Radio_WithFixedInterval_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_WithFixedInterval.CheckedChanged
        Label_TimeInterval.Visible = Radio_WithFixedInterval.Checked
        Text_TimeIntervalSec.Visible = Radio_WithFixedInterval.Checked
    End Sub

    Private Sub Check_Subtraction_Preblurring_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Subtraction_Preblurring.CheckedChanged
        Combo_Subtraction_PreblurringSize.Visible = Check_Subtraction_Preblurring.Checked
    End Sub

    Private Sub Check_Binarization_Preblurring_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Binarization_Preblurring.CheckedChanged
        Combo_Binarization_PreblurringSize.Visible = Check_Binarization_Preblurring.Checked
    End Sub

    Private Sub Cmd_SetAdaptive_Click(sender As Object, e As EventArgs) Handles Cmd_SetAdaptive.Click
        If ROI Is Nothing Then
            MsgBox(Filename_ROI + " is not found in the source folder" + vbCrLf +
                   "Please create the file first", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If


        With Frm_RegionExtract
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub Frm_Tracking_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            Frm_Reviewer.Hide()
        End If
    End Sub

    Public Sub SelectFileName(ByVal FileName As String, ByVal SelectedIndex As Integer)

        If Me.Visible = False Then Exit Sub


        Dim FileIndexArray(1) As Integer
        Dim Imagefile1 As String
        Dim NextImageIndex As Integer
        Dim AnalysisIntervalInSec As Integer = CInt(Text_TimeIntervalSec.Text)

        With Frm_FileManager
            Text_Image1.Text = FileName
            Imagefile1 = Text_SourceFolder.Text & PathDelimit & FileName

            If MyFileSys.FileExists(Imagefile1) Then
                Image_Original =
                CType(MyImgProcessing.Image_FromFile(Imagefile1).Clone, Bitmap)

                NextImageIndex = Find_NextImageIndex(.FileListBox,
                                                 SelectedIndex,
                                                 AnalysisIntervalInSec,
                                                 Radio_WithFixedInterval.Checked)
                If NextImageIndex = 0 Then
                    Text_Image2.Text = ""
                Else
                    Text_Image2.Text = .FileListBox.FileName(NextImageIndex)
                End If


                Frm_FileManager.LoadImages()



                If Frm_Canvas.Cmd_QuickAnim.Text = "No animation" Then
                    Frm_Canvas.Cmd_QuickAnim_Click(Nothing, Nothing)
                End If

                Frm_Canvas.Canvas.Image = CType(Image_Original.Clone, Bitmap)
                Frm_Canvas.Text = "Canvas - Original 1st image of " & FileName


                Image_Binarized = Nothing
                Image_RegionExtracted = Nothing

                Frm_Canvas.DrawRegions()

            Else
                MsgBox("File not found!", MsgBoxStyle.Critical, "Error")

            End If

        End With
    End Sub

    Private Sub Check_Confine_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Confine.CheckedChanged
        Text_ConfineFrom.Enabled = Check_Confine.Checked
        Text_ConfineTo.Enabled = Check_Confine.Checked
    End Sub


    Function Read_ROI(SourceFolder As String, Optional delimitStr As String = ",") As String
        Dim RegionInfoFullPath As String

        Dim TextTable(,) As String
        Dim TextTable_RowCount As Integer
        Dim TextTable_ColCount As Integer

        RegionInfoFullPath = SourceFolder & PathDelimit & Filename_ROI

        If MyFileSys.FileExists(RegionInfoFullPath) = False Then
            ROI = Nothing
            Return Filename_ROI & " not found in the " & delimitStr & SourceFolder
        End If


        TextTable = MyTextLib.Get_String2DAarry_From_TextFile(RegionInfoFullPath,
                                                              delimitStr,
                                                              False)

        If TextTable Is Nothing Then
            Return "Empty ROI file"
        End If

        TextTable_RowCount = TextTable.GetUpperBound(1)
        TextTable_ColCount = TextTable.GetUpperBound(0)
        ReDim ROI(TextTable_RowCount - 2)


        If TextTable_ColCount <> 10 Then
            Return "Invalid ROI format"
        End If

        For q As Integer = 2 To TextTable_RowCount
            Try
                With ROI(q - 2)
                    .Condition1 = TextTable(1, q)
                    .Condition2 = TextTable(2, q)
                    .TestDate = TextTable(3, q)
                    .Plate = TextTable(4, q)
                    .Well = TextTable(5, q)
                    .Shape = TextTable(6, q).ToLower
                    .Boundary = New Rectangle(CInt(TextTable(7, q)),
                                               CInt(TextTable(8, q)),
                                               CInt(TextTable(9, q)) - CInt(TextTable(7, q)) + 1,
                                               CInt(TextTable(10, q)) - CInt(TextTable(8, q)) + 1)
                End With

            Catch
                ROI = Nothing
                Return "Invalid region: Check " & q.ToString.Trim & "th line of the " &
                                delimitStr & RegionInfoFullPath
            End Try
        Next

        Return ""
    End Function


    'Return "", if no errors
    Public Function Process_DistanceFromCenterHeatmap(SourceFolder As String,
                                      Optional delimitStr As String = ",",
                                      Optional IsConfineImages As Boolean = False) As String

        Dim OutStr As String
        Dim TotalCount As Integer
        Dim IndexBegin, IndexEnd As Integer

        Try
            DistanceHeatmap_GridSizeN = CInt(Frm_Reviewer.Text_GridSizeN_Dis.Text)
            If DistanceHeatmap_GridSizeN < 5 Then
                DistanceHeatmap_GridSizeN = 15
                Frm_Reviewer.Text_GridSizeN_Loc.Text = "15"
            ElseIf DistanceHeatmap_GridSizeN > 50 Then
                DistanceHeatmap_GridSizeN = 50
                Frm_Reviewer.Text_GridSizeN_Dis.Text = "50"
            End If
        Catch ex As Exception
            DistanceHeatmap_GridSizeN = 15
            Frm_Reviewer.Text_GridSizeN_Dis.Text = "15"
        End Try



        Array_DistanceFromCenter = MyTextLib.Get_String2DAarry_From_TextFile(
                                                SourceFolder + PathDelimit +
                                                Filename_DistanceFromCenter,
                                                delimitStr, False)
        If Array_DistanceFromCenter Is Nothing Then
            Return "Could not open " + Filename_DistanceFromCenter
        End If


        If IsConfineImages AndAlso Frm_Reviewer.Check_Confine_Dis.Checked Then
            IndexBegin = Math.Max(2, CInt(Frm_Reviewer.Text_ConfineFrom_Dis.Text))
            IndexEnd = Math.Min(CInt(Frm_Reviewer.Text_ConfineTo_Dis.Text),
                                            Array_DistanceFromCenter.GetUpperBound(1))
        Else
            IndexBegin = 2
            IndexEnd = Array_DistanceFromCenter.GetUpperBound(1)
        End If


        Dim CurRegion, CurIndex As Integer
        Dim m As Double



        'index begin from 1
        Dim DistanceHeatmapNum(DistanceHeatmap_GridSizeN, 1) As Integer


        OutStr = ""
        For q As Integer = 1 To DistanceHeatmap_GridSizeN
            OutStr += delimitStr + q.ToString.Trim
        Next
        OutStr += vbCrLf


        For CurRegion = 0 To ROI.GetUpperBound(0)
            ReDim DistanceHeatmapNum(DistanceHeatmap_GridSizeN, 1)


            TotalCount = 0
            Dim MaxLength As Integer = CInt(Math.Max(ROI(CurRegion).Boundary.Width / 2,
                                                     ROI(CurRegion).Boundary.Height / 2))
            For CurIndex = IndexBegin To IndexEnd
                If Array_DistanceFromCenter(CurRegion + 5, CurIndex) <> "" Then

                    m = Val(Array_DistanceFromCenter(CurRegion + 5, CurIndex))
                    m = Int(m / MaxLength * DistanceHeatmap_GridSizeN)
                    m = Math.Min(m, DistanceHeatmap_GridSizeN - 1)
                    DistanceHeatmapNum(CInt(m) + 1, 1) += 1
                    TotalCount += 1
                End If
            Next

            OutStr += Get_ChemicalInfoStr(CurRegion, True) + delimitStr +
                      MyTextLib.Convert_Int2DArray_To_LongString(DistanceHeatmapNum, delimitStr)
        Next
        Try
            My.Computer.FileSystem.WriteAllText(SourceFolder + PathDelimit + Filename_DistanceFromCenterHeatmap,
                                   OutStr,
                                   False, System.Text.Encoding.ASCII)
        Catch e As Exception
            Return "Could not create " + Filename_LocationHeatmap + vbCrLf + vbCrLf +
                        e.ToString
        End Try

        Return ""
    End Function

End Class
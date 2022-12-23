Imports System.IO

Public Class Frm_FileManager

    Dim IsFormLoading As Boolean = True

    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()
    End Sub


    Private Sub Frm_FileManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        IsFormLoading = False
        FileListBox.ExtFilter = ".bmp .tiff .tif .jpeg .jpg .gif .png"
        FileListBox.AdjustWidthRatio(60)
    End Sub

    Public Sub New()

        InitializeComponent()

        Me.MdiParent = MDIMain
        MDIMain.Show()
    End Sub

    Public Sub Set_Folder(FullPath As String)
        If IsFormLoading Then Exit Sub

        FileListBox.CurrentFullPath = FullPath
        FileListBox.ReScan()

        Me.Text = "File Manager: " & Get_ShortFolderPath(FullPath)


        If myFileSys.FileExists(FullPath & PathDelimit & Filename_ROI) Then
            Dim RetMsg As String

            RetMsg = Frm_Tracker.Read_ROI(FullPath)



            If RetMsg = "" Then
                Frm_Canvas.Cmd_ShowRegions.Enabled = True
                Frm_Canvas.Cmd_ShowRegions.Text = "Show regions"

                If ROI.Length <> Frm_Reviewer.Combo_Well.Items.Count Then
                    Frm_Reviewer.Combo_Well.Items.Clear()
                    For q As Integer = 1 To ROI.Length
                        Frm_Reviewer.Combo_Well.Items.Add(q.ToString.Trim)
                    Next
                    Frm_Reviewer.Combo_Well.SelectedIndex = 0
                End If

                If Frm_Reviewer.Visible Then
                    Frm_Reviewer.Load_OutputFiles()
                End If

            Else
                Frm_Canvas.Cmd_ShowRegions.Enabled = False
                Frm_Canvas.Cmd_ShowRegions.Text = "Hide regions"
            End If

        Else
            Frm_Canvas.Cmd_ShowRegions.Enabled = False
            Frm_Canvas.Cmd_ShowRegions.Text = "Hide regions"

            Frm_Reviewer.Combo_Well.Items.Clear()
        End If


    End Sub

    Private Function Get_ShortFolderPath(ByVal FullPathStr As String) As String
        If Len(FullPathStr) > 28 Then
            Return "..." & Strings.Right(FullPathStr, 28)
        Else
            Return FullPathStr
        End If

    End Function

    Private Sub FileListBox_FileSelected(ByVal FileName As String,
                                         ByVal FullPath As String,
                                         ByVal SelectedIndex As Integer) Handles FileListBox.FileSelected

        Label_FileNum.Text = " File #: " + (SelectedIndex + 1).ToString()
        If Frm_Tracker.Visible Then
            Call Frm_Tracker.SelectFileName(FileName, SelectedIndex)
        End If

        If Frm_Reviewer.Visible Then
            Call Frm_Reviewer.SelectFileName(FileName, SelectedIndex)
        End If
    End Sub


    Public Sub LoadImages()
        Dim Imagefile1 As String
        Dim Imagefile2 As String

        With Frm_Tracker
            Imagefile1 = .Text_SourceFolder.Text & PathDelimit & .Text_Image1.Text
            '  If Imagefile1.

            Image_Original = CType(myImgProcessing.Image_FromFile(Imagefile1).Clone, Bitmap)
            If .Text_Image2.Text <> "" Then
                Imagefile2 = .Text_SourceFolder.Text & PathDelimit & .Text_Image2.Text
            End If

            Image_Binarized = Nothing
            Image_RegionExtracted = Nothing
            Image_RegionLabeled = Nothing
            Image_OverlayOnOriginal = Nothing
        End With
    End Sub

    Private Sub FileListBox_ListUpdated() Handles FileListBox.ListUpdated
        Label_FileCount.Text = "Total " & FileListBox.FilesCount.ToString &
                                " files found"
    End Sub


    Public Sub Cmd_Rescan_Click(sender As System.Object, e As System.EventArgs) Handles Cmd_Rescan.Click
        Dim SourceFolder As String

        Dim AnalysisIntervalInSec As Integer = CInt(Frm_Tracker.Text_TimeIntervalSec.Text)

        Cmd_Rescan.Enabled = False

        If Frm_Tracker.Visible Then
            SourceFolder = Frm_Tracker.Text_SourceFolder.Text
        ElseIf Frm_Reviewer.Visible Then
            SourceFolder = Frm_Reviewer.Text_SourceFolder.Text
        Else
            Exit Sub
        End If

        Call Set_Folder(SourceFolder)
        If FileListBox.FilesCount >= 2 Then
            FileListBox.ListView.Items(0).Selected = True
        End If


        Cmd_Rescan.Enabled = True

    End Sub

    Private Sub FileListBox_UpdatingList(FilesCount As Integer, CurrentFileIndex As Integer) Handles FileListBox.UpdatingList
        Label_FileCount.Text = "Updating " & CurrentFileIndex.ToString &
                            "th file in " & FilesCount.ToString & " files"
    End Sub

    Private Sub FileListBox_Load(sender As Object, e As EventArgs) Handles FileListBox.Load

    End Sub
End Class
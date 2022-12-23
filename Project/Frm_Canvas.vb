Imports System.IO
Imports System.Drawing.Imaging




Public Class Frm_Canvas


    Dim _IsFormLoading As Boolean = True
    Private FileSaveDialog As New SaveFileDialog
    Dim m_PanStartPoint As Point
    Private _DrawingFont As New Font("Microsoft Sans Serif", 12,
                                    FontStyle.Regular, GraphicsUnit.Pixel)


    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Me.Hide()
    End Sub


    Private Sub Frm_Canvas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Canvas
            .Image = New Bitmap(100, 100)
            .PanMode = True
            .ScrollbarsVisible = True
            .VerticalScroll.Enabled = True
            .HorizontalScroll.Enabled = True
        End With

        Combo_AnimInterval.Text = "500"
        Combo_Anim1.SelectedIndex = 0
        Combo_Anim2.SelectedIndex = 0
        _IsFormLoading = False
    End Sub


    Public Sub New()
        InitializeComponent()

        Me.MdiParent = MDIMain
        MDIMain.Show()
    End Sub


    Public Sub DrawNow(bm As Bitmap)
        Canvas.Image = bm

        If Me.Visible = False Then
            Me.Show()
        End If

        Application.DoEvents()
    End Sub


    Private Sub Cmd_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Copy.Click
        Copy()
    End Sub


    Public Sub Copy()
        Try
            Clipboard.Clear()
            Clipboard.SetImage(Canvas.Image)
        Catch
            MsgBox("Failed to copy image!", MsgBoxStyle.Critical)
        End Try
    End Sub



    Public Sub OpenDialogAndSave()
        Static Pre_Path As String

        With FileSaveDialog
            If Pre_Path = "" Then Pre_Path = .InitialDirectory
            .InitialDirectory = Pre_Path
            .Title = "Save image file"
            .Filter = "Bitmap|*.bmp|Tiff|*.tif;*.tiff|png|*.png|Gif|*.gif|JPG|*.jpg;*.jpeg"
            .FileName = ""
            .OverwritePrompt = True
            .CheckPathExists = True
            If .ShowDialog = DialogResult.OK Then

                Dim DestFileName As String = .FileName
                Dim Return_Message As String =
                    Save(DestFileName)

                If Return_Message <> "" Then
                    MsgBox(Return_Message, MsgBoxStyle.Critical, "Error")
                End If


            End If
        End With
    End Sub


    Public Function Save(ByVal DestFileName As String,
                         Optional JpegCompressionRate As Single = 0.97) As String

        Dim FileName_Ext As String = Path.GetExtension(DestFileName)
        Dim ImageFileFormat As ImageFormat

        Select Case FileName_Ext.ToLower
            Case ".bmp"
                ImageFileFormat = ImageFormat.Bmp
            Case ".tiff", ".tif"
                ImageFileFormat = ImageFormat.Tiff
            Case ".png"
                ImageFileFormat = ImageFormat.Png
            Case ".gif"
                ImageFileFormat = ImageFormat.Gif
            Case ".jpg", ".jpeg"
                ImageFileFormat = ImageFormat.Jpeg
            Case Else
                ImageFileFormat = Nothing
        End Select


        If ImageFileFormat Is Nothing Then
            Return "Invalid image file format"


        ElseIf ImageFileFormat Is ImageFormat.Jpeg Then
            Try
                Call SaveCompressedJpeg(Canvas.Image,
                                        DestFileName, CLng(JpegCompressionRate * 100))
            Catch
                Return "Failed to save image file"
            End Try

        Else

            Dim outImage As Image
            outImage = CType(Canvas.Image.Clone, Image)

            Try
                outImage.Save(DestFileName, ImageFileFormat)
            Catch
                Return "Failed to save image file"
            End Try


            outImage.Dispose()
            outImage = Nothing

        End If


        Return ""
    End Function


    Private Sub Cmd_SaveAs_Click(sender As Object, e As EventArgs) Handles Cmd_SaveAs.Click
        OpenDialogAndSave()
    End Sub



    ' Get a codec's information.
    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For i As Integer = 0 To encoders.Length
            If encoders(i).MimeType = mimeType Then
                Return encoders(i)
            End If
        Next i
        Return Nothing
    End Function

    ' Save a JPEG in compressed form.
    ' The compression_level value
    ' should be between 10 and 100.
    Public Sub SaveCompressedJpeg(ByVal image As Image, ByVal file_name As String,
                                  ByVal compression_level As Long)

        If compression_level < 10 Then
            Throw New ArgumentException("Compression level must be between 10 and 100")
        End If

        ' Get an encoder parameter array and set the compression level.
        Dim encoder_params As EncoderParameters = New EncoderParameters(1)
        encoder_params.Param(0) = New EncoderParameter(Encoder.Quality, compression_level)
        ' Prepare the codec to encode.
        Dim image_codec_info As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' Save the file.
        image.Save(file_name, image_codec_info, encoder_params)
    End Sub


    Public Function Get_FormBorderWidth() As Integer
        Return CInt((Me.Width - Me.ClientSize.Width) / 2)
    End Function


    Public Function Get_FormTitleBarHeight() As Integer
        Return Me.Height - Me.ClientSize.Height - 2 * Get_FormBorderWidth()
    End Function


    Public Sub Cmd_Zoom100_Click(sender As Object, e As EventArgs) Handles Cmd_Zoom100.Click
        Canvas.ZoomFactor = 1
    End Sub

    Public Sub Cmd_ZoomIn_Click(sender As Object, e As EventArgs) Handles Cmd_ZoomIn.Click
        Canvas.ZoomIn()
    End Sub

    Public Sub Cmd_ZoomOut_Click(sender As Object, e As EventArgs) Handles Cmd_ZoomOut.Click
        Canvas.ZoomOut()
    End Sub

    Public Sub Menu_ResetZoom_Click(sender As Object, e As EventArgs) Handles Menu_ResetZoom.Click
        If Menu_Stretchtofit.Checked Then
            Call Menu_Stretchtofit_Click(Nothing, Nothing)
        End If

        Canvas.Origin = New Point(0, 0)
        Canvas.ZoomFactor = 1
    End Sub

    Public Sub Menu_Stretchtofit_Click(sender As Object, e As EventArgs) Handles Menu_Stretchtofit.Click
        Menu_Stretchtofit.Checked = Not (Menu_Stretchtofit.Checked)
        Canvas.StretchImageToFit = Menu_Stretchtofit.Checked

        Cmd_Zoom100.Enabled = Not (Menu_Stretchtofit.Checked)
        Cmd_ZoomIn.Enabled = Not (Menu_Stretchtofit.Checked)
        Cmd_ZoomOut.Enabled = Not (Menu_Stretchtofit.Checked)
    End Sub

    Public Sub Menu_Fittoscreen_Click(sender As Object, e As EventArgs) Handles Menu_Fittoscreen.Click
        If Menu_Stretchtofit.Checked Then
            Call Menu_Stretchtofit_Click(Nothing, Nothing)
        End If
        Canvas.fittoscreen()

    End Sub



    Public Sub Cmd_QuickAnim_Click(sender As Object, e As EventArgs) Handles Cmd_QuickAnim.Click
        If Cmd_QuickAnim.Text <> "No animation" Then
            Cmd_QuickAnim.Text = "No animation"
            Timer_Animation.Interval = CInt(Combo_AnimInterval.Text)
            Timer_Animation.Enabled = True
        Else
            Cmd_QuickAnim.Text = "Animate"
            Timer_Animation.Enabled = False
        End If
    End Sub

    Private Sub Timer_Animation_Tick(sender As Object, e As EventArgs) Handles Timer_Animation.Tick
        Static CurrentImageNum As Integer = 0

        If CurrentImageNum = 0 Then
            Select Case Combo_Anim1.SelectedIndex
                Case 0
                    If Image_Original IsNot Nothing Then
                        Canvas.Image = CType(Image_Original, Image)
                        Me.Text = "Canvas - Original image of " & Frm_Tracker.Text_Image1.Text
                    End If
                Case 1
                    If Image_Binarized IsNot Nothing Then
                        Canvas.Image = CType(Image_Binarized, Image)
                        Me.Text = "Canvas - Binarized image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case 2
                    If Image_RegionExtracted IsNot Nothing Then
                        Canvas.Image = CType(Image_RegionExtracted, Image)
                        Me.Text = "Canvas - Region extracted image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case 3
                    If Image_RegionLabeled IsNot Nothing Then
                        Canvas.Image = CType(Image_RegionLabeled, Image)
                        Me.Text = "Canvas - Region labeled image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case Else
            End Select
            CurrentImageNum = 1
        Else
            Select Case Combo_Anim2.SelectedIndex
                Case 0
                    If Image_Binarized IsNot Nothing Then
                        Canvas.Image = CType(Image_Binarized, Image)
                        Me.Text = "Canvas - Binarized image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case 1
                    If Image_RegionExtracted IsNot Nothing Then
                        Canvas.Image = CType(Image_RegionExtracted, Image)
                        Me.Text = "Canvas - Region extracted image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case 2
                    If Image_RegionLabeled IsNot Nothing Then
                        Canvas.Image = CType(Image_RegionLabeled, Image)
                        Me.Text = "Canvas - Region labeled image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case 3
                    If Image_OverlayOnOriginal IsNot Nothing Then
                        Canvas.Image = CType(Image_OverlayOnOriginal, Image)
                        Me.Text = "Canvas - Region labeled image of " & Frm_Tracker.Text_Image1.Text
                    End If

                Case Else
            End Select

            CurrentImageNum = 0
        End If



        DrawRegions()
    End Sub


    Private Sub Combo_AnimInterval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_AnimInterval.SelectedIndexChanged
        If _IsFormLoading Then Exit Sub

        Timer_Animation.Interval = CInt(Combo_AnimInterval.Text)
    End Sub



    Private Sub Cmd_ShowRegions_Click(sender As Object, e As EventArgs) Handles Cmd_ShowRegions.Click
        If Cmd_ShowRegions.Text = "Show regions" Then
            Cmd_ShowRegions.Text = "Hide regions"
        Else
            Cmd_ShowRegions.Text = "Show regions"
        End If
    End Sub


    Public Sub DrawRegions()
        If ROI Is Nothing OrElse Canvas.Image Is Nothing Then Exit Sub


        Using bm As New Bitmap(Canvas.Image), GraphBox As Graphics = Graphics.FromImage(bm)


            For q As Integer = 0 To ROI.GetUpperBound(0)
                If Cmd_ShowRegions.Text = "Show regions" Then
                    If ROI(q).Shape = "rectangle" Then
                        GraphBox.DrawRectangle(Pens.Red, ROI(q).Boundary)
                    Else
                        GraphBox.DrawEllipse(Pens.Red, ROI(q).Boundary)
                    End If
                End If


                If Cmd_ShowLabels.Text = "Show labels" Then
                    Call MyImgProcessing.Draw_Text_Outlined_Graphics(
                                     GraphBox, ROI(q).Boundary.Left, ROI(q).Boundary.Top - 25,
                                      "[" & (q + 1).ToString.Trim & "] " &
                                      Get_ChemicalInfoStr(q, False, " "),
                                     _DrawingFont, Color.Yellow, Color.Black)
                End If

            Next


            Canvas.Image = CType(bm.Clone, Bitmap)
        End Using
    End Sub


    Private Sub Canvas_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If Frm_RegionExtract.Visible Then
            Cursor.Hide()
            Threading.Thread.Sleep(500)
            Frm_RegionExtract.Find_ColorCodeInTable(Hex(
                 MyImgProcessing.Get_PixelColor_From1PixelInScreen(
                                MyImgProcessing.GetX, MyImgProcessing.GetY)))
            Cursor.Show()
        End If
    End Sub

    Private Sub Cmd_ShowLabels_Click(sender As Object, e As EventArgs) Handles Cmd_ShowLabels.Click
        If Cmd_ShowLabels.Text = "Show labels" Then
            Cmd_ShowLabels.Text = "Hide labels"
        Else
            Cmd_ShowLabels.Text = "Show labels"
        End If
    End Sub
End Class
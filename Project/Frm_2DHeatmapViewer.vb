Public Class Frm_HeatMap_General

    Dim myGraphLib As New GraphLib
    Dim myTextLib As New TextLibCompact
    Dim myFileSys As New FileSystemEngine




    Dim RectF As RectangleF
    Dim Rect As Rectangle
    Dim _myColor As New Color
    Dim _ShadowBrush As New SolidBrush(_myColor)
    Dim _BorderPen As New Pen(Color.DarkGray)

    Dim MyFont As New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel)
    Dim MyFont2 As Font = New Font("Arial", 24, FontStyle.Regular, GraphicsUnit.Pixel)
    Dim MyFont2Size As Size

    Dim PictureBox_Width As Integer = 500
    Dim PictureBox_Height As Integer = 500
    Dim TotalSteps As Integer
    Dim _InternalCells_XCount As Integer, _InternalCells_YCount As Integer


    Public Array_2DHeatmap(,) As String


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


    Private Sub Frm_HeatMapCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myGraphLib.Load_ColorGradient_File(My.Application.Info.DirectoryPath _
                                                & PathDelimit & "Essential color gradient.vgc")
        Combo_ColorSpectrum.SelectedIndex = 2

    End Sub

    Public Sub Cmd_Draw_Click(sender As Object, e As EventArgs) Handles Cmd_Draw.Click
        If myFileSys.FileExists(Text_Filename.Text) = False Then
            MsgBox("File not found", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Array_2DHeatmap = Load_2DHeatmapFile(Text_Filename.Text)
        If Array_2DHeatmap Is Nothing Then
            MsgBox("Something is wrong in the file", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Draw2DHeatmap(Array_2DHeatmap)
    End Sub



    Public Sub Draw2DHeatmap(Src2DArray(,) As String)
        If Check_AutoValueRange.Checked Then
            SetAutoValueRange(Src2DArray)
        End If

        Dim LabelWidth As Integer = 200
        Dim MarginWidthHeight As Integer = 25
        Dim ValueMin As Single = CSng(Text_ValueMin.Text)
        Dim ValueMax As Single = CSng(Text_ValueMax.Text)
        Dim bmWidth As Integer = CInt(Text_WellImageWidth.Text)
        Dim bmHeight As Integer = CInt(Text_WellImageHeight.Text)
        Dim RowCount, ColCount As Integer
        Dim CellWidth, CellHeight As Double
        Dim x, y As Integer

        If ValueMin = ValueMax Then
            MsgBox("Min and Max are identical!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        RowCount = Src2DArray.GetUpperBound(1)
        ColCount = Src2DArray.GetUpperBound(0)


        MyFont2Size = TextRenderer.MeasureText("W", MyFont2)
        CellWidth = (bmWidth - LabelWidth - MarginWidthHeight * 2) / (ColCount - 1)
        CellHeight = (bmHeight - MarginWidthHeight * 2 - MyFont2Size.Height * 2) / (RowCount - 1)

        Using bm As New Bitmap(bmWidth, bmHeight),
                        GraphBox As Graphics = Graphics.FromImage(bm)

            GraphBox.Clear(Color.White)

            Dim ColorIndex As Integer
            Dim ColorSpectrumIndex As Integer = Combo_ColorSpectrum.SelectedIndex + 1



            For y = 1 To RowCount
                For x = 1 To ColCount
                    If y = 1 Then
                        Continue For
                    Else
                        If x = 1 Then
                            Continue For
                        End If
                    End If


                    If Src2DArray(x, y) = "" Then
                        _ShadowBrush.Color = Color.White
                    Else
                        ColorIndex = CInt((CSng(Src2DArray(x, y)) - ValueMin) /
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
                    End If


                    GraphBox.FillRectangle(_ShadowBrush, New Rectangle(
                                       CInt(LabelWidth + (x - 2) * CellWidth) + MarginWidthHeight,
                                       CInt(MyFont2Size.Height * 2 + (y - 2) * CellHeight + MarginWidthHeight),
                                       CInt(CellWidth + 1),
                                       CInt(CellHeight + 1)))
                Next
            Next


            If Check_ShowLabels.Checked Then
                For y = 1 To RowCount
                    For x = 1 To ColCount


                        If y = 1 Then
                            MyFont2Size = TextRenderer.MeasureText(Src2DArray(x, y), MyFont2)
                            MyImgProcessing.Draw_Text_Outlined_Graphics(GraphBox,
                                                CInt(LabelWidth + (x - 2) * CellWidth + MarginWidthHeight + (CellWidth / 2) - MyFont2Size.Width / 2),
                                                CInt(MyFont2Size.Height / 2) + MarginWidthHeight,
                                                Src2DArray(x, y),
                                                MyFont2, Color.Black, Color.White)
                            Continue For
                        Else
                            If x = 1 Then
                                MyFont2Size = TextRenderer.MeasureText(Src2DArray(x, y), MyFont2)
                                If CellHeight > MyFont2Size.Height Then
                                    MyImgProcessing.Draw_Text_Outlined_Graphics(GraphBox,
                                                MarginWidthHeight,
                                                CInt(MyFont2Size.Height * 2 + (y - 2) * CellHeight +
                                                (CellHeight - MyFont2Size.Height) / 2) + MarginWidthHeight,
                                                Src2DArray(x, y),
                                                MyFont2, Color.Black, Color.White)
                                Else
                                    MyImgProcessing.Draw_Text_Outlined_Graphics(GraphBox,
                                               MarginWidthHeight,
                                               CInt(MyFont2Size.Height * 2 + (y - 2) * CellHeight) + MarginWidthHeight,
                                               Src2DArray(x, y),
                                               MyFont2, Color.Black, Color.White)
                                End If
                                Continue For
                            End If
                        End If
                    Next
                Next
            End If


            Picture_Graph.Image = CType(bm.Clone, Image)
        End Using


        If False Then
            Picture_Graph.Image.Save(
                      myFileSys.Get_FullFilenameWithoutExtension_From_FullFileName(
                     Text_Filename.Text) & "- Heatmap.png")
        End If


        Me.BringToFront()
    End Sub


    Public Sub SetAutoValueRange(SrcNumArray(,) As String)
        Dim ColMaxIndex As Integer = SrcNumArray.GetUpperBound(0)
        Dim RowMaxIndex As Integer = SrcNumArray.GetUpperBound(1)
        Dim MinValue As Double = 100000000
        Dim MaxValue As Double = -100000000
        Dim CurValue As Double
        For y As Integer = 2 To RowMaxIndex
            For x As Integer = 2 To ColMaxIndex
                If SrcNumArray(x, y) = "" Then
                Else
                    CurValue = CDbl(SrcNumArray(x, y))
                    If MaxValue < CurValue Then
                        MaxValue = CurValue
                    End If
                    If MinValue > CurValue Then
                        MinValue = CurValue
                    End If
                End If
            Next
        Next

        Text_ValueMin.Text = CInt(MinValue).ToString
        Text_ValueMax.Text = CInt(MaxValue).ToString

    End Sub


    Private Sub Cmd_Copy_Click(sender As Object, e As EventArgs) Handles Cmd_Copy.Click
        Clipboard.SetImage(Picture_Graph.Image)
        MsgBox("Image copied to clipboard")
    End Sub

    Private Sub Cmd_Open_Click(sender As Object, e As EventArgs) Handles Cmd_Open.Click

        With OpenFileDialog
            .FileName = ""

            .Title = "Open text file"
            .CheckFileExists = True
            .CheckPathExists = True
            .ShowReadOnly = False
            .Filter = "Text file|*.csv|Text file|*.txt"
            .FilterIndex = 1

            If .ShowDialog = DialogResult.OK Then
                Text_Filename.Text = .FileName
            End If
        End With
    End Sub


    Sub UpdateGradientBar()
        Using bm As New Bitmap(50, 100),
                        GraphBox As Graphics = Graphics.FromImage(bm)

            Dim ColorSpectrumIndex As Integer = Combo_ColorSpectrum.SelectedIndex + 1

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
            Pic_Gradientbar.Image = CType(bm.Clone, Image)
        End Using
    End Sub

    Private Sub Combo_ColorSpectrum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_ColorSpectrum.SelectedIndexChanged
        UpdateGradientBar()
    End Sub



    Private Sub Cmd_CopyGradientBar_Click(sender As Object, e As EventArgs) Handles Cmd_CopyGradientBar.Click
        Clipboard.SetImage(Pic_Gradientbar.Image)
        MsgBox("Gradient bar image copied to clipboard")
    End Sub


    'return nothing, if errors
    Public Function Load_2DHeatmapFile(FullFilename As String,
                                       Optional delimitStr As String = ",") As String(,)

        Dim NumStrArray(,) As String
        NumStrArray = myTextLib.Get_String2DAarry_From_TextFile(FullFilename, delimitStr, False)
        If NumStrArray Is Nothing Then
            Return Nothing
        Else
            Return NumStrArray
        End If
    End Function

    Private Sub Cmd_Clipboard_Draw_Click(sender As Object, e As EventArgs) Handles Cmd_Clipboard_Draw.Click
        Array_2DHeatmap = Load_2DHeatmapFromText(Text_Data.Text)
        If Array_2DHeatmap Is Nothing Then
            MsgBox("Content is empty or insufficient", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Draw2DHeatmap(Array_2DHeatmap)
    End Sub

    Private Sub Cmd_Paste_Click(sender As Object, e As EventArgs) Handles Cmd_Paste.Click
        Try
            Text_Data.Text = Clipboard.GetText
        Catch
            MsgBox("Clipboard is empty or has an error", MsgBoxStyle.OkOnly, "Paste")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Check_AutoValueRange_CheckedChanged(sender As Object, e As EventArgs) Handles Check_AutoValueRange.CheckedChanged
        Text_ValueMin.Enabled = Not (Check_AutoValueRange.Checked)
        Text_ValueMax.Enabled = Not (Check_AutoValueRange.Checked)
    End Sub


    'return nothing, if errors
    Public Function Load_2DHeatmapFromText(LongStr As String,
                                           Optional delimitStr As String = vbTab) As String(,)

        Dim NumStrArray(,) As String
        NumStrArray = myTextLib.Get_String2DAarry_From_LongString(LongStr, delimitStr, False)

        If NumStrArray Is Nothing Then
            Return Nothing
        End If

        If NumStrArray.GetUpperBound(0) < 3 OrElse
           NumStrArray.GetUpperBound(1) < 3 Then
            Return Nothing
        End If


        Return NumStrArray
    End Function
End Class
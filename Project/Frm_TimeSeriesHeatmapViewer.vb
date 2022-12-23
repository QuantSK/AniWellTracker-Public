Public Class Frm_TimeSeriesHeatmapViewer

    Dim myGraphLib As New GraphLib
    Dim myTextLib As New TextLibCompact
    Dim myFileSys As New FileSystemEngine


    Dim _myColor As New Color
    Dim _ShadowBrush As New SolidBrush(_myColor)

    Dim MyFont As New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel)

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

        Combo_TimeUnit.SelectedIndex = 1
        Combo_ColorSpectrum.SelectedIndex = 5

    End Sub

    Private Function GetExcelColumnName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function

    Public Sub SetAutoValueRange(SrcNumArray(,) As String)
        Dim ColMaxIndex As Integer = SrcNumArray.GetUpperBound(0)
        Dim RowMaxIndex As Integer = SrcNumArray.GetUpperBound(1)
        Dim MinValue As Double = 100000000
        Dim MaxValue As Double = -100000000
        Dim CurValue As Double
        For y As Integer = 2 To RowMaxIndex
            For x As Integer = 5 To ColMaxIndex
                If SrcNumArray(x, y) = "" Or SrcNumArray(x, y) = "Ambiguous" Then
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


    Public Sub Cmd_Draw_Click(sender As Object, e As EventArgs) Handles Cmd_Draw.Click
        If myFileSys.FileExists(Text_Filename.Text) = False Then
            MsgBox("File not found", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If



        Dim NumStrArray(,) As String
        Try
            NumStrArray = myTextLib.Get_String2DAarry_From_TextFile(
                                     Text_Filename.Text, ",", False)
        Catch ee As Exception
            MsgBox(ee, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try


        If Check_AutoValueRange.Checked Then
            SetAutoValueRange(NumStrArray)
        End If


        Dim IsFillWhiteBlank As Boolean = Check_FillWhiteBlank.Checked
        Dim ActivityMin As Integer = CInt(Text_ValueMin.Text)
        Dim ActivityMax As Integer = CInt(Text_ValueMax.Text)
        Dim ColMaxIndex As Integer = NumStrArray.GetUpperBound(0)
            Dim RowMaxIndex As Integer = NumStrArray.GetUpperBound(1)
            Dim bmWidth As Integer = CInt(Text_WellImageWidth.Text)
            Dim bmHeight_SingleWell As Integer = CInt(Text_WellImageHeight.Text)
            Dim bmHeight As Integer = (ColMaxIndex - 4) * bmHeight_SingleWell + 1
            If ActivityMin = ActivityMax Then
                MsgBox("Min and Max are identical!", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            Using bm As New Bitmap(bmWidth, bmHeight),
                        GraphBox As Graphics = Graphics.FromImage(bm)
                Dim CurTimeInMS As Long
                Dim TimeMinInMS As Long
                Dim TimeMaxInMS As Long
                Dim CurXPosition As Integer
                Dim PastXPosition As Integer
                Dim ColorIndex As Integer
                Dim PastColor(ColMaxIndex) As Color
                Dim ColorSpectrumIndex As Integer = Combo_ColorSpectrum.SelectedIndex + 1

                Select Case Combo_TimeUnit.Text
                    Case "Min"
                        TimeMinInMS = CLng(Text_TimeMin.Text) * 1000 * 60
                        TimeMaxInMS = CLng(Text_TimeMax.Text) * 1000 * 60
                    Case "Hour"
                        TimeMinInMS = CLng(Text_TimeMin.Text) * 1000 * 60 * 60
                        TimeMaxInMS = CLng(Text_TimeMax.Text) * 1000 * 60 * 60
                    Case "Day"
                        TimeMinInMS = CLng(Text_TimeMin.Text) * 1000 * 60 * 60 * 24
                        TimeMaxInMS = CLng(Text_TimeMax.Text) * 1000 * 60 * 60 * 24
                    Case Else
                End Select

                If TimeMinInMS = TimeMaxInMS Then
                    MsgBox("Time range is wrong!", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If

                Dim LabelWidth As Integer = 125


            GraphBox.Clear(Color.White)
            PastXPosition = -1

            For y As Integer = 2 To RowMaxIndex

                CurTimeInMS = CLng(NumStrArray(3, y))
                If CurTimeInMS >= TimeMinInMS AndAlso CurTimeInMS <= TimeMaxInMS Then
                    CurXPosition = CInt((bmWidth - LabelWidth) * (CurTimeInMS - TimeMinInMS) / (TimeMaxInMS - TimeMinInMS) + LabelWidth)


                    For x As Integer = 5 To ColMaxIndex
                        If PastXPosition = -1 Then
                            PastXPosition = LabelWidth
                        End If

                        If NumStrArray(x, y) = "" Or NumStrArray(x, y) = "Ambiguous" Then
                            _ShadowBrush.Color = Color.White
                        Else
                            ColorIndex = CInt((CDbl(NumStrArray(x, y)) - ActivityMin) / (ActivityMax - ActivityMin) * 100)

                            ColorIndex = Math.Max(ColorIndex, 0)
                            ColorIndex = Math.Min(ColorIndex, 255)

                            Select Case ColorSpectrumIndex
                                Case 1, 2
                                    _ShadowBrush.Color = myGraphLib.Get_IndexedBrushColor(ColorSpectrumIndex, ColorIndex)
                                Case 3
                                    _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_BR(ColorIndex)
                                Case 4
                                    _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_BW(ColorIndex)
                                Case 5
                                    _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_BY(ColorIndex)
                                Case 6
                                    _ShadowBrush.Color = myGraphLib.Get_GradientBrushColor_Matlab(ColorIndex)
                                Case Else
                            End Select
                        End If


                        PastColor(x) = _ShadowBrush.Color

                        If IsFillWhiteBlank = False Then
                            _ShadowBrush.Color = PastColor(x)
                            GraphBox.FillRectangle(_ShadowBrush, New Rectangle(
                                     PastXPosition, (x - 5) * bmHeight_SingleWell,
                                     CurXPosition - PastXPosition, bmHeight_SingleWell))
                        End If


                        GraphBox.DrawLine(New Pen(_ShadowBrush.Color),
                                      New Point(CurXPosition, (x - 5) * bmHeight_SingleWell),
                                      New Point(CurXPosition, (x - 4) * bmHeight_SingleWell))


                    Next

                    PastXPosition = CurXPosition
                End If
            Next

            'Print well#
            For x As Integer = 5 To ColMaxIndex
                    If Check_ShowLabels.Checked Then

                        MyImgProcessing.Draw_Text_Outlined_Graphics(GraphBox,
                                1,
                                CInt((x - 5) * bmHeight_SingleWell +
                                        bmHeight_SingleWell / 2 - MyFont.Size),
                                "[" + GetExcelColumnName(x) + "] " + NumStrArray(x, 1).Replace("|", " "),
                                MyFont,
                                Color.Black, Color.White)

                    End If
                    GraphBox.DrawRectangle(Pens.Black,
                                         New Rectangle(New Point(LabelWidth, (x - 5) * bmHeight_SingleWell),
                                         New Size(bmWidth - LabelWidth - 1, bmHeight_SingleWell)))
                Next

            Picture_Graph.Image = CType(bm.Clone, Image)
            End Using



            If False Then
                Picture_Graph.Image.Save(
            myFileSys.Get_FullFilenameWithoutExtension_From_FullFileName(
            Text_Filename.Text) & "- Heatmap.png")
            End If
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
            .Filter = "Comma delimited file|*.csv"
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

    Private Sub Check_ShowNumberID_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Check_AutoValueRange_CheckedChanged(sender As Object, e As EventArgs) Handles Check_AutoValueRange.CheckedChanged
        Text_ValueMin.Enabled = Not (Check_AutoValueRange.Checked)
        Text_ValueMax.Enabled = Not (Check_AutoValueRange.Checked)
    End Sub
End Class
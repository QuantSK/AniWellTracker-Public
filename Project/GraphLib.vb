Public Class GraphLib


    Private Structure TYPE_ColorArrayFormat
        Dim R As Integer
        Dim G As Integer
        Dim B As Integer
    End Structure


    Dim ColorArray(3, 100) As TYPE_ColorArrayFormat


    Public Sub Load_ColorGradient_File(ByVal FileName As String)

        Dim Delimiters() As Char = New Char() {CChar(vbTab), ","c}
        Dim SplittedStrArray As String()

        Dim q As Integer
        Dim Buf_Str As String
        Dim FileNumber As Integer = FreeFile()


        FileOpen(FileNumber, FileName, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)


        For q = 1 To 100
            Buf_Str = LineInput(FileNumber)

            'Split letter
            SplittedStrArray = Buf_Str.Split(Delimiters)

            'Check number of columns
            If SplittedStrArray.Length <> 7 Then
                FileClose(FileNumber)

                MsgBox("Incorrect color gradient file" & vbCrLf & vbCrLf _
                       & "Please check 'Essential color gradient.vgc'", MsgBoxStyle.Critical, "Open color gradient file")

                Exit Sub
            End If

            ColorArray(1, q).R = CInt(SplittedStrArray(1).Trim)      'Energy
            ColorArray(1, q).G = CInt(SplittedStrArray(2).Trim)      'Energy
            ColorArray(1, q).B = CInt(SplittedStrArray(3).Trim)      'Energy
            ColorArray(2, q).R = CInt(SplittedStrArray(4).Trim)      'Probability
            ColorArray(2, q).G = CInt(SplittedStrArray(5).Trim)      'Probability
            ColorArray(2, q).B = CInt(SplittedStrArray(6).Trim)      'Probability
        Next

        FileClose(FileNumber)
    End Sub


    Public Function Get_IndexedBrushColor(ByVal Source_ColorIndex As Integer, ByVal ColorValueIndex As Integer) As Color
        If ColorValueIndex < 1 Then ColorValueIndex = 1
        If ColorValueIndex > 100 Then ColorValueIndex = 100

        Return Color.FromArgb(255 _
                    , ColorArray(Source_ColorIndex, ColorValueIndex).R _
                    , ColorArray(Source_ColorIndex, ColorValueIndex).G _
                    , ColorArray(Source_ColorIndex, ColorValueIndex).B)
    End Function

    Public Function Get_GradientBrushColor_BR(ByVal ColorValueIndex As Integer) As Color
        If ColorValueIndex < 1 Then ColorValueIndex = 1
        If ColorValueIndex > 100 Then ColorValueIndex = 100

        Return Color.FromArgb(255 _
                    , CInt(ColorValueIndex / 100 * 255) _
                    , 0 _
                    , CInt(255 - Int(ColorValueIndex / 100 * 255)))
    End Function


    Public Function Get_GradientBrushColor_BY(ByVal ColorValueIndex As Integer) As Color
        If ColorValueIndex < 1 Then ColorValueIndex = 1
        If ColorValueIndex > 100 Then ColorValueIndex = 100

        Return Color.FromArgb(255,
                              CInt(ColorValueIndex / 100 * 255),
                              CInt(ColorValueIndex / 100 * 255),
                              255 - CInt(ColorValueIndex / 100 * 255))
    End Function


    Public Function Get_GradientBrushColor_BW(ByVal ColorValueIndex As Integer) As Color
        If ColorValueIndex < 1 Then ColorValueIndex = 1
        If ColorValueIndex > 100 Then ColorValueIndex = 100

        Return Color.FromArgb(255,
                              CInt(Int(ColorValueIndex / 100 * 255)),
                              CInt(ColorValueIndex / 100 * 255),
                              CInt(ColorValueIndex / 100 * 255))
    End Function


    Public Function Get_GradientBrushColor_Matlab(ByVal ColorValueIndex As Integer) As Color
        If ColorValueIndex < 1 Then ColorValueIndex = 1
        If ColorValueIndex > 100 Then ColorValueIndex = 100


        Dim ColorValueSng As Single = CSng(ColorValueIndex / 100)
        Dim Cr, Cg, Cb As Single

        If 0 <= ColorValueSng And ColorValueSng <= 1 / 8 Then
            Cr = 0
            Cg = 0
            Cb = CSng((4 * ColorValueSng) + 0.5)
        ElseIf (1 / 8 < ColorValueSng And ColorValueSng <= 3 / 8) Then
            Cr = 0
            Cg = CSng(4 * ColorValueSng - 0.5)
            Cb = 1
        ElseIf (3 / 8 < ColorValueSng And ColorValueSng <= 5 / 8) Then
            Cr = CSng(4 * ColorValueSng - 1.5)
            Cg = 1
            Cb = CSng(-4 * ColorValueSng + 2.5)
        ElseIf (5 / 8 < ColorValueSng And ColorValueSng <= 7 / 8) Then
            Cr = 1
            Cg = CSng(-4 * ColorValueSng + 3.5)
            Cb = 0
        ElseIf (7 / 8 < ColorValueSng And ColorValueSng <= 1) Then
            Cr = CSng(-4 * ColorValueSng + 4.5)
            Cg = 0
            Cb = 0
        Else
            Cr = 0.5
            Cg = 0
            Cb = 0
        End If

        Return Color.FromArgb(255, CInt(Cr * 255), CInt(Cg * 255), CInt(Cb * 255))
    End Function

End Class

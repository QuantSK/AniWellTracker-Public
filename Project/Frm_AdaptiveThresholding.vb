Public Class Frm_AdaptiveThresholding

    Dim _IsFormLoading As Boolean = True

    Public ProcessingBoxSize As Integer = 35
    Public IsObjectBlack As Boolean = True
    Public ThresholdLevel As Integer = 92


    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True

        MDImain.Enabled = True
        MDImain.BringToFront()
        Me.Hide()
    End Sub


    Private Sub Cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OK.Click
        ProcessingBoxSize = CInt(Text_BoxSize.Text)
        IsObjectBlack = Radio_ObjectBlack.Checked
        ThresholdLevel = CInt(Text_ThresholdLevel.Text)

        MDIMain.Enabled = True
        MDIMain.BringToFront()
        Me.Hide()

        Frm_Tracker.Cmd_TestBinarization_Click(Nothing, Nothing)
    End Sub

    Private Sub Text_BoxSize_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Text_BoxSize.KeyUp
        If _IsFormLoading Then Exit Sub
        Text_BoxSize.Text = Track_BoxSize.Value.ToString
    End Sub

    Private Sub Text_BoxSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_BoxSize.TextChanged
        If _IsFormLoading Then Exit Sub

        Dim CurrentValue As Integer

        Try
            CurrentValue = CInt(Val(Text_BoxSize.Text))

            If CurrentValue >= Track_BoxSize.Minimum AndAlso
            CurrentValue <= Track_BoxSize.Maximum Then
                Track_BoxSize.Value = CurrentValue
            End If


        Catch
            Exit Sub
        End Try
    End Sub

    Private Sub Track_BoxSize_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Track_BoxSize.Scroll
        If _IsFormLoading Then Exit Sub
        Text_BoxSize.Text = Track_BoxSize.Value.ToString
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        MDImain.Enabled = True
        MDImain.BringToFront()
        Me.Hide()
    End Sub

    Private Sub Text_ThresholdLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_ThresholdLevel.TextChanged
        If _IsFormLoading Then Exit Sub

        Dim CurrentValue As Integer

        Try
            CurrentValue = CInt(Val(Text_ThresholdLevel.Text))

            If CurrentValue >= Track_ThresholdLevel.Minimum AndAlso
                CurrentValue <= Track_ThresholdLevel.Maximum Then
                Track_ThresholdLevel.Value = CurrentValue
            End If
        Catch
            Exit Sub
        End Try
    End Sub

    Private Sub Track_ThresholdLevel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Track_ThresholdLevel.KeyUp
        If _IsFormLoading Then Exit Sub
        Text_ThresholdLevel.Text = Track_ThresholdLevel.Value.ToString
    End Sub

    Private Sub Track_ThresholdLevel_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Track_ThresholdLevel.Scroll
        If _IsFormLoading Then Exit Sub
        Text_ThresholdLevel.Text = Track_ThresholdLevel.Value.ToString
    End Sub

    Private Sub Check_Automatic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_Automatic.CheckedChanged
        If Check_Automatic.Checked Then
            Radio_ObjectBlack.Enabled = False
            Radio_ObjectWhite.Enabled = False
        Else
            Radio_ObjectBlack.Enabled = True
            Radio_ObjectWhite.Enabled = True
        End If
    End Sub

    Private Sub Frm_AdaptiveThresholding_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If _IsFormLoading Then Exit Sub

        If Me.Visible Then
            Text_BoxSize.Text = ProcessingBoxSize.ToString.Trim
            Track_BoxSize.Value = ProcessingBoxSize
            Radio_ObjectBlack.Checked = IsObjectBlack
            Text_ThresholdLevel.Text = ThresholdLevel.ToString.Trim
            Track_ThresholdLevel.Value = ThresholdLevel

            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Frm_AdaptiveThresholding_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _IsFormLoading = False
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Frm_AdaptiveThresholding_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
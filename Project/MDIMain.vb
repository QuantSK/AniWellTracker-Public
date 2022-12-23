Imports System.ComponentModel

Public Class MDIMain



    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub
    'Dim myNetGraphics As ne


    Private Sub MDImain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Threading.Thread.CurrentThread.CurrentCulture =
                        New Globalization.CultureInfo("en-US", True)

        'My.Settings.Reload()



        With Frm_Tracker
            .Left = 0
            .Top = 0
            .Show()
        End With

#If DEBUG Then
        Frm_Reviewer.Text_SourceFolder.Text = "D:\AniWellTracker images\20201118_15일 치어 original & 레진 플레이트 테스트 - 논문"
        Frm_Tracker.Text_SourceFolder.Text = Frm_Reviewer.Text_SourceFolder.Text
#Else
        Frm_Tracker.Text_SourceFolder.Text = ""
#End If
        Frm_Reviewer.Text_SourceFolder.Text = Frm_Tracker.Text_SourceFolder.Text


        With Frm_Canvas
            .Left = Frm_Tracker.Left + Frm_Tracker.Width
            .Top = 0
            .Show()
        End With

        With Frm_FileManager
            .Left = 0
            .Top = Frm_Tracker.Top + Frm_Tracker.Height
            .Width = Frm_Tracker.Width
            .Show()
            .Cmd_Rescan_Click(Nothing, Nothing)
        End With

    End Sub

    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        Dim ww As System.EventArgs = Nothing

        'My.Settings.Save()

        Application.Exit()
    End Sub




    Private Sub Menu_TimeSeriesHeatmap_Click(sender As Object, e As EventArgs) Handles Menu_TimeSeriesHeatmap.Click
        With Frm_TimeSeriesHeatmapViewer
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub MDIMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Application.Exit()
    End Sub

    Private Sub Menu_Processing_Click(sender As Object, e As EventArgs) Handles Menu_Window.Click

    End Sub

    Private Sub Menu_Copy_Click(sender As Object, e As EventArgs) Handles Menu_Copy.Click
        Frm_Canvas.Copy()
    End Sub


    Private Sub MDIMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadWithoutShow(Frm_AdaptiveThresholding)
        LoadWithoutShow(Frm_RegionExtract)
    End Sub



    Private Sub Cmd_ReviewMode_Click(sender As Object, e As EventArgs) Handles Cmd_ReviewMode.Click
        Menu_ReviewMode_Click(Nothing, Nothing)
    End Sub

    Private Sub Cmd_TrackingMode_Click(sender As Object, e As EventArgs) Handles Cmd_TrackingMode.Click
        Menu_TrackingMode_Click(Nothing, Nothing)
    End Sub

    Private Sub Menu_TrackingMode_Click(sender As Object, e As EventArgs) Handles Menu_TrackingMode.Click
        Frm_Tracker.Show()
    End Sub

    Private Sub Menu_ReviewMode_Click(sender As Object, e As EventArgs) Handles Menu_ReviewMode.Click
        Frm_Reviewer.Show()
    End Sub

    Private Sub Cmd_TimeSeriesHeatmap_Click(sender As Object, e As EventArgs) Handles Cmd_TimeSeriesHeatmap.Click
        Menu_TimeSeriesHeatmap_Click(Nothing, Nothing)
    End Sub

    Private Sub Menu_About_Click(sender As Object, e As EventArgs) Handles Menu_About.Click
        Frm_About.Show()
    End Sub

    Private Sub Menu_2DHeatmap_Click(sender As Object, e As EventArgs) Handles Menu_2DHeatmap.Click
        With Frm_HeatMap_General
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub Cmd_2DHeatmap_Click(sender As Object, e As EventArgs) Handles Cmd_2DHeatmap.Click
        Menu_2DHeatmap_Click(Nothing, Nothing)
    End Sub

    Private Sub Menu_Canvas_Click(sender As Object, e As EventArgs) Handles Menu_Canvas.Click
        Frm_Canvas.Show()
    End Sub
End Class

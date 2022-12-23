<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMain))
        Me.StatusStrip_Status = New System.Windows.Forms.StatusStrip()
        Me.Status_Info = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status_Progressbar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Status_Info2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status_Info3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status_XY = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.Menu_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Window = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_TrackingMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ReviewMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Canvas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_TimeSeriesHeatmap = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_2DHeatmap = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip_Menu = New System.Windows.Forms.ToolStrip()
        Me.Cmd_TrackingMode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_ReviewMode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_TimeSeriesHeatmap = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_2DHeatmap = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip_Status.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip_Status
        '
        Me.StatusStrip_Status.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.StatusStrip_Status.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status_Info, Me.Status_Progressbar, Me.Status_Info2, Me.Status_Info3, Me.Status_XY})
        Me.StatusStrip_Status.Location = New System.Drawing.Point(0, 525)
        Me.StatusStrip_Status.Name = "StatusStrip_Status"
        Me.StatusStrip_Status.Size = New System.Drawing.Size(1050, 39)
        Me.StatusStrip_Status.TabIndex = 4
        Me.StatusStrip_Status.Text = "StatusStrip1"
        '
        'Status_Info
        '
        Me.Status_Info.AutoSize = False
        Me.Status_Info.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Status_Info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Status_Info.Name = "Status_Info"
        Me.Status_Info.Size = New System.Drawing.Size(300, 33)
        Me.Status_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Status_Progressbar
        '
        Me.Status_Progressbar.AutoSize = False
        Me.Status_Progressbar.Name = "Status_Progressbar"
        Me.Status_Progressbar.Size = New System.Drawing.Size(200, 31)
        '
        'Status_Info2
        '
        Me.Status_Info2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Status_Info2.Name = "Status_Info2"
        Me.Status_Info2.Size = New System.Drawing.Size(4, 33)
        '
        'Status_Info3
        '
        Me.Status_Info3.AutoSize = False
        Me.Status_Info3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Status_Info3.Name = "Status_Info3"
        Me.Status_Info3.Size = New System.Drawing.Size(200, 33)
        '
        'Status_XY
        '
        Me.Status_XY.AutoSize = False
        Me.Status_XY.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Status_XY.Name = "Status_XY"
        Me.Status_XY.Size = New System.Drawing.Size(130, 33)
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File, Me.Menu_Edit, Me.Menu_Window, Me.Menu_About})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1050, 25)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'Menu_File
        '
        Me.Menu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Exit})
        Me.Menu_File.Name = "Menu_File"
        Me.Menu_File.ShortcutKeyDisplayString = ""
        Me.Menu_File.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.Menu_File.Size = New System.Drawing.Size(45, 21)
        Me.Menu_File.Text = "&File"
        '
        'Menu_Exit
        '
        Me.Menu_Exit.Image = CType(resources.GetObject("Menu_Exit.Image"), System.Drawing.Image)
        Me.Menu_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(114, 26)
        Me.Menu_Exit.Text = "E&xit"
        '
        'Menu_Edit
        '
        Me.Menu_Edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Copy})
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.Menu_Edit.Size = New System.Drawing.Size(47, 21)
        Me.Menu_Edit.Text = "&Edit"
        '
        'Menu_Copy
        '
        Me.Menu_Copy.Image = CType(resources.GetObject("Menu_Copy.Image"), System.Drawing.Image)
        Me.Menu_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Menu_Copy.Name = "Menu_Copy"
        Me.Menu_Copy.Size = New System.Drawing.Size(124, 26)
        Me.Menu_Copy.Text = "&Copy"
        '
        'Menu_Window
        '
        Me.Menu_Window.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_TrackingMode, Me.Menu_ReviewMode, Me.ToolStripSeparator2, Me.Menu_Canvas, Me.Menu_TimeSeriesHeatmap, Me.Menu_2DHeatmap})
        Me.Menu_Window.Name = "Menu_Window"
        Me.Menu_Window.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.Menu_Window.Size = New System.Drawing.Size(75, 21)
        Me.Menu_Window.Text = "&Window"
        '
        'Menu_TrackingMode
        '
        Me.Menu_TrackingMode.Image = CType(resources.GetObject("Menu_TrackingMode.Image"), System.Drawing.Image)
        Me.Menu_TrackingMode.Name = "Menu_TrackingMode"
        Me.Menu_TrackingMode.Size = New System.Drawing.Size(232, 26)
        Me.Menu_TrackingMode.Text = "&Tracking mode"
        '
        'Menu_ReviewMode
        '
        Me.Menu_ReviewMode.Image = CType(resources.GetObject("Menu_ReviewMode.Image"), System.Drawing.Image)
        Me.Menu_ReviewMode.Name = "Menu_ReviewMode"
        Me.Menu_ReviewMode.Size = New System.Drawing.Size(232, 26)
        Me.Menu_ReviewMode.Text = "&Review mode"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(229, 6)
        '
        'Menu_Canvas
        '
        Me.Menu_Canvas.Image = CType(resources.GetObject("Menu_Canvas.Image"), System.Drawing.Image)
        Me.Menu_Canvas.Name = "Menu_Canvas"
        Me.Menu_Canvas.Size = New System.Drawing.Size(232, 26)
        Me.Menu_Canvas.Text = "Canvas"
        '
        'Menu_TimeSeriesHeatmap
        '
        Me.Menu_TimeSeriesHeatmap.Image = CType(resources.GetObject("Menu_TimeSeriesHeatmap.Image"), System.Drawing.Image)
        Me.Menu_TimeSeriesHeatmap.Name = "Menu_TimeSeriesHeatmap"
        Me.Menu_TimeSeriesHeatmap.Size = New System.Drawing.Size(232, 26)
        Me.Menu_TimeSeriesHeatmap.Text = "Time-&Series Heatmap"
        '
        'Menu_2DHeatmap
        '
        Me.Menu_2DHeatmap.Image = CType(resources.GetObject("Menu_2DHeatmap.Image"), System.Drawing.Image)
        Me.Menu_2DHeatmap.Name = "Menu_2DHeatmap"
        Me.Menu_2DHeatmap.Size = New System.Drawing.Size(232, 26)
        Me.Menu_2DHeatmap.Text = "2&D heatmap"
        '
        'Menu_About
        '
        Me.Menu_About.Name = "Menu_About"
        Me.Menu_About.Size = New System.Drawing.Size(59, 21)
        Me.Menu_About.Text = "About"
        '
        'ToolStrip_Menu
        '
        Me.ToolStrip_Menu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip_Menu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_TrackingMode, Me.ToolStripSeparator1, Me.Cmd_ReviewMode, Me.ToolStripSeparator3, Me.Cmd_TimeSeriesHeatmap, Me.ToolStripSeparator4, Me.Cmd_2DHeatmap})
        Me.ToolStrip_Menu.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip_Menu.Name = "ToolStrip_Menu"
        Me.ToolStrip_Menu.Size = New System.Drawing.Size(1050, 27)
        Me.ToolStrip_Menu.TabIndex = 6
        Me.ToolStrip_Menu.Text = "ToolStrip1"
        '
        'Cmd_TrackingMode
        '
        Me.Cmd_TrackingMode.Image = CType(resources.GetObject("Cmd_TrackingMode.Image"), System.Drawing.Image)
        Me.Cmd_TrackingMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_TrackingMode.Name = "Cmd_TrackingMode"
        Me.Cmd_TrackingMode.Size = New System.Drawing.Size(128, 24)
        Me.Cmd_TrackingMode.Text = "Tracking mode"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'Cmd_ReviewMode
        '
        Me.Cmd_ReviewMode.Image = CType(resources.GetObject("Cmd_ReviewMode.Image"), System.Drawing.Image)
        Me.Cmd_ReviewMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ReviewMode.Name = "Cmd_ReviewMode"
        Me.Cmd_ReviewMode.Size = New System.Drawing.Size(121, 24)
        Me.Cmd_ReviewMode.Text = "Review mode"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'Cmd_TimeSeriesHeatmap
        '
        Me.Cmd_TimeSeriesHeatmap.Image = CType(resources.GetObject("Cmd_TimeSeriesHeatmap.Image"), System.Drawing.Image)
        Me.Cmd_TimeSeriesHeatmap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_TimeSeriesHeatmap.Name = "Cmd_TimeSeriesHeatmap"
        Me.Cmd_TimeSeriesHeatmap.Size = New System.Drawing.Size(170, 24)
        Me.Cmd_TimeSeriesHeatmap.Text = "Time-series heatmap"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'Cmd_2DHeatmap
        '
        Me.Cmd_2DHeatmap.Image = CType(resources.GetObject("Cmd_2DHeatmap.Image"), System.Drawing.Image)
        Me.Cmd_2DHeatmap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_2DHeatmap.Name = "Cmd_2DHeatmap"
        Me.Cmd_2DHeatmap.Size = New System.Drawing.Size(112, 24)
        Me.Cmd_2DHeatmap.Text = "2D heatmap"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 564)
        Me.Controls.Add(Me.ToolStrip_Menu)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip_Status)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "MDIMain"
        Me.Text = "AniWellTracker 1.0 (12/19/2022)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip_Status.ResumeLayout(False)
        Me.StatusStrip_Status.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip_Menu.ResumeLayout(False)
        Me.ToolStrip_Menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip_Status As StatusStrip
    Friend WithEvents Status_Progressbar As ToolStripProgressBar
    Friend WithEvents Status_Info As ToolStripStatusLabel
    Friend WithEvents Menu_File As ToolStripMenuItem
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents Menu_Copy As ToolStripMenuItem
    Friend WithEvents Menu_Window As ToolStripMenuItem
    Friend WithEvents ToolStrip_Menu As ToolStrip
    Friend WithEvents Menu_TrackingMode As ToolStripMenuItem
    Friend WithEvents Status_Info2 As ToolStripStatusLabel
    Friend WithEvents Menu_TimeSeriesHeatmap As ToolStripMenuItem
    Friend WithEvents Status_Info3 As ToolStripStatusLabel
    Friend WithEvents Status_XY As ToolStripStatusLabel
    Friend WithEvents Cmd_TrackingMode As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Cmd_ReviewMode As ToolStripButton
    Friend WithEvents Menu_ReviewMode As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Cmd_TimeSeriesHeatmap As ToolStripButton
    Friend WithEvents Menu_About As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Menu_2DHeatmap As ToolStripMenuItem
    Friend WithEvents Cmd_2DHeatmap As ToolStripButton
    Friend WithEvents Menu_Canvas As ToolStripMenuItem
End Class

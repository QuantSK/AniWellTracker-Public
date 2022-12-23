﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Canvas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Canvas))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Cmd_SaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Copy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_Zoom100 = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_ZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_ZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Menu_ResetZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Stretchtofit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Fittoscreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_QuickAnim = New System.Windows.Forms.ToolStripMenuItem()
        Me.Combo_Anim1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Combo_Anim2 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Combo_AnimInterval = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_ShowRegions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cmd_ShowLabels = New System.Windows.Forms.ToolStripButton()
        Me.Timer_Animation = New System.Windows.Forms.Timer(Me.components)
        Me.Canvas = New Queens_ImageControl.ImageControl()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Arial", 9.5!)
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_SaveAs, Me.ToolStripSeparator2, Me.Cmd_Copy, Me.ToolStripSeparator1, Me.Cmd_Zoom100, Me.Cmd_ZoomIn, Me.Cmd_ZoomOut, Me.ToolStripDropDownButton1, Me.ToolStripSeparator3, Me.Cmd_QuickAnim, Me.Combo_Anim1, Me.ToolStripSeparator6, Me.Combo_Anim2, Me.ToolStripLabel1, Me.Combo_AnimInterval, Me.ToolStripSeparator5, Me.Cmd_ShowRegions, Me.ToolStripSeparator4, Me.Cmd_ShowLabels})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1049, 28)
        Me.ToolStrip.TabIndex = 19
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'Cmd_SaveAs
        '
        Me.Cmd_SaveAs.Image = CType(resources.GetObject("Cmd_SaveAs.Image"), System.Drawing.Image)
        Me.Cmd_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_SaveAs.Name = "Cmd_SaveAs"
        Me.Cmd_SaveAs.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.Cmd_SaveAs.Size = New System.Drawing.Size(34, 28)
        Me.Cmd_SaveAs.ToolTipText = "Save as"
        Me.Cmd_SaveAs.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        Me.ToolStripSeparator2.Visible = False
        '
        'Cmd_Copy
        '
        Me.Cmd_Copy.Image = CType(resources.GetObject("Cmd_Copy.Image"), System.Drawing.Image)
        Me.Cmd_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Copy.Name = "Cmd_Copy"
        Me.Cmd_Copy.Size = New System.Drawing.Size(29, 25)
        Me.Cmd_Copy.ToolTipText = "Copy"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'Cmd_Zoom100
        '
        Me.Cmd_Zoom100.Image = CType(resources.GetObject("Cmd_Zoom100.Image"), System.Drawing.Image)
        Me.Cmd_Zoom100.ImageTransparentColor = System.Drawing.Color.Black
        Me.Cmd_Zoom100.Name = "Cmd_Zoom100"
        Me.Cmd_Zoom100.Size = New System.Drawing.Size(29, 25)
        Me.Cmd_Zoom100.ToolTipText = "Zoom 100%"
        '
        'Cmd_ZoomIn
        '
        Me.Cmd_ZoomIn.Image = CType(resources.GetObject("Cmd_ZoomIn.Image"), System.Drawing.Image)
        Me.Cmd_ZoomIn.ImageTransparentColor = System.Drawing.Color.Black
        Me.Cmd_ZoomIn.Name = "Cmd_ZoomIn"
        Me.Cmd_ZoomIn.Size = New System.Drawing.Size(29, 25)
        Me.Cmd_ZoomIn.ToolTipText = "Zoom in"
        '
        'Cmd_ZoomOut
        '
        Me.Cmd_ZoomOut.Image = CType(resources.GetObject("Cmd_ZoomOut.Image"), System.Drawing.Image)
        Me.Cmd_ZoomOut.ImageTransparentColor = System.Drawing.Color.Black
        Me.Cmd_ZoomOut.Name = "Cmd_ZoomOut"
        Me.Cmd_ZoomOut.Size = New System.Drawing.Size(29, 25)
        Me.Cmd_ZoomOut.ToolTipText = "Zoom out"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_ResetZoom, Me.Menu_Stretchtofit, Me.Menu_Fittoscreen})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(34, 25)
        Me.ToolStripDropDownButton1.ToolTipText = "Zoom options"
        '
        'Menu_ResetZoom
        '
        Me.Menu_ResetZoom.Name = "Menu_ResetZoom"
        Me.Menu_ResetZoom.Size = New System.Drawing.Size(176, 26)
        Me.Menu_ResetZoom.Text = "Reset"
        '
        'Menu_Stretchtofit
        '
        Me.Menu_Stretchtofit.Name = "Menu_Stretchtofit"
        Me.Menu_Stretchtofit.Size = New System.Drawing.Size(176, 26)
        Me.Menu_Stretchtofit.Text = "Stretch to fit"
        '
        'Menu_Fittoscreen
        '
        Me.Menu_Fittoscreen.Name = "Menu_Fittoscreen"
        Me.Menu_Fittoscreen.Size = New System.Drawing.Size(176, 26)
        Me.Menu_Fittoscreen.Text = "Fit to screen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'Cmd_QuickAnim
        '
        Me.Cmd_QuickAnim.Image = CType(resources.GetObject("Cmd_QuickAnim.Image"), System.Drawing.Image)
        Me.Cmd_QuickAnim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_QuickAnim.Name = "Cmd_QuickAnim"
        Me.Cmd_QuickAnim.Size = New System.Drawing.Size(100, 28)
        Me.Cmd_QuickAnim.Text = "Animate"
        '
        'Combo_Anim1
        '
        Me.Combo_Anim1.AutoSize = False
        Me.Combo_Anim1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Anim1.DropDownWidth = 55
        Me.Combo_Anim1.Items.AddRange(New Object() {"Original", "Binarized", "Region extracted", "Region labeled"})
        Me.Combo_Anim1.Name = "Combo_Anim1"
        Me.Combo_Anim1.Size = New System.Drawing.Size(150, 28)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
        '
        'Combo_Anim2
        '
        Me.Combo_Anim2.AutoSize = False
        Me.Combo_Anim2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Anim2.DropDownWidth = 55
        Me.Combo_Anim2.Items.AddRange(New Object() {"Binarized", "Region extracted", "Region labeled", "Original overlayed"})
        Me.Combo_Anim2.Name = "Combo_Anim2"
        Me.Combo_Anim2.Size = New System.Drawing.Size(150, 28)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(56, 25)
        Me.ToolStripLabel1.Text = "Interval"
        '
        'Combo_AnimInterval
        '
        Me.Combo_AnimInterval.AutoSize = False
        Me.Combo_AnimInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_AnimInterval.DropDownWidth = 55
        Me.Combo_AnimInterval.Items.AddRange(New Object() {"100", "200", "300", "400", "500", "600", "700", "800", "1000", "1500", "2000"})
        Me.Combo_AnimInterval.Name = "Combo_AnimInterval"
        Me.Combo_AnimInterval.Size = New System.Drawing.Size(75, 28)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 28)
        '
        'Cmd_ShowRegions
        '
        Me.Cmd_ShowRegions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ShowRegions.Image = CType(resources.GetObject("Cmd_ShowRegions.Image"), System.Drawing.Image)
        Me.Cmd_ShowRegions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowRegions.Name = "Cmd_ShowRegions"
        Me.Cmd_ShowRegions.Size = New System.Drawing.Size(107, 25)
        Me.Cmd_ShowRegions.Text = "Show regions"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 28)
        '
        'Cmd_ShowLabels
        '
        Me.Cmd_ShowLabels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Cmd_ShowLabels.Image = CType(resources.GetObject("Cmd_ShowLabels.Image"), System.Drawing.Image)
        Me.Cmd_ShowLabels.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_ShowLabels.Name = "Cmd_ShowLabels"
        Me.Cmd_ShowLabels.Size = New System.Drawing.Size(96, 25)
        Me.Cmd_ShowLabels.Text = "Show labels"
        '
        'Timer_Animation
        '
        '
        'Canvas
        '
        Me.Canvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Canvas.Image = Nothing
        Me.Canvas.initialimage = Nothing
        Me.Canvas.Location = New System.Drawing.Point(0, 28)
        Me.Canvas.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Origin = New System.Drawing.Point(0, 0)
        Me.Canvas.PanButton = System.Windows.Forms.MouseButtons.Left
        Me.Canvas.PanMode = True
        Me.Canvas.ScrollbarsVisible = True
        Me.Canvas.Size = New System.Drawing.Size(1049, 774)
        Me.Canvas.StretchImageToFit = False
        Me.Canvas.TabIndex = 20
        Me.Canvas.ZoomFactor = 1.0R
        Me.Canvas.ZoomOnMouseWheel = True
        '
        'Frm_Canvas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 802)
        Me.Controls.Add(Me.Canvas)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Canvas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Canvas"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_SaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents Cmd_Zoom100 As Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ZoomIn As Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_ZoomOut As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Menu_ResetZoom As Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Stretchtofit As Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Fittoscreen As Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_QuickAnim As ToolStripMenuItem
    Friend WithEvents Combo_AnimInterval As ToolStripComboBox
    Friend WithEvents Timer_Animation As Timer
    Friend WithEvents Combo_Anim1 As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents Cmd_ShowRegions As ToolStripButton
    Friend WithEvents Combo_Anim2 As ToolStripComboBox
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Canvas As Queens_ImageControl.ImageControl
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Cmd_ShowLabels As ToolStripButton
End Class

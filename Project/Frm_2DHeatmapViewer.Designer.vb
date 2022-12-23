<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_HeatMap_General
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_HeatMap_General))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Text_WellImageHeight = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_WellImageWidth = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Text_ValueMax = New System.Windows.Forms.TextBox()
        Me.Text_ValueMin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Picture_Graph = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Cmd_Open = New System.Windows.Forms.Button()
        Me.Text_Filename = New System.Windows.Forms.TextBox()
        Me.Cmd_Draw = New System.Windows.Forms.Button()
        Me.Combo_ColorSpectrum = New System.Windows.Forms.ComboBox()
        Me.Cmd_Copy = New System.Windows.Forms.Button()
        Me.Cmd_CopyGradientBar = New System.Windows.Forms.Button()
        Me.Pic_Gradientbar = New System.Windows.Forms.PictureBox()
        Me.Cmd_Clipboard_Draw = New System.Windows.Forms.Button()
        Me.TabControl_Method = New System.Windows.Forms.TabControl()
        Me.TabPage_File = New System.Windows.Forms.TabPage()
        Me.TabPage_Clipboard = New System.Windows.Forms.TabPage()
        Me.Cmd_Paste = New System.Windows.Forms.Button()
        Me.Text_Data = New System.Windows.Forms.TextBox()
        Me.Group_DrawOption = New System.Windows.Forms.GroupBox()
        Me.Check_ShowLabels = New System.Windows.Forms.CheckBox()
        Me.Check_AutoValueRange = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Picture_Graph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Gradientbar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl_Method.SuspendLayout()
        Me.TabPage_File.SuspendLayout()
        Me.TabPage_Clipboard.SuspendLayout()
        Me.Group_DrawOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(182, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "~"
        '
        'Text_WellImageHeight
        '
        Me.Text_WellImageHeight.Location = New System.Drawing.Point(232, 37)
        Me.Text_WellImageHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_WellImageHeight.Name = "Text_WellImageHeight"
        Me.Text_WellImageHeight.Size = New System.Drawing.Size(76, 25)
        Me.Text_WellImageHeight.TabIndex = 18
        Me.Text_WellImageHeight.Text = "1000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(210, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "X"
        '
        'Text_WellImageWidth
        '
        Me.Text_WellImageWidth.Location = New System.Drawing.Point(126, 37)
        Me.Text_WellImageWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_WellImageWidth.Name = "Text_WellImageWidth"
        Me.Text_WellImageWidth.Size = New System.Drawing.Size(76, 25)
        Me.Text_WellImageWidth.TabIndex = 16
        Me.Text_WellImageWidth.Text = "1000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Canvas size"
        '
        'Text_ValueMax
        '
        Me.Text_ValueMax.Location = New System.Drawing.Point(197, 91)
        Me.Text_ValueMax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_ValueMax.Name = "Text_ValueMax"
        Me.Text_ValueMax.Size = New System.Drawing.Size(52, 25)
        Me.Text_ValueMax.TabIndex = 14
        Me.Text_ValueMax.Text = "400"
        '
        'Text_ValueMin
        '
        Me.Text_ValueMin.Location = New System.Drawing.Point(126, 91)
        Me.Text_ValueMin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_ValueMin.Name = "Text_ValueMin"
        Me.Text_ValueMin.Size = New System.Drawing.Size(52, 25)
        Me.Text_ValueMin.TabIndex = 13
        Me.Text_ValueMin.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Value range"
        '
        'Picture_Graph
        '
        Me.Picture_Graph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picture_Graph.BackColor = System.Drawing.Color.White
        Me.Picture_Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_Graph.Location = New System.Drawing.Point(11, 15)
        Me.Picture_Graph.Name = "Picture_Graph"
        Me.Picture_Graph.Size = New System.Drawing.Size(551, 590)
        Me.Picture_Graph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture_Graph.TabIndex = 11
        Me.Picture_Graph.TabStop = False
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Cmd_Open
        '
        Me.Cmd_Open.Location = New System.Drawing.Point(19, 184)
        Me.Cmd_Open.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Open.Name = "Cmd_Open"
        Me.Cmd_Open.Size = New System.Drawing.Size(124, 49)
        Me.Cmd_Open.TabIndex = 20
        Me.Cmd_Open.Text = "Set file"
        Me.Cmd_Open.UseVisualStyleBackColor = True
        '
        'Text_Filename
        '
        Me.Text_Filename.Location = New System.Drawing.Point(20, 18)
        Me.Text_Filename.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_Filename.Multiline = True
        Me.Text_Filename.Name = "Text_Filename"
        Me.Text_Filename.Size = New System.Drawing.Size(283, 143)
        Me.Text_Filename.TabIndex = 26
        Me.Text_Filename.Text = "C:\My Programming\VS 2010 - Source\ZebraTracker\sample data\dod2.txt"
        '
        'Cmd_Draw
        '
        Me.Cmd_Draw.Location = New System.Drawing.Point(180, 184)
        Me.Cmd_Draw.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Draw.Name = "Cmd_Draw"
        Me.Cmd_Draw.Size = New System.Drawing.Size(123, 49)
        Me.Cmd_Draw.TabIndex = 27
        Me.Cmd_Draw.Text = "Draw"
        Me.Cmd_Draw.UseVisualStyleBackColor = True
        '
        'Combo_ColorSpectrum
        '
        Me.Combo_ColorSpectrum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_ColorSpectrum.FormattingEnabled = True
        Me.Combo_ColorSpectrum.Items.AddRange(New Object() {"1 (Color spectrum 1)", "2 (Color spectrum 2)", "3 (Blue to Red)", "4 (White to Black)", "5 (Blue to Yellow)", "6 (MatLab default)"})
        Me.Combo_ColorSpectrum.Location = New System.Drawing.Point(140, 135)
        Me.Combo_ColorSpectrum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Combo_ColorSpectrum.Name = "Combo_ColorSpectrum"
        Me.Combo_ColorSpectrum.Size = New System.Drawing.Size(168, 25)
        Me.Combo_ColorSpectrum.TabIndex = 29
        '
        'Cmd_Copy
        '
        Me.Cmd_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Copy.Location = New System.Drawing.Point(605, 556)
        Me.Cmd_Copy.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Copy.Name = "Cmd_Copy"
        Me.Cmd_Copy.Size = New System.Drawing.Size(124, 49)
        Me.Cmd_Copy.TabIndex = 30
        Me.Cmd_Copy.Text = "Copy heatmap"
        Me.Cmd_Copy.UseVisualStyleBackColor = True
        '
        'Cmd_CopyGradientBar
        '
        Me.Cmd_CopyGradientBar.Location = New System.Drawing.Point(24, 168)
        Me.Cmd_CopyGradientBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_CopyGradientBar.Name = "Cmd_CopyGradientBar"
        Me.Cmd_CopyGradientBar.Size = New System.Drawing.Size(77, 32)
        Me.Cmd_CopyGradientBar.TabIndex = 31
        Me.Cmd_CopyGradientBar.Text = "Copy"
        Me.Cmd_CopyGradientBar.UseVisualStyleBackColor = True
        '
        'Pic_Gradientbar
        '
        Me.Pic_Gradientbar.BackColor = System.Drawing.Color.White
        Me.Pic_Gradientbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Gradientbar.Location = New System.Drawing.Point(107, 168)
        Me.Pic_Gradientbar.Name = "Pic_Gradientbar"
        Me.Pic_Gradientbar.Size = New System.Drawing.Size(201, 31)
        Me.Pic_Gradientbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Gradientbar.TabIndex = 32
        Me.Pic_Gradientbar.TabStop = False
        '
        'Cmd_Clipboard_Draw
        '
        Me.Cmd_Clipboard_Draw.Location = New System.Drawing.Point(180, 184)
        Me.Cmd_Clipboard_Draw.Name = "Cmd_Clipboard_Draw"
        Me.Cmd_Clipboard_Draw.Size = New System.Drawing.Size(123, 49)
        Me.Cmd_Clipboard_Draw.TabIndex = 35
        Me.Cmd_Clipboard_Draw.Text = "Draw"
        Me.Cmd_Clipboard_Draw.UseVisualStyleBackColor = True
        '
        'TabControl_Method
        '
        Me.TabControl_Method.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl_Method.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl_Method.Controls.Add(Me.TabPage_File)
        Me.TabControl_Method.Controls.Add(Me.TabPage_Clipboard)
        Me.TabControl_Method.HotTrack = True
        Me.TabControl_Method.Location = New System.Drawing.Point(581, 250)
        Me.TabControl_Method.Name = "TabControl_Method"
        Me.TabControl_Method.SelectedIndex = 0
        Me.TabControl_Method.Size = New System.Drawing.Size(329, 288)
        Me.TabControl_Method.TabIndex = 36
        '
        'TabPage_File
        '
        Me.TabPage_File.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage_File.Controls.Add(Me.Text_Filename)
        Me.TabPage_File.Controls.Add(Me.Cmd_Open)
        Me.TabPage_File.Controls.Add(Me.Cmd_Draw)
        Me.TabPage_File.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_File.Name = "TabPage_File"
        Me.TabPage_File.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_File.Size = New System.Drawing.Size(321, 255)
        Me.TabPage_File.TabIndex = 0
        Me.TabPage_File.Text = "File"
        Me.TabPage_File.UseVisualStyleBackColor = True
        '
        'TabPage_Clipboard
        '
        Me.TabPage_Clipboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage_Clipboard.Controls.Add(Me.Cmd_Paste)
        Me.TabPage_Clipboard.Controls.Add(Me.Text_Data)
        Me.TabPage_Clipboard.Controls.Add(Me.Cmd_Clipboard_Draw)
        Me.TabPage_Clipboard.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Clipboard.Name = "TabPage_Clipboard"
        Me.TabPage_Clipboard.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Clipboard.Size = New System.Drawing.Size(321, 255)
        Me.TabPage_Clipboard.TabIndex = 1
        Me.TabPage_Clipboard.Text = "Clipboard"
        Me.TabPage_Clipboard.UseVisualStyleBackColor = True
        '
        'Cmd_Paste
        '
        Me.Cmd_Paste.Location = New System.Drawing.Point(20, 184)
        Me.Cmd_Paste.Name = "Cmd_Paste"
        Me.Cmd_Paste.Size = New System.Drawing.Size(123, 49)
        Me.Cmd_Paste.TabIndex = 37
        Me.Cmd_Paste.Text = "Paste"
        Me.Cmd_Paste.UseVisualStyleBackColor = True
        '
        'Text_Data
        '
        Me.Text_Data.Font = New System.Drawing.Font("Gulim", 8.139131!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Text_Data.Location = New System.Drawing.Point(20, 18)
        Me.Text_Data.Multiline = True
        Me.Text_Data.Name = "Text_Data"
        Me.Text_Data.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Text_Data.Size = New System.Drawing.Size(283, 143)
        Me.Text_Data.TabIndex = 0
        Me.Text_Data.WordWrap = False
        '
        'Group_DrawOption
        '
        Me.Group_DrawOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Group_DrawOption.Controls.Add(Me.Check_ShowLabels)
        Me.Group_DrawOption.Controls.Add(Me.Check_AutoValueRange)
        Me.Group_DrawOption.Controls.Add(Me.Label4)
        Me.Group_DrawOption.Controls.Add(Me.Label1)
        Me.Group_DrawOption.Controls.Add(Me.Pic_Gradientbar)
        Me.Group_DrawOption.Controls.Add(Me.Text_ValueMin)
        Me.Group_DrawOption.Controls.Add(Me.Cmd_CopyGradientBar)
        Me.Group_DrawOption.Controls.Add(Me.Text_ValueMax)
        Me.Group_DrawOption.Controls.Add(Me.Text_WellImageWidth)
        Me.Group_DrawOption.Controls.Add(Me.Combo_ColorSpectrum)
        Me.Group_DrawOption.Controls.Add(Me.Label3)
        Me.Group_DrawOption.Controls.Add(Me.Text_WellImageHeight)
        Me.Group_DrawOption.Controls.Add(Me.Label5)
        Me.Group_DrawOption.Location = New System.Drawing.Point(581, 15)
        Me.Group_DrawOption.Name = "Group_DrawOption"
        Me.Group_DrawOption.Size = New System.Drawing.Size(329, 221)
        Me.Group_DrawOption.TabIndex = 37
        Me.Group_DrawOption.TabStop = False
        Me.Group_DrawOption.Text = "Draw option"
        '
        'Check_ShowLabels
        '
        Me.Check_ShowLabels.AutoSize = True
        Me.Check_ShowLabels.Checked = True
        Me.Check_ShowLabels.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_ShowLabels.Location = New System.Drawing.Point(25, 137)
        Me.Check_ShowLabels.Name = "Check_ShowLabels"
        Me.Check_ShowLabels.Size = New System.Drawing.Size(109, 21)
        Me.Check_ShowLabels.TabIndex = 34
        Me.Check_ShowLabels.Text = "Show labels"
        Me.Check_ShowLabels.UseVisualStyleBackColor = True
        '
        'Check_AutoValueRange
        '
        Me.Check_AutoValueRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Check_AutoValueRange.AutoSize = True
        Me.Check_AutoValueRange.Checked = True
        Me.Check_AutoValueRange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_AutoValueRange.Location = New System.Drawing.Point(264, 93)
        Me.Check_AutoValueRange.Name = "Check_AutoValueRange"
        Me.Check_AutoValueRange.Size = New System.Drawing.Size(59, 21)
        Me.Check_AutoValueRange.TabIndex = 33
        Me.Check_AutoValueRange.Text = "Auto"
        Me.Check_AutoValueRange.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(766, 556)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 49)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Frm_HeatMap_General
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 624)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Group_DrawOption)
        Me.Controls.Add(Me.TabControl_Method)
        Me.Controls.Add(Me.Cmd_Copy)
        Me.Controls.Add(Me.Picture_Graph)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Frm_HeatMap_General"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "2D Heatmap Viewer"
        CType(Me.Picture_Graph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Gradientbar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl_Method.ResumeLayout(False)
        Me.TabPage_File.ResumeLayout(False)
        Me.TabPage_File.PerformLayout()
        Me.TabPage_Clipboard.ResumeLayout(False)
        Me.TabPage_Clipboard.PerformLayout()
        Me.Group_DrawOption.ResumeLayout(False)
        Me.Group_DrawOption.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Text_WellImageHeight As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Text_WellImageWidth As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Text_ValueMax As TextBox
    Friend WithEvents Text_ValueMin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Picture_Graph As PictureBox
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents Cmd_Open As Button
    Friend WithEvents Text_Filename As TextBox
    Friend WithEvents Cmd_Draw As Button
    Friend WithEvents Combo_ColorSpectrum As ComboBox
    Friend WithEvents Cmd_Copy As Button
    Friend WithEvents Cmd_CopyGradientBar As Button
    Friend WithEvents Pic_Gradientbar As PictureBox
    Friend WithEvents Cmd_Clipboard_Draw As Button
    Friend WithEvents TabControl_Method As TabControl
    Friend WithEvents TabPage_File As TabPage
    Friend WithEvents TabPage_Clipboard As TabPage
    Friend WithEvents Text_Data As TextBox
    Friend WithEvents Cmd_Paste As Button
    Friend WithEvents Group_DrawOption As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Check_AutoValueRange As CheckBox
    Friend WithEvents Check_ShowLabels As CheckBox
End Class

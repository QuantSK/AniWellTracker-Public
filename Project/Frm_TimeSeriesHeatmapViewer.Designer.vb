<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_TimeSeriesHeatmapViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_TimeSeriesHeatmapViewer))
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_TimeMin = New System.Windows.Forms.TextBox()
        Me.Text_TimeMax = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Combo_TimeUnit = New System.Windows.Forms.ComboBox()
        Me.Text_Filename = New System.Windows.Forms.TextBox()
        Me.Cmd_Draw = New System.Windows.Forms.Button()
        Me.Combo_ColorSpectrum = New System.Windows.Forms.ComboBox()
        Me.Cmd_Copy = New System.Windows.Forms.Button()
        Me.Cmd_CopyGradientBar = New System.Windows.Forms.Button()
        Me.Pic_Gradientbar = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Check_FillWhiteBlank = New System.Windows.Forms.CheckBox()
        Me.Check_ShowLabels = New System.Windows.Forms.CheckBox()
        Me.Check_AutoValueRange = New System.Windows.Forms.CheckBox()
        CType(Me.Picture_Graph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Gradientbar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(641, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "~"
        '
        'Text_WellImageHeight
        '
        Me.Text_WellImageHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_WellImageHeight.Location = New System.Drawing.Point(665, 35)
        Me.Text_WellImageHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_WellImageHeight.Name = "Text_WellImageHeight"
        Me.Text_WellImageHeight.Size = New System.Drawing.Size(75, 25)
        Me.Text_WellImageHeight.TabIndex = 18
        Me.Text_WellImageHeight.Text = "30"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(641, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "X"
        '
        'Text_WellImageWidth
        '
        Me.Text_WellImageWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_WellImageWidth.Location = New System.Drawing.Point(563, 35)
        Me.Text_WellImageWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_WellImageWidth.Name = "Text_WellImageWidth"
        Me.Text_WellImageWidth.Size = New System.Drawing.Size(75, 25)
        Me.Text_WellImageWidth.TabIndex = 16
        Me.Text_WellImageWidth.Text = "700"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(560, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Image size of a single well"
        '
        'Text_ValueMax
        '
        Me.Text_ValueMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_ValueMax.Location = New System.Drawing.Point(665, 197)
        Me.Text_ValueMax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_ValueMax.Name = "Text_ValueMax"
        Me.Text_ValueMax.Size = New System.Drawing.Size(75, 25)
        Me.Text_ValueMax.TabIndex = 14
        Me.Text_ValueMax.Text = "400"
        '
        'Text_ValueMin
        '
        Me.Text_ValueMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_ValueMin.Location = New System.Drawing.Point(563, 197)
        Me.Text_ValueMin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_ValueMin.Name = "Text_ValueMin"
        Me.Text_ValueMin.Size = New System.Drawing.Size(75, 25)
        Me.Text_ValueMin.TabIndex = 13
        Me.Text_ValueMin.Text = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(560, 172)
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
        Me.Picture_Graph.Size = New System.Drawing.Size(531, 609)
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
        Me.Cmd_Open.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Open.Location = New System.Drawing.Point(727, 384)
        Me.Cmd_Open.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Open.Name = "Cmd_Open"
        Me.Cmd_Open.Size = New System.Drawing.Size(97, 34)
        Me.Cmd_Open.TabIndex = 20
        Me.Cmd_Open.Text = "Set file"
        Me.Cmd_Open.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(641, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 17)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "~"
        '
        'Text_TimeMin
        '
        Me.Text_TimeMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_TimeMin.Location = New System.Drawing.Point(563, 114)
        Me.Text_TimeMin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_TimeMin.Name = "Text_TimeMin"
        Me.Text_TimeMin.Size = New System.Drawing.Size(75, 25)
        Me.Text_TimeMin.TabIndex = 23
        Me.Text_TimeMin.Text = "0"
        '
        'Text_TimeMax
        '
        Me.Text_TimeMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_TimeMax.Location = New System.Drawing.Point(665, 114)
        Me.Text_TimeMax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_TimeMax.Name = "Text_TimeMax"
        Me.Text_TimeMax.Size = New System.Drawing.Size(75, 25)
        Me.Text_TimeMax.TabIndex = 22
        Me.Text_TimeMax.Text = "2"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(560, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Time range"
        '
        'Combo_TimeUnit
        '
        Me.Combo_TimeUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Combo_TimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_TimeUnit.FormattingEnabled = True
        Me.Combo_TimeUnit.Items.AddRange(New Object() {"Min", "Hour", "Day"})
        Me.Combo_TimeUnit.Location = New System.Drawing.Point(755, 117)
        Me.Combo_TimeUnit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Combo_TimeUnit.Name = "Combo_TimeUnit"
        Me.Combo_TimeUnit.Size = New System.Drawing.Size(69, 25)
        Me.Combo_TimeUnit.TabIndex = 25
        '
        'Text_Filename
        '
        Me.Text_Filename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Text_Filename.Location = New System.Drawing.Point(565, 423)
        Me.Text_Filename.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_Filename.Multiline = True
        Me.Text_Filename.Name = "Text_Filename"
        Me.Text_Filename.Size = New System.Drawing.Size(258, 82)
        Me.Text_Filename.TabIndex = 26
        '
        'Cmd_Draw
        '
        Me.Cmd_Draw.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Draw.Location = New System.Drawing.Point(717, 528)
        Me.Cmd_Draw.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Draw.Name = "Cmd_Draw"
        Me.Cmd_Draw.Size = New System.Drawing.Size(107, 58)
        Me.Cmd_Draw.TabIndex = 27
        Me.Cmd_Draw.Text = "Draw now"
        Me.Cmd_Draw.UseVisualStyleBackColor = True
        '
        'Combo_ColorSpectrum
        '
        Me.Combo_ColorSpectrum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Combo_ColorSpectrum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_ColorSpectrum.FormattingEnabled = True
        Me.Combo_ColorSpectrum.Items.AddRange(New Object() {"1 (Color spectrum 1)", "2 (Color spectrum 2)", "3 (Blue to Red)", "4 (White to Black)", "5 (Blue to Yellow)", "6 (MatLab default)"})
        Me.Combo_ColorSpectrum.Location = New System.Drawing.Point(645, 272)
        Me.Combo_ColorSpectrum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Combo_ColorSpectrum.Name = "Combo_ColorSpectrum"
        Me.Combo_ColorSpectrum.Size = New System.Drawing.Size(180, 25)
        Me.Combo_ColorSpectrum.TabIndex = 29
        '
        'Cmd_Copy
        '
        Me.Cmd_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Copy.Location = New System.Drawing.Point(565, 528)
        Me.Cmd_Copy.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_Copy.Name = "Cmd_Copy"
        Me.Cmd_Copy.Size = New System.Drawing.Size(107, 58)
        Me.Cmd_Copy.TabIndex = 30
        Me.Cmd_Copy.Text = "Copy"
        Me.Cmd_Copy.UseVisualStyleBackColor = True
        '
        'Cmd_CopyGradientBar
        '
        Me.Cmd_CopyGradientBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_CopyGradientBar.Location = New System.Drawing.Point(755, 233)
        Me.Cmd_CopyGradientBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cmd_CopyGradientBar.Name = "Cmd_CopyGradientBar"
        Me.Cmd_CopyGradientBar.Size = New System.Drawing.Size(69, 32)
        Me.Cmd_CopyGradientBar.TabIndex = 31
        Me.Cmd_CopyGradientBar.Text = "Copy"
        Me.Cmd_CopyGradientBar.UseVisualStyleBackColor = True
        '
        'Pic_Gradientbar
        '
        Me.Pic_Gradientbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic_Gradientbar.BackColor = System.Drawing.Color.White
        Me.Pic_Gradientbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Gradientbar.Location = New System.Drawing.Point(563, 233)
        Me.Pic_Gradientbar.Name = "Pic_Gradientbar"
        Me.Pic_Gradientbar.Size = New System.Drawing.Size(177, 31)
        Me.Pic_Gradientbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Gradientbar.TabIndex = 32
        Me.Pic_Gradientbar.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(560, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Color bar"
        '
        'Check_FillWhiteBlank
        '
        Me.Check_FillWhiteBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Check_FillWhiteBlank.AutoSize = True
        Me.Check_FillWhiteBlank.Location = New System.Drawing.Point(563, 316)
        Me.Check_FillWhiteBlank.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Check_FillWhiteBlank.Name = "Check_FillWhiteBlank"
        Me.Check_FillWhiteBlank.Size = New System.Drawing.Size(195, 21)
        Me.Check_FillWhiteBlank.TabIndex = 33
        Me.Check_FillWhiteBlank.Text = "Fill white when blank data"
        Me.Check_FillWhiteBlank.UseVisualStyleBackColor = True
        '
        'Check_ShowLabels
        '
        Me.Check_ShowLabels.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Check_ShowLabels.AutoSize = True
        Me.Check_ShowLabels.Checked = True
        Me.Check_ShowLabels.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_ShowLabels.Location = New System.Drawing.Point(563, 360)
        Me.Check_ShowLabels.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Check_ShowLabels.Name = "Check_ShowLabels"
        Me.Check_ShowLabels.Size = New System.Drawing.Size(109, 21)
        Me.Check_ShowLabels.TabIndex = 35
        Me.Check_ShowLabels.Text = "Show labels"
        Me.Check_ShowLabels.UseVisualStyleBackColor = True
        '
        'Check_AutoValueRange
        '
        Me.Check_AutoValueRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Check_AutoValueRange.AutoSize = True
        Me.Check_AutoValueRange.Checked = True
        Me.Check_AutoValueRange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_AutoValueRange.Location = New System.Drawing.Point(755, 199)
        Me.Check_AutoValueRange.Name = "Check_AutoValueRange"
        Me.Check_AutoValueRange.Size = New System.Drawing.Size(59, 21)
        Me.Check_AutoValueRange.TabIndex = 36
        Me.Check_AutoValueRange.Text = "Auto"
        Me.Check_AutoValueRange.UseVisualStyleBackColor = True
        '
        'Frm_TimeSeriesHeatmapViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 638)
        Me.Controls.Add(Me.Check_AutoValueRange)
        Me.Controls.Add(Me.Check_ShowLabels)
        Me.Controls.Add(Me.Check_FillWhiteBlank)
        Me.Controls.Add(Me.Pic_Gradientbar)
        Me.Controls.Add(Me.Cmd_CopyGradientBar)
        Me.Controls.Add(Me.Cmd_Copy)
        Me.Controls.Add(Me.Combo_ColorSpectrum)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cmd_Draw)
        Me.Controls.Add(Me.Text_Filename)
        Me.Controls.Add(Me.Combo_TimeUnit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_TimeMin)
        Me.Controls.Add(Me.Text_TimeMax)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Text_WellImageHeight)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Text_WellImageWidth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Text_ValueMax)
        Me.Controls.Add(Me.Text_ValueMin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Picture_Graph)
        Me.Controls.Add(Me.Cmd_Open)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Frm_TimeSeriesHeatmapViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time-Series Heatmap Viewer"
        CType(Me.Picture_Graph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Gradientbar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents Label2 As Label
    Friend WithEvents Text_TimeMin As TextBox
    Friend WithEvents Text_TimeMax As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Combo_TimeUnit As ComboBox
    Friend WithEvents Text_Filename As TextBox
    Friend WithEvents Cmd_Draw As Button
    Friend WithEvents Combo_ColorSpectrum As ComboBox
    Friend WithEvents Cmd_Copy As Button
    Friend WithEvents Cmd_CopyGradientBar As Button
    Friend WithEvents Pic_Gradientbar As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Check_FillWhiteBlank As CheckBox
    Friend WithEvents Check_ShowLabels As CheckBox
    Friend WithEvents Check_AutoValueRange As CheckBox
End Class

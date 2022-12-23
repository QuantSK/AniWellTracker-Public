<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_AdaptiveThresholding
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AdaptiveThresholding))
        Me.Text_BoxSize = New System.Windows.Forms.TextBox()
        Me.Track_BoxSize = New System.Windows.Forms.TrackBar()
        Me.Cmd_OK = New System.Windows.Forms.Button()
        Me.Cmd_Cancel = New System.Windows.Forms.Button()
        Me.Radio_ObjectBlack = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Check_Automatic = New System.Windows.Forms.CheckBox()
        Me.Radio_ObjectWhite = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Track_ThresholdLevel = New System.Windows.Forms.TrackBar()
        Me.Text_ThresholdLevel = New System.Windows.Forms.TextBox()
        CType(Me.Track_BoxSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Track_ThresholdLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_BoxSize
        '
        Me.Text_BoxSize.Location = New System.Drawing.Point(23, 45)
        Me.Text_BoxSize.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_BoxSize.Name = "Text_BoxSize"
        Me.Text_BoxSize.Size = New System.Drawing.Size(63, 25)
        Me.Text_BoxSize.TabIndex = 1
        Me.Text_BoxSize.Text = "35"
        '
        'Track_BoxSize
        '
        Me.Track_BoxSize.Location = New System.Drawing.Point(95, 41)
        Me.Track_BoxSize.Margin = New System.Windows.Forms.Padding(4)
        Me.Track_BoxSize.Maximum = 200
        Me.Track_BoxSize.Minimum = 1
        Me.Track_BoxSize.Name = "Track_BoxSize"
        Me.Track_BoxSize.Size = New System.Drawing.Size(364, 56)
        Me.Track_BoxSize.TabIndex = 2
        Me.Track_BoxSize.TickFrequency = 5
        Me.Track_BoxSize.Value = 35
        '
        'Cmd_OK
        '
        Me.Cmd_OK.Location = New System.Drawing.Point(93, 317)
        Me.Cmd_OK.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmd_OK.Name = "Cmd_OK"
        Me.Cmd_OK.Size = New System.Drawing.Size(115, 47)
        Me.Cmd_OK.TabIndex = 8
        Me.Cmd_OK.Text = "OK"
        Me.Cmd_OK.UseVisualStyleBackColor = True
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cmd_Cancel.Location = New System.Drawing.Point(292, 317)
        Me.Cmd_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(115, 47)
        Me.Cmd_Cancel.TabIndex = 9
        Me.Cmd_Cancel.Text = "Cancel"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Radio_ObjectBlack
        '
        Me.Radio_ObjectBlack.AutoSize = True
        Me.Radio_ObjectBlack.Checked = True
        Me.Radio_ObjectBlack.Location = New System.Drawing.Point(35, 32)
        Me.Radio_ObjectBlack.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_ObjectBlack.Name = "Radio_ObjectBlack"
        Me.Radio_ObjectBlack.Size = New System.Drawing.Size(65, 21)
        Me.Radio_ObjectBlack.TabIndex = 3
        Me.Radio_ObjectBlack.TabStop = True
        Me.Radio_ObjectBlack.Text = "Black"
        Me.Radio_ObjectBlack.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Check_Automatic)
        Me.GroupBox1.Controls.Add(Me.Radio_ObjectWhite)
        Me.GroupBox1.Controls.Add(Me.Radio_ObjectBlack)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 120)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(484, 72)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color of objects of interest"
        '
        'Check_Automatic
        '
        Me.Check_Automatic.AutoSize = True
        Me.Check_Automatic.Enabled = False
        Me.Check_Automatic.Location = New System.Drawing.Point(351, 33)
        Me.Check_Automatic.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_Automatic.Name = "Check_Automatic"
        Me.Check_Automatic.Size = New System.Drawing.Size(95, 21)
        Me.Check_Automatic.TabIndex = 5
        Me.Check_Automatic.Text = "Automatic"
        Me.Check_Automatic.UseVisualStyleBackColor = True
        '
        'Radio_ObjectWhite
        '
        Me.Radio_ObjectWhite.AutoSize = True
        Me.Radio_ObjectWhite.Location = New System.Drawing.Point(179, 33)
        Me.Radio_ObjectWhite.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_ObjectWhite.Name = "Radio_ObjectWhite"
        Me.Radio_ObjectWhite.Size = New System.Drawing.Size(67, 21)
        Me.Radio_ObjectWhite.TabIndex = 4
        Me.Radio_ObjectWhite.Text = "White"
        Me.Radio_ObjectWhite.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Track_BoxSize)
        Me.GroupBox2.Controls.Add(Me.Text_BoxSize)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 16)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(484, 96)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Size of processing box   (Recommend bigger than objects of interest)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Track_ThresholdLevel)
        Me.GroupBox3.Controls.Add(Me.Text_ThresholdLevel)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 199)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(486, 99)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Threshold level %   (Recommend 86 as default)"
        '
        'Track_ThresholdLevel
        '
        Me.Track_ThresholdLevel.Location = New System.Drawing.Point(95, 41)
        Me.Track_ThresholdLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.Track_ThresholdLevel.Maximum = 110
        Me.Track_ThresholdLevel.Minimum = 50
        Me.Track_ThresholdLevel.Name = "Track_ThresholdLevel"
        Me.Track_ThresholdLevel.Size = New System.Drawing.Size(367, 56)
        Me.Track_ThresholdLevel.TabIndex = 7
        Me.Track_ThresholdLevel.TickFrequency = 5
        Me.Track_ThresholdLevel.Value = 86
        '
        'Text_ThresholdLevel
        '
        Me.Text_ThresholdLevel.Location = New System.Drawing.Point(23, 45)
        Me.Text_ThresholdLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_ThresholdLevel.Name = "Text_ThresholdLevel"
        Me.Text_ThresholdLevel.Size = New System.Drawing.Size(63, 25)
        Me.Text_ThresholdLevel.TabIndex = 6
        Me.Text_ThresholdLevel.Text = "92"
        '
        'Frm_AdaptiveThresholding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.Cmd_Cancel
        Me.ClientSize = New System.Drawing.Size(524, 382)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cmd_OK)
        Me.Controls.Add(Me.Cmd_Cancel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_AdaptiveThresholding"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adaptive thresholding"
        Me.TopMost = True
        CType(Me.Track_BoxSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Track_ThresholdLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Text_BoxSize As System.Windows.Forms.TextBox
    Friend WithEvents Track_BoxSize As System.Windows.Forms.TrackBar
    Friend WithEvents Cmd_OK As System.Windows.Forms.Button
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Radio_ObjectBlack As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_ObjectWhite As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Track_ThresholdLevel As System.Windows.Forms.TrackBar
    Friend WithEvents Text_ThresholdLevel As System.Windows.Forms.TextBox
    Friend WithEvents Check_Automatic As System.Windows.Forms.CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Tracker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Tracker))
        Me.Group_Source = New System.Windows.Forms.GroupBox()
        Me.Cmd_CustomFolder_Set = New System.Windows.Forms.Button()
        Me.Text_SourceFolder = New System.Windows.Forms.TextBox()
        Me.Combo_Binarization_PreblurringSize = New System.Windows.Forms.ComboBox()
        Me.Cmd_TestBinarization = New System.Windows.Forms.Button()
        Me.Cmd_SetBinarization = New System.Windows.Forms.Button()
        Me.Check_Binarization_Preblurring = New System.Windows.Forms.CheckBox()
        Me.Cmd_Process = New System.Windows.Forms.Button()
        Me.FolderDialog_SourceImage = New System.Windows.Forms.FolderBrowserDialog()
        Me.Cmd_TestRegionExtract = New System.Windows.Forms.Button()
        Me.Cmd_SetAdaptive = New System.Windows.Forms.Button()
        Me.Combo_Subtraction_PreblurringSize = New System.Windows.Forms.ComboBox()
        Me.Check_Subtraction_Preblurring = New System.Windows.Forms.CheckBox()
        Me.Text_Image1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Group_TestImage = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_Image2 = New System.Windows.Forms.TextBox()
        Me.Check_ProcessEverySubfolder = New System.Windows.Forms.CheckBox()
        Me.Tab_Config = New System.Windows.Forms.TabControl()
        Me.Tab_Binarization = New System.Windows.Forms.TabPage()
        Me.Tab_RegionExtraction = New System.Windows.Forms.TabPage()
        Me.Tab_Processing = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_ConfineTo = New System.Windows.Forms.TextBox()
        Me.Text_ConfineFrom = New System.Windows.Forms.TextBox()
        Me.Check_Confine = New System.Windows.Forms.CheckBox()
        Me.Text_TimeIntervalSec = New System.Windows.Forms.TextBox()
        Me.Radio_WithFixedInterval = New System.Windows.Forms.RadioButton()
        Me.Group_TimeInterval = New System.Windows.Forms.GroupBox()
        Me.Radio_WithoutFixedInterval = New System.Windows.Forms.RadioButton()
        Me.Label_TimeInterval = New System.Windows.Forms.Label()
        Me.Group_Source.SuspendLayout()
        Me.Group_TestImage.SuspendLayout()
        Me.Tab_Config.SuspendLayout()
        Me.Tab_Binarization.SuspendLayout()
        Me.Tab_RegionExtraction.SuspendLayout()
        Me.Tab_Processing.SuspendLayout()
        Me.Group_TimeInterval.SuspendLayout()
        Me.SuspendLayout()
        '
        'Group_Source
        '
        Me.Group_Source.Controls.Add(Me.Cmd_CustomFolder_Set)
        Me.Group_Source.Controls.Add(Me.Text_SourceFolder)
        Me.Group_Source.Location = New System.Drawing.Point(13, 12)
        Me.Group_Source.Margin = New System.Windows.Forms.Padding(5)
        Me.Group_Source.Name = "Group_Source"
        Me.Group_Source.Padding = New System.Windows.Forms.Padding(5)
        Me.Group_Source.Size = New System.Drawing.Size(511, 69)
        Me.Group_Source.TabIndex = 36
        Me.Group_Source.TabStop = False
        Me.Group_Source.Text = "Source image folder"
        '
        'Cmd_CustomFolder_Set
        '
        Me.Cmd_CustomFolder_Set.Image = CType(resources.GetObject("Cmd_CustomFolder_Set.Image"), System.Drawing.Image)
        Me.Cmd_CustomFolder_Set.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_CustomFolder_Set.Location = New System.Drawing.Point(407, 28)
        Me.Cmd_CustomFolder_Set.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmd_CustomFolder_Set.Name = "Cmd_CustomFolder_Set"
        Me.Cmd_CustomFolder_Set.Size = New System.Drawing.Size(82, 27)
        Me.Cmd_CustomFolder_Set.TabIndex = 4
        Me.Cmd_CustomFolder_Set.Text = "    Set"
        Me.Cmd_CustomFolder_Set.UseVisualStyleBackColor = True
        '
        'Text_SourceFolder
        '
        Me.Text_SourceFolder.Location = New System.Drawing.Point(25, 27)
        Me.Text_SourceFolder.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Text_SourceFolder.Name = "Text_SourceFolder"
        Me.Text_SourceFolder.Size = New System.Drawing.Size(377, 25)
        Me.Text_SourceFolder.TabIndex = 5
        Me.Text_SourceFolder.TabStop = False
        '
        'Combo_Binarization_PreblurringSize
        '
        Me.Combo_Binarization_PreblurringSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Binarization_PreblurringSize.FormattingEnabled = True
        Me.Combo_Binarization_PreblurringSize.Items.AddRange(New Object() {"3x3 Gaussian", "5x5 Gaussian", "7x7 Gaussian", "3x3 Blur", "5x5 Blur", "7x7 Blur", "9x9 Blur"})
        Me.Combo_Binarization_PreblurringSize.Location = New System.Drawing.Point(15, 69)
        Me.Combo_Binarization_PreblurringSize.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Combo_Binarization_PreblurringSize.Name = "Combo_Binarization_PreblurringSize"
        Me.Combo_Binarization_PreblurringSize.Size = New System.Drawing.Size(171, 25)
        Me.Combo_Binarization_PreblurringSize.TabIndex = 49
        Me.Combo_Binarization_PreblurringSize.Visible = False
        '
        'Cmd_TestBinarization
        '
        Me.Cmd_TestBinarization.Location = New System.Drawing.Point(397, 25)
        Me.Cmd_TestBinarization.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmd_TestBinarization.Name = "Cmd_TestBinarization"
        Me.Cmd_TestBinarization.Size = New System.Drawing.Size(86, 42)
        Me.Cmd_TestBinarization.TabIndex = 40
        Me.Cmd_TestBinarization.Text = "Test"
        Me.Cmd_TestBinarization.UseVisualStyleBackColor = True
        '
        'Cmd_SetBinarization
        '
        Me.Cmd_SetBinarization.Location = New System.Drawing.Point(215, 25)
        Me.Cmd_SetBinarization.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmd_SetBinarization.Name = "Cmd_SetBinarization"
        Me.Cmd_SetBinarization.Size = New System.Drawing.Size(176, 42)
        Me.Cmd_SetBinarization.TabIndex = 0
        Me.Cmd_SetBinarization.Text = "Set adaptive threshold"
        Me.Cmd_SetBinarization.UseVisualStyleBackColor = True
        '
        'Check_Binarization_Preblurring
        '
        Me.Check_Binarization_Preblurring.AutoSize = True
        Me.Check_Binarization_Preblurring.Location = New System.Drawing.Point(15, 36)
        Me.Check_Binarization_Preblurring.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Check_Binarization_Preblurring.Name = "Check_Binarization_Preblurring"
        Me.Check_Binarization_Preblurring.Size = New System.Drawing.Size(106, 21)
        Me.Check_Binarization_Preblurring.TabIndex = 48
        Me.Check_Binarization_Preblurring.Text = "Pre-blurring"
        Me.Check_Binarization_Preblurring.UseVisualStyleBackColor = True
        '
        'Cmd_Process
        '
        Me.Cmd_Process.Image = CType(resources.GetObject("Cmd_Process.Image"), System.Drawing.Image)
        Me.Cmd_Process.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Process.Location = New System.Drawing.Point(365, 31)
        Me.Cmd_Process.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmd_Process.Name = "Cmd_Process"
        Me.Cmd_Process.Size = New System.Drawing.Size(118, 73)
        Me.Cmd_Process.TabIndex = 38
        Me.Cmd_Process.Text = "Process"
        Me.Cmd_Process.UseVisualStyleBackColor = True
        '
        'Cmd_TestRegionExtract
        '
        Me.Cmd_TestRegionExtract.Location = New System.Drawing.Point(397, 25)
        Me.Cmd_TestRegionExtract.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmd_TestRegionExtract.Name = "Cmd_TestRegionExtract"
        Me.Cmd_TestRegionExtract.Size = New System.Drawing.Size(86, 42)
        Me.Cmd_TestRegionExtract.TabIndex = 0
        Me.Cmd_TestRegionExtract.Text = "Test"
        Me.Cmd_TestRegionExtract.UseVisualStyleBackColor = True
        '
        'Cmd_SetAdaptive
        '
        Me.Cmd_SetAdaptive.Location = New System.Drawing.Point(214, 25)
        Me.Cmd_SetAdaptive.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmd_SetAdaptive.Name = "Cmd_SetAdaptive"
        Me.Cmd_SetAdaptive.Size = New System.Drawing.Size(176, 42)
        Me.Cmd_SetAdaptive.TabIndex = 43
        Me.Cmd_SetAdaptive.Text = "Set region extraction"
        Me.Cmd_SetAdaptive.UseVisualStyleBackColor = True
        '
        'Combo_Subtraction_PreblurringSize
        '
        Me.Combo_Subtraction_PreblurringSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Subtraction_PreblurringSize.FormattingEnabled = True
        Me.Combo_Subtraction_PreblurringSize.Items.AddRange(New Object() {"3x3 Gaussian", "5x5 Gaussian", "7x7 Gaussian", "3x3 Blur", "5x5 Blur", "7x7 Blur", "9x9 Blur"})
        Me.Combo_Subtraction_PreblurringSize.Location = New System.Drawing.Point(15, 69)
        Me.Combo_Subtraction_PreblurringSize.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Combo_Subtraction_PreblurringSize.Name = "Combo_Subtraction_PreblurringSize"
        Me.Combo_Subtraction_PreblurringSize.Size = New System.Drawing.Size(170, 25)
        Me.Combo_Subtraction_PreblurringSize.TabIndex = 48
        Me.Combo_Subtraction_PreblurringSize.Visible = False
        '
        'Check_Subtraction_Preblurring
        '
        Me.Check_Subtraction_Preblurring.AutoSize = True
        Me.Check_Subtraction_Preblurring.Location = New System.Drawing.Point(15, 36)
        Me.Check_Subtraction_Preblurring.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Check_Subtraction_Preblurring.Name = "Check_Subtraction_Preblurring"
        Me.Check_Subtraction_Preblurring.Size = New System.Drawing.Size(106, 21)
        Me.Check_Subtraction_Preblurring.TabIndex = 45
        Me.Check_Subtraction_Preblurring.Text = "Pre-blurring"
        Me.Check_Subtraction_Preblurring.UseVisualStyleBackColor = True
        '
        'Text_Image1
        '
        Me.Text_Image1.Location = New System.Drawing.Point(98, 27)
        Me.Text_Image1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Text_Image1.Name = "Text_Image1"
        Me.Text_Image1.ReadOnly = True
        Me.Text_Image1.Size = New System.Drawing.Size(393, 25)
        Me.Text_Image1.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Current"
        '
        'Group_TestImage
        '
        Me.Group_TestImage.Controls.Add(Me.Label3)
        Me.Group_TestImage.Controls.Add(Me.Label4)
        Me.Group_TestImage.Controls.Add(Me.Text_Image2)
        Me.Group_TestImage.Controls.Add(Me.Text_Image1)
        Me.Group_TestImage.Location = New System.Drawing.Point(13, 209)
        Me.Group_TestImage.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Group_TestImage.Name = "Group_TestImage"
        Me.Group_TestImage.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Group_TestImage.Size = New System.Drawing.Size(511, 110)
        Me.Group_TestImage.TabIndex = 40
        Me.Group_TestImage.TabStop = False
        Me.Group_TestImage.Text = "Current time-lapse images"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Next"
        '
        'Text_Image2
        '
        Me.Text_Image2.Location = New System.Drawing.Point(98, 62)
        Me.Text_Image2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Text_Image2.Name = "Text_Image2"
        Me.Text_Image2.ReadOnly = True
        Me.Text_Image2.Size = New System.Drawing.Size(393, 25)
        Me.Text_Image2.TabIndex = 43
        '
        'Check_ProcessEverySubfolder
        '
        Me.Check_ProcessEverySubfolder.AutoSize = True
        Me.Check_ProcessEverySubfolder.Location = New System.Drawing.Point(20, 31)
        Me.Check_ProcessEverySubfolder.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Check_ProcessEverySubfolder.Name = "Check_ProcessEverySubfolder"
        Me.Check_ProcessEverySubfolder.Size = New System.Drawing.Size(188, 21)
        Me.Check_ProcessEverySubfolder.TabIndex = 48
        Me.Check_ProcessEverySubfolder.Text = "Process every subfolder"
        Me.Check_ProcessEverySubfolder.UseVisualStyleBackColor = True
        '
        'Tab_Config
        '
        Me.Tab_Config.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab_Config.Controls.Add(Me.Tab_Binarization)
        Me.Tab_Config.Controls.Add(Me.Tab_RegionExtraction)
        Me.Tab_Config.Controls.Add(Me.Tab_Processing)
        Me.Tab_Config.Location = New System.Drawing.Point(15, 341)
        Me.Tab_Config.Name = "Tab_Config"
        Me.Tab_Config.SelectedIndex = 0
        Me.Tab_Config.Size = New System.Drawing.Size(514, 181)
        Me.Tab_Config.TabIndex = 43
        '
        'Tab_Binarization
        '
        Me.Tab_Binarization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_Binarization.Controls.Add(Me.Combo_Binarization_PreblurringSize)
        Me.Tab_Binarization.Controls.Add(Me.Cmd_TestBinarization)
        Me.Tab_Binarization.Controls.Add(Me.Check_Binarization_Preblurring)
        Me.Tab_Binarization.Controls.Add(Me.Cmd_SetBinarization)
        Me.Tab_Binarization.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Binarization.Name = "Tab_Binarization"
        Me.Tab_Binarization.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Binarization.Size = New System.Drawing.Size(506, 148)
        Me.Tab_Binarization.TabIndex = 0
        Me.Tab_Binarization.Text = "[1] Binarization"
        Me.Tab_Binarization.UseVisualStyleBackColor = True
        '
        'Tab_RegionExtraction
        '
        Me.Tab_RegionExtraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_RegionExtraction.Controls.Add(Me.Cmd_SetAdaptive)
        Me.Tab_RegionExtraction.Controls.Add(Me.Combo_Subtraction_PreblurringSize)
        Me.Tab_RegionExtraction.Controls.Add(Me.Check_Subtraction_Preblurring)
        Me.Tab_RegionExtraction.Controls.Add(Me.Cmd_TestRegionExtract)
        Me.Tab_RegionExtraction.Location = New System.Drawing.Point(4, 29)
        Me.Tab_RegionExtraction.Name = "Tab_RegionExtraction"
        Me.Tab_RegionExtraction.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_RegionExtraction.Size = New System.Drawing.Size(506, 148)
        Me.Tab_RegionExtraction.TabIndex = 1
        Me.Tab_RegionExtraction.Text = "[2] Region extraction"
        Me.Tab_RegionExtraction.UseVisualStyleBackColor = True
        '
        'Tab_Processing
        '
        Me.Tab_Processing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_Processing.Controls.Add(Me.Label1)
        Me.Tab_Processing.Controls.Add(Me.Label2)
        Me.Tab_Processing.Controls.Add(Me.Text_ConfineTo)
        Me.Tab_Processing.Controls.Add(Me.Text_ConfineFrom)
        Me.Tab_Processing.Controls.Add(Me.Check_Confine)
        Me.Tab_Processing.Controls.Add(Me.Check_ProcessEverySubfolder)
        Me.Tab_Processing.Controls.Add(Me.Cmd_Process)
        Me.Tab_Processing.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Processing.Name = "Tab_Processing"
        Me.Tab_Processing.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Processing.Size = New System.Drawing.Size(506, 148)
        Me.Tab_Processing.TabIndex = 2
        Me.Tab_Processing.Text = "[3] Processing"
        Me.Tab_Processing.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "File #  from"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 17)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "to"
        '
        'Text_ConfineTo
        '
        Me.Text_ConfineTo.Enabled = False
        Me.Text_ConfineTo.Location = New System.Drawing.Point(237, 97)
        Me.Text_ConfineTo.Name = "Text_ConfineTo"
        Me.Text_ConfineTo.Size = New System.Drawing.Size(53, 25)
        Me.Text_ConfineTo.TabIndex = 51
        Me.Text_ConfineTo.Text = "100"
        '
        'Text_ConfineFrom
        '
        Me.Text_ConfineFrom.Enabled = False
        Me.Text_ConfineFrom.Location = New System.Drawing.Point(152, 97)
        Me.Text_ConfineFrom.Name = "Text_ConfineFrom"
        Me.Text_ConfineFrom.Size = New System.Drawing.Size(53, 25)
        Me.Text_ConfineFrom.TabIndex = 50
        Me.Text_ConfineFrom.Text = "1"
        '
        'Check_Confine
        '
        Me.Check_Confine.AutoSize = True
        Me.Check_Confine.Location = New System.Drawing.Point(20, 68)
        Me.Check_Confine.Name = "Check_Confine"
        Me.Check_Confine.Size = New System.Drawing.Size(181, 21)
        Me.Check_Confine.TabIndex = 49
        Me.Check_Confine.Text = "Confine source images"
        Me.Check_Confine.UseVisualStyleBackColor = True
        '
        'Text_TimeIntervalSec
        '
        Me.Text_TimeIntervalSec.Location = New System.Drawing.Point(404, 56)
        Me.Text_TimeIntervalSec.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Text_TimeIntervalSec.Name = "Text_TimeIntervalSec"
        Me.Text_TimeIntervalSec.Size = New System.Drawing.Size(46, 25)
        Me.Text_TimeIntervalSec.TabIndex = 50
        Me.Text_TimeIntervalSec.Text = "1"
        Me.Text_TimeIntervalSec.Visible = False
        '
        'Radio_WithFixedInterval
        '
        Me.Radio_WithFixedInterval.AutoSize = True
        Me.Radio_WithFixedInterval.Location = New System.Drawing.Point(25, 57)
        Me.Radio_WithFixedInterval.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Radio_WithFixedInterval.Name = "Radio_WithFixedInterval"
        Me.Radio_WithFixedInterval.Size = New System.Drawing.Size(328, 21)
        Me.Radio_WithFixedInterval.TabIndex = 53
        Me.Radio_WithFixedInterval.Text = "Find the next image at a specified time interval"
        Me.Radio_WithFixedInterval.UseVisualStyleBackColor = True
        '
        'Group_TimeInterval
        '
        Me.Group_TimeInterval.Controls.Add(Me.Radio_WithFixedInterval)
        Me.Group_TimeInterval.Controls.Add(Me.Radio_WithoutFixedInterval)
        Me.Group_TimeInterval.Controls.Add(Me.Text_TimeIntervalSec)
        Me.Group_TimeInterval.Controls.Add(Me.Label_TimeInterval)
        Me.Group_TimeInterval.Location = New System.Drawing.Point(13, 100)
        Me.Group_TimeInterval.Margin = New System.Windows.Forms.Padding(5)
        Me.Group_TimeInterval.Name = "Group_TimeInterval"
        Me.Group_TimeInterval.Padding = New System.Windows.Forms.Padding(5)
        Me.Group_TimeInterval.Size = New System.Drawing.Size(511, 95)
        Me.Group_TimeInterval.TabIndex = 42
        Me.Group_TimeInterval.TabStop = False
        Me.Group_TimeInterval.Text = "Analysis interval"
        '
        'Radio_WithoutFixedInterval
        '
        Me.Radio_WithoutFixedInterval.AutoSize = True
        Me.Radio_WithoutFixedInterval.Checked = True
        Me.Radio_WithoutFixedInterval.Location = New System.Drawing.Point(25, 28)
        Me.Radio_WithoutFixedInterval.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Radio_WithoutFixedInterval.Name = "Radio_WithoutFixedInterval"
        Me.Radio_WithoutFixedInterval.Size = New System.Drawing.Size(326, 21)
        Me.Radio_WithoutFixedInterval.TabIndex = 52
        Me.Radio_WithoutFixedInterval.TabStop = True
        Me.Radio_WithoutFixedInterval.Text = "Select next image without regular time interval"
        Me.Radio_WithoutFixedInterval.UseVisualStyleBackColor = True
        '
        'Label_TimeInterval
        '
        Me.Label_TimeInterval.AutoSize = True
        Me.Label_TimeInterval.Location = New System.Drawing.Point(459, 59)
        Me.Label_TimeInterval.Name = "Label_TimeInterval"
        Me.Label_TimeInterval.Size = New System.Drawing.Size(32, 17)
        Me.Label_TimeInterval.TabIndex = 49
        Me.Label_TimeInterval.Text = "sec"
        Me.Label_TimeInterval.Visible = False
        '
        'Frm_Tracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 537)
        Me.Controls.Add(Me.Tab_Config)
        Me.Controls.Add(Me.Group_TimeInterval)
        Me.Controls.Add(Me.Group_TestImage)
        Me.Controls.Add(Me.Group_Source)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Tracker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tracker"
        Me.Group_Source.ResumeLayout(False)
        Me.Group_Source.PerformLayout()
        Me.Group_TestImage.ResumeLayout(False)
        Me.Group_TestImage.PerformLayout()
        Me.Tab_Config.ResumeLayout(False)
        Me.Tab_Binarization.ResumeLayout(False)
        Me.Tab_Binarization.PerformLayout()
        Me.Tab_RegionExtraction.ResumeLayout(False)
        Me.Tab_RegionExtraction.PerformLayout()
        Me.Tab_Processing.ResumeLayout(False)
        Me.Tab_Processing.PerformLayout()
        Me.Group_TimeInterval.ResumeLayout(False)
        Me.Group_TimeInterval.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Group_Source As GroupBox
    Friend WithEvents Cmd_Process As Button
    Friend WithEvents Cmd_CustomFolder_Set As Button
    Friend WithEvents Text_SourceFolder As TextBox
    Friend WithEvents FolderDialog_SourceImage As FolderBrowserDialog
    Friend WithEvents Cmd_SetBinarization As Button
    Friend WithEvents Cmd_TestRegionExtract As Button
    Friend WithEvents Cmd_TestBinarization As Button
    Friend WithEvents Check_Binarization_Preblurring As CheckBox
    Friend WithEvents Check_Subtraction_Preblurring As CheckBox
    Friend WithEvents Text_Image1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Group_TestImage As GroupBox
    Friend WithEvents Combo_Binarization_PreblurringSize As ComboBox
    Friend WithEvents Combo_Subtraction_PreblurringSize As ComboBox
    Friend WithEvents Check_ProcessEverySubfolder As CheckBox
    Friend WithEvents Cmd_SetAdaptive As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Text_Image2 As TextBox
    Friend WithEvents Tab_Config As TabControl
    Friend WithEvents Tab_Binarization As TabPage
    Friend WithEvents Tab_RegionExtraction As TabPage
    Friend WithEvents Tab_Processing As TabPage
    Friend WithEvents Text_ConfineTo As TextBox
    Friend WithEvents Text_ConfineFrom As TextBox
    Friend WithEvents Check_Confine As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Text_TimeIntervalSec As TextBox
    Friend WithEvents Radio_WithFixedInterval As RadioButton
    Friend WithEvents Group_TimeInterval As GroupBox
    Friend WithEvents Radio_WithoutFixedInterval As RadioButton
    Friend WithEvents Label_TimeInterval As Label
End Class

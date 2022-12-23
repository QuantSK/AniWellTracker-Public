<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Reviewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Reviewer))
        Me.Group_Source = New System.Windows.Forms.GroupBox()
        Me.Cmd_CustomFolder_Set = New System.Windows.Forms.Button()
        Me.Text_SourceFolder = New System.Windows.Forms.TextBox()
        Me.Cmd_RePostProcessing = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Check_Track_Location = New System.Windows.Forms.CheckBox()
        Me.Combo_ImageOrTime = New System.Windows.Forms.ComboBox()
        Me.Text_TrackLength = New System.Windows.Forms.TextBox()
        Me.Check_Track = New System.Windows.Forms.CheckBox()
        Me.Check_AngleLine = New System.Windows.Forms.CheckBox()
        Me.Check_ObjectLocation = New System.Windows.Forms.CheckBox()
        Me.Text_CropMargin = New System.Windows.Forms.TextBox()
        Me.Label_CropMargin = New System.Windows.Forms.Label()
        Me.Cmd_OpenLogFile = New System.Windows.Forms.Button()
        Me.Cmd_StartSaving = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_FileTo = New System.Windows.Forms.TextBox()
        Me.Text_FileFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_Well = New System.Windows.Forms.ComboBox()
        Me.Radio_SingleWell = New System.Windows.Forms.RadioButton()
        Me.Radio_EntireImage = New System.Windows.Forms.RadioButton()
        Me.FolderDialog_SourceImage = New System.Windows.Forms.FolderBrowserDialog()
        Me.Tab_Function = New System.Windows.Forms.TabControl()
        Me.Tab_Image = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Text_SaveInterval = New System.Windows.Forms.TextBox()
        Me.Cmd_EveryWell = New System.Windows.Forms.Button()
        Me.Cmd_CopyWellB = New System.Windows.Forms.Button()
        Me.Cmd_CopyWellA = New System.Windows.Forms.Button()
        Me.Tab_Reprocessing = New System.Windows.Forms.TabPage()
        Me.Text_BlockDurationMin = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Tab_TimeSeriesHeatMap = New System.Windows.Forms.TabPage()
        Me.Cmd_DistanceFromCenter = New System.Windows.Forms.Button()
        Me.Cmd_CentralAngle = New System.Windows.Forms.Button()
        Me.Cmd_DeltaRotation = New System.Windows.Forms.Button()
        Me.Cmd_TravelSpeed = New System.Windows.Forms.Button()
        Me.Cmd_AverageTravelSpeed1M = New System.Windows.Forms.Button()
        Me.Cmd_TravelDistance = New System.Windows.Forms.Button()
        Me.Cmd_TotalTravelDistance1M = New System.Windows.Forms.Button()
        Me.Tab_LocationHeatmap = New System.Windows.Forms.TabPage()
        Me.Combo_FilterSize = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Check_Contour = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Pic_Gradientbar_Loc = New System.Windows.Forms.PictureBox()
        Me.Combo_ColorSpectrum_Loc = New System.Windows.Forms.ComboBox()
        Me.Cmd_CreateLocationHeatmap = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Text_ValueMax_Loc = New System.Windows.Forms.TextBox()
        Me.Text_ValueMin_Loc = New System.Windows.Forms.TextBox()
        Me.Text_ConfineTo_Loc = New System.Windows.Forms.TextBox()
        Me.Text_ConfineFrom_Loc = New System.Windows.Forms.TextBox()
        Me.Cmd_DrawHeatmap_Location = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Text_GridSizeN_Loc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Check_Confine_Loc = New System.Windows.Forms.CheckBox()
        Me.Tab_DistFromCenterHeatmap = New System.Windows.Forms.TabPage()
        Me.Pic_Gradientbar_Dis = New System.Windows.Forms.PictureBox()
        Me.Combo_ColorSpectrum_Dis = New System.Windows.Forms.ComboBox()
        Me.Cmd_CreateDistanceFromCenterHeatmap = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text_ConfineTo_Dis = New System.Windows.Forms.TextBox()
        Me.Text_ConfineFrom_Dis = New System.Windows.Forms.TextBox()
        Me.Cmd_DrawDistanceFromCenterHeatmap = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Text_GridSizeN_Dis = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Check_Confine_Dis = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Group_Source.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Tab_Function.SuspendLayout()
        Me.Tab_Image.SuspendLayout()
        Me.Tab_Reprocessing.SuspendLayout()
        Me.Tab_TimeSeriesHeatMap.SuspendLayout()
        Me.Tab_LocationHeatmap.SuspendLayout()
        CType(Me.Pic_Gradientbar_Loc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_DistFromCenterHeatmap.SuspendLayout()
        CType(Me.Pic_Gradientbar_Dis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Group_Source
        '
        Me.Group_Source.Controls.Add(Me.Cmd_CustomFolder_Set)
        Me.Group_Source.Controls.Add(Me.Text_SourceFolder)
        Me.Group_Source.Location = New System.Drawing.Point(14, 15)
        Me.Group_Source.Margin = New System.Windows.Forms.Padding(5)
        Me.Group_Source.Name = "Group_Source"
        Me.Group_Source.Padding = New System.Windows.Forms.Padding(5)
        Me.Group_Source.Size = New System.Drawing.Size(516, 75)
        Me.Group_Source.TabIndex = 37
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
        Me.Text_SourceFolder.Text = "E:\My Imaging\20181009 Zlarvae_5ppm_set1"
        '
        'Cmd_RePostProcessing
        '
        Me.Cmd_RePostProcessing.Location = New System.Drawing.Point(38, 44)
        Me.Cmd_RePostProcessing.Name = "Cmd_RePostProcessing"
        Me.Cmd_RePostProcessing.Size = New System.Drawing.Size(290, 50)
        Me.Cmd_RePostProcessing.TabIndex = 7
        Me.Cmd_RePostProcessing.Text = "Conduct reprocessing"
        Me.Cmd_RePostProcessing.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Check_Track_Location)
        Me.GroupBox2.Controls.Add(Me.Combo_ImageOrTime)
        Me.GroupBox2.Controls.Add(Me.Text_TrackLength)
        Me.GroupBox2.Controls.Add(Me.Check_Track)
        Me.GroupBox2.Controls.Add(Me.Check_AngleLine)
        Me.GroupBox2.Controls.Add(Me.Check_ObjectLocation)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(518, 114)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Render option"
        '
        'Check_Track_Location
        '
        Me.Check_Track_Location.AutoSize = True
        Me.Check_Track_Location.Checked = True
        Me.Check_Track_Location.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_Track_Location.Location = New System.Drawing.Point(289, 67)
        Me.Check_Track_Location.Name = "Check_Track_Location"
        Me.Check_Track_Location.Size = New System.Drawing.Size(121, 21)
        Me.Check_Track_Location.TabIndex = 43
        Me.Check_Track_Location.Text = "Show location"
        Me.Check_Track_Location.UseVisualStyleBackColor = True
        '
        'Combo_ImageOrTime
        '
        Me.Combo_ImageOrTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_ImageOrTime.Enabled = False
        Me.Combo_ImageOrTime.FormattingEnabled = True
        Me.Combo_ImageOrTime.Items.AddRange(New Object() {"Images", "Time (sec)", "Time (min)"})
        Me.Combo_ImageOrTime.Location = New System.Drawing.Point(166, 67)
        Me.Combo_ImageOrTime.Name = "Combo_ImageOrTime"
        Me.Combo_ImageOrTime.Size = New System.Drawing.Size(104, 25)
        Me.Combo_ImageOrTime.TabIndex = 42
        '
        'Text_TrackLength
        '
        Me.Text_TrackLength.Location = New System.Drawing.Point(97, 68)
        Me.Text_TrackLength.Name = "Text_TrackLength"
        Me.Text_TrackLength.Size = New System.Drawing.Size(54, 25)
        Me.Text_TrackLength.TabIndex = 41
        Me.Text_TrackLength.Text = "20"
        '
        'Check_Track
        '
        Me.Check_Track.AutoSize = True
        Me.Check_Track.Checked = True
        Me.Check_Track.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_Track.Location = New System.Drawing.Point(22, 71)
        Me.Check_Track.Name = "Check_Track"
        Me.Check_Track.Size = New System.Drawing.Size(66, 21)
        Me.Check_Track.TabIndex = 40
        Me.Check_Track.Text = "Track"
        Me.Check_Track.UseVisualStyleBackColor = True
        '
        'Check_AngleLine
        '
        Me.Check_AngleLine.AutoSize = True
        Me.Check_AngleLine.Location = New System.Drawing.Point(190, 27)
        Me.Check_AngleLine.Name = "Check_AngleLine"
        Me.Check_AngleLine.Size = New System.Drawing.Size(116, 21)
        Me.Check_AngleLine.TabIndex = 1
        Me.Check_AngleLine.Text = "Central angle"
        Me.Check_AngleLine.UseVisualStyleBackColor = True
        '
        'Check_ObjectLocation
        '
        Me.Check_ObjectLocation.AutoSize = True
        Me.Check_ObjectLocation.Checked = True
        Me.Check_ObjectLocation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_ObjectLocation.Location = New System.Drawing.Point(22, 27)
        Me.Check_ObjectLocation.Name = "Check_ObjectLocation"
        Me.Check_ObjectLocation.Size = New System.Drawing.Size(127, 21)
        Me.Check_ObjectLocation.TabIndex = 0
        Me.Check_ObjectLocation.Text = "Object location"
        Me.Check_ObjectLocation.UseVisualStyleBackColor = True
        '
        'Text_CropMargin
        '
        Me.Text_CropMargin.Location = New System.Drawing.Point(268, 62)
        Me.Text_CropMargin.Name = "Text_CropMargin"
        Me.Text_CropMargin.Size = New System.Drawing.Size(50, 25)
        Me.Text_CropMargin.TabIndex = 45
        Me.Text_CropMargin.Text = "40"
        '
        'Label_CropMargin
        '
        Me.Label_CropMargin.AutoSize = True
        Me.Label_CropMargin.Location = New System.Drawing.Point(165, 66)
        Me.Label_CropMargin.Name = "Label_CropMargin"
        Me.Label_CropMargin.Size = New System.Drawing.Size(89, 17)
        Me.Label_CropMargin.TabIndex = 44
        Me.Label_CropMargin.Text = "Crop margin"
        '
        'Cmd_OpenLogFile
        '
        Me.Cmd_OpenLogFile.Image = CType(resources.GetObject("Cmd_OpenLogFile.Image"), System.Drawing.Image)
        Me.Cmd_OpenLogFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_OpenLogFile.Location = New System.Drawing.Point(351, 153)
        Me.Cmd_OpenLogFile.Name = "Cmd_OpenLogFile"
        Me.Cmd_OpenLogFile.Size = New System.Drawing.Size(140, 44)
        Me.Cmd_OpenLogFile.TabIndex = 43
        Me.Cmd_OpenLogFile.Text = "  Open folder"
        Me.Cmd_OpenLogFile.UseVisualStyleBackColor = True
        '
        'Cmd_StartSaving
        '
        Me.Cmd_StartSaving.Location = New System.Drawing.Point(205, 153)
        Me.Cmd_StartSaving.Name = "Cmd_StartSaving"
        Me.Cmd_StartSaving.Size = New System.Drawing.Size(140, 44)
        Me.Cmd_StartSaving.TabIndex = 42
        Me.Cmd_StartSaving.Text = "Start saving"
        Me.Cmd_StartSaving.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 17)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "to"
        '
        'Text_FileTo
        '
        Me.Text_FileTo.Location = New System.Drawing.Point(99, 140)
        Me.Text_FileTo.Name = "Text_FileTo"
        Me.Text_FileTo.Size = New System.Drawing.Size(50, 25)
        Me.Text_FileTo.TabIndex = 5
        Me.Text_FileTo.Text = "50000"
        '
        'Text_FileFrom
        '
        Me.Text_FileFrom.Location = New System.Drawing.Point(99, 103)
        Me.Text_FileFrom.Name = "Text_FileFrom"
        Me.Text_FileFrom.Size = New System.Drawing.Size(50, 25)
        Me.Text_FileFrom.TabIndex = 4
        Me.Text_FileFrom.Text = "100"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File # from"
        '
        'Combo_Well
        '
        Me.Combo_Well.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Well.FormattingEnabled = True
        Me.Combo_Well.Location = New System.Drawing.Point(247, 16)
        Me.Combo_Well.Name = "Combo_Well"
        Me.Combo_Well.Size = New System.Drawing.Size(71, 25)
        Me.Combo_Well.TabIndex = 2
        '
        'Radio_SingleWell
        '
        Me.Radio_SingleWell.AutoSize = True
        Me.Radio_SingleWell.Location = New System.Drawing.Point(9, 44)
        Me.Radio_SingleWell.Name = "Radio_SingleWell"
        Me.Radio_SingleWell.Size = New System.Drawing.Size(98, 21)
        Me.Radio_SingleWell.TabIndex = 1
        Me.Radio_SingleWell.Text = "Single well"
        Me.Radio_SingleWell.UseVisualStyleBackColor = True
        '
        'Radio_EntireImage
        '
        Me.Radio_EntireImage.AutoSize = True
        Me.Radio_EntireImage.Checked = True
        Me.Radio_EntireImage.Location = New System.Drawing.Point(9, 17)
        Me.Radio_EntireImage.Name = "Radio_EntireImage"
        Me.Radio_EntireImage.Size = New System.Drawing.Size(111, 21)
        Me.Radio_EntireImage.TabIndex = 0
        Me.Radio_EntireImage.TabStop = True
        Me.Radio_EntireImage.Text = "Entire image"
        Me.Radio_EntireImage.UseVisualStyleBackColor = True
        '
        'Tab_Function
        '
        Me.Tab_Function.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab_Function.Controls.Add(Me.Tab_Image)
        Me.Tab_Function.Controls.Add(Me.Tab_Reprocessing)
        Me.Tab_Function.Controls.Add(Me.Tab_TimeSeriesHeatMap)
        Me.Tab_Function.Controls.Add(Me.Tab_LocationHeatmap)
        Me.Tab_Function.Controls.Add(Me.Tab_DistFromCenterHeatmap)
        Me.Tab_Function.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Tab_Function.HotTrack = True
        Me.Tab_Function.Location = New System.Drawing.Point(13, 250)
        Me.Tab_Function.Multiline = True
        Me.Tab_Function.Name = "Tab_Function"
        Me.Tab_Function.SelectedIndex = 0
        Me.Tab_Function.Size = New System.Drawing.Size(517, 275)
        Me.Tab_Function.TabIndex = 41
        '
        'Tab_Image
        '
        Me.Tab_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_Image.Controls.Add(Me.Label9)
        Me.Tab_Image.Controls.Add(Me.Label15)
        Me.Tab_Image.Controls.Add(Me.Text_SaveInterval)
        Me.Tab_Image.Controls.Add(Me.Cmd_EveryWell)
        Me.Tab_Image.Controls.Add(Me.Cmd_CopyWellB)
        Me.Tab_Image.Controls.Add(Me.Cmd_CopyWellA)
        Me.Tab_Image.Controls.Add(Me.Text_CropMargin)
        Me.Tab_Image.Controls.Add(Me.Radio_EntireImage)
        Me.Tab_Image.Controls.Add(Me.Label_CropMargin)
        Me.Tab_Image.Controls.Add(Me.Radio_SingleWell)
        Me.Tab_Image.Controls.Add(Me.Cmd_OpenLogFile)
        Me.Tab_Image.Controls.Add(Me.Combo_Well)
        Me.Tab_Image.Controls.Add(Me.Cmd_StartSaving)
        Me.Tab_Image.Controls.Add(Me.Label1)
        Me.Tab_Image.Controls.Add(Me.Label2)
        Me.Tab_Image.Controls.Add(Me.Text_FileFrom)
        Me.Tab_Image.Controls.Add(Me.Text_FileTo)
        Me.Tab_Image.Location = New System.Drawing.Point(4, 57)
        Me.Tab_Image.Name = "Tab_Image"
        Me.Tab_Image.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Image.Size = New System.Drawing.Size(509, 214)
        Me.Tab_Image.TabIndex = 0
        Me.Tab_Image.Text = "Image"
        Me.Tab_Image.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(51, 180)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 17)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "step"
        '
        'Text_SaveInterval
        '
        Me.Text_SaveInterval.Location = New System.Drawing.Point(99, 177)
        Me.Text_SaveInterval.Name = "Text_SaveInterval"
        Me.Text_SaveInterval.Size = New System.Drawing.Size(50, 25)
        Me.Text_SaveInterval.TabIndex = 48
        Me.Text_SaveInterval.Text = "100"
        '
        'Cmd_EveryWell
        '
        Me.Cmd_EveryWell.Location = New System.Drawing.Point(351, 100)
        Me.Cmd_EveryWell.Name = "Cmd_EveryWell"
        Me.Cmd_EveryWell.Size = New System.Drawing.Size(140, 36)
        Me.Cmd_EveryWell.TabIndex = 47
        Me.Cmd_EveryWell.Text = "Save every well"
        Me.Cmd_EveryWell.UseVisualStyleBackColor = True
        '
        'Cmd_CopyWellB
        '
        Me.Cmd_CopyWellB.Location = New System.Drawing.Point(351, 56)
        Me.Cmd_CopyWellB.Name = "Cmd_CopyWellB"
        Me.Cmd_CopyWellB.Size = New System.Drawing.Size(140, 36)
        Me.Cmd_CopyWellB.TabIndex = 46
        Me.Cmd_CopyWellB.Text = "Copy well image B"
        Me.Cmd_CopyWellB.UseVisualStyleBackColor = True
        '
        'Cmd_CopyWellA
        '
        Me.Cmd_CopyWellA.Location = New System.Drawing.Point(351, 12)
        Me.Cmd_CopyWellA.Name = "Cmd_CopyWellA"
        Me.Cmd_CopyWellA.Size = New System.Drawing.Size(140, 36)
        Me.Cmd_CopyWellA.TabIndex = 43
        Me.Cmd_CopyWellA.Text = "Copy well image A"
        Me.Cmd_CopyWellA.UseVisualStyleBackColor = True
        '
        'Tab_Reprocessing
        '
        Me.Tab_Reprocessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_Reprocessing.Controls.Add(Me.Text_BlockDurationMin)
        Me.Tab_Reprocessing.Controls.Add(Me.Label17)
        Me.Tab_Reprocessing.Controls.Add(Me.Cmd_RePostProcessing)
        Me.Tab_Reprocessing.Location = New System.Drawing.Point(4, 57)
        Me.Tab_Reprocessing.Name = "Tab_Reprocessing"
        Me.Tab_Reprocessing.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Reprocessing.Size = New System.Drawing.Size(509, 214)
        Me.Tab_Reprocessing.TabIndex = 1
        Me.Tab_Reprocessing.Text = "Reprocessing"
        Me.Tab_Reprocessing.UseVisualStyleBackColor = True
        '
        'Text_BlockDurationMin
        '
        Me.Text_BlockDurationMin.Location = New System.Drawing.Point(232, 133)
        Me.Text_BlockDurationMin.Name = "Text_BlockDurationMin"
        Me.Text_BlockDurationMin.Size = New System.Drawing.Size(51, 25)
        Me.Text_BlockDurationMin.TabIndex = 20
        Me.Text_BlockDurationMin.Text = "15"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(35, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(172, 17)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Time block duration (min)"
        '
        'Tab_TimeSeriesHeatMap
        '
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_DistanceFromCenter)
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_CentralAngle)
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_DeltaRotation)
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_TravelSpeed)
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_AverageTravelSpeed1M)
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_TravelDistance)
        Me.Tab_TimeSeriesHeatMap.Controls.Add(Me.Cmd_TotalTravelDistance1M)
        Me.Tab_TimeSeriesHeatMap.Location = New System.Drawing.Point(4, 57)
        Me.Tab_TimeSeriesHeatMap.Name = "Tab_TimeSeriesHeatMap"
        Me.Tab_TimeSeriesHeatMap.Size = New System.Drawing.Size(509, 214)
        Me.Tab_TimeSeriesHeatMap.TabIndex = 3
        Me.Tab_TimeSeriesHeatMap.Text = "Time series heatmap"
        Me.Tab_TimeSeriesHeatMap.UseVisualStyleBackColor = True
        '
        'Cmd_DistanceFromCenter
        '
        Me.Cmd_DistanceFromCenter.ForeColor = System.Drawing.Color.Black
        Me.Cmd_DistanceFromCenter.Location = New System.Drawing.Point(16, 83)
        Me.Cmd_DistanceFromCenter.Name = "Cmd_DistanceFromCenter"
        Me.Cmd_DistanceFromCenter.Size = New System.Drawing.Size(171, 53)
        Me.Cmd_DistanceFromCenter.TabIndex = 44
        Me.Cmd_DistanceFromCenter.Text = "Distance from center (Every data)"
        Me.Cmd_DistanceFromCenter.UseVisualStyleBackColor = True
        '
        'Cmd_CentralAngle
        '
        Me.Cmd_CentralAngle.ForeColor = System.Drawing.Color.Black
        Me.Cmd_CentralAngle.Location = New System.Drawing.Point(261, 23)
        Me.Cmd_CentralAngle.Name = "Cmd_CentralAngle"
        Me.Cmd_CentralAngle.Size = New System.Drawing.Size(109, 53)
        Me.Cmd_CentralAngle.TabIndex = 43
        Me.Cmd_CentralAngle.Text = "Central angle (Every data)"
        Me.Cmd_CentralAngle.UseVisualStyleBackColor = True
        '
        'Cmd_DeltaRotation
        '
        Me.Cmd_DeltaRotation.ForeColor = System.Drawing.Color.Black
        Me.Cmd_DeltaRotation.Location = New System.Drawing.Point(376, 23)
        Me.Cmd_DeltaRotation.Name = "Cmd_DeltaRotation"
        Me.Cmd_DeltaRotation.Size = New System.Drawing.Size(121, 53)
        Me.Cmd_DeltaRotation.TabIndex = 42
        Me.Cmd_DeltaRotation.Text = "Delta rotation (Every data)"
        Me.Cmd_DeltaRotation.UseVisualStyleBackColor = True
        '
        'Cmd_TravelSpeed
        '
        Me.Cmd_TravelSpeed.ForeColor = System.Drawing.Color.Black
        Me.Cmd_TravelSpeed.Location = New System.Drawing.Point(16, 23)
        Me.Cmd_TravelSpeed.Name = "Cmd_TravelSpeed"
        Me.Cmd_TravelSpeed.Size = New System.Drawing.Size(112, 53)
        Me.Cmd_TravelSpeed.TabIndex = 14
        Me.Cmd_TravelSpeed.Text = "Travel speed (Every data)"
        Me.Cmd_TravelSpeed.UseVisualStyleBackColor = True
        '
        'Cmd_AverageTravelSpeed1M
        '
        Me.Cmd_AverageTravelSpeed1M.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_AverageTravelSpeed1M.Location = New System.Drawing.Point(17, 142)
        Me.Cmd_AverageTravelSpeed1M.Name = "Cmd_AverageTravelSpeed1M"
        Me.Cmd_AverageTravelSpeed1M.Size = New System.Drawing.Size(171, 53)
        Me.Cmd_AverageTravelSpeed1M.TabIndex = 17
        Me.Cmd_AverageTravelSpeed1M.Text = "Average travel speed (Each time block)"
        Me.Cmd_AverageTravelSpeed1M.UseVisualStyleBackColor = True
        '
        'Cmd_TravelDistance
        '
        Me.Cmd_TravelDistance.ForeColor = System.Drawing.Color.Black
        Me.Cmd_TravelDistance.Location = New System.Drawing.Point(134, 23)
        Me.Cmd_TravelDistance.Name = "Cmd_TravelDistance"
        Me.Cmd_TravelDistance.Size = New System.Drawing.Size(121, 53)
        Me.Cmd_TravelDistance.TabIndex = 16
        Me.Cmd_TravelDistance.Text = "Travel distance (Every data)"
        Me.Cmd_TravelDistance.UseVisualStyleBackColor = True
        '
        'Cmd_TotalTravelDistance1M
        '
        Me.Cmd_TotalTravelDistance1M.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_TotalTravelDistance1M.Location = New System.Drawing.Point(194, 142)
        Me.Cmd_TotalTravelDistance1M.Name = "Cmd_TotalTravelDistance1M"
        Me.Cmd_TotalTravelDistance1M.Size = New System.Drawing.Size(158, 53)
        Me.Cmd_TotalTravelDistance1M.TabIndex = 18
        Me.Cmd_TotalTravelDistance1M.Text = "Total travel distance (Each time block)"
        Me.Cmd_TotalTravelDistance1M.UseVisualStyleBackColor = True
        '
        'Tab_LocationHeatmap
        '
        Me.Tab_LocationHeatmap.Controls.Add(Me.Combo_FilterSize)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Label7)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Check_Contour)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Label8)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Pic_Gradientbar_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Combo_ColorSpectrum_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Cmd_CreateLocationHeatmap)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Label6)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Text_ValueMax_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Text_ValueMin_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Text_ConfineTo_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Text_ConfineFrom_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Cmd_DrawHeatmap_Location)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Label5)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Text_GridSizeN_Loc)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Label4)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Label3)
        Me.Tab_LocationHeatmap.Controls.Add(Me.Check_Confine_Loc)
        Me.Tab_LocationHeatmap.Location = New System.Drawing.Point(4, 57)
        Me.Tab_LocationHeatmap.Name = "Tab_LocationHeatmap"
        Me.Tab_LocationHeatmap.Size = New System.Drawing.Size(509, 214)
        Me.Tab_LocationHeatmap.TabIndex = 2
        Me.Tab_LocationHeatmap.Text = "Location heatmap"
        Me.Tab_LocationHeatmap.UseVisualStyleBackColor = True
        '
        'Combo_FilterSize
        '
        Me.Combo_FilterSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_FilterSize.FormattingEnabled = True
        Me.Combo_FilterSize.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Combo_FilterSize.Location = New System.Drawing.Point(438, 51)
        Me.Combo_FilterSize.Name = "Combo_FilterSize"
        Me.Combo_FilterSize.Size = New System.Drawing.Size(48, 25)
        Me.Combo_FilterSize.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(363, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 17)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Filter size"
        '
        'Check_Contour
        '
        Me.Check_Contour.AutoSize = True
        Me.Check_Contour.Checked = True
        Me.Check_Contour.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_Contour.Location = New System.Drawing.Point(272, 53)
        Me.Check_Contour.Name = "Check_Contour"
        Me.Check_Contour.Size = New System.Drawing.Size(82, 21)
        Me.Check_Contour.TabIndex = 70
        Me.Check_Contour.Text = "Contour"
        Me.Check_Contour.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(267, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 17)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Value range"
        '
        'Pic_Gradientbar_Loc
        '
        Me.Pic_Gradientbar_Loc.BackColor = System.Drawing.Color.White
        Me.Pic_Gradientbar_Loc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Gradientbar_Loc.Location = New System.Drawing.Point(270, 119)
        Me.Pic_Gradientbar_Loc.Name = "Pic_Gradientbar_Loc"
        Me.Pic_Gradientbar_Loc.Size = New System.Drawing.Size(215, 31)
        Me.Pic_Gradientbar_Loc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Gradientbar_Loc.TabIndex = 68
        Me.Pic_Gradientbar_Loc.TabStop = False
        '
        'Combo_ColorSpectrum_Loc
        '
        Me.Combo_ColorSpectrum_Loc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_ColorSpectrum_Loc.FormattingEnabled = True
        Me.Combo_ColorSpectrum_Loc.Items.AddRange(New Object() {"1 (Color spectrum 1)", "2 (Color spectrum 2)", "3 (Blue to Red)", "4 (White to Black)", "5 (Blue to Yellow)", "6 (MatLab default)"})
        Me.Combo_ColorSpectrum_Loc.Location = New System.Drawing.Point(270, 86)
        Me.Combo_ColorSpectrum_Loc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Combo_ColorSpectrum_Loc.Name = "Combo_ColorSpectrum_Loc"
        Me.Combo_ColorSpectrum_Loc.Size = New System.Drawing.Size(215, 25)
        Me.Combo_ColorSpectrum_Loc.TabIndex = 66
        '
        'Cmd_CreateLocationHeatmap
        '
        Me.Cmd_CreateLocationHeatmap.Location = New System.Drawing.Point(22, 156)
        Me.Cmd_CreateLocationHeatmap.Name = "Cmd_CreateLocationHeatmap"
        Me.Cmd_CreateLocationHeatmap.Size = New System.Drawing.Size(177, 45)
        Me.Cmd_CreateLocationHeatmap.TabIndex = 55
        Me.Cmd_CreateLocationHeatmap.Text = "Re-processing"
        Me.Cmd_CreateLocationHeatmap.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 17)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "~"
        '
        'Text_ValueMax_Loc
        '
        Me.Text_ValueMax_Loc.Location = New System.Drawing.Point(433, 14)
        Me.Text_ValueMax_Loc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_ValueMax_Loc.Name = "Text_ValueMax_Loc"
        Me.Text_ValueMax_Loc.Size = New System.Drawing.Size(52, 25)
        Me.Text_ValueMax_Loc.TabIndex = 63
        Me.Text_ValueMax_Loc.Text = "400"
        '
        'Text_ValueMin_Loc
        '
        Me.Text_ValueMin_Loc.Location = New System.Drawing.Point(356, 14)
        Me.Text_ValueMin_Loc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Text_ValueMin_Loc.Name = "Text_ValueMin_Loc"
        Me.Text_ValueMin_Loc.Size = New System.Drawing.Size(52, 25)
        Me.Text_ValueMin_Loc.TabIndex = 62
        Me.Text_ValueMin_Loc.Text = "0"
        '
        'Text_ConfineTo_Loc
        '
        Me.Text_ConfineTo_Loc.Location = New System.Drawing.Point(173, 47)
        Me.Text_ConfineTo_Loc.Name = "Text_ConfineTo_Loc"
        Me.Text_ConfineTo_Loc.Size = New System.Drawing.Size(53, 25)
        Me.Text_ConfineTo_Loc.TabIndex = 54
        Me.Text_ConfineTo_Loc.Text = "100"
        '
        'Text_ConfineFrom_Loc
        '
        Me.Text_ConfineFrom_Loc.Location = New System.Drawing.Point(91, 47)
        Me.Text_ConfineFrom_Loc.Name = "Text_ConfineFrom_Loc"
        Me.Text_ConfineFrom_Loc.Size = New System.Drawing.Size(53, 25)
        Me.Text_ConfineFrom_Loc.TabIndex = 53
        Me.Text_ConfineFrom_Loc.Text = "1"
        '
        'Cmd_DrawHeatmap_Location
        '
        Me.Cmd_DrawHeatmap_Location.Location = New System.Drawing.Point(271, 156)
        Me.Cmd_DrawHeatmap_Location.Name = "Cmd_DrawHeatmap_Location"
        Me.Cmd_DrawHeatmap_Location.Size = New System.Drawing.Size(215, 45)
        Me.Cmd_DrawHeatmap_Location.TabIndex = 61
        Me.Cmd_DrawHeatmap_Location.Text = "Draw heatmap on image"
        Me.Cmd_DrawHeatmap_Location.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 17)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "to"
        '
        'Text_GridSizeN_Loc
        '
        Me.Text_GridSizeN_Loc.Location = New System.Drawing.Point(110, 101)
        Me.Text_GridSizeN_Loc.Name = "Text_GridSizeN_Loc"
        Me.Text_GridSizeN_Loc.Size = New System.Drawing.Size(57, 25)
        Me.Text_GridSizeN_Loc.TabIndex = 60
        Me.Text_GridSizeN_Loc.Text = "15"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 17)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "File #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Grid size N"
        '
        'Check_Confine_Loc
        '
        Me.Check_Confine_Loc.AutoSize = True
        Me.Check_Confine_Loc.Location = New System.Drawing.Point(21, 17)
        Me.Check_Confine_Loc.Name = "Check_Confine_Loc"
        Me.Check_Confine_Loc.Size = New System.Drawing.Size(181, 21)
        Me.Check_Confine_Loc.TabIndex = 52
        Me.Check_Confine_Loc.Text = "Confine source images"
        Me.Check_Confine_Loc.UseVisualStyleBackColor = True
        '
        'Tab_DistFromCenterHeatmap
        '
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Pic_Gradientbar_Dis)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Combo_ColorSpectrum_Dis)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Cmd_CreateDistanceFromCenterHeatmap)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Label10)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Text_ConfineTo_Dis)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Text_ConfineFrom_Dis)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Cmd_DrawDistanceFromCenterHeatmap)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Label12)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Text_GridSizeN_Dis)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Label13)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Label14)
        Me.Tab_DistFromCenterHeatmap.Controls.Add(Me.Check_Confine_Dis)
        Me.Tab_DistFromCenterHeatmap.Location = New System.Drawing.Point(4, 57)
        Me.Tab_DistFromCenterHeatmap.Name = "Tab_DistFromCenterHeatmap"
        Me.Tab_DistFromCenterHeatmap.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_DistFromCenterHeatmap.Size = New System.Drawing.Size(509, 214)
        Me.Tab_DistFromCenterHeatmap.TabIndex = 4
        Me.Tab_DistFromCenterHeatmap.Text = "Distance from center heatmap"
        Me.Tab_DistFromCenterHeatmap.UseVisualStyleBackColor = True
        '
        'Pic_Gradientbar_Dis
        '
        Me.Pic_Gradientbar_Dis.BackColor = System.Drawing.Color.White
        Me.Pic_Gradientbar_Dis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Gradientbar_Dis.Location = New System.Drawing.Point(271, 88)
        Me.Pic_Gradientbar_Dis.Name = "Pic_Gradientbar_Dis"
        Me.Pic_Gradientbar_Dis.Size = New System.Drawing.Size(215, 28)
        Me.Pic_Gradientbar_Dis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Gradientbar_Dis.TabIndex = 100
        Me.Pic_Gradientbar_Dis.TabStop = False
        '
        'Combo_ColorSpectrum_Dis
        '
        Me.Combo_ColorSpectrum_Dis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_ColorSpectrum_Dis.FormattingEnabled = True
        Me.Combo_ColorSpectrum_Dis.Items.AddRange(New Object() {"1 (Color spectrum 1)", "2 (Color spectrum 2)", "3 (Blue to Red)", "4 (White to Black)", "5 (Blue to Yellow)", "6 (MatLab default)"})
        Me.Combo_ColorSpectrum_Dis.Location = New System.Drawing.Point(271, 55)
        Me.Combo_ColorSpectrum_Dis.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Combo_ColorSpectrum_Dis.Name = "Combo_ColorSpectrum_Dis"
        Me.Combo_ColorSpectrum_Dis.Size = New System.Drawing.Size(215, 25)
        Me.Combo_ColorSpectrum_Dis.TabIndex = 99
        '
        'Cmd_CreateDistanceFromCenterHeatmap
        '
        Me.Cmd_CreateDistanceFromCenterHeatmap.Location = New System.Drawing.Point(22, 152)
        Me.Cmd_CreateDistanceFromCenterHeatmap.Name = "Cmd_CreateDistanceFromCenterHeatmap"
        Me.Cmd_CreateDistanceFromCenterHeatmap.Size = New System.Drawing.Size(177, 40)
        Me.Cmd_CreateDistanceFromCenterHeatmap.TabIndex = 89
        Me.Cmd_CreateDistanceFromCenterHeatmap.Text = "Re-processing"
        Me.Cmd_CreateDistanceFromCenterHeatmap.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(268, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 17)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Color bar"
        '
        'Text_ConfineTo_Dis
        '
        Me.Text_ConfineTo_Dis.Location = New System.Drawing.Point(174, 52)
        Me.Text_ConfineTo_Dis.Name = "Text_ConfineTo_Dis"
        Me.Text_ConfineTo_Dis.Size = New System.Drawing.Size(53, 25)
        Me.Text_ConfineTo_Dis.TabIndex = 88
        Me.Text_ConfineTo_Dis.Text = "100"
        '
        'Text_ConfineFrom_Dis
        '
        Me.Text_ConfineFrom_Dis.Location = New System.Drawing.Point(92, 52)
        Me.Text_ConfineFrom_Dis.Name = "Text_ConfineFrom_Dis"
        Me.Text_ConfineFrom_Dis.Size = New System.Drawing.Size(53, 25)
        Me.Text_ConfineFrom_Dis.TabIndex = 87
        Me.Text_ConfineFrom_Dis.Text = "1"
        '
        'Cmd_DrawDistanceFromCenterHeatmap
        '
        Me.Cmd_DrawDistanceFromCenterHeatmap.Location = New System.Drawing.Point(271, 152)
        Me.Cmd_DrawDistanceFromCenterHeatmap.Name = "Cmd_DrawDistanceFromCenterHeatmap"
        Me.Cmd_DrawDistanceFromCenterHeatmap.Size = New System.Drawing.Size(215, 40)
        Me.Cmd_DrawDistanceFromCenterHeatmap.TabIndex = 94
        Me.Cmd_DrawDistanceFromCenterHeatmap.Text = "Draw heatmap on image"
        Me.Cmd_DrawDistanceFromCenterHeatmap.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(148, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 17)
        Me.Label12.TabIndex = 91
        Me.Label12.Text = "to"
        '
        'Text_GridSizeN_Dis
        '
        Me.Text_GridSizeN_Dis.Location = New System.Drawing.Point(111, 99)
        Me.Text_GridSizeN_Dis.Name = "Text_GridSizeN_Dis"
        Me.Text_GridSizeN_Dis.Size = New System.Drawing.Size(57, 25)
        Me.Text_GridSizeN_Dis.TabIndex = 93
        Me.Text_GridSizeN_Dis.Text = "15"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(36, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 17)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "File #"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(26, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 17)
        Me.Label14.TabIndex = 92
        Me.Label14.Text = "Grid size N"
        '
        'Check_Confine_Dis
        '
        Me.Check_Confine_Dis.AutoSize = True
        Me.Check_Confine_Dis.Location = New System.Drawing.Point(22, 25)
        Me.Check_Confine_Dis.Name = "Check_Confine_Dis"
        Me.Check_Confine_Dis.Size = New System.Drawing.Size(181, 21)
        Me.Check_Confine_Dis.TabIndex = 86
        Me.Check_Confine_Dis.Text = "Confine source images"
        Me.Check_Confine_Dis.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(181, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Well #"
        '
        'Frm_Reviewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 537)
        Me.Controls.Add(Me.Tab_Function)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Group_Source)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Reviewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reviewer"
        Me.Group_Source.ResumeLayout(False)
        Me.Group_Source.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Tab_Function.ResumeLayout(False)
        Me.Tab_Image.ResumeLayout(False)
        Me.Tab_Image.PerformLayout()
        Me.Tab_Reprocessing.ResumeLayout(False)
        Me.Tab_Reprocessing.PerformLayout()
        Me.Tab_TimeSeriesHeatMap.ResumeLayout(False)
        Me.Tab_LocationHeatmap.ResumeLayout(False)
        Me.Tab_LocationHeatmap.PerformLayout()
        CType(Me.Pic_Gradientbar_Loc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_DistFromCenterHeatmap.ResumeLayout(False)
        Me.Tab_DistFromCenterHeatmap.PerformLayout()
        CType(Me.Pic_Gradientbar_Dis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Group_Source As GroupBox
    Friend WithEvents Cmd_CustomFolder_Set As Button
    Friend WithEvents Text_SourceFolder As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Check_ObjectLocation As CheckBox
    Friend WithEvents Combo_ImageOrTime As ComboBox
    Friend WithEvents Text_TrackLength As TextBox
    Friend WithEvents Check_Track As CheckBox
    Friend WithEvents Check_AngleLine As CheckBox
    Friend WithEvents Combo_Well As ComboBox
    Friend WithEvents Radio_SingleWell As RadioButton
    Friend WithEvents Radio_EntireImage As RadioButton
    Friend WithEvents Cmd_StartSaving As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Text_FileTo As TextBox
    Friend WithEvents Text_FileFrom As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderDialog_SourceImage As FolderBrowserDialog
    Friend WithEvents Check_Track_Location As CheckBox
    Friend WithEvents Cmd_RePostProcessing As Button
    Friend WithEvents Cmd_OpenLogFile As Button
    Friend WithEvents Text_CropMargin As TextBox
    Friend WithEvents Label_CropMargin As Label
    Friend WithEvents Tab_Function As TabControl
    Friend WithEvents Tab_Image As TabPage
    Friend WithEvents Tab_Reprocessing As TabPage
    Friend WithEvents Tab_LocationHeatmap As TabPage
    Friend WithEvents Cmd_CreateLocationHeatmap As Button
    Friend WithEvents Text_ConfineTo_Loc As TextBox
    Friend WithEvents Text_ConfineFrom_Loc As TextBox
    Friend WithEvents Check_Confine_Loc As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Text_GridSizeN_Loc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmd_DrawHeatmap_Location As Button
    Friend WithEvents Pic_Gradientbar_Loc As PictureBox
    Friend WithEvents Combo_ColorSpectrum_Loc As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Text_ValueMax_Loc As TextBox
    Friend WithEvents Text_ValueMin_Loc As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Cmd_CopyWellB As Button
    Friend WithEvents Cmd_CopyWellA As Button
    Friend WithEvents Cmd_TravelSpeed As Button
    Friend WithEvents Check_Contour As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Combo_FilterSize As ComboBox
    Friend WithEvents Cmd_EveryWell As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Text_SaveInterval As TextBox
    Friend WithEvents Cmd_TravelDistance As Button
    Friend WithEvents Cmd_TotalTravelDistance1M As Button
    Friend WithEvents Cmd_AverageTravelSpeed1M As Button
    Friend WithEvents Text_BlockDurationMin As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Tab_TimeSeriesHeatMap As TabPage
    Friend WithEvents Cmd_DistanceFromCenter As Button
    Friend WithEvents Cmd_CentralAngle As Button
    Friend WithEvents Cmd_DeltaRotation As Button
    Friend WithEvents Tab_DistFromCenterHeatmap As TabPage
    Friend WithEvents Pic_Gradientbar_Dis As PictureBox
    Friend WithEvents Combo_ColorSpectrum_Dis As ComboBox
    Friend WithEvents Cmd_CreateDistanceFromCenterHeatmap As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Text_ConfineTo_Dis As TextBox
    Friend WithEvents Text_ConfineFrom_Dis As TextBox
    Friend WithEvents Cmd_DrawDistanceFromCenterHeatmap As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Text_GridSizeN_Dis As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Check_Confine_Dis As CheckBox
    Friend WithEvents Label9 As Label
End Class

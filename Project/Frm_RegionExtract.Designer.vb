<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegionExtract
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegionExtract))
        Me.Cmd_OK = New System.Windows.Forms.Button()
        Me.Cmd_Cancel = New System.Windows.Forms.Button()
        Me.Grid_Statistics = New System.Windows.Forms.DataGridView()
        Me.Check_Labeling = New System.Windows.Forms.CheckBox()
        Me.Combo_Color_Preset = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_Copy = New System.Windows.Forms.Button()
        Me.Check_Preview = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_AreaMin = New System.Windows.Forms.TextBox()
        Me.Cmd_Analyze = New System.Windows.Forms.Button()
        Me.Text_NumbOfRegion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Check_CenterPoint = New System.Windows.Forms.CheckBox()
        Me.Text_CenterPointSize = New System.Windows.Forms.TextBox()
        Me.Label_CenterPointSize = New System.Windows.Forms.Label()
        Me.Group_UseScreeningCondition = New System.Windows.Forms.GroupBox()
        Me.Check_LimitMaxObjects = New System.Windows.Forms.CheckBox()
        Me.Combo_SortBy = New System.Windows.Forms.ComboBox()
        Me.Label_SortBy = New System.Windows.Forms.Label()
        Me.Text_ObjectMax = New System.Windows.Forms.TextBox()
        Me.Text_WidthHeightMax = New System.Windows.Forms.TextBox()
        Me.Text_AreaMax = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Text_WidthHeightMin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Check_UseScreenCondition = New System.Windows.Forms.CheckBox()
        Me.LabelNumb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CenterX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CenterY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Height = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.X1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.X2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Grid_Statistics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_UseScreeningCondition.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_OK
        '
        Me.Cmd_OK.Location = New System.Drawing.Point(449, 11)
        Me.Cmd_OK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cmd_OK.Name = "Cmd_OK"
        Me.Cmd_OK.Size = New System.Drawing.Size(100, 42)
        Me.Cmd_OK.TabIndex = 15
        Me.Cmd_OK.Text = "OK"
        Me.Cmd_OK.UseVisualStyleBackColor = True
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cmd_Cancel.Location = New System.Drawing.Point(555, 11)
        Me.Cmd_Cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(100, 42)
        Me.Cmd_Cancel.TabIndex = 14
        Me.Cmd_Cancel.Text = "Cancel"
        Me.Cmd_Cancel.UseVisualStyleBackColor = True
        '
        'Grid_Statistics
        '
        Me.Grid_Statistics.AllowUserToAddRows = False
        Me.Grid_Statistics.AllowUserToDeleteRows = False
        Me.Grid_Statistics.AllowUserToResizeColumns = False
        Me.Grid_Statistics.AllowUserToResizeRows = False
        Me.Grid_Statistics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid_Statistics.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid_Statistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Statistics.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LabelNumb, Me.Area, Me.CenterX, Me.CenterY, Me.Width, Me.Height, Me.ColorCode, Me.X1, Me.Y1, Me.X2, Me.Y2})
        Me.Grid_Statistics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid_Statistics.Location = New System.Drawing.Point(14, 240)
        Me.Grid_Statistics.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid_Statistics.MultiSelect = False
        Me.Grid_Statistics.Name = "Grid_Statistics"
        Me.Grid_Statistics.RowHeadersVisible = False
        Me.Grid_Statistics.RowHeadersWidth = 51
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Grid_Statistics.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Grid_Statistics.RowTemplate.Height = 23
        Me.Grid_Statistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_Statistics.Size = New System.Drawing.Size(641, 259)
        Me.Grid_Statistics.TabIndex = 16
        '
        'Check_Labeling
        '
        Me.Check_Labeling.AutoSize = True
        Me.Check_Labeling.Checked = True
        Me.Check_Labeling.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_Labeling.Location = New System.Drawing.Point(120, 43)
        Me.Check_Labeling.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Check_Labeling.Name = "Check_Labeling"
        Me.Check_Labeling.Size = New System.Drawing.Size(84, 21)
        Me.Check_Labeling.TabIndex = 17
        Me.Check_Labeling.Text = "Labeling"
        Me.Check_Labeling.UseVisualStyleBackColor = True
        '
        'Combo_Color_Preset
        '
        Me.Combo_Color_Preset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_Color_Preset.Enabled = False
        Me.Combo_Color_Preset.FormattingEnabled = True
        Me.Combo_Color_Preset.Items.AddRange(New Object() {"Black", "White"})
        Me.Combo_Color_Preset.Location = New System.Drawing.Point(146, 11)
        Me.Combo_Color_Preset.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Combo_Color_Preset.Name = "Combo_Color_Preset"
        Me.Combo_Color_Preset.Size = New System.Drawing.Size(137, 25)
        Me.Combo_Color_Preset.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Background color"
        '
        'Cmd_Copy
        '
        Me.Cmd_Copy.Image = CType(resources.GetObject("Cmd_Copy.Image"), System.Drawing.Image)
        Me.Cmd_Copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Copy.Location = New System.Drawing.Point(526, 206)
        Me.Cmd_Copy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cmd_Copy.Name = "Cmd_Copy"
        Me.Cmd_Copy.Size = New System.Drawing.Size(129, 26)
        Me.Cmd_Copy.TabIndex = 21
        Me.Cmd_Copy.Text = "   Copy table"
        Me.Cmd_Copy.UseVisualStyleBackColor = True
        '
        'Check_Preview
        '
        Me.Check_Preview.AutoSize = True
        Me.Check_Preview.Checked = True
        Me.Check_Preview.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_Preview.Location = New System.Drawing.Point(18, 43)
        Me.Check_Preview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Check_Preview.Name = "Check_Preview"
        Me.Check_Preview.Size = New System.Drawing.Size(82, 21)
        Me.Check_Preview.TabIndex = 22
        Me.Check_Preview.Text = "Preview"
        Me.Check_Preview.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Area Min"
        '
        'Text_AreaMin
        '
        Me.Text_AreaMin.Location = New System.Drawing.Point(84, 22)
        Me.Text_AreaMin.Name = "Text_AreaMin"
        Me.Text_AreaMin.Size = New System.Drawing.Size(45, 25)
        Me.Text_AreaMin.TabIndex = 24
        Me.Text_AreaMin.Text = "15"
        '
        'Cmd_Analyze
        '
        Me.Cmd_Analyze.Image = CType(resources.GetObject("Cmd_Analyze.Image"), System.Drawing.Image)
        Me.Cmd_Analyze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Analyze.Location = New System.Drawing.Point(555, 76)
        Me.Cmd_Analyze.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cmd_Analyze.Name = "Cmd_Analyze"
        Me.Cmd_Analyze.Size = New System.Drawing.Size(100, 28)
        Me.Cmd_Analyze.TabIndex = 25
        Me.Cmd_Analyze.Text = "     Update"
        Me.Cmd_Analyze.UseVisualStyleBackColor = True
        '
        'Text_NumbOfRegion
        '
        Me.Text_NumbOfRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Text_NumbOfRegion.Enabled = False
        Me.Text_NumbOfRegion.Location = New System.Drawing.Point(146, 509)
        Me.Text_NumbOfRegion.Name = "Text_NumbOfRegion"
        Me.Text_NumbOfRegion.Size = New System.Drawing.Size(59, 25)
        Me.Text_NumbOfRegion.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 512)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 17)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Number of regions"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(220, 533)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(326, 17)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "* For the best result, use black and white image!!"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(328, 17)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "* Double click on Workspace window to find color"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(220, 509)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 17)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "* Every region has different color"
        '
        'Check_CenterPoint
        '
        Me.Check_CenterPoint.AutoSize = True
        Me.Check_CenterPoint.Location = New System.Drawing.Point(215, 43)
        Me.Check_CenterPoint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Check_CenterPoint.Name = "Check_CenterPoint"
        Me.Check_CenterPoint.Size = New System.Drawing.Size(109, 21)
        Me.Check_CenterPoint.TabIndex = 57
        Me.Check_CenterPoint.Text = "Center point"
        Me.Check_CenterPoint.UseVisualStyleBackColor = True
        '
        'Text_CenterPointSize
        '
        Me.Text_CenterPointSize.Location = New System.Drawing.Point(354, 41)
        Me.Text_CenterPointSize.Name = "Text_CenterPointSize"
        Me.Text_CenterPointSize.Size = New System.Drawing.Size(29, 25)
        Me.Text_CenterPointSize.TabIndex = 59
        Me.Text_CenterPointSize.Text = "5"
        '
        'Label_CenterPointSize
        '
        Me.Label_CenterPointSize.AutoSize = True
        Me.Label_CenterPointSize.Location = New System.Drawing.Point(311, 44)
        Me.Label_CenterPointSize.Name = "Label_CenterPointSize"
        Me.Label_CenterPointSize.Size = New System.Drawing.Size(37, 17)
        Me.Label_CenterPointSize.TabIndex = 58
        Me.Label_CenterPointSize.Text = "Size"
        '
        'Group_UseScreeningCondition
        '
        Me.Group_UseScreeningCondition.Controls.Add(Me.Check_LimitMaxObjects)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Combo_SortBy)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Label_SortBy)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Text_ObjectMax)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Text_WidthHeightMax)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Text_AreaMax)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Label8)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Label7)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Text_WidthHeightMin)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Text_AreaMin)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Label9)
        Me.Group_UseScreeningCondition.Controls.Add(Me.Label2)
        Me.Group_UseScreeningCondition.Location = New System.Drawing.Point(14, 99)
        Me.Group_UseScreeningCondition.Name = "Group_UseScreeningCondition"
        Me.Group_UseScreeningCondition.Size = New System.Drawing.Size(641, 93)
        Me.Group_UseScreeningCondition.TabIndex = 60
        Me.Group_UseScreeningCondition.TabStop = False
        '
        'Check_LimitMaxObjects
        '
        Me.Check_LimitMaxObjects.AutoSize = True
        Me.Check_LimitMaxObjects.Checked = True
        Me.Check_LimitMaxObjects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_LimitMaxObjects.Location = New System.Drawing.Point(353, 23)
        Me.Check_LimitMaxObjects.Name = "Check_LimitMaxObjects"
        Me.Check_LimitMaxObjects.Size = New System.Drawing.Size(199, 21)
        Me.Check_LimitMaxObjects.TabIndex = 73
        Me.Check_LimitMaxObjects.Text = "Limit max objects per ROI"
        Me.Check_LimitMaxObjects.UseVisualStyleBackColor = True
        '
        'Combo_SortBy
        '
        Me.Combo_SortBy.AutoCompleteCustomSource.AddRange(New String() {"Area", "CenterX", "CenterY", "Width", "Height", "X1", "Y1", "X2", "Y2"})
        Me.Combo_SortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_SortBy.FormattingEnabled = True
        Me.Combo_SortBy.Items.AddRange(New Object() {"Area", "CenterX", "CenterY", "Width", "Height", "X1", "Y1", "X2", "Y2"})
        Me.Combo_SortBy.Location = New System.Drawing.Point(500, 53)
        Me.Combo_SortBy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Combo_SortBy.Name = "Combo_SortBy"
        Me.Combo_SortBy.Size = New System.Drawing.Size(114, 25)
        Me.Combo_SortBy.TabIndex = 62
        '
        'Label_SortBy
        '
        Me.Label_SortBy.AutoSize = True
        Me.Label_SortBy.Location = New System.Drawing.Point(421, 57)
        Me.Label_SortBy.Name = "Label_SortBy"
        Me.Label_SortBy.Size = New System.Drawing.Size(54, 17)
        Me.Label_SortBy.TabIndex = 71
        Me.Label_SortBy.Text = "Sort by"
        '
        'Text_ObjectMax
        '
        Me.Text_ObjectMax.Location = New System.Drawing.Point(569, 21)
        Me.Text_ObjectMax.Name = "Text_ObjectMax"
        Me.Text_ObjectMax.Size = New System.Drawing.Size(45, 25)
        Me.Text_ObjectMax.TabIndex = 71
        Me.Text_ObjectMax.Text = "1"
        '
        'Text_WidthHeightMax
        '
        Me.Text_WidthHeightMax.Location = New System.Drawing.Point(273, 54)
        Me.Text_WidthHeightMax.Name = "Text_WidthHeightMax"
        Me.Text_WidthHeightMax.Size = New System.Drawing.Size(45, 25)
        Me.Text_WidthHeightMax.TabIndex = 65
        Me.Text_WidthHeightMax.Text = "30"
        '
        'Text_AreaMax
        '
        Me.Text_AreaMax.Location = New System.Drawing.Point(84, 54)
        Me.Text_AreaMax.Name = "Text_AreaMax"
        Me.Text_AreaMax.Size = New System.Drawing.Size(45, 25)
        Me.Text_AreaMax.TabIndex = 26
        Me.Text_AreaMax.Text = "120"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(144, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 17)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Width(Height) Max"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Area Max"
        '
        'Text_WidthHeightMin
        '
        Me.Text_WidthHeightMin.Location = New System.Drawing.Point(273, 22)
        Me.Text_WidthHeightMin.Name = "Text_WidthHeightMin"
        Me.Text_WidthHeightMin.Size = New System.Drawing.Size(45, 25)
        Me.Text_WidthHeightMin.TabIndex = 63
        Me.Text_WidthHeightMin.Text = "3"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(144, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 17)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Width(Height) Min"
        '
        'Check_UseScreenCondition
        '
        Me.Check_UseScreenCondition.AutoSize = True
        Me.Check_UseScreenCondition.Checked = True
        Me.Check_UseScreenCondition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_UseScreenCondition.Location = New System.Drawing.Point(18, 80)
        Me.Check_UseScreenCondition.Name = "Check_UseScreenCondition"
        Me.Check_UseScreenCondition.Size = New System.Drawing.Size(186, 21)
        Me.Check_UseScreenCondition.TabIndex = 61
        Me.Check_UseScreenCondition.Text = "Use screening condition"
        Me.Check_UseScreenCondition.UseVisualStyleBackColor = True
        '
        'LabelNumb
        '
        Me.LabelNumb.HeaderText = "#"
        Me.LabelNumb.MinimumWidth = 6
        Me.LabelNumb.Name = "LabelNumb"
        Me.LabelNumb.Width = 40
        '
        'Area
        '
        Me.Area.HeaderText = "Area"
        Me.Area.MinimumWidth = 6
        Me.Area.Name = "Area"
        Me.Area.Width = 70
        '
        'CenterX
        '
        Me.CenterX.HeaderText = "Center X"
        Me.CenterX.MinimumWidth = 6
        Me.CenterX.Name = "CenterX"
        Me.CenterX.Width = 60
        '
        'CenterY
        '
        Me.CenterY.HeaderText = "Center Y"
        Me.CenterY.MinimumWidth = 6
        Me.CenterY.Name = "CenterY"
        Me.CenterY.Width = 60
        '
        'Width
        '
        Me.Width.HeaderText = "Width"
        Me.Width.MinimumWidth = 6
        Me.Width.Name = "Width"
        Me.Width.Width = 60
        '
        'Height
        '
        Me.Height.HeaderText = "Height"
        Me.Height.MinimumWidth = 6
        Me.Height.Name = "Height"
        Me.Height.Width = 60
        '
        'ColorCode
        '
        Me.ColorCode.HeaderText = "Color"
        Me.ColorCode.MinimumWidth = 6
        Me.ColorCode.Name = "ColorCode"
        Me.ColorCode.Width = 80
        '
        'X1
        '
        Me.X1.HeaderText = "X1"
        Me.X1.MinimumWidth = 6
        Me.X1.Name = "X1"
        Me.X1.Width = 60
        '
        'Y1
        '
        Me.Y1.HeaderText = "Y1"
        Me.Y1.MinimumWidth = 6
        Me.Y1.Name = "Y1"
        Me.Y1.Width = 60
        '
        'X2
        '
        Me.X2.HeaderText = "X2"
        Me.X2.MinimumWidth = 6
        Me.X2.Name = "X2"
        Me.X2.Width = 60
        '
        'Y2
        '
        Me.Y2.HeaderText = "Y2"
        Me.Y2.MinimumWidth = 6
        Me.Y2.Name = "Y2"
        Me.Y2.Width = 60
        '
        'Frm_RegionExtract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cmd_Cancel
        Me.ClientSize = New System.Drawing.Size(668, 558)
        Me.Controls.Add(Me.Check_UseScreenCondition)
        Me.Controls.Add(Me.Cmd_Analyze)
        Me.Controls.Add(Me.Group_UseScreeningCondition)
        Me.Controls.Add(Me.Text_CenterPointSize)
        Me.Controls.Add(Me.Label_CenterPointSize)
        Me.Controls.Add(Me.Check_CenterPoint)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Text_NumbOfRegion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Check_Preview)
        Me.Controls.Add(Me.Cmd_Copy)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo_Color_Preset)
        Me.Controls.Add(Me.Check_Labeling)
        Me.Controls.Add(Me.Grid_Statistics)
        Me.Controls.Add(Me.Cmd_OK)
        Me.Controls.Add(Me.Cmd_Cancel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RegionExtract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Region Labeling"
        Me.TopMost = True
        CType(Me.Grid_Statistics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_UseScreeningCondition.ResumeLayout(False)
        Me.Group_UseScreeningCondition.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmd_OK As System.Windows.Forms.Button
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Grid_Statistics As System.Windows.Forms.DataGridView
    Friend WithEvents Check_Labeling As System.Windows.Forms.CheckBox
    Friend WithEvents Combo_Color_Preset As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Copy As System.Windows.Forms.Button
    Friend WithEvents Check_Preview As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_AreaMin As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Analyze As System.Windows.Forms.Button
    Friend WithEvents Text_NumbOfRegion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Check_CenterPoint As CheckBox
    Friend WithEvents Text_CenterPointSize As TextBox
    Friend WithEvents Label_CenterPointSize As Label
    Friend WithEvents Group_UseScreeningCondition As GroupBox
    Friend WithEvents Text_WidthHeightMax As TextBox
    Friend WithEvents Text_AreaMax As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Text_WidthHeightMin As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Check_UseScreenCondition As CheckBox
    Friend WithEvents Text_ObjectMax As TextBox
    Friend WithEvents Combo_SortBy As ComboBox
    Friend WithEvents Label_SortBy As Label
    Friend WithEvents Check_LimitMaxObjects As CheckBox
    Friend WithEvents LabelNumb As DataGridViewTextBoxColumn
    Friend WithEvents Area As DataGridViewTextBoxColumn
    Friend WithEvents CenterX As DataGridViewTextBoxColumn
    Friend WithEvents CenterY As DataGridViewTextBoxColumn
    Friend WithEvents Width As DataGridViewTextBoxColumn
    Friend WithEvents Height As DataGridViewTextBoxColumn
    Friend WithEvents ColorCode As DataGridViewTextBoxColumn
    Friend WithEvents X1 As DataGridViewTextBoxColumn
    Friend WithEvents Y1 As DataGridViewTextBoxColumn
    Friend WithEvents X2 As DataGridViewTextBoxColumn
    Friend WithEvents Y2 As DataGridViewTextBoxColumn
End Class

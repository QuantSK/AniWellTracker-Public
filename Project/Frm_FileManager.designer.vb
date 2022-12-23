<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FileManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FileManager))
        Me.Cmd_Rescan = New System.Windows.Forms.Button()
        Me.Label_FileCount = New System.Windows.Forms.Label()
        Me.FolderDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.DirSearcher = New System.DirectoryServices.DirectorySearcher()
        Me.Label_FileNum = New System.Windows.Forms.Label()
        Me.FileListBox = New AniWellTracker.FileListBox()
        Me.SuspendLayout()
        '
        'Cmd_Rescan
        '
        Me.Cmd_Rescan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_Rescan.Image = CType(resources.GetObject("Cmd_Rescan.Image"), System.Drawing.Image)
        Me.Cmd_Rescan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Rescan.Location = New System.Drawing.Point(416, 203)
        Me.Cmd_Rescan.Name = "Cmd_Rescan"
        Me.Cmd_Rescan.Size = New System.Drawing.Size(112, 39)
        Me.Cmd_Rescan.TabIndex = 7
        Me.Cmd_Rescan.Text = "     Refresh"
        Me.Cmd_Rescan.UseVisualStyleBackColor = True
        '
        'Label_FileCount
        '
        Me.Label_FileCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_FileCount.AutoSize = True
        Me.Label_FileCount.Location = New System.Drawing.Point(12, 214)
        Me.Label_FileCount.Name = "Label_FileCount"
        Me.Label_FileCount.Size = New System.Drawing.Size(120, 17)
        Me.Label_FileCount.TabIndex = 7
        Me.Label_FileCount.Text = "Total 0 files found"
        '
        'DirSearcher
        '
        Me.DirSearcher.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirSearcher.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirSearcher.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'Label_FileNum
        '
        Me.Label_FileNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_FileNum.AutoSize = True
        Me.Label_FileNum.Location = New System.Drawing.Point(223, 215)
        Me.Label_FileNum.Name = "Label_FileNum"
        Me.Label_FileNum.Size = New System.Drawing.Size(47, 17)
        Me.Label_FileNum.TabIndex = 8
        Me.Label_FileNum.Text = "File #:"
        '
        'FileListBox
        '
        Me.FileListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileListBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FileListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FileListBox.CurrentFullPath = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE"
        Me.FileListBox.ExtFilter = ""
        Me.FileListBox.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FileListBox.Location = New System.Drawing.Point(8, 12)
        Me.FileListBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FileListBox.Name = "FileListBox"
        Me.FileListBox.Size = New System.Drawing.Size(520, 184)
        Me.FileListBox.TabIndex = 6
        '
        'Frm_FileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 249)
        Me.Controls.Add(Me.Label_FileNum)
        Me.Controls.Add(Me.Label_FileCount)
        Me.Controls.Add(Me.Cmd_Rescan)
        Me.Controls.Add(Me.FileListBox)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_FileManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "File Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileListBox As FileListBox
    ' Friend WithEvents DirSearcher As System.DirectoryServices.DirectorySearcher
    Friend WithEvents Cmd_Rescan As System.Windows.Forms.Button
    Friend WithEvents Label_FileCount As System.Windows.Forms.Label
    Friend WithEvents FolderDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DirSearcher As DirectoryServices.DirectorySearcher
    Friend WithEvents Label_FileNum As Label
End Class

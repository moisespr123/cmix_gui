﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.InputFileMessage = New System.Windows.Forms.Label()
        Me.InputFileTxt = New System.Windows.Forms.TextBox()
        Me.OutputFileMessage = New System.Windows.Forms.Label()
        Me.OutputFileTxt = New System.Windows.Forms.TextBox()
        Me.ActionGroupBox = New System.Windows.Forms.GroupBox()
        Me.PreprocessRButton = New System.Windows.Forms.RadioButton()
        Me.ExtractRButton = New System.Windows.Forms.RadioButton()
        Me.CompressRButton = New System.Windows.Forms.RadioButton()
        Me.cmixVersionToUseLabel = New System.Windows.Forms.Label()
        Me.cmixVersionDropdown = New System.Windows.Forms.ComboBox()
        Me.BrowseButton1 = New System.Windows.Forms.Button()
        Me.BrowseButton2 = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.AboutLabel1 = New System.Windows.Forms.Label()
        Me.AboutLabel2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.BrowseFolder = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.UseEngDictCheckbox = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SpanishRButton = New System.Windows.Forms.RadioButton()
        Me.EnglishRButton = New System.Windows.Forms.RadioButton()
        Me.ActionGroupBox.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'InputFileMessage
        '
        Me.InputFileMessage.AutoSize = True
        Me.InputFileMessage.Location = New System.Drawing.Point(9, 70)
        Me.InputFileMessage.Name = "InputFileMessage"
        Me.InputFileMessage.Size = New System.Drawing.Size(223, 13)
        Me.InputFileMessage.TabIndex = 0
        Me.InputFileMessage.Text = "Step 1: Browse for a file or folder to compress:"
        '
        'InputFileTxt
        '
        Me.InputFileTxt.Location = New System.Drawing.Point(12, 86)
        Me.InputFileTxt.Name = "InputFileTxt"
        Me.InputFileTxt.Size = New System.Drawing.Size(237, 20)
        Me.InputFileTxt.TabIndex = 3
        '
        'OutputFileMessage
        '
        Me.OutputFileMessage.AutoSize = True
        Me.OutputFileMessage.Location = New System.Drawing.Point(9, 109)
        Me.OutputFileMessage.Name = "OutputFileMessage"
        Me.OutputFileMessage.Size = New System.Drawing.Size(240, 13)
        Me.OutputFileMessage.TabIndex = 2
        Me.OutputFileMessage.Text = "Step 2: Browse for a location to save the archive:"
        '
        'OutputFileTxt
        '
        Me.OutputFileTxt.Location = New System.Drawing.Point(12, 125)
        Me.OutputFileTxt.Name = "OutputFileTxt"
        Me.OutputFileTxt.Size = New System.Drawing.Size(237, 20)
        Me.OutputFileTxt.TabIndex = 6
        '
        'ActionGroupBox
        '
        Me.ActionGroupBox.Controls.Add(Me.PreprocessRButton)
        Me.ActionGroupBox.Controls.Add(Me.ExtractRButton)
        Me.ActionGroupBox.Controls.Add(Me.CompressRButton)
        Me.ActionGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.ActionGroupBox.Name = "ActionGroupBox"
        Me.ActionGroupBox.Size = New System.Drawing.Size(276, 46)
        Me.ActionGroupBox.TabIndex = 4
        Me.ActionGroupBox.TabStop = False
        Me.ActionGroupBox.Text = "I want to:"
        '
        'PreprocessRButton
        '
        Me.PreprocessRButton.AutoSize = True
        Me.PreprocessRButton.Location = New System.Drawing.Point(83, 19)
        Me.PreprocessRButton.Name = "PreprocessRButton"
        Me.PreprocessRButton.Size = New System.Drawing.Size(116, 17)
        Me.PreprocessRButton.TabIndex = 1
        Me.PreprocessRButton.TabStop = True
        Me.PreprocessRButton.Text = "Only Preprocessing"
        Me.PreprocessRButton.UseVisualStyleBackColor = True
        '
        'ExtractRButton
        '
        Me.ExtractRButton.AutoSize = True
        Me.ExtractRButton.Location = New System.Drawing.Point(205, 19)
        Me.ExtractRButton.Name = "ExtractRButton"
        Me.ExtractRButton.Size = New System.Drawing.Size(58, 17)
        Me.ExtractRButton.TabIndex = 2
        Me.ExtractRButton.TabStop = True
        Me.ExtractRButton.Text = "Extract"
        Me.ExtractRButton.UseVisualStyleBackColor = True
        '
        'CompressRButton
        '
        Me.CompressRButton.AutoSize = True
        Me.CompressRButton.Location = New System.Drawing.Point(6, 19)
        Me.CompressRButton.Name = "CompressRButton"
        Me.CompressRButton.Size = New System.Drawing.Size(71, 17)
        Me.CompressRButton.TabIndex = 0
        Me.CompressRButton.TabStop = True
        Me.CompressRButton.Text = "Compress"
        Me.CompressRButton.UseVisualStyleBackColor = True
        '
        'cmixVersionToUseLabel
        '
        Me.cmixVersionToUseLabel.AutoSize = True
        Me.cmixVersionToUseLabel.Location = New System.Drawing.Point(9, 148)
        Me.cmixVersionToUseLabel.Name = "cmixVersionToUseLabel"
        Me.cmixVersionToUseLabel.Size = New System.Drawing.Size(100, 13)
        Me.cmixVersionToUseLabel.TabIndex = 5
        Me.cmixVersionToUseLabel.Text = "cmix version to use:"
        '
        'cmixVersionDropdown
        '
        Me.cmixVersionDropdown.FormattingEnabled = True
        Me.cmixVersionDropdown.Items.AddRange(New Object() {"cmix_v15b"})
        Me.cmixVersionDropdown.Location = New System.Drawing.Point(12, 164)
        Me.cmixVersionDropdown.Name = "cmixVersionDropdown"
        Me.cmixVersionDropdown.Size = New System.Drawing.Size(121, 21)
        Me.cmixVersionDropdown.TabIndex = 8
        '
        'BrowseButton1
        '
        Me.BrowseButton1.Location = New System.Drawing.Point(255, 84)
        Me.BrowseButton1.Name = "BrowseButton1"
        Me.BrowseButton1.Size = New System.Drawing.Size(96, 23)
        Me.BrowseButton1.TabIndex = 4
        Me.BrowseButton1.Text = "Browse File"
        Me.BrowseButton1.UseVisualStyleBackColor = True
        '
        'BrowseButton2
        '
        Me.BrowseButton2.Location = New System.Drawing.Point(255, 123)
        Me.BrowseButton2.Name = "BrowseButton2"
        Me.BrowseButton2.Size = New System.Drawing.Size(96, 23)
        Me.BrowseButton2.TabIndex = 7
        Me.BrowseButton2.Text = "Browse"
        Me.BrowseButton2.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(183, 151)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(263, 57)
        Me.StartButton.TabIndex = 10
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'AboutLabel1
        '
        Me.AboutLabel1.AutoSize = True
        Me.AboutLabel1.Location = New System.Drawing.Point(9, 225)
        Me.AboutLabel1.Name = "AboutLabel1"
        Me.AboutLabel1.Size = New System.Drawing.Size(165, 13)
        Me.AboutLabel1.TabIndex = 10
        Me.AboutLabel1.Text = "GUI software by: Moisés Cardona"
        '
        'AboutLabel2
        '
        Me.AboutLabel2.AutoSize = True
        Me.AboutLabel2.Location = New System.Drawing.Point(9, 238)
        Me.AboutLabel2.Name = "AboutLabel2"
        Me.AboutLabel2.Size = New System.Drawing.Size(101, 13)
        Me.AboutLabel2.TabIndex = 11
        Me.AboutLabel2.Text = "cmix by: Byron Knoll"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "cmix GitHub Repo:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(111, 251)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(174, 13)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "https://github.com/byronknoll/cmix"
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Location = New System.Drawing.Point(387, 251)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(59, 13)
        Me.VersionLabel.TabIndex = 14
        Me.VersionLabel.Text = "GUI v1.0r4"
        '
        'BrowseFolder
        '
        Me.BrowseFolder.Location = New System.Drawing.Point(357, 84)
        Me.BrowseFolder.Name = "BrowseFolder"
        Me.BrowseFolder.Size = New System.Drawing.Size(89, 23)
        Me.BrowseFolder.TabIndex = 5
        Me.BrowseFolder.Text = "Browse Folder"
        Me.BrowseFolder.UseVisualStyleBackColor = True
        '
        'UseEngDictCheckbox
        '
        Me.UseEngDictCheckbox.AutoSize = True
        Me.UseEngDictCheckbox.Location = New System.Drawing.Point(12, 192)
        Me.UseEngDictCheckbox.Name = "UseEngDictCheckbox"
        Me.UseEngDictCheckbox.Size = New System.Drawing.Size(148, 17)
        Me.UseEngDictCheckbox.TabIndex = 9
        Me.UseEngDictCheckbox.Text = "Use the English dictionary"
        Me.UseEngDictCheckbox.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SpanishRButton)
        Me.GroupBox2.Controls.Add(Me.EnglishRButton)
        Me.GroupBox2.Location = New System.Drawing.Point(311, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(135, 46)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Language / Idioma"
        '
        'SpanishRButton
        '
        Me.SpanishRButton.AutoSize = True
        Me.SpanishRButton.Location = New System.Drawing.Point(70, 19)
        Me.SpanishRButton.Name = "SpanishRButton"
        Me.SpanishRButton.Size = New System.Drawing.Size(63, 17)
        Me.SpanishRButton.TabIndex = 4
        Me.SpanishRButton.TabStop = True
        Me.SpanishRButton.Text = "Español"
        Me.SpanishRButton.UseVisualStyleBackColor = True
        '
        'EnglishRButton
        '
        Me.EnglishRButton.AutoSize = True
        Me.EnglishRButton.Location = New System.Drawing.Point(6, 19)
        Me.EnglishRButton.Name = "EnglishRButton"
        Me.EnglishRButton.Size = New System.Drawing.Size(59, 17)
        Me.EnglishRButton.TabIndex = 3
        Me.EnglishRButton.TabStop = True
        Me.EnglishRButton.Text = "English"
        Me.EnglishRButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 272)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.UseEngDictCheckbox)
        Me.Controls.Add(Me.BrowseFolder)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AboutLabel2)
        Me.Controls.Add(Me.AboutLabel1)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.BrowseButton2)
        Me.Controls.Add(Me.BrowseButton1)
        Me.Controls.Add(Me.cmixVersionDropdown)
        Me.Controls.Add(Me.cmixVersionToUseLabel)
        Me.Controls.Add(Me.ActionGroupBox)
        Me.Controls.Add(Me.OutputFileTxt)
        Me.Controls.Add(Me.OutputFileMessage)
        Me.Controls.Add(Me.InputFileTxt)
        Me.Controls.Add(Me.InputFileMessage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "cmix Graphical User Interface"
        Me.ActionGroupBox.ResumeLayout(False)
        Me.ActionGroupBox.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InputFileMessage As Label
    Friend WithEvents InputFileTxt As TextBox
    Friend WithEvents OutputFileMessage As Label
    Friend WithEvents OutputFileTxt As TextBox
    Friend WithEvents ActionGroupBox As GroupBox
    Friend WithEvents ExtractRButton As RadioButton
    Friend WithEvents CompressRButton As RadioButton
    Friend WithEvents cmixVersionToUseLabel As Label
    Friend WithEvents cmixVersionDropdown As ComboBox
    Friend WithEvents BrowseButton1 As Button
    Friend WithEvents BrowseButton2 As Button
    Friend WithEvents StartButton As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents AboutLabel1 As Label
    Friend WithEvents AboutLabel2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents VersionLabel As Label
    Friend WithEvents BrowseFolder As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents UseEngDictCheckbox As CheckBox
    Friend WithEvents PreprocessRButton As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SpanishRButton As RadioButton
    Friend WithEvents EnglishRButton As RadioButton
End Class

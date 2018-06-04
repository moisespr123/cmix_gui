﻿Public Class Form1
    Private OutputFileName As String = String.Empty
    Private cmix_version As String = String.Empty
    Private dict As String = String.Empty
    Private TaskRunning As Boolean = False

    'variables that holds localization messages:
    Private AboutString1 As String = My.Resources.About1
    Private AboutString2 As String = My.Resources.About2
    Private ActionGroupBoxString As String = My.Resources.ActionGroupBox
    Private BrowseFileButton As String = My.Resources.BrowseFileButton
    Private BrowseFolderButton As String = My.Resources.BrowseFolderButton
    Private BrowseOutputButton As String = My.Resources.BrowseOutputButton
    Private cmixVersionToUseLabelString As String = My.Resources.cmixVersionToUseLabel
    Private CompressFolderSelectedMessage As String = My.Resources.CompressFolderSelectedMessage
    Private CompressInputMessage As String = My.Resources.CompressInputMessage
    Private CompressOutputMessage As String = My.Resources.CompressOutputMessage
    Private CompressRButtonString As String = My.Resources.CompressRButton
    Private ExtractFolderSelectedMessage As String = My.Resources.ExtractFolderSelectedMessage
    Private ExtractInputMessage As String = My.Resources.ExtractInputMessage
    Private ExtractOutputMessage As String = My.Resources.ExtractOutputMessage
    Private ExtractRButtonString As String = My.Resources.ExtractRButton
    Private LogSaved As String = My.Resources.LogSaved
    Private PreprocessFolderSelectedMessage As String = My.Resources.PreprocessFolderSelectedMessage
    Private PreprocessInputMessage As String = My.Resources.PreprocessInputMessage
    Private PreprocessOutputMessage As String = My.Resources.PreprocessOutputMessage
    Private PreprocessRButtonString As String = My.Resources.PreprocessRButton
    Private SaveLogButtonString As String = My.Resources.SaveLogButton
    Private StartButtonString As String = My.Resources.StartButton
    Private UseDictString As String = My.Resources.UseDict
    Private Finished As String = My.Resources.Finished
    Private FormName As String = My.Resources.FormName
    Private TaskRunningString As String = My.Resources.TaskRunning

    Private Sub UpdateElementsInForm()
        GetInputNameAndUpdateForm(InputFileTxt.Text)
        If CompressRButton.Checked Then
            InputFileMessage.Text = CompressInputMessage
        ElseIf PreprocessRButton.Checked Then
            InputFileMessage.Text = PreprocessInputMessage
        ElseIf ExtractRButton.Checked Then
            InputFileMessage.Text = ExtractInputMessage
        End If
        AboutLabel1.Text = AboutString1
        AboutLabel2.Text = AboutString2
        ActionGroupBox.Text = ActionGroupBoxString
        BrowseButton1.Text = BrowseFileButton
        BrowseFolder.Text = BrowseFolderButton
        BrowseButton2.Text = BrowseOutputButton
        cmixVersionToUseLabel.Text = cmixVersionToUseLabelString
        CompressRButton.Text = CompressRButtonString
        PreprocessRButton.Text = PreprocessRButtonString
        ExtractRButton.Text = ExtractRButtonString
        SaveLogButton.Text = SaveLogButtonString
        StartButton.Text = StartButtonString
        UseEngDictCheckbox.Text = UseDictString
        Me.Text = FormName
    End Sub
    Private Sub UpdateMessageStrings(Language As String)
        If Language = "English" Then
            AboutString1 = My.Resources.About1
            AboutString2 = My.Resources.About2
            ActionGroupBoxString = My.Resources.ActionGroupBox
            BrowseFileButton = My.Resources.BrowseFileButton
            BrowseFolderButton = My.Resources.BrowseFolderButton
            BrowseOutputButton = My.Resources.BrowseOutputButton
            cmixVersionToUseLabelString = My.Resources.cmixVersionToUseLabel
            CompressFolderSelectedMessage = My.Resources.CompressFolderSelectedMessage
            CompressInputMessage = My.Resources.CompressInputMessage
            CompressOutputMessage = My.Resources.CompressOutputMessage
            CompressRButtonString = My.Resources.CompressRButton
            ExtractFolderSelectedMessage = My.Resources.ExtractFolderSelectedMessage
            ExtractInputMessage = My.Resources.ExtractInputMessage
            ExtractOutputMessage = My.Resources.ExtractOutputMessage
            ExtractRButtonString = My.Resources.ExtractRButton
            LogSaved = My.Resources.LogSaved
            PreprocessFolderSelectedMessage = My.Resources.PreprocessFolderSelectedMessage
            PreprocessInputMessage = My.Resources.PreprocessInputMessage
            PreprocessOutputMessage = My.Resources.PreprocessOutputMessage
            PreprocessRButtonString = My.Resources.PreprocessRButton
            SaveLogButtonString = My.Resources.SaveLogButton
            StartButtonString = My.Resources.StartButton
            TaskRunningString = My.Resources.TaskRunning
            UseDictString = My.Resources.UseDict
            Finished = My.Resources.Finished
            FormName = My.Resources.FormName
        Else
            AboutString1 = My.Resources.About1Spanish
            AboutString2 = My.Resources.About2Spanish
            ActionGroupBoxString = My.Resources.ActionGroupBoxSpanish
            BrowseFileButton = My.Resources.BrowseFileButtonSpanish
            BrowseFolderButton = My.Resources.BrowseFolderButtonSpanish
            BrowseOutputButton = My.Resources.BrowseOutputButtonSpanish
            cmixVersionToUseLabelString = My.Resources.cmixVersionToUseLabelSpanish
            CompressFolderSelectedMessage = My.Resources.CompressFolderSelectedMessageSpanish
            CompressInputMessage = My.Resources.CompressInputMessageSpanish
            CompressOutputMessage = My.Resources.CompressOutputMessageSpanish
            CompressRButtonString = My.Resources.CompressRButtonSpanish
            ExtractFolderSelectedMessage = My.Resources.ExtractFolderSelectedMessageSpanish
            ExtractInputMessage = My.Resources.ExtractInputMessageSpanish
            ExtractOutputMessage = My.Resources.ExtractOutputMessageSpanish
            ExtractRButtonString = My.Resources.ExtractRButtonSpanish
            LogSaved = My.Resources.LogSavedSpanish
            PreprocessFolderSelectedMessage = My.Resources.PreprocessFolderSelectedMessageSpanish
            PreprocessInputMessage = My.Resources.PreprocessInputMessageSpanish
            PreprocessOutputMessage = My.Resources.PreprocessOutputMessageSpanish
            PreprocessRButtonString = My.Resources.PreprocessRButtonSpanish
            SaveLogButtonString = My.Resources.SaveLogButtonSpanish
            StartButtonString = My.Resources.StartButtonSpanish
            TaskRunningString = My.Resources.TaskRunningSpanish
            UseDictString = My.Resources.UseDictSpanish
            Finished = My.Resources.FinishedSpanish
            FormName = My.Resources.FormNameSpanish
        End If
        UpdateElementsInForm()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CompressRButton.Checked = My.Settings.Compress
        ExtractRButton.Checked = My.Settings.Extract
        PreprocessRButton.Checked = My.Settings.Preprocess
        cmixVersionDropdown.SelectedItem = My.Settings.Version
        UseEngDictCheckbox.Checked = My.Settings.UseEngDict
        EnglishRButton.Checked = My.Settings.EnglishLanguage
        SpanishRButton.Checked = My.Settings.SpanishLanguage
    End Sub
    Private Sub CompressRButton_CheckedChanged(sender As Object, e As EventArgs) Handles CompressRButton.CheckedChanged
        InputFileMessage.Text = CompressInputMessage
        OutputFileMessage.Text = CompressOutputMessage
        UseEngDictCheckbox.Enabled = True
        My.Settings.Compress = CompressRButton.Checked
        My.Settings.Save()
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        InputFileMessage.Text = ExtractInputMessage
        OutputFileMessage.Text = ExtractOutputMessage
        UseEngDictCheckbox.Enabled = True
        My.Settings.Extract = ExtractRButton.Checked
        My.Settings.Save()
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub PreprocessRButton_CheckedChanged(sender As Object, e As EventArgs) Handles PreprocessRButton.CheckedChanged
        InputFileMessage.Text = PreprocessInputMessage
        OutputFileMessage.Text = PreprocessOutputMessage
        My.Settings.Preprocess = PreprocessRButton.Checked
        My.Settings.Save()
        UseEngDictCheckbox.Checked = True
        UseEngDictCheckbox.Enabled = False
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Function CheckIfFileOrFolder(Optional PathToCheck As String = "") As String
        If My.Computer.FileSystem.FileExists(PathToCheck) Or PathToCheck = "" Then
            If CompressRButton.Checked Then
                OutputFileMessage.Text = CompressOutputMessage
            ElseIf PreprocessRButton.Checked Then
                OutputFileMessage.Text = PreprocessOutputMessage
            ElseIf ExtractRButton.Checked Then
                OutputFileMessage.Text = ExtractOutputMessage
            End If
            OutputFileTxt.Enabled = True
            BrowseButton2.Enabled = True
            If PathToCheck IsNot "" Then Return "File"
        ElseIf My.Computer.FileSystem.DirectoryExists(PathToCheck) Then
            If CompressRButton.Checked Then
                OutputFileMessage.Text = CompressFolderSelectedMessage
            ElseIf PreprocessRButton.Checked Then
                OutputFileMessage.Text = PreprocessFolderSelectedMessage
            ElseIf ExtractRButton.Checked Then
                OutputFileMessage.Text = ExtractFolderSelectedMessage
            End If
            OutputFileTxt.Enabled = False
            BrowseButton2.Enabled = False
            Return "Folder"
        End If
        Return "N/A"
    End Function

    Private Sub SetVersion(Extension As String)
        If Extension.Contains("15b") Then cmixVersionDropdown.SelectedItem = "cmix_v15b"
    End Sub

    Private Sub SetDict(Extension As String)
        If Extension.Contains("_dict") Then UseEngDictCheckbox.Checked = True Else UseEngDictCheckbox.Checked = False
    End Sub

    Private Sub SetOutputFileNamePathWithoutExtension(Path As String)
        OutputFileTxt.Text = My.Computer.FileSystem.GetParentPath(Path) + "\" + IO.Path.GetFileNameWithoutExtension(Path)
    End Sub

    Private Function GetInputNameAndUpdateForm(Path As String) As String
        Dim CheckIfFile = CheckIfFileOrFolder(Path)
        If CheckIfFile = "File" Then
            Dim FileExtension As String = IO.Path.GetExtension(Path)
            If FileExtension.Contains("cmix") Then
                SetVersion(FileExtension)
                SetDict(FileExtension)
                SetOutputFileNamePathWithoutExtension(Path)
                ExtractRButton.Checked = True
            End If
            If CompressRButton.Checked Or PreprocessRButton.Checked Then
                OutputFileName = Path + ".cmix"
                SetOutputFilename()
            End If
        End If
        Return Path
    End Function

    Private Sub BrowseButton1_Click(sender As Object, e As EventArgs) Handles BrowseButton1.Click
        OpenFileDialog1.Title = InputFileTxt.Text
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        If InputFileTxt.Text IsNot String.Empty Then
            If My.Computer.FileSystem.FileExists(InputFileTxt.Text) Then OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(InputFileTxt.Text) Else OpenFileDialog1.FileName = String.Empty
        Else
            OpenFileDialog1.FileName = String.Empty
        End If
        Dim response As DialogResult = OpenFileDialog1.ShowDialog
        If response = DialogResult.OK Then
            InputFileTxt.Text = GetInputNameAndUpdateForm(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub BrowseFolder_Click(sender As Object, e As EventArgs) Handles BrowseFolder.Click
        Dim response As DialogResult = FolderBrowserDialog1.ShowDialog()
        If response = DialogResult.OK Then
            InputFileTxt.Text = GetInputNameAndUpdateForm(FolderBrowserDialog1.SelectedPath)
        End If
    End Sub

    Private Sub BrowseButton2_Click(sender As Object, e As EventArgs) Handles BrowseButton2.Click
        SaveFileDialog1.Title = InputFileTxt.Text
        If CompressRButton.Checked Then SaveFileDialog1.Filter = "cmix file|*.cmix" Else SaveFileDialog1.Filter = "All files (*.*)|*.*"
        If OutputFileTxt.Text IsNot String.Empty Then
            If My.Computer.FileSystem.FileExists(OutputFileTxt.Text) Then SaveFileDialog1.FileName = My.Computer.FileSystem.GetName(OutputFileTxt.Text) Else SaveFileDialog1.FileName = String.Empty
        Else
            SaveFileDialog1.FileName = String.Empty
        End If
        Dim response As DialogResult = SaveFileDialog1.ShowDialog
        If response = DialogResult.OK Then
            If CompressRButton.Checked Then
                OutputFileName = SaveFileDialog1.FileName
                If CompressRButton.Checked Then SetOutputFilename()
            Else
                OutputFileTxt.Text = SaveFileDialog1.FileName
            End If
        End If
    End Sub

    Private Sub SetOutputFilename()
        If CompressRButton.Checked Or PreprocessRButton.Checked Then OutputFileTxt.Text = OutputFileName + cmix_version + dict
    End Sub

    Private Sub cmixVersionDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmixVersionDropdown.SelectedIndexChanged
        My.Settings.Version = cmixVersionDropdown.SelectedItem
        My.Settings.Save()
        If cmixVersionDropdown.SelectedItem = "cmix_v15b" Then
            cmix_version = "15b"
        End If
        If OutputFileName IsNot String.Empty Then
            SetOutputFilename()
        End If
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        InputFileTxt.Text = e.Data.GetData(DataFormats.FileDrop)(0)
        GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub Run_cmix(Input As String, Output As String, action As String)
        If action.Contains("-c") Then
            UpdateLog("Compressing file " + Input)
        ElseIf action.Contains("-d") Then
            UpdateLog("Extracting file " + Input)
        Else
            UpdateLog("Preprocessing file " + Input)
        End If
        UpdateLog("Start time: " & Date.Now())
        UpdateLog("----------")
        Dim cmixProcessInfo As New ProcessStartInfo
        Dim cmixProcess As Process
        cmixProcessInfo.FileName = My.Settings.Version + ".exe"
        cmixProcessInfo.Arguments = action + " """ + Input + """ """ + Output + """"
        cmixProcessInfo.CreateNoWindow = True
        cmixProcessInfo.RedirectStandardOutput = True
        cmixProcessInfo.UseShellExecute = False
        cmixProcess = Process.Start(cmixProcessInfo)
        Dim currentOutput As String = String.Empty
        While cmixProcess.HasExited = False
            While cmixProcess.StandardOutput.EndOfStream = False
                currentOutput = cmixProcess.StandardOutput.ReadLine
                If currentOutput.Contains("progress") Or currentOutput.Contains("pretraining") Then
                    If currentOutput.Contains("progress: 0%") Or currentOutput.Contains("pretraining: 0%") Then
                        UpdateLog(currentOutput)
                    Else
                        UpdateLog(currentOutput, True)
                    End If
                Else
                    UpdateLog(currentOutput)
                End If
            End While
        End While
        UpdateLog("Finished processing file " + Input + vbCrLf + "End Time: " + Date.Now() + vbCrLf)
    End Sub
    Private Delegate Sub UpdateLogInvoker(message As String, ErasePreviousLine As Boolean)
    Private Sub UpdateLog(message As String, Optional ErasePreviousLine As Boolean = False)
        If ProgressLog.InvokeRequired Then
            ProgressLog.Invoke(New UpdateLogInvoker(AddressOf UpdateLog), message, ErasePreviousLine)
        Else
            If ErasePreviousLine Then
                ProgressLog.Text = ProgressLog.Text.Replace(ProgressLog.Lines(ProgressLog.Lines.Count - 2), message.Replace(vbCrLf, ""))
            Else
                If message = String.Empty = False And message = vbCrLf = False Then
                    ProgressLog.AppendText(message + vbCrLf)
                End If
            End If
            ProgressLog.SelectionStart = ProgressLog.Text.Length - 1
            ProgressLog.ScrollToCaret()
        End If
    End Sub
    Public Sub ProcessFiles(Folder As String, Action As String)
        For Each File In IO.Directory.GetFiles(Folder)
            If ExtractRButton.Checked Then
                If IO.Path.GetExtension(File).Contains("cmix") Then
                    GetInputNameAndUpdateForm(File)
                    Run_cmix(File, OutputFileTxt.Text, Action)
                End If
            Else
                Run_cmix(File, File + ".cmix" + cmix_version + dict, Action)
            End If
        Next
    End Sub

    Public Sub ProcessSubfolders(Folder As String, Action As String)
        For Each Subfolder In IO.Directory.GetDirectories(Folder)
            ProcessFolder(Subfolder, Action)
        Next
    End Sub

    Public Sub ProcessFolder(Folder As String, Action As String)
        ProcessFiles(Folder, Action)
        ProcessSubfolders(Folder, Action)
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If InputFileTxt.Text IsNot String.Empty Then
            If TaskRunning = False Then
                TaskRunning = True
                Dim Thread As New System.Threading.Thread(Sub() ProcessThread())
                Thread.Start()
            Else
                MsgBox(TaskRunningString)
            End If
        End If
    End Sub
    Private Sub ProcessThread()
        Dim ProcessAction As String = String.Empty
        If CompressRButton.Checked Then
            ProcessAction = "-c"
        ElseIf PreprocessRButton.Checked Then
            ProcessAction = "-s"
        Else
            ProcessAction = "-d"
        End If
        If My.Settings.UseEngDict Then ProcessAction = ProcessAction + " english.dic"
        Dim CheckInput As String = CheckIfFileOrFolder(InputFileTxt.Text)
        If CheckInput = "File" Then
            If OutputFileTxt.Text IsNot String.Empty Then
                Run_cmix(InputFileTxt.Text, OutputFileTxt.Text, ProcessAction)
            End If
        ElseIf CheckInput = "Folder" Then
            ProcessFolder(InputFileTxt.Text, ProcessAction)
        End If
        TaskRunning = False
        MessageBox.Show(Finished)
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/byronknoll/cmix")
    End Sub

    Private Sub UseEngDictCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles UseEngDictCheckbox.CheckedChanged
        My.Settings.UseEngDict = UseEngDictCheckbox.Checked
        My.Settings.Save()
        If UseEngDictCheckbox.Checked Then dict = "_dict" Else dict = String.Empty
        If OutputFileName IsNot String.Empty Then
            SetOutputFilename()
        End If
    End Sub

    Private Sub EnglishRButton_CheckedChanged(sender As Object, e As EventArgs) Handles EnglishRButton.CheckedChanged
        My.Settings.EnglishLanguage = EnglishRButton.Checked
        My.Settings.Save()
        UpdateMessageStrings("English")
    End Sub

    Private Sub SpanishRButton_CheckedChanged(sender As Object, e As EventArgs) Handles SpanishRButton.CheckedChanged
        My.Settings.SpanishLanguage = SpanishRButton.Checked
        My.Settings.Save()
        UpdateMessageStrings("Spanish")
    End Sub

    Private Sub SaveLogButton_Click(sender As Object, e As EventArgs) Handles SaveLogButton.Click
        Dim SaveLogFile As New SaveFileDialog
        SaveLogFile.Title = "Browse for a location to save the log file"
        SaveLogFile.Filter = "Log file (*.log)|*.log"
        SaveLogFile.FileName = String.Empty
        Dim dialogResult As DialogResult = SaveLogFile.ShowDialog
        If DialogResult.OK Then
            If SaveLogFile.FileName = String.Empty = False Then
                My.Computer.FileSystem.WriteAllText(SaveLogFile.FileName, ProgressLog.Text, False)
                MsgBox(LogSaved)
            End If
        End If
    End Sub

    Private Sub InputFileTxt_TextChanged(sender As Object, e As EventArgs) Handles InputFileTxt.TextChanged
        GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub
End Class

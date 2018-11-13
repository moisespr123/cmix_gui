Public Class Form1
    Private OutputFileName As String = String.Empty
    Private cmix_version As String = String.Empty
    Private dict As String = String.Empty
    Private TaskRunning As Boolean = False
    Private ExitSoftware As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckExes()
        CompressRButton.Checked = My.Settings.Compress
        ExtractRButton.Checked = My.Settings.Extract
        PreprocessRButton.Checked = My.Settings.Preprocess
        UseEngDictCheckbox.Checked = My.Settings.UseEngDict
        EnglishRButton.Checked = My.Settings.EnglishLanguage
        SpanishRButton.Checked = My.Settings.SpanishLanguage
        ShowCMD.Checked = My.Settings.ShowCMD
        Dim Thread As New Threading.Thread(Sub() UpdateRAMBars())
        Thread.Start()
    End Sub

    Private Sub CheckExes()
        If My.Computer.FileSystem.FileExists("cmix_v16e.exe") Then cmixVersionDropdown.Items.Add("cmix_v16e")
        If My.Computer.FileSystem.FileExists("cmix_v16d.exe") Then cmixVersionDropdown.Items.Add("cmix_v16d")
        If My.Computer.FileSystem.FileExists("cmix_v16c.exe") Then cmixVersionDropdown.Items.Add("cmix_v16c")
        If My.Computer.FileSystem.FileExists("cmix_v16b.exe") Then cmixVersionDropdown.Items.Add("cmix_v16b")
        If My.Computer.FileSystem.FileExists("cmix_v16a.exe") Then cmixVersionDropdown.Items.Add("cmix_v16a")
        If My.Computer.FileSystem.FileExists("cmix_v15i.exe") Then cmixVersionDropdown.Items.Add("cmix_v15i")
        If My.Computer.FileSystem.FileExists("cmix_v15g.exe") Then cmixVersionDropdown.Items.Add("cmix_v15g")
        If My.Computer.FileSystem.FileExists("cmix_v15f.exe") Then cmixVersionDropdown.Items.Add("cmix_v15f")
        If My.Computer.FileSystem.FileExists("cmix_v15e.exe") Then cmixVersionDropdown.Items.Add("cmix_v15e")
        If My.Computer.FileSystem.FileExists("cmix_v15d.exe") Then cmixVersionDropdown.Items.Add("cmix_v15d")
        If My.Computer.FileSystem.FileExists("cmix_v15c.exe") Then cmixVersionDropdown.Items.Add("cmix_v15c")
        If My.Computer.FileSystem.FileExists("cmix_v15b.exe") Then cmixVersionDropdown.Items.Add("cmix_v15b")
        If Not My.Computer.FileSystem.FileExists("english.dic") Then UseEngDictCheckbox.Enabled = False
        If cmixVersionDropdown.Items.Contains(My.Settings.Version) Then cmixVersionDropdown.SelectedItem = My.Settings.Version
    End Sub
    Private Sub CompressRButton_CheckedChanged(sender As Object, e As EventArgs) Handles CompressRButton.CheckedChanged
        InputFileMessage.Text = Translations.CompressInputMessage
        OutputFileMessage.Text = Translations.CompressOutputMessage
        If My.Computer.FileSystem.FileExists("english.dic") Then UseEngDictCheckbox.Enabled = True
        My.Settings.Compress = CompressRButton.Checked
        My.Settings.Save()
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        InputFileMessage.Text = Translations.ExtractInputMessage
        OutputFileMessage.Text = Translations.ExtractOutputMessage
        If My.Computer.FileSystem.FileExists("english.dic") Then UseEngDictCheckbox.Enabled = True
        My.Settings.Extract = ExtractRButton.Checked
        My.Settings.Save()
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub PreprocessRButton_CheckedChanged(sender As Object, e As EventArgs) Handles PreprocessRButton.CheckedChanged
        InputFileMessage.Text = Translations.PreprocessInputMessage
        OutputFileMessage.Text = Translations.PreprocessOutputMessage
        My.Settings.Preprocess = PreprocessRButton.Checked
        My.Settings.Save()
        UseEngDictCheckbox.Checked = True
        UseEngDictCheckbox.Enabled = False
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Function CheckIfFileOrFolder(Optional PathToCheck As String = "") As String
        If My.Computer.FileSystem.FileExists(PathToCheck) Or PathToCheck = "" Then
            If CompressRButton.Checked Then
                OutputFileMessage.Text = Translations.CompressOutputMessage
            ElseIf PreprocessRButton.Checked Then
                OutputFileMessage.Text = Translations.PreprocessOutputMessage
            ElseIf ExtractRButton.Checked Then
                OutputFileMessage.Text = Translations.ExtractOutputMessage
            End If
            OutputFileTxt.Enabled = True
            BrowseButton2.Enabled = True
            If PathToCheck IsNot "" Then Return "File"
        ElseIf My.Computer.FileSystem.DirectoryExists(PathToCheck) Then
            If CompressRButton.Checked Then
                OutputFileMessage.Text = Translations.CompressFolderSelectedMessage
            ElseIf PreprocessRButton.Checked Then
                OutputFileMessage.Text = Translations.PreprocessFolderSelectedMessage
            ElseIf ExtractRButton.Checked Then
                OutputFileMessage.Text = Translations.ExtractFolderSelectedMessage
            End If
            OutputFileTxt.Enabled = False
            BrowseButton2.Enabled = False
            Return "Folder"
        End If
        Return "N/A"
    End Function

    Private Sub SetVersion(Extension As String)
        If Extension.Contains("15b") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15b"
        ElseIf Extension.Contains("15c") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15c"
        ElseIf Extension.Contains("15d") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15d"
        ElseIf Extension.Contains("15e") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15e"
        ElseIf Extension.Contains("15f") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15f"
        ElseIf Extension.Contains("15g") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15g"
        ElseIf Extension.Contains("15h") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15h"
        ElseIf Extension.Contains("15i") Then
            cmixVersionDropdown.SelectedItem = "cmix_v15i"
        ElseIf Extension.Contains("16a") Then
            cmixVersionDropdown.SelectedItem = "cmix_v16a"
        ElseIf Extension.Contains("16b") Then
            cmixVersionDropdown.SelectedItem = "cmix_v16b"
        ElseIf Extension.Contains("16c") Then
            cmixVersionDropdown.SelectedItem = "cmix_v16c"
        ElseIf Extension.Contains("16d") Then
            cmixVersionDropdown.SelectedItem = "cmix_v16d"
        ElseIf Extension.Contains("16e") Then
            cmixVersionDropdown.SelectedItem = "cmix_v16e"
        End If
    End Sub

    Private Function SetDict(Extension As String) As Boolean
        If Extension.Contains("_dict") Then
            If My.Computer.FileSystem.FileExists("english.dic") Then
                UseEngDictCheckbox.Checked = True
            Else
                MsgBox("english.dic is missing. Cannot use dictionary.")
                InputFileTxt.Text = ""
                OutputFileTxt.Text = ""
                Return False
            End If
        Else
            UseEngDictCheckbox.Checked = False
        End If
        Return True
    End Function

    Private Sub SetOutputFileNamePathWithoutExtension(Path As String)
        OutputFileTxt.Text = My.Computer.FileSystem.GetParentPath(Path) + "\" + IO.Path.GetFileNameWithoutExtension(Path)
    End Sub

    Public Function GetInputNameAndUpdateForm(Path As String) As String
        Dim CheckIfFile = CheckIfFileOrFolder(Path)
        If CheckIfFile = "File" Then
            Dim FileExtension As String = IO.Path.GetExtension(Path)
            If FileExtension.Contains("cmix") Then
                SetVersion(FileExtension)
                If SetDict(FileExtension) Then
                    SetOutputFileNamePathWithoutExtension(Path)
                    ExtractRButton.Checked = True
                End If
            End If
            If CompressRButton.Checked Or PreprocessRButton.Checked Then
                OutputFileName = Path + ".cmix"
                SetOutputFilename()
            End If
        End If
        Return Path
    End Function

    Private Sub BrowseButton1_Click(sender As Object, e As EventArgs) Handles BrowseButton1.Click
        OpenFileDialog1.Title = InputFileMessage.Text
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        If InputFileTxt.Text IsNot String.Empty Then
            If My.Computer.FileSystem.FileExists(InputFileTxt.Text) Then OpenFileDialog1.FileName = My.Computer.FileSystem.GetName(InputFileTxt.Text) Else OpenFileDialog1.FileName = String.Empty
        Else
            OpenFileDialog1.FileName = String.Empty
        End If
        Dim response As DialogResult = OpenFileDialog1.ShowDialog
        If response = DialogResult.OK Then
            InputFileTxt.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub BrowseFolder_Click(sender As Object, e As EventArgs) Handles BrowseFolder.Click
        Dim response As DialogResult = FolderBrowserDialog1.ShowDialog()
        If response = DialogResult.OK Then
            InputFileTxt.Text = GetInputNameAndUpdateForm(FolderBrowserDialog1.SelectedPath)
        End If
    End Sub

    Private Sub BrowseButton2_Click(sender As Object, e As EventArgs) Handles BrowseButton2.Click
        SaveFileDialog1.Title = OutputFileMessage.Text
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

    Private Sub CmixVersionDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmixVersionDropdown.SelectedIndexChanged
        My.Settings.Version = cmixVersionDropdown.SelectedItem
        My.Settings.Save()
        If cmixVersionDropdown.SelectedItem = "cmix_v15b" Then
            cmix_version = "15b"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15c" Then
            cmix_version = "15c"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15d" Then
            cmix_version = "15d"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15e" Then
            cmix_version = "15e"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15f" Then
            cmix_version = "15f"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15g" Then
            cmix_version = "15g"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15h" Then
            cmix_version = "15h"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v15i" Then
            cmix_version = "15i"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v16a" Then
            cmix_version = "16a"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v16b" Then
            cmix_version = "16b"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v16c" Then
            cmix_version = "16c"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v16d" Then
            cmix_version = "16d"
        ElseIf cmixVersionDropdown.SelectedItem = "cmix_v16e" Then
            cmix_version = "16e"
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
        cmixProcessInfo.CreateNoWindow = Not ShowCMD.Checked
        cmixProcessInfo.RedirectStandardError = Not ShowCMD.Checked
        cmixProcessInfo.UseShellExecute = ShowCMD.Checked
        cmixProcess = Process.Start(cmixProcessInfo)
        Dim WrotePretraining As Boolean = False
        Dim WroteProgress As Boolean = False
        If Not ShowCMD.Checked Then
            Dim currentOutput As String = String.Empty
            While Not cmixProcess.HasExited
                While Not cmixProcess.StandardError.EndOfStream
                    currentOutput = cmixProcess.StandardError.ReadLine
                    If currentOutput.Contains("pretraining") Then
                        If Not WrotePretraining Then
                            UpdateLog(currentOutput)
                            WrotePretraining = True
                        Else
                            UpdateLog(currentOutput, True)
                        End If
                    ElseIf currentOutput.Contains("progress") Then
                        If Not WroteProgress Then
                            UpdateLog(currentOutput)
                            WroteProgress = True
                        Else
                            UpdateLog(currentOutput, True)
                        End If
                    Else
                        UpdateLog(currentOutput)
                    End If
                End While
            End While
        Else
            cmixProcess.WaitForExit()
        End If
        UpdateLog("----------")
        UpdateLog("Finished processing file " + Input + vbCrLf + "End Time: " + Date.Now() + vbCrLf)
        UpdateLog(String.Format("Input file size: {0:N2} MB ", My.Computer.FileSystem.GetFileInfo(Input).Length / 1024 / 1024))
        UpdateLog(String.Format("Compressed file size: {0:N2} MB ", My.Computer.FileSystem.GetFileInfo(Output).Length / 1024 / 1024))
    End Sub
    Private Delegate Sub UpdateLogInvoker(message As String, ErasePreviousLine As Boolean)
    Private Sub UpdateLog(message As String, Optional ErasePreviousLine As Boolean = False)
        If ProgressLog.InvokeRequired Then
            ProgressLog.Invoke(New UpdateLogInvoker(AddressOf UpdateLog), message, ErasePreviousLine)
        Else
            If ErasePreviousLine Then
                ProgressLog.Text = ProgressLog.Text.Replace(ProgressLog.Lines(ProgressLog.Lines.Count - 2), message.Replace(vbCrLf, ""))
            Else
                If Not message = String.Empty And Not message = vbCrLf Then
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
            If Not TaskRunning Then
                TaskRunning = True
                Dim Thread As New Threading.Thread(Sub() ProcessThread())
                Thread.Start()
            Else
                MsgBox(Translations.TaskRunningString)
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
        MessageBox.Show(Translations.Finished)
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
        Translations.UpdateMessageStrings("English")
    End Sub

    Private Sub SpanishRButton_CheckedChanged(sender As Object, e As EventArgs) Handles SpanishRButton.CheckedChanged
        My.Settings.SpanishLanguage = SpanishRButton.Checked
        My.Settings.Save()
        Translations.UpdateMessageStrings("Spanish")
    End Sub

    Private Sub SaveLogButton_Click(sender As Object, e As EventArgs) Handles SaveLogButton.Click
        Dim SaveLogFile As New SaveFileDialog With {
            .Title = "Browse for a location to save the log file",
            .Filter = "Log file (*.log)|*.log",
            .FileName = String.Empty
        }
        Dim dialogResult As DialogResult = SaveLogFile.ShowDialog
        If DialogResult.OK Then
            If Not SaveLogFile.FileName = String.Empty Then
                My.Computer.FileSystem.WriteAllText(SaveLogFile.FileName, ProgressLog.Text, False)
                MsgBox(Translations.LogSaved)
            End If
        End If
    End Sub

    Private Sub InputFileTxt_TextChanged(sender As Object, e As EventArgs) Handles InputFileTxt.TextChanged
        GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Delegate Sub ClearLogInvoker()
    Private Sub ClearLog()
        If ProgressLog.InvokeRequired Then
            ProgressLog.Invoke(New ClearLogInvoker(AddressOf ClearLog))
        Else
            ProgressLog.Clear()
        End If
    End Sub
    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        If Not TaskRunning Then ClearLog()
    End Sub

    Private Sub UpdateRAMBars()
        Dim TotalSystemRAM As Double = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024 / 1024
        TotalRAM.GetCurrentParent.Invoke(Sub()
                                             TotalRAM.Text = String.Format(Translations.TotalRAMString + " {0:N2} GB", TotalSystemRAM)
                                         End Sub)
        RAMBar.GetCurrentParent.Invoke(Sub()
                                           RAMBar.Maximum = TotalSystemRAM
                                       End Sub)
        Dim AvailableSystemRAM As Double = 0.0
        Dim UsedSystemRAM As Double = 0.0
        While True
            If ExitSoftware Then Exit While
            Try
                AvailableSystemRAM = My.Computer.Info.AvailablePhysicalMemory / 1024 / 1024 / 1024
                UsedSystemRAM = TotalSystemRAM - AvailableSystemRAM
                AvailableRAM.GetCurrentParent.Invoke(Sub()
                                                         AvailableRAM.Text = String.Format(Translations.AvailableRAMString + " {0:N2} GB", AvailableSystemRAM)
                                                     End Sub)
                UsedRAM.GetCurrentParent.Invoke(Sub()
                                                    UsedRAM.Text = String.Format(Translations.UsedRAMString + " {0:N2} GB", UsedSystemRAM)
                                                End Sub)
                RAMBar.GetCurrentParent.Invoke(Sub()
                                                   RAMBar.Value = UsedSystemRAM
                                               End Sub)
                Threading.Thread.Sleep(500)
            Catch
                Continue While
            End Try
        End While
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ExitSoftware = True
    End Sub

    Private Sub ShowCMD_CheckedChanged(sender As Object, e As EventArgs) Handles ShowCMD.CheckedChanged
        My.Settings.ShowCMD = ShowCMD.Checked
        My.Settings.Save()
    End Sub
End Class

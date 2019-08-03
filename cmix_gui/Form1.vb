Public Class Form1
    Private OutputFileName As String = String.Empty
    Private cmix_version As String = String.Empty
    Private dict As String = String.Empty
    Private TaskRunning As Boolean = False
    Private ExitSoftware As Boolean = False
    Private cmixVersionDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String) From {
        {"15b", "cmix_v15b"},
        {"15c", "cmix_v15c"},
        {"15d", "cmix_v15d"},
        {"15e", "cmix_v15e"},
        {"15f", "cmix_v15f"},
        {"15g", "cmix_v15g"},
        {"15h", "cmix_v15h"},
        {"15i", "cmix_v15i"},
        {"16a", "cmix_v16a"},
        {"16b", "cmix_v16b"},
        {"16c", "cmix_v16c"},
        {"16d", "cmix_v16d"},
        {"16e", "cmix_v16e"},
        {"16f", "cmix_v16f"},
        {"17", "cmix_v17"},
        {"18", "cmix_v18"}
        }


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IO.Directory.SetCurrentDirectory(IO.Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName))
        CheckExes()
        CompressRButton.Checked = My.Settings.Compress
        ExtractRButton.Checked = My.Settings.Extract
        PreprocessRButton.Checked = My.Settings.Preprocess
        UseEngDictCheckbox.Checked = My.Settings.UseEngDict
        EnglishRButton.Checked = My.Settings.EnglishLanguage
        SpanishRButton.Checked = My.Settings.SpanishLanguage
        ShowCMD.Checked = My.Settings.ShowCMD
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            InputFileTxt.Text = vars(1)
            GetInputNameAndUpdateForm(InputFileTxt.Text)
        End If
        Dim Thread As New Threading.Thread(Sub() UpdateRAMBars())
        Thread.Start()
    End Sub

    Private Sub CheckExes()
        For Each item As KeyValuePair(Of String, String) In cmixVersionDictionary
            If My.Computer.FileSystem.FileExists("exes\" + item.Key + "\" + item.Value + ".exe") Then cmixVersionDropdown.Items.Add(item.Value)
        Next
        If cmixVersionDropdown.Items.Contains(My.Settings.Version) Then cmixVersionDropdown.SelectedItem = My.Settings.Version
    End Sub
    Private Sub CheckDictionaryFile()
        If IO.File.Exists("exes\" + cmix_version + "\english.dic") Then
            UseEngDictCheckbox.Enabled = True
        Else
            UseEngDictCheckbox.Enabled = False
            UseEngDictCheckbox.Checked = False
        End If
    End Sub
    Private Sub CompressRButton_CheckedChanged(sender As Object, e As EventArgs) Handles CompressRButton.CheckedChanged
        InputFileMessage.Text = Translations.CompressInputMessage
        OutputFileMessage.Text = Translations.CompressOutputMessage
        CheckDictionaryFile()
        My.Settings.Compress = CompressRButton.Checked
        My.Settings.Save()
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        InputFileMessage.Text = Translations.ExtractInputMessage
        OutputFileMessage.Text = Translations.ExtractOutputMessage
        CheckDictionaryFile()
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
            Else
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
            Else
                OutputFileMessage.Text = Translations.ExtractFolderSelectedMessage
            End If
            OutputFileTxt.Enabled = False
            BrowseButton2.Enabled = False
            Return "Folder"
        End If
        Return "N/A"
    End Function

    Private Sub SetVersion(Extension As String)
        For Each item As KeyValuePair(Of String, String) In cmixVersionDictionary
            If Extension.Contains(item.Key) Then
                cmixVersionDropdown.SelectedItem = item.Value
            End If
        Next
    End Sub

    Private Function SetDict(Extension As String) As Boolean
        If Extension.Contains("_dict") Then
            If IO.File.Exists("exes\" + cmix_version + "\english.dic") Then
                UseEngDictCheckbox.Checked = True
            Else
                MsgBox("english.dic is missing. Cannot use dictionary.")
                InputFileTxt.Text = ""
                OutputFileTxt.Text = ""
                UseEngDictCheckbox.Checked = False
                Return False
            End If
        Else
            UseEngDictCheckbox.Checked = False
        End If
        Return True
    End Function

    Public Function GetInputNameAndUpdateForm(Path As String) As String
        Dim CheckIfFile = CheckIfFileOrFolder(Path)
        If CheckIfFile = "File" Then
            Dim FileExtension As String = IO.Path.GetExtension(Path)
            If FileExtension.Contains("cmix") Then
                SetVersion(FileExtension)
                If SetDict(FileExtension) Then
                    OutputFileTxt.Text = IO.Path.ChangeExtension(Path, Nothing)
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
        For Each item As KeyValuePair(Of String, String) In cmixVersionDictionary
            If cmixVersionDropdown.SelectedItem = item.Value Then
                cmix_version = item.Key
                CheckDictionaryFile()
            End If
        Next
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

    Private Sub UpdateLogEventHandler(sender As Object, e As DataReceivedEventArgs)
        If Not e.Data = Nothing Then
            UpdateLog(e.Data)
        End If
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
        Using process As New Process
            process.StartInfo.WorkingDirectory = "exes\" + cmix_version
            process.StartInfo.FileName = "exes\" + cmix_version + "\" + My.Settings.Version + ".exe"
            process.StartInfo.Arguments = action + " """ + Input + """ """ + Output + """"
            process.StartInfo.CreateNoWindow = Not ShowCMD.Checked
            process.StartInfo.RedirectStandardOutput = Not ShowCMD.Checked
            process.StartInfo.RedirectStandardError = Not ShowCMD.Checked
            process.StartInfo.UseShellExecute = ShowCMD.Checked
            If Not ShowCMD.Checked Then
                AddHandler process.OutputDataReceived, New DataReceivedEventHandler(AddressOf UpdateLogEventHandler)
                AddHandler process.ErrorDataReceived, New DataReceivedEventHandler(AddressOf UpdateLogEventHandler)
            End If
            process.Start()
            If Not ShowCMD.Checked Then
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()
            End If
            process.WaitForExit()
            UpdateLog("----------")
        End Using
        UpdateLog("Finished processing file " + Input + vbCrLf + "End Time: " + Date.Now() + vbCrLf)
        Dim OutputFileMessage As String = String.Empty
        If action.Contains("-c") Then
            OutputFileMessage = "Compressed"
        ElseIf action.Contains("-d") Then
            OutputFileMessage = "Extracted"
        Else
            OutputFileMessage = "Preprocessed"
        End If
        UpdateLog(String.Format("Input file size: {0:N2} MB ", My.Computer.FileSystem.GetFileInfo(Input).Length / 1024 / 1024))
        UpdateLog(String.Format(OutputFileMessage + " file size: {0:N2} MB ", My.Computer.FileSystem.GetFileInfo(Output).Length / 1024 / 1024))
    End Sub
    Private Delegate Sub UpdateLogInvoker(message As String)
    Private Sub UpdateLog(message As String)
        If ProgressLog.InvokeRequired Then
            ProgressLog.Invoke(New UpdateLogInvoker(AddressOf UpdateLog), message)
        Else
            ProgressLog.AppendText(Date.Now().ToString() + " || " + message + vbCrLf)
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

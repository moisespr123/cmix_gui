Public Class Form1
    Private OutputFileName As String = String.Empty
    Private cmix_version As String = String.Empty
    Private dict As String = String.Empty
    Private Sub CompressRButton_CheckedChanged(sender As Object, e As EventArgs) Handles CompressRButton.CheckedChanged
        InputFileMessage.Text = My.Resources.CompressInputMessage
        OutputFileMessage.Text = My.Resources.CompressOutputMessage
        BrowseFolder.Enabled = True
        UseEngDictCheckbox.Enabled = True
        My.Settings.Compress = CompressRButton.Checked
        My.Settings.Save()
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        InputFileMessage.Text = My.Resources.ExtractInputMessage
        OutputFileMessage.Text = My.Resources.ExtractOutputMessage
        BrowseFolder.Enabled = False
        UseEngDictCheckbox.Enabled = True
        My.Settings.Extract = ExtractRButton.Checked
        My.Settings.Save()
    End Sub


    Private Sub PreprocessRButton_CheckedChanged(sender As Object, e As EventArgs) Handles PreprocessRButton.CheckedChanged
        InputFileMessage.Text = My.Resources.PreprocessInputMessage
        OutputFileMessage.Text = My.Resources.PreprocessOutputMessage
        BrowseFolder.Enabled = True
        My.Settings.Preprocess = PreprocessRButton.Checked
        My.Settings.Save()
        UseEngDictCheckbox.Checked = True
        UseEngDictCheckbox.Enabled = False
        If InputFileTxt.Text IsNot String.Empty Then GetInputNameAndUpdateForm(InputFileTxt.Text)
    End Sub

    Private Function CheckIfFileOrFolder(PathToCheck As String) As String
        If My.Computer.FileSystem.FileExists(PathToCheck) Then
            If CompressRButton.Checked Then OutputFileMessage.Text = My.Resources.CompressOutputMessage
            OutputFileTxt.Enabled = True
            BrowseButton2.Enabled = True
            Return "File"
        ElseIf My.Computer.FileSystem.DirectoryExists(PathToCheck) Then
            If CompressRButton.Checked Then
                OutputFileMessage.Text = My.Resources.CompressFolderSelectedMessage
            ElseIf PreprocessRButton.Checked Then
                OutputFileMessage.Text = My.Resources.PreprocessFolderSelectedMessage
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
            If CompressRButton.Checked Then
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
        If CompressRButton.Checked Then OutputFileTxt.Text = OutputFileName + cmix_version + dict
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CompressRButton.Checked = My.Settings.Compress
        ExtractRButton.Checked = My.Settings.Extract
        PreprocessRButton.Checked = My.Settings.Preprocess
        cmixVersionDropdown.SelectedItem = My.Settings.Version
        UseEngDictCheckbox.Checked = My.Settings.UseEngDict
    End Sub

    Private Sub Run_cmix(Input As String, Output As String, action As String)
        Dim cmixProcessInfo As New ProcessStartInfo
        Dim cmixProcess As Process
        cmixProcessInfo.FileName = My.Settings.Version + ".exe"
        cmixProcessInfo.Arguments = action + " """ & Input & """ """ & Output & """"
        cmixProcessInfo.CreateNoWindow = False
        cmixProcess = Process.Start(cmixProcessInfo)
        cmixProcess.WaitForExit()
    End Sub

    Public Sub ProcessFiles(Folder As String, Action As String)
        For Each File In IO.Directory.GetFiles(Folder)
            Run_cmix(File, File + ".cmix" + cmix_version + dict, Action)
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
                MessageBox.Show("Finished!")
            End If
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

End Class

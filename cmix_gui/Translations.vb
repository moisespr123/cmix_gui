Public Class Translations
    'variables that holds localization messages:
    Public Shared AboutString1 As String = My.Resources.About1
    Public Shared AboutString2 As String = My.Resources.About2
    Public Shared ActionGroupBoxString As String = My.Resources.ActionGroupBox
    Public Shared BrowseFileButton As String = My.Resources.BrowseFileButton
    Public Shared BrowseFolderButton As String = My.Resources.BrowseFolderButton
    Public Shared BrowseOutputButton As String = My.Resources.BrowseOutputButton
    Public Shared ClearLogButtonString As String = My.Resources.ClearLogButton
    Public Shared cmixVersionToUseLabelString As String = My.Resources.cmixVersionToUseLabel
    Public Shared CompressFolderSelectedMessage As String = My.Resources.CompressFolderSelectedMessage
    Public Shared CompressInputMessage As String = My.Resources.CompressInputMessage
    Public Shared CompressOutputMessage As String = My.Resources.CompressOutputMessage
    Public Shared CompressRButtonString As String = My.Resources.CompressRButton
    Public Shared ExtractFolderSelectedMessage As String = My.Resources.ExtractFolderSelectedMessage
    Public Shared ExtractInputMessage As String = My.Resources.ExtractInputMessage
    Public Shared ExtractOutputMessage As String = My.Resources.ExtractOutputMessage
    Public Shared ExtractRButtonString As String = My.Resources.ExtractRButton
    Public Shared LogSaved As String = My.Resources.LogSaved
    Public Shared PreprocessFolderSelectedMessage As String = My.Resources.PreprocessFolderSelectedMessage
    Public Shared PreprocessInputMessage As String = My.Resources.PreprocessInputMessage
    Public Shared PreprocessOutputMessage As String = My.Resources.PreprocessOutputMessage
    Public Shared PreprocessRButtonString As String = My.Resources.PreprocessRButton
    Public Shared SaveLogButtonString As String = My.Resources.SaveLogButton
    Public Shared StartButtonString As String = My.Resources.StartButton
    Public Shared UseDictString As String = My.Resources.UseDict
    Public Shared Finished As String = My.Resources.Finished
    Public Shared FormName As String = My.Resources.FormName
    Public Shared TaskRunningString As String = My.Resources.TaskRunning
    Public Shared ShowCMDString As String = My.Resources.ShowCMD
    Public Shared AvailableRAMString As String = My.Resources.AvailableRAM
    Public Shared UsedRAMString As String = My.Resources.UsedRAM
    Public Shared TotalRAMString As String = My.Resources.TotalRAM
    Private Shared Sub UpdateElementsInForm()
        Form1.GetInputNameAndUpdateForm(Form1.InputFileTxt.Text)
        If Form1.CompressRButton.Checked Then
            Form1.InputFileMessage.Text = CompressInputMessage
        ElseIf Form1.PreprocessRButton.Checked Then
            Form1.InputFileMessage.Text = PreprocessInputMessage
        ElseIf Form1.ExtractRButton.Checked Then
            Form1.InputFileMessage.Text = ExtractInputMessage
        End If
        Form1.AboutLabel1.Text = AboutString1
        Form1.AboutLabel2.Text = AboutString2
        Form1.ActionGroupBox.Text = ActionGroupBoxString
        Form1.BrowseButton1.Text = BrowseFileButton
        Form1.BrowseFolder.Text = BrowseFolderButton
        Form1.BrowseButton2.Text = BrowseOutputButton
        Form1.ClearLogButton.Text = ClearLogButtonString
        Form1.cmixVersionToUseLabel.Text = cmixVersionToUseLabelString
        Form1.CompressRButton.Text = CompressRButtonString
        Form1.PreprocessRButton.Text = PreprocessRButtonString
        Form1.ExtractRButton.Text = ExtractRButtonString
        Form1.SaveLogButton.Text = SaveLogButtonString
        Form1.StartButton.Text = StartButtonString
        Form1.UseEngDictCheckbox.Text = UseDictString
        Form1.ShowCMD.Text = ShowCMDString
        Form1.Text = FormName
    End Sub
    Public Shared Sub UpdateMessageStrings(Language As String)
        If Language = "English" Then
            AboutString1 = My.Resources.About1
            AboutString2 = My.Resources.About2
            ActionGroupBoxString = My.Resources.ActionGroupBox
            BrowseFileButton = My.Resources.BrowseFileButton
            BrowseFolderButton = My.Resources.BrowseFolderButton
            BrowseOutputButton = My.Resources.BrowseOutputButton
            ClearLogButtonString = My.Resources.ClearLogButton
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
            AvailableRAMString = My.Resources.AvailableRAM
            UsedRAMString = My.Resources.UsedRAM
            TotalRAMString = My.Resources.TotalRAM
            ShowCMDString = My.Resources.ShowCMD
        Else
            AboutString1 = My.Resources.About1Spanish
            AboutString2 = My.Resources.About2Spanish
            ActionGroupBoxString = My.Resources.ActionGroupBoxSpanish
            BrowseFileButton = My.Resources.BrowseFileButtonSpanish
            BrowseFolderButton = My.Resources.BrowseFolderButtonSpanish
            BrowseOutputButton = My.Resources.BrowseOutputButtonSpanish
            ClearLogButtonString = My.Resources.ClearLogButtonSpanish
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
            AvailableRAMString = My.Resources.AvailableRAMSpanish
            UsedRAMString = My.Resources.UsedRAMSpanish
            TotalRAMString = My.Resources.TotalRAMSpanish
            ShowCMDString = My.Resources.ShowCMDSpanish
        End If
        UpdateElementsInForm()
    End Sub
End Class

Imports System.IO

Public Class SettingsForm
    Dim checkChanging As Boolean = False, loading As Boolean = True

    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Icon_256

        If Not IsNothing(My.Settings.SimpleSaveOverwriting) AndAlso My.Settings.SimpleSaveOverwriting Then
            SimpleOverwritingCheckBox.Checked = True
        Else ' default is false
            SimpleOverwritingCheckBox.Checked = False
        End If
        If Not IsNothing(My.Settings.SimpleSaveOverwritingPermaDelete) AndAlso My.Settings.SimpleSaveOverwritingPermaDelete = False Then
            RecycleDelete1RadioButton.Checked = True
            PermaDelete1RadioButton.Checked = False
        Else ' default is true
            RecycleDelete1RadioButton.Checked = False
            PermaDelete1RadioButton.Checked = True
        End If
        If SimpleOverwritingCheckBox.Checked Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
        End If

        If Not IsNothing(My.Settings.SaveListPermaDelete) AndAlso My.Settings.SaveListPermaDelete = False Then
            RecycleDelete2RadioButton.Checked = True
            PermaDelete2RadioButton.Checked = False
        Else
            RecycleDelete2RadioButton.Checked = False
            PermaDelete2RadioButton.Checked = True
        End If

        If Not IsNothing(My.Settings.ManualSaveResetInterval) AndAlso My.Settings.ManualSaveResetInterval = False Then
            ResetIntervalCheckBox.Checked = False
        Else ' default is true
            ResetIntervalCheckBox.Checked = True
        End If

        AltSaveNowLocCheckBox.Checked = MainForm.Games.CurrentSettings.AlternateSaveNowLocationEnabled
        AltSaveNowLocTextBox.Text = MainForm.Games.CurrentSettings.AlternateSaveNowLocation

        QuickSaveHotkeyTextBox.Text = KeyStringDisplayForm(MainForm.Games.QuickSaveHotkey)
        QuickLoadHotkeyTextBox.Text = KeyStringDisplayForm(MainForm.Games.QuickLoadHotkey)

        If Not IsNothing(My.Settings.BackupQuickLoad) Then
            BackupQuickLoadCheckBox.Checked = My.Settings.BackupQuickLoad
        End If

        loading = False
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainForm.HotkeysTimer.Start()

        MainForm.SaveMySettings()
    End Sub

    Private Sub SimpleOverwritingCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles SimpleOverwritingCheckBox.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            If SimpleOverwritingCheckBox.Checked = False Then
                My.Settings.SimpleSaveOverwriting = False
            Else
                My.Settings.SimpleSaveOverwriting = True
            End If
            If SimpleOverwritingCheckBox.Checked Then
                GroupBox3.Enabled = True
            Else
                GroupBox3.Enabled = False
            End If
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub

    Private Sub PermaDelete1RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles PermaDelete1RadioButton.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            My.Settings.SimpleSaveOverwritingPermaDelete = True
            PermaDelete1RadioButton.Checked = True
            RecycleDelete1RadioButton.Checked = False
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub
    Private Sub RecycleDelete1RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RecycleDelete1RadioButton.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            My.Settings.SimpleSaveOverwritingPermaDelete = False
            PermaDelete1RadioButton.Checked = False
            RecycleDelete1RadioButton.Checked = True
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub

    Private Sub PermaDelete2RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles PermaDelete2RadioButton.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            My.Settings.SaveListPermaDelete = True
            PermaDelete2RadioButton.Checked = True
            RecycleDelete2RadioButton.Checked = False
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub
    Private Sub RecycleDelete2RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RecycleDelete2RadioButton.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            My.Settings.SaveListPermaDelete = False
            PermaDelete2RadioButton.Checked = False
            RecycleDelete2RadioButton.Checked = True
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub

    Private Sub ResetIntervalCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ResetIntervalCheckBox.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            If ResetIntervalCheckBox.Checked = False Then
                My.Settings.ManualSaveResetInterval = False
            Else
                My.Settings.ManualSaveResetInterval = True
            End If
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub

    Private Sub AltSaveNowLocCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AltSaveNowLocCheckBox.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            If AltSaveNowLocCheckBox.Checked = False Then
                MainForm.Games.CurrentSettings.AlternateSaveNowLocationEnabled = False
            Else
                MainForm.Games.CurrentSettings.AlternateSaveNowLocationEnabled = True
            End If
            MainForm.SaveMySettings()

            If SavesViewer.Visible = True Then
                SavesViewer.ToggleSavesViewerType(SavesViewer.ToggleTypeButton.Text, False)
            End If

            checkChanging = False
        End If
    End Sub

    Private Sub BackupQuickLoadCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BackupQuickLoadCheckBox.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            If BackupQuickLoadCheckBox.Checked = False Then
                My.Settings.BackupQuickLoad = False
            Else
                My.Settings.BackupQuickLoad = True
            End If
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub

    Private Sub AltSaveNowLocTextBox_TextChanged(sender As Object, e As EventArgs) Handles AltSaveNowLocTextBox.TextChanged
        If loading = False Then
            MainForm.Games.CurrentSettings.AlternateSaveNowLocation = AltSaveNowLocTextBox.Text
            If SavesViewer.Visible = True Then
                SavesViewer.ToggleSavesViewerType(SavesViewer.ToggleTypeButton.Text, False)
            End If
        End If
    End Sub

    Private Sub AltSaveNowLocBrowseButton_Click(sender As Object, e As EventArgs) Handles AltSaveNowLocBrowseButton.Click
        If Directory.Exists(AltSaveNowLocTextBox.Text) Then
            FolderBrowserDialog1.SelectedPath = AltSaveNowLocTextBox.Text
        End If
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If Not (result = DialogResult.Cancel OrElse result = DialogResult.Abort) Then
            If FolderBrowserDialog1.SelectedPath <> "" Then
                AltSaveNowLocTextBox.Text = FolderBrowserDialog1.SelectedPath
            End If
        End If
    End Sub

    Private Sub BackgroundImageButton_Click(sender As Object, e As EventArgs) Handles BackgroundImageButton.Click
        BackgroundImageDialog.Show()
    End Sub

    Public IgnoreHotkeyOnce As Boolean = False
    Private Sub HotkeyTextBoxes(sender As Object, e As KeyEventArgs) Handles QuickSaveHotkeyTextBox.KeyDown, QuickLoadHotkeyTextBox.KeyDown
        If Not e.KeyCode.ToString = "ControlKey" AndAlso Not e.KeyCode.ToString = "ShiftKey" AndAlso Not e.KeyCode.ToString = "Menu" Then
            Dim senderTextBox As TextBox = CType(sender, TextBox)

            Dim KeyPressed As String = KeyStringDisplayForm(e.KeyCode)

            If KeyPressed = "Escape" Then

                If senderTextBox.Name = "QuickSaveHotkeyTextBox" Then
                    If Not KeyPressed = QuickLoadHotkeyTextBox.Text Then
                        QuickSaveHotkeyTextBox.Text = "None"
                        MainForm.Games.QuickSaveHotkey = Nothing

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                ElseIf senderTextBox.Name = "QuickLoadHotkeyTextBox" Then
                    If Not KeyPressed = QuickSaveHotkeyTextBox.Text Then
                        QuickLoadHotkeyTextBox.Text = "None"
                        MainForm.Games.QuickLoadHotkey = Nothing

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                End If

            ElseIf e.Modifiers.ToString = "None" Then

                If senderTextBox.Name = "QuickSaveHotkeyTextBox" Then
                    If Not KeyPressed = QuickLoadHotkeyTextBox.Text Then
                        QuickSaveHotkeyTextBox.Text = KeyPressed
                        MainForm.Games.QuickSaveHotkey = e.KeyCode

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                ElseIf senderTextBox.Name = "QuickLoadHotkeyTextBox" Then
                    If Not KeyPressed = QuickSaveHotkeyTextBox.Text Then
                        QuickLoadHotkeyTextBox.Text = KeyPressed
                        MainForm.Games.QuickLoadHotkey = e.KeyCode

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                End If

            Else
                'QuickSaveHotkeyTextBox.Text = e.Modifiers.ToString & "+" & KeyPressed
                'MainForm.QuickSaveHotKey = e.KeyCode
                'MainForm.CurrentSave.QuickSaveHotKey = e.KeyCode
            End If
        End If
    End Sub

    Private Shared Function KeyStringDisplayForm(KyCode As Keys) As String
        Dim key As String = KyCode.ToString
        Select Case (key)
            Case "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9"
                Return key.Substring(1)
            Case "OemPeriod"
                Return "."
            Case "Oemcomma"
                Return ","
            Case "OemQuestion"
                Return "?"
            Case "OemOpenBrackets"
                Return "["
            Case "Oem1"
                Return ";"
            Case "Oem7"
                Return "'"
            Case "Oem5"
                Return "\"
            Case "Oem6"
                Return "]"
            Case "OemMinus"
                Return "-"
            Case "Oemplus"
                Return "+"
            Case "Oemtilde"
                Return "+"
            Case "Escape"
                Return "Escape"
            Case Else
                Return key
        End Select
    End Function

    Private Sub HotkeyTextBox_Enter(sender As Object, e As EventArgs) Handles QuickSaveHotkeyTextBox.Enter, QuickLoadHotkeyTextBox.Enter
        MainForm.HotkeysTimer.Stop()
    End Sub

    Private Sub HotkeyTextBox_Leave(sender As Object, e As EventArgs) Handles QuickSaveHotkeyTextBox.Leave, QuickLoadHotkeyTextBox.Leave
        MainForm.HotkeysTimer.Start()
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub

    Private Sub Directory_DragDrop(sender As Object, e As DragEventArgs) Handles AltSaveNowLocTextBox.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim directories As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If Directory.Exists(directories(0)) Then
                CType(sender, TextBox).Text = directories(0)
                Me.ActiveControl = Nothing
            End If
        End If
    End Sub

    Private Sub Directory_DragEnter(sender As Object, e As DragEventArgs) Handles AltSaveNowLocTextBox.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub
End Class
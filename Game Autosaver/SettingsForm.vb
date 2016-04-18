Public Class SettingsForm
    Dim checkChanging As Boolean = False, loading As Boolean = True

    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Icon_256

        If Not IsNothing(My.Settings.SimpleAutosaveOverwriting) AndAlso My.Settings.SimpleAutosaveOverwriting = True Then
            SimpleOverwritingCheckBox.Checked = True
        Else ' default is false
            SimpleOverwritingCheckBox.Checked = False
        End If
        If Not IsNothing(My.Settings.SimpleAutosaveOverwritingPermaDelete) AndAlso My.Settings.SimpleAutosaveOverwritingPermaDelete = False Then
            RecycleDelete1RadioButton.Checked = True
            PermaDelete1RadioButton.Checked = False
        Else ' default is true
            RecycleDelete1RadioButton.Checked = False
            PermaDelete1RadioButton.Checked = True
        End If
        If SimpleOverwritingCheckBox.Checked = True Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
        End If

        If Not IsNothing(My.Settings.ManualSaveResetInterval) AndAlso My.Settings.ManualSaveResetInterval = False Then
            ResetIntervalCheckBox.Checked = False
        Else ' default is true
            ResetIntervalCheckBox.Checked = True
        End If

        If Not IsNothing(My.Settings.AlternateSaveNowLocationEnabled) AndAlso My.Settings.AlternateSaveNowLocationEnabled = True Then
            AltSaveNowLocCheckBox.Checked = True
        Else ' default is false
            AltSaveNowLocCheckBox.Checked = False
        End If

        If Not IsNothing(My.Settings.AlternateSaveNowLocation) Then
            AltSaveNowLocTextBox.Text = My.Settings.AlternateSaveNowLocation
        End If

        If Not IsNothing(My.Settings.QuickSaveHotKey) Then
            QuickSaveHotkeyTextBox.Text = KeyStringDisplayForm(My.Settings.QuickSaveHotKey)
        End If
        If Not IsNothing(My.Settings.QuickLoadHotKey) Then
            QuickLoadHotkeyTextBox.Text = KeyStringDisplayForm(My.Settings.QuickLoadHotKey)
        End If

        If Not IsNothing(My.Settings.BackupQuickLoad) Then
            BackupQuickLoadCheckBox.Checked = My.Settings.BackupQuickLoad
        End If

        loading = False
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Hotkeys.Show()

        My.Settings.Save()
    End Sub

    Private Sub SimpleOverwritingCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles SimpleOverwritingCheckBox.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            If SimpleOverwritingCheckBox.Checked = False Then
                My.Settings.SimpleAutosaveOverwriting = False
            Else
                My.Settings.SimpleAutosaveOverwriting = True
            End If
            If SimpleOverwritingCheckBox.Checked = True Then
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

            My.Settings.SimpleAutosaveOverwritingPermaDelete = True
            PermaDelete1RadioButton.Checked = True
            RecycleDelete1RadioButton.Checked = False
            My.Settings.Save()

            checkChanging = False
        End If
    End Sub

    Private Sub RecycleDelete1RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RecycleDelete1RadioButton.CheckedChanged
        If Not checkChanging AndAlso loading = False Then
            checkChanging = True

            My.Settings.SimpleAutosaveOverwritingPermaDelete = False
            PermaDelete1RadioButton.Checked = False
            RecycleDelete1RadioButton.Checked = True
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
                My.Settings.AlternateSaveNowLocationEnabled = False
            Else
                My.Settings.AlternateSaveNowLocationEnabled = True
            End If
            My.Settings.Save()

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
            My.Settings.AlternateSaveNowLocation = AltSaveNowLocTextBox.Text
        End If
    End Sub

    Private Sub AltSaveNowLocBrowseButton_Click(sender As Object, e As EventArgs) Handles AltSaveNowLocBrowseButton.Click
        If IO.Directory.Exists(AltSaveNowLocTextBox.Text) Then
            FolderBrowserDialog1.SelectedPath = AltSaveNowLocTextBox.Text
        End If
        If Not (FolderBrowserDialog1.ShowDialog() = DialogResult.Cancel Or DialogResult.Abort) Then
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

            Dim KeyPressed As String = KeyStringDisplayForm(e.KeyCode)

            If KeyPressed = "Escape" Then

                If sender.Name = "QuickSaveHotkeyTextBox" Then
                    If Not KeyPressed = QuickLoadHotkeyTextBox.Text Then
                        QuickSaveHotkeyTextBox.Text = "None"
                        MainForm.QuickSaveHotKey = Nothing
                        My.Settings.QuickSaveHotKey = Nothing

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                ElseIf sender.Name = "QuickLoadHotkeyTextBox" Then
                    If Not KeyPressed = QuickSaveHotkeyTextBox.Text Then
                        QuickLoadHotkeyTextBox.Text = "None"
                        MainForm.QuickLoadHotKey = Nothing
                        My.Settings.QuickLoadHotKey = Nothing

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                End If

            ElseIf e.Modifiers.ToString = "None" Then

                If sender.Name = "QuickSaveHotkeyTextBox" Then
                    If Not KeyPressed = QuickLoadHotkeyTextBox.Text Then
                        QuickSaveHotkeyTextBox.Text = KeyPressed
                        MainForm.QuickSaveHotKey = e.KeyCode
                        My.Settings.QuickSaveHotKey = e.KeyCode

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                ElseIf sender.Name = "QuickLoadHotkeyTextBox" Then
                    If Not KeyPressed = QuickSaveHotkeyTextBox.Text Then
                        QuickLoadHotkeyTextBox.Text = KeyPressed
                        MainForm.QuickLoadHotKey = e.KeyCode
                        My.Settings.QuickLoadHotKey = e.KeyCode

                        MainForm.HotkeysChangeLock = True
                        IgnoreHotkeyOnce = True
                    Else
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    End If
                End If

            Else
                'QuickSaveHotkeyTextBox.Text = e.Modifiers.ToString & "+" & KeyPressed
                'MainForm.QuickSaveHotKey = e.KeyCode
                'My.Settings.QuickSaveHotKey = e.KeyCode
            End If
        End If
    End Sub

    Private Function KeyStringDisplayForm(KyCode As Keys) As String
        Select Case (KyCode.ToString)
            Case "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9"
                Return KyCode.ToString.Substring(1)
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
                Return KyCode.ToString
        End Select
    End Function

    Private Sub QuickSaveHotkeyTextBox_Enter(sender As Object, e As EventArgs) Handles QuickSaveHotkeyTextBox.Enter
        Hotkeys.Close()
    End Sub

    Private Sub QuickSaveHotkeyTextBox_Leave(sender As Object, e As EventArgs) Handles QuickSaveHotkeyTextBox.Leave
        Hotkeys.Show()
    End Sub

    Private Sub QuickLoadHotkeyTextBox_Enter(sender As Object, e As EventArgs) Handles QuickLoadHotkeyTextBox.Enter
        Hotkeys.Close()
    End Sub

    Private Sub QuickLoadHotkeyTextBox_Leave(sender As Object, e As EventArgs) Handles QuickLoadHotkeyTextBox.Leave
        Hotkeys.Show()
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub
End Class
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

        loading = False
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub
End Class
Public Class GameList

    ' Save format (With My.Settings.)
    ' .Name<\?/>.GameSaveDirectory<\?/>.AutosaveStorageDirectory<\?/>.AutosaveIntervalMinutes<\?/>.SaveCounter<\?/>
    ' .OverwriteSaves<\?/>.BackgroundImageLoc<\?/>.RoundRobinEnabled<\?/>.AutosaveLimit<\?/>.AlternateSaveNowLocationEnabled<\?/>.AlternateSaveNowLocation
    ' <\?/>.QuickSaveCounter<\?/>.LastQuickSavePath

    Private Sub GameList_Load() Handles MyBase.Load
        Icon = My.Resources.Icon_256

        If IsNothing(My.Settings.GameList) Then
            My.Settings.GameList = New Specialized.StringCollection
        End If

        If My.Settings.GameList.Count > 0 Then

            Dim GameData As New List(Of String())
            For Each element As String In My.Settings.GameList
                GameData.Add(Split(element, "<\?/>"))
            Next

            For Each e As String() In GameData
                If Not IsNothing(e) AndAlso e.Length > 0 Then
                    Dim NewRowIndex = DataGridView1.Rows.Add(e(0), "Load", "Remove")
                    Try
                        DataGridView1.Item(3, NewRowIndex).Value = e(1)
                        DataGridView1.Item(4, NewRowIndex).Value = e(2)
                        DataGridView1.Item(5, NewRowIndex).Value = e(3)
                        DataGridView1.Item(6, NewRowIndex).Value = e(4)

                        Dim test As Boolean = False
                        If Boolean.TryParse(e(5), test) = True Then
                            DataGridView1.Item(7, NewRowIndex).Value = CBool(e(5))
                        Else ' default is false
                            DataGridView1.Item(7, NewRowIndex).Value = False
                        End If

                        DataGridView1.Item(8, NewRowIndex).Value = e(6)

                        If Boolean.TryParse(e(7), test) = True Then
                            DataGridView1.Item(9, NewRowIndex).Value = CBool(e(7))
                        Else ' default is false
                            DataGridView1.Item(9, NewRowIndex).Value = False
                        End If

                        DataGridView1.Item(10, NewRowIndex).Value = e(8)

                        If Boolean.TryParse(e(9), test) = True Then
                            DataGridView1.Item(11, NewRowIndex).Value = CBool(e(9))
                        Else ' default is false
                            DataGridView1.Item(11, NewRowIndex).Value = False
                        End If
                        DataGridView1.Item(12, NewRowIndex).Value = e(10)

                        DataGridView1.Item(13, NewRowIndex).Value = e(11) ' QuickSaveCounter

                        DataGridView1.Item(14, NewRowIndex).Value = e(12) ' LastQuickSavePath
                    Catch ex As System.IndexOutOfRangeException
                    End Try

                    If e(0) = MainForm.Label6.Text Then ' currently open save
                        Dim CellBtn As New DataGridViewButtonCell
                        CellBtn.Value = "Current"
                        DataGridView1.Item(1, NewRowIndex) = CellBtn
                    End If
                    DataGridView1.Rows(NewRowIndex).Selected = False
                End If
            Next
        End If

        ' add current MainForm data to datagridview if it isn't already present in My.Settings as a save
        Dim foundIt As Boolean = False
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Item(0, i).Value = MainForm.Label6.Text Then
                foundIt = True
                Exit For
            End If
        Next
        If foundIt = False Then
            With My.Settings
                Dim NewRowIndex As Integer = AddRowFromCurrent() ' add a DataGridView row from current MainForm configurations
                Dim CellBtn As New DataGridViewButtonCell
                CellBtn.Value = "Current"
                DataGridView1.Item(1, NewRowIndex) = CellBtn
                DataGridView1.Rows(NewRowIndex).Selected = False
            End With
        End If
    End Sub

    Private Sub GameList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'My.Settings.Save()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Select Case e.ColumnIndex
            Case 1 ' Load Button
                LoadGame(e.RowIndex)
            Case 2 ' Remove Button
                RemoveGame(e.RowIndex)
        End Select
    End Sub

    ''' <summary>
    ''' Load a corresponding row in the DataGridView.
    ''' </summary>
    ''' <param name="row">The corresponding row.</param>
    Private Sub LoadGame(row As Integer)
        If DataGridView1.Item(1, row).Value = "Current" Then
            MsgBox("This is already active.", MsgBoxStyle.Information, "Error")
        Else
            StopAnyMainFormWork() ' stop any active elements
            MainForm.MainForm_FormClosing() ' update settings

            Dim foundIt As Boolean = False
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Item(0, i).Value = MainForm.Label6.Text Then ' find currently loaded game/name
                    foundIt = True
                    RemoveGameFromSettings(i) ' remove the current row (before loading) from settings temporarily
                    With My.Settings ' update currently loaded save's respective row info before loading different one 
                        DataGridView1.Item(0, i).Value = .Name
                        DataGridView1.Item(3, i).Value = .GameSaveDirectory
                        DataGridView1.Item(4, i).Value = .AutosaveStorageDirectory
                        DataGridView1.Item(5, i).Value = .AutosaveIntervalMinutes
                        DataGridView1.Item(6, i).Value = .AutoSaveCounter
                        DataGridView1.Item(7, i).Value = .OverwriteSaves
                        DataGridView1.Item(8, i).Value = .BackgroundImageLoc
                        DataGridView1.Item(9, i).Value = .RoundRobinEnabled
                        DataGridView1.Item(10, i).Value = .AutosaveLimit
                        DataGridView1.Item(11, i).Value = .AlternateSaveNowLocationEnabled
                        DataGridView1.Item(12, i).Value = .AlternateSaveNowLocation
                        DataGridView1.Item(13, i).Value = .QuickSaveCounter
                        DataGridView1.Item(14, i).Value = .LastQuickSavePath
                    End With
                End If
            Next
            If foundIt = False Then ' currently loaded info not found as row
                AddRowFromCurrent() ' add a DataGridView row from current MainForm configurations
            End If

            Dim test As Boolean = False
            With My.Settings
                .Name = DataGridView1.Item(0, row).Value

                If Not IsNothing(DataGridView1.Item(3, row).Value) Then
                    .GameSaveDirectory = DataGridView1.Item(3, row).Value
                Else ' default
                    .GameSaveDirectory = ""
                End If

                If Not IsNothing(DataGridView1.Item(4, row).Value) Then
                    .AutosaveStorageDirectory = DataGridView1.Item(4, row).Value
                Else ' default
                    .AutosaveStorageDirectory = ""
                End If

                If Not IsNothing(DataGridView1.Item(5, row).Value) Then
                    .AutosaveIntervalMinutes = DataGridView1.Item(5, row).Value
                Else ' default
                    .AutosaveIntervalMinutes = 5
                End If

                If Not IsNothing(DataGridView1.Item(6, row).Value) Then
                    .AutoSaveCounter = DataGridView1.Item(6, row).Value
                Else ' default
                    .AutoSaveCounter = 1
                End If

                If Boolean.TryParse(DataGridView1.Item(7, row).Value, test) = True Then
                    .OverwriteSaves = DataGridView1.Item(7, row).Value
                Else ' default
                    .OverwriteSaves = False
                End If

                If Not IsNothing(DataGridView1.Item(8, row).Value) Then
                    .BackgroundImageLoc = DataGridView1.Item(8, row).Value
                Else ' default
                    .BackgroundImageLoc = ""
                End If

                If Boolean.TryParse(DataGridView1.Item(9, row).Value, test) = True Then
                    .RoundRobinEnabled = DataGridView1.Item(9, row).Value
                Else ' default
                    .RoundRobinEnabled = False
                End If

                If Not IsNothing(DataGridView1.Item(10, row).Value) Then
                    .AutosaveLimit = DataGridView1.Item(10, row).Value
                Else ' default
                    .AutosaveLimit = 79228162514264337593543950335D
                End If

                If Boolean.TryParse(DataGridView1.Item(11, row).Value, test) = True Then
                    .AlternateSaveNowLocationEnabled = DataGridView1.Item(11, row).Value
                Else ' default
                    .AlternateSaveNowLocationEnabled = False
                End If

                If Not IsNothing(DataGridView1.Item(12, row).Value) Then
                    .AlternateSaveNowLocation = DataGridView1.Item(12, row).Value
                Else ' default
                    .AlternateSaveNowLocation = ""
                End If

                If Not IsNothing(DataGridView1.Item(13, row).Value) Then
                    .QuickSaveCounter = DataGridView1.Item(13, row).Value
                Else ' default
                    .QuickSaveCounter = 1D
                End If

                If Not IsNothing(DataGridView1.Item(14, row).Value) Then
                    .LastQuickSavePath = DataGridView1.Item(14, row).Value
                Else ' default
                    .LastQuickSavePath = ""
                End If

            End With

            MainForm.MainForm_Load()

            SaveGames() ' save ALL of the DataGridView rows
            My.Settings.Save()

            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Stop any active elements in the MainForm.
    ''' </summary>
    Private Sub StopAnyMainFormWork()
        SyncLock MainForm.accessLock
            If MainForm.StartButton.Text = "Stop Autosaving" Then
                MainForm.StartButton.PerformClick() ' stop autosaving
            End If
        End SyncLock
        SettingsForm.Close()
        BackgroundImageDialog.Close()
    End Sub

    ''' <summary>
    ''' Remove a specified row and all it's data from the form and My.Settings
    ''' </summary>
    ''' <param name="row">Corresponding row. (Name and settings data row)</param>
    Private Sub RemoveGame(row As Integer)
        If DataGridView1.Rows.Count > 0 Then
            If DataGridView1.Item(1, row).Value = "Current" Then
                MsgBox("This is currently active so it can't be deleted.", MsgBoxStyle.Information, "Error")
            Else
                RemoveGameFromSettings(row)

                DataGridView1.Rows.RemoveAt(row)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Remove game from My.Settings list by DataGridView row corresponding name.
    ''' </summary>
    Private Sub RemoveGameFromSettings(row As Integer)
        For i As Integer = 0 To My.Settings.GameList.Count - 1 'DataGridView1.Item(0, row).Value & "<\?/>"
            For j As Integer = 0 To My.Settings.GameList(i).Length - 1
                If My.Settings.GameList(i)(j) = "<"c AndAlso My.Settings.GameList(i).Length - 1 >= j + 4 AndAlso
                       My.Settings.GameList(i)(j + 1) = "\"c AndAlso
                       My.Settings.GameList(i)(j + 2) = "?"c AndAlso
                       My.Settings.GameList(i)(j + 3) = "/"c AndAlso
                       My.Settings.GameList(i)(j + 4) = ">"c Then

                    Dim settingName As String = (My.Settings.GameList(i).Substring(0, j))
                    If settingName = DataGridView1.Item(0, row).Value Then
                        My.Settings.GameList.RemoveAt(i)
                        GoTo EndOfForLoops1
                    End If
                End If
            Next
        Next
EndOfForLoops1:
    End Sub

    ''' <summary>
    ''' Save all games (rows) present in DataGridView currently to My.Settings game list.
    ''' </summary>
    Private Sub SaveGames()
        Dim currentCount As Integer = 0
        Dim GameDataTemp As String()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If Not My.Settings.GameList.Count = 0 Then
                For k As Integer = 0 To My.Settings.GameList.Count - 1
                    GameDataTemp = Split(My.Settings.GameList(k), "<\?/>")
                    If GameDataTemp(0) = DataGridView1.Item(0, i).Value Then
                        Exit For ' same name found so don't save
                    End If
                    If k = My.Settings.GameList.Count - 1 Then
                        My.Settings.GameList.Add(ReconstructDataGridViewSettingString(i))
                    End If
                Next
            Else
                My.Settings.GameList.Add(ReconstructDataGridViewSettingString(i))
            End If
        Next

    End Sub

    ''' <summary>
    ''' Create and add a default configuration row to the DataGridView
    ''' </summary>
    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click
        Dim NewGame As String = InputBox("Enter a name", "New", "GAME AUTOSAVER")
        Dim charLimit As Integer = 300
        If IsNothing(NewGame) OrElse NewGame = "" Then
            MsgBox("Name entered is empty.", MsgBoxStyle.Exclamation, "Error")
        ElseIf NewGame.Length >= charLimit Then
            MsgBox("Name cannot be longer than " & charLimit & ".", MsgBoxStyle.Exclamation, "Error")
        Else
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Item(0, i).Value = NewGame Then
                    MsgBox("This name already exists!", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                End If
            Next

            With My.Settings
                DataGridView1.Rows.Add(NewGame, "Load", "Remove", "", "", "5", "1", False, "", False, "79228162514264337593543950335", False, "", "1", "")
            End With
            SaveGames()
        End If
    End Sub

    ''' <summary>
    ''' Reconstruct the string in which named saves are stored in My.Settings
    ''' </summary>
    ''' <param name="row">Corresponding DataGridView row.</param>
    Private Function ReconstructDataGridViewSettingString(row As Integer)
        Return DataGridView1.Item(0, row).Value & "<\?/>" &
        DataGridView1.Item(3, row).Value & "<\?/>" &
        DataGridView1.Item(4, row).Value & "<\?/>" &
        DataGridView1.Item(5, row).Value & "<\?/>" &
        DataGridView1.Item(6, row).Value & "<\?/>" &
        DataGridView1.Item(7, row).Value & "<\?/>" &
        DataGridView1.Item(8, row).Value & "<\?/>" &
        DataGridView1.Item(9, row).Value & "<\?/>" &
        DataGridView1.Item(10, row).Value & "<\?/>" &
        DataGridView1.Item(11, row).Value & "<\?/>" &
        DataGridView1.Item(12, row).Value & "<\?/>" &
        DataGridView1.Item(13, row).Value & "<\?/>" &
        DataGridView1.Item(14, row).Value

        ' Save format (My.Settings)
    End Function

    ''' <summary>
    ''' Add a row from the current data being used in MainForm etc.
    ''' </summary>
    ''' <returns>Returns the index of the new row</returns>
    Private Function AddRowFromCurrent() As Integer

        Dim index As Integer
        With MainForm
            Dim overwriteState As Boolean
            If .OverwriteComboBox.SelectedIndex = 0 Then
                overwriteState = False
            Else
                overwriteState = True
            End If

            Dim roundRobinState As Boolean = False
            If .RoundRobinButton.Text = "Disabled" Then
                roundRobinState = False
            ElseIf .RoundRobinButton.Text = "Enabled" Then
                roundRobinState = True
            End If

            Dim autosaveLimit As Decimal = 79228162514264337593543950335D
            If Not IsNothing(My.Settings.AutosaveLimit) Then
                autosaveLimit = My.Settings.AutosaveLimit
            End If

            index = DataGridView1.Rows.Add(.Label6.Text, "Load", "Remove", .TextBox1.Text, .TextBox2.Text, CStr(.NumericUpDown1.Value),
                                   .SaveCountTextBox.Text, overwriteState, My.Settings.BackgroundImageLoc, roundRobinState, autosaveLimit,
                                   My.Settings.AlternateSaveNowLocationEnabled, My.Settings.AlternateSaveNowLocation, My.Settings.QuickSaveCounter,
                                   My.Settings.LastQuickSavePath)
        End With

        Return index
    End Function
End Class
Imports Newtonsoft.Json

Public Class GameList

    Private Sub GameList_Load() Handles MyBase.Load
        Icon = My.Resources.Icon_256

        MainForm.Games.SaveCurrentSettings(MainForm.ThisForm)

        If MainForm.Games.GameList.Count > 0 Then
            For Each e As GameSettings In MainForm.Games.GameList.Values
                Dim NewRowIndex As Integer = DataGridView1.Rows.Add(e.Name, "Load", "Remove")

                If e.Name = MainForm.Label6.Text Then ' currently open save
                    Dim CellBtn As New DataGridViewButtonCell
                    CellBtn.Value = "Current"
                    DataGridView1.Item(1, NewRowIndex) = CellBtn
                End If
                DataGridView1.Rows(NewRowIndex).Selected = False
            Next
            DataGridView1.Sort(DataGridView1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
        End If

    End Sub

    Private Sub GameList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex > -1 Then
            Select Case e.ColumnIndex
                Case 1 ' Load Button
                    LoadGame(e.RowIndex)
                Case 2 ' Remove Button
                    RemoveGame(e.RowIndex)
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Load a corresponding row in the DataGridView.
    ''' </summary>
    ''' <param name="row">The corresponding row.</param>
    Private Sub LoadGame(row As Integer)
        If row >= 0 Then
            If CStr(DataGridView1.Item(1, row).Value) = "Current" Then
                MsgBox("This is already active.", MsgBoxStyle.Information, "Error")
            Else
                If DataGridView1.SelectedCells.Count > 0 Then

                    Dim idx As Integer = DataGridView1.SelectedCells.Item(0).RowIndex
                    Dim Name As String = CStr(DataGridView1.Item(0, idx).Value)
                    If MainForm.Games.GameList.ContainsKey(Name) Then
                        StopAnyMainFormWork() ' stop any active elements
                        MainForm.MainForm_FormClosing() ' update settings

                        If MainForm.Games.LoadSave(MainForm.ThisForm, Name) Then
                            My.Settings.Saves = JsonConvert.SerializeObject(MainForm.Games)
                            My.Settings.Save()
                            MainForm.TopMost = True
                            MainForm.TopMost = False
                            Me.Close()
                        Else
                            MsgBox("Could not find game data.", MsgBoxStyle.Exclamation, "Error")
                        End If
                    Else
                        MsgBox("Could not find saved game with that name.", MsgBoxStyle.Exclamation, "Error")
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub ResortDataGridView()
        If DataGridView1.SortOrder <> SortOrder.None AndAlso DataGridView1.SortedColumn IsNot Nothing Then
            Dim Direction As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Ascending
            If DataGridView1.SortOrder = SortOrder.Descending Then
                Direction = System.ComponentModel.ListSortDirection.Descending
            End If
            DataGridView1.Sort(DataGridView1.SortedColumn, Direction)
        End If
    End Sub

    ''' <summary>
    ''' Stop any active elements in the MainForm.
    ''' </summary>
    Private Shared Sub StopAnyMainFormWork()
        SyncLock MainForm.accessLock
            If MainForm.StartButton.Text = "Stop Autosaving" Then
                MainForm.StartButton.PerformClick() ' stop autosaving
            End If
        End SyncLock
        SettingsForm.Close()
        BackgroundImageDialog.Close()
        SavesViewer.Close()
    End Sub

    ''' <summary>
    ''' Remove a specified row and all it's data from settings.
    ''' </summary>
    ''' <param name="row">Corresponding row. (Name and settings data row)</param>
    Private Sub RemoveGame(row As Integer)
        If row >= 0 Then
            If DataGridView1.Rows.Count > 0 Then
                If CStr(DataGridView1.Item(1, row).Value) = "Current" Then
                    MsgBox("This is currently active so it can't be deleted.", MsgBoxStyle.Information, "Error")
                Else
                    My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    Dim result As MsgBoxResult = MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Warning")
                    If result = MsgBoxResult.Yes Then
                        If MainForm.Games.GameList.Remove(CStr(DataGridView1.Item(0, row).Value)) Then
                            DataGridView1.Rows.RemoveAt(row)
                        Else
                            MsgBox("Could not find data to delete!", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Const GameNameCharLimit As Integer = 300
    ''' <summary>
    ''' Create and add a new row to the DataGridView
    ''' </summary>
    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click
        Dim NewGame As String = InputBox("Enter a name", "New", "")

        If NewGame = "" Then
            'My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        ElseIf NewGame.Length >= GameNameCharLimit Then
            MsgBox("Name cannot be longer than " & GameNameCharLimit & ".", MsgBoxStyle.Exclamation, "Error")
        Else
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If CStr(DataGridView1.Item(0, i).Value) = NewGame Then
                    MsgBox("This name already exists!", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                End If
            Next

            MainForm.Games.GameList.Add(NewGame, New GameSettings)
            MainForm.Games.GameList(NewGame).Name = NewGame
            DataGridView1.Rows.Add(NewGame, "Load", "Remove")
            ResortDataGridView()
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        ' renaming row
        If e.ColumnIndex = 0 AndAlso DataGridView1.SelectedCells.Count > 0 Then
            Dim NewName As String = CStr(DataGridView1.Item(e.ColumnIndex, EdittedRow).Value)
            If NewName <> "" Then
                If MainForm.Games.RenameGameName(MainForm.ThisForm, OldName, NewName) Then
                    MainForm.SaveMySettings()
                Else
                    MsgBox("Name already exists.", MsgBoxStyle.Exclamation)
                End If
            End If
        End If
    End Sub

    Private EdittedRow As Integer = -1
    Private OldName As String = ""
    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        EdittedRow = e.RowIndex
        OldName = CStr(DataGridView1.Item(0, e.RowIndex).Value)
    End Sub
End Class
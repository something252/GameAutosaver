Imports System.IO

Public Class SavesViewer

    Private Class DataGridInfo
        Public SaveNames As New List(Of KeyValuePair(Of String, String)) ' file path, file name
        Public SaveLastModifiedDates As New List(Of Date)
    End Class
    Dim DataList As DataGridInfo
    Dim CurrentSaveText As String

    Private Sub SavesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Icon_256

        CurrentSaveText = MainForm.AutoSaveFileString
        If Not LoadItems(MainForm.Games.CurrentSettings.AutoSaveStorageDirectory, CurrentSaveText) Then
            MsgBox("Save directory does not exist.", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
    End Sub

    Private Sub SavesList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FileSystemWatcher1.Dispose()
    End Sub

    ''' <summary>
    ''' Load items into DataGridView.
    ''' </summary>
    ''' <param name="SavePath">Main directory to use look in</param>
    ''' <param name="SaveText">Text phrase at the start of every save to look for.</param>
    Private Function LoadItems(SavePath As String, SaveText As String) As Boolean
        If Directory.Exists(SavePath) Then
            FileSystemWatcher1.Path = SavePath
            DataList = New DataGridInfo
            SaveDataGridView.Rows.Clear()
            Dim TempList As String() = Directory.GetDirectories(SavePath)
            If TempList IsNot Nothing Then

                Dim foundBackupDir As Boolean = False
                For Each dir As String In TempList
                    Dim name As String = MainForm.GetFileName(dir)
                    If TestStringPartial(SaveText, name, True) Then
                        If name.Length >= SaveText.Length + 1 Then
                            Dim TestStr As String = name.Substring(SaveText.Length + 1)
                            If TestStr IsNot Nothing AndAlso TestStr <> "" AndAlso IsNumeric(TestStr) Then
                                Dim num1 As Integer
                                If Integer.TryParse(TestStr, num1) Then
                                    DataList.SaveNames.Add(New KeyValuePair(Of String, String)(dir, name))
                                    DataList.SaveLastModifiedDates.Add(My.Computer.FileSystem.GetFileInfo(dir).LastWriteTime) ' last modified
                                End If
                            End If

                        End If
                    Else
                        If Not foundBackupDir AndAlso TestStringPartial("Last Restore Temporary Backup", name, True) Then
                            foundBackupDir = True
                            DataList.SaveNames.Add(New KeyValuePair(Of String, String)(dir, name))
                            DataList.SaveLastModifiedDates.Add(My.Computer.FileSystem.GetFileInfo(dir).LastWriteTime) ' last modified
                        End If
                    End If
                Next

            End If

            For i As Integer = 0 To DataList.SaveNames.Count - 1
                SaveDataGridView.Rows.Add(DataList.SaveNames(i).Value, DataList.SaveLastModifiedDates(i), "Load")
            Next
            SaveDataGridView.Sort(SaveDataGridView.Columns.Item(1), System.ComponentModel.ListSortDirection.Descending)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SaveDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SaveDataGridView.CellClick
        If e.RowIndex > -1 Then
            Select Case e.ColumnIndex
                Case 2 ' Load Button
                    Dim Name As String = CStr(SaveDataGridView(0, e.RowIndex).Value)
                    Dim i As Integer
                    For i = 0 To DataList.SaveNames.Count - 1
                        If DataList.SaveNames(i).Value = Name Then
                            Exit For
                        End If
                    Next
                    LoadSave(DataList.SaveNames(i).Key, MainForm.TextBox1.Text)
            End Select
        End If
    End Sub

    Private Sub LoadSave(savePath As String, destinationPath As String)
        If Not Directory.Exists(savePath) Then
            MsgBox("Load failed!" & vbNewLine & vbNewLine & "Save does not exist: " & """" & savePath & """", MsgBoxStyle.Critical)
        ElseIf Directory.Exists(destinationPath) Then
            savePath = savePath.TrimEnd("\"c)
            destinationPath = destinationPath.TrimEnd("\"c)

            If IsNothing(My.Settings.ManualSaveResetInterval) OrElse My.Settings.ManualSaveResetInterval Then
                SyncLock MainForm.timer1Lock
                    If MainForm.StartButton.Text = "Stop Autosaving" Then ' currently autosaving
                        MainForm.SaveTimerPtr.Stop()
                        Me.BackColor = Color.Gold ' reset color
                        MainForm.StartSaving()
                    End If
                End SyncLock
            End If

            SyncLock MainForm.timer1Lock
                Try
                    If My.Settings.BackupQuickLoad AndAlso MainForm.GetFileName(savePath) <> "Last Restore Temporary Backup" Then ' if quick load backup enabled
                        MainForm.TextBox2.Text = MainForm.TextBox2.Text.TrimEnd("\"c)
                        Dim BackupDestination As String = MainForm.TextBox2.Text & "\" & "Last Restore Temporary Backup"
                        If Directory.Exists(BackupDestination) Then
                            My.Computer.FileSystem.DeleteDirectory(BackupDestination, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                        My.Computer.FileSystem.CopyDirectory(destinationPath, BackupDestination)
                    End If

                    My.Computer.FileSystem.DeleteDirectory(destinationPath, FileIO.DeleteDirectoryOption.DeleteAllContents) ' delete destination

                    My.Computer.FileSystem.CopyDirectory(savePath, destinationPath) ' copy to destination
                Catch ex As Exception
                    My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    MsgBox(ex.Message)
                End Try
            End SyncLock
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub

    ''' <summary>
    ''' Test a partial string against another string (with partial string tested as aligned from start or end of other string)
    ''' </summary>
    ''' <param name="PartialStr">Partial string</param>
    ''' <param name="AgainstStr">String to be tested against</param>
    ''' <param name="fromStart">Determines whether to test against string from start (to right) or end (to left)</param>
    Public Shared Function TestStringPartial(partialStr As String, againstStr As String, Optional fromStart As Boolean = True) As Boolean
        If partialStr IsNot Nothing AndAlso againstStr IsNot Nothing AndAlso Not partialStr.Length > againstStr.Length Then
            If partialStr.Length = 0 AndAlso againstStr.Length = 0 Then
                Return True
            End If
            If fromStart Then ' from start (left)
                For i As Integer = 0 To partialStr.Length - 1
                    If partialStr(i) <> againstStr(i) Then
                        Return False
                    End If
                Next
            Else ' from end (right)
                Dim againstCount = againstStr.Length - 1
                For i As Integer = partialStr.Length - 1 To 0 Step -1
                    If partialStr(i) <> againstStr(againstCount) Then
                        Return False
                    End If
                    againstCount -= 1
                Next
            End If
            Return True
        End If
        Return False
    End Function

    Public Sub ToggleTypeButton_Click() Handles ToggleTypeButton.Click
        ToggleSavesViewerType(ToggleTypeButton.Text)
        Me.ActiveControl = SaveDataGridView
    End Sub

    Public Sub ToggleSavesViewerType(type As String, Optional toggle As Boolean = True)
        If type = "Autosaves" Then
            If toggle Then
                ViewQuickSaves()
            Else
                ViewAutoSaves()
            End If
        ElseIf type = "Quick Saves" Then
            If toggle Then
                ViewAutoSaves()
            Else
                ViewQuickSaves()
            End If
        End If
    End Sub

    Private Sub ViewQuickSaves()
        With MainForm.Games.CurrentSettings
            ToggleTypeButton.Text = "Quick Saves"
            CurrentSaveText = MainForm.QuickSaveFileString
            If .AlternateSaveNowLocationEnabled AndAlso Directory.Exists(.AlternateSaveNowLocation) Then
                LoadItems(.AlternateSaveNowLocation, CurrentSaveText)
            Else
                LoadItems(.AutoSaveStorageDirectory, CurrentSaveText)
            End If
        End With
    End Sub

    Private Sub ViewAutoSaves()
        With MainForm.Games.CurrentSettings
            ToggleTypeButton.Text = "Autosaves"
            CurrentSaveText = MainForm.AutoSaveFileString
            LoadItems(.AutoSaveStorageDirectory, CurrentSaveText)
        End With
    End Sub

    Private Sub FileSystemWatcher1_Created(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Created
        Try
            Dim matched As Boolean = False
            If TestStringPartial(CurrentSaveText, e.Name, True) Then
                If e.Name.Length >= CurrentSaveText.Length + 1 Then
                    Dim TestStr As String = e.Name.Substring(CurrentSaveText.Length + 1)
                    If TestStr IsNot Nothing AndAlso TestStr <> "" AndAlso IsNumeric(TestStr) Then
                        Dim num1 As Integer
                        If Integer.TryParse(TestStr, num1) Then
                            matched = True
                        End If
                    End If
                End If
            ElseIf TestStringPartial("Last Restore Temporary Backup", e.Name, True) Then
                matched = True
            End If

            If matched Then
                DataList.SaveNames.Add(New KeyValuePair(Of String, String)(e.FullPath, e.Name))
                Dim lastWrite As Date = My.Computer.FileSystem.GetFileInfo(e.FullPath).LastWriteTime
                DataList.SaveLastModifiedDates.Add(lastWrite) ' last modified
                SaveDataGridView.Rows.Add(e.Name, lastWrite, "Load")
                ResortDataGridView()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FileSystemWatcher1_Deleted(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Deleted
        Try
            For i As Integer = 0 To DataList.SaveNames.Count - 1
                If e.Name = DataList.SaveNames(i).Value Then
                    For k As Integer = 0 To SaveDataGridView.RowCount - 1
                        If CStr(SaveDataGridView.Item(0, k).Value) = e.Name Then
                            SaveDataGridView.Rows.RemoveAt(k)
                            Exit For
                        End If
                    Next
                    DataList.SaveNames.RemoveAt(i)
                    DataList.SaveLastModifiedDates.RemoveAt(i)
                    ResortDataGridView()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FileSystemWatcher1_Renamed(sender As Object, e As RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        Try
            For i As Integer = 0 To DataList.SaveNames.Count - 1
                If e.OldName = DataList.SaveNames(i).Value Then
                    DataList.SaveNames(i) = New KeyValuePair(Of String, String)(e.FullPath, e.Name)
                    DataList.SaveLastModifiedDates(i) = My.Computer.FileSystem.GetFileInfo(e.FullPath).LastWriteTime ' last modified
                    For k As Integer = 0 To SaveDataGridView.RowCount - 1
                        If CStr(SaveDataGridView.Item(0, k).Value) = e.OldName Then
                            SaveDataGridView.Item(0, k).Value = e.Name
                            SaveDataGridView.Item(1, k).Value = DataList.SaveLastModifiedDates(i)
                            ResortDataGridView()
                        End If
                    Next
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ResortDataGridView()
        If SaveDataGridView.SortOrder <> SortOrder.None AndAlso SaveDataGridView.SortedColumn IsNot Nothing Then
            Dim Direction As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Ascending
            If SaveDataGridView.SortOrder = SortOrder.Descending Then
                Direction = System.ComponentModel.ListSortDirection.Descending
            End If
            SaveDataGridView.Sort(SaveDataGridView.SortedColumn, Direction)
        End If
    End Sub

    Private Sub RemoveSaveButton_Click(sender As Object, e As EventArgs) Handles RemoveSaveButton.Click
        If SaveDataGridView.SelectedCells.Count > 0 Then
            For j As Integer = SaveDataGridView.SelectedCells.Count - 1 To 0 Step -1
                Dim saveName As String = CStr(SaveDataGridView.Item(0, SaveDataGridView.SelectedCells(j).RowIndex).Value)

                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                Dim result As MsgBoxResult = MsgBox("Are you sure you want to delete " & """" & saveName & """", MsgBoxStyle.YesNo)
                If result = MsgBoxResult.Yes Then
                    For i As Integer = 0 To DataList.SaveNames.Count - 1
                        If saveName = DataList.SaveNames(i).Value Then
                            Try
                                If Not IsNothing(My.Settings.SaveListPermaDelete) AndAlso My.Settings.SaveListPermaDelete = False Then
                                    My.Computer.FileSystem.DeleteDirectory(DataList.SaveNames(i).Key, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                                Else
                                    My.Computer.FileSystem.DeleteDirectory(DataList.SaveNames(i).Key, FileIO.DeleteDirectoryOption.DeleteAllContents)
                                End If

                                SaveDataGridView.Rows.RemoveAt(SaveDataGridView.SelectedCells(j).RowIndex)
                                DataList.SaveNames.RemoveAt(i)
                                DataList.SaveLastModifiedDates.RemoveAt(i)
                                'ResortDataGridView()
                            Catch ex As Exception
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                                MsgBox(ex.Message)
                            End Try
                            Exit For
                        End If
                    Next
                End If

            Next
            Me.ActiveControl = Nothing
        Else
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub

    Private Sub OpenContainingFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenContainingFolderToolStripMenuItem.Click
        If SaveDataGridView.SelectedCells.Count > 0 Then
            Dim saveName As String = CStr(SaveDataGridView.Item(0, SaveDataGridView.SelectedCells(0).RowIndex).Value)
            For i As Integer = 0 To DataList.SaveNames.Count - 1
                If saveName = DataList.SaveNames(i).Value Then
                    MainForm.OpenDirectoryButton(DataList.SaveNames(i).Key)
                    Exit For
                End If
            Next
        Else
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub

    Private Sub SaveDataGridView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SaveDataGridView.CellMouseDown
        If e.Button = MouseButtons.Right Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                SaveDataGridView.CurrentCell = SaveDataGridView(0, e.RowIndex)
            End If
        End If
    End Sub

    Private Sub SaveDataGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles SaveDataGridView.KeyDown
        If e.KeyCode = Keys.Delete Then
            RemoveSaveButton.PerformClick()
            Me.ActiveControl = SaveDataGridView
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
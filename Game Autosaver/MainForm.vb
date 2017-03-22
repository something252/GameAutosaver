Imports System.IO
Imports Newtonsoft.Json

Public Class MainForm
    Public Shared ThisForm As MainForm
    Public Const AutoSaveFileString As String = "Autosave"
    Public Const QuickSaveFileString As String = "Quick Save"
    Dim shownComplete As Boolean = False
    Dim SaveTime As Date
    Public accessLock As New Object
    Public timer1Lock As New Object
    Public SaveTimerPtr As Timer
    Public HotkeysChangeLock As Boolean = False ' locks hotkey usage after hotkeys have been changed in settings

    ''' <summary>
    ''' Game specific save data
    ''' </summary>
    Public Shared Games As GameData

    ' start button click
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If StartButton.Text = "Start Autosaving" AndAlso Not Directory.Exists(TextBox1.Text) Then
            MsgBox("Game save directory does not exist!", MsgBoxStyle.Exclamation, "Error")
        ElseIf StartButton.Text = "Start Autosaving" AndAlso Not Directory.Exists(TextBox2.Text) Then
            MsgBox("Autosave storage directory does not exist!", MsgBoxStyle.Exclamation, "Error")
        Else
            Games.CurrentSettings.AutoSaveIntervalMinutes = CInt(NumericUpDown1.Value)
            Games.CurrentSettings.GameSaveDirectory = TextBox1.Text
            Games.CurrentSettings.AutoSaveStorageDirectory = TextBox2.Text
            SaveMySettings()

            If StartButton.Text = "Start Autosaving" Then
                TextBox1.ReadOnly = True
                TextBox2.ReadOnly = True
                StartSaving()
            ElseIf StartButton.Text = "Stop Autosaving" Then
                TextBox1.ReadOnly = False
                TextBox2.ReadOnly = False
                SaveTimerPtr.Stop()
                Reset() ' reset settings
            End If
        End If

    End Sub

    Public Sub StartSaving()
        SyncLock timer1Lock
            Dim tmp As DateTime = Now
            SaveTime = tmp.AddMinutes(NumericUpDown1.Value) ' Set save timer to x minutes from now
            SaveTimeLabel.Text = SaveTime.ToLongTimeString
            NumericUpDown1.Enabled = False

            SaveTimerPtr.Start()
            StartButton.Text = "Stop Autosaving"
            ChangeMainFormColors(Color.Red)
            NumericUpDown1.Enabled = False
        End SyncLock
    End Sub

    Public Sub MainForm_Load() Handles MyBase.Load
        Icon = My.Resources.Icon_256
        NotifyIcon1.Icon = My.Resources.Icon_256
        SettingsButton.Image = My.Resources.Cog_Wheel

        SaveTimerPtr = Me.SaveTimer
        ThisForm = Me

        If My.Settings.Saves IsNot Nothing AndAlso My.Settings.Saves.Length > 0 Then
            Games = JsonConvert.DeserializeObject(Of GameData)(My.Settings.Saves)
            Games.FinishedLoading()
            Games.LoadSave(ThisForm, Games.CurrentName, True)
        Else
            Games = New GameData
            Games.FinishedLoading()
            Games.StartupLoadBlankSave(ThisForm)
        End If

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing ' focus nothing

        shownComplete = True
    End Sub

    Public Sub MainForm_FormClosing() Handles MyBase.FormClosing
        'endThread = True ' stop thread(s)
        HotkeysTimer.Stop()

        SaveMySettings()

        Me.Show()
        Me.WindowState = FormWindowState.Normal ' Unminimize Window
    End Sub

    Public Shared Sub SaveMySettings()
        Games.SaveCurrentSettings(ThisForm)
        My.Settings.Saves = JsonConvert.SerializeObject(Games)
        My.Settings.Save()
    End Sub

    Private Sub Directory_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop, TextBox2.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim directories As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If Directory.Exists(directories(0)) Then
                CType(sender, TextBox).Text = directories(0)
                Me.ActiveControl = Nothing
            End If
        End If
    End Sub

    Private Sub Directory_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter, TextBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Public Sub QuickLoad() Handles QuickLoadButton.Click
        If Not Directory.Exists(Games.CurrentSettings.LastQuickSavePath) Then
            MsgBox("Quick load failed!" & vbNewLine & vbNewLine & "quick save does not exist: " & """" & Games.CurrentSettings.LastQuickSavePath & """", MsgBoxStyle.Critical)
        Else
            If IsNothing(My.Settings.ManualSaveResetInterval) OrElse My.Settings.ManualSaveResetInterval Then
                SyncLock timer1Lock
                    If StartButton.Text = "Stop Autosaving" Then ' currently autosaving
                        SaveTimerPtr.Stop()
                        ChangeMainFormColors(Color.Gold) ' reset color
                        StartSaving()
                    End If
                End SyncLock
            End If

            Try
                SyncLock timer1Lock
                    If Directory.Exists(TextBox1.Text) Then

                        If My.Settings.BackupQuickLoad Then ' if quick load backup enabled
                            TextBox2.Text = TextBox2.Text.TrimEnd("\"c)
                            Dim BackupDestination As String = TextBox2.Text & "\" & "Last Restore Temporary Backup"
                            If Directory.Exists(BackupDestination) Then
                                My.Computer.FileSystem.DeleteDirectory(BackupDestination, FileIO.DeleteDirectoryOption.DeleteAllContents)
                            End If
                            My.Computer.FileSystem.CopyDirectory(TextBox1.Text, BackupDestination)
                        End If

                        My.Computer.FileSystem.DeleteDirectory(TextBox1.Text, FileIO.DeleteDirectoryOption.DeleteAllContents) ' delete destination
                    End If
                    My.Computer.FileSystem.CopyDirectory(Games.CurrentSettings.LastQuickSavePath, TextBox1.Text) ' copy to destination
                End SyncLock
            Catch ' files in use so can't delete error
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
            End Try
        End If
    End Sub

    Private Sub CurrentTimer_Tick(sender As Object, e As EventArgs) Handles CurrentTimer.Tick
        CurrentTimeLabel.Text = CType(TimeOfDay, String)
    End Sub

    Private Sub SaveTimer_Tick(sender As Object, e As EventArgs) Handles SaveTimer.Tick
        SyncLock timer1Lock
            If Date.Compare(Now, SaveTime) > -1 Then
                SaveTimerPtr.Stop() ' turn off this timer

                ChangeMainFormColors(Color.Gold) ' reset color

                ThisForm.SaveNow()
            End If
        End SyncLock
    End Sub

    Dim QuickSaveButtonFlag As Boolean = False
    Public Sub QuickSaveButton_Click() Handles QuickSaveButton.Click
        If Not Directory.Exists(TextBox1.Text) Then
            MsgBox("Game save directory does not exist.", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not Directory.Exists(TextBox2.Text) Then
            MsgBox("Autosave storage directory does not exist.", MsgBoxStyle.Exclamation, "Error")
        Else
            If Not IsNothing(My.Settings.ManualSaveResetInterval) AndAlso My.Settings.ManualSaveResetInterval = False Then
                QuickSaveButtonFlag = True
                SaveNow()
            Else ' My.Settings.ManualSaveResetInterval = True (default when nothing)
                SyncLock timer1Lock
                    If StartButton.Text = "Stop Autosaving" Then ' currently autosaving
                        SaveTimerPtr.Stop()
                        ChangeMainFormColors(Color.Gold) ' reset color
                        QuickSaveButtonFlag = True
                        SaveNow()
                    Else
                        QuickSaveButtonFlag = True
                        SaveNow()
                    End If
                End SyncLock
            End If
        End If
    End Sub

    Dim Source As String ' copy the game's save location
    Dim Destination As String ' autosave destination location
    ''' <summary>
    ''' Autosave primary saving work.
    ''' </summary>
    Public Sub SaveNow()
        Control.CheckForIllegalCrossThreadCalls = False
        SyncLock accessLock
            If Directory.Exists(TextBox1.Text) AndAlso Directory.Exists(TextBox2.Text) Then

                ' To do:
                ' save from this folder (textbox1)
                ' and copy into TextBox2 folder (with counter affix)

                Source = TextBox1.Text ' copy the game's save location

                If QuickSaveButtonFlag AndAlso Games.CurrentSettings.AlternateSaveNowLocationEnabled Then

                    If Not Directory.Exists(Games.CurrentSettings.AlternateSaveNowLocation) Then
                        Dim result As MsgBoxResult = MsgBox("Alternate """"Save Now"""" location does not exist!" & vbNewLine &
                            "Save to autosave directory instead?", MsgBoxStyle.OkCancel, "Error")
                        If result = MsgBoxResult.Ok Then
                            Destination = TextBox2.Text ' autosave destination location
                        Else
                            'endThread = False
                            Exit Sub ' cancel/abort saving
                        End If
                    Else
                        Destination = Games.CurrentSettings.AlternateSaveNowLocation
                    End If
                Else
                    Destination = TextBox2.Text ' autosave destination location
                End If

                Source = Source.TrimEnd("\"c)
                Games.CurrentSettings.GameSaveDirectory = Source
                Destination = Destination.TrimEnd("\"c)
                If QuickSaveButtonFlag = False Then
                    Games.CurrentSettings.AutoSaveStorageDirectory = Destination
                End If

                If Destination = Source Then
                    MsgBox("Source and destination locations are the same!", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If

                ' Check and set the value of overwrite directory flag.
                Dim overwriteFlag As Boolean = False
                If OverwriteComboBox.SelectedIndex = 0 Then ' false / Don't overwrite saves
                    overwriteFlag = False
                ElseIf OverwriteComboBox.SelectedIndex = 1 Then ' true / Do overwrite saves
                    overwriteFlag = True
                End If

                ' Create new directory to be saved to. (With counter)
                If QuickSaveButtonFlag Then
                    Destination = Destination & "\" & QuickSaveFileString & " " & CStr(Games.CurrentSettings.QuickSaveCounter)
                Else
                    Destination = Destination & "\" & AutoSaveFileString & " " & CStr(Games.CurrentSettings.AutoSaveCounter)
                End If

                ' Copy to the save location.
                CopyToSaveLocation(overwriteFlag)

                ' Increment the save count.
                If QuickSaveButtonFlag Then ' quick save
                    If Games.CurrentSettings.QuickSaveLimit = 0 Then ' unlimited
                        If Games.CurrentSettings.QuickSaveCounter = Integer.MaxValue Then
                            Games.CurrentSettings.QuickSaveCounter = 1 ' limit reached
                        Else
                            Games.CurrentSettings.QuickSaveCounter += 1 ' increment count
                        End If
                    Else ' limited
                        If Games.CurrentSettings.QuickSaveCounter = Games.CurrentSettings.QuickSaveLimit Then
                            Games.CurrentSettings.QuickSaveCounter = 1 ' limit reached
                        Else
                            Games.CurrentSettings.QuickSaveCounter += 1 ' increment count
                        End If
                    End If

                    If CounterSwitchButton.Text = QuickSaveText Then
                        SaveCountTextBox.Text = CStr(Games.CurrentSettings.QuickSaveCounter) ' update counter amount
                    End If
                Else ' autosave
                    If Games.CurrentSettings.AutoSaveLimit = 0 Then ' unlimited
                        If Games.CurrentSettings.AutoSaveCounter = Integer.MaxValue Then
                            Games.CurrentSettings.AutoSaveCounter = 1 ' limit reached
                        Else
                            Games.CurrentSettings.AutoSaveCounter += 1 ' increment count
                        End If
                    Else ' limited
                        If Games.CurrentSettings.AutoSaveCounter = Games.CurrentSettings.AutoSaveLimit Then
                            Games.CurrentSettings.AutoSaveCounter = 1 ' limit reached
                        Else
                            Games.CurrentSettings.AutoSaveCounter += 1 ' increment count
                        End If
                    End If

                    If CounterSwitchButton.Text = AutoSaveText Then
                        SaveCountTextBox.Text = CStr(Games.CurrentSettings.AutoSaveCounter) ' update counter amount
                    End If
                End If


                If QuickSaveButtonFlag AndAlso
                StartButton.Text = "Stop Autosaving" AndAlso Not IsNothing(My.Settings.ManualSaveResetInterval) AndAlso My.Settings.ManualSaveResetInterval _
                OrElse QuickSaveButtonFlag = False Then

                    StartSaving() ' setup next autosave interval
                End If

                QuickSaveButtonFlag = False

            Else
                If Not Directory.Exists(TextBox1.Text) Then
                    MsgBox("Game save directory does not exist!", MsgBoxStyle.Critical, "Error")
                ElseIf Not Directory.Exists(TextBox2.Text) Then
                    MsgBox("Autosave storage directory does not exist!", MsgBoxStyle.Critical, "Error")
                End If
                AutosaveIOFailure() ' Autosave failure
            End If

            SaveMySettings()

            'endThread = False
        End SyncLock
    End Sub

    ''' <summary>
    ''' Copy the source directory contents to the destination directory.
    ''' </summary>
    ''' <param name="overwriteFlag">Flag determining whether or not files/folders will be overridden at destination if they already exist.</param>
    Private Sub CopyToSaveLocation(ByVal overwriteFlag As Boolean)
        'Dim TopFolderName As String = GetFileName(Source)
        'Dim UpperDestination As String = Destination
        ' Destination = Destination & "\" & TopFolderName
        If QuickSaveButtonFlag Then
            Games.CurrentSettings.LastQuickSavePath = Destination ' set new last quick save path
        End If
        If overwriteFlag Then
            If Directory.Exists(Destination) Then ' case 1
                If Not IsNothing(My.Settings.SimpleSaveOverwriting) AndAlso My.Settings.SimpleSaveOverwriting Then
                    Try
                        If Not IsNothing(My.Settings.SimpleSaveOverwritingPermaDelete) AndAlso My.Settings.SimpleSaveOverwritingPermaDelete = False Then
                            My.Computer.FileSystem.DeleteDirectory(Destination, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                        Else ' My.Settings.SimpleAutosaveOverwritingPermaDelete = true (default when nothing)
                            My.Computer.FileSystem.DeleteDirectory(Destination, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                        My.Computer.FileSystem.CopyDirectory(Source, Destination, overwriteFlag)
                    Catch
                        AutosaveIOFailure() ' Autosave failure
                    End Try
                Else ' My.Settings.SimpleAutosaveOverwriting = false (default when nothing)
                    Try
                        My.Computer.FileSystem.CopyDirectory(Source, Destination, overwriteFlag)
                    Catch
                        AutosaveIOFailure() ' Autosave failure
                    End Try
                End If
            Else ' case 2
                Try
                    My.Computer.FileSystem.CreateDirectory(Destination)
                    My.Computer.FileSystem.CopyDirectory(Source, Destination, overwriteFlag)
                Catch
                    AutosaveIOFailure() ' Autosave failure
                End Try
            End If
        Else ' Don't overwrite anything
            If Not Directory.Exists(Destination) Then ' case 3
                Try
                    My.Computer.FileSystem.CreateDirectory(Destination)
                    My.Computer.FileSystem.CopyDirectory(Source, Destination, overwriteFlag)
                Catch
                    AutosaveIOFailure() ' Autosave failure
                End Try
            Else ' case 4

                ' Initialization.
                If SubFiles IsNot Nothing Then
                    SubFiles.Clear()
                Else
                    SubFiles = New List(Of String)
                End If
                If SubDirectories IsNot Nothing Then
                    SubDirectories.Clear()
                Else
                    SubDirectories = New List(Of String)
                End If

                ' Preliminary populating.
                Dim list() As String = Directory.GetFiles(Source)
                For Each FilePath In list
                    SubFiles.Add(FilePath)
                Next

                ' Perform file/directory adding on all subfolders found as well.
                GenerateWhatToSaveList(list, Source)

                ' Create all the directories first.
                For Each DirectoryTemp As String In SubDirectories
                    If Not Directory.Exists(Destination & DirectoryTemp) Then
                        Try
                            My.Computer.FileSystem.CopyDirectory(Source & DirectoryTemp, Destination & DirectoryTemp)
                        Catch
                            AutosaveIOFailure() ' Autosave failure
                        End Try
                    End If
                Next

                ' Create all the files
                For Each FileTemp As String In SubFiles
                    Dim tmp2 = Split(FileTemp, Source)
                    Try
                        If Not File.Exists(Destination & tmp2(1)) Then
                            My.Computer.FileSystem.CopyFile(FileTemp, Destination & tmp2(1))
                        End If
                    Catch
                        AutosaveIOFailure() ' Autosave failure
                    End Try
                Next

                SubFiles.Clear()
                SubDirectories.Clear()
            End If
        End If
    End Sub

    Dim SubFiles As List(Of String) ' list of all files in source
    Dim SubDirectories As List(Of String) ' list of all directories in source (with source path cut out)
    Private Sub GenerateWhatToSaveList(ByRef list() As String, ByRef path As String)
        list = Directory.GetDirectories(path)
        If list.Length > 0 Then ' more folders found (links to folders don't count)
            For Each DirectoryTmp In list
                ' add this directory to directory list
                Dim tmp1 = Split(DirectoryTmp, Source)
                Try
                    SubDirectories.Add(tmp1(1))
                Catch
                End Try

                ' add all files in this directory to file list
                Dim listTemp = Directory.GetFiles(DirectoryTmp)
                For Each FilePath In listTemp
                    SubFiles.Add(FilePath)
                Next

                ' look for more directories to add more files/folders from using this directory
                AddAllFromSubFoldersRecursive(DirectoryTmp)
            Next
        End If
    End Sub

    Private Sub AddAllFromSubFoldersRecursive(path As String)
        Dim List = Directory.GetDirectories(path)
        If List.Length > 0 Then ' more folders found (links to folders don't count)
            For Each DirectoryTmp In List

                ' add this directory to directory list
                Dim tmp1 = Split(DirectoryTmp, Source)
                Try
                    SubDirectories.Add(tmp1(1))
                Catch
                End Try

                ' add all files in this directory to file list
                Dim listTemp = Directory.GetFiles(DirectoryTmp)
                For Each FilePath In listTemp
                    SubFiles.Add(FilePath)
                Next

                ' look for more directories to add more files/folders from using this directory
                AddAllFromSubFoldersRecursive(DirectoryTmp)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Get name of a given full path including its extension if present.
    ''' </summary>
    Public Shared Function GetFileName(str As String) As String
        If str IsNot Nothing Then
            Dim count As Integer = 0
            For c As Integer = str.Length - 1 To 0 Step -1
                If str(c) = "\"c Then
                    If Not c = 0 Then ' doesn't have slash as last char (Not Str.Length - c = Str.Length)
                        Return str.Substring(c + 1, count)
                    End If
                End If
                count += 1
            Next
        End If
        Return str
    End Function

    ''' <summary>
    ''' Get the containing folder of a given path as string.
    ''' </summary>
    Public Shared Function GetContainingFolder(path As String) As String
        If path IsNot Nothing Then
            Dim count As Integer = 0
            For i As Integer = path.Length - 1 To 0 Step -1
                If path(i) = "\"c Then
                    Return path.Substring(0, path.Length - (count + 1))
                End If
                count += 1
            Next
        End If
        Return ""
    End Function

    Private Sub Reset()
        Control.CheckForIllegalCrossThreadCalls = False
        StartButton.Text = "Start Autosaving" ' reset button text
        SaveTimeLabel.Text = "Never" ' reset alarm set to text
        NumericUpDown1.Enabled = True
        ChangeMainFormColors(System.Drawing.SystemColors.Control) ' reset color
    End Sub

    ''' <summary>
    ''' Change MainForm control colors.
    ''' </summary>
    Private Sub ChangeMainFormColors(newColor As Color)
        Me.BackColor = newColor
        Label6.BackColor = newColor
    End Sub

    Private Sub Browse1_Click(sender As Object, e As EventArgs) Handles Browse1.Click
        Browse(TextBox1)
    End Sub

    Private Sub Browse2_Click(sender As Object, e As EventArgs) Handles Browse2.Click
        Browse(TextBox2)
    End Sub

    Private Sub Browse(obj As TextBox)
        If Directory.Exists(obj.Text) Then
            FolderBrowserDialog1.SelectedPath = obj.Text
        End If
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If Not (result = DialogResult.Cancel OrElse result = DialogResult.Abort) Then
            If FolderBrowserDialog1.SelectedPath <> "" Then
                SyncLock accessLock
                    obj.Text = FolderBrowserDialog1.SelectedPath
                End SyncLock
            End If
        End If
    End Sub

    ''' <summary>
    ''' Tray icon mouse clicking related.
    ''' </summary>
    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = MouseButtons.Right Then ' right click
            TrayMenu.Show()
            TrayMenu.Activate()
            TrayMenu.Width = 1 'it will be set behind the menu, so it's 1x1 pixels
            TrayMenu.Height = 1
        ElseIf e.Button = MouseButtons.Left Then ' left click
            TrayMenu.Hide()
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    ''' <summary>
    ''' Main form minimizes to tray flag.
    ''' </summary>
    Dim MinimizeButtonFlag As Boolean = False
    Private Sub MinimizeToTrayButton_Click(sender As Object, e As EventArgs) Handles MinimizeToTrayButton.Click
        CurrentTimer.Stop()
        MinimizeButtonFlag = True ' button was just clicked
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MinimizeButtonFlag Then ' only when "minimize to tray" button is used and not standard minimizing
            MinimizeButtonFlag = False
            NotifyIcon1.Visible = True
            Me.Hide()
            'NotifyIcon1.BalloonTipText = "Minimized To Tray"
            'NotifyIcon1.ShowBalloonTip(250)
        ElseIf Me.WindowState = FormWindowState.Normal Then
            CurrentTimer.Start()
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub ContainingButton1_Click(sender As Object, e As EventArgs) Handles ContainingButton1.Click
        OpenDirectoryButton(TextBox1.Text)
    End Sub

    Private Sub ContainingButton2_Click(sender As Object, e As EventArgs) Handles ContainingButton2.Click
        OpenDirectoryButton(TextBox2.Text)
    End Sub

    ''' <summary>
    ''' Select in containing folder. (Explorer)
    ''' </summary>
    ''' <param name="path">Path to open containing folder of.</param>
    Public Shared Sub OpenDirectoryButton(path As String)
        If path IsNot Nothing Then
            If path = "" Then
                MsgBox("No path has been specified.", MsgBoxStyle.Information, "Error")
            ElseIf Not Directory.Exists(path) Then
                MsgBox("The directory does not exist.", MsgBoxStyle.Information, "Error")
            Else
                Process.Start("""" & path & """")
            End If
        End If
    End Sub

    Public BackgroundPicture As Image
    ''' <summary>
    ''' Set the background of the form to a selected image file.
    ''' </summary>
    Public Sub BackgroundImageSelect()
        ' Set to current image path if one is in use
        If Games.CurrentSettings.BackgroundImageLoc IsNot Nothing Then
            Dim path As String = GetDirectoryString(TextBox1.Text)
            If Directory.Exists(path) Then
                OpenImageFileDialog.InitialDirectory = path ' set initial path to currently used one where a file was selected in the past
                If File.Exists(TextBox1.Text) Then
                    OpenImageFileDialog.FileName = GetFileDisplayString(TextBox1.Text)
                Else
                    OpenImageFileDialog.FileName = ""
                End If
            End If
        End If

        If OpenImageFileDialog.ShowDialog = DialogResult.OK Then
            Games.CurrentSettings.BackgroundImageLoc = OpenImageFileDialog.FileName
            SaveMySettings()
            BackgroundPicture = Image.FromFile(OpenImageFileDialog.FileName)
            RefreshBackgroundImage()
        End If
    End Sub

    ''' <summary>
    ''' refresh the background image by replacing it at the control's current dimensions
    ''' </summary>
    Public Sub RefreshBackgroundImage()
        If File.Exists(Games.CurrentSettings.BackgroundImageLoc) Then ' if background image is something
            Using bmp1 = New Bitmap(Me.Width, Me.Height - StartButton.Height) ' stretch the background image to fit the new size
                Using g1 = Graphics.FromImage(bmp1)
                    g1.DrawImage(BackgroundPicture, 0, 0, bmp1.Width, bmp1.Height)
                    Me.BackgroundImage = CType(bmp1.Clone, Image)
                End Using
            End Using
        End If
    End Sub

    Private Sub NewScreen_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        If shownComplete Then
            resizeInProgress = True
        End If
    End Sub

    Private Sub NewScreen_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If shownComplete Then
            resizeInProgress = False
            ResizeBackgroundImage()
        End If
    End Sub

    Dim resizeInProgress As Boolean = False
    ''' <summary>
    ''' Resize the Main form's background image to its new size and replace it. (Stretch)
    ''' </summary>
    Public Sub ResizeBackgroundImage()
        If Not resizeInProgress Then
            RefreshBackgroundImage()
        End If
    End Sub

    ''' <summary>
    ''' Gets a file display worthy string, without full path or file extension info.
    ''' </summary>
    ''' <param name="str">String to be altered</param>
    Public Shared Function GetFileDisplayString(str As String) As String
        Dim myStr() As String = Split(str, "\")
        Dim newStr As String = myStr(myStr.Length - 1)
        Dim myStr2() As String = Split(newStr, ".")
        Dim constructName As String = myStr2(0)
        For i As Integer = 1 To myStr2.Length - 2 ' don't add extension
            constructName = constructName & "." & myStr2(i)
        Next
        Return constructName
    End Function

    ''' <summary>
    ''' Returns the containing directory of a given string. (Split on "\")
    ''' </summary>
    ''' <param name="str">File string to be checked</param>
    Public Shared Function GetDirectoryString(str As String) As String
        Dim myStr() As String = Split(str, "\")
        Dim newStr As String = ""
        For i As Integer = 0 To myStr.Count - 2
            newStr &= myStr(i) & "\"
        Next
        Return newStr
    End Function

    ''' <summary>
    ''' Occurs when an IO failure happens, so it can be logged.
    ''' </summary>
    Private Sub AutosaveIOFailure()
        AutosaveF1TextBox.Visible = True
        AutosaveF1Label.Visible = True

        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        AutosaveF1TextBox.Text = CType(CInt(AutosaveF1TextBox.Text) + 1, String) ' Autosave failure
    End Sub

    Private Sub ChangeCountButton_Click(sender As Object, e As EventArgs) Handles ChangeCountButton.Click
        Dim newCount As String = InputBox("Input new count", "", SaveCountTextBox.Text)
        With Games.CurrentSettings
            If newCount = "" Then
                'MsgBox("Entered value is blank.", MsgBoxStyle.Exclamation, "Error")
            ElseIf Not IsNumeric(newCount) Then
                MsgBox("Entered value is not a number.", MsgBoxStyle.Exclamation, "Error")
            Else ' success
                Dim tempNum As Integer
                If Integer.TryParse(newCount, tempNum) Then
                    tempNum = CInt(newCount)
                Else
                    MsgBox("Entered value is too large.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                End If

                If tempNum < 0 Then
                    MsgBox("Entered value cannot be negative.", MsgBoxStyle.Exclamation, "Error")
                ElseIf (CounterSwitchButton.Text = AutoSaveText AndAlso .AutoSaveLimit <> 0 AndAlso tempNum > .AutoSaveLimit) OrElse
                      (CounterSwitchButton.Text = QuickSaveText AndAlso .QuickSaveLimit <> 0 AndAlso tempNum > .QuickSaveLimit) Then
                    MsgBox("Entered value cannot be higher than the specified limit.", MsgBoxStyle.Exclamation, "Error")
                Else ' success
                    Dim newCounter As Integer = tempNum
                    If newCounter = 0 Then
                        newCounter = 1
                    End If

                    SyncLock accessLock
                        If CounterSwitchButton.Text = QuickSaveText Then
                            .QuickSaveCounter = newCounter
                        ElseIf CounterSwitchButton.Text = AutoSaveText Then
                            .AutoSaveCounter = newCounter
                        End If
                        SaveCountTextBox.Text = CStr(newCounter)

                        SaveMySettings()
                    End SyncLock
                End If
            End If
        End With
    End Sub

    Dim roundRobinButtonWasClicked As Boolean = False
    ''' <summary>
    ''' Button that toggles round robin saving on or off.
    ''' </summary>
    Private Sub RoundRobinButton_Click(sender As Object, e As EventArgs) Handles RoundRobinButton.Click

        roundRobinButtonWasClicked = True
        If RoundRobinButton.Text = "Disabled" Then ' setting to enabled now
            If SaveLimitTextBox.Text = "None" Then ' attempt to set limit (optional)
                ChangeLimitButton_Click()
            End If

            Games.CurrentSettings.OverwriteSaves = True
            OverwriteComboBox.Enabled = True
            OverwriteComboBox.SelectedIndex = 1 ' true / Do overwrite saves
            OverwriteComboBox.Enabled = False

            Games.CurrentSettings.RoundRobinEnabled = True
            RoundRobinButton.Text = "Enabled"
        ElseIf RoundRobinButton.Text = "Enabled" Then ' setting to disabled now

            Games.CurrentSettings.OverwriteSaves = False
            OverwriteComboBox.Enabled = True
            OverwriteComboBox.SelectedIndex = 0 ' false / Don't overwrite saves
            OverwriteComboBox.Enabled = False

            Games.CurrentSettings.RoundRobinEnabled = False
            RoundRobinButton.Text = "Disabled"
        End If
        roundRobinButtonWasClicked = False

        SaveMySettings()
    End Sub

    Private Function ChangeLimitButton_Click() As Boolean Handles ChangeLimitButton.Click
        Dim newVal As String
        If SaveLimitTextBox.Text = "None" Then
            newVal = InputBox("Input new limit or 0 for no limit", "", "0")
        Else
            newVal = InputBox("Input new limit or 0 for no limit", "", SaveLimitTextBox.Text)
        End If

        If newVal = "" Then
            'MsgBox("Entered value is blank.", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(newVal) Then
            MsgBox("Entered value is not a number.", MsgBoxStyle.Exclamation, "Error")
        Else ' success
            Dim newValue As Integer
            If Integer.TryParse(newVal, newValue) Then
                newValue = CInt(newVal)
            Else
                MsgBox("Entered value is too large.", MsgBoxStyle.Exclamation, "Error")
                Return False ' failure
            End If

            If newValue < 0 Then
                MsgBox("Entered value cannot be negative.", MsgBoxStyle.Exclamation, "Error")
            Else ' success
                SyncLock accessLock
                    Dim limit As Integer
                    Dim counter As Integer
                    If CounterSwitchButton.Text = AutoSaveText Then
                        counter = Games.CurrentSettings.AutoSaveCounter
                    Else ' quick save
                        counter = Games.CurrentSettings.QuickSaveCounter
                    End If


                    If newValue = 0 Then ' unlimited
                        limit = 0
                        SaveLimitTextBox.Text = "None"
                    Else ' limited
                        limit = newValue
                        SaveLimitTextBox.Text = CStr(newValue)
                        If OverwriteComboBox.SelectedIndex = 0 AndAlso roundRobinButtonWasClicked = False Then ' false don't overwrite
                            MsgBox("Please consider enabling round robin." & vbNewLine & "Otherwise once the autosaving starts from 1 again nothing will be overwritten.",
                                MsgBoxStyle.Exclamation, "Warning")
                        End If
                    End If

                    ' set counter to 1 if now above the new limit
                    If limit <> 0 AndAlso counter > limit Then
                        counter = 1
                        SaveCountTextBox.Text = "1"
                    End If


                    If CounterSwitchButton.Text = AutoSaveText Then
                        Games.CurrentSettings.AutoSaveLimit = limit
                        Games.CurrentSettings.AutoSaveCounter = counter
                    Else ' quick save
                        Games.CurrentSettings.QuickSaveLimit = limit
                        Games.CurrentSettings.QuickSaveCounter = counter
                    End If
                    SaveMySettings()
                End SyncLock

                Return True ' success
            End If
        End If
        Return False ' failure
    End Function

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim Name As String = InputBox("Specify the name.", "Rename", Label6.Text)
        If Name <> "" Then
            If Games.RenameGameName(ThisForm, Games.CurrentName, Name) Then
                GameList.Close()
                SaveMySettings()
            Else
                MsgBox("Name already exists.", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Settings button clicked.
    ''' </summary>
    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsForm.Show()
        SettingsForm.TopMost = True
        SettingsForm.TopMost = False
    End Sub

    ''' <summary>
    ''' Show list of loadable game save configs
    ''' </summary>
    Private Sub GameListButton_Click(sender As Object, e As EventArgs) Handles GameListButton.Click
        GameList.Show()
        GameList.TopMost = True
        GameList.TopMost = False
    End Sub

    Public Const QuickSaveText As String = "quick save"
    Public Const AutoSaveText As String = "autosave"
    Public Const QuickSaveLimitText As String = "Quick save limit:"
    Public Const AutoSaveLimitText As String = "Autosave limit:"

    ''' <summary>
    ''' Switches the text in the button to manual save or auto save, which will determine which counter is shown and editable.
    ''' </summary>
    Private Sub CounterSwitchButton_Click(sender As Object, e As EventArgs) Handles CounterSwitchButton.Click
        If CounterSwitchButton.Text = AutoSaveText Then
            CounterSwitchButton.Text = "quick save"
            SaveCountTextBox.Text = CStr(Games.CurrentSettings.QuickSaveCounter)
            If Games.CurrentSettings.QuickSaveLimit = 0 Then
                SaveLimitTextBox.Text = "None"
            Else
                SaveLimitTextBox.Text = CStr(Games.CurrentSettings.QuickSaveLimit)
            End If
            Label7.Text = QuickSaveLimitText
        ElseIf CounterSwitchButton.Text = QuickSaveText Then
            CounterSwitchButton.Text = "autosave"
            SaveCountTextBox.Text = CStr(Games.CurrentSettings.AutoSaveCounter)
            If Games.CurrentSettings.AutoSaveLimit = 0 Then
                SaveLimitTextBox.Text = "None"
            Else
                SaveLimitTextBox.Text = CStr(Games.CurrentSettings.AutoSaveLimit)
            End If
            Label7.Text = AutoSaveLimitText
        End If
    End Sub


    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer

    ' prevents key from being held down and registering more than once before being unpressed
    Dim QuickSaveKeyPressed As Boolean = False
    Dim QuickLoadKeyPressed As Boolean = False

    Private Sub HotkeysTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotkeysTimer.Tick

        If CBool(GetKeyPress(Games.QuickSaveHotkey)) Then ' Quick save hotkey press
            If QuickSaveKeyPressed = False Then
                QuickSaveKeyPressed = True

                If HotkeysChangeLock = False Then
                    QuickSaveButton_Click() ' quick save button click
                End If
            End If
        Else
            QuickSaveKeyPressed = False ' key was not pressed
        End If

        If CBool(GetKeyPress(Games.QuickLoadHotkey)) Then ' Quick load hotkey press
            If QuickLoadKeyPressed = False Then
                QuickLoadKeyPressed = True

                If HotkeysChangeLock = False Then
                    QuickLoad() ' Quick load
                End If
            End If
        Else
            QuickLoadKeyPressed = False ' key was not pressed
        End If

        HotkeysChangeLock = False
    End Sub

    Private Sub SaveViewerButton_Click(sender As Object, e As EventArgs) Handles SaveViewerButton.Click
        If Not Directory.Exists(TextBox1.Text) Then
            MsgBox("Game save directory does not exist!", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not Directory.Exists(TextBox2.Text) Then
            MsgBox("Autosave storage directory does not exist!", MsgBoxStyle.Exclamation, "Error")
        Else
            SavesViewer.Show()
            SavesViewer.TopMost = True
            SavesViewer.TopMost = False
        End If
    End Sub
End Class


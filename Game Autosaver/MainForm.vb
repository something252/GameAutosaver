Imports System.IO

Public Class MainForm
    Shared ThisForm As Object
    Dim shownComplete As Boolean = False

    Dim pass1 As Boolean = True, endThread As Boolean = False
    Public SaveThread As System.Threading.Thread
    Public AlarmStopThread As System.Threading.Thread
    Public accessLock As New Object
    Private timer1Lock As New Object
    Public HotkeysChangeLock As Boolean = False ' locks hotkey usage after hotkeys have been changed in settings
    Private QuickSaveCounter As Decimal
    Public QuickSaveHotKey As Keys
    Public QuickLoadHotKey As Keys
    Private LastQuickSavePath As String ' holds last quick save path

    ' start button click
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If StartButton.Text = "Start Autosaving" AndAlso Not Directory.Exists(TextBox1.Text) Then
            MsgBox("Game save directory does not exist!", MsgBoxStyle.Exclamation, "Error")
        ElseIf StartButton.Text = "Start Autosaving" AndAlso Not Directory.Exists(TextBox2.Text) Then
            MsgBox("Autosave storage directory does not exist!", MsgBoxStyle.Exclamation, "Error")
        Else
            My.Settings.AutosaveIntervalMinutes = CInt(NumericUpDown1.Value)
            My.Settings.GameSaveDirectory = TextBox1.Text
            My.Settings.AutosaveStorageDirectory = TextBox2.Text
            My.Settings.Save()

            If StartButton.Text = "Start Autosaving" Then
                TextBox1.ReadOnly = True
                TextBox2.ReadOnly = True
                StartSaving()
            ElseIf StartButton.Text = "Stop Autosaving" Then
                TextBox1.ReadOnly = False
                TextBox2.ReadOnly = False
                SaveTimerPtr.Stop()
                AlarmTimeDatePicker.Enabled = True
                Reset() ' reset settings
            End If
        End If

    End Sub

    Private Sub StartSaving()
        SyncLock timer1Lock
            Dim tmp As DateTime = Now
            tmp = tmp.AddMinutes(CInt(NumericUpDown1.Value))
            AlarmTimeDatePicker.Text = tmp ' Set default alarm to x minutes from now
            AlarmTimeLabel.Text = AlarmTimeDatePicker.Text
            NumericUpDown1.Enabled = False

            AlarmTimeDatePicker.Enabled = False
            pass1 = True
            SaveTimerPtr.Start()
            StartButton.Text = "Stop Autosaving"
            Me.BackColor = Color.Red
            NumericUpDown1.Enabled = False
        End SyncLock
    End Sub

    Shared SaveTimerPtr As Object
    Public Sub MainForm_Load() Handles MyBase.Load
        Icon = My.Resources.Icon_256
        NotifyIcon1.Icon = My.Resources.Icon_256
        SettingsButton.Image = My.Resources.Cog_Wheel

        Me.Opacity = 100.0

        If Not IsNothing(My.Settings.QuickSaveCounter) Then
            QuickSaveCounter = My.Settings.QuickSaveCounter
        Else
            QuickSaveCounter = 1D
        End If

        If Not IsNothing(My.Settings.LastQuickSavePath) Then
            LastQuickSavePath = My.Settings.LastQuickSavePath
        Else
            LastQuickSavePath = ""
        End If

        If Not IsNothing(My.Settings.QuickSaveHotKey) Then
            QuickSaveHotKey = My.Settings.QuickSaveHotKey
        Else
            QuickSaveHotKey = Keys.F5
        End If
        If Not IsNothing(My.Settings.QuickLoadHotKey) Then
            QuickLoadHotKey = My.Settings.QuickLoadHotKey
        Else
            QuickLoadHotKey = Keys.F8
        End If
        Hotkeys.Show()

        If Not IsNothing(My.Settings.Name) Then
            Label6.Text = My.Settings.Name
        Else
            Label6.Text = "GAME AUTOSAVER"
        End If

        AlarmTimeDatePicker.Location = New Point(-1000, -1000)

        SaveTimerPtr = Me.SaveTimer
        ThisForm = Me

        CurrentTimer.Start() ' Start current time related timer
        Dim tmp As DateTime = Now
        If Not IsNothing(My.Settings.AutosaveIntervalMinutes) AndAlso Not My.Settings.AutosaveIntervalMinutes = 0 Then
            NumericUpDown1.Value = CDec(My.Settings.AutosaveIntervalMinutes)
            tmp = tmp.AddMinutes(My.Settings.AutosaveIntervalMinutes)
        Else
            tmp = tmp.AddMinutes(CInt(NumericUpDown1.Value))
        End If

        If Not IsNothing(My.Settings.GameSaveDirectory) Then
            TextBox1.Text = My.Settings.GameSaveDirectory
        End If
        If Not IsNothing(My.Settings.AutosaveStorageDirectory) Then
            TextBox2.Text = My.Settings.AutosaveStorageDirectory
        End If

        AlarmTimeDatePicker.Text = tmp ' Set default alarm to 5 minutes from now

        CounterSwitchButton.Text = AutoSaveText

        If Not IsNothing(My.Settings.AutoSaveCounter) AndAlso Not My.Settings.AutoSaveCounter = 0 Then
            If My.Settings.AutoSaveCounter > Math.Abs(My.Settings.AutosaveLimit) Then
                AutoSaveCounter = 1
                SaveCountTextBox.Text = 1
            Else
                AutoSaveCounter = Math.Abs(My.Settings.AutoSaveCounter)
                SaveCountTextBox.Text = Math.Abs(My.Settings.AutoSaveCounter)
            End If
        Else
            AutoSaveCounter = 1
            SaveCountTextBox.Text = 1
        End If

        If Not IsNothing(My.Settings.BackgroundImageLoc) AndAlso File.Exists(My.Settings.BackgroundImageLoc) Then
            backgroundPicture = Image.FromFile(My.Settings.BackgroundImageLoc)
            RefreshBackgroundImage()
        Else
            Me.BackgroundImage = Nothing
        End If

        If IsNothing(My.Settings.RoundRobinEnabled) OrElse My.Settings.RoundRobinEnabled = False Then ' is nothing or exists and is false
            If Not IsNothing(My.Settings.OverwriteSaves) Then
                If My.Settings.OverwriteSaves = False Then
                    OverwriteComboBox.SelectedIndex = 0 ' false / Don't overwrite saves
                Else
                    OverwriteComboBox.SelectedIndex = 1 ' true / Do overwrite saves
                End If
            Else
                OverwriteComboBox.SelectedIndex = 0 ' false / Don't overwrite saves
            End If
            RoundRobinButton.Text = "Disabled"
        Else ' exists and is RoundRobinEnabled = true
            OverwriteComboBox.SelectedIndex = 1 ' true / Do overwrite saves
            'OverwriteComboBox.Enabled = False
            RoundRobinButton.Text = "Enabled"
        End If

        If IsNothing(My.Settings.AutosaveLimit) OrElse Math.Abs(My.Settings.AutosaveLimit) = 79228162514264337593543950335D Then
            AutosaveLimit = 79228162514264337593543950335D
            AutosaveLimitTextBox.Text = "None"
        Else
            AutosaveLimit = Math.Abs(My.Settings.AutosaveLimit)
            AutosaveLimitTextBox.Text = Math.Abs(My.Settings.AutosaveLimit)
        End If

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing ' focus nothing

        shownComplete = True
    End Sub

    Public Sub MainForm_FormClosing() Handles MyBase.FormClosing
        StopThread() ' stop thread(s)

        Me.Opacity = 0.0 ' so that the form doesn't show when closed from tray icon menu

        If Not IsNothing(NumericUpDown1.Value) Then
            My.Settings.AutosaveIntervalMinutes = CInt(NumericUpDown1.Value)
        End If

        If Not IsNothing(AutoSaveCounter) Then
            My.Settings.AutoSaveCounter = AutoSaveCounter
        End If

        If IsNothing(My.Settings.RoundRobinEnabled) OrElse My.Settings.RoundRobinEnabled = False Then
            If OverwriteComboBox.SelectedIndex = 0 Then ' false / Don't overwrite saves
                My.Settings.OverwriteSaves = False
            ElseIf OverwriteComboBox.SelectedIndex = 1 Then ' true / Do overwrite saves
                My.Settings.OverwriteSaves = True
            End If
        End If
        If RoundRobinButton.Text = "Enabled" Then
            My.Settings.RoundRobinEnabled = True
        ElseIf RoundRobinButton.Text = "Disabled" Then
            My.Settings.RoundRobinEnabled = False
        End If

        If IsNothing(AutosaveLimit) OrElse AutosaveLimit = 79228162514264337593543950335D Then
            My.Settings.AutosaveLimit = 79228162514264337593543950335D ' unlimited
            'AutosaveLimitTextBox.Text = "None"
        Else
            My.Settings.AutosaveLimit = AutosaveLimit ' limited
            'AutosaveLimitTextBox.Text = limitAmount
        End If

        If Not IsNothing(TextBox1.Text) AndAlso Directory.Exists(TextBox1.Text) Then
            My.Settings.GameSaveDirectory = TextBox1.Text
        End If
        If Not IsNothing(TextBox2.Text) AndAlso Directory.Exists(TextBox2.Text) Then
            My.Settings.AutosaveStorageDirectory = TextBox2.Text
        End If

        If Not IsNothing(backgroundPicture) Then
            'My.Settings.BackgroundImageLoc
        End If

        If Not IsNothing(QuickSaveCounter) Then
            My.Settings.QuickSaveCounter = QuickSaveCounter
        End If

        If Not IsNothing(LastQuickSavePath) Then
            My.Settings.LastQuickSavePath = LastQuickSavePath
        End If

        If Not IsNothing(QuickSaveHotKey) Then
            My.Settings.QuickSaveHotKey = QuickSaveHotKey
        End If
        If Not IsNothing(QuickLoadHotKey) Then
            My.Settings.QuickLoadHotKey = QuickLoadHotKey
        End If
        Hotkeys.Close()

        Me.Show()
        Me.WindowState = FormWindowState.Normal ' Unminimize Window
    End Sub

    Public Sub QuickLoad() Handles QuickLoadButton.Click
        If Not Directory.Exists(LastQuickSavePath) Then
            MsgBox("Quick load failed!" & vbNewLine & vbNewLine & "quick save does not exist: " & """" & LastQuickSavePath & """", MsgBoxStyle.Critical)
        Else
            If IsNothing(My.Settings.ManualSaveResetInterval) OrElse My.Settings.ManualSaveResetInterval = True Then
                SyncLock timer1Lock
                    If StartButton.Text = "Stop Autosaving" Then ' currently autosaving
                        SaveTimerPtr.Stop()
                        Me.BackColor = Color.Gold ' reset color
                        StartSaving()
                    End If
                End SyncLock
            End If
            If Directory.Exists(TextBox1.Text) Then

                If My.Settings.BackupQuickLoad Then ' if quick load backup enabled
                    If TextBox2.Text(TextBox2.Text.Length - 1) = "\" Then
                        TextBox2.Text = TextBox2.Text.Substring(0, TextBox2.Text.Length - 1)
                    End If
                    Dim BackupDestination As String = TextBox2.Text & "\" & "Quick Save Temporary Backup"
                    If Directory.Exists(BackupDestination) Then
                        My.Computer.FileSystem.DeleteDirectory(BackupDestination, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    My.Computer.FileSystem.CopyDirectory(TextBox1.Text, BackupDestination)
                End If

                My.Computer.FileSystem.DeleteDirectory(TextBox1.Text, FileIO.DeleteDirectoryOption.DeleteAllContents) ' delete destination
            End If
            My.Computer.FileSystem.CopyDirectory(LastQuickSavePath, TextBox1.Text) ' copy to destination
        End If
    End Sub

    Private Sub CurrentTimer_Tick(sender As Object, e As EventArgs) Handles CurrentTimer.Tick
        CurrentTimeLabel.Text = TimeOfDay
    End Sub

    Private Sub SaveTimer_Tick(sender As Object, e As EventArgs) Handles SaveTimer.Tick
        SyncLock timer1Lock
            If CDate(AlarmTimeDatePicker.Text) = TimeOfDay Then
                SaveTimerPtr.Stop() ' turn off this timer

                Me.BackColor = Color.Gold ' reset color

                ThisForm.SaveNow()

                'Reset() ' reset settings
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
                        Me.BackColor = Color.Gold ' reset color
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
    Dim AutoSaveCounter As Decimal ' autosave number to append to the end
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

                If QuickSaveButtonFlag = True AndAlso
                Not IsNothing(My.Settings.AlternateSaveNowLocationEnabled) AndAlso My.Settings.AlternateSaveNowLocationEnabled = True Then

                    If Not Directory.Exists(My.Settings.AlternateSaveNowLocation) Then
                        Dim result As MsgBoxResult = MsgBox("Alternate """"Save Now"""" location does not exist!" & vbNewLine &
                                "Save to autosave directory instead?", MsgBoxStyle.OkCancel, "Error")
                        If result = MsgBoxResult.Ok Then
                            Destination = TextBox2.Text ' autosave destination location
                        Else
                            endThread = False
                            Exit Sub ' cancel/abort saving
                        End If
                    Else
                        Destination = My.Settings.AlternateSaveNowLocation
                    End If
                Else
                    Destination = TextBox2.Text ' autosave destination location
                End If

                If Source(Source.Length - 1) = "\" Then
                    Source = Source.Substring(0, Source.Length - 1)
                    My.Settings.GameSaveDirectory = Source
                End If
                If Destination(Destination.Length - 1) = "\" Then
                    Destination = Destination.Substring(0, Destination.Length - 1)
                    If QuickSaveButtonFlag = False Then
                        My.Settings.AutosaveStorageDirectory = Destination
                    End If
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
                If QuickSaveButtonFlag = True Then
                    Destination = Destination & "\" & "Quick Save " & QuickSaveCounter
                Else
                    Destination = Destination & "\" & "Autosave " & AutoSaveCounter
                End If

                ' Copy to the save location.
                CopyToSaveLocation(overwriteFlag)

                ' Increment the save count.
                If QuickSaveButtonFlag = True Then ' quick save
                    If Not QuickSaveCounter = 79228162514264337593543950335D Then
                        QuickSaveCounter += 1 ' increment count
                    Else
                        QuickSaveCounter = 1 ' integer max or limit reached
                    End If
                    My.Settings.QuickSaveCounter = QuickSaveCounter
                    If CounterSwitchButton.Text = QuickSaveText Then
                        SaveCountTextBox.Text = QuickSaveCounter ' update counter amount
                    End If
                Else ' autosave
                    If Not AutoSaveCounter = AutosaveLimit Then
                        AutoSaveCounter += 1 ' increment count
                    Else
                        AutoSaveCounter = 1 ' integer max or limit reached
                    End If
                    My.Settings.AutoSaveCounter = AutoSaveCounter
                    If CounterSwitchButton.Text = AutoSaveText Then
                        SaveCountTextBox.Text = AutoSaveCounter ' update counter amount
                    End If
                End If


                'Reset()

                If QuickSaveButtonFlag = True AndAlso
                   StartButton.Text = "Stop Autosaving" AndAlso Not IsNothing(My.Settings.ManualSaveResetInterval) AndAlso My.Settings.ManualSaveResetInterval = True _
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

            My.Settings.Save()

            endThread = False ' reset back to false for later uses
        End SyncLock
    End Sub

    ''' <summary>
    ''' Copy the source directory contents to the destination directory. (all of this is due to FileSystem.CopyDirectory not working when override is false but some stuff exists...)
    ''' </summary>
    ''' <param name="overwriteFlag">Flag determining whether or not files/folders will be overridden at destination if they already exist.</param>
    Private Sub CopyToSaveLocation(ByVal overwriteFlag As Boolean)
        Dim TopFolderName As String = GetFileName(Source)
        Dim UpperDestination As String = Destination
        Destination = Destination & "\" & TopFolderName
        If QuickSaveButtonFlag = True Then
            LastQuickSavePath = Destination ' set new last quick save path
        End If
        If overwriteFlag = True Then
            If Directory.Exists(Destination) Then ' case 1
                If Not IsNothing(My.Settings.SimpleAutosaveOverwriting) AndAlso My.Settings.SimpleAutosaveOverwriting = True Then
                    Try
                        If Not IsNothing(My.Settings.SimpleAutosaveOverwritingPermaDelete) AndAlso My.Settings.SimpleAutosaveOverwritingPermaDelete = False Then
                            My.Computer.FileSystem.DeleteDirectory(UpperDestination, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                        Else ' My.Settings.SimpleAutosaveOverwritingPermaDelete = true (default when nothing)
                            My.Computer.FileSystem.DeleteDirectory(UpperDestination, FileIO.DeleteDirectoryOption.DeleteAllContents)
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
                If Not IsNothing(SubFiles) Then
                    SubFiles.Clear()
                Else
                    SubFiles = New ArrayList
                End If
                If Not IsNothing(SubDirectories) Then
                    SubDirectories.Clear()
                Else
                    SubDirectories = New ArrayList
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

            End If
        End If
    End Sub

    Dim SubFiles As ArrayList ' list of all files in source
    Dim SubDirectories As ArrayList ' list of all directories in source (with source path cut out)
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

    Private Sub AddAllFromSubFoldersRecursive(ByRef path As String)
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
    Public Function GetFileName(ByRef Str As String) As String
        Dim count As Integer = 0
        For c As Integer = Str.Length - 1 To 0 Step -1
            If Str(c) = "\"c Then
                If Not c = 0 Then ' doesn't have slash as last char (Not Str.Length - c = Str.Length)
                    Return Str.Substring(c + 1, count)
                End If
            End If
            count += 1
        Next
        Return Str
    End Function

    ''' <summary>
    ''' Get the containing folder of a given path as string.
    ''' </summary>
    Public Function GetContainingFolder(path As String) As String
        Dim count As Integer = 0
        For i As Integer = path.Length - 1 To 0 Step -1
            If path(i) = "\"c Then
                MsgBox(path.Substring(0, path.Length - (count + 1)))
                Return path.Substring(0, path.Length - (count + 1))
            End If
            count += 1
        Next
        Return ""
    End Function

    Private Sub Reset()
        Control.CheckForIllegalCrossThreadCalls = False
        StartButton.Text = "Start Autosaving" ' reset button text
        AlarmTimeLabel.Text = "Never" ' reset alarm set to text
        NumericUpDown1.Enabled = True
        Me.BackColor = System.Drawing.SystemColors.Control ' reset color
    End Sub

    Public Sub StopThread()
        endThread = True
    End Sub

    Private Sub Browse1_Click(sender As Object, e As EventArgs) Handles Browse1.Click
        Browse(TextBox1)
    End Sub

    Private Sub Browse2_Click(sender As Object, e As EventArgs) Handles Browse2.Click
        Browse(TextBox2)
    End Sub

    Private Sub Browse(obj As Object)
        If Directory.Exists(obj.Text) Then
            FolderBrowserDialog1.SelectedPath = obj.Text
        End If
        If Not (FolderBrowserDialog1.ShowDialog() = DialogResult.Cancel Or DialogResult.Abort) Then
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
        If MinimizeButtonFlag = True Then ' only when "minimize to tray" button is used and not standard minimizing
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
    Public Sub OpenDirectoryButton(path As String)
        If IsNothing(path) OrElse path = "" Then
            MsgBox("No path has been specified.", MsgBoxStyle.Information, "Error")
        ElseIf Not Directory.Exists(path) Then
            MsgBox("The directory does not exist.", MsgBoxStyle.Information, "Error")
        Else
            'Call Shell("explorer /select," & """" & path & """", AppWinStyle.NormalFocus)
            Process.Start("""" & path & """")
        End If
    End Sub

    Dim backgroundPicture As Image
    ''' <summary>
    ''' Set the background of the form to a selected image file.
    ''' </summary>
    Public Sub BackgroundImageSelect()
        ' Set to current image path if one is in use
        If Not IsNothing(My.Settings.BackgroundImageLoc) Then
            Dim path As String = Me.GetDirectoryString(TextBox1.Text)
            If Directory.Exists(path) Then
                OpenImageFileDialog.InitialDirectory = path ' set initial path to currently used one where a file was selected in the past
                If IO.File.Exists(TextBox1.Text) Then
                    OpenImageFileDialog.FileName = Me.GetFileDisplayString(TextBox1.Text)
                Else
                    OpenImageFileDialog.FileName = ""
                End If
            End If
        End If

        If OpenImageFileDialog.ShowDialog = DialogResult.OK Then
            My.Settings.BackgroundImageLoc = OpenImageFileDialog.FileName
            My.Settings.Save()
            backgroundPicture = Image.FromFile(OpenImageFileDialog.FileName)
            RefreshBackgroundImage()
        End If
    End Sub

    ''' <summary>
    ''' refresh the background image by replacing it at the control's current dimensions
    ''' </summary>
    Public Sub RefreshBackgroundImage()
        If Not IsNothing(My.Settings.BackgroundImageLoc) AndAlso File.Exists(My.Settings.BackgroundImageLoc) Then ' if background image is something
            Using bmp1 = New Bitmap(Me.Width, Me.Height - StartButton.Height) ' stretch the background image to fit the new size
                Using g1 = Graphics.FromImage(bmp1)
                    g1.DrawImage(backgroundPicture, 0, 0, bmp1.Width, bmp1.Height)
                    Me.BackgroundImage = bmp1.Clone
                End Using
            End Using
        End If
    End Sub

    Private Sub NewScreen_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        If shownComplete = True Then
            resizeInProgress = True
        End If
    End Sub

    Private Sub NewScreen_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If shownComplete = True Then
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
    Public Function GetFileDisplayString(str As String) As String
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
    Public Function GetDirectoryString(str As String) As String
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
        AutosaveF1TextBox.Text = CInt(AutosaveF1TextBox.Text) + 1 ' Autosave failure
    End Sub

    Private Sub ChangeCountButton_Click(sender As Object, e As EventArgs) Handles ChangeCountButton.Click
        Dim newCount As String = InputBox("Input new count", "", SaveCountTextBox.Text)
        If IsNothing(newCount) OrElse newCount = "" Then
            'MsgBox("Entered value is blank.", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(newCount) Then
            MsgBox("Entered value is not a number.", MsgBoxStyle.Exclamation, "Error")
        Else ' success
            Dim tempNum As Decimal
            If Decimal.TryParse(newCount, tempNum) Then
                tempNum = Math.Truncate(CDec(newCount))
            Else
                MsgBox("Entered value is too large.", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If

            If tempNum > 79228162514264337593543950335D Then
                MsgBox("Entered value is too high.", MsgBoxStyle.Exclamation, "Error")
            ElseIf tempNum < 1D AndAlso Not tempNum = 0D Then
                MsgBox("Entered value cannot be negative.", MsgBoxStyle.Exclamation, "Error")
            ElseIf tempNum > AutosaveLimit Then
                MsgBox("Entered value cannot be higher than the specified limit.", MsgBoxStyle.Exclamation, "Error")
            Else ' success
                Dim newCounter As Decimal = tempNum
                If newCounter = 0 Then
                    newCounter = 1
                End If

                SyncLock accessLock
                    If CounterSwitchButton.Text = QuickSaveText Then
                        My.Settings.QuickSaveCounter = newCounter
                        QuickSaveCounter = newCounter
                    ElseIf CounterSwitchButton.Text = AutoSaveText Then
                        My.Settings.AutoSaveCounter = newCounter
                        AutoSaveCounter = newCounter
                    End If
                    SaveCountTextBox.Text = newCounter

                    My.Settings.Save()
                End SyncLock
            End If
        End If
    End Sub

    ''' <summary>
    ''' Toggle state of round robin.
    ''' </summary>
    Private Sub CheckIfRoundRobinable()
        If OverwriteComboBox.SelectedIndex = 1 Then ' yes overwrites autosaves
            'OverwriteComboBox.Enabled = False
            My.Settings.RoundRobinEnabled = True
            RoundRobinButton.Text = "Enabled"
        Else
            'OverwriteComboBox.Enabled = True
            My.Settings.RoundRobinEnabled = False
            RoundRobinButton.Text = "Disabled"
        End If
        My.Settings.Save()
    End Sub

    Dim roundRobinButtonWasClicked As Boolean = False
    ''' <summary>
    ''' Button that toggles round robin saving on or off at the defined amount.
    ''' </summary>
    Private Sub RoundRobinButton_Click(sender As Object, e As EventArgs) Handles RoundRobinButton.Click

        roundRobinButtonWasClicked = True
        If RoundRobinButton.Text = "Disabled" Then ' setting to enabled now
            If AutosaveLimitTextBox.Text = "None" Then ' attempt to set limit (optional)
                ChangeLimitButton_Click()
            End If

            My.Settings.OverwriteSaves = True
            OverwriteComboBox.Enabled = True
            OverwriteComboBox.SelectedIndex = 1 ' true / Do overwrite saves
            OverwriteComboBox.Enabled = False

            My.Settings.RoundRobinEnabled = True
            RoundRobinButton.Text = "Enabled"
        ElseIf RoundRobinButton.Text = "Enabled" Then ' setting to disabled now

            My.Settings.OverwriteSaves = False
            OverwriteComboBox.Enabled = True
            OverwriteComboBox.SelectedIndex = 0 ' false / Don't overwrite saves
            OverwriteComboBox.Enabled = False

            My.Settings.RoundRobinEnabled = False
            RoundRobinButton.Text = "Disabled"
        End If
        roundRobinButtonWasClicked = False

        My.Settings.Save()
    End Sub

    Dim AutosaveLimit As Decimal
    Private Function ChangeLimitButton_Click() As Boolean Handles ChangeLimitButton.Click
        'AutosaveLimitTextBox.Text

        Dim newVal As String
        If AutosaveLimitTextBox.Text = "None" Then
            newVal = InputBox("Input new limit or 0 for no limit", "", "0")
        Else
            newVal = InputBox("Input new limit or 0 for no limit", "", AutosaveLimitTextBox.Text)
        End If

        If IsNothing(newVal) OrElse newVal = "" Then
            'MsgBox("Entered value is blank.", MsgBoxStyle.Exclamation, "Error")
        ElseIf Not IsNumeric(newVal) Then
            MsgBox("Entered value is not a number.", MsgBoxStyle.Exclamation, "Error")
        Else ' success
            Dim tempNum As Decimal
            If Decimal.TryParse(newVal, tempNum) Then
                tempNum = Math.Truncate(CDec(newVal))
            Else
                MsgBox("Entered value is too large.", MsgBoxStyle.Exclamation, "Error")
                Return False ' failure
            End If

            If tempNum > 79228162514264337593543950335D Then
                MsgBox("Entered value is too high.", MsgBoxStyle.Exclamation, "Error")
            ElseIf tempNum < 0D Then
                MsgBox("Entered value cannot be negative.", MsgBoxStyle.Exclamation, "Error")
            Else ' success
                Dim newValue As Decimal = CDec(tempNum)
                SyncLock accessLock
                    If newValue = 0 Then ' unlimited
                        My.Settings.AutosaveLimit = 79228162514264337593543950335D
                        AutosaveLimit = 79228162514264337593543950335D
                        AutosaveLimitTextBox.Text = "None"
                    Else ' limited
                        My.Settings.AutosaveLimit = newValue
                        AutosaveLimit = newValue
                        AutosaveLimitTextBox.Text = newValue
                        If OverwriteComboBox.SelectedIndex = 0 AndAlso roundRobinButtonWasClicked = False Then ' false don't overwrite
                            MsgBox("Please consider enabling round robin." & vbNewLine & "Otherwise once the autosaving starts from 1 again nothing will be overwritten.",
                                   MsgBoxStyle.Exclamation, "Warning")
                        End If
                    End If
                    If AutoSaveCounter > AutosaveLimit Then ' set autosave counter to 1 if now above the new limit
                        My.Settings.AutoSaveCounter = 1
                        AutoSaveCounter = 1
                        SaveCountTextBox.Text = 1
                    End If
                    My.Settings.Save()
                End SyncLock

                Return True ' success
            End If
        End If
        Return False ' failure
    End Function

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        'Dim Name As String = InputBox("Specify the name.", "Rename", Label6.Text)
        'If Not IsNothing(Name) AndAlso Not Name = "" AndAlso Name.Length < 50 AndAlso Not Label6.Text = Name Then
        'Label6.Text = Name
        'End If
    End Sub

    ''' <summary>
    ''' Settings button clicked.
    ''' </summary>
    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        SettingsForm.Show()
    End Sub

    ''' <summary>
    ''' Show list of loadable game autosave configs
    ''' </summary>
    Private Sub GameListButton_Click(sender As Object, e As EventArgs) Handles GameListButton.Click
        GameList.Show()
    End Sub

    Dim QuickSaveText As String = "quick save"
    Dim AutoSaveText As String = "autosave"

    ''' <summary>
    ''' Switches the text in the button to manual save or auto save, which will determine which counter is shown and editable.
    ''' </summary>
    Private Sub CounterSwitchButton_Click(sender As Object, e As EventArgs) Handles CounterSwitchButton.Click
        If CounterSwitchButton.Text = AutoSaveText Then
            CounterSwitchButton.Text = "quick save"
            SaveCountTextBox.Text = QuickSaveCounter
        ElseIf CounterSwitchButton.Text = QuickSaveText Then
            CounterSwitchButton.Text = "autosave"
            SaveCountTextBox.Text = AutoSaveCounter
        End If
    End Sub

End Class


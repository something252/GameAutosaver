Imports System.IO

Public Class GameData
    Public GameList As New Dictionary(Of String, GameSettings) ' name, save settings

    Public QuickSaveHotkey As Keys = Keys.F5
    Public QuickLoadHotkey As Keys = Keys.F8

    Private Loading As Boolean = True
    Public Sub FinishedLoading()
        Loading = False
    End Sub

    Private _CurrentName As String = ""
    ''' <summary>
    ''' Currently active game name
    ''' </summary>
    Public Property CurrentName As String
        Get
            Return _CurrentName
        End Get
        Set(value As String)
            If Not Loading Then
                If GameList.ContainsKey(value) Then
                    _CurrentName = value
                End If
            Else
                _CurrentName = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Currently active game settings
    ''' </summary>
    Public Property CurrentSettings As GameSettings
        Get
            If GameList.ContainsKey(CurrentName) Then
                Return GameList(CurrentName)
            Else
                Return Nothing
            End If
        End Get
        Set(value As GameSettings)
            If Not Loading Then
                If GameList.ContainsKey(CurrentName) Then
                    GameList(CurrentName) = value
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Rename name from gamelist.
    ''' </summary>
    Public Function RenameGameName(mainForm As MainForm, oldName As String, newName As String) As Boolean
        If mainForm IsNot Nothing AndAlso newName IsNot Nothing AndAlso
            Not newName = "" AndAlso Not oldName = "" AndAlso newName.Length < 300 AndAlso Not mainForm.Label6.Text = newName AndAlso
            GameList.ContainsKey(oldName) AndAlso Not GameList.ContainsKey(newName) Then

            Dim tmp As GameSettings = GameList(oldName)
            tmp.Name = newName
            If CurrentName = oldName Then
                UseNewSave(newName, tmp)
                mainForm.Label6.Text = newName
            Else
                GameList.Add(newName, tmp)
            End If
            GameList.Remove(oldName)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Add new game save or overwrite existing one using given name and setting, then set name as current save name.
    ''' </summary>
    Public Sub UseNewSave(name As String, Optional settings As GameSettings = Nothing)
        If settings Is Nothing Then
            settings = New GameSettings
        End If
        settings.Name = name

        If Not GameList.ContainsKey(name) Then
            GameList.Add(name, settings)
            CurrentName = name
        Else ' use already existing save and overwrite
            CurrentName = name
            CurrentSettings = settings
        End If
    End Sub

    ''' <summary>
    ''' Load save of given name.
    ''' </summary>
    Public Function LoadSave(mainForm As MainForm, name As String, Optional startup As Boolean = False) As Boolean
        If name <> "" Then
            If GameList.ContainsKey(name) Then
                If Not startup Then
                    SaveCurrentSettings(mainForm)
                End If
                CurrentName = name
                LoadSettings(mainForm, GameList(name))
                Return True
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' Load blank save when gamelist is empty on main form startup.
    ''' </summary>
    Public Sub StartupLoadBlankSave(mainForm As MainForm)
        If mainForm IsNot Nothing Then
            UseNewSave(mainForm.Label6.Text, New GameSettings)
            LoadSettings(mainForm, New GameSettings)
        End If
    End Sub

    Private Sub LoadSettings(mainForm As MainForm, settings As GameSettings)
        If mainForm IsNot Nothing AndAlso settings IsNot Nothing Then
            With settings

                If .Name <> "" Then
                    mainForm.Label6.Text = .Name
                Else
                    mainForm.Label6.Text = "GAME AUTOSAVER"
                End If
                CurrentName = mainForm.Label6.Text

                mainForm.CurrentTimer.Start() ' Start current time related timer
                mainForm.NumericUpDown1.Value = .AutoSaveIntervalMinutes

                mainForm.TextBox1.Text = .GameSaveDirectory
                mainForm.TextBox2.Text = .AutoSaveStorageDirectory

                mainForm.CounterSwitchButton.Text = MainForm.AutoSaveText
                If .AutoSaveCounter > .AutoSaveLimit Then
                    mainForm.SaveCountTextBox.Text = "1"
                Else
                    mainForm.SaveCountTextBox.Text = CStr(.AutoSaveCounter)
                End If
                mainForm.Label7.Text = MainForm.AutoSaveLimitText
                If .AutoSaveLimit = 0 Then
                    mainForm.SaveLimitTextBox.Text = "None"
                Else
                    mainForm.SaveLimitTextBox.Text = CStr(.AutoSaveLimit)
                End If

                If File.Exists(.BackgroundImageLoc) Then
                    Try
                        mainForm.BackgroundPicture = Image.FromFile(.BackgroundImageLoc)
                        mainForm.RefreshBackgroundImage()
                    Catch
                    End Try
                Else
                    mainForm.BackgroundImage = Nothing
                End If

                If .RoundRobinEnabled = False Then ' exists and is false
                    If .OverwriteSaves = False Then
                        mainForm.OverwriteComboBox.SelectedIndex = 0 ' false / Don't overwrite saves
                    Else
                        mainForm.OverwriteComboBox.SelectedIndex = 1 ' true / Do overwrite saves
                    End If
                    mainForm.RoundRobinButton.Text = "Disabled"
                Else
                    mainForm.OverwriteComboBox.SelectedIndex = 1 ' true / Do overwrite saves
                    mainForm.RoundRobinButton.Text = "Enabled"
                End If

                mainForm.HotkeysTimer.Start()
            End With
        End If
    End Sub

    Public Sub SaveCurrentSettings(mainForm As MainForm)
        If mainForm IsNot Nothing Then
            CurrentSettings.Name = mainForm.Label6.Text
            CurrentSettings.AutoSaveIntervalMinutes = CInt(mainForm.NumericUpDown1.Value)
            If mainForm.OverwriteComboBox.SelectedIndex = 0 Then ' false / Don't overwrite saves
                CurrentSettings.OverwriteSaves = False
            ElseIf mainForm.OverwriteComboBox.SelectedIndex = 1 Then ' true / Do overwrite saves
                CurrentSettings.OverwriteSaves = True
            End If
            CurrentSettings.GameSaveDirectory = mainForm.TextBox1.Text
            CurrentSettings.AutoSaveStorageDirectory = mainForm.TextBox2.Text
        End If
    End Sub
End Class

Public Class GameSettings
    Public Name As String
    Public GameSaveDirectory As String = ""
    Public AutoSaveStorageDirectory As String = ""
    Public AutoSaveIntervalMinutes As Integer = 5

    Private _AutoSaveCounter As Integer = 1
    Public Property AutoSaveCounter() As Integer
        Get
            Return _AutoSaveCounter
        End Get
        Set(value As Integer)
            _AutoSaveCounter = value
        End Set
    End Property

    Public OverwriteSaves As Boolean = False
    Public BackgroundImageLoc As String = ""
    Public RoundRobinEnabled As Boolean = True

    Private _AutoSaveLimit As Integer = 0
    Public Property AutoSaveLimit() As Integer
        Get
            Return _AutoSaveLimit
        End Get
        Set(value As Integer)
            _AutoSaveLimit = value
        End Set
    End Property

    Public AlternateSaveNowLocationEnabled As Boolean = False
    Public AlternateSaveNowLocation As String = ""

    Private _QuickSaveCounter As Integer = 1
    Public Property QuickSaveCounter() As Integer
        Get
            Return _QuickSaveCounter
        End Get
        Set(value As Integer)
            _QuickSaveCounter = value
        End Set
    End Property

    Private _QuickSaveLimit As Integer = 0
    Public Property QuickSaveLimit() As Integer
        Get
            Return _QuickSaveLimit
        End Get
        Set(value As Integer)
            _QuickSaveLimit = value
        End Set
    End Property


    Public LastQuickSavePath As String = ""
End Class
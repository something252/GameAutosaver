
Public Class Hotkeys

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer

    ' prevents key from being held down and registering more than once before being unpressed
    Dim QuickSaveKeyPressed As Boolean = False
    Dim QuickLoadKeyPressed As Boolean = False

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If GetKeyPress(MainForm.QuickSaveHotKey) Then ' Quick save hotkey press
            If QuickSaveKeyPressed = False Then
                QuickSaveKeyPressed = True

                If MainForm.HotkeysChangeLock = False Then
                    MainForm.QuickSaveButton_Click() ' quick save button click
                End If
            End If
        Else
            QuickSaveKeyPressed = False ' key was not pressed
        End If

        If GetKeyPress(MainForm.QuickLoadHotKey) Then ' Quick load hotkey press
            If QuickLoadKeyPressed = False Then
                QuickLoadKeyPressed = True

                If MainForm.HotkeysChangeLock = False Then
                    MainForm.QuickLoad() ' Quick load
                End If
            End If
        Else
            QuickLoadKeyPressed = False ' key was not pressed
        End If

        MainForm.HotkeysChangeLock = False
    End Sub

End Class
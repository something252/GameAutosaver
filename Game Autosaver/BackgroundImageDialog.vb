Public Class BackgroundImageDialog


    Private Sub BackgroundImageDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Icon_256
    End Sub

    ''' <summary>
    ''' Change background.
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.BackgroundImageSelect()

        Me.Close()
    End Sub

    ''' <summary>
    ''' Reset/clear background.
    ''' </summary>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.Games.CurrentSettings.BackgroundImageLoc = ""
        MainForm.SaveMySettings()
        MainForm.BackgroundImage = Nothing

        Me.Close()
    End Sub
End Class
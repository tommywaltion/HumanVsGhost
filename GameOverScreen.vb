Public Class GameOverScreen
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Playground.Hide()
        Playground.ResetsData()
        Me.Hide()
        mainMenu.Show()
        mainMenu.BackgroundMusicPlayer.Ctlcontrols.play()
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        Me.Hide()
        Playground.ResetsData()
        Playground.start_Wave()
    End Sub
End Class
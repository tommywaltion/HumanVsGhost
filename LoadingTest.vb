Public NotInheritable Class LoadingTest
    Private Sub LoadingTest_Load(sender As Object, e As EventArgs) Handles Me.Shown
        Dim Str As IO.Stream = My.Resources.SplashSound
        Dim snd As New Media.SoundPlayer(Str)
        snd.Play()
    End Sub
End Class

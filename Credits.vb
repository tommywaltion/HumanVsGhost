Public Class Credits

    Private Sub Credits_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim fullHeigth As Integer
        CreditBox.Location = New Point(Me.Width / 2 - CreditBox.Width / 2, -200)
        For Each ctrl As Control In CreditBox.Controls
            fullHeigth += ctrl.Height
        Next
        CreditBox.Height = fullHeigth + 200
        CreditBox.Top = Me.Height
        Scrolling.Start()
    End Sub

    Private Sub Scrolling_Tick(sender As Object, e As EventArgs) Handles Scrolling.Tick
        If CreditBox.Top + CreditBox.Height <= 0 Then
            Scrolling.Stop()
            Me.Hide()
            mainMenu.Show()
            Exit Sub
        End If
        CreditBox.Top -= 2
    End Sub

    Private Sub Credits_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Scrolling.Stop()
        Me.Hide()
        mainMenu.Show()
    End Sub
End Class

Imports System.ComponentModel
Imports System.Drawing.Imaging

Public Class mainMenu
    Private Sub MulaiBTN_Click(sender As Object, e As EventArgs) Handles MulaiBTN.Click
        BackgroundMusicPlayer.Ctlcontrols.stop()
        Playground.maxEnemyInWave = 20
        Playground.minEnemyInWave = 15
        Me.Hide()
        Playground.Show()
        Playground.start_Wave()
    End Sub

    Public Sub reseting()
        Playground.ResetsData()
        BackgroundMusicPlayer.Ctlcontrols.play()
    End Sub

    Private Sub KeluarBTN_Click(sender As Object, e As EventArgs) Handles KeluarBTN.Click
        Dim jawaban As Integer
        jawaban = MsgBox("Apakah anda yakin ingin keluar ?", vbQuestion + vbYesNo + vbDefaultButton2, "")
        If jawaban = vbYes Then
            BackgroundMusicPlayer.Ctlcontrols.stop()
            Playground.applicationClosing = True
            Playground.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub MainMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim jawaban As Integer
        jawaban = MsgBox("Apakah anda yakin ingin keluar ?", vbQuestion + vbYesNo + vbDefaultButton2, "")
        If jawaban = vbNo Then
            e.Cancel = True
            Exit Sub
        End If
        BackgroundMusicPlayer.Ctlcontrols.stop()
        Playground.applicationClosing = True
        Playground.Close()
    End Sub

    Private Sub mainMenu_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        BackgroundMusicPlayer.Ctlcontrols.play()
    End Sub

    Private Sub mainMenu_Load_1(sender As Object, e As EventArgs) Handles Me.Load
        writeCredits()
        SelectionMenu.Location = New Point(0, 0)
        Alamanac.Location = New Point(0, 0)
        Versus.Left = Alamanac.Width / 2 - Versus.Width / 2
        SelectionMenu.Visible = True
        Alamanac.Visible = False
        SelectionMenu.BringToFront()
        Playground.Hide()
        BackgroundMusicPlayer.URL = CurDir() & "\Music\Sound_MainMenu.wav"
        BackgroundMusicPlayer.settings.playCount = 9999
        BackgroundMusicPlayer.settings.volume = 75
        BackgroundMusicPlayer.Ctlcontrols.stop()
    End Sub

    Private Sub KembaliBTN_Click(sender As Object, e As EventArgs) Handles KembaliBTN.Click
        SelectionMenu.Visible = True
        Alamanac.Visible = False
        SelectionMenu.BringToFront()
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles AlmanacBTN.Click
        SelectionMenu.Visible = False
        Alamanac.Visible = True
        Alamanac.BringToFront()
    End Sub

    Private Sub PictureBox17_Click_1(sender As Object, e As EventArgs) Handles CreditBTN.Click
        Me.Hide()
        Credits.ShowDialog()
    End Sub
    Private Sub writeCredits()
        Dim ProjectProgramer As New Label With {
            .Text = "Manager Projects & Programmer",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 9)
            }
        Dim ProjectProgramerMember As New Label With {
            .Text = "Raihan Desfitra",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)
            }
        Dim SoundDesign As New Label With {
            .Text = "Sound Design",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 9)}
        Dim SoundDesignMember As New Label With {
            .Text = "Andi Ahmad Zaelani",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim Designer As New Label With {
            .Text = "Design",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 9)}
        Dim DesignerMember1 As New Label With {
            .Text = "Andi Ahmad Zaelani",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim DesignerMember2 As New Label With {
            .Text = "Raihan Ilham Habibi",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim DesignerMember3 As New Label With {
            .Text = "Sri Mulyani",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim DesignerMember4 As New Label With {
            .Text = "Tri Fuji Astuti",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim GameTester As New Label With {
            .Text = "Game Tester",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 9)}
        Dim GameTesterMember As New Label With {
            .Text = "Andi Ahmad Zaelani",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim GameName As New Label With {
            .Text = "Humans Vs Ghost",
            .AutoSize = True,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font(Credits.FontStored.Font.FontFamily.ToString(), 18)}
        Dim LogoPicture As New PictureBox With {
            .Image = My.Resources.logo1,
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .BorderStyle = Nothing,
            .Size = New Point(250, 250)}
        Dim LogozPicture As New PictureBox With {
            .Image = My.Resources.Logo_ITI_1_,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .BorderStyle = Nothing,
            .Size = New Point(250, 250)}
        Credits.CreditBox.Controls.Add(ProjectProgramer)
        Credits.CreditBox.Controls.Add(ProjectProgramerMember)
        Credits.CreditBox.Controls.Add(SoundDesign)
        Credits.CreditBox.Controls.Add(SoundDesignMember)
        Credits.CreditBox.Controls.Add(Designer)
        Credits.CreditBox.Controls.Add(DesignerMember1)
        Credits.CreditBox.Controls.Add(DesignerMember2)
        Credits.CreditBox.Controls.Add(DesignerMember3)
        Credits.CreditBox.Controls.Add(DesignerMember4)
        Credits.CreditBox.Controls.Add(GameTester)
        Credits.CreditBox.Controls.Add(GameTesterMember)
        Credits.CreditBox.Controls.Add(GameName)
        Credits.CreditBox.Controls.Add(LogoPicture)
        Credits.CreditBox.Controls.Add(LogozPicture)
        Credits.CreditBox.Width = SoundDesignMember.Width * 1.5
        ProjectProgramer.Top = 25
        ProjectProgramer.Left = Credits.CreditBox.Width / 2 - ProjectProgramer.Width / 2
        ProjectProgramerMember.Top += ProjectProgramer.Top + ProjectProgramer.Height
        ProjectProgramerMember.Left = Credits.CreditBox.Width / 2 - ProjectProgramerMember.Width / 2
        SoundDesign.Top += ProjectProgramerMember.Top + ProjectProgramerMember.Height + 25
        SoundDesign.Left = Credits.CreditBox.Width / 2 - SoundDesign.Width / 2
        SoundDesignMember.Top += SoundDesign.Top + SoundDesign.Height
        SoundDesignMember.Left = Credits.CreditBox.Width / 2 - SoundDesignMember.Width / 2
        Designer.Top += SoundDesignMember.Top + SoundDesignMember.Height + 25
        Designer.Left = Credits.CreditBox.Width / 2 - Designer.Width / 2
        DesignerMember1.Top += Designer.Top + Designer.Height
        DesignerMember1.Left = Credits.CreditBox.Width / 2 - DesignerMember1.Width / 2
        DesignerMember2.Top += DesignerMember1.Top + DesignerMember1.Height
        DesignerMember2.Left = Credits.CreditBox.Width / 2 - DesignerMember2.Width / 2
        DesignerMember3.Top += DesignerMember2.Top + DesignerMember2.Height
        DesignerMember3.Left = Credits.CreditBox.Width / 2 - DesignerMember3.Width / 2
        DesignerMember4.Top += DesignerMember3.Top + DesignerMember3.Height
        DesignerMember4.Left = Credits.CreditBox.Width / 2 - DesignerMember4.Width / 2
        GameTester.Top += DesignerMember4.Top + DesignerMember4.Height + 25
        GameTester.Left = Credits.CreditBox.Width / 2 - GameTester.Width / 2
        GameTesterMember.Top += GameTester.Top + GameTester.Height
        GameTesterMember.Left = Credits.CreditBox.Width / 2 - GameTesterMember.Width / 2
        GameName.Top += GameTesterMember.Top + GameTesterMember.Height + 50
        GameName.Left = Credits.CreditBox.Width / 2 - GameName.Width / 2
        LogoPicture.Top += GameName.Top + GameName.Height
        LogoPicture.Left = Credits.CreditBox.Width / 2 - LogoPicture.Width / 2
        LogozPicture.Top += LogoPicture.Top + LogoPicture.Height + 50
        LogozPicture.Left = Credits.CreditBox.Width / 2 - LogozPicture.Width / 2
        Credits.BgPart1.BringToFront()
        Credits.BgPart2.SendToBack()
        Credits.BgPart3.BringToFront()
    End Sub
End Class
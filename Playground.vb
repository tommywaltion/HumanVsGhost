
Imports AxWMPLib

Public Class Playground
    Dim PocongKeliling As New Bitmap(My.Resources.PocongKeliling)
    Dim Jailangkung As New Bitmap(My.Resources.Ja_ilangkung)
    Dim Bahyul As New Bitmap(My.Resources.Bahyul)
    Dim KantulAnak As New Bitmap(My.Resources.Kuntilanak)
    Dim Dragcula As New Bitmap(My.Resources.Dragcula)
    Dim Djin As New Bitmap(My.Resources.jin)
    Dim Kuyang As New Bitmap(My.Resources.kuyang)
    Dim BatuIjo As New Bitmap(My.Resources.BatuIjo)

    Dim selectingTangan As New Bitmap(My.Resources.slot2)
    Dim unselectedTangan As New Bitmap(My.Resources.slottangan)
    Dim KasirSprite As New Bitmap(My.Resources.kasir)
    Dim KasirPackets As New Bitmap(My.Resources.Aber)
    Dim KasirPackets_Selected As New Bitmap(My.Resources.Aber_Selected)
    Dim OjolSprite As New Bitmap(My.Resources.ojol)
    Dim OjolPackets As New Bitmap(My.Resources.Ojolali)
    Dim OjolPackets_Selected As New Bitmap(My.Resources.Ojolali_Selected)
    Dim PecuSprite As New Bitmap(My.Resources.Tatank)
    Dim PecuPackets As New Bitmap(My.Resources.Pecu)
    Dim PecuPackets_Selected As New Bitmap(My.Resources.Pecu_Selected)
    Dim UciSprite As New Bitmap(My.Resources.ukhti)
    Dim UciPackets As New Bitmap(My.Resources.uci)
    Dim UciPackets_Selected As New Bitmap(My.Resources.uci_Selected)
    Dim DosanSprite As New Bitmap(My.Resources.Dokter)
    Dim DosanPackets As New Bitmap(My.Resources.Dosan)
    Dim DosanPackets_Selected As New Bitmap(My.Resources.Dosan_Selected)
    Dim EmongSprite As New Bitmap(My.Resources.emakrempong)
    Dim EmongPackets As New Bitmap(My.Resources.Emong)
    Dim EmongPackets_Selected As New Bitmap(My.Resources.Emong_Selected)
    Dim STMSprite As New Bitmap(My.Resources.AnakSTM)
    Dim STMPackets As New Bitmap(My.Resources.slotsSTM)
    Dim STMPackets_Selected As New Bitmap(My.Resources.slotsSTM_Selected)
    Dim PegalSprite As New Bitmap(My.Resources.preman)
    Dim PegalPackets As New Bitmap(My.Resources.Pegal)
    Dim PegalPackets_Selected As New Bitmap(My.Resources.Pegal_Selected)
    Dim Stum As New Bitmap(My.Resources.stume)

    Dim ParticleCangkul1 As Image = My.Resources.Cangkul_1
    Dim ParticleCangkul2 As Image = My.Resources.Cangkul_2
    Dim ParticleCangkul3 As Image = My.Resources.Cangkul_3

    Dim tanganLuarLayar As New Point(0, -100)
    Dim besarCoin As New Point(50, 50)

    Dim Generator As New Random()

    Dim heroSound(9, 5) As AxWindowsMediaPlayer

    Public maxEnemyInWave As Integer = 20
    Public minEnemyInWave As Integer = 10
    Public applicationClosing As Boolean

    Dim heroPlacement(9, 5) As PictureBox
    Dim heroHealth(9, 5) As Integer
    Dim heroDamage(9, 5) As Integer
    Dim selected_hero As Integer
    Dim heroAttackTimer(9, 5) As Timer
    Dim Lane1Particle As New ArrayList
    Dim Lane1ParticleTimer As New ArrayList
    Dim Lane2Particle As New ArrayList
    Dim Lane2ParticleTimer As New ArrayList
    Dim Lane3Particle As New ArrayList
    Dim Lane3ParticleTimer As New ArrayList
    Dim Lane4Particle As New ArrayList
    Dim Lane4ParticleTimer As New ArrayList
    Dim Lane5Particle As New ArrayList
    Dim Lane5ParticleTimer As New ArrayList

    Dim enemyLeft As Integer
    Dim enemyLeftForLabel As Integer
    Dim enemyOnLane As New BitArray(5, False)
    Dim enemyLane1 As New ArrayList
    Dim Lane1Health As New ArrayList
    Dim Lane1MovementTimer As New ArrayList
    Dim enemyLane2 As New ArrayList
    Dim Lane2Health As New ArrayList
    Dim Lane2MovementTimer As New ArrayList
    Dim enemyLane3 As New ArrayList
    Dim Lane3Health As New ArrayList
    Dim Lane3MovementTimer As New ArrayList
    Dim enemyLane4 As New ArrayList
    Dim Lane4Health As New ArrayList
    Dim Lane4MovementTimer As New ArrayList
    Dim enemyLane5 As New ArrayList
    Dim Lane5Health As New ArrayList
    Dim Lane5MovementTimer As New ArrayList

    Dim coinStored As Integer = 50
    Dim CoinJatuh As New ArrayList

    Dim lastLineDefense As New BitArray(5, True)

    Dim enemyTimer As Integer
    Dim coinGenPlanted As Integer
    Dim movedToTimer As Boolean
    Dim lastWave As Boolean
    Dim spawnNewEnemy As Boolean

    Structure enemyStats
        Dim Name As String
        Dim health As Integer
        Dim movementSpeed As Integer
        Dim eatingSpeed As Integer
        Dim charImage As Bitmap
        Dim charWidth As Integer
        Dim charHeight As Integer
        Dim charTop As Integer
        Dim charLeft As Integer
    End Structure

    Private enemyList() As enemyStats = {
            New enemyStats With {
                      .Name = "Tuyul",
                      .health = 5,
                      .movementSpeed = 100,
                      .eatingSpeed = 250,
                      .charImage = Bahyul,
                      .charWidth = 50,
                      .charHeight = 50,
                      .charLeft = 25,
                      .charTop = 50},
            New enemyStats With {
                      .Name = "Pocong",
                      .health = 10,
                      .movementSpeed = 250,
                      .eatingSpeed = 500,
                      .charImage = PocongKeliling,
                      .charWidth = 100,
                      .charHeight = 100,
                      .charLeft = 100,
                      .charTop = 100},
            New enemyStats With {
                      .Name = "Jalangkung",
                      .health = 15,
                      .movementSpeed = 250,
                      .eatingSpeed = 500,
                      .charImage = Jailangkung,
                      .charWidth = 75,
                      .charHeight = 75,
                      .charLeft = 25,
                      .charTop = 100},
            New enemyStats With {
                      .Name = "KuntilAnak",
                      .health = 15,
                      .movementSpeed = 250,
                      .eatingSpeed = 500,
                      .charImage = KantulAnak,
                      .charWidth = 100,
                      .charHeight = 100,
                      .charLeft = 100,
                      .charTop = 100},
            New enemyStats With {
                      .Name = "Kuyang",
                      .health = 7,
                      .movementSpeed = 150,
                      .eatingSpeed = 500,
                      .charImage = Kuyang,
                      .charWidth = 50,
                      .charHeight = 50,
                      .charLeft = 100,
                      .charTop = 100},
            New enemyStats With {
                      .Name = "Dracula",
                      .health = 30,
                      .movementSpeed = 750,
                      .eatingSpeed = 500,
                      .charImage = Dragcula,
                      .charWidth = 100,
                      .charHeight = 100,
                      .charLeft = 100,
                      .charTop = 100},
            New enemyStats With {
                      .Name = "Jin",
                      .health = 20,
                      .movementSpeed = 400,
                      .eatingSpeed = 500,
                      .charImage = Djin,
                      .charWidth = 100,
                      .charHeight = 100,
                      .charLeft = 100,
                      .charTop = 100},
            New enemyStats With {
                      .Name = "Ijo",
                      .health = 40,
                      .movementSpeed = 900,
                      .eatingSpeed = 500,
                      .charImage = BatuIjo,
                      .charWidth = 100,
                      .charHeight = 100,
                      .charLeft = 100,
                      .charTop = 100}
        }

    Dim enemyProbability() As Double = {0.2, 0.33125, 0.140625, 0.125, 0.0725, 0.0525, 0.046875, 0.03125}

    'Load the entire map
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        BackgroundMusicPlayer.URL = CurDir() & "\Music\Sound_War.wav"
        BackgroundMusicPlayer.settings.playCount = 9999
        BackgroundMusicPlayer.settings.volume = 75
        BackgroundMusicPlayer.Ctlcontrols.stop()
        EnemySound.URL = ""
        EnemySound.settings.playCount = 1
        EnemySound.settings.volume = 75
        Randomize()
        For Each ctrl As Control In Background.Controls.OfType(Of PictureBox)
            If LSet(ctrl.Name, 9) = "Placement" Then
                Dim posX As Integer = Val(Mid(ctrl.Name, ctrl.Name.Length(), 1))
                Dim posY As Integer = Val(Mid(ctrl.Name, ctrl.Name.Length() - 1, 1))
                heroPlacement(posX, posY) = ctrl
                AddHandler ctrl.Click, AddressOf Planting
            End If
        Next
        For Each ctrl As AxWindowsMediaPlayer In Background.Controls.OfType(Of AxWindowsMediaPlayer)
            If LSet(ctrl.Name, 5) = "Sound" Then
                Dim posX As Integer = Val(Mid(ctrl.Name, ctrl.Name.Length(), 1))
                Dim posY As Integer = Val(Mid(ctrl.Name, ctrl.Name.Length() - 1, 1))
                ctrl.settings.playCount = 1
                ctrl.settings.volume = 100
                ctrl.Ctlcontrols.stop()
                heroSound(posX, posY) = ctrl
            End If
        Next
        updateCoin()
        TanganSelected.Top = -100
        Spawner1.Left += Background.Width - (Spawner1.Left + Spawner1.Width)
        Spawner1.Visible = False
        Spawner2.Left += Background.Width - (Spawner2.Left + Spawner2.Width)
        Spawner2.Visible = False
        Spawner3.Left += Background.Width - (Spawner3.Left + Spawner3.Width)
        Spawner3.Visible = False
        Spawner4.Left += Background.Width - (Spawner4.Left + Spawner4.Width)
        Spawner4.Visible = False
        Spawner5.Left += Background.Width - (Spawner5.Left + Spawner5.Width)
        Spawner5.Visible = False
    End Sub
    'Random coin fall randomly on the map to help user
    Private Sub RandomCoin_Tick(sender As Object, e As EventArgs) Handles RandomCoin.Tick
        Dim posX As Integer = Generator.Next(1, 10)
        Dim posY As Integer = Generator.Next(1, 6)
        Dim fallenCoin As New PictureBox With {
                        .Size = besarCoin,
                        .BackColor = Color.DarkGreen,
                        .Top = heroPlacement(posX, posY).Top - 20,
                        .Left = heroPlacement(posX, posY).Left - 20,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Image = My.Resources.coin,
                        .Name = "FallingCoin"
                    }
        AddHandler fallenCoin.Click, AddressOf collectCoin
        CoinJatuh.Add(fallenCoin)
        Me.Controls.Add(fallenCoin)
        fallenCoin.BringToFront()
    End Sub
    'update the sun when coinStored changed
    Private Sub updateCoin()
        CoinStoredTXT.Text = coinStored.ToString()
    End Sub
    'when user wanted to plant and selected one of the plant placement, see what hero they choose and run function for the hero iit chooses
    Public Sub Planting(sender As Object, e As System.EventArgs)
        Dim posX As Integer = Val(Mid(sender.Name, sender.Name.Length(), 1))
        Dim posY As Integer = Val(Mid(sender.Name, sender.Name.Length() - 1, 1))
        Dim placePos As PictureBox = sender
        Dim times As New Timer
        Select Case selected_hero
            Case -1
                If Not IsNothing(placePos.Image) AndAlso Not IsNothing(heroAttackTimer(posX, posY)) Then
                    placePos.Image = Nothing
                    heroSound(posX, posY).URL = Nothing
                    heroHealth(posX, posY) = Nothing
                    heroDamage(posX, posY) = Nothing
                    heroAttackTimer(posX, posY).Stop()
                    heroAttackTimer(posX, posY).Dispose()
                    heroAttackTimer(posX, posY) = Nothing
                End If
            Case 0
                Return
            Case 1
                If IsNothing(placePos.Image) AndAlso coinStored >= 50 Then
                    placePos.Image = KasirSprite
                    heroHealth(posX, posY) = 6
                    coinGenPlanted += 1
                    coinStored -= 50
                    times.Interval = 6000
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Kasir.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf Kasir
                    heroDamage(posX, posY) = 0
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
            Case 2
                If IsNothing(placePos.Image) AndAlso coinStored >= 75 Then
                    placePos.Image = OjolSprite
                    heroHealth(posX, posY) = 3
                    coinStored -= 75
                    times.Interval = 1500
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Ojol.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf OjekOnline
                    heroDamage(posX, posY) = 1
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
            Case 3
                If IsNothing(placePos.Image) AndAlso coinStored >= 100 Then
                    placePos.Image = PecuSprite
                    heroHealth(posX, posY) = 6
                    coinStored -= 100
                    times.Interval = 1500
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Pacul.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf Petani
                    heroDamage(posX, posY) = 1
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
            Case 4
                If IsNothing(placePos.Image) AndAlso coinStored >= 100 Then
                    placePos.Image = UciSprite
                    heroHealth(posX, posY) = 6
                    coinStored -= 100
                    times.Interval = 1750
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Panah.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf Pemanah
                    heroDamage(posX, posY) = 1
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
            Case 5
                If IsNothing(placePos.Image) AndAlso coinStored >= 125 Then
                    placePos.Image = DosanSprite
                    heroHealth(posX, posY) = 4
                    coinStored -= 125
                    times.Interval = 2500
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Doctor.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf Dokter
                    heroDamage(posX, posY) = 2
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
            Case 6
                If IsNothing(placePos.Image) AndAlso coinStored >= 125 Then
                    placePos.Image = EmongSprite
                    heroHealth(posX, posY) = 75
                    coinStored -= 125
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Panci.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    heroDamage(posX, posY) = 0
                    heroAttackTimer(posX, posY) = times
                End If
            Case 7
                If IsNothing(placePos.Image) AndAlso coinStored >= 125 Then
                    placePos.Image = STMSprite
                    heroHealth(posX, posY) = 6
                    coinStored -= 125
                    times.Interval = 400
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound STM.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf STM
                    heroDamage(posX, posY) = 2
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
            Case 8
                If IsNothing(placePos.Image) AndAlso coinStored >= 175 Then
                    placePos.Image = PegalSprite
                    heroHealth(posX, posY) = 15
                    coinStored -= 175
                    times.Interval = 500
                    heroSound(posX, posY).URL = CurDir() & "\SoundEffects\Sound Preman.wav"
                    heroSound(posX, posY).Ctlcontrols.stop()
                    AddHandler times.Tick, AddressOf Preman
                    heroDamage(posX, posY) = 2
                    heroAttackTimer(posX, posY) = times
                    heroAttackTimer(posX, posY).Start()
                End If
        End Select
        updateCoin()
        selected_hero = 0
        HeroPackets1.Image = KasirPackets
        HeroPackets2.Image = OjolPackets
        HeroPackets3.Image = PecuPackets
        HeroPackets4.Image = UciPackets
        HeroPackets5.Image = DosanPackets
        HeroPackets6.Image = EmongPackets
        HeroPackets7.Image = STMPackets
        HeroPackets8.Image = PegalPackets
        SlotTangan.Image = unselectedTangan
        TanganFollowMouse.Stop()
        TanganSelected.Location = tanganLuarLayar
    End Sub
    'for kasir 
    Private Sub Kasir(sender As Object, e As EventArgs)
        Dim coinTimer As Timer = sender
        Dim check As Boolean
        If Not coinTimer.Interval = 24000 Then
            coinTimer.Interval = 24000
        End If
        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(coinTimer) Then
                    check = True
                    heroSound(x, y).Ctlcontrols.play()
                    Dim spawnCoin As New PictureBox With {
                        .Size = besarCoin,
                        .BackColor = Color.DarkGreen,
                        .Top = heroPlacement(x, y).Top - 20,
                        .Left = heroPlacement(x, y).Left - 20,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Image = New Bitmap(My.Resources.coin)
                    }
                    CoinJatuh.Add(spawnCoin)
                    AddHandler spawnCoin.Click, AddressOf collectCoin
                    Me.Controls.Add(spawnCoin)
                    spawnCoin.BringToFront()
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    'add stored coin when clicking coin
    Private Sub collectCoin(sender As Object, e As EventArgs)
        Me.Controls.Remove(sender)
        CoinJatuh.Remove(sender)
        sender.Dispose()
        coinStored += 25
        updateCoin()
    End Sub
    'for ojol
    Private Sub OjekOnline(sender As Object, e As EventArgs)
        Dim attackTimer As Timer = sender
        Dim check As Boolean

        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(attackTimer) Then
                    If enemyOnLane(y - 1) = False Then
                        heroPlacement(x, y).Image = OjolSprite
                        Return
                    End If
                    check = True
                    Dim melee As Boolean
                    If y = 1 Then
                        For Each enemy As PictureBox In enemyLane1
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = OjolSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                attackTimer.Interval = 500
                                heroPlacement(x, y).Image = My.Resources.OjolAttackMelee
                                heroSound(x, y).Ctlcontrols.play()
                                Lane1Health(enemyLane1.IndexOf(enemy)) -= heroDamage(x, y)
                                melee = True
                                Exit For
                            End If
                            heroPlacement(x, y).Image = OjolSprite
                        Next
                    ElseIf y = 2 Then
                        For Each enemy As PictureBox In enemyLane2
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = OjolSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                attackTimer.Interval = 500
                                heroPlacement(x, y).Image = My.Resources.OjolAttackMelee
                                heroSound(x, y).Ctlcontrols.play()
                                Lane2Health(enemyLane2.IndexOf(enemy)) -= heroDamage(x, y)
                                melee = True
                                Exit For
                            End If
                            heroPlacement(x, y).Image = OjolSprite
                        Next
                    ElseIf y = 3 Then
                        For Each enemy As PictureBox In enemyLane3
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = OjolSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                attackTimer.Interval = 500
                                heroPlacement(x, y).Image = My.Resources.OjolAttackMelee
                                heroSound(x, y).Ctlcontrols.play()
                                Lane3Health(enemyLane3.IndexOf(enemy)) -= heroDamage(x, y)
                                melee = True
                                Exit For
                            End If
                            heroPlacement(x, y).Image = OjolSprite
                        Next
                    ElseIf y = 4 Then
                        For Each enemy As PictureBox In enemyLane4
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = OjolSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                attackTimer.Interval = 500
                                heroPlacement(x, y).Image = My.Resources.OjolAttackMelee
                                heroSound(x, y).Ctlcontrols.play()
                                Lane4Health(enemyLane4.IndexOf(enemy)) -= heroDamage(x, y)
                                melee = True
                                Exit For
                            End If
                            heroPlacement(x, y).Image = OjolSprite
                        Next
                    ElseIf y = 5 Then
                        For Each enemy As PictureBox In enemyLane5
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                attackTimer.Interval = 500
                                heroSound(x, y).Ctlcontrols.play()
                                Lane5Health(enemyLane5.IndexOf(enemy)) -= heroDamage(x, y)
                                melee = True
                                Exit For
                            End If
                        Next
                    End If
                    If melee = False Then
                        attackTimer.Interval = 1500
                        heroPlacement(x, y).Image = My.Resources.OjolAttackShoot
                        heroSound(x, y).Ctlcontrols.play()
                        Dim attack_particle As New PictureBox With {
                            .Size = New Point(50, 50),
                            .BackColor = Color.DarkGreen,
                            .Top = heroPlacement(x, y).Top + heroPlacement(x, y).Size.Height / 2 - 30,
                            .Left = heroPlacement(x, y).Left + heroPlacement(x, y).Size.Width / 2,
                            .SizeMode = PictureBoxSizeMode.StretchImage,
                            .Image = My.Resources.Helm,
                            .Name = x.ToString()
                            }
                        Dim attackMoving As New Timer
                        attackMoving.Interval = 100
                        attackMoving.Start()
                        If y = 1 Then
                            Lane1ParticleTimer.Add(attackMoving)
                            Lane1Particle.Add(attack_particle)
                        ElseIf y = 2 Then
                            Lane2ParticleTimer.Add(attackMoving)
                            Lane2Particle.Add(attack_particle)
                        ElseIf y = 3 Then
                            Lane3ParticleTimer.Add(attackMoving)
                            Lane3Particle.Add(attack_particle)
                        ElseIf y = 4 Then
                            Lane4ParticleTimer.Add(attackMoving)
                            Lane4Particle.Add(attack_particle)
                        ElseIf y = 5 Then
                            Lane5ParticleTimer.Add(attackMoving)
                            Lane5Particle.Add(attack_particle)
                        End If
                        Me.Controls.Add(attack_particle)
                        Dim time As Timer = attackMoving
                        AddHandler time.Tick, AddressOf MovingParticle
                        attack_particle.BringToFront()
                    End If
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    'for Petani
    Private Sub Petani(sender As Object, e As EventArgs)
        Dim attackTimer As Timer = sender
        Dim check As Boolean
        Dim ran As Integer = Generator.Next(1, 4)
        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(attackTimer) Then
                    If enemyOnLane(y - 1) = False Then
                        heroPlacement(x, y).Image = PecuSprite
                        Return
                    End If
                    check = True
                    heroPlacement(x, y).Image = My.Resources.PetaniAttack
                    Dim attack_particle As New PictureBox With {
                        .Size = New Point(50, 50),
                        .BackColor = Color.DarkGreen,
                        .Top = heroPlacement(x, y).Top + heroPlacement(x, y).Size.Height / 2 - 30,
                        .Left = heroPlacement(x, y).Left + heroPlacement(x, y).Size.Width / 2,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Name = x.ToString()
                    }
                    If ran = 1 Then
                        attack_particle.Image = ParticleCangkul1
                    ElseIf ran = 2 Then
                        attack_particle.Image = ParticleCangkul2
                    ElseIf ran = 3 Then
                        attack_particle.Image = ParticleCangkul3
                    End If
                    Dim attackMoving As New Timer
                    attackMoving.Interval = 50
                    attackMoving.Start()
                    If y = 1 Then
                        Lane1ParticleTimer.Add(attackMoving)
                        Lane1Particle.Add(attack_particle)
                    ElseIf y = 2 Then
                        Lane2ParticleTimer.Add(attackMoving)
                        Lane2Particle.Add(attack_particle)
                    ElseIf y = 3 Then
                        Lane3ParticleTimer.Add(attackMoving)
                        Lane3Particle.Add(attack_particle)
                    ElseIf y = 4 Then
                        Lane4ParticleTimer.Add(attackMoving)
                        Lane4Particle.Add(attack_particle)
                    ElseIf y = 5 Then
                        Lane5ParticleTimer.Add(attackMoving)
                        Lane5Particle.Add(attack_particle)
                    End If
                    Me.Controls.Add(attack_particle)
                    Dim time As Timer = attackMoving
                    AddHandler time.Tick, AddressOf MovingParticle
                    attack_particle.BringToFront()
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    'for uci
    Private Sub Pemanah(sender As Object, e As EventArgs)
        Dim attackTimer As Timer = sender
        Dim check As Boolean

        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(attackTimer) Then
                    If enemyOnLane(y - 1) = False Then
                        heroPlacement(x, y).Image = UciSprite
                        Return
                    End If
                    check = True
                    heroPlacement(x, y).Image = My.Resources.ukhtiAttack
                    heroSound(x, y).Ctlcontrols.play()
                    Dim attack_particle As New PictureBox With {
                        .Size = New Point(50, 50),
                        .BackColor = Color.DarkGreen,
                        .Top = heroPlacement(x, y).Top + heroPlacement(x, y).Size.Height / 2 - 30,
                        .Left = heroPlacement(x, y).Left + heroPlacement(x, y).Size.Width / 2,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Image = My.Resources.panah,
                        .Name = x.ToString()
                    }
                    Dim attackMoving As New Timer
                    attackMoving.Interval = 50
                    attackMoving.Start()
                    If y = 1 Then
                        Lane1ParticleTimer.Add(attackMoving)
                        Lane1Particle.Add(attack_particle)
                    ElseIf y = 2 Then
                        Lane2ParticleTimer.Add(attackMoving)
                        Lane2Particle.Add(attack_particle)
                    ElseIf y = 3 Then
                        Lane3ParticleTimer.Add(attackMoving)
                        Lane3Particle.Add(attack_particle)
                    ElseIf y = 4 Then
                        Lane4ParticleTimer.Add(attackMoving)
                        Lane4Particle.Add(attack_particle)
                    ElseIf y = 5 Then
                        Lane5ParticleTimer.Add(attackMoving)
                        Lane5Particle.Add(attack_particle)
                    End If
                    Me.Controls.Add(attack_particle)
                    Dim time As Timer = attackMoving
                    AddHandler time.Tick, AddressOf MovingParticle
                    attack_particle.BringToFront()
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    'for dokter
    Private Sub Dokter(sender As Object, e As EventArgs)
        Dim attackTimer As Timer = sender
        Dim check As Boolean

        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(attackTimer) Then
                    If enemyOnLane(y - 1) = False Then
                        heroPlacement(x, y).Image = DosanSprite
                        Return
                    End If
                    check = True
                    heroPlacement(x, y).Image = My.Resources.DokterAttack
                    heroSound(x, y).Ctlcontrols.play()
                    Dim attack_particle As New PictureBox With {
                        .Size = New Point(50, 50),
                        .BackColor = Color.DarkGreen,
                        .Top = heroPlacement(x, y).Top + heroPlacement(x, y).Size.Height / 2 - 40,
                        .Left = heroPlacement(x, y).Left + heroPlacement(x, y).Size.Width / 2,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Image = My.Resources.Suntikan,
                        .Name = x.ToString()
                    }
                    Dim attackMoving As New Timer
                    attackMoving.Interval = 100
                    attackMoving.Start()
                    If y = 1 Then
                        Lane1ParticleTimer.Add(attackMoving)
                        Lane1Particle.Add(attack_particle)
                    ElseIf y = 2 Then
                        Lane2ParticleTimer.Add(attackMoving)
                        Lane2Particle.Add(attack_particle)
                    ElseIf y = 3 Then
                        Lane3ParticleTimer.Add(attackMoving)
                        Lane3Particle.Add(attack_particle)
                    ElseIf y = 4 Then
                        Lane4ParticleTimer.Add(attackMoving)
                        Lane4Particle.Add(attack_particle)
                    ElseIf y = 5 Then
                        Lane5ParticleTimer.Add(attackMoving)
                        Lane5Particle.Add(attack_particle)
                    End If
                    Me.Controls.Add(attack_particle)
                    Dim time As Timer = attackMoving
                    AddHandler time.Tick, AddressOf MovingParticle
                    attack_particle.BringToFront()
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    'for moving the attack to the right and check if its outside of screen
    Private Sub MovingParticle(sender As Timer, e As EventArgs)
        Dim attack As PictureBox
        Dim posX As Integer
        If Lane1ParticleTimer.Contains(sender) Then
            attack = Lane1Particle(Lane1ParticleTimer.IndexOf(sender))
            posX = Val(attack.Name)
            If attack.Left + attack.Width + 50 >= Me.Width Then
                sender.Stop()
                sender.Dispose()
                Lane1ParticleTimer.Remove(sender)
                Me.Controls.Remove(attack)
                attack.Dispose()
                Lane1Particle.Remove(attack)
                Exit Sub
            End If
            For Each enemy As PictureBox In enemyLane1
                If enemy.Name = "KuntilAnak" Then
                    Continue For
                End If
                If enemy.Bounds.IntersectsWith(attack.Bounds) Then
                    If attack.Image.Equals(ParticleCangkul1) Or attack.Image.Equals(ParticleCangkul2) Or attack.Image.Equals(ParticleCangkul3) Then
                        heroSound(posX, 1).Ctlcontrols.play()
                    End If
                    sender.Stop()
                    sender.Dispose()
                    Lane1ParticleTimer.Remove(sender)
                    Me.Controls.Remove(attack)
                    attack.Dispose()
                    Lane1Particle.Remove(attack)
                    If attack.Image Is My.Resources.Suntikan AndAlso enemy.Name = "Dracula" Then
                        Lane1Health(enemyLane1.IndexOf(enemy)) -= heroDamage(posX, 1) * 2
                    Else
                        Lane1Health(enemyLane1.IndexOf(enemy)) -= heroDamage(posX, 1)
                    End If
                    Exit For
                End If
            Next
            attack.Left += 25
        ElseIf Lane2ParticleTimer.Contains(sender) Then
            attack = Lane2Particle(Lane2ParticleTimer.IndexOf(sender))
            posX = Val(attack.Name)
            If attack.Left + attack.Width + 50 >= Me.Width Then
                sender.Stop()
                sender.Dispose()
                Lane2ParticleTimer.Remove(sender)
                Me.Controls.Remove(attack)
                attack.Dispose()
                Lane2Particle.Remove(attack)
                Exit Sub
            End If
            For Each enemy As PictureBox In enemyLane2
                If enemy.Name = "KuntilAnak" Then
                    Continue For
                End If
                If enemy.Bounds.IntersectsWith(attack.Bounds) Then
                    If attack.Image.Equals(ParticleCangkul1) Or attack.Image.Equals(ParticleCangkul2) Or attack.Image.Equals(ParticleCangkul3) Then
                        heroSound(posX, 2).Ctlcontrols.play()
                    End If
                    sender.Stop()
                    sender.Dispose()
                    Lane2ParticleTimer.Remove(sender)
                    Me.Controls.Remove(attack)
                    attack.Dispose()
                    Lane2Particle.Remove(attack)
                    If attack.Image Is My.Resources.Suntikan AndAlso enemy.Name = "Dracula" Then
                        Lane2Health(enemyLane2.IndexOf(enemy)) -= heroDamage(posX, 2) * 2
                    Else
                        Lane2Health(enemyLane2.IndexOf(enemy)) -= heroDamage(posX, 2)
                    End If
                    Exit For
                End If
            Next
            attack.Left += 25
        ElseIf Lane3ParticleTimer.Contains(sender) Then
            attack = Lane3Particle(Lane3ParticleTimer.IndexOf(sender))
            posX = Val(attack.Name)
            If attack.Left + attack.Width + 50 >= Me.Width Then
                sender.Stop()
                sender.Dispose()
                Lane3ParticleTimer.Remove(sender)
                Me.Controls.Remove(attack)
                attack.Dispose()
                Lane3Particle.Remove(attack)
                Exit Sub
            End If
            For Each enemy As PictureBox In enemyLane3
                If enemy.Name = "KuntilAnak" Then
                    Continue For
                End If
                If enemy.Bounds.IntersectsWith(attack.Bounds) Then
                    If attack.Image.Equals(ParticleCangkul1) Or attack.Image.Equals(ParticleCangkul2) Or attack.Image.Equals(ParticleCangkul3) Then
                        heroSound(posX, 3).Ctlcontrols.play()
                    End If
                    sender.Stop()
                    sender.Dispose()
                    Lane3ParticleTimer.Remove(sender)
                    Me.Controls.Remove(attack)
                    attack.Dispose()
                    Lane3Particle.Remove(attack)
                    If attack.Image Is My.Resources.Suntikan AndAlso enemy.Name = "Dracula" Then
                        Lane3Health(enemyLane3.IndexOf(enemy)) -= heroDamage(posX, 3) * 2
                    Else
                        Lane3Health(enemyLane3.IndexOf(enemy)) -= heroDamage(posX, 3)
                    End If
                    Exit For
                End If
            Next
            attack.Left += 25
        ElseIf Lane4ParticleTimer.Contains(sender) Then
            attack = Lane4Particle(Lane4ParticleTimer.IndexOf(sender))
            posX = Val(attack.Name)
            If attack.Left + attack.Width + 50 >= Me.Width Then
                sender.Stop()
                sender.Dispose()
                Lane4ParticleTimer.Remove(sender)
                Me.Controls.Remove(attack)
                attack.Dispose()
                Lane4Particle.Remove(attack)
                Exit Sub
            End If
            For Each enemy As PictureBox In enemyLane4
                If enemy.Name = "KuntilAnak" Then
                    Continue For
                End If
                If enemy.Bounds.IntersectsWith(attack.Bounds) Then
                    If attack.Image.Equals(ParticleCangkul1) Or attack.Image.Equals(ParticleCangkul2) Or attack.Image.Equals(ParticleCangkul3) Then
                        heroSound(posX, 4).Ctlcontrols.play()
                    End If
                    sender.Stop()
                    sender.Dispose()
                    Lane4ParticleTimer.Remove(sender)
                    Me.Controls.Remove(attack)
                    attack.Dispose()
                    Lane4Particle.Remove(attack)
                    If attack.Image Is My.Resources.Suntikan AndAlso enemy.Name = "Dracula" Then
                        Lane4Health(enemyLane4.IndexOf(enemy)) -= heroDamage(posX, 4) * 2
                    Else
                        Lane4Health(enemyLane4.IndexOf(enemy)) -= heroDamage(posX, 4)
                    End If
                    Exit For
                End If
            Next
            attack.Left += 25
        ElseIf Lane5ParticleTimer.Contains(sender) Then
            attack = Lane5Particle(Lane5ParticleTimer.IndexOf(sender))
            posX = Val(attack.Name)
            If attack.Left + attack.Width + 50 >= Me.Width Then
                sender.Stop()
                sender.Dispose()
                Lane5ParticleTimer.Remove(sender)
                Me.Controls.Remove(attack)
                attack.Dispose()
                Lane5Particle.Remove(attack)
                Exit Sub
            End If
            For Each enemy As PictureBox In enemyLane5
                If enemy.Name = "KuntilAnak" Then
                    Continue For
                End If
                If enemy.Bounds.IntersectsWith(attack.Bounds) Then
                    If attack.Image.Equals(ParticleCangkul1) Or attack.Image.Equals(ParticleCangkul2) Or attack.Image.Equals(ParticleCangkul3) Then
                        heroSound(posX, 5).Ctlcontrols.play()
                    End If
                    sender.Stop()
                    sender.Dispose()
                    Lane5ParticleTimer.Remove(sender)
                    Me.Controls.Remove(attack)
                    attack.Dispose()
                    Lane5Particle.Remove(attack)
                    If attack.Image Is My.Resources.Suntikan AndAlso enemy.Name = "Dracula" Then
                        Lane5Health(enemyLane5.IndexOf(enemy)) -= heroDamage(posX, 5) * 2
                    Else
                        Lane5Health(enemyLane5.IndexOf(enemy)) -= heroDamage(posX, 5)
                    End If
                    Exit For
                End If
            Next
            attack.Left += 25
        End If
    End Sub
    Private Sub STM(sender As Object, e As EventArgs)
        Dim attackTimer As Timer = sender
        Dim check As Boolean

        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(attackTimer) Then
                    If enemyOnLane(y - 1) = False Then
                        heroPlacement(x, y).Image = STMSprite
                        Return
                    End If
                    check = True
                    If y = 1 Then
                        For Each enemy As PictureBox In enemyLane1
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = STMSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.STMAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane1Health(enemyLane1.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = STMSprite
                        Next
                    ElseIf y = 2 Then
                        For Each enemy As PictureBox In enemyLane2
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = STMSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.STMAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane2Health(enemyLane2.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = STMSprite
                        Next
                    ElseIf y = 3 Then
                        For Each enemy As PictureBox In enemyLane3
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = STMSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.STMAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane3Health(enemyLane3.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = STMSprite
                        Next
                    ElseIf y = 4 Then
                        For Each enemy As PictureBox In enemyLane4
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = STMSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.STMAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane4Health(enemyLane4.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = STMSprite
                        Next
                    ElseIf y = 5 Then
                        For Each enemy As PictureBox In enemyLane5
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = STMSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.STMAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane5Health(enemyLane5.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = STMSprite
                        Next
                    End If
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    Private Sub Preman(sender As Object, e As EventArgs)
        Dim attackTimer As Timer = sender
        Dim check As Boolean

        For x As Integer = 1 To heroAttackTimer.GetUpperBound(0)
            For y As Integer = 1 To heroAttackTimer.GetUpperBound(1)
                If Not IsNothing(heroAttackTimer(x, y)) AndAlso heroAttackTimer(x, y).Equals(attackTimer) Then
                    If enemyOnLane(y - 1) = False Then
                        heroPlacement(x, y).Image = PegalSprite
                        Return
                    End If
                    check = True
                    If y = 1 Then
                        For Each enemy As PictureBox In enemyLane1
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = PegalSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.PremanAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane1Health(enemyLane1.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = PegalSprite
                        Next
                    ElseIf y = 2 Then
                        For Each enemy As PictureBox In enemyLane2
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = PegalSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.PremanAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane2Health(enemyLane2.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = PegalSprite
                        Next
                    ElseIf y = 3 Then
                        For Each enemy As PictureBox In enemyLane3
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = PegalSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.PremanAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane3Health(enemyLane3.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = PegalSprite
                        Next
                    ElseIf y = 4 Then
                        For Each enemy As PictureBox In enemyLane4
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = PegalSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.PremanAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane4Health(enemyLane4.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = PegalSprite
                        Next
                    ElseIf y = 5 Then
                        For Each enemy As PictureBox In enemyLane5
                            If enemy.Name = "Jalangkung" Or enemy.Name = "Kuyang" Then
                                heroPlacement(x, y).Image = PegalSprite
                                Continue For
                            End If
                            If enemy.Left - (heroPlacement(x, y).Left + heroPlacement(x, y).Width) <= 150 Then
                                heroPlacement(x, y).Image = My.Resources.PremanAttack
                                heroSound(x, y).Ctlcontrols.play()
                                Lane5Health(enemyLane5.IndexOf(enemy)) -= heroDamage(x, y)
                                Exit For
                            End If
                            heroPlacement(x, y).Image = PegalSprite
                        Next
                    End If
                    Exit For
                End If
            Next
            If check = True Then
                Exit For
            End If
        Next
    End Sub
    'for Tangan, moved with mouse
    Private Sub PlaygroundMap_MouseMove(sender As Object, e As EventArgs) Handles TanganFollowMouse.Tick
        TanganSelected.Top = MousePosition.Y - Me.Top - TanganSelected.Height / 2 + 5
        TanganSelected.Left = MousePosition.X - Me.Left - TanganSelected.Width / 2
        TanganSelected.BringToFront()
    End Sub
    'for when selected Tangan and remove hero
    Private Sub SlotTangan_Click(sender As Object, e As EventArgs) Handles SlotTangan.Click
        If selected_hero = -1 Then
            selected_hero = 0
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        Else
            selected_hero = -1
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = selectingTangan
            TanganFollowMouse.Start()
        End If
    End Sub
    'for when selected hero 1, Kasir
    Private Sub HeroPackets1_Click(sender As Object, e As EventArgs) Handles HeroPackets1.Click
        If selected_hero = 1 Then
            selected_hero = 0
            HeroPackets1.Image = KasirPackets
        Else
            selected_hero = 1
            HeroPackets1.Image = KasirPackets_Selected
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    'for when selected hero 2, Tatank
    Private Sub HeroPackets2_Click(sender As Object, e As EventArgs) Handles HeroPackets2.Click
        If selected_hero = 2 Then
            selected_hero = 0
            HeroPackets2.Image = OjolPackets
        Else
            selected_hero = 2
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets_Selected
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    Private Sub HeroPackets3_Click(sender As Object, e As EventArgs) Handles HeroPackets3.Click
        If selected_hero = 3 Then
            selected_hero = 0
            HeroPackets3.Image = PecuPackets
        Else
            selected_hero = 3
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets_Selected
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    Private Sub HeroPackets4_Click(sender As Object, e As EventArgs) Handles HeroPackets4.Click
        If selected_hero = 4 Then
            selected_hero = 0
            HeroPackets4.Image = UciPackets
        Else
            selected_hero = 4
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets_Selected
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    Private Sub HeroPackets5_Click(sender As Object, e As EventArgs) Handles HeroPackets5.Click
        If selected_hero = 5 Then
            selected_hero = 0
            HeroPackets5.Image = DosanPackets
        Else
            selected_hero = 5
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets_Selected
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    Private Sub HeroPackets6_Click(sender As Object, e As EventArgs) Handles HeroPackets6.Click
        If selected_hero = 6 Then
            selected_hero = 0
            HeroPackets6.Image = EmongPackets
        Else
            selected_hero = 6
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets_Selected
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    Private Sub HeroPackets7_Click(sender As Object, e As EventArgs) Handles HeroPackets7.Click
        If selected_hero = 7 Then
            selected_hero = 0
            HeroPackets7.Image = STMPackets
        Else
            selected_hero = 7
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets_Selected
            HeroPackets8.Image = PegalPackets
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    Private Sub HeroPackets8_Click(sender As Object, e As EventArgs) Handles HeroPackets8.Click
        If selected_hero = 8 Then
            selected_hero = 0
            HeroPackets8.Image = PegalPackets
        Else
            selected_hero = 8
            HeroPackets1.Image = KasirPackets
            HeroPackets2.Image = OjolPackets
            HeroPackets3.Image = PecuPackets
            HeroPackets4.Image = UciPackets
            HeroPackets5.Image = DosanPackets
            HeroPackets6.Image = EmongPackets
            HeroPackets7.Image = STMPackets
            HeroPackets8.Image = PegalPackets_Selected
            SlotTangan.Image = unselectedTangan
            TanganSelected.Location = tanganLuarLayar
            TanganFollowMouse.Stop()
        End If
    End Sub
    'to spawn enemy
    Private Sub SpawnEnemy()
        Dim randomEnemy As enemyStats
        Dim randomPos As Byte = Generator.Next(5) + 1
        Dim spawnAt As PictureBox = CType(Background.Controls("Spawner" & randomPos), PictureBox)
        randomEnemy = randomItems(enemyList, enemyProbability)
        Dim enemies As New PictureBox With {
            .Width = spawnAt.Width * randomEnemy.charWidth / 100,
            .Height = spawnAt.Height * randomEnemy.charHeight / 100,
            .Top = (spawnAt.Top + spawnAt.Height) - (spawnAt.Height * randomEnemy.charTop / 100),
            .Left = (spawnAt.Left + spawnAt.Width) - (spawnAt.Width * randomEnemy.charLeft / 100) - (spawnAt.Width / 2),
            .BackColor = Color.DarkGreen,
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Image = randomEnemy.charImage,
            .Name = randomEnemy.Name
        }
        Dim timerForMovement As New Timer With {
            .Interval = randomEnemy.movementSpeed
        }
        timerForMovement.Start()
        Dim enemyHealth As Integer = randomEnemy.health
        If EnemySound.playState = 1 Or EnemySound.playState = 0 Then
            If randomEnemy.Name = "Pocong" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound Pocong.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "Tuyul" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound tuyul.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "Jalangkung" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound Jailangkung.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "KuntilAnak" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound kuntilanak.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "Dracula" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound vampir.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "Jin" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound jin.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "Kuyang" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound kuyang.wav"
                EnemySound.Ctlcontrols.play()
            ElseIf randomEnemy.Name = "Ijo" Then
                EnemySound.URL = CurDir() & "\SoundEffects\Sound buta ijo.wav"
                EnemySound.Ctlcontrols.play()
            End If
        End If
        If randomPos = 1 Then
            enemyLane1.Add(enemies)
            Lane1MovementTimer.Add(timerForMovement)
            Lane1Health.Add(enemyHealth)
        ElseIf randomPos = 2 Then
            enemyLane2.Add(enemies)
            Lane2MovementTimer.Add(timerForMovement)
            Lane2Health.Add(enemyHealth)
        ElseIf randomPos = 3 Then
            enemyLane3.Add(enemies)
            Lane3MovementTimer.Add(timerForMovement)
            Lane3Health.Add(enemyHealth)
        ElseIf randomPos = 4 Then
            enemyLane4.Add(enemies)
            Lane4MovementTimer.Add(timerForMovement)
            Lane4Health.Add(enemyHealth)
        ElseIf randomPos = 5 Then
            enemyLane5.Add(enemies)
            Lane5MovementTimer.Add(timerForMovement)
            Lane5Health.Add(enemyHealth)
        End If
        Me.Controls.Add(enemies)
        AddHandler timerForMovement.Tick, AddressOf enemyMoving
        enemyOnLane(randomPos - 1) = True
        enemies.BringToFront()
        enemyLeft -= 1
    End Sub
    'Enemy Randomizer
    Private Function randomItems(enemy As Array, probability As Array) As enemyStats
        Dim sum As Double
        Dim spin As Double
        spin = Rnd()
        For I As Long = LBound(probability) To UBound(probability)
            sum = sum + probability(probability.Length - (1 + I))
            'Console.WriteLine("Sum " & sum & " Prob " & probability(probability.Length - (1 + I)) & " Spin " & spin)
            If spin <= sum Then
                randomItems = enemy(probability.Length - (1 + I))
                Exit Function
            End If
        Next I
        randomItems = enemy(UBound(probability))
    End Function
    'enemy logic
    Private Sub enemyMoving(sender As Timer, e As EventArgs)
        Dim enemy As PictureBox
        If Lane1MovementTimer.Contains(sender) Then
            enemy = enemyLane1(Lane1MovementTimer.IndexOf(sender))
        ElseIf Lane2MovementTimer.Contains(sender) Then
            enemy = enemyLane2(Lane2MovementTimer.IndexOf(sender))
        ElseIf Lane3MovementTimer.Contains(sender) Then
            enemy = enemyLane3(Lane3MovementTimer.IndexOf(sender))
        ElseIf Lane4MovementTimer.Contains(sender) Then
            enemy = enemyLane4(Lane4MovementTimer.IndexOf(sender))
        ElseIf Lane5MovementTimer.Contains(sender) Then
            enemy = enemyLane5(Lane5MovementTimer.IndexOf(sender))
        Else
            Exit Sub
        End If
        Dim enemyMovingTimer As Timer = sender
        'when theres hero on enemy, enemy will eat/destroy it
        If enemyLane1.Contains(enemy) AndAlso Lane1Health(enemyLane1.IndexOf(enemy)) <= 0 Then
            enemyKilled(enemy)
            Exit Sub
        ElseIf enemyLane2.Contains(enemy) AndAlso Lane2Health(enemyLane2.IndexOf(enemy)) <= 0 Then
            enemyKilled(enemy)
            Exit Sub
        ElseIf enemyLane3.Contains(enemy) AndAlso Lane3Health(enemyLane3.IndexOf(enemy)) <= 0 Then
            enemyKilled(enemy)
            Exit Sub
        ElseIf enemyLane4.Contains(enemy) AndAlso Lane4Health(enemyLane4.IndexOf(enemy)) <= 0 Then
            enemyKilled(enemy)
            Exit Sub
        ElseIf enemyLane5.Contains(enemy) AndAlso Lane5Health(enemyLane5.IndexOf(enemy)) <= 0 Then
            enemyKilled(enemy)
            Exit Sub
        End If
        'move enemy if there is a plant on it or not
        Dim stepInPixel As Integer = enemyCollideWithHero(enemy, 2, 1)
        Dim enemystatusData As enemyStats = currentEnemy(enemy)
        If stepInPixel = 0 Then
            sender.Interval = enemystatusData.eatingSpeed
        Else
            enemy.Left -= stepInPixel
            sender.Interval = enemystatusData.movementSpeed
        End If
        'check if there is stem left, if yes use it as last line of defense, kill every enemy in lane
        If enemyCollideWithLastLineDefense(enemy) Then
            Exit Sub
        End If
        'fail check if enemy moved to far off the screen
        If enemy.Left <= 0 Then
            enemyKilled(enemy)
        End If
        'if enemy cross the gameover hitbox
        If GameOverHitBox.Bounds.IntersectsWith(enemy.Bounds) Then
            'Game over screen and stop everything
            GameOverScreen.BackgroundImage = My.Resources.kalah
            ResetsData()
            GameOverScreen.ShowDialog()
        End If
    End Sub
    Function currentEnemy(enemy As PictureBox) As enemyStats
        If enemy.Name = "Pocong" Then
            Return enemyList.GetValue(0)
        ElseIf enemy.Name = "Tuyul" Then
            Return enemyList.GetValue(1)
        ElseIf enemy.Name = "Jalangkung" Then
            Return enemyList.GetValue(2)
        ElseIf enemy.Name = "KuntilAnak" Then
            Return enemyList.GetValue(3)
        ElseIf enemy.Name = "Dracula" Then
            Return enemyList.GetValue(4)
        ElseIf enemy.Name = "Jin" Then
            Return enemyList.GetValue(5)
        ElseIf enemy.Name = "Kuyang" Then
            Return enemyList.GetValue(6)
        ElseIf enemy.Name = "Ijo" Then
            Return enemyList.GetValue(7)
        End If
        Return Nothing
    End Function
    Private Function enemyCollideWithLastLineDefense(enemy As PictureBox) As Boolean
        If LastLineDefense1.Bounds.IntersectsWith(enemy.Bounds) AndAlso lastLineDefense(0) = True AndAlso enemyLane1.Contains(enemy) Then
            lastLineDefense(0) = False
            Dim movingOnLane As New Timer
            movingOnLane.Interval = 50
            AddHandler movingOnLane.Tick, Function(sender As Timer, e As EventArgs)
                                              LastLineDefense1.Left += 10
                                              If LastLineDefense1.Left >= Me.Width Then
                                                  sender.Stop()
                                                  sender.Dispose()
                                                  LastLineDefense1.Enabled = False
                                                  LastLineDefense1.Visible = False
                                                  Return Nothing
                                                  Exit Function
                                              End If
                                              For I As Integer = enemyLane1.Count - 1 To 0 Step -1
                                                  If enemyLane1(I).Bounds.IntersectsWith(LastLineDefense1.Bounds) Then
                                                      enemyKilled(enemyLane1(I))
                                                      Return Nothing
                                                      Exit Function
                                                  End If
                                              Next
                                              Return Nothing
                                          End Function
            movingOnLane.Start()
            Return True
        ElseIf LastLineDefense2.Bounds.IntersectsWith(enemy.Bounds) AndAlso lastLineDefense(1) = True AndAlso enemyLane2.Contains(enemy) Then
            lastLineDefense(1) = False
            Dim movingOnLane As New Timer
            movingOnLane.Interval = 50
            AddHandler movingOnLane.Tick, Function(sender As Timer, e As EventArgs)
                                              LastLineDefense2.Left += 10
                                              If LastLineDefense2.Left >= Me.Width Then
                                                  sender.Stop()
                                                  sender.Dispose()
                                                  LastLineDefense2.Enabled = False
                                                  LastLineDefense2.Visible = False
                                                  Return Nothing
                                                  Exit Function
                                              End If
                                              For I As Integer = enemyLane2.Count - 1 To 0 Step -1
                                                  If enemyLane2(I).Bounds.IntersectsWith(LastLineDefense2.Bounds) Then
                                                      enemyKilled(enemyLane2(I))
                                                      Return Nothing
                                                      Exit Function
                                                  End If
                                              Next
                                              Return Nothing
                                          End Function
            movingOnLane.Start()
            Return True
        ElseIf LastLineDefense3.Bounds.IntersectsWith(enemy.Bounds) AndAlso lastLineDefense(2) = True AndAlso enemyLane3.Contains(enemy) Then
            lastLineDefense(2) = False
            Dim movingOnLane As New Timer
            movingOnLane.Interval = 50
            AddHandler movingOnLane.Tick, Function(sender As Timer, e As EventArgs)
                                              LastLineDefense3.Left += 10
                                              If LastLineDefense3.Left >= Me.Width Then
                                                  sender.Stop()
                                                  sender.Dispose()
                                                  LastLineDefense3.Enabled = False
                                                  LastLineDefense3.Visible = False
                                                  Return Nothing
                                                  Exit Function
                                              End If
                                              For I As Integer = enemyLane3.Count - 1 To 0 Step -1
                                                  If enemyLane3(I).Bounds.IntersectsWith(LastLineDefense3.Bounds) Then
                                                      enemyKilled(enemyLane3(I))
                                                      Return Nothing
                                                      Exit Function
                                                  End If
                                              Next
                                              Return Nothing
                                          End Function
            movingOnLane.Start()
            Return True
        ElseIf LastLineDefense4.Bounds.IntersectsWith(enemy.Bounds) AndAlso lastLineDefense(3) = True AndAlso enemyLane4.Contains(enemy) Then
            lastLineDefense(3) = False
            Dim movingOnLane As New Timer
            movingOnLane.Interval = 50
            AddHandler movingOnLane.Tick, Function(sender As Timer, e As EventArgs)
                                              LastLineDefense4.Left += 10
                                              If LastLineDefense4.Left >= Me.Width Then
                                                  sender.Stop()
                                                  sender.Dispose()
                                                  LastLineDefense4.Enabled = False
                                                  LastLineDefense4.Visible = False
                                                  Return Nothing
                                                  Exit Function
                                              End If
                                              For I As Integer = enemyLane4.Count - 1 To 0 Step -1
                                                  If enemyLane4(I).Bounds.IntersectsWith(LastLineDefense4.Bounds) Then
                                                      enemyKilled(enemyLane4(I))
                                                      Return Nothing
                                                      Exit Function
                                                  End If
                                              Next
                                              Return Nothing
                                          End Function
            movingOnLane.Start()
            Return True
        ElseIf LastLineDefense5.Bounds.IntersectsWith(enemy.Bounds) AndAlso lastLineDefense(4) = True AndAlso enemyLane5.Contains(enemy) Then
            lastLineDefense(4) = False
            Dim movingOnLane As New Timer
            movingOnLane.Interval = 50
            AddHandler movingOnLane.Tick, Function(sender As Timer, e As EventArgs)
                                              LastLineDefense5.Left += 10
                                              If LastLineDefense5.Left >= Me.Width Then
                                                  sender.Stop()
                                                  sender.Dispose()
                                                  LastLineDefense5.Enabled = False
                                                  LastLineDefense5.Visible = False
                                                  Return Nothing
                                                  Exit Function
                                              End If
                                              For I As Integer = enemyLane5.Count - 1 To 0 Step -1
                                                  If enemyLane5(I).Bounds.IntersectsWith(LastLineDefense5.Bounds) Then
                                                      enemyKilled(enemyLane5(I))
                                                      Return Nothing
                                                      Exit Function
                                                  End If
                                              Next
                                              Return Nothing
                                          End Function
            movingOnLane.Start()
            Return True
        End If
        Return False
    End Function
    Private Function enemyCollideWithHero(Enemy As PictureBox, stepInPixel As Integer, damage As Integer) As Integer
        For I = 1 To heroPlacement.GetUpperBound(0)
            If enemyLane1.Contains(Enemy) Then
                If heroPlacement(I, 1).Bounds.IntersectsWith(Enemy.Bounds) AndAlso heroPlacement(I, 1).Image IsNot Nothing Then
                    heroHealth(I, 1) -= damage
                    If heroHealth(I, 1) <= 0 Then
                        If heroPlacement(I, 2).Image.Equals(EmongSprite) Then
                            heroSound(I, 2).Ctlcontrols.play()
                        End If
                        heroAttackTimer(I, 1).Stop()
                        heroAttackTimer(I, 1).Dispose()
                        heroAttackTimer(I, 1) = Nothing
                        heroSound(I, 1).URL = Nothing
                        heroPlacement(I, 1).Image = Nothing
                        heroHealth(I, 1) = Nothing
                    End If
                    Return 0
                End If
                Continue For
            ElseIf enemyLane2.Contains(Enemy) Then
                If heroPlacement(I, 2).Bounds.IntersectsWith(Enemy.Bounds) AndAlso heroPlacement(I, 2).Image IsNot Nothing Then
                    heroHealth(I, 2) -= damage
                    If heroHealth(I, 2) <= 0 Then
                        If heroPlacement(I, 2).Image.Equals(EmongSprite) Then
                            heroSound(I, 2).Ctlcontrols.play()
                        End If
                        heroAttackTimer(I, 2).Stop()
                        heroAttackTimer(I, 2).Dispose()
                        heroAttackTimer(I, 2) = Nothing
                        heroSound(I, 2).URL = Nothing
                        heroPlacement(I, 2).Image = Nothing
                        heroHealth(I, 2) = Nothing
                    End If
                    Return 0
                End If
                Continue For
            ElseIf enemyLane3.Contains(Enemy) Then
                If heroPlacement(I, 3).Bounds.IntersectsWith(Enemy.Bounds) AndAlso heroPlacement(I, 3).Image IsNot Nothing Then
                    If heroPlacement(I, 3).Image.Equals(EmongSprite) Then
                        heroSound(I, 3).Ctlcontrols.play()
                    End If
                    heroHealth(I, 3) -= damage
                    If heroHealth(I, 3) <= 0 Then
                        heroAttackTimer(I, 3).Stop()
                        heroAttackTimer(I, 3).Dispose()
                        heroAttackTimer(I, 3) = Nothing
                        heroSound(I, 3).URL = Nothing
                        heroPlacement(I, 3).Image = Nothing
                        heroHealth(I, 3) = Nothing
                    End If
                    Return 0
                    End If
                    Continue For
            ElseIf enemyLane4.Contains(Enemy) Then
                If heroPlacement(I, 4).Bounds.IntersectsWith(Enemy.Bounds) AndAlso heroPlacement(I, 4).Image IsNot Nothing Then
                    heroHealth(I, 4) -= damage
                    If heroHealth(I, 4) <= 0 Then
                        If heroPlacement(I, 4).Image.Equals(EmongSprite) Then
                            heroSound(I, 4).Ctlcontrols.play()
                        End If
                        heroAttackTimer(I, 4).Stop()
                        heroAttackTimer(I, 4).Dispose()
                        heroAttackTimer(I, 4) = Nothing
                        heroSound(I, 4).URL = Nothing
                        heroPlacement(I, 4).Image = Nothing
                        heroHealth(I, 4) = Nothing
                    End If
                    Return 0
                End If
                Continue For
            ElseIf enemyLane5.Contains(Enemy) Then
                If heroPlacement(I, 5).Bounds.IntersectsWith(Enemy.Bounds) AndAlso heroPlacement(I, 5).Image IsNot Nothing Then
                    heroHealth(I, 5) -= damage
                    If heroHealth(I, 5) <= 0 Then
                        If heroPlacement(I, 5).Image.Equals(EmongSprite) Then
                            heroSound(I, 5).Ctlcontrols.play()
                        End If
                        heroAttackTimer(I, 5).Stop()
                        heroAttackTimer(I, 5).Dispose()
                        heroAttackTimer(I, 5) = Nothing
                        heroSound(I, 5).URL = Nothing
                        heroPlacement(I, 5).Image = Nothing
                        heroHealth(I, 5) = Nothing
                    End If
                    Return 0
                End If
                Continue For
            End If
        Next
        Return stepInPixel
    End Function
    'When enemy is killed
    Private Sub enemyKilled(enemy As PictureBox)
        If enemyLane1.Contains(enemy) Then
            Dim index As Integer
            index = enemyLane1.IndexOf(enemy)
            Me.Controls.Remove(enemy)
            enemy.Dispose()
            enemyLane1.Remove(enemy)
            Lane1MovementTimer(index).Stop()
            Lane1MovementTimer(index).Dispose()
            Lane1MovementTimer.RemoveAt(index)
            Lane1Health.RemoveAt(index)
            If enemyLane1.Count = 0 Then
                enemyOnLane(0) = False
            End If
        ElseIf enemyLane2.Contains(enemy) Then
            Dim index As Integer
            index = enemyLane2.IndexOf(enemy)
            Me.Controls.Remove(enemy)
            enemy.Dispose()
            enemyLane2.Remove(enemy)
            Lane2MovementTimer(index).Stop()
            Lane2MovementTimer(index).Dispose()
            Lane2MovementTimer.RemoveAt(index)
            Lane2Health.RemoveAt(index)
            If enemyLane2.Count = 0 Then
                enemyOnLane(1) = False
            End If
        ElseIf enemyLane3.Contains(enemy) Then
            Dim index As Integer
            index = enemyLane3.IndexOf(enemy)
            Me.Controls.Remove(enemy)
            enemy.Dispose()
            enemyLane3.Remove(enemy)
            Lane3MovementTimer(index).Stop()
            Lane3MovementTimer(index).Dispose()
            Lane3MovementTimer.RemoveAt(index)
            Lane3Health.RemoveAt(index)
            If enemyLane3.Count = 0 Then
                enemyOnLane(2) = False
            End If
        ElseIf enemyLane4.Contains(enemy) Then
            Dim index As Integer
            index = enemyLane4.IndexOf(enemy)
            Me.Controls.Remove(enemy)
            enemy.Dispose()
            enemyLane4.Remove(enemy)
            Lane4MovementTimer(index).Stop()
            Lane4MovementTimer(index).Dispose()
            Lane4MovementTimer.RemoveAt(index)
            Lane4Health.RemoveAt(index)
            If enemyLane4.Count = 0 Then
                enemyOnLane(3) = False
            End If
        ElseIf enemyLane5.Contains(enemy) Then
            Dim index As Integer
            index = enemyLane5.IndexOf(enemy)
            Me.Controls.Remove(enemy)
            enemy.Dispose()
            enemyLane5.Remove(enemy)
            Lane5MovementTimer(index).Stop()
            Lane5MovementTimer(index).Dispose()
            Lane5MovementTimer.RemoveAt(index)
            Lane5Health.RemoveAt(index)
            If enemyLane5.Count = 0 Then
                enemyOnLane(4) = False
            End If
        End If
        If enemyOnLane(0) = False AndAlso enemyOnLane(1) = False AndAlso enemyOnLane(2) = False AndAlso enemyOnLane(3) = False AndAlso enemyOnLane(4) = False Then
            If enemyLeft <= 0 Then
                If lastWave = False Then
                    lastWave = True
                    FinalyWave()
                Else
                    GameOverScreen.BackgroundImage = My.Resources.menang
                    ResetsData()
                    GameOverScreen.ShowDialog()
                End If
            Else
                spawnNewEnemy = True
            End If
        End If
        enemyLeftForLabel -= 1
        EnemyLeftLabel.Text = enemyLeftForLabel.ToString() + " Left"
    End Sub
    Private Sub FinalyWave()
        Dim burstNumber As Integer = Math.Round((maxEnemyInWave + minEnemyInWave) / 2)
        enemyLeftForLabel += burstNumber
        enemyLeft += burstNumber
        For I As Integer = 1 To burstNumber
            SpawnEnemy()
        Next
    End Sub
    'to spawn enemy randomly and to check if level complete
    Private Sub enemySpawner_Tick(sender As Object, e As EventArgs) Handles enemySpawnTimer.Tick
        If enemyLeft <= 0 Then
            enemySpawnTimer.Stop()
            'Level complete
            Exit Sub
        End If
        enemyTimer += 1
        If movedToTimer = True AndAlso enemyTimer >= 13 Then
            enemyTimer = 0
            SpawnEnemy()
        ElseIf enemyTimer >= 20 Or (coinGenPlanted >= 3 AndAlso movedToTimer = False) Then
            movedToTimer = True
            enemyTimer = 0
            SpawnEnemy()
        ElseIf spawnNewEnemy = True Then
            spawnNewEnemy = False
            If enemyTimer >= 2 Then
                enemyTimer -= 2
            End If
            SpawnEnemy()
        End If
    End Sub
    'to reset everything on this form
    Public Sub ResetsData()
        coinGenPlanted = 0
        enemyLeft = 0
        enemyTimer = 0
        movedToTimer = False
        lastWave = False
        coinStored = 50
        updateCoin()
        enemySpawnTimer.Stop()
        RandomCoin.Stop()
        LastLineDefense1.Enabled = True
        LastLineDefense1.Visible = True
        LastLineDefense1.Left = Placement11.Left - 100
        LastLineDefense2.Enabled = True
        LastLineDefense2.Visible = True
        LastLineDefense2.Left = Placement21.Left - 100
        LastLineDefense3.Enabled = True
        LastLineDefense3.Visible = True
        LastLineDefense3.Left = Placement31.Left - 100
        LastLineDefense4.Enabled = True
        LastLineDefense4.Visible = True
        LastLineDefense4.Left = Placement41.Left - 100
        LastLineDefense5.Enabled = True
        LastLineDefense5.Visible = True
        LastLineDefense5.Left = Placement51.Left - 100
        For I = 1 To 9
            For J = 1 To 5
                heroPlacement(I, J).Image = Nothing
                heroHealth(I, J) = Nothing
                If heroAttackTimer(I, J) IsNot Nothing Then
                    heroAttackTimer(I, J).Stop()
                    heroAttackTimer(I, J).Dispose()
                    heroAttackTimer(I, J) = Nothing
                End If
            Next
        Next
        For I = 1 To 9
            For J = 1 To 5
                heroSound(I, J).URL = Nothing
                heroSound(I, J).Ctlcontrols.stop()
            Next
        Next
        For I = 0 To 4
            enemyOnLane(I) = False
        Next
        For I = 0 To lastLineDefense.Count - 1
            lastLineDefense(I) = True
        Next
        For I = enemyLane1.Count - 1 To 0 Step -1
            Lane1MovementTimer(I).Stop()
            Lane1MovementTimer(I).Dispose()
            Lane1MovementTimer.RemoveAt(I)
            Me.Controls.Remove(enemyLane1(I))
            enemyLane1.RemoveAt(I)
            Lane1Health.RemoveAt(I)
        Next
        For I = enemyLane2.Count - 1 To 0 Step -1
            Lane2MovementTimer(I).Stop()
            Lane2MovementTimer(I).Dispose()
            Lane2MovementTimer.RemoveAt(I)
            Me.Controls.Remove(enemyLane2(I))
            enemyLane2.RemoveAt(I)
            Lane2Health.RemoveAt(I)
        Next
        For I = enemyLane3.Count - 1 To 0 Step -1
            Lane3MovementTimer(I).Stop()
            Lane3MovementTimer(I).Dispose()
            Lane3MovementTimer.RemoveAt(I)
            Me.Controls.Remove(enemyLane3(I))
            enemyLane3.RemoveAt(I)
            Lane3Health.RemoveAt(I)
        Next
        For I = enemyLane4.Count - 1 To 0 Step -1
            Lane4MovementTimer(I).Stop()
            Lane4MovementTimer(I).Dispose()
            Lane4MovementTimer.RemoveAt(I)
            Me.Controls.Remove(enemyLane4(I))
            enemyLane4.RemoveAt(I)
            Lane4Health.RemoveAt(I)
        Next
        For I = enemyLane5.Count - 1 To 0 Step -1
            Lane5MovementTimer(I).Stop()
            Lane5MovementTimer(I).Dispose()
            Lane5MovementTimer.RemoveAt(I)
            Me.Controls.Remove(enemyLane5(I))
            enemyLane5.RemoveAt(I)
            Lane5Health.RemoveAt(I)
        Next
        For Each ctrl As Control In CoinJatuh
            ctrl.Dispose()
            Me.Controls.Remove(ctrl)
        Next
        BackgroundMusicPlayer.Ctlcontrols.stop()
    End Sub
    'start the wave, and let all of things work toghether
    Public Sub start_Wave()
        ResetsData()
        updateCoin()
        enemyLeft = Generator.Next(minEnemyInWave, maxEnemyInWave + 1)
        enemyLeftForLabel = enemyLeft
        EnemyLeftLabel.Text = enemyLeftForLabel.ToString() + " Left"
        RandomCoin.Start()
        enemySpawnTimer.Start()
        BackgroundMusicPlayer.Ctlcontrols.play()
    End Sub
    'if user force close the game
    Private Sub PlaygroundMap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If applicationClosing = False Then
            e.Cancel = True
            Me.Hide()
            mainMenu.Show()
            mainMenu.reseting()
        End If
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Credits
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Credits))
        Me.Scrolling = New System.Windows.Forms.Timer(Me.components)
        Me.BgPart3 = New System.Windows.Forms.PictureBox()
        Me.BgPart1 = New System.Windows.Forms.PictureBox()
        Me.BgPart2 = New System.Windows.Forms.PictureBox()
        Me.FontStored = New System.Windows.Forms.Label()
        Me.CreditBox = New System.Windows.Forms.Panel()
        CType(Me.BgPart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BgPart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BgPart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Scrolling
        '
        Me.Scrolling.Interval = 50
        '
        'BgPart3
        '
        Me.BgPart3.Image = Global.PV_FinalProjects.My.Resources.Resources.bgcredit_2
        Me.BgPart3.Location = New System.Drawing.Point(63, 401)
        Me.BgPart3.Name = "BgPart3"
        Me.BgPart3.Size = New System.Drawing.Size(676, 48)
        Me.BgPart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BgPart3.TabIndex = 3
        Me.BgPart3.TabStop = False
        '
        'BgPart1
        '
        Me.BgPart1.Image = Global.PV_FinalProjects.My.Resources.Resources.bgcredit_1
        Me.BgPart1.Location = New System.Drawing.Point(0, 0)
        Me.BgPart1.Name = "BgPart1"
        Me.BgPart1.Size = New System.Drawing.Size(802, 99)
        Me.BgPart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BgPart1.TabIndex = 2
        Me.BgPart1.TabStop = False
        '
        'BgPart2
        '
        Me.BgPart2.Image = Global.PV_FinalProjects.My.Resources.Resources.bgcredit_3
        Me.BgPart2.Location = New System.Drawing.Point(0, 91)
        Me.BgPart2.Name = "BgPart2"
        Me.BgPart2.Size = New System.Drawing.Size(802, 314)
        Me.BgPart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BgPart2.TabIndex = 0
        Me.BgPart2.TabStop = False
        '
        'FontStored
        '
        Me.FontStored.AutoSize = True
        Me.FontStored.Font = New System.Drawing.Font("Adobe Gothic Std B", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FontStored.Location = New System.Drawing.Point(12, 9)
        Me.FontStored.Name = "FontStored"
        Me.FontStored.Size = New System.Drawing.Size(0, 35)
        Me.FontStored.TabIndex = 0
        '
        'CreditBox
        '
        Me.CreditBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.CreditBox.Location = New System.Drawing.Point(291, 164)
        Me.CreditBox.Name = "CreditBox"
        Me.CreditBox.Size = New System.Drawing.Size(200, 100)
        Me.CreditBox.TabIndex = 0
        '
        'Credits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CreditBox)
        Me.Controls.Add(Me.FontStored)
        Me.Controls.Add(Me.BgPart3)
        Me.Controls.Add(Me.BgPart1)
        Me.Controls.Add(Me.BgPart2)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Credits"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Credits"
        CType(Me.BgPart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BgPart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BgPart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BgPart2 As PictureBox
    Friend WithEvents BgPart1 As PictureBox
    Friend WithEvents BgPart3 As PictureBox
    Friend WithEvents Scrolling As Timer
    Friend WithEvents FontStored As Label
    Friend WithEvents CreditBox As Panel
End Class

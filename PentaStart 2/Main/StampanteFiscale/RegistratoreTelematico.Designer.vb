<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegistratoreTelematico
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistratoreTelematico))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonLetGiornalera = New System.Windows.Forms.Button()
        Me.ButtonChiusura = New System.Windows.Forms.Button()
        Me.ButtonLetDGFE = New System.Windows.Forms.Button()
        Me.ButtonAnnullo = New System.Windows.Forms.Button()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.ButtonInvioAE = New System.Windows.Forms.Button()
        Me.LettMF = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonIndietro = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoEllipsis = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(786, 97)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Registratore Telematico"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonLetGiornalera
        '
        Me.ButtonLetGiornalera.BackColor = System.Drawing.Color.LightYellow
        Me.ButtonLetGiornalera.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonLetGiornalera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonLetGiornalera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonLetGiornalera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLetGiornalera.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.ButtonLetGiornalera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonLetGiornalera.Location = New System.Drawing.Point(41, 113)
        Me.ButtonLetGiornalera.Name = "ButtonLetGiornalera"
        Me.ButtonLetGiornalera.Size = New System.Drawing.Size(312, 69)
        Me.ButtonLetGiornalera.TabIndex = 14
        Me.ButtonLetGiornalera.TabStop = False
        Me.ButtonLetGiornalera.Text = "Lettura Giornalera"
        Me.ButtonLetGiornalera.UseVisualStyleBackColor = False
        '
        'ButtonChiusura
        '
        Me.ButtonChiusura.BackColor = System.Drawing.Color.Red
        Me.ButtonChiusura.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonChiusura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.ButtonChiusura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.ButtonChiusura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChiusura.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.ButtonChiusura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonChiusura.Location = New System.Drawing.Point(423, 113)
        Me.ButtonChiusura.Name = "ButtonChiusura"
        Me.ButtonChiusura.Size = New System.Drawing.Size(312, 69)
        Me.ButtonChiusura.TabIndex = 14
        Me.ButtonChiusura.TabStop = False
        Me.ButtonChiusura.Text = "Chiusura Fiscale"
        Me.ButtonChiusura.UseVisualStyleBackColor = False
        '
        'ButtonLetDGFE
        '
        Me.ButtonLetDGFE.BackColor = System.Drawing.Color.White
        Me.ButtonLetDGFE.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonLetDGFE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonLetDGFE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonLetDGFE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLetDGFE.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.ButtonLetDGFE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonLetDGFE.Location = New System.Drawing.Point(41, 289)
        Me.ButtonLetDGFE.Name = "ButtonLetDGFE"
        Me.ButtonLetDGFE.Size = New System.Drawing.Size(312, 69)
        Me.ButtonLetDGFE.TabIndex = 14
        Me.ButtonLetDGFE.TabStop = False
        Me.ButtonLetDGFE.Text = "Lettura DGFE"
        Me.ButtonLetDGFE.UseVisualStyleBackColor = False
        '
        'ButtonAnnullo
        '
        Me.ButtonAnnullo.BackColor = System.Drawing.Color.LightGray
        Me.ButtonAnnullo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonAnnullo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.ButtonAnnullo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.ButtonAnnullo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnullo.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.ButtonAnnullo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAnnullo.Location = New System.Drawing.Point(41, 201)
        Me.ButtonAnnullo.Name = "ButtonAnnullo"
        Me.ButtonAnnullo.Size = New System.Drawing.Size(312, 69)
        Me.ButtonAnnullo.TabIndex = 14
        Me.ButtonAnnullo.TabStop = False
        Me.ButtonAnnullo.Text = "Annullo Scontrino"
        Me.ButtonAnnullo.UseVisualStyleBackColor = False
        '
        'ButtonReset
        '
        Me.ButtonReset.BackColor = System.Drawing.Color.White
        Me.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReset.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.ButtonReset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonReset.Location = New System.Drawing.Point(423, 289)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(312, 69)
        Me.ButtonReset.TabIndex = 14
        Me.ButtonReset.TabStop = False
        Me.ButtonReset.Text = "Reset Misuratore"
        Me.ButtonReset.UseVisualStyleBackColor = False
        '
        'ButtonInvioAE
        '
        Me.ButtonInvioAE.BackColor = System.Drawing.Color.LightGreen
        Me.ButtonInvioAE.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonInvioAE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.ButtonInvioAE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray
        Me.ButtonInvioAE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInvioAE.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.ButtonInvioAE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonInvioAE.Location = New System.Drawing.Point(423, 201)
        Me.ButtonInvioAE.Name = "ButtonInvioAE"
        Me.ButtonInvioAE.Size = New System.Drawing.Size(312, 69)
        Me.ButtonInvioAE.TabIndex = 14
        Me.ButtonInvioAE.TabStop = False
        Me.ButtonInvioAE.Text = "Forzare Invio A.E"
        Me.ButtonInvioAE.UseVisualStyleBackColor = False
        '
        'LettMF
        '
        Me.LettMF.BackColor = System.Drawing.Color.White
        Me.LettMF.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.LettMF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.LettMF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.LettMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LettMF.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.LettMF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LettMF.Location = New System.Drawing.Point(41, 377)
        Me.LettMF.Name = "LettMF"
        Me.LettMF.Size = New System.Drawing.Size(312, 69)
        Me.LettMF.TabIndex = 14
        Me.LettMF.TabStop = False
        Me.LettMF.Text = "Lettura M.F."
        Me.LettMF.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 25.0!)
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(423, 377)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(312, 69)
        Me.Button2.TabIndex = 14
        Me.Button2.TabStop = False
        Me.Button2.Text = "Reset Scontrino"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ButtonIndietro
        '
        Me.ButtonIndietro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonIndietro.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonIndietro.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonIndietro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.ButtonIndietro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.ButtonIndietro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonIndietro.Font = New System.Drawing.Font("Century Gothic", 25.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonIndietro.ForeColor = System.Drawing.Color.Black
        Me.ButtonIndietro.Location = New System.Drawing.Point(272, 468)
        Me.ButtonIndietro.Name = "ButtonIndietro"
        Me.ButtonIndietro.Size = New System.Drawing.Size(246, 61)
        Me.ButtonIndietro.TabIndex = 18
        Me.ButtonIndietro.TabStop = False
        Me.ButtonIndietro.Text = "INDIETRO"
        Me.ButtonIndietro.UseVisualStyleBackColor = False
        '
        'RegistratoreTelematico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackgroundImage = Global.PentaStart.My.Resources.Resources.Bordes2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(790, 550)
        Me.Controls.Add(Me.ButtonIndietro)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.ButtonInvioAE)
        Me.Controls.Add(Me.LettMF)
        Me.Controls.Add(Me.ButtonAnnullo)
        Me.Controls.Add(Me.ButtonLetDGFE)
        Me.Controls.Add(Me.ButtonChiusura)
        Me.Controls.Add(Me.ButtonLetGiornalera)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RegistratoreTelematico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registratore Telematico"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonLetGiornalera As Button
    Friend WithEvents ButtonChiusura As Button
    Friend WithEvents ButtonLetDGFE As Button
    Friend WithEvents ButtonAnnullo As Button
    Friend WithEvents ButtonReset As Button
    Friend WithEvents ButtonInvioAE As Button
    Friend WithEvents LettMF As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ButtonIndietro As Button
End Class

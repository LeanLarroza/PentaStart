﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LetturaDGFE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LetturaDGFE))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.iscon = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.fscon = New System.Windows.Forms.TextBox()
        Me.ButtonIndietro = New System.Windows.Forms.Button()
        Me.ButtonConferma = New System.Windows.Forms.Button()
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
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Lettura DGFE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 28.0!)
        Me.Label1.Location = New System.Drawing.Point(38, 100)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 97)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Data Iniziale"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoEllipsis = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 28.0!)
        Me.Label2.Location = New System.Drawing.Point(38, 202)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 97)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Data Finale"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 35.0!)
        Me.TextBox1.Location = New System.Drawing.Point(286, 118)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(454, 60)
        Me.TextBox1.TabIndex = 16
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 35.0!)
        Me.TextBox2.Location = New System.Drawing.Point(286, 220)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(454, 60)
        Me.TextBox2.TabIndex = 16
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoEllipsis = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 28.0!)
        Me.Label4.Location = New System.Drawing.Point(38, 313)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(245, 97)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Da scontrino"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'iscon
        '
        Me.iscon.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 35.0!)
        Me.iscon.Location = New System.Drawing.Point(286, 331)
        Me.iscon.Name = "iscon"
        Me.iscon.Size = New System.Drawing.Size(81, 60)
        Me.iscon.TabIndex = 16
        Me.iscon.Text = "0"
        Me.iscon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoEllipsis = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 28.0!)
        Me.Label5.Location = New System.Drawing.Point(411, 313)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(245, 97)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "A scontrino"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fscon
        '
        Me.fscon.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 35.0!)
        Me.fscon.Location = New System.Drawing.Point(659, 331)
        Me.fscon.Name = "fscon"
        Me.fscon.Size = New System.Drawing.Size(81, 60)
        Me.fscon.TabIndex = 16
        Me.fscon.Text = "0"
        Me.fscon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonIndietro
        '
        Me.ButtonIndietro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonIndietro.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonIndietro.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonIndietro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.ButtonIndietro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.ButtonIndietro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonIndietro.Font = New System.Drawing.Font("Century Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonIndietro.ForeColor = System.Drawing.Color.Black
        Me.ButtonIndietro.Location = New System.Drawing.Point(46, 463)
        Me.ButtonIndietro.Name = "ButtonIndietro"
        Me.ButtonIndietro.Size = New System.Drawing.Size(259, 52)
        Me.ButtonIndietro.TabIndex = 17
        Me.ButtonIndietro.TabStop = False
        Me.ButtonIndietro.Text = "INDIETRO"
        Me.ButtonIndietro.UseVisualStyleBackColor = False
        '
        'ButtonConferma
        '
        Me.ButtonConferma.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonConferma.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonConferma.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonConferma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonConferma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonConferma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConferma.Font = New System.Drawing.Font("Century Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonConferma.ForeColor = System.Drawing.Color.Black
        Me.ButtonConferma.Location = New System.Drawing.Point(490, 463)
        Me.ButtonConferma.Name = "ButtonConferma"
        Me.ButtonConferma.Size = New System.Drawing.Size(259, 52)
        Me.ButtonConferma.TabIndex = 18
        Me.ButtonConferma.TabStop = False
        Me.ButtonConferma.Text = "CONFERMA"
        Me.ButtonConferma.UseVisualStyleBackColor = False
        '
        'LetturaDGFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.PentaStart.My.Resources.Resources.Bordes2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(790, 550)
        Me.Controls.Add(Me.ButtonIndietro)
        Me.Controls.Add(Me.ButtonConferma)
        Me.Controls.Add(Me.fscon)
        Me.Controls.Add(Me.iscon)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LetturaDGFE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "lettdgfe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents iscon As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents fscon As TextBox
    Friend WithEvents ButtonIndietro As Button
    Friend WithEvents ButtonConferma As Button
End Class

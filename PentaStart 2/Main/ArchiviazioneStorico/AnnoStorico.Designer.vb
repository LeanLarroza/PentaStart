<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnoStorico
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnnoStorico))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonSI = New System.Windows.Forms.Button()
        Me.ButtonNO = New System.Windows.Forms.Button()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.anno = New System.Windows.Forms.Label()
        Me.indietro = New System.Windows.Forms.Label()
        Me.avanti = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoEllipsis = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 19.2!)
        Me.Label2.Location = New System.Drawing.Point(50, 122)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(392, 77)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "SCEGLIERE ANNO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ARCHIVIO STORICO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonSI
        '
        Me.ButtonSI.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonSI.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSI.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonSI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSI.Font = New System.Drawing.Font("Century Gothic", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSI.ForeColor = System.Drawing.Color.Black
        Me.ButtonSI.Location = New System.Drawing.Point(38, 331)
        Me.ButtonSI.Name = "ButtonSI"
        Me.ButtonSI.Size = New System.Drawing.Size(168, 89)
        Me.ButtonSI.TabIndex = 21
        Me.ButtonSI.TabStop = False
        Me.ButtonSI.Text = "OK"
        Me.ButtonSI.UseVisualStyleBackColor = False
        '
        'ButtonNO
        '
        Me.ButtonNO.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonNO.BackColor = System.Drawing.Color.Silver
        Me.ButtonNO.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonNO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.ButtonNO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.ButtonNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonNO.Font = New System.Drawing.Font("Century Gothic", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNO.ForeColor = System.Drawing.Color.Black
        Me.ButtonNO.Location = New System.Drawing.Point(286, 331)
        Me.ButtonNO.Name = "ButtonNO"
        Me.ButtonNO.Size = New System.Drawing.Size(168, 89)
        Me.ButtonNO.TabIndex = 22
        Me.ButtonNO.TabStop = False
        Me.ButtonNO.Text = "NO"
        Me.ButtonNO.UseVisualStyleBackColor = False
        '
        'Panel
        '
        Me.Panel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Location = New System.Drawing.Point(1, 2)
        Me.Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(490, 117)
        Me.Panel.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoEllipsis = True
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 117)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ATTENZIONE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'anno
        '
        Me.anno.AutoSize = True
        Me.anno.Font = New System.Drawing.Font("Lucida Sans", 28.2!)
        Me.anno.Location = New System.Drawing.Point(188, 231)
        Me.anno.Name = "anno"
        Me.anno.Size = New System.Drawing.Size(115, 43)
        Me.anno.TabIndex = 24
        Me.anno.Text = "2019"
        '
        'indietro
        '
        Me.indietro.AutoSize = True
        Me.indietro.Font = New System.Drawing.Font("Lucida Sans", 28.2!)
        Me.indietro.Location = New System.Drawing.Point(67, 231)
        Me.indietro.Name = "indietro"
        Me.indietro.Size = New System.Drawing.Size(67, 43)
        Me.indietro.TabIndex = 24
        Me.indietro.Text = "<<"
        '
        'avanti
        '
        Me.avanti.AutoSize = True
        Me.avanti.Font = New System.Drawing.Font("Lucida Sans", 28.2!)
        Me.avanti.Location = New System.Drawing.Point(347, 231)
        Me.avanti.Name = "avanti"
        Me.avanti.Size = New System.Drawing.Size(67, 43)
        Me.avanti.TabIndex = 24
        Me.avanti.Text = ">>"
        '
        'AnnoStorico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(490, 455)
        Me.Controls.Add(Me.avanti)
        Me.Controls.Add(Me.indietro)
        Me.Controls.Add(Me.anno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonSI)
        Me.Controls.Add(Me.ButtonNO)
        Me.Controls.Add(Me.Panel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AnnoStorico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AnnoStorico"
        Me.Panel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonSI As Button
    Friend WithEvents ButtonNO As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents anno As Label
    Friend WithEvents indietro As Label
    Friend WithEvents avanti As Label
End Class

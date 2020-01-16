<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Errore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Errore))
        Me.lbErrore = New System.Windows.Forms.Label()
        Me.ButtonNO = New System.Windows.Forms.Button()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbErrore
        '
        Me.lbErrore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lbErrore.AutoEllipsis = True
        Me.lbErrore.BackColor = System.Drawing.Color.White
        Me.lbErrore.Font = New System.Drawing.Font("Lucida Sans", 19.2!)
        Me.lbErrore.Location = New System.Drawing.Point(10, 122)
        Me.lbErrore.Margin = New System.Windows.Forms.Padding(0)
        Me.lbErrore.Name = "lbErrore"
        Me.lbErrore.Size = New System.Drawing.Size(471, 188)
        Me.lbErrore.TabIndex = 23
        Me.lbErrore.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbErrore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.ButtonNO.Location = New System.Drawing.Point(156, 313)
        Me.ButtonNO.Name = "ButtonNO"
        Me.ButtonNO.Size = New System.Drawing.Size(168, 89)
        Me.ButtonNO.TabIndex = 22
        Me.ButtonNO.TabStop = False
        Me.ButtonNO.Text = "OK"
        Me.ButtonNO.UseVisualStyleBackColor = False
        '
        'Panel
        '
        Me.Panel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Location = New System.Drawing.Point(2, 2)
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
        Me.Label1.Location = New System.Drawing.Point(-5, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 117)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ERRORE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Errore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(490, 455)
        Me.Controls.Add(Me.lbErrore)
        Me.Controls.Add(Me.ButtonNO)
        Me.Controls.Add(Me.Panel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Errore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PentaStart"
        Me.TopMost = True
        Me.Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbErrore As Label
    Friend WithEvents ButtonNO As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents Label1 As Label
End Class

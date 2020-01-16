<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Attenzione
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Attenzione))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Buttonexito = New System.Windows.Forms.Button()
        Me.lbMessagio = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(490, 117)
        Me.Panel.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoEllipsis = True
        Me.Label3.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(490, 117)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "ATTENZIONE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Buttonexito
        '
        Me.Buttonexito.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Buttonexito.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Buttonexito.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Buttonexito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Buttonexito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Buttonexito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonexito.Font = New System.Drawing.Font("Century Gothic", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonexito.ForeColor = System.Drawing.Color.Black
        Me.Buttonexito.Location = New System.Drawing.Point(161, 328)
        Me.Buttonexito.Name = "Buttonexito"
        Me.Buttonexito.Size = New System.Drawing.Size(168, 89)
        Me.Buttonexito.TabIndex = 7
        Me.Buttonexito.TabStop = False
        Me.Buttonexito.Text = "OK"
        Me.Buttonexito.UseVisualStyleBackColor = False
        '
        'lbMessagio
        '
        Me.lbMessagio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lbMessagio.AutoEllipsis = True
        Me.lbMessagio.Font = New System.Drawing.Font("Lucida Sans", 19.2!)
        Me.lbMessagio.Location = New System.Drawing.Point(13, 132)
        Me.lbMessagio.Margin = New System.Windows.Forms.Padding(0)
        Me.lbMessagio.Name = "lbMessagio"
        Me.lbMessagio.Size = New System.Drawing.Size(455, 171)
        Me.lbMessagio.TabIndex = 8
        Me.lbMessagio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Attenzione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.PentaStart.My.Resources.Resources.Bordes2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(490, 455)
        Me.Controls.Add(Me.lbMessagio)
        Me.Controls.Add(Me.Buttonexito)
        Me.Controls.Add(Me.Panel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(490, 455)
        Me.MinimumSize = New System.Drawing.Size(490, 455)
        Me.Name = "Attenzione"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PentaStart"
        Me.Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As Panel
    Friend WithEvents Buttonexito As Button
    Friend WithEvents lbMessagio As Label
    Friend WithEvents Label3 As Label
End Class

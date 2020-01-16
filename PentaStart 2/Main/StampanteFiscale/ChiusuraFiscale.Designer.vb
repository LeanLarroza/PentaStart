<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChiusuraFiscale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChiusuraFiscale))
        Me.ButtonSI = New System.Windows.Forms.Button()
        Me.ButtonNO = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.ButtonSI.Location = New System.Drawing.Point(37, 326)
        Me.ButtonSI.Name = "ButtonSI"
        Me.ButtonSI.Size = New System.Drawing.Size(168, 89)
        Me.ButtonSI.TabIndex = 17
        Me.ButtonSI.TabStop = False
        Me.ButtonSI.Text = "SI"
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
        Me.ButtonNO.Location = New System.Drawing.Point(285, 326)
        Me.ButtonNO.Name = "ButtonNO"
        Me.ButtonNO.Size = New System.Drawing.Size(168, 89)
        Me.ButtonNO.TabIndex = 18
        Me.ButtonNO.TabStop = False
        Me.ButtonNO.Text = "NO"
        Me.ButtonNO.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoEllipsis = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 19.2!)
        Me.Label2.Location = New System.Drawing.Point(49, 117)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(392, 174)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "SEI SICURO DI ESEGUIRE LA CHIUSURA FISCALE?"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, -3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 117)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "ATTENZIONE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chiusura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.PentaStart.My.Resources.Resources.Bordes2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(490, 455)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonSI)
        Me.Controls.Add(Me.ButtonNO)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "chiusura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chiusura fiscale"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonSI As Button
    Friend WithEvents ButtonNO As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class

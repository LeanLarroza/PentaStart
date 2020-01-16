<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImgSpegni = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonTele = New System.Windows.Forms.Button()
        Me.Button3logis = New System.Windows.Forms.Button()
        Me.Utility = New System.Windows.Forms.Button()
        Me.Label = New System.Windows.Forms.Label()
        Me.ButtonChiusura = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Buttonnas = New System.Windows.Forms.Button()
        Me.Buttonbak = New System.Windows.Forms.Button()
        Me.Buttonfattelett = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chiudi = New System.Windows.Forms.Button()
        CType(Me.ImgSpegni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImgSpegni
        '
        Me.ImgSpegni.BackColor = System.Drawing.Color.Transparent
        Me.ImgSpegni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ImgSpegni.Image = CType(resources.GetObject("ImgSpegni.Image"), System.Drawing.Image)
        Me.ImgSpegni.InitialImage = Nothing
        Me.ImgSpegni.Location = New System.Drawing.Point(333, 367)
        Me.ImgSpegni.Name = "ImgSpegni"
        Me.ImgSpegni.Size = New System.Drawing.Size(125, 123)
        Me.ImgSpegni.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgSpegni.TabIndex = 0
        Me.ImgSpegni.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(766, 198)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ButtonTele
        '
        Me.ButtonTele.BackColor = System.Drawing.Color.White
        Me.ButtonTele.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonTele.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonTele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonTele.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTele.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTele.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ButtonTele.Location = New System.Drawing.Point(40, 345)
        Me.ButtonTele.Name = "ButtonTele"
        Me.ButtonTele.Size = New System.Drawing.Size(218, 145)
        Me.ButtonTele.TabIndex = 6
        Me.ButtonTele.TabStop = False
        Me.ButtonTele.Text = "Teleassistenza"
        Me.ButtonTele.UseVisualStyleBackColor = False
        '
        'Button3logis
        '
        Me.Button3logis.BackColor = System.Drawing.Color.White
        Me.Button3logis.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange
        Me.Button3logis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Button3logis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button3logis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3logis.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3logis.ForeColor = System.Drawing.Color.DarkOrange
        Me.Button3logis.Location = New System.Drawing.Point(533, 345)
        Me.Button3logis.Name = "Button3logis"
        Me.Button3logis.Size = New System.Drawing.Size(218, 145)
        Me.Button3logis.TabIndex = 7
        Me.Button3logis.TabStop = False
        Me.Button3logis.Text = "Avvia 3logis"
        Me.Button3logis.UseVisualStyleBackColor = False
        '
        'Utility
        '
        Me.Utility.BackColor = System.Drawing.Color.White
        Me.Utility.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Utility.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Utility.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Utility.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Utility.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Utility.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Utility.Location = New System.Drawing.Point(40, 233)
        Me.Utility.Name = "Utility"
        Me.Utility.Size = New System.Drawing.Size(158, 40)
        Me.Utility.TabIndex = 8
        Me.Utility.TabStop = False
        Me.Utility.Text = "Utility"
        Me.Utility.UseVisualStyleBackColor = False
        '
        'Label
        '
        Me.Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label.AutoEllipsis = True
        Me.Label.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.Location = New System.Drawing.Point(175, 499)
        Me.Label.Margin = New System.Windows.Forms.Padding(0)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(440, 42)
        Me.Label.TabIndex = 15
        Me.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonChiusura
        '
        Me.ButtonChiusura.BackColor = System.Drawing.Color.White
        Me.ButtonChiusura.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.ButtonChiusura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ButtonChiusura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ButtonChiusura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChiusura.Font = New System.Drawing.Font("Century Gothic", 17.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonChiusura.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ButtonChiusura.Location = New System.Drawing.Point(227, 233)
        Me.ButtonChiusura.Name = "ButtonChiusura"
        Me.ButtonChiusura.Size = New System.Drawing.Size(332, 40)
        Me.ButtonChiusura.TabIndex = 16
        Me.ButtonChiusura.TabStop = False
        Me.ButtonChiusura.Text = "Reg. Telematico"
        Me.ButtonChiusura.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(305, 332)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 35)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Spegni il sistema"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Buttonnas
        '
        Me.Buttonnas.BackColor = System.Drawing.Color.White
        Me.Buttonnas.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Buttonnas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Buttonnas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Buttonnas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonnas.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonnas.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Buttonnas.Location = New System.Drawing.Point(588, 233)
        Me.Buttonnas.Name = "Buttonnas"
        Me.Buttonnas.Size = New System.Drawing.Size(162, 40)
        Me.Buttonnas.TabIndex = 8
        Me.Buttonnas.TabStop = False
        Me.Buttonnas.Text = "SMS"
        Me.Buttonnas.UseVisualStyleBackColor = False
        '
        'Buttonbak
        '
        Me.Buttonbak.BackColor = System.Drawing.Color.White
        Me.Buttonbak.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Buttonbak.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Buttonbak.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Buttonbak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonbak.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonbak.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Buttonbak.Location = New System.Drawing.Point(40, 287)
        Me.Buttonbak.Name = "Buttonbak"
        Me.Buttonbak.Size = New System.Drawing.Size(158, 40)
        Me.Buttonbak.TabIndex = 8
        Me.Buttonbak.TabStop = False
        Me.Buttonbak.Text = "Backup"
        Me.Buttonbak.UseVisualStyleBackColor = False
        '
        'Buttonfattelett
        '
        Me.Buttonfattelett.BackColor = System.Drawing.Color.White
        Me.Buttonfattelett.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Buttonfattelett.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Buttonfattelett.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Buttonfattelett.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonfattelett.Font = New System.Drawing.Font("Century Gothic", 17.0!, System.Drawing.FontStyle.Bold)
        Me.Buttonfattelett.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Buttonfattelett.Location = New System.Drawing.Point(227, 287)
        Me.Buttonfattelett.Name = "Buttonfattelett"
        Me.Buttonfattelett.Size = New System.Drawing.Size(332, 40)
        Me.Buttonfattelett.TabIndex = 16
        Me.Buttonfattelett.TabStop = False
        Me.Buttonfattelett.Text = "Fatt. Elettronica"
        Me.Buttonfattelett.UseVisualStyleBackColor = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoEllipsis = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(175, 499)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(440, 42)
        Me.Label2.TabIndex = 15
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.Visible = False
        '
        'Chiudi
        '
        Me.Chiudi.BackColor = System.Drawing.Color.White
        Me.Chiudi.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Chiudi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Chiudi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Chiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Chiudi.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chiudi.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Chiudi.Location = New System.Drawing.Point(588, 287)
        Me.Chiudi.Name = "Chiudi"
        Me.Chiudi.Size = New System.Drawing.Size(162, 40)
        Me.Chiudi.TabIndex = 8
        Me.Chiudi.TabStop = False
        Me.Chiudi.Text = "Chiudi"
        Me.Chiudi.UseVisualStyleBackColor = False
        '
        'FormMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(790, 550)
        Me.Controls.Add(Me.Buttonfattelett)
        Me.Controls.Add(Me.ButtonChiusura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.Buttonbak)
        Me.Controls.Add(Me.Utility)
        Me.Controls.Add(Me.Chiudi)
        Me.Controls.Add(Me.Buttonnas)
        Me.Controls.Add(Me.Button3logis)
        Me.Controls.Add(Me.ButtonTele)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ImgSpegni)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PentaStart"
        CType(Me.ImgSpegni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ImgSpegni As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonTele As Button
    Friend WithEvents Button3logis As Button
    Friend WithEvents Utility As Button
    Friend WithEvents Label As Label
    Friend WithEvents ButtonChiusura As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Buttonnas As Button
    Friend WithEvents Buttonbak As Button
    Friend WithEvents Buttonfattelett As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Label2 As Label
    Friend WithEvents Chiudi As Button
End Class

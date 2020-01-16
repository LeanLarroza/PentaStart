<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitaArchiviazioneStorico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnitaArchiviazioneStorico))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tipo0 = New System.Windows.Forms.CheckBox()
        Me.tipo2 = New System.Windows.Forms.CheckBox()
        Me.tipo1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(151, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(201, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.Label1.Location = New System.Drawing.Point(22, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Unita Archiviazione"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tipo0)
        Me.GroupBox1.Controls.Add(Me.tipo2)
        Me.GroupBox1.Controls.Add(Me.tipo1)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 102)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo di Archiviazione"
        '
        'tipo0
        '
        Me.tipo0.AutoSize = True
        Me.tipo0.Location = New System.Drawing.Point(18, 22)
        Me.tipo0.Name = "tipo0"
        Me.tipo0.Size = New System.Drawing.Size(154, 17)
        Me.tipo0.TabIndex = 0
        Me.tipo0.Text = "Tipo 0 - Non archiviare dati"
        Me.tipo0.UseVisualStyleBackColor = True
        '
        'tipo2
        '
        Me.tipo2.AutoSize = True
        Me.tipo2.Location = New System.Drawing.Point(18, 68)
        Me.tipo2.Name = "tipo2"
        Me.tipo2.Size = New System.Drawing.Size(127, 17)
        Me.tipo2.TabIndex = 0
        Me.tipo2.Text = "Tipo 2 - Spostare dati"
        Me.tipo2.UseVisualStyleBackColor = True
        '
        'tipo1
        '
        Me.tipo1.AutoSize = True
        Me.tipo1.Location = New System.Drawing.Point(18, 45)
        Me.tipo1.Name = "tipo1"
        Me.tipo1.Size = New System.Drawing.Size(135, 17)
        Me.tipo1.TabIndex = 0
        Me.tipo1.Text = "Tipo 1 - Cancellare dati"
        Me.tipo1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(249, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Conferma"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(249, 91)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Indietro"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UnitaArchiviazione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 162)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UnitaArchiviazione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unita di Archiviazione"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tipo0 As CheckBox
    Friend WithEvents tipo2 As CheckBox
    Friend WithEvents tipo1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class

Imports System.IO

Public Class UnitaArchiviazioneStorico

    Public UnitaArchiviazione As String
    Public TipoArchiviazione As String
    Private Sub UnitaArchiviazione_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ini As New IniFile
        ini.Load(Application.StartupPath & "/PentaStart.ini")
        TipoArchiviazione = ini.GetKeyValue("DB", "TipoArchiviazione")
        UnitaArchiviazione = ini.GetKeyValue("DB", "UnitaArchiviazione")

        ComboBox1.Items.Add("null")
        Try
            Dim drives As List(Of DriveInfo) = DriveInfo.GetDrives().ToList()
            For Each drive As DriveInfo In drives
                Try
                    ComboBox1.Items.Add(drive.VolumeLabel)
                Catch ex As Exception
                    Continue For
                End Try
            Next
        Catch ex As Exception

        End Try


        Select Case TipoArchiviazione
            Case "0"
                tipo0.Checked = True
                tipo1.Checked = False
                tipo2.Checked = False
            Case "1"
                tipo0.Checked = False
                tipo1.Checked = True
                tipo2.Checked = False
            Case "2"
                tipo0.Checked = False
                tipo1.Checked = False
                tipo2.Checked = True
            Case Else
                tipo0.Checked = True
                tipo1.Checked = False
                tipo2.Checked = False
        End Select

        ComboBox1.SelectedItem = UnitaArchiviazione

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If tipo0.Checked Then
            TipoArchiviazione = "0"
        ElseIf tipo1.Checked Then
            TipoArchiviazione = "1"
        ElseIf tipo2.Checked Then
            TipoArchiviazione = "2"
        Else
            tipo0.Checked = True
            TipoArchiviazione = "0"
        End If

        UnitaArchiviazione = ComboBox1.SelectedItem

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Tipo0_CheckedChanged(sender As Object, e As EventArgs) Handles tipo0.CheckedChanged
        If tipo0.Checked Then
            tipo1.Checked = False
            tipo2.Checked = False
        End If
    End Sub

    Private Sub Tipo1_CheckedChanged(sender As Object, e As EventArgs) Handles tipo1.CheckedChanged
        If tipo1.Checked Then
            tipo0.Checked = False
            tipo2.Checked = False
        End If
    End Sub

    Private Sub Tipo2_CheckedChanged(sender As Object, e As EventArgs) Handles tipo2.CheckedChanged
        If tipo2.Checked Then
            tipo1.Checked = False
            tipo0.Checked = False
        End If
    End Sub
End Class
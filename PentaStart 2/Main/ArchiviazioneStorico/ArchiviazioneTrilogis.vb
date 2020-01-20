Imports System.IO

Public Class ArchiviazioneTrilogis
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        Dim existe As Boolean = False
        For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
            Try
                If driveInfo.VolumeLabel = Variables.UnitaArchiviazione.Value Then
                    existe = True
                End If
            Catch ex As Exception
                Continue For
            End Try

        Next
        If existe Then
            Me.Hide()
            Dim localByName2 As Process() = Process.GetProcessesByName("ScontrinoPenta")
            For Each p As Process In localByName2
                p.Kill()
            Next p
            Dim localByName As Process() = Process.GetProcessesByName("FattElett")
            For Each p As Process In localByName
                p.Kill()
            Next p
            Process.Start(Application.StartupPath & "/ArchiviazioneTrilogis.exe").WaitForExit()
            Me.Dispose()
        Else
            Dim FormErrore As New Errore
            FormErrore.Messagio = "PENDRIVE NON TROVATO"
            FormErrore.ShowDialog()
            Me.Dispose()
        End If


    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Return
    End Sub

    Private Sub ArchiviazioneTrilogis_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
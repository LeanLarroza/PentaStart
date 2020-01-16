﻿Imports PentaStart.Utility
Public Class SpegniPC
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        If Variables.TipoArchiviazione.Value = 1 And Variables.Software.Value = "trilogis" Then
            Dim Inizio As Date = Now
            LogFile.WriteLog("Avvio ArchiviazioneTrilogis in corso...")
            Process.Start(Application.StartupPath + "\ArchiviazioneTrilogis.exe").WaitForExit()
            LogFile.WriteLog("Fine ArchiviazioneTrilogis (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
        End If
        LogFile.WriteLog("Chiusura PC in corso...")
        LogFile.ChisuraProgramma()
        System.Diagnostics.Process.Start("shutdown", "-s -t 00")
        Application.Exit()
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Hide()
        FormMain.Show()
    End Sub

End Class
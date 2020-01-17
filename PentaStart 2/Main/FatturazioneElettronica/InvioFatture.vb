Imports System.IO
Imports System.Reflection
Imports PentaStart.Variables
Imports PentaStart.Utility

Public Class InvioFatture
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        Me.Hide()
        If Variables.VersioneSYNC.Value <> AssemblyName.GetAssemblyName(Variables.PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe").Version.ToString() Or Not File.Exists(Variables.PercorsoMacroMiniMouse.Value + "\1.mmmacro") Then
            Try
                CreaMacroSYNC()
            Catch ex As Exception
                MostraErrore(Me, "Errore nel aggiornamento del automatismo SYNC.", ex)
                Me.Hide()
            End Try
            ModificaKey(VersioneSYNC, AssemblyName.GetAssemblyName(Variables.PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe").Version.ToString())
        End If
        Try
            AvvioInvioFattureSync()
        Catch ex As Exception
            MostraErrore(Me, "Errore Invio SYNC", ex)
            Me.Close()
        End Try
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Hide()
        Me.Close()
    End Sub
End Class
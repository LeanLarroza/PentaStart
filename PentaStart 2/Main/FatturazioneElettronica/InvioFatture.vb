Imports System.IO
Imports System.Reflection
Imports PentaStart.Variables
Imports PentaStart.Utility

Public Class InvioFatture
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        Me.Hide()
        'MessageBox.Show(AssemblyName.GetAssemblyName("C:\Sync\FatturazioneElettronica\BrainTeamFatturaElettronica.exe").Version.ToString())
        If Variables.VersioneSYNC.Value <> AssemblyName.GetAssemblyName(Variables.PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe").Version.ToString() Or Not File.Exists(Variables.PercorsoMacroMiniMouse.Value + "\1.mmmacro") Then
            Try
                CreaMacroSYNC()
            Catch ex As Exception
                MessageBox.Show("Errore nel aggiornamento del automatismo SYNC." + Environment.NewLine + ex.ToString(), "PentaStart")
            End Try
            Variables.VersioneSYNC.Value = AssemblyName.GetAssemblyName(Variables.PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe").Version.ToString()
            Dim iniexist As String = Application.StartupPath + "\PentaStart.ini"
            Dim ini As New IniFile
            If System.IO.File.Exists(iniexist) Then
                ini.Load(Application.StartupPath + "\PentaStart.ini")
                ini.SetKeyValue("FATTEL", "VersioneSYNC", Variables.VersioneSYNC.Value)
                ini.Save(Application.StartupPath + "\PentaStart.ini")
            Else
                MsgBox("Errore agg. PentaStart.ini", MsgBoxStyle.OkOnly, "PentaStart")
            End If
        End If
        Try
            AvvioInvioFattureSync()
        Catch ex As Exception
            MessageBox.Show("SYNC non trovato.", "PentaStart")
            MessageBox.Show(ex.ToString(), "PentaStart")
        End Try
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Hide()
    End Sub
End Class
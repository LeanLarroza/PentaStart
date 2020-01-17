Imports System.IO
Imports System.Reflection
Imports PentaStart.Variables
Imports PentaStart.Utility
Public Class CoordinateSYNC

    Public PercorsoMacro As String
    Public PercorsoSync As String

    Private Sub PulBPOS_Click(sender As Object, e As EventArgs) Handles pulBPOS.Click
        tbCoorXChiusura1.Text = "1000"
        tbCoorYChiusura1.Text = "0"
        tbCoorXChiusura2.Text = "450"
        tbCoorYChiusura2.Text = "550"
        tbCoorXChiusura3.Text = "150"
        tbCoorYChiusura3.Text = "550"
        tbCoorXCInvio.Text = "500"
        tbCoorYCInvio.Text = "460"
        tbCoorXErrori.Text = "700"
        tbCoorYErrori.Text = "50"
        tbCoorXFatt.Text = "530"
        tbCoorYFatt.Text = "200"
        tbCoorXInvio.Text = "700"
        tbCoorYInvio.Text = "110"
    End Sub

    Private Sub PulFEC_Click(sender As Object, e As EventArgs) Handles pulFEC.Click
        tbCoorXChiusura1.Text = "1900"
        tbCoorYChiusura1.Text = "3"
        tbCoorXChiusura2.Text = "1000"
        tbCoorYChiusura2.Text = "700"
        tbCoorXChiusura3.Text = "820"
        tbCoorYChiusura3.Text = "660"
        tbCoorXCInvio.Text = "1115"
        tbCoorYCInvio.Text = "610"
        tbCoorXErrori.Text = "1160"
        tbCoorYErrori.Text = "200"
        tbCoorXFatt.Text = "1000"
        tbCoorYFatt.Text = "355"
        tbCoorXInvio.Text = "700"
        tbCoorYInvio.Text = "100"
    End Sub

    Private Sub PulEmpty_Click(sender As Object, e As EventArgs) Handles pulEmpty.Click
        tbCoorXChiusura1.Text = "0"
        tbCoorYChiusura1.Text = "0"
        tbCoorXChiusura2.Text = "0"
        tbCoorYChiusura2.Text = "0"
        tbCoorXChiusura3.Text = "0"
        tbCoorYChiusura3.Text = "0"
        tbCoorXCInvio.Text = "0"
        tbCoorYCInvio.Text = "0"
        tbCoorXErrori.Text = "0"
        tbCoorYErrori.Text = "0"
        tbCoorXFatt.Text = "0"
        tbCoorYFatt.Text = "0"
        tbCoorXInvio.Text = "0"
        tbCoorYInvio.Text = "0"
    End Sub

    Private Sub PulAnnullo_Click(sender As Object, e As EventArgs) Handles pulAnnullo.Click
        MostraErrore(Me, "Impostazione Invio SYNC annullata")
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub PulConferma_Click(sender As Object, e As EventArgs) Handles pulConferma.Click
        Dim iniexist As String = Application.StartupPath + "\PentaStart.ini"
        Dim ini As New IniFile
        CreaMacroSYNC()
        If System.IO.File.Exists(iniexist) Then
            ModificaKey(CoordinateXInvio, tbCoorXCInvio.Text)
            ModificaKey(CoordinateYInvio, tbCoorYCInvio.Text)
            ModificaKey(CoordinateXErrore, tbCoorXErrori.Text)
            ModificaKey(CoordinateYErrore, tbCoorYErrori.Text)
            ModificaKey(CoordinateButtonXFatturazione, tbCoorXFatt.Text)
            ModificaKey(CoordinateButtonYFatturazione, tbCoorYFatt.Text)
            ModificaKey(CoordinateButtonXInvio, tbCoorXInvio.Text)
            ModificaKey(CoordinateButtonYInvio, tbCoorYInvio.Text)
            ModificaKey(CoordinateButtonXChiusura1, tbCoorXChiusura1.Text)
            ModificaKey(CoordinateButtonYChiusura1, tbCoorYChiusura1.Text)
            ModificaKey(CoordinateButtonXChiusura2, tbCoorXChiusura2.Text)
            ModificaKey(CoordinateButtonYChiusura2, tbCoorYChiusura2.Text)
            ModificaKey(CoordinateButtonXChiusura3, tbCoorXChiusura3.Text)
            ModificaKey(CoordinateButtonYChiusura3, tbCoorYChiusura3.Text)
        Else
            MostraErrore(Me, "Errore nel salvataggio delle coordiante sync in PentaStart.ini")
        End If
        MostraAttenzione("Impostazione coordinate SYNC aggiornate con succeso.")
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub PulTest_Click(sender As Object, e As EventArgs) Handles pulTest.Click
        Dim FormDomanda As New Domanda With {.Messagio = "Si desidera provare le coordinate impostate?"}
        Dim result As DialogResult = FormDomanda.ShowDialog()
        If result = DialogResult.Yes Then
            Try
                If File.Exists(PercorsoMacro + "\1.mmmacro") Then
                    FileIO.FileSystem.RenameFile(PercorsoMacro + "\1.mmmacro", "1_bk.mmmacro")
                Else
                    MostraErrore(Me, "Il file 1.mmmacro non esiste.")
                End If
            Catch ex As Exception
                MostraErrore(Me, "Impossibile salvare il file di macro corrente", ex)
            End Try

            Dim VersioneSYNC As String = AssemblyName.GetAssemblyName(Variables.PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe").Version.ToString()
            Dim StringFile = "1 | IF | PROCESS NAME | BRAINTEAMFATTURAELETTRONICA | NOT EXIST | GOTO MACRO LINE | 2" + Environment.NewLine +
            "2 | IF | PROCESS NAME | BRAINTEAMFATTURAELETTRONICA | NOT EXIST | GOTO MACRO LINE | 1" + Environment.NewLine +
            "3 | IF | WINDOW TITLE | BrainTeam Fatturazione Elettronica v." + VersioneSYNC + " | NOT EXIST | GOTO MACRO LINE | 4" + Environment.NewLine +
            "4 | IF | WINDOW TITLE | BrainTeam Fatturazione Elettronica v." + VersioneSYNC + " | NOT EXIST | GOTO MACRO LINE | 3" + Environment.NewLine +
            "5 | RUN ACTION | SELECT WINDOW BY NAME | BrainTeam" + Environment.NewLine +
            "6 | " + tbCoorXFatt.Text + " | " + tbCoorYFatt.Text + " | 1265 | Left Click" + Environment.NewLine +
            "7 | RUN ACTION | SELECT WINDOW BY NAME | BrainTeam Fatturazione Elettronica" + Environment.NewLine +
            "8 | " + tbCoorXInvio.Text + " | " + tbCoorYInvio.Text + " | 3703 | Left Click" + Environment.NewLine +
            "9 | RUN ACTION | WAIT SECONDS | 10" + Environment.NewLine +
            "10 | IF | PIXEL COLOR | Color [R=89, G=89, B=89]::At Location [X:" + tbCoorXCInvio.Text + " Y:" + tbCoorYCInvio.Text + "] | IS THE SAME | GOTO MACRO LINE | 9" + Environment.NewLine +
            "11 | IF | PIXEL COLOR | Color [R=70, G=130, B=180]::At Location [X:" + tbCoorXErrori.Text + " Y:" + tbCoorYErrori.Text + "] | IS THE SAME | STOP" + Environment.NewLine +
            "12 | " + tbCoorXChiusura1.Text + " | " + tbCoorYChiusura1.Text + " | 4961 | Left Click" + Environment.NewLine +
            "13 | " + tbCoorXChiusura2.Text + " | " + tbCoorYChiusura2.Text + " | 1172 | Left Click" + Environment.NewLine +
            "14 | " + tbCoorXChiusura3.Text + " | " + tbCoorYChiusura3.Text + " | 1172 | Left Click"

            Try
                LogFile.WriteLog("Creazione File Macro di TEST")
                File.WriteAllText(PercorsoMacro + "\1.mmmacro", StringFile)
            Catch ex As Exception
                MostraErrore(Me, "Impossibile creare il file di macro test", ex)
                Return
            End Try

            Try
                AvvioInvioFattureSync()
            Catch ex As Exception
                MostraErrore(Me, "SYNC non trovato.", ex)
            End Try

            Try
                File.Delete(PercorsoMacro + "\1.mmmacro")
                If File.Exists(PercorsoMacro + "1_bk.mmmacro") Then
                    FileIO.FileSystem.RenameFile(Application.ExecutablePath + "\1_bk.mmmacro", "1.mmmacro")
                End If
            Catch ex As Exception
                MostraErrore(Me, "Errore nel ripristino del macro originale.", ex)
            End Try
        Else
            Return
        End If
    End Sub

    Private Sub CoordinateSYNC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbCoorXChiusura1.Text = CoordinateButtonXChiusura1.Value
        tbCoorYChiusura1.Text = CoordinateButtonYChiusura1.Value
        tbCoorXChiusura2.Text = CoordinateButtonXChiusura2.Value
        tbCoorYChiusura2.Text = CoordinateButtonYChiusura2.Value
        tbCoorXChiusura3.Text = CoordinateButtonXChiusura3.Value
        tbCoorYChiusura3.Text = CoordinateButtonYChiusura3.Value
        tbCoorXCInvio.Text = CoordinateXInvio.Value
        tbCoorYCInvio.Text = CoordinateYInvio.Value
        tbCoorXErrori.Text = CoordinateXErrore.Value
        tbCoorYErrori.Text = CoordinateYErrore.Value
        tbCoorXFatt.Text = CoordinateButtonXFatturazione.Value
        tbCoorYFatt.Text = CoordinateButtonYFatturazione.Value
        tbCoorXInvio.Text = CoordinateButtonXInvio.Value
        tbCoorYInvio.Text = CoordinateButtonYInvio.Value
    End Sub
End Class
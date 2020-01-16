Imports System.IO
Imports System.IO.Ports
Imports IWshRuntimeLibrary
Imports File = System.IO.File
Imports PentaStart.Utility
Public Class ChiusuraFiscale

    Private AxCoEcrCom1 As AxCOECRCOMLib.AxCoEcrCom
    Private Sub chiusura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlloDriverInvioScontrino()
        If EsisteStampanteDitron() And Variables.Software.Value = "menu" Then
            AxCoEcrCom1 = New AxCOECRCOMLib.AxCoEcrCom()
            AxCoEcrCom1.Open("1")
        Else
            ControlloDriverInvioScontrino()
        End If
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Dispose()
        RegistratoreTelematico.Show()
    End Sub

    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        If EsisteStampanteMCT() Then
            LogFile.WriteLog("Chiusura fiscale stampante MCT in corso...")
            Dim commandi() As String = {"=K", "=C3", "=C10", "=C1", "=C1"}
            Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
            ScrivereFile(commandi, Percorso)
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA CHIUSURA FISCALE." & Environment.NewLine & " ESEGUIRE CHIUSURA FISCALE MANUALMENTE")
        ElseIf EsisteStampanteDitron() Then
            LogFile.WriteLog("Chiusura fiscale stampante Ditron in corso...")
            If Variables.Software.Value = "menu" Then
                Try
                    Dim result As String = ""
                    Dim sOpz = "PORT = 1"
                    If Variables.PercorsoDatabase.Value <> "" Then
                        sOpz = sOpz + ",CURDIR = '" + Variables.PercorsoDatabase + "'"
                    End If
                    result = AxCoEcrCom1.Open(sOpz)
                    If result = 0 Then
                        Me.Hide()
                        Dim FormAttendere As New Attendere
                        FormAttendere.Show()
                        FormAttendere.Refresh()
                        AxCoEcrCom1.EcrCmd("clear", result)
                        AxCoEcrCom1.EcrCmd("chiave z", result)
                        AxCoEcrCom1.EcrCmd("azzgio tipo=2", result)
                        AxCoEcrCom1.EcrCmd("chiave z", result)
                        AxCoEcrCom1.EcrCmd("INP NUM = 99, TERM = 145", result)
                        AxCoEcrCom1.EcrCmd("CLEAR", result)
                        AxCoEcrCom1.EcrCmd("chiave reg", result)
                        AxCoEcrCom1.Close()
                        LogFile.WriteLog("La stampante ha eseguito il commando.")
                        FormAttendere.Hide()
                        FormAttendere.Dispose()
                    Else
                        MostraErrore(Me, "ERRORE STAMPA CHIUSURA FISCALE." & Environment.NewLine & " ESEGUIRE CHIUSURA FISCALE MANUALMENTE")
                    End If
                Catch ex As Exception
                    MostraErrore(Me, "ERRORE STAMPA CHIUSURA FISCALE." & Environment.NewLine & " ESEGUIRE CHIUSURA FISCALE MANUALMENTE", ex)
                End Try
            ElseIf Variables.Software.Value = "laundry" Then
                MostraErrore(Me, "ESEGUIRE CHIUSURA FISCALE CON IL PROGRAMMA LAUNDRY.")
            ElseIf Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim commandi() As String = {"CHIAVE Z", "INP TERM=145", "INP TERM=145", "CHIAVE Z", "INP NUM=99, TERM=145", "CHIAVE REG"}
                Dim Percorso As String = Variables.PercorsoWinEcr.Value.Replace("/", "\") + "\TOSEND\scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA CHIUSURA FISCALE." & Environment.NewLine & " ESEGUIRE CHIUSURA FISCALE MANUALMENTE")
            End If
        ElseIf EsisteStampanteEpson() Then
            LogFile.WriteLog("Chiusura fiscale stampante Epson in corso...")
            Dim commandi() As String = {"printerFiscalReport", "Printer|1", "printZReport|1"}
            Dim Percorso As String = Variables.PercorsoFpMate.Value.Replace("/", "\") + "\TOSEND\scontrino.txt"
            ScrivereFile(commandi, Variables.PercorsoFpMate.Value.Replace("/", "\") + "\TOSEND\scontrino.txt")
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA CHIUSURA FISCALE." & Environment.NewLine & " ESEGUIRE CHIUSURA FISCALE MANUALMENTE")
        End If
        Me.Dispose()
        FormMain.Show()
    End Sub
End Class
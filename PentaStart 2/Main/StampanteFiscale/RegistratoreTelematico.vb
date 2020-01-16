Imports System.IO
Imports System.IO.Ports
Imports IWshRuntimeLibrary
Imports PentaStart.Utility

Public Class RegistratoreTelematico
    Private AxCoEcrCom1 As AxCOECRCOMLib.AxCoEcrCom
    Private Sub regtelematico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogFile.WriteLog("Avvio schermata gestione registratore telematico in corso...")
        ControlloDriverInvioScontrino()
        If EsisteStampanteDitron() And Variables.Software.Value = "menu" Then
            AxCoEcrCom1 = New AxCOECRCOMLib.AxCoEcrCom()
            AxCoEcrCom1.Open(1)
        End If
    End Sub

    Private Sub indietro_Click(sender As Object, e As EventArgs)
        Me.Dispose()
        FormMain.Show()
    End Sub

    Private Sub ButtonLetGiornalera_Click(sender As Object, e As EventArgs) Handles ButtonLetGiornalera.Click
        LogFile.WriteLog("Avvio stampa Lettura Giornalera in corso...")
        If EsisteStampanteMCT() Then
            Dim commandi() As String = {"=K", "=C2", "=C10", "=C1"}
            Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
            ScrivereFile(commandi, Percorso)
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA GIORNALERA. RIPROVARE")
            Me.Show()
        ElseIf EsisteStampanteDitron() Then
            If Variables.Software.Value = "menu" Then
                Try
                    Dim result As String = ""
                    Dim sOpz = "PORT = 1"
                    If Variables.PercorsoDatabase.Value <> "" Then
                        sOpz = sOpz + ",CURDIR = '" + Variables.PercorsoDatabase + "'"
                    End If
                    result = AxCoEcrCom1.Open(sOpz)
                    If result = "0" Then
                        AxCoEcrCom1.EcrCmd("clear", result)
                        AxCoEcrCom1.EcrCmd("chiave x", result)
                        AxCoEcrCom1.EcrCmd("report num=2", result)
                        AxCoEcrCom1.EcrCmd("chiave reg", result)
                        AxCoEcrCom1.Close()
                    End If
                Catch ex As Exception
                    MostraErrore(Me, "ERRORE STAMPA LETTURA GIORNALERA. RIPROVARE", ex)
                End Try
            ElseIf Variables.Software.Value = "laundry" Then
                MostraErrore(Me, "ESEGUIRE LETTURA GIORNALERA DAL PROGRAMMA LAUNDRY.")
            ElseIf Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim commandi() As String = {"chiave x", "report num=2", "chiave reg"}
                Dim Percorso As String = Variables.PercorsoWinEcr.Value.Replace("/", "\") + "\TOSEND\scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA GIORNALERA. RIPROVARE")
                Me.Show()
            End If
        ElseIf EsisteStampanteEpson() Then
            Dim commandi() As String = {"printerFiscalReport", "Printer|1", "printXReport"}
            Dim Percorso As String = Variables.PercorsoFpMate.Value + "/TOSEND/scontrino.txt"
            ScrivereFile(commandi, Percorso)
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA GIORNALERA. RIPROVARE")
            Me.Show()
        End If
    End Sub

    Private Sub ButtonChiusura_Click(sender As Object, e As EventArgs) Handles ButtonChiusura.Click
        Me.Dispose()
        ChiusuraFiscale.Show()
    End Sub

    Private Sub ButtonLetDGFE_Click(sender As Object, e As EventArgs) Handles ButtonLetDGFE.Click
        Me.Dispose()
        LetturaDGFE.Show()
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        If EsisteStampanteMCT() Then
            Dim commandi() As String = {"=K", "=C1"}
            Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
            ScrivereFile(commandi, Percorso)
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA GIORNALERA. RIPROVARE")
            Me.Show()
        ElseIf EsisteStampanteDitron() Then
            If Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim commandi() As String = {"RESPRN", "CHIAVE REG"}
                Dim Percorso As String = Variables.PercorsoWinEcr.Value.Replace("/", "\") + "\TOSEND\scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA GIORNALERA. RIPROVARE")
                Me.Show()
            End If
        ElseIf EsisteStampanteEpson() Then
            Dim commandi() As String = {"chiave reg"}
            ScrivereFile(commandi, Variables.PercorsoFpMate.Value.Replace("/", "\") + "\TOSEND\scontrino.txt")
        End If
    End Sub

    Private Sub ButtonAnnullo_Click(sender As Object, e As EventArgs) Handles ButtonAnnullo.Click
        Me.Dispose()
        AnnulloScontrino.Show()
    End Sub

    Private Sub ButtonInvioAE_Click(sender As Object, e As EventArgs) Handles ButtonInvioAE.Click
        If EsisteStampanteMCT() Then
            Dim commandi() As String = {"=K", "=C3", "=C422", "=C1"}
            ScrivereFile(commandi, Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt")
        ElseIf EsisteStampanteDitron() Then
            If Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim commandi() As String = {"CHIAVE Z", "INP NUM=99, TERM=145", "CHIAVE REG"}
                ScrivereFile(commandi, Variables.PercorsoWinEcr.Value.Replace("/", "\") + "\TOSEND\scontrino.txt")
            End If
        ElseIf EsisteStampanteEpson() Then
            MostraErrore(Me, "L'INVIO DEI CORRISPETTIVI VIENE ESEGUITO INSIEME ALLA CHIUSURA GIORNALERA")
        End If
    End Sub

    Private Sub LettMF_Click(sender As Object, e As EventArgs) Handles LettMF.Click
        Me.Dispose()
        LetturaMF.Show()
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.Dispose()
        FormMain.BringToFront()
        FormMain.Show()
    End Sub
End Class
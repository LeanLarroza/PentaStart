Imports System.Globalization
Imports System.IO
Imports System.IO.Ports
Imports IWshRuntimeLibrary
Imports PentaStart.Utility
Public Class LetturaMF
    Private AxCoEcrCom1 As AxCOECRCOMLib.AxCoEcrCom

    Private Sub Lettdgfe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlloDriverInvioScontrino()
        If EsisteStampanteDitron() And Variables.Software.Value = "menu" Then
            AxCoEcrCom1 = New AxCOECRCOMLib.AxCoEcrCom()
        End If
        TextBox1.Text = Now.ToString("dd/MM/yy")
        TextBox2.Text = Now.ToString("dd/MM/yy")
        Me.ActiveControl = Label1
    End Sub

    Private Sub ButtonConferma_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        Dim DataTextBox As Date
        If Not Date.TryParseExact(TextBox1.Text, "dd/MM/yy", New CultureInfo("it-IT"), DateTimeStyles.None, DataTextBox) And Not Date.TryParseExact(TextBox2.Text, "dd/MM/yy", New CultureInfo("it-IT"), DateTimeStyles.None, DataTextBox) Then
            LogFile.WriteLog("Data documento errata")
            LogFile.WriteLog("Data iniziale: " & TextBox1.Text)
            LogFile.WriteLog("Data finale: " & TextBox2.Text)
            MostraErrore(Me, "DATA INSERITA NON VALIDA.")
            Return
        End If

        Dim DataIniziale As Date = Date.ParseExact(TextBox1.Text, "dd/MM/yy", New CultureInfo("it-IT"))
        Dim DataFinale As Date = Date.ParseExact(TextBox2.Text, "dd/MM/yy", New CultureInfo("it-IT"))
        If DataIniziale > DataFinale Then
            Dim DataTemp As Date
            DataTemp = New Date(DataIniziale.Year, DataIniziale.Month, DataIniziale.Day)
            DataIniziale = New Date(DataFinale.Year, DataFinale.Month, DataFinale.Day)
            DataFinale = New Date(DataTemp.Year, DataTemp.Month, DataTemp.Day)
            TextBox1.Text = DataIniziale.ToString("dd/MM/yy")
            TextBox2.Text = DataFinale.ToString("dd/MM/yy")
            Me.Refresh()
        End If

        LogFile.WriteLog("Lettura Memoria Fiscale in corso..")
        LogFile.WriteLog("Data iniziale scelta: " & TextBox1.Text)
        LogFile.WriteLog("Data finale scelta: " & TextBox2.Text)

        If EsisteStampanteMCT() Then
            Dim commandi() As String = {"=K", "=C3", "=C403/&" + TextBox1.Text.Replace("/", "") + "/[" + TextBox2.Text.Replace("/", ""), "=C1"}
            Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
            ScrivereFile(commandi, Percorso)
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA MEMORIA FISCALE.")
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
                        Dim FormAttendere As New Attendere
                        FormAttendere.Show()
                        FormAttendere.Refresh()
                        AxCoEcrCom1.EcrCmd("clear", result)
                        AxCoEcrCom1.EcrCmd("chiave p", result)
                        AxCoEcrCom1.EcrCmd("dgfe datai=" + TextBox1.Text.Replace("/", "") + ", dataf=" + TextBox2.Text.Replace("/", "") + ", soloz=si, stampa=si", result)
                        AxCoEcrCom1.EcrCmd("chiave reg", result)
                        AxCoEcrCom1.Close()
                        LogFile.WriteLog("La stampante ha eseguito il commando.")
                        FormAttendere.Hide()
                        FormAttendere.Dispose()
                    Else
                        MostraErrore(Me, "ERRORE STAMPA LETTURA MEMORIA FISCALE.")
                    End If
                Catch ex As Exception
                    MostraErrore(Me, "ERRORE STAMPA LETTURA MEMORIA FISCALE.", ex)
                End Try
            ElseIf Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim commandi() As String = {"clear", "chiave p", "dgfe datai=" + TextBox1.Text.Replace("/", "") + ", dataf=" + TextBox2.Text.Replace("/", "") + ", soloz=si, stampa=si", "chiave reg"}
                Dim Percorso As String = Variables.PercorsoWinEcr.Value.Replace("/", "\") + "\TOSEND\scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA MEMORIA FISCALE.")
                Me.Show()
            Else
                InSviluppo(Me)
            End If
        ElseIf EsisteStampanteEpson() Then
            Dim commandi() As String = {"printContentByDate|1|5|" & DataIniziale.Day.ToString("00") & "|" & DataIniziale.Month.ToString("00") & "|" & DataIniziale.Year.ToString("0000") & "|" & DataFinale.Day.ToString("00") & "|" & DataFinale.Month.ToString("00") & "|" & DataFinale.Year.ToString("0000") & ""}
            Dim Percorso As String = Variables.PercorsoFpMate.Value + "/TOSEND/scontrino.txt"
            ScrivereFile(commandi, Percorso)
            Me.Hide()
            AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
            Me.Show()
        End If
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.Dispose()
        RegistratoreTelematico.Show()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        MostraCalendarioEAggiornaTesto(Me, Date.ParseExact(TextBox1.Text, "dd/MM/yy", CultureInfo.InvariantCulture), TextBox1)
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        MostraCalendarioEAggiornaTesto(Me, Date.ParseExact(TextBox2.Text, "dd/MM/yy", CultureInfo.InvariantCulture), TextBox2)
    End Sub
End Class
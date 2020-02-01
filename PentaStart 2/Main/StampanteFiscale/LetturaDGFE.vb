Imports System.Globalization
Imports System.IO
Imports System.IO.Ports
Imports IWshRuntimeLibrary
Imports PentaStart.Utility

Public Class LetturaDGFE
    Private AxCoEcrCom1 As AxCOECRCOMLib.AxCoEcrCom
    Dim keyboard As New KeyBoard
    Private Sub Indietro_Click(sender As Object, e As EventArgs)
        Me.Dispose()
        RegistratoreTelematico.Show()
    End Sub

    Private Sub Lettdgfe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlloDriverInvioScontrino()
        LogFile.WriteLog("Avvio Lettura DGFE in corso...")
        If EsisteStampanteDitron() And Variables.Software.Value = "menu" Then
            AxCoEcrCom1 = New AxCOECRCOMLib.AxCoEcrCom()
        End If

        TextBox1.Text = Now.ToString("dd/MM/yy")
        TextBox2.Text = Now.ToString("dd/MM/yy")
        Me.ActiveControl = Label1
    End Sub

    Private Sub Iscon_TextChanged(sender As Object, e As EventArgs) Handles iscon.TextChanged
        Dim scontrinoin As Integer
        Dim scontrinofin As Integer
        Try
            scontrinoin = CInt(iscon.Text)
        Catch ex As Exception
            scontrinoin = 0
        End Try
        Try
            scontrinofin = CInt(fscon.Text)
        Catch ex As Exception
            scontrinofin = 0
        End Try

        If scontrinoin > scontrinofin Then
            fscon.Text = iscon.Text
        End If
    End Sub

    Private Sub Fscon_TextChanged(sender As Object, e As EventArgs) Handles fscon.TextChanged
        Dim scontrinoin As Integer
        Dim scontrinofin As Integer
        Try
            scontrinoin = CInt(iscon.Text)
        Catch ex As Exception
            scontrinoin = 0
        End Try
        Try
            scontrinofin = CInt(fscon.Text)
        Catch ex As Exception
            scontrinofin = 0
        End Try

        If scontrinoin > scontrinofin Then
            iscon.Text = fscon.Text
        End If
    End Sub

    Private Sub TextBox1_Click_1(sender As Object, e As EventArgs) Handles TextBox1.Click
        MostraCalendarioEAggiornaTesto(Me, Date.ParseExact(TextBox1.Text, "dd/MM/yy", CultureInfo.InvariantCulture), TextBox1)
    End Sub

    Private Sub ButtonConferma_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        Dim DataTextBox As Date
        If Not Date.TryParseExact(TextBox1.Text, "dd/MM/yy", New CultureInfo("it-IT"), DateTimeStyles.None, DataTextBox) And Not Date.TryParseExact(TextBox2.Text, "dd/MM/yy", New CultureInfo("it-IT"), DateTimeStyles.None, DataTextBox) Then
            LogFile.WriteLog("Data documento errata")
            LogFile.WriteLog("Data iniziale: " & TextBox1.Text)
            LogFile.WriteLog("Data finale: " & TextBox2.Text)
            LogFile.WriteLog("Errore stampa lettura contenuto memoria DGFE.")
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

        Dim unused = 0
        If Not Decimal.TryParse(iscon.Text, unused) And Not Not Decimal.TryParse(fscon.Text, unused) Then
            MostraErrore(Me, "NUMERO SCONTRINO NON VALIDO.")
            Return
        End If

        If iscon.Text = "" Or iscon.Text = "00" Then
            iscon.Text = "0"
        ElseIf fscon.Text = "" Or fscon.Text = "00" Then
            fscon.Text = "0"
        End If

        LogFile.WriteLog("Avvio stampa contenuto DGFE in corso..")
        LogFile.WriteLog("Data iniziale scelta: " & TextBox1.Text)
        LogFile.WriteLog("Data finale scelta: " & TextBox2.Text)
        LogFile.WriteLog("Da scontrino: " & iscon.Text)
        LogFile.WriteLog("A scontrino: " & fscon.Text)

        If EsisteStampanteMCT() Then
            If iscon.Text = "0" And fscon.Text = "0" Then
                Dim commandi() As String = {"=K", "=C3", "=C451/$1/&" & TextBox1.Text.Replace("/", "") & "/[" + TextBox2.Text.Replace("/", ""), " =C1"}
                Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
                Me.Show()
            Else
                Dim commandi() As String = {"=K", "=C3", "=C452/$1/&" & TextBox1.Text.Replace("/", "") & "/[" & CInt(iscon.Text).ToString() & "/]" & CInt(fscon.Text).ToString(), "=C1"}
                Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
                Me.Show()
            End If
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
                        If (iscon.Text <> "0" And fscon.Text <> "0") And fscon.Text <> "" And iscon.Text <> "" Then
                            AxCoEcrCom1.EcrCmd("dgfe datai=" & TextBox1.Text.Replace("/", "") & ", dataf=" + TextBox2.Text.Replace("/", "") + ", numscoi=" & CInt(iscon.Text).ToString() & ", numscof=" + CInt(fscon.Text).ToString() & ", stampa", result)
                        Else
                            AxCoEcrCom1.EcrCmd("dgfe datai=" & TextBox1.Text.Replace("/", "") & ", dataf=" & TextBox2.Text.Replace("/", "") & ", stampa", result)
                        End If
                        AxCoEcrCom1.EcrCmd("chiave reg", result)
                        AxCoEcrCom1.Close()
                        LogFile.WriteLog("La stampante ha eseguito il commando.")
                        FormAttendere.Hide()
                        FormAttendere.Dispose()
                    Else
                        MostraErrore(Me, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
                    End If
                Catch ex As Exception
                    MostraErrore(Me, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.", ex)
                End Try
            ElseIf Variables.Software.Value = "laundry" Then
                InSviluppo(Me)
            ElseIf Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim commandi() As String = {"CHIAVE PROG", "INP NUM=160, TERM=145", "INP NUM=" & TextBox1.Text.Replace("/", "") & ", TERM=145", "INP NUM=" & TextBox2.Text.Replace("/", "") & ", TERM=145", "INP NUM=" + CInt(iscon.Text).ToString() & ", TERM=145", "INP NUM=" + CInt(fscon.Text).ToString() & ", TERM=145", "CHIAVE REG"}
                Dim Percorso As String = Variables.PercorsoWinEcr.Value.Replace("/", "\") & "\TOSEND\scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
                Me.Show()
            End If
        ElseIf EsisteStampanteEpson() Then
            If iscon.Text = "0" And fscon.Text = "0" Then
                Dim commandi() As String = {"printerCommand", "Printer|1", "PrintContent|1|0|" & DataIniziale.Day.ToString("00") & "|" & DataIniziale.Month.ToString("00") & "|" & DataIniziale.Year.ToString("0000") & "|" & DataFinale.Day.ToString("00") & "|" & DataFinale.Month.ToString("00") & "|" & DataFinale.Year.ToString("0000") & ""}
                Dim Percorso As String = Variables.PercorsoFpMate.Value + "/TOSEND/scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
                Me.Show()
            Else
                Dim commandi() As String = {"printerCommand", "Printer|1", "PrintContent|1|0|" & DataIniziale.Day.ToString("00") & "|" & DataIniziale.Month.ToString("00") & "|" & DataIniziale.Year.ToString("0000") & "|" & CInt(iscon.Text).ToString("0000") & "|" & CInt(fscon.Text).ToString("0000")}
                Dim Percorso As String = Variables.PercorsoFpMate.Value + "/TOSEND/scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA LETTURA CONTENUTO MEMORIA DGFE.")
                Me.Show()
            End If
        End If
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        MostraCalendarioEAggiornaTesto(Me, Date.ParseExact(TextBox2.Text, "dd/MM/yy", CultureInfo.InvariantCulture), TextBox2)
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.Dispose()
        RegistratoreTelematico.Show()
    End Sub

    Private Sub Iscon_Click(sender As Object, e As EventArgs) Handles iscon.Click
        MostraEAggiornaNumero(Me, iscon.Text, iscon)
    End Sub

    Private Sub Fscon_Click(sender As Object, e As EventArgs) Handles fscon.Click
        MostraEAggiornaNumero(Me, fscon.Text, fscon)
    End Sub
End Class
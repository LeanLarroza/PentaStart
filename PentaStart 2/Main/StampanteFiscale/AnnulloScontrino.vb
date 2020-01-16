Imports System.IO
Imports IWshRuntimeLibrary
Imports File = System.IO.File
Imports PentaStart.Utility
Imports System.Globalization

Public Class AnnulloScontrino
    Private result As String = ""
    Private Sub Annullosco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlloDriverInvioScontrino()
        LogFile.WriteLog("Avvio schermata Annullo Scontrino in corso..")
        TextBox2.Text = ""
        TextBox1.Text = Now.ToString("dd/MM/yy")
        ImportoAnn.Text = ""
        If EsisteStampanteMCT() Then
            Label5.Visible = False
            Label6.Visible = False
            ImportoAnn.Visible = False
        ElseIf EsisteStampanteDitron() And Variables.Software.Value = "menu" Then
            AxCoEcrCom1 = New AxCOECRCOMLib.AxCoEcrCom()
            Dim sOpz = "PORT = 1"
            If Variables.PercorsoDatabase.Value <> "" Then
                sOpz = sOpz + ",CURDIR = '" + Variables.PercorsoDatabase + "'"
            End If
            result = AxCoEcrCom1.Open(sOpz)
            If result = "0" Then
                Dim sco As String = ""
                AxCoEcrCom1.EcrCmd("INFO CODICE=10", sco)
                AxCoEcrCom1.EcrCmd("INFO CODICE=11", result)
                Dim azz As Integer = CInt(result)
                azz += 1
                Dim azz0 As String = azz.ToString("0000")
                TextBox2.Text = azz0 + sco
            End If
            AxCoEcrCom1.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        If Not TextBox2.Text.Replace("-", "").Length = 8 Then
            LogFile.WriteLog("Numero di documento errato: " & TextBox2.Text)
            MostraErrore(Me, "NUMERO DI DOCUMENTO NON VALIDO.")
            Return
        End If

        Dim DataTextBox As Date
        If Not Date.TryParseExact(TextBox1.Text, "dd/MM/yy", New CultureInfo("it-IT"), DateTimeStyles.None, DataTextBox) Then
            LogFile.WriteLog("Data documento errata: " & TextBox2.Text)
            MostraErrore(Me, "DATA NON VALIDA.")
            Return
        End If

        TextBox2.Text = TextBox2.Text.Replace("-", "")
        Dim nazz = TextBox2.Text.Substring(0, 4)
        Dim nscont = TextBox2.Text.Substring(4)
        LogFile.WriteLog("Data inserita: " & TextBox1.Text)
        LogFile.WriteLog("Numero Azzeramento: " & CInt(nazz).ToString("0000"))
        LogFile.WriteLog("Numero Scontrino: " & CInt(nscont).ToString("0000"))

        If (ImportoAnn.Text = "0" Or ImportoAnn.Text = "" Or ImportoAnn.Text = "00") And Not EsisteStampanteMCT() And Not EsisteStampanteEpson() Then
            MostraErrore(Me, "INSERIRE IMPORTO TOTALE SCONTRINO.")
            Return
        End If

        If EsisteStampanteMCT() Then
            Dim result3 As DialogResult = MessageBox.Show("Sei sicuro di annullare lo scontrino N." + TextBox2.Text + "?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result3 = DialogResult.Yes) Then
                LogFile.WriteLog("Stampa documento di annullamento per lo scontrino " & TextBox2.Text.Replace("-", "") & " con data " & TextBox1.Text & " in corso...")
                Dim commandi() As String = {"=K", "=C1", "=k/&" + TextBox1.Text.Replace("/", "") + "/[" + CInt(nazz).ToString() + "/]" + CInt(nscont).ToString(), "=C1"}
                Dim Percorso As String = Variables.PercorsoMultiDriver.Value + "/TOSEND/scontrino.txt"
                ScrivereFile(commandi, Percorso)
                Me.Hide()
                AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA DOCUMENTO DI ANNULLAMENTO. RIPROVARE")
            End If
        ElseIf EsisteStampanteDitron() Then
            LogFile.WriteLog("Stampa documento di annullamento per lo scontrino " & TextBox2.Text.Replace("-", "") & ", Importo: €" & ImportoAnn.Text & " con data " & TextBox1.Text & " in corso...")
            If Variables.Software.Value = "menu" Then
                ImportoAnn.Text = ImportoAnn.Text.Replace(".", ",")
                Dim ImportoAnnullo As String = Convert.ToDouble(ImportoAnn.Text).ToString("0.00")
                Dim result3 As DialogResult = MessageBox.Show("Sei sicuro di annullare lo scontrino N." + TextBox2.Text + " Importo:  €" + ImportoAnnullo + "?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result3 = DialogResult.Yes) Then
                    Dim sOpz = "PORT = 1"
                    If Variables.PercorsoDatabase.Value <> "" Then
                        sOpz = sOpz + ",CURDIR = '" + Variables.PercorsoDatabase + "'"
                    End If
                    result = AxCoEcrCom1.Open(sOpz)
                    If result = "0" Then
                        Me.Hide()
                        Dim FormAttendere As New Attendere
                        FormAttendere.Show()
                        FormAttendere.Refresh()
                        AxCoEcrCom1.EcrCmd("INP TERM=188", result)
                        AxCoEcrCom1.EcrCmd("INP TERM=145", result)
                        AxCoEcrCom1.EcrCmd("INP TERM=145", result)
                        AxCoEcrCom1.EcrCmd("INP ALFA=" + TextBox2.Text + " , TERM=145", result)
                        Threading.Thread.Sleep(2000)
                        AxCoEcrCom1.EcrCmd("INP TERM=145", result)
                        Threading.Thread.Sleep(2000)
                        AxCoEcrCom1.EcrCmd("CLEAR", result)
                        AxCoEcrCom1.EcrCmd("vend rep=" + Variables.RepartoAnnullo.Value + ", pre=" + ImportoAnnullo.Replace(",", ".") + ", des='" + Variables.CausaleAnnullo.Value + "'", result)
                        AxCoEcrCom1.EcrCmd("CHIUS", result)
                        AxCoEcrCom1.EcrCmd("CLEAR", result)
                        AxCoEcrCom1.Close()
                        LogFile.WriteLog("La stampante ha eseguito il commando.")
                        FormAttendere.Hide()
                        FormAttendere.Dispose()
                    Else
                        MostraErrore(Me, "ERRORE STAMPA DOCUMENTO DI ANNULLAMENTO. RIPROVARE")
                    End If
                Else
                    ImportoAnn.Text = ""
                    Me.Dispose()
                    RegistratoreTelematico.Show()
                End If
            ElseIf Variables.Software.Value = "laundry" Then
                InSviluppo(Me)
            ElseIf Variables.Software.Value = "comus" Or Variables.Software.Value = "trilogis" Then
                Dim result3 As DialogResult = MessageBox.Show("Sei sicuro di annullare lo scontrino N." + TextBox2.Text + " Importo:  €" + ImportoAnn.Text + "?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result3 = DialogResult.Yes) Then
                    LogFile.WriteLog("Stampa documento di annullamento per lo scontrino " & TextBox2.Text.Replace("-", "") & ", Importo: €" & ImportoAnn.Text & " con data " & TextBox1.Text & " in corso...")
                    ImportoAnn.Text = ImportoAnn.Text.Replace(".", ",")
                    Dim ImportoAnnullo As String = Convert.ToDouble(ImportoAnn.Text).ToString("0.00")
                    Dim commandi() As String = {"CHIAVE REG", "INP TERM=188", "INP TERM=145", "INP TERM=145", "INP ALFA=" + TextBox2.Text + " TERM=145", "INP TERM=145", "CLEAR", "vend rep=" + Variables.RepartoAnnullo.Value + ", pre=" + ImportoAnnullo.Replace(",", ".") + ", des='" + Variables.CausaleAnnullo.Value + "'", "CHIUS", "CLEAR"}
                    Dim Percorso As String = Variables.PercorsoWinEcr.Value.Replace("/", "\") + "\TOSEND\scontrino.txt"
                    ScrivereFile(commandi, Percorso)
                    Me.Hide()
                    AttendereRispostaStampante(Percorso, commandi, "ERRORE STAMPA DOCUMENTO DI ANNULLAMENTO. RIPROVARE")
                    ImportoAnn.Text = ""
                    Me.Dispose()
                    RegistratoreTelematico.Show()
                End If
            End If
        ElseIf EsisteStampanteEpson() Then
            InSviluppo(Me)
        End If
        Me.Dispose()
        RegistratoreTelematico.Show()
    End Sub

    Private Sub Indietro_Click(sender As Object, e As EventArgs) Handles indietro.Click
        ImportoAnn.Text = ""
        Try
            AxCoEcrCom1.Close()
        Catch ex As Exception
        End Try
        Me.Dispose()
        RegistratoreTelematico.Show()
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        MostraCalendarioEAggiornaTesto(Me, Date.ParseExact(TextBox1.Text, "dd/MM/yy", CultureInfo.InvariantCulture), TextBox1)
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        MostraEAggiornaNumero(Me, TextBox2.Text, TextBox2)
    End Sub

    Private Sub ImportoAnn_Click(sender As Object, e As EventArgs) Handles ImportoAnn.Click
        MostraEAggiornaNumero(Me, ImportoAnn.Text, ImportoAnn)
    End Sub
End Class
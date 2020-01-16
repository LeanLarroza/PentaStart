Imports System.IO
Imports FirebirdSql.Data.FirebirdClient
Imports PentaStart.Utility
Imports PentaStart.Variables
Public Class formutility
    Private Sub Utility_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub AvvioConfigStampante(sender As Button, e As EventArgs) Handles ButtonMCT.Click, ButtonEPSON.Click, ButtonDITRON.Click
        AvvioImpostazioneStampante(sender.Text)
    End Sub

    Private Sub AvvioImpostazioneStampante(Stampante As String)
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio impostazione Stampante " & Stampante)
        Dim adminpassword As New AdminPassword()
        Dim result = adminpassword.ShowDialog()
        If (result = DialogResult.OK) Then
            MostraAttenzione("Si consiglia di eseguire un backup del database prima della impostazione")
            Select Case Stampante
                Case "MCT"
                    If EsisteStampanteMCT() Then
                        Dim FormDomanda As New Domanda With {.Messagio = "Disattivare stampante MCT?"}
                        Dim result9 As DialogResult = FormDomanda.ShowDialog()
                        If (result9 = DialogResult.Yes) Then
                            ModificaKey(mct, "false")
                            ModificaKey(PercorsoMultiDriver, "null")
                            MostraAttenzione("Stampante MCT cancellata con sucesso." & Environment.NewLine & "Riavvio PentaStart In corso...")
                            LogFile.WriteLog("Fine impostazione Stampante MCT (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
                            RiavvioPentaStart()
                        Else
                            Me.Activate()
                            Me.BringToFront()
                            Return
                        End If
                    End If

                    If (Variables.Software.Value = "trilogis") Then
                        LogFile.WriteLog("Richiesta percorso MultiDriver")
                        Dim FormDomanda As New Domanda With {.Messagio = "L'installazione di Multiserver è già stata eseguita?"}
                        Dim result2 As DialogResult = FormDomanda.ShowDialog()
                        If (result2 = DialogResult.Yes) Then
                            Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                                .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory),
                                .RootFolder = Environment.SpecialFolder.MyComputer,
                                .Description = "Specificare il percorso del MultiDriverServer.",
                                .ShowNewFolderButton = False
                            }
                            If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                                LogFile.WriteLog("Percorso MultiDriver scelto: " + cercaspercorsodb.SelectedPath)
                                If File.Exists(cercaspercorsodb.SelectedPath + "/MULTIDRIVER_SERVER.exe") Then
                                    LogFile.WriteLog("Percorso MultiDriverServer confermato. (MULTIDRIVER_SERVER trovato)")
                                    ModificaKey(PercorsoMultiDriver, cercaspercorsodb.SelectedPath)
                                Else
                                    MostraErrore(Me, "Errore percorso MultiDriverServer." & Environment.NewLine & "(MultiDriverServer non trovato).")
                                    Return
                                End If
                            Else
                                MostraErrore(Me, "Impostazione stampante MCT annullata")
                                Return
                            End If
                        Else
                            MostraErrore(Me, "Errore installazione MultiDriverServer. (MultiDriverServer non trovato). Eseguire l'installazione di MultiDriverServer prima della impostazione.")
                            Return
                        End If
                    End If
                    ModificaKey(mct, "true")
                    ModificaKey(ditron, "false")
                    ModificaKey(epson, "false")

                Case "DITRON"
                    If EsisteStampanteDitron() Then
                        Dim FormDomanda As New Domanda With {.Messagio = "Disattivare stampante DITRON?"}
                        Dim result9 As DialogResult = FormDomanda.ShowDialog()
                        If (result9 = DialogResult.Yes) Then
                            ModificaKey(ditron, "false")
                            ModificaKey(PercorsoWinEcr, "null")
                            MostraAttenzione("Stampante Ditron cancellata con sucesso." & Environment.NewLine & "Riavvio PentaStart In corso...")
                            LogFile.WriteLog("Fine impostazione Stampante DITRON (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
                            RiavvioPentaStart()
                        Else
                            Me.Activate()
                            Me.BringToFront()
                            Return
                        End If
                    End If

                    If (Variables.Software.Value = "trilogis") Then
                        LogFile.WriteLog("Richiesta percorso WinEcr")
                        Dim FormDomanda As New Domanda With {.Messagio = "L'installazione di WinEcrCom è già stata eseguita?"}
                        Dim result2 As DialogResult = FormDomanda.ShowDialog()
                        If (result2 = DialogResult.Yes) Then
                            Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                                .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory),
                                .RootFolder = Environment.SpecialFolder.MyComputer,
                                .Description = "Specificare il percorso del WinEcrCom.",
                                .ShowNewFolderButton = False
                            }
                            If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                                LogFile.WriteLog("Percorso WinEcr scelto: " + cercaspercorsodb.SelectedPath)
                                If File.Exists(cercaspercorsodb.SelectedPath + "/Utilities/WinEcrConf.exe") Then
                                    LogFile.WriteLog("Percorso WinEcr confermato. (WinEcrConf trovato)")
                                    Try
                                        If Not Directory.Exists(cercaspercorsodb.SelectedPath + "/TOSEND") Then Directory.CreateDirectory(cercaspercorsodb.SelectedPath + "/TOSEND")
                                    Catch ex As Exception
                                        MostraErrore(Me, "Errore creazione cartella " & cercaspercorsodb.SelectedPath, ex)
                                    End Try
                                    ModificaKey(PercorsoWinEcr, cercaspercorsodb.SelectedPath)
                                Else
                                    MostraErrore(Me, "Errore percorso WinEcr. (WinEcrConf non trovato). Eseguire l'installazione di WinEcrCom prima della impostazione.")
                                    Return
                                End If
                            Else
                                MostraErrore(Me, "Impostazione stampante Ditron annullata")
                                Return
                            End If
                        Else
                            MostraErrore(Me, "Errore installazione WinEcr. (WinEcrConf non trovato). Eseguire l'installazione di WinEcrCom prima della impostazione.")
                            Return
                        End If
                    End If
                    ModificaKey(mct, "false")
                    ModificaKey(ditron, "true")
                    ModificaKey(epson, "false")

                Case "EPSON"
                    If EsisteStampanteEpson() Then
                        Dim FormDomanda As New Domanda With {.Messagio = "Disattivare stampante EPSON?"}
                        Dim result9 As DialogResult = FormDomanda.ShowDialog()
                        If (result9 = DialogResult.Yes) Then
                            ModificaKey(epson, "false")
                            ModificaKey(PercorsoFpMate, "null")
                            MostraAttenzione("Stampante EPSON cancellata con sucesso." & Environment.NewLine & "Riavvio PentaStart In corso...")
                            LogFile.WriteLog("Fine impostazione Stampante EPSON (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
                            RiavvioPentaStart()
                        Else
                            Me.Activate()
                            Me.BringToFront()
                            Return
                        End If
                    End If

                    Try
                        Directory.CreateDirectory("C:\Epson")
                        Directory.CreateDirectory("C:\Epson\ERRORI")
                        Directory.CreateDirectory("C:\Epson\TOSEND")
                        Directory.CreateDirectory("C:\Epson\LOGS")
                        LogFile.WriteLog("Percorso FpMate: C:/Epson")
                        ModificaKey(PercorsoFpMate, "C:/Epson")
                    Catch ex As Exception
                        MostraErrore(Me, "ERRORE CREAZIONE CARTELLA TOSEND IN PERCORSO C:/EPSON", ex)
                    End Try

                    If File.Exists("C:\trilogis\PentaUtilities\FpMate\Settings.xml") Then
                        Try
                            File.Copy("C:\trilogis\PentaUtilities\FpMate\Settings.xml", "C:\ProgramData\EPSON\EpsonFpMate\Settings.xml")
                            LogFile.WriteLog("Copia File Settings.xml riuscita: C:\ProgramData\EPSON\EpsonFpMate")
                        Catch ex As Exception
                            LogFile.WriteLog("Errore copia File Settings.xml. Copiare manualmente su C:\ProgramData\EPSON\EpsonFpMate")
                            MostraErrore(Me, "Errore caricamento Settings.xml (FpMateSettings)." + Environment.NewLine + "Copiare manualmente il file .\PentaUtilities\FpMate su C:\ProgramData\Epson\EpsonFpMate" + Environment.NewLine + "Cliccare OK una volta eseguita la copia del file.", ex)
                        End Try
                    End If
                    ModificaKey(mct, "false")
                    ModificaKey(ditron, "false")
                    ModificaKey(epson, "true")

            End Select

            If (Variables.Software.Value = "trilogis") Then
                Dim Conexion As New FbConnection
                Dim fb_string As FbConnectionStringBuilder = New FbConnectionStringBuilder With {
                .ServerType = FbServerType.Default,
                .UserID = Variables.UtenteDatabase.Value,
                .Password = Variables.PasswordDatabase.Value,
                .Database = "c:\trilogis\trilogislocalconf.fb20",
                .Pooling = False
                }
                Try
                    Conexion.ConnectionString = fb_string.ToString
                    Conexion.Open()
                    LogFile.WriteLog("Apertura connessione database configurazione (3Logis)")
                Catch err As FbException
                    MostraErrore(Me, "ERRORE APERTURA CONNESSIONE DATABASE", err)
                End Try

                LogFile.WriteLog("Avvio configurazione 3logis")
                Dim Command As String = "UPDATE CONFIGURAZIONE SET VALORE='0' WHERE PAGINAID=6 AND SUBPAGINAID=8 AND LIVELLOID=1 AND POSIZIONE=1"
                Dim Command2 As String = "UPDATE CONFIGURAZIONE SET VALORE='0' WHERE PAGINAID=6 AND SUBPAGINAID=8 AND LIVELLOID=1 AND POSIZIONE=2.1"
                Dim Command3 As String = "UPDATE CONFIGURAZIONE SET VALORE='False' WHERE PAGINAID=6 AND SUBPAGINAID=8 AND LIVELLOID=1 AND POSIZIONE=2"
                Dim Command4 As String = "UPDATE CONFIGURAZIONE SET VALORE='STAMPANTE FISCALE' WHERE PAGINAID=6 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=3.1"
                Dim Command5 As String = "UPDATE CONFIGURAZIONE SET VALORE='15' WHERE PAGINAID=6 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=3.7"
                Dim Command6 As String = "UPDATE CONFIGURAZIONE SET VALORE='90' WHERE PAGINAID=6 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=3.3"
                Dim Command7 As String = "UPDATE CONFIGURAZIONE SET VALORE='False' WHERE PAGINAID=6 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=3.31"
                Dim Command8 As String = "UPDATE CONFIGURAZIONE SET VALORE='True' WHERE PAGINAID=6 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=3.29"
                Dim Command9 As String = "UPDATE CONFIGURAZIONE SET VALORE='2' WHERE PAGINAID=4 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=3"
                Dim Command10 As String = "UPDATE CONFIGURAZIONE SET VALORE='True' WHERE PAGINAID=4 AND SUBPAGINAID=2 AND LIVELLOID=1 AND POSIZIONE=8.5"

                Dim execomand As New FbCommand(Command, Conexion)
                Dim execomand2 As New FbCommand(Command2, Conexion)
                Dim execomand3 As New FbCommand(Command3, Conexion)
                Dim execomand4 As New FbCommand(Command4, Conexion)
                Dim execomand5 As New FbCommand(Command5, Conexion)
                Dim execomand6 As New FbCommand(Command6, Conexion)
                Dim execomand7 As New FbCommand(Command7, Conexion)
                Dim execomand8 As New FbCommand(Command8, Conexion)
                Dim execomand9 As New FbCommand(Command9, Conexion)
                Dim execomand10 As New FbCommand(Command10, Conexion)
                execomand.ExecuteNonQuery()
                execomand2.ExecuteNonQuery()
                execomand3.ExecuteNonQuery()
                execomand4.ExecuteNonQuery()
                execomand5.ExecuteNonQuery()
                execomand6.ExecuteNonQuery()
                execomand7.ExecuteNonQuery()
                execomand8.ExecuteNonQuery()
                execomand9.ExecuteNonQuery()
                execomand10.ExecuteNonQuery()
                LogFile.WriteLog("Fine configurazione 3logis")

                LogFile.WriteLog("Chiusura connessione database configurazione (3Logis)")
                Conexion.Close()
                Conexion.Dispose()
            End If

            InizializzareInfoAggiuntivaScontrino()
            MostraAttenzione("Stampante " & Stampante & " impostata con sucesso. Riavvio PentaStart In corso...")
            LogFile.WriteLog("Fine impostazione Stampante " & Stampante & " (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
            RiavvioPentaStart()
        ElseIf (result = DialogResult.Abort) Then
            LogFile.WriteLog("Impostazione " & Stampante & " annullata")
            MostraAttenzione("Impostazione stampante " & Stampante & " annullata.")
        Else
            LogFile.WriteLog("Errore inserimento password")
            MostraErrore(Me, "ERRORE INSERIMENTO PASSWORD")
        End If
        LogFile.WriteLog("Fine impostazione Stampante " & Stampante & " (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
    End Sub

    Private Shared Sub InizializzareInfoAggiuntivaScontrino()
        Dim FormDomanda As New Domanda With {.Messagio = "Attivare la stampa del scontrino collegato alla transazione?"}
        Dim result3 As DialogResult = FormDomanda.ShowDialog()
        If (result3 = DialogResult.Yes) Then
            ModificaKey(DettaglioNScontrino, "true")
        Else
            ModificaKey(DettaglioNScontrino, "false")
        End If

        FormDomanda = New Domanda With {.Messagio = "Attivare la stampa dei capi collegati al acconto/recupero?"}
        Dim result4 As DialogResult = FormDomanda.ShowDialog()
        If (result4 = DialogResult.Yes) Then
            ModificaKey(DettaglioCapi, "true")
        Else
            ModificaKey(DettaglioCapi, "false")
        End If

        FormDomanda = New Domanda With {.Messagio = "Attivare stampa scontrino parlante?"}
        Dim result5 As DialogResult = FormDomanda.ShowDialog()
        If (result5 = DialogResult.Yes) Then
            ModificaKey(ScontrinoParlante, "True")
        Else
            ModificaKey(ScontrinoParlante, "False")
        End If
    End Sub

    Private Sub Indietro_Click(sender As Object, e As EventArgs) Handles ButtonINDITRO.Click
        Me.Hide()
        FormMain.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Variables.Software.Value = "trilogis") Then
            Me.Hide()
            If Utility.ControlloSoftwareAperto() Then
                Return
            End If
            AvvioTricovers.Show()
        Else
            MostraErrore(Me, "ERRORE IMPOSTAZIONE SOFTWARE.")
            Return
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Variables.Software.Value = "laundry") Then
            Me.Hide()
            If Utility.ControlloSoftwareAperto() Then
                Me.Show()
                Return
            End If
            AvvioTricovers.Show()
        Else
            MostraErrore(Me, "ERRORE IMPOSTAZIONE SOFTWARE. Software: " & Variables.Software.Value)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio impostazione Modulo SpeakerPronto")
        If Variables.Software.Value = "trilogis" Then
            Dim adminpassword As New AdminPassword()
            Dim result = adminpassword.ShowDialog()
            If (result = DialogResult.OK) Then
                If SpeakerNomePronto.Value = "true" Then
                    Dim FormDomanda As New Domanda With {.Messagio = "Disattivare modulo Speaker Nome Pronto?"}
                    Dim result9 As DialogResult = FormDomanda.ShowDialog()
                    If (result9 = DialogResult.Yes) Then
                        ModificaKey(SpeakerNomePronto, "null")
                        MostraAttenzione("Modulo Speaker Nome Pronto disattivato con sucesso." & Environment.NewLine & "Riavvio PentaStart In corso...")
                        LogFile.WriteLog("Fine impostazione Modulo SpeakerPronto (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
                        RiavvioPentaStart()
                    Else
                        Me.Activate()
                        Me.BringToFront()
                        Return
                    End If
                End If

                Dim FormDomanda2 As New Domanda With {.Messagio = "Attivare Modulo Speaker NomePronto?"}
                Dim result2 As DialogResult = FormDomanda2.ShowDialog()
                If (result2 = DialogResult.Yes) Then
                    ModificaKey(SpeakerNomePronto, "true")
                    MostraAttenzione("Modulo Speaker Nome Pronto attivato con sucesso." & Environment.NewLine & "Riavvio PentaStart In corso...")
                    LogFile.WriteLog("Fine impostazione Modulo SpeakerPronto (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
                    RiavvioPentaStart()
                Else
                    MostraAttenzione("Impostazione Modulo Speaker NomePronto annullata.")
                    Return
                End If
            Else
                MostraAttenzione("Impostazione Modulo Speaker NomePronto annullata.")
                Return
            End If
        Else
            MostraErrore(Me, "ERRORE IMPOSTAZIONE SOFTWARE. Software: " & Variables.Software.Value)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio impostazione Fatturazione Elettronica")
        If Variables.Software.Value = "trilogis" Then
            Dim adminpassword As New AdminPassword()
            Dim result = adminpassword.ShowDialog()
            If (result = DialogResult.OK) Then

                If FatturazioneElett.Value = "true" Then
                    Dim result9 As DialogResult = MessageBox.Show("Disattivare modulo Fatturazione Elettronica?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (result9 = DialogResult.Yes) Then
                        ModificaKey(FatturazioneElett, "false")
                        RiavvioPentaStart()
                    Else
                        Return
                    End If
                End If

                If (File.Exists(Path.GetPathRoot(Environment.SystemDirectory) + "trilogis\FattElett.exe") And Variables.Software.Value = "trilogis") Then
                    Dim result2 As DialogResult = MessageBox.Show("Attivare Fatturazione Elettronica (Generazione file XML)?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (result2 = DialogResult.Yes) Then
                        ModificaKey(FatturazioneElett, "true")
                        LogFile.WriteLog("Modulo Fatturazione Elettronica (Generazione file XML) attivato")
                        MsgBox("Modulo Fatturazione Elettronica (Generazione file XML) attivato.", MsgBoxStyle.OkOnly, "PentaStart")
                        LogFile.WriteLog("Richiesta percorso Fatturazione Elettronica")

                        Dim cercaspercorsofatt As FolderBrowserDialog = New FolderBrowserDialog With {
                            .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory),
                            .RootFolder = Environment.SpecialFolder.MyComputer,
                            .Description = "Scegliere il percorso dove salvare le fatture XML.",
                            .ShowNewFolderButton = True
                        }
                        If cercaspercorsofatt.ShowDialog() = DialogResult.OK Then
                            LogFile.WriteLog("Percorso Fatturazione Elettronica confermato. (" + cercaspercorsofatt.SelectedPath + ")")
                            ModificaKey(PercorsoFatture, cercaspercorsofatt.SelectedPath)
                        Else
                            LogFile.WriteLog("Impostazione Fatturazione Elettronica annullata")
                            ModificaKey(PercorsoFatture, "null")
                        End If
                        LogFile.WriteLog("Percorso Fatture impostato.Riavvio PentaStart in corso...")
                        LogFile.ChisuraProgramma()
                        MsgBox("Percorso Fatture impostato. Riavvio PentaStart in corso..
" + cercaspercorsofatt.SelectedPath, MsgBoxStyle.OkOnly, "PentaStart")
                        Application.Restart()
                    Else
                        ModificaKey(FatturazioneElett, "false")
                        LogFile.WriteLog("Modulo Fatturazione Elettronica (Generazione file XML) disattivato.")
                        MsgBox("Modulo Fatturazione Elettronica (Generazione file XML) disattivato.", MsgBoxStyle.OkOnly, "PentaStart")
                    End If
                ElseIf (Variables.Software.Value <> "trilogis") Then
                    LogFile.WriteLog("Richiesta percorso Fatturazione Elettronica")
                    Dim cercaspercorsofatt As FolderBrowserDialog = New FolderBrowserDialog With {
                        .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory),
                        .RootFolder = Environment.SpecialFolder.MyComputer,
                        .Description = "Scegliere il percorso dove cercare le fatture XML.",
                        .ShowNewFolderButton = True
                    }
                    If cercaspercorsofatt.ShowDialog() = DialogResult.OK Then
                        LogFile.WriteLog("Percorso Fatturazione Elettronica confermato. (" + cercaspercorsofatt.SelectedPath + ")")
                        ModificaKey(PercorsoFatture, cercaspercorsofatt.SelectedPath)
                    Else
                        LogFile.WriteLog("Percorso Fatturazione Elettronica cancellato.")
                        ModificaKey(PercorsoFatture, "null")
                    End If
                    LogFile.WriteLog("Percorso Fatture impostato.Riavvio PentaStart in corso...")
                    MsgBox("Percorso Fatture impostato. Riavvio PentaStart in corso..
" + cercaspercorsofatt.SelectedPath, MsgBoxStyle.OkOnly, "PentaStart")
                    RiavvioPentaStart()
                End If
            Else
                LogFile.WriteLog("Errore inserimento password")
                MsgBox("Errore password.", MsgBoxStyle.Critical, "PentaStart")

            End If
        Else
            LogFile.WriteLog("Errore impostazione software. (Software: " + Variables.Software.Value + ")")
            MsgBox("Errore impostazione software.", MsgBoxStyle.Critical, "PentaStart")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio impostazione Modulo SYNC")


        Dim adminpassword As New AdminPassword()
        Dim resultpassword = adminpassword.ShowDialog()
        If (resultpassword = DialogResult.OK) Then

            If InvioSYNC.Value = "true" Then
                Dim result9 As DialogResult = MessageBox.Show("Disattivare Invio SYNC?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result9 = DialogResult.Yes) Then
                    ModificaKey(InvioSYNC, "false")
                    RiavvioPentaStart()
                Else
                    Return
                End If
            End If


            Dim sceltapercorsosync As FolderBrowserDialog = New FolderBrowserDialog()
            sceltapercorsosync.Description = "Specificare la cartella dove si trova il SYNC"
            sceltapercorsosync.RootFolder = Environment.SpecialFolder.MyComputer
            sceltapercorsosync.ShowNewFolderButton = False
            LogFile.WriteLog("Richiesta percorso SYNC")
            Dim resultcartella As DialogResult = sceltapercorsosync.ShowDialog()
            If resultcartella = DialogResult.OK Then
                LogFile.WriteLog("Percorso SYNC scelto: " + sceltapercorsosync.SelectedPath)
                If (File.Exists(sceltapercorsosync.SelectedPath + "\BrainTeamFatturaElettronica.exe")) Then
                    LogFile.WriteLog("Percorso SYNC confermato: " + sceltapercorsosync.SelectedPath)
                    ModificaKey(PercorsoSYNC, sceltapercorsosync.SelectedPath)

                    Dim result As DialogResult = MessageBox.Show("Attivare invio SYNC?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        LogFile.WriteLog("Richiesta percorso 1.mmmacro (MiniMouse)")
                        Dim sceltapercorsomacro As FolderBrowserDialog = New FolderBrowserDialog()
                        sceltapercorsomacro.Description = "Specificare la cartella dove si trova 1.mmmacro (Cartella software)"
                        sceltapercorsomacro.RootFolder = Environment.SpecialFolder.MyComputer
                        sceltapercorsomacro.ShowNewFolderButton = False
                        Dim dialogresult As DialogResult = sceltapercorsomacro.ShowDialog()
                        If dialogresult = DialogResult.OK Then
                            LogFile.WriteLog("Percorso 1.mmmacro (MiniMouse) scelto: " + sceltapercorsomacro.SelectedPath)
                            ModificaKey(PercorsoMacroMiniMouse, sceltapercorsomacro.SelectedPath)
                            CreateRegFile(sceltapercorsomacro.SelectedPath)
                            Process.Start(sceltapercorsomacro.SelectedPath + "\Macro.reg").WaitForExit()
                        Else
                            Return
                        End If
                        Dim FormCoordinate As CoordinateSYNC = New CoordinateSYNC()
                        FormCoordinate.PercorsoMacro = sceltapercorsomacro.SelectedPath
                        FormCoordinate.PercorsoSync = Variables.PercorsoSYNC.Value
                        Dim risultatocoor As DialogResult = FormCoordinate.ShowDialog()
                        If risultatocoor = DialogResult.OK Then
                            Dim ini As New IniFile
                            ini.Load(Application.StartupPath + "\PentaStart.ini")
                            ini.SetKeyValue("MODULI", "InvioSYNC", "true")
                            ini.Save(Application.StartupPath + "\PentaStart.ini")
                            MsgBox("Modulo invio SYNC attivato. Riavvio PentaStart in corso..", MsgBoxStyle.OkOnly, "PentaStart")
                            Variables.InvioSYNC.Value = "true"
                            Application.Restart()
                        Else
                            Return
                        End If
                    Else
                        ModificaKey(InvioSYNC, "false")
                        MsgBox("Modulo invio SYNC disattivato.", MsgBoxStyle.OkOnly, "PentaStart")
                    End If
                    LogFile.WriteLog("Modulo SYNC attivato.Riavvio PentaStart in corso...")
                    MsgBox("Modulo SYNC attivato. Riavvio PentaStart in corso...", MsgBoxStyle.OkOnly, "PentaStart")
                    RiavvioPentaStart()
                Else
                    LogFile.WriteLog("Errore attivazione Modulo SYNC. BrainTeamFatturaElettronica non trovato ")
                    MsgBox("ERRORE MODULO.
Modulo SYNC non installato.
Percorso: " + Variables.PercorsoSYNC.Value, MsgBoxStyle.Critical, "PentaStart")
                End If
            Else
                LogFile.WriteLog("Impostazione Modulo SYNC annullato")

            End If
        Else
            LogFile.WriteLog("Errore inserimento password")
            MsgBox("Errore password.", MsgBoxStyle.Critical, "PentaStart")

            Return
        End If
        LogFile.WriteLog("Fine impostazione Modulo SYNC (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
    End Sub

    Private Sub CreateRegFile(path As String)
        Dim regstring As String = "Windows Registry Editor Version 5.00" + Environment.NewLine +
                                Environment.NewLine +
                                "[HKEY_CURRENT_USER\Software\Turnssoft]" + Environment.NewLine +
                                Environment.NewLine +
                                "[HKEY_CURRENT_USER\Software\Turnssoft\MiniMouseMacroPro]" + Environment.NewLine +
                                """Minimize To System Tray"" = ""True""" + Environment.NewLine +
                                """Version"" = ""7.1.0.0""" + Environment.NewLine +
                                """On Top Enabled"" = ""False""" + Environment.NewLine +
                                """On Top Remove"" = ""False""" + Environment.NewLine +
                                """Exit After Macro"" = ""False""" + Environment.NewLine +
                                """Disable Tray Notification"" = ""True""" + Environment.NewLine +
                                """Disable Tray Icon"" = ""False""" + Environment.NewLine +
                                """Run at System Startup"" = ""False""" + Environment.NewLine +
                                """Startup Path"" = """"" + Environment.NewLine +
                                """Start Minimized"" = ""True""" + Environment.NewLine +
                                """Auto Shrink Play"" = ""False""" + Environment.NewLine +
                                """Auto Shrink Record"" = ""False""" + Environment.NewLine +
                                """Auto Relist on Play"" = ""False""" + Environment.NewLine +
                                """Disable Mouse Playback"" = ""False""" + Environment.NewLine +
                                """Never Write To INI"" = ""False""" + Environment.NewLine +
                                """Disable Key Duplicates"" = ""True""" + Environment.NewLine +
                                """Control Mouse Capture"" = ""True""" + Environment.NewLine +
                                """Run Macro on Open"" = ""False""" + Environment.NewLine +
                                """Edit Macro on Open"" = ""False""" + Environment.NewLine +
                                """Hide Menu"" = ""False""" + Environment.NewLine +
                                """Hide Top Panel"" = ""False""" + Environment.NewLine +
                                """Hide Bottom Panel"" = ""False""" + Environment.NewLine +
                                """Hide Bottom Bar"" = ""False""" + Environment.NewLine +
                                """Save Size on Exit"" = ""False""" + Environment.NewLine +
                                """Enable Event Logging"" = ""False""" + Environment.NewLine +
                                """Main Window Width"" = dword : 0000016b" + Environment.NewLine +
                                """Main Window Height""=dword:0000017d" + Environment.NewLine +
                                """Main Window X""=dword:00000000" + Environment.NewLine +
                                """Main Window Y""=dword:00000000" + Environment.NewLine +
                                """Record to File""=""False""" + Environment.NewLine +
                                """Record to File Append""=""False""" + Environment.NewLine +
                                """Record to File Path""=""" + path.Replace("\", "\\") + "\\MMM_out.mmmacro""" + Environment.NewLine +
                                """Delimiter""="" | """ + Environment.NewLine +
                                """Hotkey Mouse Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Mouse Key""=""F7""" + Environment.NewLine +
                                """Hotkey Mouse Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Record Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Record Key""=""F8""" + Environment.NewLine +
                                """Hotkey Record Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Stop Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Stop Key""=""F10""" + Environment.NewLine +
                                """Hotkey Stop Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Clear Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Clear Key""=""F12""" + Environment.NewLine +
                                """Hotkey Clear Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Pause Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Pause Key""=""F9""" + Environment.NewLine +
                                """Hotkey Pause Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Play Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Play Key""=""F11""" + Environment.NewLine +
                                """Hotkey Play Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Stop Playback Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Stop Playback Key""=""F6""" + Environment.NewLine +
                                """Hotkey Stop Playback Enabled""=""True""" + Environment.NewLine +
                                """Hotkey Master Kill Enabled""=""False""" + Environment.NewLine +
                                """Hotkey Master Kill Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Master Kill Key""=""K""" + Environment.NewLine +
                                """Hotkey Playback Faster Enabled""=""False""" + Environment.NewLine +
                                """Hotkey Playback Faster Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Playback Faster Key""=""P""" + Environment.NewLine +
                                """Hotkey Playback Slower Enabled""=""False""" + Environment.NewLine +
                                """Hotkey Playback Slower Modifier""=dword:00000001" + Environment.NewLine +
                                """Hotkey Playback Slower Key""=""O""" + Environment.NewLine +
                                """Disable Keyboard Capture""=""False""" + Environment.NewLine +
                                """Disable Mouse Click Capture""=""False""" + Environment.NewLine +
                                """Disable Drag And Drop""=""True""" + Environment.NewLine +
                                """Multi-key Capture""=""True""" + Environment.NewLine +
                                """Ignore Shift""=""True""" + Environment.NewLine +
                                """Ignore Left Shift""=""True""" + Environment.NewLine +
                                """Ignore Right Shift""=""True""" + Environment.NewLine +
                                """Ignore Ctrl""=""True""" + Environment.NewLine +
                                """Ignore Left Ctrl""=""True""" + Environment.NewLine +
                                """Ignore Right Ctrl""=""True""" + Environment.NewLine +
                                """Ignore Alt""=""True""" + Environment.NewLine +
                                """Ignore Left Alt""=""True""" + Environment.NewLine +
                                """Ignore Right Alt""=""True""" + Environment.NewLine +
                                """Quick Launch Row Count""=dword:00000001" + Environment.NewLine +
                                """Macro Queue Enabled""=""True""" + Environment.NewLine +
                                """Macro Queue Startup Enabled""=""True""" + Environment.NewLine +
                                """Macro Queue Loop Enabled""=""False""" + Environment.NewLine +
                                """Macro Queue Loop Value""=dword:00000000" + Environment.NewLine +
                                """Macro Queue Row Count""=dword:00000001" + Environment.NewLine +
                                """Disable Update Check""=""False""" + Environment.NewLine +
                                """Disable Update Notification""=""False""" + Environment.NewLine +
                                """Delete Registry On Exit""=""False""" + Environment.NewLine +
                                """Delete INI On Exit""=""False""" + Environment.NewLine +
                                """Events All""=dword:00001388" + Environment.NewLine +
                                """Events Info""=dword:000003e8" + Environment.NewLine +
                                """Events Warning""=dword:000003e8" + Environment.NewLine +
                                """Events Error""=dword:000003e8" + Environment.NewLine +
                                """Events Macro""=dword:000003e8" + Environment.NewLine +
                                """Events Recording""=dword:000003e8" + Environment.NewLine +
                                """Events Log Entry Limit""=dword:000009c4" + Environment.NewLine +
                                """Enable Sound Success""=""False""" + Environment.NewLine +
                                """Enable Sound Fail""=""False""" + Environment.NewLine +
                                """Enable Sound Error""=""False""" + Environment.NewLine +
                                """Sound Success""=""Success High""" + Environment.NewLine +
                                """Sound Fail""=""Fail High""" + Environment.NewLine +
                                """Sound Error""=""Error High""" + Environment.NewLine +
                                """Clear Variables on Playback""=""False""" + Environment.NewLine +
                                """Enable Variable Saves""=""False""" + Environment.NewLine +
                                """Key Capture Rate""=dword:00000096" + Environment.NewLine +
                                """Mouse Capture Rate""=dword:0000000a" + Environment.NewLine +
                                """.mmmacro File Association""=""False""" + Environment.NewLine +
                                """Macro Font""=""Name=Palatino Linotype, Size=9, Units=3""" + Environment.NewLine +
                                """Macro Color""=""Color [ForestGreen]""" + Environment.NewLine +
                                """Enable Key Down Capture""=""False""" + Environment.NewLine +
                                """Event Log Output To File""=""False""" + Environment.NewLine +
                                """Event Log Overwrite""=""False""" + Environment.NewLine +
                                """Event Log Output File""=""""" + Environment.NewLine +
                                """Recent Macro Count""=dword:00000001" + Environment.NewLine +
                                """INTEGER""=dword:00000000" + Environment.NewLine +
                                """INTEGER1""=dword:00000000" + Environment.NewLine +
                                """INTEGER2""=dword:00000000" + Environment.NewLine +
                                """INTEGER3""=dword:00000000" + Environment.NewLine +
                                """INTEGER4""=dword:00000000" + Environment.NewLine +
                                """STRING""=""""" + Environment.NewLine +
                                """STRING1""=""""" + Environment.NewLine +
                                """STRING2""=""""" + Environment.NewLine +
                                """STRING3""=""""" + Environment.NewLine +
                                """STRING4""=""""" + Environment.NewLine +
                                """Recent Macro 0""=""C:\\trilogis\\1.mmmacro""" + Environment.NewLine +
                                """Quick Launch Row 0""=""1|True|" + path.Replace("\", "\\") + "\\1.mmmacro|False|False|False|0|False|0|[None]|F6""" + Environment.NewLine +
                                """Macro Queue Row 0""=""1|True|" + path.Replace("\", "\\") + "\\1.mmmacro|False|False|0|False|0"""
        LogFile.WriteLog("Scrittura file Macro.reg in corso...")
        File.WriteAllText(path + "\Macro.reg", regstring)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio impostazione Archiviazione Database")


        Dim adminpassword As New AdminPassword()
        Dim result = adminpassword.ShowDialog()
        If (result = DialogResult.OK) Then

            If Variables.Software.Value = "trilogis" Then
                Dim result2 = MessageBox.Show("Attivare archiviazione database in chiusura?", "PentaStart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result2 = DialogResult.Yes) Then
                    Dim unitaarc As New UnitaArchiviazioneStorico()
                    Dim unita = unitaarc.ShowDialog()
                    If unita = DialogResult.OK Then
                        LogFile.WriteLog("Tipo Archiviazione scelto: " + unitaarc.TipoArchiviazione)
                        LogFile.WriteLog("Unita Archiviazione scelta: " + unitaarc.UnitaArchiviazione)
                        ModificaKey(TipoArchiviazione, unitaarc.TipoArchiviazione)
                        ModificaKey(UnitaArchiviazione, unitaarc.UnitaArchiviazione)
                        LogFile.WriteLog("Archiviazione attivata con succeso. Riavvio PentaStart in corso...")
                        LogFile.ChisuraProgramma()
                        MessageBox.Show("Archiviazione attivata con succeso. Riavvio PentaStart in corso...", "PentaStart")
                        Application.Restart()
                    End If
                End If
            End If
        Else
            LogFile.WriteLog("Errore inserimento password")
            MsgBox("Errore password.", MsgBoxStyle.Critical, "PentaStart")

        End If
    End Sub

    Private Sub ButtonLogoPenta_Click(sender As Object, e As EventArgs) Handles ButtonLogoPenta.Click
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio impostazione Logo Penta")


        Dim adminpassword As New AdminPassword()
        Dim result = adminpassword.ShowDialog()
        If (result = DialogResult.OK) Then
            Dim fmTipoLogo As New TipoLogoPenta()
            Dim tipologo = fmTipoLogo.ShowDialog()
            Select Case tipologo
                Case DialogResult.Yes
                    LogFile.WriteLog("Logo Penta scelto: 1 - In Alto")
                    ModificaKey(LogoPenta, "1")
                Case DialogResult.No
                    LogFile.WriteLog("Logo Penta scelto: 2 - In Basso")
                    ModificaKey(LogoPenta, "2")
                Case DialogResult.Cancel
                    LogFile.WriteLog("Logo Penta scelto: 3 - Nessuno")
                    ModificaKey(LogoPenta, "false")
                Case Else
                    Return
            End Select
            LogFile.WriteLog("Fine impostazione Logo Penta (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
        Else
            LogFile.WriteLog("Errore inserimento password")
            MsgBox("Errore password.", MsgBoxStyle.Critical, "PentaStart")

        End If
    End Sub

    Private Sub AggSoftware_Click(sender As Object, e As EventArgs) Handles AggSoftware.Click
        If AggiornamentiAttivi() Then
            Dim result As DialogResult = MessageBox.Show("Si desidera aggiornare PentaStart?", "PentaStart", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                LogFile.WriteLog("Rilevato aggiornamento forzato")
                FormMain.AggiornamentoPenta()
            Else
                Return
            End If
        End If
    End Sub
End Class

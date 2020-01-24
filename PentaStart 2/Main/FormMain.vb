Imports System.IO
Imports System.Timers
Imports FirebirdSql.Data.FirebirdClient
Imports IWshRuntimeLibrary
Imports Microsoft.Win32
Imports File = System.IO.File
Imports PentaStart.Utility
Imports PentaStart.Variables
Imports System.Net
Imports System.Globalization

Public Class FormMain
    Private FileScontrinoComusDitron As FileSystemWatcher
    Private regKey As RegistryKey
    Private SoftwareScaduto As Boolean
    Private AvvisoScadenzaAssistenza As Boolean
    Private FormLogoPenta As BannerLogoPenta

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LogFile.InizializzareLog()
            InizializzareRegistro()
            ControlloScadenzaAssistenza()
            ControlloScadenzaSoftware()
            InizializzareFileIni()
            ControlloAggiornamenti()
            BackupDatabase()
            InizializzareSYNC()
            ControlloArchiviazione()
            ComusWinECR()
            ControlloStorico()
            AvvioProgramma()
        Catch ex As Exception
            MostraErrore(Me, "ERRORE CRITICO AVVIO PROGRAMMA. CONTATTERE L'ASSISTENZA.", ex)
            Application.Restart()
        End Try
    End Sub

    Private Sub ControlloAggiornamenti()
        LogFile.WriteLog("Avvio controllo aggiornamenti")
        If AggiornamentiAttivi() Then
            If ControlloConnessionePenta() Then
                LogFile.WriteLog("Connessione internet trovata")
                LogFile.WriteLog("Data di controllo aggiornamento: " & Date.ParseExact(DataProssimoAggiornamento.Value, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"))
                If DataProssimoAggiornamento.Value <= Now.ToString("yyyyMMdd") Then
                    ModificaKey(ForzareAggiornamento, Now.AddDays(7).ToString("yyyyMMdd"))
                    AggiornamentoPenta()
                ElseIf ForzareAggiornamento.Value = "true" Then
                    ModificaKey(ForzareAggiornamento, "false")
                    DataProssimoAggiornamento.Value = Now.AddDays(7).ToString("yyyyMMdd")
                    LogFile.WriteLog("Rilevato aggiornamento forzato")
                    AggiornamentoPenta()
                End If
            Else
                LogFile.WriteLog("Nessuna connessione internet trovata")
                LogFile.WriteLog("Controllo aggiornamenti annullato")
            End If
        ElseIf ForzareAggiornamento.Value = "true" Then
            ModificaKey(ForzareAggiornamento, "false")
            LogFile.WriteLog("Rilevato aggiornamento forzato")
            AggiornamentoPenta()
        End If
    End Sub

    Public Sub AggiornamentoPenta()
        LogFile.WriteLog("Avvio PentaUpdate.exe in corso...")
        ChiusuraProgramma("FattElett")
        ChiusuraProgramma("ScontrinoPenta")
        ChiusuraProgramma("NomePronto")
        LogFile.ChisuraProgramma()
        Try
            Process.Start(Application.StartupPath & "/PentaUpdate.exe")
            Environment.Exit(0)
        Catch ex As Exception
            MostraErrore(Me, "Errore apertura PentaUpdate", ex)
            Return
        End Try
    End Sub

    Public Shared Function ControlloConnessionePenta() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.pentaelectronic.eu")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub AvvioProgramma()
        If Esecuzione.Value = "true" Then
            If (Software.Value <> "null") Then
                If (Software.Value = "trilogis") Then
                    While AttendereAvvioFirebird() = False
                        AttendereAvvioFirebird()
                    End While
                    Label2.Visible = False
                    NascondereTrilogisExe()
                    ControlloIstanzaAperta("C:\trilogis\trilogis.exe")

                    If SoftwareScaduto = False Then
                        Dim trilogis As System.Diagnostics.Process = New System.Diagnostics.Process()
                        AvvioScontrinoPenta()
                        InizializzareSpeakerPronto()
                        InizializzareFattElettTrilogis()
                        trilogis.StartInfo.FileName = "C:\trilogis\trilogis.exe"
                        If AvvisoScadenzaAssistenza Then
                            SAT.Show()
                        End If
                        trilogis = ControlloLogoPenta(trilogis)
                        trilogis.Start()
                    End If
                ElseIf (Software.Value = "laundry") Then
                    ControlloIstanzaAperta("Errezeta2.Laundry.PocketSync")
                    Process.Start("C:\Program Files (x86)\Laundry32\Laundry.PocketSync\Errezeta2.Laundry.PocketSync.exe")
                    If AvvisoScadenzaAssistenza Then
                        SAT.Show()
                    End If
                ElseIf (Software.Value = "menu") Then
                    ControlloIstanzaAperta("Menù")
                    Process.Start("C:\Menù\Menù.exe")
                    If AvvisoScadenzaAssistenza Then
                        SAT.Show()
                    End If
                ElseIf (Software.Value = "comus") Then
                    ControlloIstanzaAperta("Comus")
                    Process.Start("C:\COMUS32\Comus.exe")
                    If AvvisoScadenzaAssistenza Then
                        SAT.Show()
                    End If
                Else
                    MostraErrore(Me, "Errore impostazione software")
                    Me.Show()
                End If
            End If
        Else
            AvvioScontrinoPenta()
        End If
    End Sub

    Private Function ControlloLogoPenta(trilogis As Process) As Process
        If LogoPenta.Value = "1" Or LogoPenta.Value = "2" Then
            FormLogoPenta = New BannerLogoPenta()
            FormLogoPenta.WindowState = FormWindowState.Maximized
            FormLogoPenta.Focus()
            FormLogoPenta.Show()
            FormLogoPenta.TopMost = True
            FormLogoPenta.WindowState = FormWindowState.Normal
            FormLogoPenta.Activate()
            trilogis.EnableRaisingEvents = True
            AddHandler trilogis.Exited, AddressOf ChiusuraTrilogis
        End If
        Return trilogis
    End Function

    Private Shared Sub NascondereTrilogisExe()
        Dim path As String = "C:\trilogis\trilogis.exe"
        FileSystem.SetAttr(path, FileAttribute.Hidden)
    End Sub

    Private Sub ControlloStorico()
        If Software.Value = "trilogis" And TipoArchiviazione.Value = "2" Then
            Buttonnas.Text = "Storico"
        Else
            Buttonnas.Text = "SMS"
        End If
    End Sub

    Private Sub AvvioScontrinoPenta()
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio caricamento ScontrinoPenta")
        ControlloDriverInvioScontrino()
        RiavvioProgrammaScontrinoPenta()
        LogFile.WriteLog("Fine caricamento ScontrinoPenta (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
    End Sub

    Private Sub ComusWinECR()
        If Software.Value = "comus" And EsisteStampanteDitron() Then
            LogFile.WriteLog("Avvio inizializzazione WinEcr per COMUS")
            FileScontrinoComusDitron = New FileSystemWatcher()
            FileScontrinoComusDitron.IncludeSubdirectories = False
            If PercorsoWinEcr.Value = "null" Then
                Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                    .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory),
                    .RootFolder = Environment.SpecialFolder.MyComputer,
                    .Description = "Scegliere il percorso de WinEcr.",
                    .ShowNewFolderButton = False
                }
                If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                    Dim ini As New IniFile()
                    ModificaKey(PercorsoWinEcr, cercaspercorsodb.SelectedPath)
                End If
                PercorsoWinEcr.Value = cercaspercorsodb.SelectedPath
            End If
            FileScontrinoComusDitron.Path = PercorsoWinEcr.Value
            FileScontrinoComusDitron.Filter = "scontrini.txt"
            FileScontrinoComusDitron.NotifyFilter = NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName
            AddHandler FileScontrinoComusDitron.Created, AddressOf FileSystemWatcher1_Created
            FileScontrinoComusDitron.EnableRaisingEvents = True

            Directory.CreateDirectory(PercorsoWinEcr.Value & "\TOSEND")

            ChiusuraProgramma("SoEcrCom")
            Process.Start(Application.StartupPath & "/SoEcrCom.lnk")
            LogFile.WriteLog("Fine inizializzazione WinEcr per COMUS")
        End If
    End Sub

    Private Sub InizializzareFattElettTrilogis()
        If (FatturazioneElett.Value = "true") Then
            LogFile.WriteLog("Avvio inizializzazione Fatturazione Elettronica")
            ChiusuraProgramma("FattElett")
            AvviareProgramma("C:\trilogis\FattElett.exe")
            LogFile.WriteLog("Fine inizializzazione Fatturazione Elettronica")
        End If
    End Sub

    Private Sub InizializzareSpeakerPronto()
        If (SpeakerNomePronto.Value = "true") Then
            LogFile.WriteLog("Avvio inizializzazione SpeakerNomePronto")
            ChiusuraProgramma("NomePronto")
            AvviareProgramma("C:\trilogis\NomePronto.exe")
            LogFile.WriteLog("Fine inizializzazione SpeakerNomePronto")
        End If
    End Sub

    Private Sub ControlloArchiviazione()
        If Software.Value = "laundry" Then
            If TipoArchiviazione.Value = "1" Then
                LogFile.WriteLog("Avvio AggDatabase (Laundry) - Rilevato Tipo Archiviazione: 1 (Al avvio)")
                Try
                    Process.Start("C:\Program Files (x86)\Laundry32\AggDatabase.exe").WaitForExit()
                Catch ex As Exception
                    MostraErrore(Me, "Impossibile trovare software Archiviazione", ex)
                End Try
            ElseIf TipoArchiviazione.Value = "3" Then
                LogFile.WriteLog("Avvio AggDatabase (Laundry) - Rilevato Tipo Archiviazione: 3 (Ogni 180 secondi)")
                Dim Timer3 As System.Timers.Timer = New Timers.Timer(180000)
                AddHandler Timer3.Elapsed, AddressOf OnTimedEvent
                Timer3.Enabled = True
            End If
        End If
    End Sub

    Private Sub InizializzareSYNC()
        If (InvioSYNC.Value = "true") Then
            If (PercorsoFatture.Value <> "null") Then
                Dim paths() As String = IO.Directory.GetFiles(PercorsoFatture.Value, "*.xml")
                Try
                    If paths.Length > 0 Then
                        Buttonfattelett.Text = "Fatt. Elettronica (" & paths.Length.ToString() & ")"
                        Me.Hide()
                        InvioFatture.ShowDialog()
                    End If
                    Dim testWatcher As FileSystemWatcher = New FileSystemWatcher(PercorsoFatture.Value, "*.xml")
                    AddHandler testWatcher.Created, AddressOf NuovaFattXML
                Catch ex As Exception
                    MostraErrore(Me, "Errore percorso fatture.", ex)
                End Try
                Buttonfattelett.Text = "Fatt. Elettronica (" & paths.Length.ToString() & ")"
                Me.Show()
            End If
        ElseIf (PercorsoFatture.Value <> "null") And (FatturazioneElett.Value = "true") Then
            Try
                Dim paths() As String = IO.Directory.GetFiles(PercorsoFatture.Value, "*.xml")
                If paths.Length > 0 Then
                    Buttonfattelett.Text = "Fatt. Elettronica (" & paths.Length.ToString() & ")"
                End If
            Catch ex As Exception
                MostraErrore(Me, "Errore percorso fatture.", ex)
            End Try
        End If
    End Sub

    Private Sub NuovaFattXML(sender As Object, e As FileSystemEventArgs)
        Dim paths() As String = IO.Directory.GetFiles(PercorsoFatture.Value, "*.xml")
        If paths.Length > 0 Then
            Buttonfattelett.Text = "Fatt. Elettronica (" & paths.Length.ToString() & ")"
        End If
    End Sub

    Private Sub BackupDatabase()
        Dim currday As Integer = Date.Now.DayOfYear
        If PercorsoBackup.Value <> "" Then
            Dim fecha = DateTime.Now.ToString("dd-MM-yyyy")
            Select Case currday
                Case 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365
                    Dim Backups = Directory.GetDirectories(PercorsoBackup.Value & "\Backups")
                    Dim quantitaBkps As Integer = Backups.Length
                    If quantitaBkps > 4 Then
                        Dim bkpvecchio As DirectoryInfo = Backups(0)
                        For Each bkp As DirectoryInfo In Backups
                            If bkp.CreationTime < bkpvecchio.CreationTime Then
                                bkpvecchio = bkp
                            End If
                        Next
                        Directory.Delete(bkpvecchio.FullName)
                    End If
                    If (Software.Value = "trilogis") Then
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\trilogis.fb20", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\trilogis.fb20", True)
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\trilogislocalconf.fb20", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\trilogislocalconf.fb20", True)
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\trilogisremoteconf.fb20", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\trilogisremoteconf.fb20", True)
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\trilogis.ini", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\trilogis.ini", True)
                    ElseIf (Software.Value = "laundry") Then
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\Database.mdb", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\Database-" & fecha & ".mdb", True)
                    ElseIf (Software.Value = "menu") Then
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\Banchetti.mdb", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\Database-" & fecha & ".mdb", True)
                    ElseIf (Software.Value = "comus") Then
                        FileIO.FileSystem.CopyFile(PercorsoDatabase.Value & "\Comus.mdb", PercorsoBackup.Value & "\Backups\Backup " & fecha & "\Database-" & fecha & ".mdb", True)
                    End If
            End Select
        End If
    End Sub

    Private Sub ControlloScadenzaSoftware()
        LogFile.WriteLog("Avvio controllo scadenza software")
        Dim percorsodemo As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\sdc.dll"
        If File.Exists(percorsodemo) Then
            LogFile.WriteLog("Trovato file controllo DEMO")
            If Now < My.Settings.scadenzademo Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\PENTA", True)
                Dim ver = regKey.GetValue("Control", 0.0)
                If Now < ver Then
                    MostraErrore(Me, "Aggionare Data e Ora del computer.")
                    SoftwareScaduto = True
                    regKey.Close()
                    LogFile.WriteLog("Modificata data di windows (Trovata data precedente)")
                    LogFile.ChisuraProgramma()
                    Environment.Exit(0)
                Else
                    SoftwareScaduto = False
                    regKey.SetValue("Control", Now)
                    regKey.Close()
                End If
                AggiornaLabelScadenzaSoftware()
            Else
                BloccoSoftware()
            End If
        End If
        LogFile.WriteLog("Fine controllo scadenza software")
    End Sub

    Private Sub BloccoSoftware()
        LogFile.WriteLog("Certificato software Penta scaduto.")
        SoftwareScaduto = True
        regKey = Registry.CurrentUser.OpenSubKey("Software\PENTA", True)
        regKey.SetValue("Control", Now)
        Dim trilogis As String = "C:\trilogis\trilogis.exe"
        Dim laundry As String = "C:\Program Files (x86)\Laundry32\Laundry.PocketSync\Errezeta2.Laundry.PocketSync.exe"
        Dim menu As String = "C:\Menù\Menù.exe"
        Dim COMUS As String = "C:\COMUS32\Comus.exe"
        If System.IO.File.Exists(trilogis) Then
            FileIO.FileSystem.RenameFile(trilogis, "scd.dll")
        ElseIf System.IO.File.Exists(laundry) Then
            FileIO.FileSystem.RenameFile(laundry, "scd.dll")
        ElseIf System.IO.File.Exists(menu) Then
            FileIO.FileSystem.RenameFile(menu, "scd.dll")
        ElseIf System.IO.File.Exists(COMUS) Then
            FileIO.FileSystem.RenameFile(COMUS, "scd.dll")
        End If
        MsgBox("The program can't start because CERT140.dll is missing or corrupt from your computer.
Try reinstalling the program to fix this problem.", MsgBoxStyle.Critical, "PentaStart.exe - System Error")
        MsgBox("An error occurred whe unpacking
CERT140.dll returned an error code: -1.

ERROR: Expired certificate " + Now.ToString("yyyyMMdd") + ".", MsgBoxStyle.Critical, "PentaStart.exe - System Error")
        MsgBox("Certificato software Penta Electronic scaduto.", MsgBoxStyle.Critical, "PentaStart.exe - System Error")
        LogFile.ChisuraProgramma()
        Environment.Exit(0)
    End Sub

    Private Sub AggiornaLabelScadenzaSoftware()
        LogFile.WriteLog("Avvio aggiornamento messagio PentaStart")
        Select Case DateDiff(DateInterval.Day, Now, My.Settings.scadenzademo)
            Case 15, 10, 7, 6, 5, 4, 3, 2, 1
                Label.Text = "Verificare certificato software.
Rimasti: " & DateDiff(DateInterval.Day, Now, My.Settings.scadenzademo) & " giorni alla scadenza."
                Label.ForeColor = Color.DarkRed
                LogFile.WriteLog("Rimangono " & DateDiff(DateInterval.Day, Now, My.Settings.scadenzademo) & " giorni fino alla scadenza della assistenza.")
            Case 0
                Label.Text = "Verificare certificato software.
Rimasto: " & DateDiff(DateInterval.Day, Now, My.Settings.scadenzademo) & " giorno alla scadenza."
                Label.ForeColor = Color.DarkRed
                LogFile.WriteLog("Rimane " & DateDiff(DateInterval.Day, Now, My.Settings.scadenzademo) & " giorno fino alla scadenza del software della assistenza.")
        End Select
        LogFile.WriteLog("Fine aggiornamento messagio PentaStart")
    End Sub

    Private Sub InizializzareRegistro()
        LogFile.WriteLog("Avvio inizializzazione registro")
        Dim createkey As Boolean
        Dim keyName As String = "HKEY_CURRENT_USER\Software\PENTA"
        Dim valueName As String = "SAT"
        Try
            Dim null = Registry.GetValue(keyName, valueName, "null").ToString()
            createkey = False
            LogFile.WriteLog("Key " + keyName + " trovata")
        Catch ex As Exception
            createkey = True
            LogFile.WriteLog("Key " + keyName + " non trovata")
        End Try
        If createkey Then
            LogFile.WriteLog("Avvio creazione Key " + keyName)
            Dim firstRunDate As Date = Now
            regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", True)
            regKey.CreateSubKey("PENTA")
            regKey = Registry.CurrentUser.OpenSubKey("Software\PENTA", True)
            regKey.SetValue("Control", firstRunDate)
            LogFile.WriteLog("Key Control: " + firstRunDate + " creata")
            regKey.SetValue("SAT", firstRunDate.AddYears(1))
            LogFile.WriteLog("Key SAT: " + firstRunDate.AddYears(1) + " creata")
            regKey.Close()
            LogFile.WriteLog("Fine creazione Key " + keyName + " (" + Now.Subtract(firstRunDate).TotalSeconds + " secondi)")
            InizializzareDemo()
        End If
        LogFile.WriteLog("Fine inizializzazione registro")
    End Sub

    Private Sub ControlloScadenzaAssistenza()
        LogFile.WriteLog("Avvio controllo di scadenza assistenza")
        regKey = Registry.CurrentUser.OpenSubKey("Software\PENTA", True)
        Dim SATsc As Date = regKey.GetValue("SAT", 0.0)
        If Now < SATsc Then
            Dim ver = regKey.GetValue("Control", 0.0)
            If Now < ver Then
                MostraErrore(Me, "Aggionare Data e Ora del computer.")
                regKey.Close()
                LogFile.WriteLog("Modificata data di windows (Trovata data precedente)")
                LogFile.ChisuraProgramma()
                SoftwareScaduto = True
                Environment.Exit(0)
            Else
                LogFile.WriteLog("Avvio controllo giorni di scadenza assistenza")
                Select Case DateDiff(DateInterval.Day, Now.Date, SATsc.Date)
                    Case 30, 20, 15, 7, 6, 5, 4, 3, 2
                        Label.Text = "Assistenza Anuale in scadenza.
        Rimasti:" & DateDiff(DateInterval.Day, Now.Date, SATsc.Date) & " giorni."
                        Label.ForeColor = Color.RoyalBlue
                        LogFile.WriteLog("Rimangono " & DateDiff(DateInterval.Day, Now.Date, SATsc.Date) & " giorni fino alla scadenza del software.")
                    Case 1
                        Label.Text = "Assistenza Anuale in scadenza.
        Rimasto:" & DateDiff(DateInterval.Day, Now.Date, SATsc.Date) & " giorno."
                        LogFile.WriteLog("Rimane " & DateDiff(DateInterval.Day, Now.Date, SATsc.Date) & " giorno fino alla scadenza del software.")
                        Label.ForeColor = Color.RoyalBlue
                End Select
                regKey.SetValue("Control", Now)
                regKey.Close()
                LogFile.WriteLog("Fine controllo giorni di scadenza assistenza")
            End If
        Else
            LogFile.WriteLog("ASSISTENZA ANNUALE SCADUTA")
            regKey = Registry.CurrentUser.OpenSubKey("Software\PENTA", True)
            regKey.SetValue("Control", Now)
            regKey.Close()
            AvvisoScadenzaAssistenza = True
            Label.Text = "ASSISTENZA ANNUALE SCADUTA"
            Label.ForeColor = Color.DarkRed
        End If
        LogFile.WriteLog("Fine controllo di scadenza assistenza")
    End Sub

    Private Sub InizializzareDemo()
        LogFile.WriteLog("Avvio impostazione DEMO")
        Dim DataScadenzaSoftwareConfermata As Boolean = False
        Dim DataScadenzaSoftware As Date = Now

        While Not DataScadenzaSoftwareConfermata
            DataScadenzaSoftware = Now
            Dim FormDomandaScadenza As New Domanda With {.Messagio = "Impostare data di scadenza software?"}
            Dim richiestaScadenza As DialogResult = FormDomandaScadenza.ShowDialog()
            If richiestaScadenza = DialogResult.Yes Then
                LogFile.WriteLog("Avvio inizializzazione DEMO")
                Dim SceltaScadenzaSoftware As New CalendarForm With {.DataIniziale = Now}
                Dim resultdatascelta As DialogResult = SceltaScadenzaSoftware.ShowDialog()
                If resultdatascelta = DialogResult.OK Then
                    If CInt(SceltaScadenzaSoftware.DataScelta.ToString("yyyyMMdd")) <= CInt(Now.ToString("yyyyMMdd")) Then
                        DataScadenzaSoftwareConfermata = False
                    Else
                        DataScadenzaSoftware = SceltaScadenzaSoftware.DataScelta
                        Dim FormConfermaData As New Domanda With {.Messagio = "Confermare data di scadenza software: " & DataScadenzaSoftware.ToString("dd/MM/yyyy") & "?"}
                        Dim confermascadenza As DialogResult = FormConfermaData.ShowDialog()
                        If True Then
                            DataScadenzaSoftwareConfermata = True
                        End If
                    End If
                Else
                    DataScadenzaSoftwareConfermata = False
                End If
            Else
                DataScadenzaSoftwareConfermata = True
            End If
        End While

        If Not CInt(DataScadenzaSoftware.ToString("yyyyMMdd")) <= CInt(Now.ToString("yyyyMMdd")) Then
            My.Settings.scadenzademo = DataScadenzaSoftware
            My.Settings.Save()
            LogFile.WriteLog("Data DEMO impostata (Data Inserita " + DataScadenzaSoftware.ToString("dd/MM/yyyy") + ")")
            Dim percorsodemo As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\sdc.dll"
            If Not File.Exists(percorsodemo) Then
                File.Create(percorsodemo)
                LogFile.WriteLog("Creato file DEMO")
                LogFile.WriteLog("Fine impostazione DEMO")
                MostraAttenzione("DEMO Attivata")
            End If
        Else
            LogFile.WriteLog("Disattivata scelta DEMO")
            LogFile.WriteLog("Fine impostazione DEMO")
            MostraAttenzione("DEMO disattivata")
        End If
    End Sub

    Private Sub OnTimedEvent(sender As Object, e As Timers.ElapsedEventArgs)
        ExecuteAggDatabase()
    End Sub

    Private Shared Sub ExecuteAggDatabase()
        Try
            Process.Start("C:\Program Files (x86)\Laundry32\AggDatabase.exe")
        Catch ex As Exception
            MostraAttenzione("Software Archiviazione database non trovato.")
        End Try
    End Sub

    Public WithEvents Timer As New System.Timers.Timer
    Dim milliseconds As Integer

    Private Sub ImgSpegni_MouseDown(sender As Object, e As MouseEventArgs) Handles ImgSpegni.MouseDown
        If e.Button = MouseButtons.Right Then
            RiavvioPC.Show()
            Me.Hide()
            Return
        End If
        Timer.Start()
    End Sub

    Private Sub ImgSpegni_MouseUp(sender As Object, e As MouseEventArgs) Handles ImgSpegni.MouseUp
        If e.Button = MouseButtons.Left Then
            Timer.Stop()
            If milliseconds >= 20 Then
                Me.Hide()
                If ControlloSoftwareAperto() Then
                    Return
                Else
                    RiavvioPC.Show()
                    milliseconds = 0
                End If
            Else
                Me.Hide()
                If ControlloSoftwareAperto() Then
                    Return
                Else
                    If (TipoArchiviazione.Value = "2" Or TipoArchiviazione.Value = "1") And Software.Value = "trilogis" Then
                        ArchiviazioneTrilogis.ShowDialog()
                    End If
                    If (InvioSYNC.Value = True) Then
                        If (PercorsoFatture.Value <> "null") And (FatturazioneElett.Value = "true") Then
                            Try
                                Dim paths() As String = IO.Directory.GetFiles(PercorsoFatture.Value, "*.xml")
                                If paths.Length > 0 Then
                                    Buttonfattelett.Text = "Fatt. Elettronica (" + paths.Length.ToString() + ")"
                                    Me.Hide()
                                    InvioFatture.ShowDialog()
                                End If
                            Catch ex As Exception
                                MostraErrore(Me, "Errore percorso fatture.", ex)
                            End Try
                        End If
                    ElseIf (PercorsoFatture.Value <> "null") And (FatturazioneElett.Value = "true") Then
                        Try
                            Dim paths() As String = IO.Directory.GetFiles(PercorsoFatture.Value, "*.xml")
                            If paths.Length > 0 Then
                                Buttonfattelett.Text = "Fatt. Elettronica (" + paths.Length.ToString() + ")"
                            End If
                        Catch ex As Exception
                            MostraErrore(Me, "Errore percorso fatture.", ex)
                        End Try
                    End If
                    SpegniPC.Show()
                    milliseconds = 0
                End If
            End If
        End If
    End Sub

    Private Sub EggTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Elapsed
        milliseconds += 1
    End Sub

    Private Sub Button3logis_Click(sender As Object, e As EventArgs) Handles Button3logis.Click
        ExecuteSoftware()
    End Sub

    Public Sub ExecuteSoftware()
        If Software.Value <> "null" Then
            If (Software.Value = "trilogis") Then
                Dim path As String = "C:\trilogis\trilogis.exe"
                FileSystem.SetAttr(path, FileAttribute.Hidden)
                Dim localByName As Process() = Process.GetProcessesByName("trilogis")
                For Each p As Process In localByName
                    Return
                Next p
                If SoftwareScaduto = False Then
                    Dim trilogis As System.Diagnostics.Process = New System.Diagnostics.Process()
                    trilogis.StartInfo.FileName = "C:\trilogis\trilogis.exe"
                    If AvvisoScadenzaAssistenza Then
                        SAT.Show()
                    End If
                    AvvioScontrinoPenta()
                    InizializzareFattElettTrilogis()
                    If LogoPenta.Value = "1" Or LogoPenta.Value = "2" Then
                        FormLogoPenta = New BannerLogoPenta()
                        FormLogoPenta.WindowState = FormWindowState.Maximized
                        FormLogoPenta.Focus()
                        FormLogoPenta.Show()
                        FormLogoPenta.TopMost = True
                        FormLogoPenta.WindowState = FormWindowState.Normal
                        FormLogoPenta.Activate()
                        trilogis.EnableRaisingEvents = True
                        AddHandler trilogis.Exited, AddressOf ChiusuraTrilogis
                    End If
                    trilogis.Start()
                End If

            ElseIf (Software.Value = "laundry") Then
                Dim localByName As Process() = Process.GetProcessesByName("Errezeta2.Laundry.PocketSync")
                For Each p As Process In localByName
                    Return
                Next p
                Process.Start("C:\Program Files (x86)\Laundry32\Laundry.PocketSync\Errezeta2.Laundry.PocketSync.exe")
                If AvvisoScadenzaAssistenza Then
                    SAT.Show()
                End If
            ElseIf (Software.Value = "menu") Then
                Dim localByName As Process() = Process.GetProcessesByName("Menù")
                For Each p As Process In localByName
                    Return
                Next p
                Process.Start("C:\Menù\Menù.exe")
                If AvvisoScadenzaAssistenza Then
                    SAT.Show()
                End If
            ElseIf (Software.Value = "comus") Then
                Dim localByName As Process() = Process.GetProcessesByName("Comus")
                For Each p As Process In localByName
                    Return
                Next p
                Process.Start("C:\COMUS32\Comus.exe")
                If AvvisoScadenzaAssistenza Then
                    SAT.Show()
                End If
            End If
        Else
            MostraErrore(Me, "Errore impostazione software.")
        End If
    End Sub

    Private Sub ChiusuraTrilogis()
        Me.Invoke(New MethodInvoker(AddressOf FormLogoPenta.Close))
    End Sub

    Private Sub Utility_Click(sender As Object, e As EventArgs) Handles Utility.Click
        Me.Hide()
        If ControlloSoftwareAperto() Then
            Me.Show()
            Return
        End If
        formutility.Show()
    End Sub

    Private Sub InizializzareFileIni()
        LogFile.WriteLog("Avvio caricamento file PentaStart.ini")
        Dim PercorsoIni As String = Application.StartupPath + "\PentaStart.ini"
        Dim ini As New IniFile
        If Not File.Exists(PercorsoIni) Then
            LogFile.WriteLog("File PentaStart.ini non trovato (" + PercorsoIni + ")")
            LogFile.WriteLog("Creazione File PentaStart.ini in corso...")
            File.Create(PercorsoIni).Dispose()
        End If
        ini.Load(PercorsoIni)
        GestioneKeyIni(ini)
        ini.Save(PercorsoIni)


        If (Software.Value <> "null") Then
            ImpostaTastoAvvio()
        Else
            Dim Inizio As Date = Now
            LogFile.WriteLog("Avvio impostazione Software")
            Dim FormDomanda As New Domanda With {.Messagio = "Impostare avvio 3Logis?"}
            Dim result As DialogResult = FormDomanda.ShowDialog()
            If (result = DialogResult.Yes) Then
                ModificaKey(Software, "trilogis")
                ModificaKey(CausaleAnnullo, "LAVAGGIO INDUMENTI")
                ImpostaTastoAvvio()
                LogFile.WriteLog("Impostato avvio 3logis")
                Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                    .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory) + "trilogis\",
                    .RootFolder = Environment.SpecialFolder.MyComputer,
                    .Description = "Scegliere il percorso del database (trilogis.fb20).",
                    .ShowNewFolderButton = False
                }
                If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                    ModificaKey(PercorsoDatabase, cercaspercorsodb.SelectedPath)
                    LogFile.WriteLog("Impostato percorso database 3logis (" + PercorsoDatabase.Value + ")")
                Else
                    ModificaKey(Software, "null")
                    MostraErrore(Me, "Percorso database trilogis non trovato. Rollback.")
                    LogFile.ChisuraProgramma()
                    Environment.Exit(0)
                End If
                Dim connfirebird = False
                While connfirebird = False
                    Dim InizioConnessione As Date = Now
                    LogFile.WriteLog("Avvio impostazione credenziali database")
                    Dim FormInserimentoUtenteDatabase As New TestoForm With {.Intestazione = "INSERIRE UTENTE DATABASE", .TestoIniziale = "SYSDBA"}
                    Dim resultinserimento As DialogResult = FormInserimentoUtenteDatabase.ShowDialog()
                    If resultinserimento = DialogResult.OK Then
                        ModificaKey(UtenteDatabase, FormInserimentoUtenteDatabase.TestoScritto)
                    Else
                        ModificaKey(Software, "null")
                        MostraErrore(Me, "Errore inserimento utente Database. Rollback.")
                        Me.Show()
                        LogFile.ChisuraProgramma()
                        Environment.Exit(0)
                    End If
                    LogFile.WriteLog("Utente inserito: " + UtenteDatabase.Value)
                    Dim FormInserimentoPasswordDatabase As New TestoForm With {.Intestazione = "INSERIRE PASSWORD DATABASE", .TestoIniziale = "masterkey"}
                    Dim resultinserimentopassword As DialogResult = FormInserimentoPasswordDatabase.ShowDialog()
                    If resultinserimentopassword = DialogResult.OK Then
                        ModificaKey(PasswordDatabase, FormInserimentoPasswordDatabase.TestoScritto)
                    Else
                        ModificaKey(UtenteDatabase, "null")
                        ModificaKey(Software, "null")
                        MostraErrore(Me, "Errore inserimento password Database. Rollback.")
                        Me.Show()
                        LogFile.ChisuraProgramma()
                        Environment.Exit(0)
                    End If
                    LogFile.WriteLog("Password inserita: " + PasswordDatabase.Value)
                    Dim fb_string As FbConnectionStringBuilder = New FbConnectionStringBuilder
                    fb_string.ServerType = FbServerType.Default
                    fb_string.UserID = UtenteDatabase.Value
                    fb_string.Password = PasswordDatabase.Value
                    fb_string.Database = cercaspercorsodb.SelectedPath + "\trilogis.fb20"
                    fb_string.Pooling = False
                    Try
                        LogFile.WriteLog("Apertura connessione database in corso...")
                        Dim connection As FbConnection = New FbConnection(fb_string.ConnectionString)
                        connection.Open()
                        If connection.State = ConnectionState.Open Then
                            MostraAttenzione("Apertura connessione database riuscita.")
                            connfirebird = True
                        End If
                    Catch ex As FbException
                        MostraErrore(Me, "Errore apertura connessione database", ex)
                        connfirebird = False
                    End Try
                End While
                Dim FormDomandaAggiornamenti As New Domanda With {.Messagio = "Attivare aggiornamenti?"}
                Dim result2 As DialogResult = FormDomandaAggiornamenti.ShowDialog()
                If (result2 = DialogResult.Yes) Then
                    ModificaKey(Aggiornamenti, "true")
                Else
                    ModificaKey(Aggiornamenti, "false")
                End If
            ElseIf (result = DialogResult.No) Then
                    Dim FormDomanda2 As New Domanda With {.Messagio = "Impostare avvio Laundry?"}
                Dim result2 As DialogResult = FormDomanda2.ShowDialog()
                If (result2 = DialogResult.Yes) Then
                    ModificaKey(Software, "laundry")
                    ModificaKey(CausaleAnnullo, "LAVAGGIO INDUMENTI")
                    ImpostaTastoAvvio()
                    LogFile.WriteLog("Impostato avvio Laundry")
                    Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                        .RootFolder = Environment.SpecialFolder.MyComputer,
                        .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory) + "LaundryData\",
                        .ShowNewFolderButton = False,
                        .Description = "Scegliere il percorso del Database (Laundry.mdb)."
                    }
                    If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                        ModificaKey(PercorsoDatabase, cercaspercorsodb.SelectedPath)
                        LogFile.WriteLog("Impostato percorso database Laundry (" + PercorsoDatabase.Value + ")")
                    Else
                        ModificaKey(Software, "null")
                        MostraErrore(Me, "Percorso database Laundry non trovato. Rollback.")
                        LogFile.ChisuraProgramma()
                        Environment.Exit(0)
                    End If
                ElseIf (result2 = DialogResult.No) Then
                    Dim FormDomanda3 As New Domanda With {.Messagio = "Impostare avvio Menu?"}
                    Dim result3 As DialogResult = FormDomanda3.ShowDialog()
                    If (result3 = DialogResult.Yes) Then
                        ModificaKey(Software, "menu")
                        ModificaKey(CausaleAnnullo, "STORNO MENU")
                        ImpostaTastoAvvio()
                        LogFile.WriteLog("Impostato avvio Menu")
                        Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                            .RootFolder = Environment.SpecialFolder.MyComputer,
                            .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory) + "Menù\Clients\",
                            .ShowNewFolderButton = False,
                            .Description = "Scegliere il percorso del Database del programma Menu."
                        }
                        If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                            ModificaKey(PercorsoDatabase, cercaspercorsodb.SelectedPath)
                            LogFile.WriteLog("Impostato percorso database Menu (" + PercorsoDatabase.Value + ")")
                        Else
                            ModificaKey(Software, "null")
                            MostraErrore(Me, "Percorso database Menu non trovato. Rollback.")
                            LogFile.ChisuraProgramma()
                            Environment.Exit(0)
                        End If
                    ElseIf (result3 = DialogResult.No) Then
                        Dim FormDomanda4 As New Domanda With {.Messagio = "Impostare avvio Comus?"}
                        Dim result4 As DialogResult = FormDomanda4.ShowDialog()
                        If (result4 = DialogResult.Yes) Then
                            ModificaKey(Software, "comus")
                            ModificaKey(CausaleAnnullo, "STORNO MENU")
                            ImpostaTastoAvvio()
                            LogFile.WriteLog("Impostato avvio Comus")
                            Dim cercaspercorsodb As FolderBrowserDialog = New FolderBrowserDialog With {
                                .RootFolder = Environment.SpecialFolder.MyComputer,
                                .SelectedPath = Path.GetPathRoot(Environment.SystemDirectory) + "Comus\",
                                .ShowNewFolderButton = False,
                                .Description = "Scegliere il percorso del Database."
                            }
                            If cercaspercorsodb.ShowDialog() = DialogResult.OK Then
                                ModificaKey(PercorsoDatabase, cercaspercorsodb.SelectedPath)
                                LogFile.WriteLog("Impostato percorso database Comus (" + PercorsoDatabase.Value + ")")
                            Else
                                ModificaKey(Software, "null")
                                MostraErrore(Me, "Percorso database Comuss non trovato. Rollback.")
                                LogFile.ChisuraProgramma()
                                Environment.Exit(0)
                            End If
                        Else
                            ImpostaTastoAvvio()
                        End If
                    End If
                End If
            End If
            LogFile.WriteLog("Fine impostazione Software: " & Software.Value & " (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
        End If
    End Sub

    Private Sub ImpostaTastoAvvio()
        If Software.Value = "trilogis" Then
            Button3logis.ForeColor = Color.DarkOrange
            Button3logis.Text = "Avvia 3logis"
            Button3logis.FlatAppearance.BorderColor = Color.DarkOrange
            If TipoArchiviazione.Value = "1" Then
                Buttonnas.Text = "Ripristino"
            End If
        ElseIf Software.Value = "laundry" Then
            Button3logis.ForeColor = Color.LimeGreen
            Button3logis.Text = "Avvia Laundry"
            Button3logis.FlatAppearance.BorderColor = Color.LimeGreen
        ElseIf Software.Value = "menu" Then
            Button3logis.ForeColor = Color.RoyalBlue
            Button3logis.Text = "Avvia Menù"
            Button3logis.FlatAppearance.BorderColor = Color.RoyalBlue
        ElseIf Software.Value = "comus" Then
            Button3logis.ForeColor = Color.RoyalBlue
            Button3logis.Text = "Avvia Comus"
            Button3logis.FlatAppearance.BorderColor = Color.RoyalBlue
        Else
            Button3logis.ForeColor = Color.RoyalBlue
            Button3logis.Text = "Non configurato"
            Button3logis.FlatAppearance.BorderColor = Color.RoyalBlue
        End If
    End Sub

    Private Sub GestioneKeyIni(ini As IniFile)
        Dim Inizio As Date = Now
        Dim unused As String = ""
        LogFile.WriteLog("Avvio lettura file PentaStart.ini")
        CaricamentoKeyIni(ini, PercorsoBackup, "C:/")
        CaricamentoKeyIni(ini, Esecuzione, "true")
        CaricamentoKeyIni(ini, Software, "null")
        CaricamentoKeyIni(ini, LogoPenta, "false")
        CaricamentoKeyIni(ini, PercorsoDatabase, "null")
        CaricamentoKeyIni(ini, UnitaArchiviazione, "null")
        CaricamentoKeyIni(ini, UtenteDatabase, "SYSDBA")
        CaricamentoKeyIni(ini, PasswordDatabase, "masterkey")
        CaricamentoKeyIni(ini, TipoArchiviazione, "0")
        CaricamentoKeyIni(ini, IndirizzoIpDatabase, "127.0.0.1")
        CaricamentoKeyIni(ini, mct, "false")
        CaricamentoKeyIni(ini, ditron, "false")
        CaricamentoKeyIni(ini, epson, "false")
        CaricamentoKeyIni(ini, CausaleAnnullo, "STORNO SCONTRINO")
        CaricamentoKeyIni(ini, RepartoAnnullo, "1")
        CaricamentoKeyIni(ini, PercorsoMultiDriver, "null")
        CaricamentoKeyIni(ini, PercorsoWinEcr, "null")
        CaricamentoKeyIni(ini, PercorsoFpMate, "null")
        CaricamentoKeyIni(ini, DettaglioNScontrino, "false")
        CaricamentoKeyIni(ini, DettaglioCapi, "false")
        CaricamentoKeyIni(ini, ScontrinoParlante, "false")
        CaricamentoKeyIni(ini, Postazione, "1")
        CaricamentoKeyIni(ini, TimeoutStampante, "9")
        CaricamentoKeyIni(ini, MatricolaRT, "null")
        CaricamentoKeyIni(ini, FatturazioneElett, "false")
        CaricamentoKeyIni(ini, SpeakerNomePronto, "false")
        CaricamentoKeyIni(ini, InvioSYNC, "false")
        CaricamentoKeyIni(ini, UrlFatturazione, "null")
        CaricamentoKeyIni(ini, VersioneSYNC, "1.0.0.0")
        CaricamentoKeyIni(ini, PercorsoFatture, "null")
        CaricamentoKeyIni(ini, PercorsoSYNC, "null")
        CaricamentoKeyIni(ini, PercorsoMacroMiniMouse, "null")
        CaricamentoKeyIni(ini, CoordinateXInvio, "0")
        CaricamentoKeyIni(ini, CoordinateYInvio, "0")
        CaricamentoKeyIni(ini, CoordinateXErrore, "0")
        CaricamentoKeyIni(ini, CoordinateYErrore, "0")
        CaricamentoKeyIni(ini, CoordinateButtonXFatturazione, "0")
        CaricamentoKeyIni(ini, CoordinateButtonYFatturazione, "0")
        CaricamentoKeyIni(ini, CoordinateButtonXInvio, "0")
        CaricamentoKeyIni(ini, CoordinateButtonYInvio, "0")
        CaricamentoKeyIni(ini, CoordinateButtonXChiusura1, "0")
        CaricamentoKeyIni(ini, CoordinateButtonYChiusura1, "0")
        CaricamentoKeyIni(ini, CoordinateButtonXChiusura2, "0")
        CaricamentoKeyIni(ini, CoordinateButtonYChiusura2, "0")
        CaricamentoKeyIni(ini, CoordinateButtonXChiusura3, "0")
        CaricamentoKeyIni(ini, CoordinateButtonYChiusura3, "0")
        CaricamentoKeyIni(ini, Aggiornamenti, "true")
        CaricamentoKeyIni(ini, DataProssimoAggiornamento, Now.AddDays(7).ToString("yyyyMMdd"))
        CaricamentoKeyIni(ini, ForzareAggiornamento, "false")
        LogFile.WriteLog("Fine lettura file PentaStart.ini (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
    End Sub

    Private Sub ButtonChiusura_Click(sender As Object, e As EventArgs) Handles ButtonChiusura.Click
        If EsisteStampanteMCT() Or EsisteStampanteDitron() Or EsisteStampanteEpson() Then
            Me.Hide()
            RegistratoreTelematico.Show()
        End If
    End Sub

    Private Sub ButtonTele_Click(sender As Object, e As EventArgs) Handles ButtonTele.Click
        Dim localByName As Process() = Process.GetProcessesByName("TeamViewer")
        For Each p As Process In localByName
            p.Kill()
        Next p

        If File.Exists("C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe") Then
            If Not File.Exists(Application.StartupPath + "\TeamViewer.lnk") Then
                Dim wsh As WshShellClass = New WshShellClass()
                Dim Shortcut As IWshRuntimeLibrary.IWshShortcut = wsh.CreateShortcut(Application.StartupPath + "\TeamViewer.lnk")
                Shortcut.Arguments = ""
                Shortcut.TargetPath = "C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe"
                Shortcut.WindowStyle = 1
                Shortcut.Description = "TeamViewer"
                Shortcut.WorkingDirectory = "C:\\Program Files (x86)\\TeamViewer"
                Shortcut.IconLocation = "C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe"
                Shortcut.Save()
            End If
            Process.Start(Application.StartupPath + "\TeamViewer.lnk")
        Else
            MostraErrore(Me, "Impossibile avviare il programma di TeleAssitenza")
            Me.Show()
        End If
    End Sub

    Private Sub Buttonbak_Click(sender As Object, e As EventArgs) Handles Buttonbak.Click
        Me.Hide()
        If ControlloSoftwareAperto() Then
            Me.Show()
            Return
        End If
        Backup.Show()
    End Sub

    Private Sub Buttonnas_Click(sender As Object, e As EventArgs) Handles Buttonnas.Click
        If (TipoArchiviazione.Value = "1" Or TipoArchiviazione.Value = "2") And Software.Value = "trilogis" Then
            If ControlloSoftwareAperto() Then
                Return
            End If
            Me.Hide()
            CaricamentoDBStorico.ShowDialog()
            Me.Show()
        Else
            Dim pentaweb As String = "http://servicesms.pentaelectronic.eu/"
            Process.Start(pentaweb)
        End If
    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        Dim pentaweb As String = "http://www.pentaelectronic.eu/"
        Process.Start(pentaweb)
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Refresh()
    End Sub

    Private Sub Chuidi_MouseDown(sender As Object, e As MouseEventArgs) Handles Chiudi.MouseDown
        If ControlloSoftwareAperto() Then
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.Hide()
            ChiusuraPentaStart.Show()
        End If
    End Sub

    Private Sub Buttonfattelett_Click(sender As Object, e As EventArgs) Handles Buttonfattelett.Click
        If UrlFatturazione.Value <> "null" Then
            Try
                Process.Start(UrlFatturazione.Value)
            Catch ex As Exception
                MostraErrore(Me, "Errore avvio Fatturazione Elettronica.", ex)
            End Try
        ElseIf PercorsoSYNC.Value <> "null" Then
            If File.Exists(PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe") Then
                Process.Start(PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe")
            Else
                MostraErrore(Me, "Errore avvio SYNC")
            End If
        Else
            MostraErrore(Me, "Errore avvio Fatturazione Elettronica.")
        End If
    End Sub

    Private Sub FileSystemWatcher1_Created(sender As Object, e As FileSystemEventArgs)
        FileScontrinoComusDitron.EnableRaisingEvents = False
        Dim Str As String = ""
        Dim read As Boolean = False
        While read = False
            Try
                Str = File.ReadAllText(PercorsoWinEcr.Value + "\scontrini.txt")
                read = True
            Catch ex As Exception
                read = False
            End Try
        End While

        TipoPagamento.SceglierePagamento(Str, PercorsoWinEcr.Value)
        FileScontrinoComusDitron.EnableRaisingEvents = True
    End Sub
End Class

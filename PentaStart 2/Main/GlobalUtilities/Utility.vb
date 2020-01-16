Imports System.IO
Imports System.Reflection
Imports IWshRuntimeLibrary
Imports Microsoft.Win32
Imports PentaStart.Variables
Imports File = System.IO.File

Public Class Utility
    Public Shared LogFile As New Log

    Public Shared Sub CreaMacroSYNC()
        Dim CoordinateXInvio As String = Variables.CoordinateXInvio.Value
        Dim CoordinateYInvio As String = Variables.CoordinateYInvio.Value
        Dim CoordinateXErrore As String = Variables.CoordinateXErrore.Value
        Dim CoordinateYErrore As String = Variables.CoordinateYErrore.Value
        Dim CoordinateButtonXFatturazione As String = Variables.CoordinateButtonXFatturazione.Value
        Dim CoordinateButtonYFatturazione As String = Variables.CoordinateButtonYFatturazione.Value
        Dim CoordinateButtonXInvio As String = Variables.CoordinateButtonXInvio.Value
        Dim CoordinateButtonYInvio As String = Variables.CoordinateButtonYInvio.Value
        Dim CoordinateButtonXChiusura1 As String = Variables.CoordinateButtonXChiusura1.Value
        Dim CoordinateButtonYChiusura1 As String = Variables.CoordinateButtonYChiusura1.Value
        Dim CoordinateButtonXChiusura2 As String = Variables.CoordinateButtonXChiusura2.Value
        Dim CoordinateButtonYChiusura2 As String = Variables.CoordinateButtonYChiusura2.Value
        Dim CoordinateButtonXChiusura3 As String = Variables.CoordinateButtonXChiusura3.Value
        Dim CoordinateButtonYChiusura3 As String = Variables.CoordinateButtonYChiusura3.Value
        Dim percorsosync As String = Variables.PercorsoSYNC.Value
        Dim VersioneSYNC As String = AssemblyName.GetAssemblyName(Variables.PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe").Version.ToString()
        Dim StringFile = "1 | IF | PROCESS NAME | BRAINTEAMFATTURAELETTRONICA | NOT EXIST | GOTO MACRO LINE | 2" + Environment.NewLine +
        "2 | IF | PROCESS NAME | BRAINTEAMFATTURAELETTRONICA | NOT EXIST | GOTO MACRO LINE | 1" + Environment.NewLine +
        "3 | IF | WINDOW TITLE | BrainTeam Fatturazione Elettronica v." + VersioneSYNC + " | NOT EXIST | GOTO MACRO LINE | 4" + Environment.NewLine +
        "4 | IF | WINDOW TITLE | BrainTeam Fatturazione Elettronica v." + VersioneSYNC + " | NOT EXIST | GOTO MACRO LINE | 3" + Environment.NewLine +
        "5 | RUN ACTION | SELECT WINDOW BY NAME | BrainTeam" + Environment.NewLine +
        "6 | " + CoordinateButtonXFatturazione + " | " + CoordinateButtonYFatturazione + " | 1265 | Left Click" + Environment.NewLine +
        "7 | RUN ACTION | SELECT WINDOW BY NAME | BrainTeam Fatturazione Elettronica" + Environment.NewLine +
        "8 | " + CoordinateButtonXInvio + " | " + CoordinateButtonYInvio + " | 3703 | Left Click" + Environment.NewLine +
        "9 | RUN ACTION | WAIT SECONDS | 10" + Environment.NewLine +
        "10 | IF | PIXEL COLOR | Color [R=89, G=89, B=89]::At Location [X:" + CoordinateXInvio + " Y:" + CoordinateYInvio + "] | IS THE SAME | GOTO MACRO LINE | 9" + Environment.NewLine +
        "11 | IF | PIXEL COLOR | Color [R=70, G=130, B=180]::At Location [X:" + CoordinateXErrore + " Y:" + CoordinateYErrore + "] | IS THE SAME | STOP" + Environment.NewLine +
        "12 | " + CoordinateButtonXChiusura1 + " | " + CoordinateButtonYChiusura1 + " | 4961 | Left Click" + Environment.NewLine +
        "13 | " + CoordinateButtonXChiusura2 + " | " + CoordinateButtonYChiusura2 + " | 1172 | Left Click" + Environment.NewLine +
        "14 | " + CoordinateButtonXChiusura3 + " | " + CoordinateButtonYChiusura3 + " | 1172 | Left Click"

        File.WriteAllText(PercorsoMacroMiniMouse.Value & "\1.mmmacro", StringFile)

    End Sub

    Public Shared Sub AvvioInvioFattureSync()
        Dim percorsomouse As String = Application.StartupPath + "\MiniMouseMacro.exe"
        Process.Start(percorsomouse)
        Process.Start(PercorsoSYNC.Value + "\BrainTeamFatturaElettronica.exe")
        Threading.Thread.Sleep(1000)
        Dim localByName As Process() = Process.GetProcessesByName("BrainTeamFatturaElettronica")
        While localByName.LongCount > 0
            Threading.Thread.Sleep(2000)
            localByName = Process.GetProcessesByName("BrainTeamFatturaElettronica")
        End While
        For Each ObjProcess As Process In Process.GetProcessesByName("BrainTeamFatturaElettronica")
            AppActivate(ObjProcess.Id)
            SendKeys.SendWait("~")
        Next
        localByName = Process.GetProcessesByName("BrainTeamFatturaElettronica")
        While localByName.LongCount > 0
            Threading.Thread.Sleep(2000)
            localByName = Process.GetProcessesByName("BrainTeamFatturaElettronica")
        End While
        Dim localByName2 As Process() = Process.GetProcessesByName("MiniMouseMacro")
        For Each p As Process In localByName2
            p.Kill()
        Next p
    End Sub

    Public Shared Function AggiornamentiAttivi() As Boolean
        LogFile.WriteLog("Avvio controllo utente - aggiornamenti")
        If Variables.Aggiornamenti.Value = "true" Then
            LogFile.WriteLog("Impostazione INI: Aggiornamenti attivati")
            Dim regKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\PENTA", True)
            Dim SATsc As Date = regKey.GetValue("SAT", 0.0)
            If Now > SATsc Then
                LogFile.WriteLog("Utente con servizio di assistenza scaduto")
                Return False
            Else
                LogFile.WriteLog("Utente con servizio di assistenza attivo")
                Return True
            End If
        Else
            LogFile.WriteLog("Impostazione INI: Aggiornamenti disattivati")
            Return False
        End If
    End Function

    Public Shared Sub ControlloIstanzaAperta(programma As String)
        Dim localByName As Process() = Process.GetProcessesByName(programma)
        For Each p As Process In localByName
            LogFile.WriteLog("Trovata istanza aperta precedentemente")
            LogFile.ChisuraProgramma()
            Application.Exit()
        Next p
    End Sub

    Public Shared Function AttendereAvvioFirebird() As Boolean
        Dim localByName As Process() = Process.GetProcessesByName("fbserver")
        While localByName.LongCount <= 0
            Threading.Thread.Sleep(1500)
            localByName = Process.GetProcessesByName("fbserver")
        End While
        Return True
    End Function

    Public Shared Function ControlloSoftwareAperto() As Boolean
        If (Software.Value <> "null") Then
            If (Software.Value = "trilogis") Then
                Dim localByName As Process() = Process.GetProcessesByName("trilogis")
                If localByName.LongCount > 0 Then
                    Dim FormTrilogisAperto As New Errore
                    FormTrilogisAperto.Messagio = "IL PROGRAMMA È IN CORSO."
                    FormTrilogisAperto.ShowDialog()
                    Return True
                Else
                    Return False
                End If
            ElseIf (Software.Value = "laundry") Then
                Dim localByName As Process() = Process.GetProcessesByName("Errezeta2.Laundry.PocketSync")
                If localByName.LongCount > 0 Then
                    Dim FormTrilogisAperto As New Errore
                    FormTrilogisAperto.Messagio = "IL PROGRAMMA È IN CORSO."
                    FormTrilogisAperto.ShowDialog()
                    Return True
                Else
                    Return False
                End If
            ElseIf (Software.Value = "menu") Then
                Dim localByName As Process() = Process.GetProcessesByName("Menù")
                If localByName.LongCount > 0 Then
                    Dim FormTrilogisAperto As New Errore
                    FormTrilogisAperto.Messagio = "IL PROGRAMMA È IN CORSO."
                    FormTrilogisAperto.ShowDialog()
                    Return True
                Else
                    Return False
                End If
            ElseIf (Software.Value = "comus") Then
                Dim localByName As Process() = Process.GetProcessesByName("Comus")
                If localByName.LongCount > 0 Then
                    Dim FormTrilogisAperto As New Errore
                    FormTrilogisAperto.Messagio = "IL PROGRAMMA È IN CORSO."
                    FormTrilogisAperto.ShowDialog()
                    Return True
                Else
                    Return False
                End If
            Else
                MsgBox("Software non configurato", MsgBoxStyle.Information, "PentaStart")
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Sub CaricamentoKeyIni(ini As IniFile, ByRef Variable As KeyIni, defaultvalue As String)
        Variable.Value = ini.GetKeyValue(Variable.Percorso, Variable.Key)
        If Variable.Value = "" Then
            Variable.Value = defaultvalue.ToString()
            ini.AddSection(Variable.Percorso)
            ini.AddSection(Variable.Percorso).AddKey(Variable.Key)
            ini.SetKeyValue(Variable.Percorso, Variable.Key, defaultvalue)
            LogFile.WriteLog("[INI] Creata Key PentaStart.ini: Percorso: " + Variable.Percorso + " - Key: " + Variable.Key + " - Valore: " + defaultvalue)
        Else
            LogFile.WriteLog("[INI] Lettura PentaStart.ini: Percorso: " + Variable.Percorso + " - Key: " + Variable.Key + " - Valore: " + Variable.Value)
        End If
    End Sub

    Public Shared Sub AdjustText(labelsize As Label)
        Dim Fit As Boolean = False
        Dim CurSize As Single
        Dim SizeStep As Single = 1
        Do Until Fit
            CurSize += SizeStep
            Dim Fnt As Font = New Font(labelsize.Font.Name, CurSize)
            Dim textSize As Size = TextRenderer.MeasureText(labelsize.Text, Fnt)
            If textSize.Height >= labelsize.Height Or textSize.Width >= labelsize.Width Or labelsize.Height = 0 Or labelsize.Width = 0 Then
                Fit = True
                If textSize.Width > labelsize.Width Then
                    CurSize -= SizeStep
                End If
                If textSize.Height > labelsize.Height Then
                    CurSize -= SizeStep
                End If
            End If
        Loop

        If CurSize >= 0 Then
            labelsize.Font = New Font(labelsize.Font.Name, CurSize)
            Application.DoEvents()
        End If
    End Sub

    Public Shared Sub ModificaKey(ByRef Variable As KeyIni, value As String)
        Dim ini As New IniFile
        ini.Load(Application.StartupPath + "\PentaStart.ini")
        ini.SetKeyValue(Variable.Percorso, Variable.Key, value)
        ini.Save(Application.StartupPath + "\PentaStart.ini")
        LogFile.WriteLog("[INI] Modificata Key PentaStart.ini: Percorso: " + Variable.Percorso + " - Key: " + Variable.Key + " - Valore: " + value)
        Dim nomevariabilestatica As String = Variable.Value
        Variable.Value = value
        LogFile.WriteLog("Valore globale caricato: " + nomevariabilestatica + ": " + Variable.Value)
    End Sub
    Public Shared Function EsisteStampanteMCT() As Boolean
        If mct.Value = "true" Then

            Directory.CreateDirectory(PercorsoMultiDriver.Value & "/TOSEND")

            If Not File.Exists(Application.StartupPath + "/MULTIDRIVER_SERVER.lnk") Then
                Dim wsh As WshShell = New WshShell()
                Dim Shortcut As IWshRuntimeLibrary.IWshShortcut = wsh.CreateShortcut(Application.StartupPath + "/MULTIDRIVER_SERVER.lnk")
                Shortcut.Arguments = ""
                Shortcut.TargetPath = PercorsoMultiDriver.Value + "/MULTIDRIVER_SERVER.exe"
                Shortcut.WindowStyle = 1
                Shortcut.Description = "MULTIDRIVER_SERVER"
                Shortcut.WorkingDirectory = PercorsoMultiDriver.Value + "/MULTIDRIVER_SERVER.exe"
                Shortcut.IconLocation = PercorsoMultiDriver.Value + "/MULTIDRIVER_SERVER.exe"
                Shortcut.Save()
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub RiavvioPentaStart()
        LogFile.ChisuraProgramma()
        Application.Restart()
    End Sub

    Public Shared Function EsisteStampanteDitron() As Boolean
        If ditron.Value = "true" Then
            Try
                Directory.CreateDirectory(PercorsoWinEcr.Value & "/TOSEND")
            Catch ex As Exception
                LogFile.WriteLog("Impossibile creare percorso: " & PercorsoWinEcr.Value & "/TOSEND")
                MessageBox.Show("Impossibile creare percorso: " & PercorsoWinEcr.Value & "/TOSEND", "PentaStart")
            End Try


            If Not File.Exists(Application.StartupPath + "/SoEcrCom.lnk") Then
                Dim wsh As WshShell = New WshShell()
                Dim Shortcut As IWshRuntimeLibrary.IWshShortcut = wsh.CreateShortcut(Application.StartupPath + "/SoEcrCom.lnk")
                Shortcut.Arguments = ""
                Shortcut.TargetPath = PercorsoWinEcr.Value + "\\Drivers\\SoEcrCom.exe"
                Shortcut.WindowStyle = 1
                Shortcut.Description = "SoEcrCom"
                Shortcut.WorkingDirectory = PercorsoWinEcr.Value + "\\Drivers\\SoEcrCom.exe"
                Shortcut.IconLocation = PercorsoWinEcr.Value + "\\Drivers\\SoEcrCom.exe"
                Shortcut.Save()
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function EsisteStampanteEpson() As Boolean
        If epson.Value = "true" Then
            Try
                Directory.CreateDirectory("C:/EPSON")
                Directory.CreateDirectory("C:/EPSON/TOSEND")
                Directory.CreateDirectory("C:/EPSON/ERRORI")
                Directory.CreateDirectory("C:/EPSON/LOGS")
            Catch ex As Exception
                LogFile.WriteLog("Impossibile creare percorso: " & PercorsoWinEcr.Value & "/TOSEND")
                MessageBox.Show("Impossibile creare percorso: " & PercorsoWinEcr.Value & "/TOSEND", "PentaStart")
            End Try

            If Not File.Exists(Application.StartupPath + "/EpsonFpMate.lnk") Then
                Dim wsh As WshShell = New WshShell()
                Dim Shortcut As IWshRuntimeLibrary.IWshShortcut = wsh.CreateShortcut(Application.StartupPath + "/EpsonFpMate.lnk")
                Shortcut.Arguments = ""
                Shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\EpsonFpMate\EpsonFpMate.exe"
                Shortcut.WindowStyle = 1
                Shortcut.Description = "EpsonFpMate"
                Shortcut.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\EpsonFpMate"
                Shortcut.IconLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\EpsonFpMate\EpsonFpMate.exe"
                Shortcut.Save()
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub RiavvioProgrammaScontrinoPenta()
        If EsisteStampanteMCT() Or EsisteStampanteDitron() Or EsisteStampanteEpson() Then
            Dim localByName3 As Process() = Process.GetProcessesByName("ScontrinoPenta")
            For Each p As Process In localByName3
                p.Kill()
            Next p
            Dim scontrinopenta As System.Diagnostics.Process = New System.Diagnostics.Process()
            scontrinopenta.StartInfo.FileName = Application.StartupPath + "\ScontrinoPenta.exe"
            Try
                scontrinopenta.Start()
            Catch ex As Exception
                LogFile.WriteLog("ScontrinoPenta non trovato.")
                Dim FormErrore As New Errore
                FormErrore.Messagio = "ERRORE AVVIO GESTIONE SCONTRINO." & Environment.NewLine & "CHIAMARE L'ASSISTENZA"
                FormErrore.ShowDialog()
                FormErrore.Dispose()
            End Try
        End If
    End Sub

    Public Shared Sub AttendereRispostaStampante(percorsofile As String, commandi() As String, messagio As String)
        Dim FormAttendere As New Attendere
        FormAttendere.Show()
        FormAttendere.Refresh()
        Dim secondi As Integer = 0
        While File.Exists(percorsofile)
            If secondi = 20 Then
                secondi += 1
                RiavvioDriverScontrino()
                Threading.Thread.Sleep(1000)
                ScrivereFile(commandi, percorsofile)
            ElseIf secondi = 35 Then
                Try
                    File.Delete(percorsofile)
                    FormAttendere.Hide()
                    FormAttendere.Dispose()
                    LogFile.WriteLog("La stampante non e riuscita a eseguire il commando.")
                    Dim FormErrore As New Errore
                    FormErrore.Messagio = messagio
                    FormErrore.ShowDialog()
                    FormErrore.Dispose()
                Catch ex As Exception
                    secondi = 10
                End Try
            Else
                Threading.Thread.Sleep(1000)
                secondi += 1
            End If
        End While
        LogFile.WriteLog("La stampante ha eseguito il commando.")
        FormAttendere.Hide()
        FormAttendere.Dispose()
    End Sub

    Public Shared Sub RiavvioDriverScontrino()
        LogFile.WriteLog("Riavvio driver scontrino in corso...")
        If EsisteStampanteMCT() Then
            ChiusuraProgramma("MULTIDRIVER_SERVER")
            Process.Start(Application.StartupPath + "/MULTIDRIVER_SERVER.lnk")
        ElseIf EsisteStampanteDitron() Then
            ChiusuraProgramma("SoEcrCom")
            Process.Start(Application.StartupPath + "/SoEcrCom.lnk")
        ElseIf EsisteStampanteEpson() Then
            ChiusuraProgramma("EpsonFpMate")
            Process.Start(Application.StartupPath + "/EpsonFpMate.lnk")
        End If
        LogFile.WriteLog("Fine riavvio driver scontrino")
    End Sub

    Public Shared Sub MostraCalendarioEAggiornaTesto(ByVal sender As Form, [date] As Date, ByRef testo As TextBox)
        sender.Hide()
        Dim FormCalendar As New CalendarForm
        Try
            FormCalendar.DataIniziale = [date]
        Catch
            FormCalendar.DataIniziale = Now
        End Try
        FormCalendar.ShowDialog()
        If FormCalendar.DialogResult = DialogResult.OK Then
            testo.Text = FormCalendar.DataScelta.ToString("dd/MM/yy")
        End If
        FormCalendar.Dispose()
        sender.Show()
    End Sub

    Public Shared Sub MostraErrore(ByVal sender As Form, messagio As String, Optional ByVal errore As Exception = Nothing)
        sender.Hide()
        Dim FormErrore As New Errore
        FormErrore.Messagio = messagio
        LogFile.WriteLog(messagio)
        If Not IsNothing(errore) Then
            LogFile.WriteLog("Errore: " & errore.ToString())
        End If
        FormErrore.ShowDialog()
        FormErrore.Dispose()
        sender.Show()
    End Sub

    Public Shared Sub InSviluppo(ByVal sender As Form)
        sender.Hide()
        Dim FormErrore As New Errore
        FormErrore.Messagio = "IN SVILUPPO"
        FormErrore.ShowDialog()
        FormErrore.Dispose()
        sender.Show()
    End Sub

    Public Shared Sub MostraAttenzione(messagio As String)
        Dim FormAttenzione As New Attenzione
        FormAttenzione.Messagio = messagio
        FormAttenzione.ShowDialog()
        FormAttenzione.Dispose()
    End Sub

    Public Shared Sub MostraEAggiornaNumero(sender As Form, numeroiniziale As String, ByRef testo As TextBox)
        sender.Hide()
        Dim FormNumero As New NumeroForm
        Try
            FormNumero.NumeroIniziale = numeroiniziale
        Catch
            FormNumero.NumeroIniziale = 0
        End Try
        FormNumero.ShowDialog()
        If FormNumero.DialogResult = DialogResult.OK Then
            testo.Text = FormNumero.NumeroInserito.ToString()
        End If
        FormNumero.Dispose()
        sender.Hide()
    End Sub

    Public Shared Sub ChiusuraProgramma(programma As String)
        LogFile.WriteLog("Chiusura " + programma + " in corso...")
        Dim localByName As Process() = Process.GetProcessesByName(programma)
        For Each p As Process In localByName
            p.Kill()
        Next p
    End Sub

    Public Shared Sub AvviareProgramma(percorso As String)
        LogFile.WriteLog("Avvio " & percorso & " in corso")
        Process.Start(percorso)
    End Sub

    Public Shared Sub ScrivereFile(commandi() As String, percorso As String)
        Using outputFile As StreamWriter = New StreamWriter(percorso)
            For Each line As String In commandi
                outputFile.WriteLine(line)
            Next
        End Using
    End Sub

    Public Shared Sub ControlloDriverInvioScontrino()
        LogFile.WriteLog("Controllo driver stampante")
        If EsisteStampanteMCT() Then
            Dim multidriver() As Process = Process.GetProcessesByName("MULTIDRIVER_SERVER")
            If (multidriver.Length = 0) Then
                AvviareProgramma(Application.StartupPath + "\\MULTIDRIVER_SERVER.lnk")
            End If
        ElseIf EsisteStampanteDitron() Then
            Dim ditron() As Process = Process.GetProcessesByName("SoEcrCom")
            If (ditron.Length = 0) Then
                AvviareProgramma(Application.StartupPath + "\\SoEcrCom.lnk")
            End If
        ElseIf EsisteStampanteEpson() Then
            Dim epson() As Process = Process.GetProcessesByName("EpsonFpMate")
            If (epson.Length = 0) Then
                AvviareProgramma(Application.StartupPath + "\\EpsonFpMate.lnk")
            End If
        End If
    End Sub
End Class

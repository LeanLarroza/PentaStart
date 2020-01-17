Imports System.IO
Imports System.Runtime.InteropServices
Imports PentaStart.Utility

Public Class CaricamentoDBStorico
    Private PercorsoArchiviazione As String
    Private f As BannerLogoPenta
    Dim modstorico As BannerStorico
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        Dim Inizio As Date = Now
        LogFile.WriteLog("Avvio caricamento archivio storico...")
        ChiusuraProgramma("ScontrinoPenta")
        ChiusuraProgramma("FattElett")

        If IsFileOpen(New FileInfo("C:\trilogis\trilogis.fb20")) Then
            ControlloSoftwareAperto()
            Return
        End If

        Dim existe As Boolean = False
        For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
            Try
                If driveInfo.VolumeLabel = Variables.UnitaArchiviazione.Value Then
                    PercorsoArchiviazione = driveInfo.Name
                    existe = True
                End If
            Catch ex As Exception
                Continue For
            End Try

        Next

        If existe Then
            If Directory.GetDirectories(PercorsoArchiviazione).Length > 1 Then
                Dim annosto As New AnnoStorico()
                Me.Hide()
                Dim result As DialogResult = annosto.ShowDialog()
                If result = DialogResult.OK Then
                    Dim copiacorretta As Boolean = CopiaDatabaseCorrente()
                    If copiacorretta Then
                        copiacorretta = CaricaDatabaseStorico(annosto.AnnoScelto)
                        If copiacorretta Then
                            Me.Hide()
                            AvvioTrilogis()
                        Else
                            MostraErrore(Me, "Errore recupero database")
                            Return
                        End If
                    Else
                        MostraErrore(Me, "Errore salvataggio database")
                        Return
                    End If
                Else
                    Me.Dispose()
                End If
            ElseIf Directory.GetDirectories(PercorsoArchiviazione).Length = 1 Then
                Dim copiacorretta As Boolean = CopiaDatabaseCorrente()
                If copiacorretta Then
                    copiacorretta = CaricaDatabaseStorico(DateTime.Now.ToString("yyyyy"))
                    If copiacorretta Then
                        AvvioTrilogis()
                    Else
                        MostraErrore(Me, "Errore recupero database")
                        Return
                    End If
                Else
                    MostraErrore(Me, "Errore salvataggio database")
                    Return
                End If
            Else
                MostraErrore(Me, "Archivio storico non trovato")
                Return
            End If
        Else
            MostraErrore(Me, "PENDRIVE NON TROVATO")
            Me.Dispose()
        End If
        LogFile.WriteLog("Fine caricamento archivio storico (" & Now.Subtract(Inizio).TotalSeconds & " secondi)")
    End Sub

    Private Sub AvvioTrilogis()
        LogFile.WriteLog("Avvio 3logis in corso (Modalità storico)")
        Dim trilogis As System.Diagnostics.Process = New System.Diagnostics.Process()
        If Variables.LogoPenta.Value = "1" Or Variables.LogoPenta.Value = "2" Then
            f = New BannerLogoPenta()
            f.WindowState = FormWindowState.Maximized
            f.Focus()
            f.Show()
            f.TopMost = True
            f.WindowState = FormWindowState.Normal
            f.Activate()
        End If
        trilogis.StartInfo.FileName = "C:\trilogis\trilogis.exe"
        trilogis.EnableRaisingEvents = True
        AddHandler trilogis.Exited, AddressOf ChiusuraTrilogis
        trilogis.Start()
        modstorico = New BannerStorico()
        modstorico.WindowState = FormWindowState.Maximized
        modstorico.Focus()
        modstorico.Show()
        modstorico.TopMost = True
        modstorico.WindowState = FormWindowState.Normal
        modstorico.Activate()
    End Sub

    Private Sub ChiusuraTrilogis(sender As Object, e As EventArgs)
        If f.Visible = True Then
            f.Invoke(New MethodInvoker(AddressOf f.Dispose))
        End If
        modstorico.Invoke(New MethodInvoker(AddressOf modstorico.Dispose))
        LogFile.WriteLog("Fine sessione 3logis (Modalità storico)")
        RipristinoDBOriginale.ShowDialog()
        Return
    End Sub

    Private Function CaricaDatabaseStorico(annoScelto As String) As Boolean
        Dim Copiaok As Boolean = False
        If Not Directory.Exists(PercorsoArchiviazione + annoScelto) Then
            LogFile.WriteLog("Creazione cartella: " + Variables.PercorsoDatabase.Value + "/DBBK")
            Return False
        End If

        Try
            File.Copy(PercorsoArchiviazione + annoScelto + "/trilogis.fb20", Variables.PercorsoDatabase.Value + "/trilogis.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Recupero File riuscito: " + PercorsoArchiviazione + annoScelto + "/trilogis.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore recupero Database storico trilogis (" & PercorsoArchiviazione + annoScelto & "/trilogis.fb20)", ex)
            Copiaok = False
        End Try
        Try
            File.Copy(PercorsoArchiviazione + annoScelto + "/trilogislocalconf.fb20", Variables.PercorsoDatabase.Value + "/trilogislocalconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Recupero File riuscito: " + PercorsoArchiviazione + annoScelto + "/trilogislocalconf.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore recupero Database storico trilogislocalconf (" & PercorsoArchiviazione + annoScelto & "/trilogislocalconf.fb20)", ex)
            Copiaok = False
        End Try
        Try
            File.Copy(PercorsoArchiviazione + annoScelto + "/trilogisremoteconf.fb20", Variables.PercorsoDatabase.Value + "/trilogisremoteconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Recupero File riuscito: " + PercorsoArchiviazione + annoScelto + "/trilogisremoteconf.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore recupero Database storico trilogisremoteconf (" & PercorsoArchiviazione + annoScelto & "/trilogisremoteconf.fb20)", ex)
            Copiaok = False
        End Try

        If Copiaok Then
            LogFile.WriteLog("Recupero database completata")
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CopiaDatabaseCorrente() As Boolean
        Dim Copiaok As Boolean = False
        If Not Directory.Exists(Variables.PercorsoDatabase.Value + "/DBBK") Then
            Directory.CreateDirectory(Variables.PercorsoDatabase.Value + "/DBBK")
            LogFile.WriteLog("Creazione cartella: " + Variables.PercorsoDatabase.Value + "/DBBK")
        End If

        Try
            File.Copy(Variables.PercorsoDatabase.Value + "/trilogis.fb20", Variables.PercorsoDatabase.Value + "/DBBK/trilogis.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Copia File riuscita: " + Variables.PercorsoDatabase.Value + "/trilogis.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore Salvataggio Database: " & Variables.PercorsoDatabase.Value & "/trilogis.fb20", ex)
            Copiaok = False
        End Try
        Try
            File.Copy(Variables.PercorsoDatabase.Value + "/trilogislocalconf.fb20", Variables.PercorsoDatabase.Value + "/DBBK/trilogislocalconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Copia File riuscita: " + Variables.PercorsoDatabase.Value + "/trilogislocalconf.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore Salvataggio Database: " & Variables.PercorsoDatabase.Value & "/trilogislocalconf.fb20", ex)
            Copiaok = False
        End Try
        Try
            File.Copy(Variables.PercorsoDatabase.Value + "/trilogisremoteconf.fb20", Variables.PercorsoDatabase.Value + "/DBBK/trilogisremoteconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Copia File riuscita: " + Variables.PercorsoDatabase.Value + "/trilogisremoteconf.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore Salvataggio Database: " & Variables.PercorsoDatabase.Value & "/trilogisremoteconf.fb20", ex)
            Copiaok = False
        End Try

        If Copiaok Then
            LogFile.WriteLog("Copia database completata")
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        FormMain.Show()
        Me.Dispose()
    End Sub

    Private Function IsFileOpen(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing
        Dim open As Boolean = False
        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
            open = False
        Catch ex As Exception
            open = True
        End Try
        If open Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Function IsFileLocked(exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function
End Class
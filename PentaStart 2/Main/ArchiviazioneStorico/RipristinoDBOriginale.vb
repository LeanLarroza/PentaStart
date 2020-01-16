Imports System.IO
Imports System.Threading
Imports PentaStart.Utility

Public Class RipristinoDBOriginale
    Private Sub RicuperoDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub RicuperoDB_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Task.Run(RicuperareDB)
        'Dim t = New Task(AddressOf RicuperareDB)
        't.Start()
    End Sub

    Public Function RicuperareDB()
        Threading.Thread.Sleep(2000)
        Dim Copiaok As Boolean = False
        Try
            File.Copy(Variables.PercorsoDatabase.Value + "/DBBK/trilogis.fb20", Variables.PercorsoDatabase.Value + "/trilogis.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Ripristino File riuscito: " + Variables.PercorsoDatabase.Value + "/DBBK/trilogis.fb20")
        Catch ex As Exception
            LogFile.WriteLog("Errore Ripristino Database: " + Variables.PercorsoDatabase.Value + "/DBBK/trilogis.fb20")
            LogFile.WriteLog("Errore Ripristino Database: " + ex.ToString())
            MessageBox.Show("Errore recupero Database storico trilogis " + ex.ToString(), "PentaStart")
            Copiaok = False
        End Try
        Try
            File.Copy(Variables.PercorsoDatabase.Value + "/DBBK/trilogislocalconf.fb20", Variables.PercorsoDatabase.Value + "/trilogislocalconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Ripristino File riuscito: " + Variables.PercorsoDatabase.Value + "/DBBK/trilogislocalconf.fb20")
        Catch ex As Exception
            LogFile.WriteLog("Errore Ripristino Database: " + Variables.PercorsoDatabase.Value + "/DBBK/trilogislocalconf.fb20")
            LogFile.WriteLog("Errore Ripristino Database: " + ex.ToString())
            MessageBox.Show("Errore recupero Database storico trilogislocalconf " + ex.ToString(), "PentaStart")
            Copiaok = False
        End Try
        Try
            File.Copy(Variables.PercorsoDatabase.Value + "/DBBK/trilogisremoteconf.fb20", Variables.PercorsoDatabase.Value + "/trilogisremoteconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Ripristino File riuscito: " + Variables.PercorsoDatabase.Value + "/DBBK/trilogisremoteconf.fb20")
        Catch ex As Exception
            LogFile.WriteLog("Errore Ripristino Database: " + Variables.PercorsoDatabase.Value + "/DBBK/trilogisremoteconf.fb20")
            LogFile.WriteLog("Errore Ripristino Database: " + ex.ToString())
            MessageBox.Show("Errore recupero Database storico trilogisremoteconf " + ex.ToString(), "PentaStart")
            Copiaok = False
        End Try

        If Not Copiaok Then
            LogFile.WriteLog("===============================================")
            LogFile.WriteLog("Errore Ripristino Database: Fare copia manuale")
            LogFile.WriteLog("===============================================")
            MessageBox.Show("Errore nel ripristino del database. Copiare manuelamente i files dentro C:/trilogis/DBBK", "PentaStart")
        End If

        Me.Invoke(New MethodInvoker(AddressOf Me.Close))
        Return True
    End Function
End Class
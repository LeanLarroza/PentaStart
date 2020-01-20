Imports System.IO
Imports System.Threading
Imports PentaStart.Utility
Imports PentaStart.Variables

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
            File.Copy(Variables.PercorsoDatabase.Value & "/DBBK/trilogis.fb20", Variables.PercorsoDatabase.Value & "/trilogis.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Ripristino File riuscito: " & Variables.PercorsoDatabase.Value & "/DBBK/trilogis.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore Ripristino Database: " & Variables.PercorsoDatabase.Value & "/DBBK/trilogis.fb20", ex)
            Copiaok = False
        End Try
        Try
            File.Copy(Variables.PercorsoDatabase.Value & "/DBBK/trilogislocalconf.fb20", Variables.PercorsoDatabase.Value & "/trilogislocalconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Ripristino File riuscito: " & Variables.PercorsoDatabase.Value & "/DBBK/trilogislocalconf.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore Ripristino Database: " & Variables.PercorsoDatabase.Value & "/DBBK/trilogislocalconf.fb20", ex)
            Copiaok = False
        End Try
        Try
            File.Copy(Variables.PercorsoDatabase.Value & "/DBBK/trilogisremoteconf.fb20", Variables.PercorsoDatabase.Value & "/trilogisremoteconf.fb20", True)
            Copiaok = True
            LogFile.WriteLog("Ripristino File riuscito: " & Variables.PercorsoDatabase.Value & "/DBBK/trilogisremoteconf.fb20")
        Catch ex As Exception
            MostraErrore(Me, "Errore Ripristino Database: " & Variables.PercorsoDatabase.Value & "/DBBK/trilogisremoteconf.fb20", ex)
            Copiaok = False
        End Try

        If Not Copiaok Then
            LogFile.WriteLog("===============================================")
            LogFile.WriteLog("Errore Ripristino Database: Fare copia manuale")
            LogFile.WriteLog("===============================================")
            MostraErrore(Me, "Errore nel ripristino del database. Copiare manuelamente i files C:/trilogis/DBBK su " & PercorsoDatabase.Value)
        End If

        Me.Invoke(New MethodInvoker(AddressOf Me.Close))
        Return True
    End Function
End Class
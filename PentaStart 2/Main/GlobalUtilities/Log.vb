Imports System.IO

Public Class Log
    Public PercorsoLog As String = Application.StartupPath + "\\Logs\\" + DateTime.Now.ToString("yyyyMMdd") + "-PENTASTART.log"

    Public Sub AvvioProgramma()
        WriteLog("------------------------------------------------------------")
        WriteLog("AVVIO: " + Application.ProductName)
    End Sub

    Public Sub ChisuraProgramma()
        WriteLog("CHIUSURA: " + Application.ProductName)
        WriteLog("------------------------------------------------------------")
    End Sub

    Public Sub InizializzareLog()
        If Not File.Exists(PercorsoLog) Then
            If Not Directory.Exists(Application.StartupPath + "\\Logs") Then
                Directory.CreateDirectory(Application.StartupPath + "\\Logs")
                Dim filelog As FileStream = File.Create(PercorsoLog)
                filelog.Dispose()
            End If
        End If
        AvvioProgramma()
    End Sub

    Public Sub WriteLog(log As String)
        File.AppendAllText(PercorsoLog, "[" + DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss") + "] --> " + log + Environment.NewLine)
    End Sub

End Class

Imports PentaStart.Utility
Public Class SAT
    Public WithEvents TimerSAT As New Timer
    Private Sub Buttonexito_Click(sender As Object, e As EventArgs) Handles Buttonexito.Click
        Me.Hide()
    End Sub

    Private Sub SAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogFile.WriteLog("Avviso servizio di assistenza scaduto aperto")
        Me.TopMost = True
    End Sub
End Class

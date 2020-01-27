Imports PentaStart.Utility
Public Class RiavvioPC
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        ChiusuraDriverScontrino()
        System.Diagnostics.Process.Start("shutdown", "-r -t 00")
        LogFile.WriteLog("Riavvio PC in corso...")
        LogFile.ChisuraProgramma()
        Application.Exit()
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Hide()
        FormMain.Show()
    End Sub

    Private Sub RiavvioPC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdjustText(Label1)
        AdjustText(Label2)
    End Sub
End Class
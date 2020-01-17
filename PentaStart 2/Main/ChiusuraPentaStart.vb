Imports PentaStart.Utility
Public Class ChiusuraPentaStart
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        ChiusuraProgramma("FattElett")
        ChiusuraProgramma("SoEcrCom")
        ChiusuraProgramma("NomePronto")
        LogFile.ChisuraProgramma()
        Application.Exit()
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Hide()
        FormMain.Show()
    End Sub

    Private Sub ChiusuraPentaStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdjustText(Label1)
    End Sub
End Class
Imports PentaStart.Utility
Public Class AnnoStorico
    Public AnnoScelto As String
    Private Sub AnnoStorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogFile.WriteLog("Scelta anno storico in corso...")
        anno.Text = DateTime.Now.ToString("yyyy")
        AnnoScelto = anno.Text
    End Sub

    Private Sub Avanti_Click(sender As Object, e As EventArgs) Handles avanti.Click
        Dim annolabel As DateTime = New DateTime(Convert.ToInt32(anno.Text), 1, 1)
        annolabel = annolabel.AddYears(1)
        anno.Text = annolabel.ToString("yyyy")
        AnnoScelto = anno.Text
    End Sub

    Private Sub Indietro_Click(sender As Object, e As EventArgs) Handles indietro.Click
        Dim annolabel As DateTime = New DateTime(Convert.ToInt32(anno.Text), 1, 1)
        annolabel = annolabel.AddYears(-1)
        anno.Text = annolabel.ToString("yyyy")
        AnnoScelto = anno.Text
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
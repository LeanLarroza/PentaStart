Public Class NumeroForm
    Public NumeroIniziale As String
    Public NumeroInserito As String
    Private PrimaModifica As Boolean = False
    Private Sub NumeroForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textNumero.Text = NumeroIniziale
        PrimaModifica = True
    End Sub

    Private Sub ButtonConferma_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        NumeroInserito = textNumero.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Number_Click(sender As Button, e As EventArgs) Handles N9.Click, N8.Click, N7.Click, N6.Click, N5.Click, N4.Click, N3.Click, N2.Click, N1.Click, N00.Click, N0.Click
        If PrimaModifica = True Then
            PrimaModifica = False
            textNumero.Text = sender.Text
        Else
            textNumero.Text = textNumero.Text & sender.Text
        End If
    End Sub

    Private Sub NReset_Click(sender As Object, e As EventArgs) Handles NReset.Click
        textNumero.Text = "0"
        PrimaModifica = True
    End Sub

    Private Sub NCancella_Click(sender As Object, e As EventArgs) Handles NCancella.Click
        PrimaModifica = False
        textNumero.Text = textNumero.Text.Substring(0, textNumero.Text.Length - 1)
    End Sub

    Private Sub NVirgola_Click(sender As Object, e As EventArgs) Handles NVirgola.Click
        PrimaModifica = False
        If textNumero.Text = "0" Then
            textNumero.Text = "0,"
        Else
            textNumero.Text = textNumero.Text & sender.Text
        End If
    End Sub
End Class
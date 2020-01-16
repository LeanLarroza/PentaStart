Public Class BannerStorico
    Private Sub ShowStorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CaricamentoLogo()
    End Sub

    Private Sub CaricamentoLogo()
        Dim x As Integer
        Dim y As Integer
        x = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (373 / 2)
        y = 0
        Me.Location = New Point(x, y)
    End Sub
End Class
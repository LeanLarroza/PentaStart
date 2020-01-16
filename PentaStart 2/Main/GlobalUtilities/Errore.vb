Imports System.Text
Imports PentaStart.Utility
Public Class Errore
    Public Messagio As String = ""

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Dispose()
        FormMain.Show()
    End Sub

    Private Sub Errore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sb As StringBuilder = New StringBuilder(Messagio)
        Dim spaces As Integer = 0
        Dim length As Integer = sb.Length
        For i As Integer = 0 To length - 1
            If sb(i) = " " Then
                spaces = spaces + 1
            ElseIf sb(i) = Environment.NewLine Then
                spaces = 0
            End If
            If spaces = 6 Then
                sb.Insert(i, Environment.NewLine)
                spaces = 0
            End If
        Next
        LogFile.WriteLog("Form di errore visualizzato: " + Messagio)
        lbErrore.Text = sb.ToString()
        AdjustText(Label1)
        AdjustText(lbErrore)
    End Sub
End Class
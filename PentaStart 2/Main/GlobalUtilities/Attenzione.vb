Imports System.Text
Imports PentaStart.Utility
Public Class Attenzione
    Public Messagio As String = ""
    Private Sub Buttonexito_Click(sender As Object, e As EventArgs) Handles Buttonexito.Click
        Me.Close()
    End Sub

    Private Sub Completato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        lbMessagio.Text = sb.ToString()
        AdjustText(Label3)
        AdjustText(lbMessagio)
    End Sub
End Class
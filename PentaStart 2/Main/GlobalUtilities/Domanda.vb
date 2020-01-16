Imports System.Text
Imports PentaStart.Utility
Public Class Domanda
    Public Messagio As String

    Private Sub Domanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        LabelMessagio.Text = sb.ToString()
        AdjustText(Label1)
        AdjustText(LabelMessagio)
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.DialogResult = DialogResult.No
        Me.Dispose()
    End Sub

    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        Me.DialogResult = DialogResult.Yes
        Me.Dispose()
    End Sub
End Class
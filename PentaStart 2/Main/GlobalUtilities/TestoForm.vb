Imports System.Windows.Forms
Imports PentaStart.Utility
Public Class TestoForm

    Private NasconderePassword As Boolean = False
    Private Maioscolo As Boolean = False
    Private abc As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
    Public Intestazione As String = ""
    Public TestoIniziale As String = ""
    Public TestoScritto As String = ""
    Public MinLenght As Integer
    Public MaxLenght As Integer

    Private Sub AdminPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogFile.WriteLog("Inserimento testo:" & Intestazione & " in corso...")
        Label1.Text = Intestazione
        textLabel.Text = TestoIniziale
        AdjustText(Label1)
        textLabel.PasswordChar = ""
        NasconderePassword = False
        Maioscolo = False
        Me.ActiveControl = textLabel
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles N8.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click, Button1.Click
        If textLabel.BackColor = Color.Red Then
            textLabel.BackColor = Color.White
        End If
        textLabel.Text = textLabel.Text & sender.Text
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        If textLabel.BackColor = Color.Red Then
            textLabel.BackColor = Color.White
        End If
        textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length - 1)
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        If textLabel.BackColor = Color.Red Then
            textLabel.BackColor = Color.White
        End If
        textLabel.Text = ""
        Me.ActiveControl = textLabel
    End Sub

    Private Sub ButtonConferma_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        If Not MinLenght = 0 And Not MaxLenght = 0 Then
            If textLabel.Text.Length >= MinLenght And textLabel.Text.Length <= MaxLenght Then
                TestoScritto = textLabel.Text
                Me.DialogResult = DialogResult.OK
                Me.Dispose()
            Else
                textLabel.BackColor = Color.Red
                Return
            End If
        Else
            TestoScritto = textLabel.Text
            Me.DialogResult = DialogResult.OK
            Me.Dispose()
        End If
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.DialogResult = DialogResult.Abort
        Me.Dispose()
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        If NasconderePassword Then
            NasconderePassword = False
            textLabel.PasswordChar = ""
        Else
            NasconderePassword = True
            textLabel.PasswordChar = "•"
        End If
    End Sub

    Private Sub TextPassword_TextChanged(sender As Object, e As EventArgs) Handles textLabel.TextChanged
        If NasconderePassword Then
            textLabel.PasswordChar = "•"
        End If
    End Sub

    Private Sub Button39_Click_1(sender As Object, e As EventArgs) Handles Button39.Click
        If Maioscolo Then
            For Each button As Control In Me.Controls
                If abc.Contains(button.Text.ToLower) Then
                    button.Text = button.Text.ToLower()
                End If
            Next
            Maioscolo = False
        Else
            For Each button As Control In Me.Controls
                If abc.Contains(button.Text.ToLower) Then
                    button.Text = button.Text.ToUpper()
                End If
            Next
            Maioscolo = True
        End If
    End Sub
End Class

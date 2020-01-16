Imports System.Windows.Forms
Imports PentaStart.Utility
Public Class AdminPassword

    Private NasconderePassword As Boolean = False

    Private Sub AdminPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogFile.WriteLog("Inserimento password amministratore in corso...")
        textPassword.PasswordChar = ""
        NasconderePassword = True
        Me.ActiveControl = textPassword
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles N8.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click, Button1.Click
        If textPassword.BackColor = Color.Red Then
            textPassword.BackColor = Color.White
        End If
        textPassword.Text = textPassword.Text & sender.Text
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        If textPassword.BackColor = Color.Red Then
            textPassword.BackColor = Color.White
        End If
        textPassword.Text = textPassword.Text.Substring(0, textPassword.Text.Length - 1)
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        If textPassword.BackColor = Color.Red Then
            textPassword.BackColor = Color.White
        End If
        textPassword.Text = ""
        Me.ActiveControl = textPassword
    End Sub

    Private Sub ButtonConferma_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        If textPassword.Text = "penta" & Now.ToString("ddMMyy") Then
            textPassword.BackColor = Color.LightGreen
            Me.DialogResult = DialogResult.OK
            Me.Dispose()
        Else
            textPassword.BackColor = Color.Red
        End If
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.DialogResult = DialogResult.Abort
        Me.Dispose()
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        If NasconderePassword Then
            NasconderePassword = False
            textPassword.PasswordChar = ""
        Else
            NasconderePassword = True
            textPassword.PasswordChar = "•"
        End If
    End Sub

    Private Sub TextPassword_TextChanged(sender As Object, e As EventArgs) Handles textPassword.TextChanged
        If NasconderePassword Then
            textPassword.PasswordChar = "•"
        End If
    End Sub
End Class

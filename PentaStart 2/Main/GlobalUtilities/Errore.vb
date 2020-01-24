Imports System.Text
Imports PentaStart.Utility
Public Class Errore
    Public Messagio As String = ""
    Public Secondi As Integer = 10
    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Dispose()
        FormMain.Show()
    End Sub

    Private Sub Errore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Secondi = 10
        LabelSecondi.Text = Secondi.ToString()
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
        Dim TimerAutoclose As New Timer
        TimerAutoclose.Interval = 1000
        TimerAutoclose.Start()
        AddHandler TimerAutoclose.Tick, AddressOf OnTick
    End Sub

    Private Sub OnTick(sender As Timer, e As EventArgs)
        If Secondi > 1 Then
            Secondi = Secondi - 1
            LabelSecondi.Text = Secondi.ToString()
            sender.Stop()
            sender.Start()
        Else
            Me.Dispose()
        End If
    End Sub
End Class
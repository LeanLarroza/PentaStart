Imports System.IO
Imports System.Timers
Imports IWshRuntimeLibrary
Imports PentaStart.Utility

Public Class BannerLogoPenta
    Private Sub ShowLogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CaricamentoLogo()

        'ControlloScadenzaSW()

    End Sub

    Private Sub ControlloScadenzaSW()
        Throw New NotImplementedException()
    End Sub


    Private Sub CaricamentoLogo()
        Dim x As Integer
        Dim y As Integer
        If Variables.LogoPenta.Value = 2 Then
            LogFile.WriteLog("Caricamento logo PENTA - Tipo: 2 - In Basso")
            x = Screen.PrimaryScreen.WorkingArea.Width - 177
            y = Screen.PrimaryScreen.WorkingArea.Height
            Me.Location = New Point(x, y)
        ElseIf Variables.LogoPenta.Value = 1 Then
            LogFile.WriteLog("Caricamento logo PENTA - Tipo: 1 - In Alto")
            x = Screen.PrimaryScreen.WorkingArea.Width / 2
            y = 0
        End If

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick, MyBase.MouseClick
        Dim localByName As Process() = Process.GetProcessesByName("TeamViewer")
        For Each p As Process In localByName
            p.Kill()
        Next p

        If IO.File.Exists("C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe") Then
            LogFile.WriteLog("Creazione collegamento TeamViewer")
            If Not IO.File.Exists(Application.StartupPath + "\TeamViewer.lnk") Then
                Dim wsh As WshShellClass = New WshShellClass()
                Dim Shortcut As IWshRuntimeLibrary.IWshShortcut = wsh.CreateShortcut(Application.StartupPath + "\TeamViewer.lnk")
                Shortcut.Arguments = ""
                Shortcut.TargetPath = "C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe"
                Shortcut.WindowStyle = 1
                Shortcut.Description = "TeamViewer"
                Shortcut.WorkingDirectory = "C:\\Program Files (x86)\\TeamViewer"
                Shortcut.IconLocation = "C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe"
                Shortcut.Save()
            End If
            LogFile.WriteLog("Apertura TeamViewer in corso...")
            Process.Start(Application.StartupPath + "\TeamViewer.lnk")
        Else
            LogFile.WriteLog("TeamViewer non trovato")
            MsgBox("Il programma di TeleAssistenza non è stato installato",, "PentaStart")
        End If
    End Sub
End Class
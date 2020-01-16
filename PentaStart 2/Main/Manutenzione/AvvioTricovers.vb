Imports PentaStart.Utility
Public Class AvvioTricovers
    Private Sub ButtonSI_Click(sender As Object, e As EventArgs) Handles ButtonSI.Click
        If (Variables.Software.Value = "trilogis") Then
            ControlloSoftwareAperto()
            LogFile.WriteLog("Avvio Tricovers in corso...")
            Dim tricovers As System.Diagnostics.Process = New System.Diagnostics.Process()
            tricovers.StartInfo.FileName = "C:\trilogis\TricoverS.exe"
            tricovers.StartInfo.WorkingDirectory = "C:\trilogis"
            tricovers.Start()
            LogFile.ChisuraProgramma()
            Environment.Exit(0)
        ElseIf (Variables.Software.Value = "laundry") Then
            ControlloSoftwareAperto()
            LogFile.WriteLog("Avvio Tricovers in corso...")
            Process.Start("C:\Program Files (x86)\Laundry32\CarScar.exe")
            LogFile.ChisuraProgramma()
            Environment.Exit(0)
        End If
    End Sub
    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Me.Hide()
        formutility.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
Imports System.Threading

Public Class KeyBoard
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private pOSK As Process = Nothing

    Public Sub Keyboard_Show()
        'An instance is running => Dan wordt pOSK het bestaande proces
        For Each pkiller As Process In Process.GetProcesses
            If String.Compare(pkiller.ProcessName, "osk", True) = 0 Then pOSK = pkiller
        Next

        'If no instance of OSK is running than create one depending on 32/64 bit
        For Each pkiller As Process In Process.GetProcesses
            If Not (String.Compare(pkiller.ProcessName, "osk", True) = 0) And (pOSK Is Nothing) Then

                Dim old As Long
                If Environment.Is64BitOperatingSystem Then
                    '64 Bit
                    If Wow64DisableWow64FsRedirection(old) Then
                        pOSK = Process.Start(osk)
                        Wow64EnableWow64FsRedirection(old)
                    End If
                Else
                    '32 Bit
                    pOSK = Process.Start(osk)
                End If
                Exit For
            End If
        Next
    End Sub

    '-------------------------------------------------
    '--- Hide On Screen Keypad mbv process threads ---
    '--- 05-07-2018                                ---
    '-------------------------------------------------
    Public Sub Keyboard_Hide()
        For Each pkiller As Process In Process.GetProcesses
            If String.Compare(pkiller.ProcessName, "osk", True) = 0 And Not (pOSK Is Nothing) Then

                ' Terminate process
                pOSK.Kill()
                Exit For
            End If
        Next

        'Wait untill proces is really terminated
        For intStap As Integer = 1 To 10
            For Each pkiller As Process In Process.GetProcesses
                If String.Compare(pkiller.ProcessName, "osk", True) = 0 Then
                    Thread.Sleep(1000)
                Else
                    pOSK = Nothing
                    Exit For
                End If
            Next
        Next intStap
    End Sub
End Class

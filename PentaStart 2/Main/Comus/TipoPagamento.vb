Imports System.IO
Imports PentaStart.Utility
Public Class TipoPagamento

    Public Str As String = ""
    Public contantiscelto As Boolean = False
    Public cartascelto As Boolean = False
    Public nonriscossoscelto As Boolean = False
    Public annulloscelto As Boolean = False
    Public percorsowinecr As String = ""

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If contantiscelto = True Then
            contantiscelto = False
            Str = Str.Replace("chius t=1", "chius t=1")
            Try
                File.WriteAllText(percorsowinecr.Replace("/", "\") + "\TOSEND\scontrini.txt", Str)
            Catch ex As Exception
                MostraErrore(Me, "Impossibile stampare lo scontrino.", ex)
            End Try
            Me.Dispose()
        Else
            contantiscelto = True
            cartascelto = False
            nonriscossoscelto = False
            annulloscelto = False
            Button3.FlatAppearance.BorderColor = Color.Red
            Button3.FlatAppearance.BorderSize = 4
            Button1.FlatAppearance.BorderColor = Color.RoyalBlue
            Button1.FlatAppearance.BorderSize = 2
            Button2.FlatAppearance.BorderColor = Color.RoyalBlue
            Button2.FlatAppearance.BorderSize = 2
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If nonriscossoscelto = True Then
            nonriscossoscelto = False
            Str = Str.Replace("chius t=1", "chius t=2")
            Try
                File.WriteAllText(percorsowinecr.Replace("/", "\") + "\TOSEND\scontrini.txt", Str)
            Catch
            End Try
            Me.Dispose()
        Else
            contantiscelto = False
            cartascelto = False
            nonriscossoscelto = True
            annulloscelto = False
            Button3.FlatAppearance.BorderColor = Color.RoyalBlue
            Button3.FlatAppearance.BorderSize = 2
            Button1.FlatAppearance.BorderColor = Color.RoyalBlue
            Button1.FlatAppearance.BorderSize = 2
            Button2.FlatAppearance.BorderColor = Color.Red
            Button2.FlatAppearance.BorderSize = 4
        End If
    End Sub

    Private Sub ButtonAnnullo_Click(sender As Object, e As EventArgs)
        If annulloscelto = True Then
            annulloscelto = False
            File.Delete(percorsowinecr.Replace("/", "\") + "\scontrini.txt")
            Me.Dispose()
        Else
            contantiscelto = False
            cartascelto = False
            nonriscossoscelto = False
            annulloscelto = True
            Button3.FlatAppearance.BorderColor = Color.RoyalBlue
            Button3.FlatAppearance.BorderSize = 2
            Button1.FlatAppearance.BorderColor = Color.RoyalBlue
            Button1.FlatAppearance.BorderSize = 2
            Button2.FlatAppearance.BorderColor = Color.RoyalBlue
            Button2.FlatAppearance.BorderSize = 2
        End If
    End Sub

    Public Sub SceglierePagamento(FileString As String, WINECR As String)
        Str = FileString
        percorsowinecr = WINECR
        Button1.FlatAppearance.BorderSize = 2
        Button1.FlatAppearance.BorderColor = Color.RoyalBlue
        Button2.FlatAppearance.BorderSize = 2
        Button2.FlatAppearance.BorderColor = Color.RoyalBlue
        Button3.FlatAppearance.BorderSize = 2
        Button3.FlatAppearance.BorderColor = Color.RoyalBlue
        contantiscelto = False
        cartascelto = False
        nonriscossoscelto = False
        annulloscelto = False
        Me.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If cartascelto = True Then
            cartascelto = False
            Str = Str.Replace("chius t=1", "chius t=5")
            Try
                File.WriteAllText(percorsowinecr.Replace("/", "\") + "\TOSEND\scontrini.txt", Str)
            Catch
            End Try
            Me.Dispose()
        Else
            contantiscelto = False
            cartascelto = True
            nonriscossoscelto = False
            annulloscelto = False
            Button3.FlatAppearance.BorderColor = Color.RoyalBlue
            Button3.FlatAppearance.BorderSize = 2
            Button1.FlatAppearance.BorderColor = Color.Red
            Button1.FlatAppearance.BorderSize = 4
            Button2.FlatAppearance.BorderColor = Color.RoyalBlue
            Button2.FlatAppearance.BorderSize = 2
        End If
    End Sub
End Class
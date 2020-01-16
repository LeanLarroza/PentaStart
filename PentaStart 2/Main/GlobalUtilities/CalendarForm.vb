Imports System.Globalization

Public Class CalendarForm
    Public DataIniziale As Date
    Public DataScelta As Date
    Dim Mese As Integer
    Dim Anno As Integer
    Dim Giorno As Integer
    Dim ndayz As Int32
    Dim Dayofweek, CurrentCulture As String
    Dim lblDayz As Label
    Dim y As Int32 = 0
    Dim x As Int32
    Dim labelscelto As Label

    Private Sub CalendarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataScelta = DataIniziale
        Mese = DataScelta.Month
        Anno = DataScelta.Year
        Giorno = DataScelta.Day
        GeneraCalendario()
    End Sub

    Private Sub GeneraCalendario()
        Panel1.Visible = False
        Panel1.Controls.Clear()
        Dim Dayz As Int32 = DateTime.DaysInMonth(Anno, Mese)
        labelMese.Text = Application.CurrentCulture.DateTimeFormat.GetMonthName(Mese)
        LabelAnno.Text = Anno
        CheckDay()
        For i As Int32 = 1 To Dayz
            ndayz += 1
            lblDayz = New Label()
            lblDayz.Name = "B" & i
            lblDayz.Text = i.ToString()
            lblDayz.BorderStyle = BorderStyle.FixedSingle
            If i = Giorno Then
                lblDayz.BackColor = Color.RoyalBlue
                labelscelto = lblDayz
            ElseIf ndayz = 1 Then
                lblDayz.BackColor = Color.LightGray
            Else
                lblDayz.BackColor = Color.LightGray
            End If
            lblDayz.Font = New Font(labelMese.Font.Name, 13, FontStyle.Bold)
            lblDayz.SetBounds(x, y, 105, 55)
            x += 105
            If ndayz = 7 Then
                x = 0
                ndayz = 0
                y += 55
            End If
            AddHandler lblDayz.Click, AddressOf CambioGiorno
            Panel1.Controls.Add(lblDayz)
        Next
        x = 0
        ndayz = 0
        y = 0
        Panel1.Visible = True
    End Sub

    Function CheckDay() As Int32
        Dim time As DateTime = New DateTime(Anno, Mese, 1)
        'get the start day of the week for the entered date and month
        Dayofweek = Application.CurrentCulture.Calendar.GetDayOfWeek(time).ToString()
        If Dayofweek = "Sunday" Then
            x = 0
        ElseIf Dayofweek = "Monday" Then
            x = 0 + 105
            ndayz = 1
        ElseIf Dayofweek = "Tuesday" Then
            x = 0 + 105 + 105
            ndayz = 2
        ElseIf Dayofweek = "Wednesday" Then
            x = 0 + 105 + 105 + 105
            ndayz = 3
        ElseIf Dayofweek = "Thursday" Then
            x = 0 + 105 + 105 + 105 + 105
            ndayz = 4
        ElseIf Dayofweek = "Friday" Then
            x = 0 + 105 + 105 + 105 + 105 + 105
            ndayz = 5
        ElseIf Dayofweek = "Saturday" Then
            x = 0 + 105 + 105 + 105 + 105 + 105 + 105
            ndayz = 6
        End If
        Return x
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Mese - 1 = 0 Then
            Anno = Anno - 1
            Mese = 12
        Else
            Mese = Mese - 1
        End If
        GeneraCalendario()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If Mese + 1 = 13 Then
            Anno = Anno + 1
            Mese = 1
        Else
            Mese = Mese + 1
        End If
        GeneraCalendario()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Anno = Anno - 1
        GeneraCalendario()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Anno = Anno + 1
        GeneraCalendario()
    End Sub

    Private Sub ButtonConferma_Click(sender As Object, e As EventArgs) Handles ButtonConferma.Click
        DataScelta = New Date(Anno, Mese, Giorno)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonIndietro_Click(sender As Object, e As EventArgs) Handles ButtonIndietro.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CambioGiorno(ByVal sender As Label, ByVal e As System.EventArgs)
        Panel1.Controls.Item(labelscelto.Name).BackColor = Color.LightGray
        labelscelto = sender
        Giorno = CInt(sender.Name.Replace("B", ""))
        sender.BackColor = Color.RoyalBlue
    End Sub
End Class
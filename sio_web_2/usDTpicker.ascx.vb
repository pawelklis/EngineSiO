Public Class usDTpicker
    Inherits System.Web.UI.UserControl

    Public Property Text As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        If Not IsDate(Me.Text) Then
            Me.Text = Now
        End If

        Me.txDateTime.Text = Me.Text
        Nind()

        If Not IsPostBack Then
            Me.pn1.Style("visibility") = "hidden"
        Else
            Me.pn1.Style("visibility") = "visible"
        End If


    End Sub
    Sub Nind()
        Dim s As String = Me.Calendar1.SelectedDate & " " & ddH.SelectedValue & ":" & ddM.SelectedValue
        If Not IsDate(Me.Text) Then
            Me.Text = Now
        End If

        Me.Text = s

        If Not IsDate(Me.Text) Then
            Me.Text = Now
        End If

        Me.txDateTime.Text = Me.Text

        Dim d As Date = Me.Text

        Me.Calendar1.SelectedDate = d.ToShortDateString
        Me.ddH.SelectedValue = d.Hour.ToString("00")
        Me.ddM.SelectedValue = d.Minute.ToString("00")

    End Sub

    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs)
        Nind()

    End Sub
    Protected Sub ddH_SelectedIndexChanged(sender As Object, e As EventArgs)
        Nind()
    End Sub
    Protected Sub ddM_SelectedIndexChanged(sender As Object, e As EventArgs)
        Nind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Me.pn1.Style("visibility") = "hidden"
    End Sub
End Class
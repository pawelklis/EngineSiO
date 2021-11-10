
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class ContentType

    Public Property _Id As String
    Public Property Key As String
    Public Property Value As String
    Public Property Contents As List(Of ContentType)
    Public Property CreateTime As DateTime

    Sub New()
        Me._Id = Guid.NewGuid.ToString
    End Sub



    Public Function Getcontrols() As List(Of Control)
        Getcontrols = New List(Of Control)
        Dim lb As Label
        Getcontrols.Add(New LiteralControl("<div style='border-style:solid;'>"))
        Getcontrols.Add(New LiteralControl("<p>" & Me.CreateTime & "</p>"))

        lb = New Label
        lb.Text = Me.Key
        lb.ID = Me._Id
        Getcontrols.Add(lb)

        lb = New Label
        lb.Text = Me.Value
        lb.ID = Me._Id
        Getcontrols.Add(lb)

        If Not IsNothing(Me.Contents) Then
            For Each ccc In Me.Contents
                For Each cccc In ccc.Getcontrols
                    Getcontrols.Add(cccc)
                Next

                Getcontrols.Add(New LiteralControl("</br>"))
            Next
        End If
        Getcontrols.Add(New LiteralControl("</div>"))
    End Function
End Class

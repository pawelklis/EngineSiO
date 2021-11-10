Imports engineSIO


Public Class PostControl
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Timer1.Interval = 2000

    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debug.Print(Me.ID)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim l As New List(Of InfoType)
        l = InfoType.Load()


        For Each i In l
            For Each c In i.Content

                For Each cc In c.Getcontrols
                    Me.PlaceHolder1.Controls.Add(cc)
                Next

                Me.PlaceHolder1.Controls.Add(New LiteralControl("</br>"))


                If Not IsNothing(i.Comments) Then

                    For Each com In i.Comments

                        For Each ic In com.Content.Getcontrols
                            Me.PlaceHolder1.Controls.Add(ic)
                        Next


                    Next

                End If

            Next


        Next
    End Sub
End Class
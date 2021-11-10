Imports EngineSiO

Public Class wbnots
    Inherits System.Web.UI.Page
    Dim s As sessionClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Interval = 5000
        CheckNotifies()
    End Sub
    Sub CheckNotifies()
        s = Session("sesja")
        Try
            Dim nots As List(Of NotifyType) = NotifyType.Load(s.User.Id, False)

            Console.WriteLine("Powiadomienia:" & nots.Count)

            For Each n In nots

                Dim sc As String = "
Shown('" & n.Content & "')
"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "notify", sc, True)

                n.Readed = "true"
                n.Save()
                'Dim m As New mongoDBCore
                'm.Delete(Of NotifyType)("notify", n)

            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        s = Session("sesja")


    End Sub
    Protected Sub Unnamed_Tick(sender As Object, e As EventArgs)

        CheckNotifies()


    End Sub
End Class
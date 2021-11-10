Imports EngineSiO




Public Class start
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub




    Private Sub start_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim infoCont As New InfoContainer
        infoCont = infoCont.LoadControl("InfoContainer.ascx")
        Me.PlaceHolder1.Controls.Add(infoCont)



        Dim newinfoctl As New NewInfoControl
        newinfoctl = newinfoctl.LoadControl("NewInfoControl.ascx")
        Me.PlaceHolder2.Controls.Add(newinfoctl)





    End Sub


End Class
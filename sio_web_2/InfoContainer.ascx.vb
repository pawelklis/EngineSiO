Imports EngineSiO

Public Class InfoContainer
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub Bind()

        Dim l As New List(Of InfoType)
        l = InfoType.Load()
        If IsNothing(l) Then Exit Sub

        For Each i In l

            Dim cc As New infoControl
            cc = cc.LoadControl("infoControl.ascx")
            cc.info = i
            Me.PlaceHolder1.Controls.Add(cc)

        Next



    End Sub

    Private Sub InfoContainer_Init(sender As Object, e As EventArgs) Handles Me.Init
        Bind()
    End Sub
End Class
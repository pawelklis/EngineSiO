Imports EngineSiO

Public Class contentControl
    Inherits System.Web.UI.UserControl

    Public Property Content As ContentType
    Public Property user As UserType

    Public Property Info As InfoType


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lbTime.Text = Content.CreateTime
        Me.lbKey.Text = Content.Key
        Me.lbValue.Text = Content.Value
        Me.lbUser.Text = user.Name

        If Not IsNothing(Content.Contents) Then

            For Each c In Content.Contents

                Dim cc As contentControl
                cc = New contentControl
                cc = cc.LoadControl("contentControl.ascx")
                cc.Content = c
                cc.user = Me.user
                Me.PlaceHolder1.Controls.Add(cc)

            Next


        End If




    End Sub

End Class
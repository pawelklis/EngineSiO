Imports EngineSiO

Public Class CommentControl
    Inherits System.Web.UI.UserControl

    Public Property Comment As CommentType
    Public Property Info As InfoType


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cc As contentControl
        cc = New contentControl
        cc = cc.LoadControl("contentControl.ascx")
        cc.Content = Me.Comment.Content
        cc.user = UserType.Load(Me.Comment.UserId)
        Me.PlaceHolder1.Controls.Add(cc)


        Dim rc As New controlReaction

        rc = rc.LoadControl("controlReaction.ascx")
        rc.reacts = Me.Comment.Reactions
        rc.Info = Me.Info
        rc.Comment = Me.Comment
        rc.WhatIsParent = controlReaction.PCenum.Comment
        Me.PlaceHolder2.Controls.Add(rc)

    End Sub

End Class
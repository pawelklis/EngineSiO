Imports EngineSiO

Public Class infoControl
    Inherits System.Web.UI.UserControl

    Public Property info As InfoType

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




    End Sub

    Protected Sub lnkAddComment_Click(sender As Object, e As EventArgs)
        pnNewComment.Visible = True
        lbCommentInfoId.Text = sender.CommandArgument

    End Sub
    Sub Bind()

        Me.PlaceHolder1.Controls.Clear()

        Me.PlaceHolder3.Controls.Clear()


        Me.lbTime.Text = info.CreateTime
        Try
            Me.lbUser.Text = info.User.Name
        Catch ex As Exception

        End Try

        Me.lbOrg.Text = info.OrganizationUnit.Name
        Me.lbZone.Text = info.Zone.Name
        ' Me.lbCategory.Text = Me.info.InfoCategoryType.Name

        For Each c In Me.info.Content

            Dim cc As contentControl
            cc = New contentControl
            cc = cc.LoadControl("contentControl.ascx")
            cc.Content = c
            cc.Info = Me.info
            cc.user = Me.info.User
            Me.PlaceHolder1.Controls.Add(cc)


        Next

        Dim lbk As Label = TryCast(AccordionPane1.FindControl("Label1"), Label)

        lbk.Text = "Komentarze (" & Me.info.Comments.Count & "):"

        For Each com In Me.info.Comments

            Dim cc As CommentControl
            cc = New CommentControl
            cc = cc.LoadControl("CommentControl.ascx")
            cc.Comment = com
            cc.Info = Me.info


            Dim pl As PlaceHolder = TryCast(MyAccordion.FindControl("PlaceHolder2"), PlaceHolder)
            pl.Controls.Add(cc)

        Next


        Dim rc As New controlReaction

        rc = rc.LoadControl("controlReaction.ascx")
        rc.reacts = Me.info.Reactions
        rc.Info = Me.info
        rc.WhatIsParent = controlReaction.PCenum.Info
        Me.PlaceHolder3.Controls.Add(rc)


        Me.lnkAddComment.CommandArgument = Me.info._id
    End Sub
    Private Sub infoControl_Init(sender As Object, e As EventArgs) Handles Me.Init

        Bind()

    End Sub

    Protected Sub btn_pncomment_close_Click(sender As Object, e As EventArgs)
        pnNewComment.Visible = False
    End Sub

    Protected Sub btnAddNewComment_Click(sender As Object, e As EventArgs)
        Dim _id As String = lbCommentInfoId.Text

        Dim com As New CommentType
        com.Content = New ContentType
        com.Content.Key = ""
        com.Content.Value = txNewComment.Text
        com.UserId = 0
        com.ZoneID = 0
        com.OrganizationId = 0
        com.CreateTime = Now
        com._Id = Guid.NewGuid.ToString

        Me.info.Comments.Add(com)
        Me.info.Save()

        pnNewComment.Visible = False

        Bind()

    End Sub
End Class
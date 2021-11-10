Imports EngineSiO

Public Class controlReaction
    Inherits System.Web.UI.UserControl
    Public Property reacts As List(Of ReactionType)
    Public Property Comment As CommentType
    Public Property Info As InfoType
    Public Property WhatIsParent As PCenum

    Public Enum PCenum
        Comment = 0
        Info = 1
    End Enum
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ImageButton1.CommandArgument = ReactionEnum.Likes
        ImageButton2.CommandArgument = ReactionEnum.Super
        ImageButton3.CommandArgument = ReactionEnum.Love
        ImageButton4.CommandArgument = ReactionEnum.NotLike
        ImageButton5.CommandArgument = ReactionEnum.Good
        ImageButton6.CommandArgument = ReactionEnum.Bad
        ImageButton7.CommandArgument = ReactionEnum.Cry
        ImageButton8.CommandArgument = ReactionEnum.Smile


        AddHandler ImageButton1.Click, AddressOf ImageButton_Click
        AddHandler ImageButton2.Click, AddressOf ImageButton_Click
        AddHandler ImageButton3.Click, AddressOf ImageButton_Click
        AddHandler ImageButton4.Click, AddressOf ImageButton_Click
        AddHandler ImageButton5.Click, AddressOf ImageButton_Click
        AddHandler ImageButton6.Click, AddressOf ImageButton_Click
        AddHandler ImageButton7.Click, AddressOf ImageButton_Click
        AddHandler ImageButton8.Click, AddressOf ImageButton_Click

        Bind()

    End Sub

    Sub Bind()
        If IsNothing(reacts) Then Exit Sub




        Dim Likes As Integer = 0
        Dim Super As Integer = 0
        Dim Love As Integer = 0
        Dim NotLike As Integer = 0
        Dim Good As Integer = 0
        Dim Bad As Integer = 0
        Dim Cry As Integer = 0
        Dim Smile As Integer = 0


        For Each r In reacts
            Select Case r.ReactionType
                Case ReactionEnum.Bad
                    Bad += 1
                Case ReactionEnum.Cry
                    Cry += 1
                Case ReactionEnum.Good
                    Good += 1
                Case ReactionEnum.Likes
                    Likes += 1
                Case ReactionEnum.Love
                    Love += 1
                Case ReactionEnum.NotLike
                    NotLike += 1
                Case ReactionEnum.Smile
                    Smile += 1
                Case ReactionEnum.Super
                    Super += 1
            End Select
        Next


        Label1.Text = Likes
        Label2.Text = Super
        Label3.Text = Love
        Label4.Text = NotLike
        Label5.Text = Good
        Label6.Text = Bad
        Label7.Text = Cry
        Label8.Text = Smile

        Label1.ForeColor = System.Drawing.Color.Black
        Label2.ForeColor = System.Drawing.Color.Black
        Label3.ForeColor = System.Drawing.Color.Black
        Label4.ForeColor = System.Drawing.Color.Black
        Label5.ForeColor = System.Drawing.Color.Black
        Label6.ForeColor = System.Drawing.Color.Black
        Label7.ForeColor = System.Drawing.Color.Black
        Label8.ForeColor = System.Drawing.Color.Black

        If Likes = 0 Then Label1.ForeColor = System.Drawing.Color.Silver
        If Super = 0 Then Label2.ForeColor = System.Drawing.Color.Silver
        If Love = 0 Then Label3.ForeColor = System.Drawing.Color.Silver
        If NotLike = 0 Then Label4.ForeColor = System.Drawing.Color.Silver
        If Good = 0 Then Label5.ForeColor = System.Drawing.Color.Silver
        If Bad = 0 Then Label6.ForeColor = System.Drawing.Color.Silver
        If Cry = 0 Then Label7.ForeColor = System.Drawing.Color.Silver
        If Smile = 0 Then Label8.ForeColor = System.Drawing.Color.Silver


    End Sub
    Private Sub ImageButton_Click(sender As Object, e As ImageClickEventArgs)

        Dim r As New ReactionType
        r.UserId = 0
        r.CreateTime = Now

        Dim btn As ImageButton = sender

        r.ReactionType = btn.CommandArgument


        If WhatIsParent = PCenum.Info Then
            Me.Info.Reactions.Add(r)
        Else

            If IsNothing(Me.Comment.Reactions) Then Me.Comment.Reactions = New List(Of ReactionType)

            Me.Comment.Reactions.Add(r)
        End If


        Me.Info.Save()

        Bind()


    End Sub


End Class
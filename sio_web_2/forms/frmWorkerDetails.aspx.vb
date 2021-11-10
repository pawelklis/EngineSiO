Imports System.Net
Imports EngineSiO

Public Class frmWorkerDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind()

        End If
    End Sub


    Sub Bind()
        BindOrg()


        Dim n As String = Request.QueryString("n")
        Dim i As String = Request.QueryString("i")



        Dim idw As Integer = Request.QueryString("id")
        If idw = 0 Then
            ddlorg.SelectedIndex = 0
            ddlzone.SelectedIndex = 0
            txname.Text = ""
            txsurname.Text = ""
            txcode.Text = ""
            txtitle.Text = ""

            If Not String.IsNullOrEmpty(n) Then
                txsurname.Text = n
            End If
            If Not String.IsNullOrEmpty(i) Then
                txname.Text = i
            End If
            If Not String.IsNullOrEmpty(n) And Not String.IsNullOrEmpty(i) Then
                Dim lg As String = ConvertCore.ZnakiPL(n & i)
                txLogin.Text = lg

                Dim l As New List(Of A_Directory.UserInfoProps)

                l.Add(A_Directory.UserInfoProps.title)
                l.Add(A_Directory.UserInfoProps.employeeNumber)

                Dim uinfo As List(Of String) = A_Directory.GetuserAdInformation(txLogin.Text, l)
                If Not IsNothing(uinfo) Then
                    If uinfo.Count > 1 Then
                        txtitle.Text = uinfo(0)
                        txcode.Text = uinfo(1)
                    End If
                End If
            End If
        Else
            Dim W As WorkerType = WorkerType.Load(idw)
            ddlorg.SelectedValue = W.OrgID
            ddlzone.SelectedValue = W.ZoneId
            txname.Text = W.Name
            txsurname.Text = W.Surname
            txcode.Text = W.Code
            txtitle.Text = W.Title
            txLogin.Text = W.Login


        End If

    End Sub

    Sub BindOrg()
        Dim lo As List(Of OrganizationUnitType) = OrganizationUnitType.Load(True)
        ddlorg.DataSource = lo
        ddlorg.DataValueField = "id"
        ddlorg.DataTextField = "name"
        ddlorg.DataBind()
        ddlorg.SelectedIndex = 0
    End Sub
    Sub BindZone()
        Dim lz As List(Of ZoneType) = ZoneType.Load(CInt(ddlorg.SelectedValue))
        ddlzone.DataSource = lz
        ddlzone.DataValueField = "id"
        ddlzone.DataTextField = "name"
        ddlzone.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim idw As Integer = Request.QueryString("id")
        Dim w As New WorkerType
        If idw = 0 Then

        Else
            w.id = idw
        End If

        w.Name = txname.Text
        w.Surname = txsurname.Text
        w.Code = txcode.Text
        w.Title = txtitle.Text
        w.OrgID = ddlorg.SelectedValue
        w.ZoneId = ddlzone.SelectedValue
        w.fullname = w.Surname & " " & w.Name
        w.Active = 1
        w.Login = txLogin.Text
        w.save()

        ScriptManager.RegisterStartupScript(Me, Me.GetType, "cl", "Close();", True)

    End Sub

    Protected Sub ddlorg_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindZone()

    End Sub

    Protected Sub txlogin_TextChanged(sender As Object, e As EventArgs)

        Dim l As New List(Of A_Directory.UserInfoProps)

        l.Add(A_Directory.UserInfoProps.title)
        l.Add(A_Directory.UserInfoProps.employeeNumber)

        Dim uinfo As List(Of String) = A_Directory.GetuserAdInformation(txLogin.Text, l)
        If Not IsNothing(uinfo) Then
            If uinfo.Count > 1 Then
                txtitle.Text = uinfo(0)
                txcode.Text = uinfo(1)
            End If
        End If


    End Sub

    Protected Sub btnAddCode_Click(sender As Object, e As EventArgs)

        txcode.Text = ConvertCore.GenereteWorkerCode

    End Sub

End Class
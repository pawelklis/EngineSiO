Imports EngineSiO

Public Class wbMap
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim s As sessionClass = Session("sesja")
        If IsNothing(s) Then Response.Redirect("~/login.aspx")
        Try
            hh.InnerText = "Witaj " & s.User.ADINFO(3) & "! Wybierz Lokalizację"
        Catch ex As Exception

        End Try

        If Not IsPostBack Then
            BindOU()
        End If



    End Sub

    Public Sub BindOU()



        Dim l As List(Of OrganizationUnitType) = OrganizationUnitType.Load(True)

        Dim s As sessionClass = Session("sesja")
        Dim ld As New List(Of OrganizationUnitType)

        For Each o In l
            If s.User.GetOrganizationAccess(o.Id) = True Then
                ld.Add(o)
            End If
        Next


        ddlorgunit.DataSource = ld
        ddlorgunit.DataValueField = "Id"
        ddlorgunit.DataTextField = "Name"
        ddlorgunit.DataBind()

        ddlorgunit.SelectedIndex = 0

        LoadOUZ()

    End Sub
    Sub LoadOUZ()
        If ddlorgunit.Items.Count = 0 Then

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Nie masz przysanych lokalizacji, skontaktuj się z administratorem');", True)
            Response.Redirect("~/login.aspx")
            Exit Sub

        End If


        Dim l As List(Of ZoneType) = ZoneType.Load(CInt(ddlorgunit.SelectedValue))
        Dim s As sessionClass = Session("sesja")

        Dim ld As New List(Of ZoneType)

        For Each o In l
            If s.User.GetZoneAccess(o.Id) = True Then
                ld.Add(o)
            End If
        Next

        ddlzone.DataSource = ld
        ddlzone.DataTextField = "Name"
        ddlzone.DataValueField = "Id"
        ddlzone.DataBind()
    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function clk(ByVal name As String) As String
        Dim retval As String = ""

        Select Case name
            Case "1"
                retval = "Podlaskie"
            Case "3"
                retval = "Inne"




        End Select

        System.Web.HttpContext.Current.Session("id_activ") = retval
        Return retval

    End Function

    Protected Sub ddlorgunit_SelectedIndexChanged(sender As Object, e As EventArgs)

        LoadOUZ()


    End Sub

    Protected Sub BtnAccept_Click(sender As Object, e As EventArgs)


        Dim ou As OrganizationUnitType = OrganizationUnitType.Load(CInt(ddlorgunit.SelectedValue))

        Dim s As sessionClass
        If ddlzone.Items.Count = 0 Then
            s = Session("sesja")
            s.OrganizationUnit = ou
            Session("sesja") = s

            Response.Redirect("~/konf/wfZones.aspx")
        End If

        Dim oz As ZoneType = ZoneType.LoadID(CInt(ddlzone.SelectedValue))

        s = Session("sesja")
        s.OrganizationUnit = ou
        s.Zone = oz
        Session("sesja") = s

        Response.Redirect("~/start.aspx")


    End Sub
End Class
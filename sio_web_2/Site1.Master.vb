Imports EngineSiO

Public Class Site1
    Inherits System.Web.UI.MasterPage
    Dim s As sessionClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("sesja")) Then Response.Redirect("~/login.aspx")
        s = Session("sesja")


        'Dim m As mySQLcore = mySQLcore.DB_Main

        'Dim dt As DataTable = m.FillDatatable("select * from users;")
        'Dim r As New HtmlTableRow
        'For x = 0 To dt.Columns.Count - 1
        '    Dim cel As New HtmlTableCell
        '    cel.InnerText = dt.Columns(x).ColumnName
        '    r.Cells.Add(cel)


        'Next
        'tb1.Rows.Add(r)

        'For i = 0 To dt.Rows.Count - 1
        '    r = New HtmlTableRow

        '    For x = 0 To dt.Columns.Count - 1
        '        Dim v As String = dt.Rows(i)(x).ToString

        '        Dim c As New HtmlTableCell
        '        c.InnerText = v
        '        c.ViewStateMode = ViewStateMode.Enabled

        '        r.Cells.Add(c)

        '    Next
        '    tb1.Rows.Add(r)
        'Next


        'Me.ContentPlaceHolder1.Controls.Add(tb1)


        Try
            lnkOrgZone.Text = s.OrganizationUnit.Name & " - " & s.Zone.Name
        Catch ex As Exception

        End Try



        Try
            lbUserName.Text = s.User.ADINFO(10)
            lbuserTitle.Text = s.User.Title


            Dim lb As Label
            lb = New Label
            lb.Style.Add("font-size", "10px")
            lb.Text = s.User.ADINFO(4)
            PlaceHolder2.Controls.Add(lb)
            PlaceHolder2.Controls.Add(New LiteralControl("</br>"))
            lb = New Label
            lb.Style.Add("font-size", "10px")
            lb.Text = s.User.ADINFO(7)
            PlaceHolder2.Controls.Add(lb)
            PlaceHolder2.Controls.Add(New LiteralControl("</br>"))
            lb = New Label
            lb.Style.Add("font-size", "10px")
            lb.Text = s.User.ADINFO(9)
            PlaceHolder2.Controls.Add(lb)
        Catch ex As Exception

        End Try





        Button1.Visible = s.User.GetAccess(AccessList.Edycja_Jednostek_Organizacyjnych)
        Button2.Visible = s.User.GetAccess(AccessList.Edycja_Komórek_organizacyjnych)
        Button3.Visible = s.User.GetAccess(AccessList.Edycja_Użytkowników)


    End Sub



    Protected Sub lnkOrgZone_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/wbMap.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfOrgUnit.aspx")
    End Sub

    Protected Sub btnLogOut_Click(sender As Object, e As EventArgs)
        Session("sesja") = Nothing
        Response.Redirect("~/login.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfZones.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfUsers.aspx")
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfOperation.aspx")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfInfoCategory.aspx")
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfInfos.aspx")
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfImports.aspx")
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfNotifies.aspx")
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfRecipients.aspx")
    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/konf/wfnotifypair.aspx")
    End Sub
End Class
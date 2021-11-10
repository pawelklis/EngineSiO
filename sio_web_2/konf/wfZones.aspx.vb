Imports EngineSiO

Public Class wfZones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind()
        End If





        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("ContentPlaceHolder1_dg1", 0, False), False)
    End Sub


    Sub Bind()
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim s As sessionClass = Session("sesja")

        Dim dt As DataTable = m.FillDatatable("select * from zones where active=1 and organizationunitid=" & s.OrganizationUnit.Id & ";")

        For x = 0 To dt.Columns.Count - 1
            If dt.Columns(x).ColumnName.ToLower.EndsWith("field") Then
                For i = 0 To dt.Rows.Count - 1

                    Dim str As String = dt.Rows(i)(x)
                    str = str.Replace(", ", "</br>").Replace("{", "").Replace("""", "").Replace("}", "")
                    dt.Rows(i)(x) = str.Replace(", ", vbNewLine).Replace("{", "")
                Next
            End If
        Next

        dg1.Attributes.Add("style", "word-break: break-all; word-wrap:break-word")





        dg1.DataSource = dt
        dg1.DataBind()

    End Sub

    Protected Sub dg1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim id As Integer = e.CommandArgument
        labelID.Text = id

        Dim o As ZoneType = ZoneType.LoadID(id)
        tt.InnerText = o.Name

        txname.Text = o.Name
        txCode.Text = o.Code




        dg2.DataSource = o.AdditionalInfo
        dg2.DataBind()

        ddlIcon.Items.Clear()

        Dim fi = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/images/icons"))

        For Each i In fi
            Dim li As New ListItem
            li.Value = "../images/icons/" & System.IO.Path.GetFileName(i)
            li.Text = System.IO.Path.GetFileName(i).Replace(".png", "")
            Dim imageURL As String = "../images/icons/" & System.IO.Path.GetFileName(i)

            li.Attributes("style") = "background: url(" & imageURL & ");background-repeat:no-repeat;"

            ddlIcon.Items.Add(li)
        Next



        pnEdit.Visible = True


    End Sub



    Protected Sub btnpnEditClose_Click(sender As Object, e As EventArgs)
        labelID.Text = 0
        pnEdit.Visible = False
    End Sub
    Sub save()
        Dim o As ZoneType
        If labelID.Text = 0 Then
            o = New ZoneType
            o.active = 1
        Else
            o = ZoneType.LoadID(CInt(labelID.Text))
        End If

        Dim s As sessionClass = Session("sesja")

        o.OrganizationUnitId = s.OrganizationUnit.Id

        o.Name = txname.Text
        o.Code = txCode.Text


        o.AdditionalInfo.Clear()

        For Each row In dg2.Rows

            Dim k As String = TryCast(row.findcontrol("txkey"), TextBox).Text
            Dim v As String = TryCast(row.findcontrol("txval"), TextBox).Text

            o.AdditionalInfo.Add(k, v)
        Next



        o.Save()

        labelID.Text = o.Id
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        save()

        Bind()

        labelID.Text = 0
        pnEdit.Visible = False
    End Sub

    Protected Sub btnAddInfo_Click(sender As Object, e As EventArgs)
        save()
        Try
            Dim o As ZoneType = ZoneType.LoadID(CInt(labelID.Text))
            o.AdditionalInfo.Add("", "")
            dg2.DataSource = o.AdditionalInfo
            dg2.DataBind()
        Catch ex As Exception

        End Try


    End Sub



    Protected Sub dg3_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim ddl As DropDownList = TryCast(e.Row.FindControl("ddlval"), DropDownList)

            ddl.DataSource = [Enum].GetValues(GetType(SoftwareCodesKeys))
            ddl.DataBind()

            Dim tx As TextBox = TryCast(e.Row.FindControl("txkey"), TextBox)
            ddl.SelectedValue = tx.Text





        End If


    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New ZoneType

        o.AdditionalInfo = New Dictionary(Of String, String)

        'o.Save()
        labelID.Text = o.Id




        tt.InnerText = o.Name

        txname.Text = o.Name
        txCode.Text = o.Code




        dg2.DataSource = o.AdditionalInfo
        dg2.DataBind()






        pnEdit.Visible = True

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As ZoneType = ZoneType.LoadID(CInt(labelID.Text))
        o.Active = 0
        o.Save()
        pnEdit.Visible = False
        Bind()

    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")
    End Sub

    Protected Sub ddlIcon_SelectedIndexChanged(sender As Object, e As EventArgs)
        im1.ImageUrl = ddlIcon.SelectedValue

    End Sub
End Class
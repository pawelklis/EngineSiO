Imports System.Drawing
Imports EngineSiO

Public Class wfInfos
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

        Dim dt As DataTable = m.FillDatatable("select * from infoconfig where active=1 ;")

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

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        '



        If e.CommandName = "edition" Then
            BindFields(id)


            pnEdit.Visible = True
        End If

        If e.CommandName = "Select" Then
            Dim Row As GridViewRow = dg1.Rows(index)
            id = CInt(TryCast(Row.FindControl("btnEdit"), Button).CommandArgument)

        End If



    End Sub

    Sub BindFields(id As Integer)
        Dim o As InfoConfigType = InfoConfigType.Load(id)
        If IsNothing(o) Then o = New InfoConfigType
        tt.InnerText = o.Name


        ddlmsg.DataSource = [Enum].GetValues(GetType(InfoMessage))
        ddlmsg.DataBind()

        ddlpr.DataSource = [Enum].GetValues(GetType(Priorities))
        ddlpr.DataBind()

        txname.Text = o.Name
        ddlmsg.SelectedValue = o.Msg.ToString
        ddlpr.SelectedValue = o.Priority.ToString


    End Sub

    Protected Sub btnpnEditClose_Click(sender As Object, e As EventArgs)
        labelID.Text = 0
        pnEdit.Visible = False
    End Sub
    Sub save()
        Dim o As InfoConfigType
        If labelID.Text = 0 Then
            o = New InfoConfigType
            o.Active = 1
        Else
            o = InfoConfigType.Load(CInt(labelID.Text))
        End If

        Dim s As sessionClass = Session("sesja")

        o.Name = txname.Text

        o.OrgId = s.OrganizationUnit.Id
        o.ZoneId = s.Zone.Id


        o.Msg = CType([Enum].Parse(GetType(InfoMessage), ddlmsg.SelectedValue), InfoMessage)
        o.Priority = CType([Enum].Parse(GetType(Priorities), ddlpr.SelectedValue), Priorities)

        o.save()

        labelID.Text = o.Id
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        save()

        Bind()

        labelID.Text = 0
        pnEdit.Visible = False
    End Sub






    Protected Sub btnAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New InfoConfigType

        labelID.Text = o.Id

        BindFields(o.Id)


        pnEdit.Visible = True

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As InfoConfigType = InfoConfigType.Load(CInt(labelID.Text))
        o.Active = 0
        o.save()
        pnEdit.Visible = False
        Bind()

    End Sub




    Protected Sub dg1_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In dg1.Rows
            If row.RowIndex = dg1.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg1, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."







            Dim txpr As Label = TryCast(e.Row.FindControl("txpr"), Label)

            Dim txmsg As Label = TryCast(e.Row.FindControl("txmsg"), Label)

            txmsg.Text = CType([Enum].Parse(GetType(InfoMessage), txmsg.Text), InfoMessage).ToString

            txpr.Text = CType([Enum].Parse(GetType(Priorities), txpr.Text), Priorities).ToString
        End If
    End Sub


End Class

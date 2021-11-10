Imports System.Drawing
Imports EngineSiO

Public Class wfNotifies
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind()
        End If





        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("ContentPlaceHolder1_dg1", 0, False), False)
    End Sub

#Region "Kategorie Operacji"


    Sub Bind()
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim s As sessionClass = Session("sesja")

        Dim dt As DataTable = m.FillDatatable("select * from notifygroup where active=1 ;")

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




        If e.CommandName = "edition" Then
            BindFields(id)


            pnEdit.Visible = True
        End If

        If e.CommandName = "Select" Then
            Dim Row As GridViewRow = dg1.Rows(index)
            id = CInt(TryCast(Row.FindControl("btnEdit"), Button).CommandArgument)
            labelID.Text = id
            Bind2()
        End If



    End Sub

    Sub BindFields(id As Integer)
        Dim o As NotifyGroupType = NotifyGroupType.Load(id)
        If IsNothing(o) Then o = New NotifyGroupType
        tt.InnerText = o.name

        txname.Text = o.name


    End Sub

    Protected Sub btnpnEditClose_Click(sender As Object, e As EventArgs)
        labelID.Text = 0
        pnEdit.Visible = False
    End Sub
    Sub save()
        Dim o As NotifyGroupType
        If labelID.Text = 0 Then
            o = New NotifyGroupType
            o.Active = 1
        Else
            o = NotifyGroupType.Load(CInt(labelID.Text))
        End If

        Dim s As sessionClass = Session("sesja")

        o.name = txname.Text

        o.Save()

        labelID.Text = o.id
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        save()

        Bind()

        labelID.Text = 0
        pnEdit.Visible = False
    End Sub






    Protected Sub btnAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New NotifyGroupType

        labelID.Text = o.id

        BindFields(o.id)


        pnEdit.Visible = True

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As NotifyGroupType = NotifyGroupType.Load(CInt(labelID.Text))
        o.Active = 0
        o.Save()
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
        End If
    End Sub

#End Region


#Region "operacje"

    Sub Bind2()
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim s As sessionClass = Session("sesja")

        Dim id As Integer = labelID.Text
        Dim o As NotifyGroupType = NotifyGroupType.Load(id)


        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("login")
        Dim dtt As DataTable = m.FillDatatable("select id,login from users where active=1")

        For i = 0 To dtt.Rows.Count - 1
            If Not o.RecipientsIDList.Contains(dtt.Rows(i)("id")) Then
                dt.Rows.Add(dtt.Rows(i)("id"), dtt.Rows(i)("login"))
            End If

        Next


        ddluser.DataSource = dt
        ddluser.DataTextField = "login"
        ddluser.DataValueField = "id"
        ddluser.DataBind()


        dg2.Attributes.Add("style", "word-break: break-all; word-wrap:break-word")

        dt = New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("login")
        dt.Columns.Add("name")
        dt.Columns.Add("surname")
        dt.Columns.Add("org")
        dt.Columns.Add("zone")
        dt.Columns.Add("Title")

        For Each i In o.Recipients
            dt.Rows.Add(i.Id, i.Login, i.Name, i.Surname, i.Title)
        Next



        dg2.DataSource = o.Recipients
        dg2.DataBind()

    End Sub

    Protected Sub dg2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim id As Integer = e.CommandArgument

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)


        If e.CommandName = "edition" Then

            Dim idn As Integer = labelID.Text
            Dim o As NotifyGroupType = NotifyGroupType.Load(idn)

            o.RecipientsIDList.Remove(id)
            o.Save()

            Bind2()

        End If

        If e.CommandName = "Select" Then

            Dim Row As GridViewRow = dg2.Rows(index)
            id = CInt(TryCast(Row.FindControl("btnEdit2"), Button).CommandArgument)

        End If



    End Sub










    Protected Sub btnAdd2_Click(sender As Object, e As ImageClickEventArgs)
        If ddluser.SelectedValue = "" Then Exit Sub
        Dim o As NotifyGroupType = NotifyGroupType.Load(labelID.Text)
        o.RecipientsIDList.Add(ddluser.SelectedValue)
        o.Save()

        Bind2()



    End Sub




    Protected Sub dg2_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In dg2.Rows
            If row.RowIndex = dg2.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub dg2_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg2, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."




        End If
    End Sub

#End Region

End Class
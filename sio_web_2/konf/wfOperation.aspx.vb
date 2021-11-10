Imports System.Drawing
Imports EngineSiO

Public Class wfOperation
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

        Dim dt As DataTable = m.FillDatatable("select * from opercat where active=1 ;")

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
        Dim Row As GridViewRow = dg1.Rows(index)

        dg3.DataSource = Nothing
        dg3.DataBind()

        If e.CommandName = "edition" Then
            BindFields(id)


            pnEdit.Visible = True
        End If

        If e.CommandName = "Select" Then
            id = CInt(TryCast(row.FindControl("btnEdit"), Button).CommandArgument)
            lbopercat2.Text = id

            Bind2()
        End If



    End Sub

    Sub BindFields(id As Integer)
        Dim o As OperationCategoryType = OperationCategoryType.Load(id)
        If IsNothing(o) Then o = New OperationCategoryType
        tt.InnerText = o.Name

        txname.Text = o.Name


    End Sub

    Protected Sub btnpnEditClose_Click(sender As Object, e As EventArgs)
        labelID.Text = 0
        pnEdit.Visible = False
    End Sub
    Sub save()
        Dim o As OperationCategoryType
        If labelID.Text = 0 Then
            o = New OperationCategoryType
            o.Active = 1
        Else
            o = OperationCategoryType.Load(CInt(labelID.Text))
        End If

        Dim s As sessionClass = Session("sesja")

        o.Name = txname.Text

        o.Save()

        labelID.Text = o.Id
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        save()

        Bind()

        labelID.Text = 0
        pnEdit.Visible = False
    End Sub






    Protected Sub btnAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New OperationCategoryType

        labelID.Text = o.Id

        BindFields(o.Id)


        pnEdit.Visible = True

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As OperationCategoryType = OperationCategoryType.Load(CInt(labelID.Text))
        o.active = 0
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

        Dim idopercat As String = lbopercat2.Text

        Dim dt As DataTable = m.FillDatatable("select * from oper where active=1 and orgid=" & s.OrganizationUnit.Id & " and zoneid=" & s.Zone.Id & " and operationcategoryid=" & idopercat & " ;")

        For x = 0 To dt.Columns.Count - 1
            If dt.Columns(x).ColumnName.ToLower.EndsWith("field") Then
                For i = 0 To dt.Rows.Count - 1

                    Dim str As String = dt.Rows(i)(x)
                    str = str.Replace(", ", "</br>").Replace("{", "").Replace("""", "").Replace("}", "")
                    dt.Rows(i)(x) = str.Replace(", ", vbNewLine).Replace("{", "")
                Next
            End If
        Next

        dg2.Attributes.Add("style", "word-break: break-all; word-wrap:break-word")





        dg2.DataSource = dt
        dg2.DataBind()

    End Sub

    Protected Sub dg2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim id As Integer = e.CommandArgument
        lbid2.Text = id
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)


        If e.CommandName = "edition" Then
            BindFields2(id)


            pnEdit2.Visible = True
        End If

        If e.CommandName = "Select" Then

            Dim Row As GridViewRow = dg2.Rows(index)
            id = CInt(TryCast(Row.FindControl("btnEdit2"), Button).CommandArgument)
            lbopercat3.Text = id

            Bind3()
        End If



    End Sub

    Sub BindFields2(id As Integer)
        Dim o As OperationType = OperationType.Load(id)
        If IsNothing(o) Then o = New OperationType
        H2.InnerText = o.Name


        ddlFormatka.DataSource = [Enum].GetValues(GetType(Formatka))
        ddlFormatka.DataBind()


        ddlinfo.DataSource = InfoConfigType.Load
        ddlinfo.DataTextField = "name"
        ddlinfo.DataValueField = "id"
        ddlinfo.DataBind()

        ddlinfo.Items.Insert(0, "Brak")

        ddlnotify.DataSource = NotifyGroupType.Load
        ddlnotify.DataTextField = "name"
        ddlnotify.DataValueField = "id"
        ddlnotify.DataBind()

        ddlnotify.Items.Insert(0, "Brak")

        'ddlFormatka.SelectedValue = o.formatkaid


        For Each v In [Enum].GetValues(GetType(Formatka))
            If v = o.formatkaid Then
                ddlFormatka.SelectedValue = v.ToString
                Exit For
            End If
        Next

        Dim a = ddlinfo.SelectedValue
        If o.InfoId = 0 Then
            ddlinfo.SelectedValue = "Brak"
        Else
            ddlinfo.SelectedValue = o.InfoId
        End If

        If o.NotifyGroupID = 0 Then
            ddlnotify.SelectedValue = "Brak"
        Else
            ddlnotify.SelectedValue = o.NotifyGroupID
        End If


        txname2.Text = o.Name


    End Sub

    Protected Sub btnpnEdit2Close_Click(sender As Object, e As EventArgs)
        lbid2.Text = 0
        pnEdit2.Visible = False
    End Sub
    Sub save2()
        Dim o As OperationType
        If lbid2.Text = 0 Then
            o = New OperationType
            o.OperationCategoryID = lbopercat2.Text
            o.Active = 1
        Else
            o = OperationType.Load(CInt(lbid2.Text))
        End If

        Dim s As sessionClass = Session("sesja")

        o.Name = txname2.Text
        o.OperationCategoryID = lbopercat2.Text
        o.OrgID = s.OrganizationUnit.Id
        o.ZoneID = s.Zone.Id
        If ddlinfo.SelectedValue = "Brak" Then
            o.InfoId = 0
        Else
            o.InfoId = ddlinfo.SelectedValue
        End If


        If ddlnotify.SelectedValue = "Brak" Then
            o.NotifyGroupID = 0
        Else
            o.NotifyGroupID = ddlnotify.SelectedValue
        End If

        For Each v In [Enum].GetValues(GetType(Formatka))
            If v.ToString = ddlFormatka.SelectedValue Then
                o.formatkaid = v
                Exit For
            End If
        Next

        o.Save()

        lbid2.Text = o.Id
        dg3.DataSource = Nothing
        dg3.DataBind()

    End Sub
    Protected Sub btn2Save_Click(sender As Object, e As EventArgs)
        save2()

        Bind2()

        lbid2.Text = 0
        pnEdit2.Visible = False
    End Sub






    Protected Sub btnAdd2_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New OperationType
        o.OperationCategoryID = lbopercat2.Text
        lbid2.Text = o.Id

        BindFields2(o.Id)


        pnEdit2.Visible = True

    End Sub

    Protected Sub btnDelete2_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As OperationType = OperationType.Load(CInt(lbid2.Text))
        o.Active = 0
        o.Save()


        Dim m As mySQLcore = mySQLcore.DB_Main
        m.ExecuteNonQuery("delete from frmparameters where operationid=" & o.Id)
        pnEdit2.Visible = False
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

            Dim tx As Label = TryCast(e.Row.FindControl("txpolecenie"), Label)

            For Each v In [Enum].GetValues(GetType(Formatka))
                If v = tx.Text Then
                    tx.Text = v.ToString
                    Exit For
                End If
            Next

            Try
                Dim txinfo As Label = TryCast(e.Row.FindControl("txinfo"), Label)
                txinfo.Text = InfoConfigType.Load(CInt(txinfo.Text)).Name
            Catch ex As Exception

            End Try

            Try
                Dim txnot As Label = TryCast(e.Row.FindControl("txnot"), Label)
                txnot.Text = NotifyGroupType.Load(CInt(txnot.Text)).name
            Catch ex As Exception

            End Try

        End If
    End Sub

#End Region



#Region "Parametry"

    Sub Bind3()
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim s As sessionClass = Session("sesja")

        Dim idopercat As String = lbopercat3.Text

        Dim dt As DataTable = m.FillDatatable("select * from frmparameters where operationid=" & idopercat & " ;")

        For x = 0 To dt.Columns.Count - 1
            If dt.Columns(x).ColumnName.ToLower.EndsWith("field") Then
                For i = 0 To dt.Rows.Count - 1

                    Dim str As String = dt.Rows(i)(x)
                    str = str.Replace(", ", "</br>").Replace("{", "").Replace("""", "").Replace("}", "")
                    dt.Rows(i)(x) = str.Replace(", ", vbNewLine).Replace("{", "")
                Next
            End If
        Next

        dg3.Attributes.Add("style", "word-break: break-all; word-wrap:break-word")





        dg3.DataSource = dt
        dg3.DataBind()

    End Sub

    Protected Sub dg3_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim id As Integer = e.CommandArgument
        lbid3.Text = id

        If e.CommandName = "edition" Then
            BindFields3(id)


            pnEdit3.Visible = True
        End If





    End Sub

    Sub BindFields3(id As Integer)
        Dim o As FrmParametersType = FrmParametersType.Load(id)
        If IsNothing(o) Then o = New FrmParametersType
        H3.InnerText = "Parametr"


        Select Case o.ValueType
            Case "WorkerLevels"
                ddlvalue.DataSource = [Enum].GetValues(GetType(WorkerLevels))
                ddlvalue.DataBind()
                For Each v In [Enum].GetValues(GetType(WorkerLevels))
                    If v = o.Value Then
                        ddlvalue.SelectedValue = v.ToString
                        Exit For
                    End If
                Next
            Case "YesNo"
                ddlvalue.DataSource = [Enum].GetValues(GetType(YesNo))
                ddlvalue.DataBind()
                For Each v In [Enum].GetValues(GetType(YesNo))
                    If v = o.Value Then
                        ddlvalue.SelectedValue = v.ToString
                        Exit For
                    End If
                Next

            Case "RangeLevels"
                ddlvalue.DataSource = [Enum].GetValues(GetType(RangeLevels))
                ddlvalue.DataBind()
                For Each v In [Enum].GetValues(GetType(RangeLevels))
                    If v = o.Value Then
                        ddlvalue.SelectedValue = v.ToString
                        Exit For
                    End If
                Next
            Case "Condition"
                ddlvalue.DataSource = [Enum].GetValues(GetType(Condition))
                ddlvalue.DataBind()
                For Each v In [Enum].GetValues(GetType(Condition))
                    If v = o.Value Then
                        ddlvalue.SelectedValue = v.ToString
                        Exit For
                    End If
                Next
        End Select

        txname3.Text = o.Key


        'ddlvalue.SelectedValue = o.formatkaid







    End Sub

    Protected Sub btnpnEdit3Close_Click(sender As Object, e As EventArgs)
        lbid3.Text = 0
        pnEdit3.Visible = False
    End Sub
    Sub save3()
        Dim o As FrmParametersType
        If lbid3.Text = 0 Then
            o = New FrmParametersType

        Else
            o = FrmParametersType.Load(CInt(lbid3.Text))
        End If

        Dim s As sessionClass = Session("sesja")

        Select Case o.ValueType
            Case "WorkerLevels"
                For Each v In [Enum].GetValues(GetType(WorkerLevels))
                    If v.ToString = ddlvalue.SelectedValue Then
                        o.Value = v
                        Exit For
                    End If
                Next
            Case "YesNo"
                For Each v In [Enum].GetValues(GetType(YesNo))
                    If v.ToString = ddlvalue.SelectedValue Then
                        o.Value = v
                        Exit For
                    End If
                Next
            Case "RangeLevels"
                For Each v In [Enum].GetValues(GetType(RangeLevels))
                    If v.ToString = ddlvalue.SelectedValue Then
                        o.Value = v
                        Exit For
                    End If
                Next
            Case "Condition"
                For Each v In [Enum].GetValues(GetType(Condition))
                    If v.ToString = ddlvalue.SelectedValue Then
                        o.Value = v
                        Exit For
                    End If
                Next
        End Select

        o.OperationID = lbopercat3.Text

        o.Save()

        lbid3.Text = o.Id
    End Sub
    Protected Sub btn3Save_Click(sender As Object, e As EventArgs)
        save3()

        Bind3()

        lbid3.Text = 0
        pnEdit3.Visible = False
    End Sub






    Protected Sub btnAdd3_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New FrmParametersType
        o.OperationID = lbid2.Text
        lbid3.Text = o.Id

        BindFields3(o.Id)


        pnEdit3.Visible = True

    End Sub

    Protected Sub btnDelete3_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As FrmParametersType = FrmParametersType.Load(CInt(labelID.Text))

        o.Save()
        pnEdit3.Visible = False
        Bind3()

    End Sub




    Protected Sub dg3_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In dg3.Rows
            If row.RowIndex = dg3.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF3")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub dg3_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg3, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."

            Dim tx As Label = TryCast(e.Row.FindControl("txname3"), Label)

            Dim vx As Label = TryCast(e.Row.FindControl("txvalue"), Label)
            'vx.Text = tx.ToolTip

            Select Case tx.ToolTip
                Case "WorkerLevels"
                    For Each v In [Enum].GetValues(GetType(WorkerLevels))
                        If v = CInt(vx.Text) Then
                            vx.Text = v.ToString
                            Exit For
                        End If
                    Next
                Case "YesNo"
                    For Each v In [Enum].GetValues(GetType(YesNo))
                        If v = CInt(vx.Text) Then
                            vx.Text = v.ToString
                            Exit For
                        End If
                    Next
                Case "RangeLevels"
                    For Each v In [Enum].GetValues(GetType(RangeLevels))
                        If v = vx.Text Then
                            vx.Text = v.ToString
                            Exit For
                        End If
                    Next
                Case "Condition"
                    For Each v In [Enum].GetValues(GetType(Condition))
                        If v = vx.Text Then
                            vx.Text = v.ToString
                            Exit For
                        End If
                    Next
            End Select


        End If
    End Sub
#End Region
End Class
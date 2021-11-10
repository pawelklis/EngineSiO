Imports EngineSiO

Public Class wfUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind()
        End If





        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("ContentPlaceHolder1_dg1", 0, False), False)
    End Sub


    Sub Bind()
        Dim m As mySQLcore = mySQLcore.DB_Main

        Dim dt As DataTable = m.FillDatatable("select * from users where active=1;")

        For x = 0 To dt.Columns.Count - 1
            If dt.Columns(x).ColumnName.ToLower.EndsWith("field") Then
                For i = 0 To dt.Rows.Count - 1

                    Dim str As String = dt.Rows(i)(x)
                    str = str.Replace(",", "</br>").Replace("{", "").Replace("""", "").Replace("}", "")
                    dt.Rows(i)(x) = str.Replace(",", vbNewLine).Replace("{", "")
                Next
            End If
        Next

        dg1.Attributes.Add("style", "word-break:break-all; word-wrap:break-word")





        dg1.DataSource = dt
        dg1.DataBind()

    End Sub

    Protected Sub dg1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim id As Integer = e.CommandArgument
        labelID.Text = id



        Dim o As UserType = UserType.Load(id)
        tt.InnerText = o.Name

        txname.Text = o.Name
        txSN.Text = o.Surname
        txLogin.Text = o.Login
        txTitle.Text = o.Title

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("key")
        dt.Columns.Add("value")

        Dim ual = [Enum].GetValues(GetType(AccessList))

        For Each item In ual
            dt.Rows.Add(item.ToString, item, o.GetAccess(item))
        Next


        dg3.DataSource = dt
        dg3.DataBind()


        Dim lo As List(Of OrganizationUnitType) = OrganizationUnitType.Load(True)


        dt = New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("key")
        dt.Columns.Add("value")

        For Each org In lo
            dt.Rows.Add(org.Id, org.Name, o.GetOrganizationAccess(org.Id))
        Next
        dg2.DataSource = dt
        dg2.DataBind()

        dt = New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("key")
        dt.Columns.Add("value")

        For Each org In lo
            Dim lz As List(Of ZoneType) = ZoneType.Load(CInt(org.Id))
            For Each z In lz
                dt.Rows.Add(z.Id, org.Name & " " & z.Name, o.GetZoneAccess(z.Id))
            Next
        Next





        dg4.DataSource = dt
        dg4.DataBind()

        pnEdit.Visible = True


    End Sub


    Protected Sub btnpnEditClose_Click(sender As Object, e As EventArgs)
        labelID.Text = 0
        pnEdit.Visible = False
    End Sub
    Sub save()
        Dim o As UserType
        If labelID.Text = 0 Then
            o = New UserType
        Else
            o = UserType.Load(CInt(labelID.Text))
        End If


        o.Name = txname.Text
        o.Surname = txSN.Text
        o.Login = txLogin.Text
        o.Title = txTitle.Text

        o.Access.Access.Clear()

        For Each row In dg3.Rows

            Dim k As String = TryCast(row.findcontrol("txkey"), TextBox).Text
            Dim v As String = TryCast(row.findcontrol("txval"), CheckBox).Checked
            Dim skid As Integer = 0
            Dim vsid As Integer = 0
            Dim l = [Enum].GetValues(GetType(AccessList))
            For Each os In l
                If os.ToString = k Then
                    skid = os
                End If
            Next



            Try
                o.Access.Access.Add(skid, v)
            Catch ex As Exception

            End Try

        Next

        o.Access.OrganizationUnits.Clear()

        For Each row In dg2.Rows
            Dim k As String = TryCast(row.findcontrol("lborgid"), Label).Text
            Dim v As Boolean = TryCast(row.findcontrol("txval"), CheckBox).Checked

            o.Access.OrganizationUnits.Add(k, v)
        Next

        o.Access.Zones.Clear()

        For Each row In dg4.Rows
            Dim k As String = TryCast(row.findcontrol("lborgid"), Label).Text
            Dim v As Boolean = TryCast(row.findcontrol("txval"), CheckBox).Checked

            o.Access.Zones.Add(k, v)
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







    Protected Sub btnAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As New UserType

        o.Access = New UserAccesssType


        'o.Save()
        labelID.Text = o.Id

        tt.InnerText = o.Name

        txname.Text = o.Name
        txSN.Text = o.Surname
        txLogin.Text = o.Login
        txTitle.Text = o.Title

        dg3.DataSource = o.Access.Access
        dg3.DataBind()


        tt.InnerText = o.Name










        pnEdit.Visible = True

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As UserType = UserType.Load(CInt(labelID.Text))
        o.Active = 0
        o.Save()
        pnEdit.Visible = False
        Bind()

    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")
    End Sub


End Class
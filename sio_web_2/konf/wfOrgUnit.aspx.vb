Imports System.Reflection
Imports EngineSiO
Imports Newtonsoft.Json

Public Class wfOrgUnit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind()
        End If





        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("ContentPlaceHolder1_dg1", 0, False), False)
    End Sub


    Sub Bind()
        Dim m As mySQLcore = mySQLcore.DB_Main

        Dim dt As DataTable = m.FillDatatable("select * from organizationunits where active=1;")

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

        Dim o As OrganizationUnitType = OrganizationUnitType.Load(id)
        tt.InnerText = o.Name

        txname.Text = o.Name
        txAdresName.Text = o.Address.Name
        txborough.Text = o.Address.Borough
        txCountry.Text = o.Address.Country
        txCounty.Text = o.Address.County
        txDistrict.Text = o.Address.District
        txhousenumber.Text = o.Address.HouseNumber
        txlat.Text = o.Address.Lat
        txlocal.Text = o.Address.Local
        txlon.Text = o.Address.Lon
        txstreet.Text = o.Address.Street
        txzipcode.Text = o.Address.ZIPCode



        dg2.DataSource = o.Info
        dg2.DataBind()

        dg3.DataSource = o.SoftwareCodes
        dg3.DataBind()




        pnEdit.Visible = True


    End Sub



    Protected Sub btnpnEditClose_Click(sender As Object, e As EventArgs)
        labelID.Text = 0
        pnEdit.Visible = False
    End Sub
    Sub save()
        Dim o As OrganizationUnitType
        If labelID.Text = 0 Then
            o = New OrganizationUnitType
        Else
            o = OrganizationUnitType.Load(CInt(labelID.Text))
        End If


        o.Name = txname.Text
        o.Address.Name = txAdresName.Text
        o.Address.Borough = txborough.Text
        o.Address.Country = txCountry.Text
        o.Address.County = txCounty.Text
        o.Address.District = txDistrict.Text
        o.Address.HouseNumber = txhousenumber.Text
        o.Address.Lat = txlat.Text
        o.Address.Local = txlocal.Text
        o.Address.Lon = txlon.Text
        o.Address.Street = txstreet.Text
        o.Address.ZIPCode = txzipcode.Text


        o.Info.Clear()

        For Each row In dg2.Rows

            Dim k As String = TryCast(row.findcontrol("txkey"), TextBox).Text
            Dim v As String = TryCast(row.findcontrol("txval"), TextBox).Text

            o.Info.Add(k, v)
        Next

        o.SoftwareCodes.Clear()

        For Each row In dg3.Rows

            Dim k As String = TryCast(row.findcontrol("ddlval"), DropDownList).SelectedValue
            Dim v As String = TryCast(row.findcontrol("txval"), TextBox).Text
            Dim skid As Integer=0
            Dim l = [Enum].GetValues(GetType(SoftwareCodesKeys))
            For Each os In l
                If os.ToString = k Then
                    skid = os
                End If
            Next


            Try
                o.SoftwareCodes.Add(skid, v)
            Catch ex As Exception

            End Try

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
            Dim o As OrganizationUnitType = OrganizationUnitType.Load(CInt(labelID.Text))
            o.Info.Add("", "")
            dg2.DataSource = o.Info
            dg2.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnAddSystem_Click(sender As Object, e As EventArgs)
        save()

        Dim o As OrganizationUnitType = OrganizationUnitType.Load(CInt(labelID.Text))
        o.SoftwareCodes.Add(-1, "")
        dg3.DataSource = o.SoftwareCodes
        dg3.DataBind()
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
        Dim o As New OrganizationUnitType

        o.Address = New AddressType
        o.Info = New Dictionary(Of String, String)
        o.SoftwareCodes = New Dictionary(Of SoftwareCodesKeys, String)

        'o.Save()
        labelID.Text = o.Id




        tt.InnerText = o.Name

        txname.Text = o.Name
        txAdresName.Text = o.Address.Name
        txborough.Text = o.Address.Borough
        txCountry.Text = o.Address.Country
        txCounty.Text = o.Address.County
        txDistrict.Text = o.Address.District
        txhousenumber.Text = o.Address.HouseNumber
        txlat.Text = o.Address.Lat
        txlocal.Text = o.Address.Local
        txlon.Text = o.Address.Lon
        txstreet.Text = o.Address.Street
        txzipcode.Text = o.Address.ZIPCode



        dg2.DataSource = o.Info
        dg2.DataBind()

        dg3.DataSource = o.SoftwareCodes
        dg3.DataBind()




        pnEdit.Visible = True

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As ImageClickEventArgs)
        Dim o As OrganizationUnitType = OrganizationUnitType.Load(CInt(labelID.Text))
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
Imports EngineSiO





Public Class tfNT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dg1.UseAccessibleHeader = True

        If Not IsPostBack Then
            Dim df As New DataTable
            df.Columns.Add("f")
            df.Columns.Add("v")
            df.Rows.Add("Jednostki_fazy_Region", Nothing)

            Session("df") = df

            binddf()

            'bind()
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("dg1", 0, False, dg1.Columns.Count), False)


    End Sub
    Sub Getdf()
        Dim df As New DataTable
        df.Columns.Add("f")
        df.Columns.Add("v")

        For Each row As GridViewRow In dgf.Rows

            Dim f As String = TryCast(row.FindControl("ddl"), DropDownList).SelectedValue
            Dim v As String = TryCast(row.FindControl("txval"), TextBox).Text
            df.Rows.Add(f, v)

        Next

        Session("df") = df
        binddf()

    End Sub
    Sub binddf()
        Dim df As DataTable = Session("df")
        dgf.DataSource = df
        dgf.DataBind()
    End Sub
    Sub bind()

        Dim l As New Dictionary(Of String, Object)


        '{Jednostki_fazy_Region,Terminowosc_fazy_dla_jednostki:0,Sparametryzowana:1,Terminowosc_E2E:0,tydzien:"Tydzien 6 2021"}


        l.Add("Jednostki_fazy_Region", "RD Wrocław")

        l.Add("Terminowosc_fazy_dla_jednostki", 0)


        l.Add("Sparametryzowana", 1)

        l.Add("tydzien", "Tydzien 6 2021")

        l.Add("Nazwa_fazy", "doręczenia")

        Dim m As New mongoDBCore

        Dim lt As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", l)

        dg1.DataSource = lt
        dg1.DataBind()



    End Sub
    Sub bind(l As Dictionary(Of String, Object))


        Dim m As New mongoDBCore

        Dim lt As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", l)

        dg1.DataSource = lt
        dg1.DataBind()

        BindCT(l, lt)

    End Sub

    Sub BindCT(l As Dictionary(Of String, Object), lt As List(Of tPrzesylkaType))



        Dim c = From o In lt
                Group o By o.Jednostka_nad_rozdzielnia Into Group
                Select New With {.Jednostka_nad_rozdzielnia = Jednostka_nad_rozdzielnia, .Count = Group.Count()}

        With Chart1
            .DataSource = c.ToList
            .Series(0).XValueMember = "Jednostka_nad_rozdzielnia"
            .Series(0).YValueMembers = "Count"
            .ChartAreas(0).AxisX.Interval = 1
            '.ChartAreas(0).AxisY.Interval = 1
            .DataBind()
        End With

        Dim d = From o In lt
                Group o By o.Jednostka_dor_rozdzielnia Into Group
                Select New With {.Jednostka_dor_rozdzielnia = Jednostka_dor_rozdzielnia, .Count = Group.Count()}

        With Chart2
            .DataSource = d.ToList
            .Series(0).XValueMember = "Jednostka_dor_rozdzielnia"
            .Series(0).YValueMembers = "Count"
            .ChartAreas(0).AxisX.Interval = 1
            '.ChartAreas(0).AxisY.Interval = 1
            .DataBind()
        End With





    End Sub

    Protected Sub dg1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim nr As String = e.CommandArgument

        Dim sb As New System.Text.StringBuilder()
        sb.Append("popWin=window.open('")
        sb.Append("wftfTracker.aspx?id=" & nr)
        sb.Append("','")
        sb.Append("details")
        sb.Append("','width=")
        sb.Append(1280)
        sb.Append(",height=")
        sb.Append(1024)
        sb.Append(",toolbar=no,location=no,left=0,top=0 directories=no,status=no,menubar=no,scrollbars=yes,resizable=no")
        sb.Append("');")
        sb.Append("popWin.focus();")

        'ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "OpenWindow", sb.ToString(), True)

        ifr.Src = "wftfTracker.aspx?id=" & nr
        pnmod.Visible = True
    End Sub

    Protected Sub btnclose_Click(sender As Object, e As EventArgs)
        pnmod.Visible = False
    End Sub

    Protected Sub ddl_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Getdf()

        Dim df As DataTable = Session("df")

        Dim filter As New Dictionary(Of String, Object)

        For i = 0 To df.Rows.Count - 1
            Dim f As String = df.Rows(i)(0).ToString
            Dim v = df.Rows(i)(1)

            If Not String.IsNullOrEmpty(f) Then
                If Not String.IsNullOrEmpty(v) Then

                    If IsNumeric(v) Then
                        filter.Add(f, CInt(v))
                    Else
                        filter.Add(f, v)
                    End If


                End If
            End If
        Next
        If filter.Count > 2 Then
            bind(filter)
        End If




    End Sub

    Protected Sub dgf_RowDataBound(sender As Object, e As GridViewRowEventArgs)


        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lf As String = TryCast(e.Row.FindControl("lf"), TextBox).Text
            Dim f As DropDownList = TryCast(e.Row.FindControl("ddl"), DropDownList)
            f.SelectedValue = lf


        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Getdf()

        Dim df As DataTable = Session("df")
        df.Rows.Add()
        Session("df") = df

        binddf()

    End Sub

    Protected Sub dgf_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Getdf()
        binddf()

        Dim df As DataTable = Session("df")
        Dim l As New List(Of Integer)
        For i = 0 To df.Rows.Count - 1
            If df.Rows(i)("f") = e.CommandArgument Then
                l.Add(i)
            End If
        Next

        For Each i In l
            df.Rows.Remove(df.Rows(i))
        Next


        Session("df") = df

        binddf()
    End Sub
End Class
Imports System.Threading.Tasks
Imports EngineSiO

Public Class wfAllregions
    Inherits System.Web.UI.Page
    Dim tydzien As Integer
    Dim rok As Integer
    Dim GRD As MongoDBReportsCore.GlobalReportData
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter1", PublicGlobalClass.ShowTableFilter("dg1", 0, False, dg1.Columns.Count), False)
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter2", PublicGlobalClass.ShowTableFilter("dg2", 0, False, dg2.Columns.Count), False)
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter3", PublicGlobalClass.ShowTableFilter("dg3", 0, False, dg2.Columns.Count), False)

        If Not IsPostBack Then
            'MongoDBReportsCore.CreateGlobalReportData(4, 2021)
            GRD = MongoDBReportsCore.getGlobalReportData(4, 2021)
            Session("grd") = GRD
            Bind()


        End If
    End Sub

    Sub Bind()
        tydzien = 4
        rok = 2021
        GRD = Session("grd")


        Dim dt As DataTable

        dt = GRD.GetSource(1).dt
        dg1.DataSource = dt
        dg1.DataBind()

        Try
            Chart1.Titles.Add("Liczba przesyłek wg regionu, tydzień:" & tydzien & " " & rok)

            Chart1.Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
            Chart1.DataSource = dt
            Chart1.Series(0).Name = dt.Columns(1).ColumnName
            '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
            'Chart1.Legends(0).Enabled = True
            Chart1.Series(0).XValueMember = "Region" 'dt.Columns(0).ColumnName
            Chart1.Series(0).YValueMembers = "lp" ' dt.Columns(1).ColumnName
            Chart1.Series(0).IsValueShownAsLabel = True

            Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

            Chart1.ChartAreas(0).AxisX.Interval = 1

            Chart1.DataBind()
        Catch ex As Exception

        End Try

        dt = GRD.GetSource(2).dt
        dg2.DataSource = dt
        dg2.DataBind()

        Try
            With Chart2
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
                .Titles.Add("Udział poszczególnych rodzajów przesyłek w ogólnej liczbie przesyłek, tydzień:" & tydzien & " " & rok)

                .Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
                .DataSource = dt
                .Series(0).Name = dt.Columns(1).ColumnName
                '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
                'Chart1.Legends(0).Enabled = True
                .Series(0).XValueMember = "typp" 'dt.Columns(0).ColumnName
                .Series(0).YValueMembers = "udzial" ' dt.Columns(1).ColumnName
                .Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .ChartAreas(0).AxisX.Interval = 1

                .ChartAreas(0).Area3DStyle.Enable3D = True
                .ChartAreas(0).Area3DStyle.Inclination = 0


                For Each s In .Series
                    s.ToolTip = " #VALX - #VALY %"
                    s.Label = " #VALX - #VALY %"
                    s.SetCustomProperty("PieLabelStyle", "outside")
                    s("BarLabelStyle") = "Center"
                    s("PointWidth") = "0.5"
                    s.BorderWidth = 0.1
                    s.BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                    s.BorderColor = System.Drawing.Color.Black

                    For Each p In s.Points
                        p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        p.Label = s.ToolTip
                        p.MarkerSize = 12

                    Next
                Next

                .DataBind()
            End With

        Catch ex As Exception

        End Try



        dt = GRD.GetSource(3).dt



        Try
            With Chart5
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
                .Titles.Add("Liczba przesyłek ze świadczeniem NG wg regionu w fazie nadania, tydzień:" & tydzien & " " & rok)

                .Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
                .DataSource = dt
                .Series(0).Name = dt.Columns(1).ColumnName
                '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
                'Chart1.Legends(0).Enabled = True
                .Series(0).XValueMember = "Jednostki_fazy_Region" 'dt.Columns(0).ColumnName
                .Series(0).YValueMembers = "NSTD" ' dt.Columns(1).ColumnName
                .Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .ChartAreas(0).AxisX.Interval = 1

                .ChartAreas(0).Area3DStyle.Enable3D = True
                .ChartAreas(0).Area3DStyle.Inclination = 0


                For Each s In .Series
                    s.ToolTip = " #VALX - #VALY "
                    s.Label = " #VALX - #VALY "
                    s.SetCustomProperty("PieLabelStyle", "outside")
                    s("BarLabelStyle") = "Center"
                    s("PointWidth") = "0.5"
                    s.BorderWidth = 0.1
                    s.BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                    s.BorderColor = System.Drawing.Color.Black

                    For Each p In s.Points
                        p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        p.Label = s.ToolTip
                        p.MarkerSize = 12

                    Next
                Next

                .DataBind()
            End With

        Catch ex As Exception

        End Try

        Try
            With Chart6
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
                .Titles.Add("Liczba przesyłek ze świadczeniem OP,OPZ wg regionu w fazie nadania, tydzień:" & tydzien & " " & rok)

                .Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
                .DataSource = dt
                .Series(0).Name = dt.Columns(1).ColumnName
                '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
                'Chart1.Legends(0).Enabled = True
                .Series(0).XValueMember = "Jednostki_fazy_Region" 'dt.Columns(0).ColumnName
                .Series(0).YValueMembers = "OPZ" ' dt.Columns(1).ColumnName
                .Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .ChartAreas(0).AxisX.Interval = 1

                .ChartAreas(0).Area3DStyle.Enable3D = True
                .ChartAreas(0).Area3DStyle.Inclination = 0


                For Each s In .Series
                    s.ToolTip = " #VALX - #VALY "
                    s.Label = " #VALX - #VALY "
                    s.SetCustomProperty("PieLabelStyle", "outside")
                    s("BarLabelStyle") = "Center"
                    s("PointWidth") = "0.5"
                    s.BorderWidth = 0.1
                    s.BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                    s.BorderColor = System.Drawing.Color.Black

                    For Each p In s.Points
                        p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        p.Label = s.ToolTip
                        p.MarkerSize = 12

                    Next
                Next

                .DataBind()
            End With

        Catch ex As Exception

        End Try

        dg4.DataSource = dt
        dg4.DataBind()


        BindNTF()
    End Sub
    Sub BindNTF()
        Dim dt As DataTable
        GRD = Session("grd")
        dt = GRD.GetSource(4).dt

        dg5.DataSource = dt
        dg5.DataBind()


        Dim l As New List(Of chartBindingHelperType)
        For i = 0 To dt.Rows.Count - 1
            Dim o As New chartBindingHelperType
            o.seria = dt.Rows(i)("Nazwa_fazy")
            o.wartosc = dt.Rows(i)("lp")
            o.ospozioma = dt.Rows(i)("Jednostki_fazy_Region")
            If o.seria = ddl2.SelectedValue Then l.Add(o)
        Next

        l = l.OrderBy(Function(x) x.wartosc).ToList()



        Try
            With Chart7

                .Titles.Add("Liczba przesyłek nieterminowych w fazie " & ddl2.SelectedValue & " oraz E2E wg regionu, w którym wystąpiła niterminowość fazy, tydzień:" & tydzien & " " & rok)

                .Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
                .DataSource = l
                .Series(0).XValueMember = "ospozioma"
                .Series(0).YValueMembers = "wartosc"

                '.Series(0).Name = dt.Columns(1).ColumnName

                ' .DataBindCrossTable(l, "ospozioma", "seria", "wartosc", Nothing)

                '.Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .ChartAreas(0).AxisX.Interval = 1
                '.ChartAreas(0).AxisY.Interval = 1
                '.ChartAreas(0).Area3DStyle.Enable3D = True
                '.ChartAreas(0).Area3DStyle.Inclination = 0


                For Each s In .Series
                    s.ChartType = DataVisualization.Charting.SeriesChartType.StackedBar
                    s.ToolTip = " #VALY "
                    's.IsValueShownAsLabel = True
                    s.Label = " ----------#VALY "
                    's.SetCustomProperty("PieLabelStyle", "outside")
                    s.SetCustomProperty("BarLabelStyle", "outside")
                    's("BarLabelStyle") = "Center"
                    's("PointWidth") = "0.5"
                    's.BorderWidth = 0.1
                    s.BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                    s.BorderColor = System.Drawing.Color.Black

                    For Each p In s.Points
                        'p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        'p.Label = s.ToolTip
                        'p.MarkerSize = 12

                    Next
                Next

                .DataBind()
            End With

        Catch ex As Exception

        End Try




        BindFaza(ddlfaza.SelectedValue, Chart3, dg3, Chart4)





    End Sub
    Sub BindFaza(faza As String, chart As DataVisualization.Charting.Chart, dg As GridView, Optional chartWolulmens As DataVisualization.Charting.Chart = Nothing)
        Dim dt As DataTable
        Dim m As mySQLcore = mySQLcore.DB_Main
        dt = m.FillDatatable("select region,faza, sum(wszystkie) as 'all',sum(tfaza) as 'tfaza',sum(tparam) as 'tparam',sum(te2e) as 'e2e',CAST( ROUND(sum(tfaza)/sum(tparam)*100,2) AS CHAR) as 'tf' from tfsummary where tydzien=" & tydzien & " and rok=" & rok & " group by region,faza order by ROUND(sum(tfaza)/sum(tparam)*100,2) asc;")

        dt.Columns.Add("nieterminowe")
        dt.Columns.Add("niesparametryzowane")
        Dim ft As DataTable
        ft = New DataTable

        For x = 0 To dt.Columns.Count - 1
            ft.Columns.Add(dt.Columns(x).ColumnName)
        Next

        Dim min As Integer = 85

        For i = 0 To dt.Rows.Count - 1

            Dim wszystkie As Integer = dt.Rows(i)("all")
            Dim termf As Integer = dt.Rows(i)("tfaza")
            Dim param As Integer = dt.Rows(i)("tparam")

            dt.Rows(i)("nieterminowe") = param - termf
            dt.Rows(i)("niesparametryzowane") = wszystkie - param

            dt.Rows(i)("tf") = dt.Rows(i)("tf").ToString.Replace(",", ".")
            If dt.Rows(i)("faza") = faza Then
                ft.ImportRow(dt.Rows(i))
            End If


            Try
                Dim ct As Integer = dt.Rows(i)("tf").ToString
                If ct < min Then min = ct - 5
            Catch ex As Exception

            End Try

        Next

        dg.DataSource = ft
        dg.DataBind()



        Try
            With chart
                .Titles.Clear()
                .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
                .Titles.Add("Terminowość fazy " & faza & ", tydzień:" & tydzien & " " & rok)

                .Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
                .DataSource = ft
                .Series(0).Name = ft.Columns(1).ColumnName
                '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
                'Chart1.Legends(0).Enabled = True
                .Series(0).XValueMember = "region" 'dt.Columns(0).ColumnName
                .Series(0).YValueMembers = "tf" ' dt.Columns(1).ColumnName
                .Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .ChartAreas(0).AxisX.Interval = 1
                .ChartAreas(0).AxisY.Minimum = min

                '.ChartAreas(0).Area3DStyle.Enable3D = True
                '.ChartAreas(0).Area3DStyle.Inclination = 0


                For Each s In .Series


                    's.Color = 

                    s.ToolTip = " #VALX - #VALY %"
                    s.Label = "#VALY %"
                    's.SetCustomProperty("PieLabelStyle", "outside")
                    s("BarLabelStyle") = "Center"
                    s("PointWidth") = "0.5"
                    's.BorderWidth = 0.1
                    's.BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                    's.BorderColor = System.Drawing.Color.Black



                    For Each p In s.Points
                        p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        p.Label = s.ToolTip
                        p.MarkerSize = 12
                    Next


                Next

                .DataBind()
            End With


            If Not IsNothing(chartWolulmens) Then
                With chartWolulmens
                    .Titles.Clear()

                    .Titles.Add("Wolumeny przesyłek dla fazy " & faza & ", tydzień:" & tydzien & " " & rok)

                    .Width = 1280 '(Request.Browser.ScreenPixelsWidth) * 2
                    .DataSource = ft

                    '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)

                    '.Legends(0).Enabled = True


                    .Series.Clear()


                    .Series.Add("Terminowe w fazie")
                    .Series("Terminowe w fazie").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
                    .Series("Terminowe w fazie").XValueMember = "region"
                    .Series("Terminowe w fazie").YValueMembers = "tfaza"
                    .Series("Terminowe w fazie").IsValueShownAsLabel = True
                    .Series("Terminowe w fazie").Color = System.Drawing.Color.DarkGreen

                    .Series.Add("Nieterminowe")
                    .Series("Nieterminowe").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
                    .Series("Nieterminowe").XValueMember = "region"
                    .Series("Nieterminowe").YValueMembers = "nieterminowe"
                    .Series("Nieterminowe").IsValueShownAsLabel = True
                    .Series("Nieterminowe").Color = System.Drawing.Color.Red


                    .Series.Add("Niesparametryzowane")
                    .Series("Niesparametryzowane").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
                    .Series("Niesparametryzowane").XValueMember = "region"
                    .Series("Niesparametryzowane").YValueMembers = "niesparametryzowane"
                    .Series("Niesparametryzowane").IsValueShownAsLabel = True
                    .Series("Niesparametryzowane").Color = System.Drawing.Color.Silver

                    .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                    .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                    .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                    .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                    .ChartAreas(0).AxisX.Interval = 1
                    '.ChartAreas(0).AxisY.Minimum = min

                    '.ChartAreas(0).Area3DStyle.Enable3D = True
                    '.ChartAreas(0).Area3DStyle.Inclination = 0


                    For Each s In .Series


                        's.Color = 

                        s.ToolTip = s.Name & " #VALY"
                        s.Label = "#VALY"
                        's.SetCustomProperty("PieLabelStyle", "outside")
                        s("BarLabelStyle") = "Center"
                        s("PointWidth") = "0.5"
                        's.BorderWidth = 0.1
                        's.BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
                        's.BorderColor = System.Drawing.Color.Black



                        For Each p In s.Points
                            p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                            p.Label = s.ToolTip
                            p.MarkerSize = 12
                        Next


                    Next

                    .DataBind()

                    .Legends.Add("Legenda")
                    .Legends(0).Docking = DataVisualization.Charting.Docking.Bottom

                End With
            End If


        Catch ex As Exception

        End Try



    End Sub
    Protected Sub dg5_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If dg5.Rows.Count > 0 Then
            dg5.UseAccessibleHeader = True
            dg5.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg5, "Select$" & e.Row.RowIndex)
        End If

    End Sub
    Protected Sub dg5_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = dg5.Rows(dg5.SelectedIndex)

        Dim region As String = TryCast(row.FindControl("Label2"), Label).Text

        Bind()

    End Sub
    Protected Sub dg4_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If dg4.Rows.Count > 0 Then
            dg4.UseAccessibleHeader = True
            dg4.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg4, "Select$" & e.Row.RowIndex)
        End If

    End Sub
    Protected Sub dg4_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = dg4.Rows(dg4.SelectedIndex)

        Dim region As String = TryCast(row.FindControl("Label2"), Label).Text

        Bind()


    End Sub


    Sub BindMONGO()
        Dim sx As String = "Nazwa_fazy"
        Dim sy As String = "tf"

        Dim l As New List(Of MongoDBReportsCore.pipeObject)
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Nazwa_fazy", .typ = MongoDBReportsCore.pipeObject.pipefieldType.grupuj, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Terminowosc_fazy_dla_jednostki", .typ = 4, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Sparametryzowana", .typ = 4, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Jednostki_fazy_Region", .typ = 0, .value = "RD Wrocław"})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "tydzien", .typ = 0, .value = "Tydzien 5 2021"})


        Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.CreatePipe(l, "tf"), "tf")

        dt.Columns.Add("tf")

        For i = 0 To dt.Rows.Count - 1
            Dim term As Integer = dt.Rows(i)("SUM(Terminowosc_fazy_dla_jednostki)")
            Dim par As Integer = dt.Rows(i)("SUM(Sparametryzowana)")

            dt.Rows(i)("tf") = Math.Round(term / par, 2)
        Next

        dg1.DataSource = dt
        dg1.DataBind()

        Try
            Chart1.DataSource = dt
            Chart1.Series(0).Name = dt.Columns(1).ColumnName
            '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
            'Chart1.Legends(0).Enabled = True
            Chart1.Series(0).XValueMember = sx 'dt.Columns(0).ColumnName
            Chart1.Series(0).YValueMembers = sy ' dt.Columns(1).ColumnName
            Chart1.Series(0).IsValueShownAsLabel = True

            Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

            Chart1.ChartAreas(0).AxisX.Interval = 1

            Chart1.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If dg1.Rows.Count > 0 Then
            dg1.UseAccessibleHeader = True
            dg1.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg1, "Select$" & e.Row.RowIndex)
        End If

    End Sub
    Protected Sub dg1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = dg1.Rows(dg1.SelectedIndex)

        Dim region As String = TryCast(row.FindControl("Label2"), Label).Text

        Bind()

    End Sub

    Protected Sub dg2_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If dg2.Rows.Count > 0 Then
            dg2.UseAccessibleHeader = True
            dg2.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg2, "Select$" & e.Row.RowIndex)
        End If

    End Sub
    Protected Sub dg2_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = dg2.Rows(dg2.SelectedIndex)

        Dim region As String = TryCast(row.FindControl("Label2"), Label).Text

        Bind()

    End Sub

    Protected Sub dg3_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If dg3.Rows.Count > 0 Then
            dg3.UseAccessibleHeader = True
            dg3.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg3, "Select$" & e.Row.RowIndex)
        End If

    End Sub
    Protected Sub dg3_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = dg3.Rows(dg3.SelectedIndex)

        Dim region As String = TryCast(row.FindControl("Label2"), Label).Text

        Bind()

    End Sub



    Protected Sub ddlfaza_SelectedIndexChanged(sender As Object, e As EventArgs)
        'BindFaza(ddlfaza.SelectedValue, Chart3, dg3, Chart4)
        Bind()

    End Sub

    Protected Sub ddl2_SelectedIndexChanged(sender As Object, e As EventArgs)

        Bind()
    End Sub
End Class
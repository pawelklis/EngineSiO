
Imports System.Web.UI.DataVisualization.Charting
Imports EngineSiO
Imports EngineSiO.MongoDBQuery

Public Class frmCrewTargetChart
    Inherits System.Web.UI.Page
    Dim ss As sessionClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ss = Session("sesja")
        If Not IsPostBack Then
            bind()
        End If

    End Sub
    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
        bind()
    End Sub
    Sub bind()
        Dim dt As DataTable = MongoDBReportsCore.CrewTargetChart(Now, ss.OrganizationUnit.Id)




        Dim lz As List(Of ZoneType) = ZoneType.Load(ss.OrganizationUnit.Id)
        Dim l As New List(Of helpertrm)

        With c1





            For i = 0 To dt.Rows.Count - 1
                Try
                    Dim ob As New helpertrm
                    ob.seria = dt.Rows(i)(0).ToString
                    ob.wartosc = dt.Rows(i)(2)
                    ob.ospozioma = dt.Rows(i)(1)

                    For Each z In lz
                        If z.Id.ToString = ob.seria Then
                            ob.seria = z.Name
                        End If
                    Next



                    l.Add(ob)
                Catch ex As Exception

                End Try

            Next
            .Series.Clear()

            .DataBindCrossTable(l, "seria", "ospozioma", "wartosc", Nothing)



            .ChartAreas(0).AxisX.LabelStyle.Interval = 1
            .ChartAreas(0).AxisX.MajorGrid.Enabled = False
            .ChartAreas(0).AxisY.MajorGrid.Enabled = False

            '.ChartAreas(0).AxisY.Minimum = 90
            '.ChartAreas(0).AxisY.Maximum = 100
            .ChartAreas(0).AxisY.LineColor = System.Drawing.Color.Silver
            .ChartAreas(0).AxisX.LineColor = Drawing.Color.Silver

            .Legends.Add(New DataVisualization.Charting.Legend)

            For Each s In .Series
                s.ChartType = DataVisualization.Charting.SeriesChartType.Column
                s.LabelAngle = 45
                s.BorderWidth = 3
                s.MarkerBorderWidth = 5
                If s.Name = "nadania" Then s.Color = Drawing.Color.Green
                If s.Name = "doręczenia" Then s.Color = Drawing.Color.Red
                If s.Name = "przewozu" Then s.Color = Drawing.Color.Gray
                If s.Name = "koncentracji" Then s.Color = Drawing.Color.Blue
                If s.Name = "dekoncentracji" Then s.Color = Drawing.Color.Yellow
            Next


            '.Titles.Add(New DataVisualization.Charting.Title With {
            '                  .Text = "Przesyłki nadeszłe"})


            .DataBind()

            .Width = Request.Browser.ScreenPixelsWidth * 2




            'With .Series(0)
            '    .YAxisType = AxisType.Secondary
            '    .BorderWidth = 1
            '    .ChartType = SeriesChartType.Spline

            'End With

            .ChartAreas(0).AxisX2.MinorGrid.Enabled = False
            .ChartAreas(0).AxisY2.MajorGrid.Enabled = False



            .Legends(0).Docking = DataVisualization.Charting.Docking.Top
            .Legends(0).Alignment = Drawing.StringAlignment.Center
            For Each s In .Series
                s.IsValueShownAsLabel = True


                If InStr(s.Name.ToLower, "godzin", Microsoft.VisualBasic.CompareMethod.Text) <> 0 Then
                    s.ToolTip = s.Name & " #VALX [#VALY godzin]"
                Else
                    s.ToolTip = s.Name & " #VALX [#VALY osoby]"
                End If
                If s.Name = "Średni czas użycia skanera w dobie" Then
                    s.ToolTip = s.Name & " #VALX [#VALY H/skaner]"
                End If
                If s.Name <> "Liczba pobrań" Then
                    For Each p In s.Points
                        'p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        'p.Label = s.ToolTip
                        'p.MarkerSize = 12

                    Next
                End If

            Next


            '.Series(0).ChartType = SeriesChartType.Column

            .CssClass = "linechart"

            Dim t As New Title
            t.Text = "Liczba osób realizujących zadania w poszczególnych strefach"
            t.Font = New Drawing.Font("Calibri", 24, System.Drawing.FontStyle.Bold)

            .Titles.Add(t)

            .Legends(0).Alignment = Drawing.StringAlignment.Far


            .Width = 790
        End With



    End Sub

    Class helpertrm
        Public Property seria As String
        Public Property wartosc As Double
        Public Property ospozioma As String
    End Class
End Class
Imports System.Web.UI.DataVisualization.Charting
Imports EngineSiO
Imports EngineSiO.MongoDBQuery

Public Class frmCrewPresentChart
    Inherits System.Web.UI.Page

    Dim s As sessionClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")
        If Not IsPostBack Then
            bind()
        End If

    End Sub
    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
        bind()
    End Sub
    Sub bind()
        Dim dt As DataTable = MongoDBReportsCore.Harmonogram_Obecnosc_chart(Now, s.Zone.Id)





        Dim l As New List(Of helpertrm)

        With c1





            For i = 0 To dt.Rows.Count - 1
                Try
                    Dim ob As New helpertrm
                    ob.seria = "Planowani"
                    ob.wartosc = dt.Rows(i)(1)

                    Dim d As Date
                    d = dt.Rows(i)(0)
                    ob.ospozioma = d.ToShortTimeString


                    l.Add(ob)

                    ob = New helpertrm
                    ob.seria = "Obecni"
                    ob.wartosc = dt.Rows(i)(2)
                    d = dt.Rows(i)(0)
                    ob.ospozioma = d.ToShortTimeString


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

            For Each ss In .Series
                ss.ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
                ss.LabelAngle = 45
                ss.BorderWidth = 3
                ss.MarkerBorderWidth = 5
                If ss.Name = "nadania" Then ss.Color = Drawing.Color.Green
                If ss.Name = "doręczenia" Then ss.Color = Drawing.Color.Red
                If ss.Name = "przewozu" Then ss.Color = Drawing.Color.Gray
                If ss.Name = "koncentracji" Then ss.Color = Drawing.Color.Blue
                If ss.Name = "dekoncentracji" Then ss.Color = Drawing.Color.Yellow
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
            For Each ss In .Series
                ss.IsValueShownAsLabel = True


                If InStr(ss.Name.ToLower, "godzin", Microsoft.VisualBasic.CompareMethod.Text) <> 0 Then
                    ss.ToolTip = ss.Name & " #VALX [#VALY godzin]"
                Else
                    ss.ToolTip = ss.Name & " #VALX [#VALY osoby]"
                End If
                If ss.Name = "Średni czas użycia skanera w dobie" Then
                    ss.ToolTip = ss.Name & " #VALX [#VALY H/skaner]"
                End If
                If ss.Name <> "Liczba pobrań" Then
                    For Each p In ss.Points
                        'p.MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                        'p.Label = s.ToolTip
                        'p.MarkerSize = 12

                    Next
                End If

            Next


            '.Series(0).ChartType = SeriesChartType.Column

            .CssClass = "linechart"

            Dim t As New Title
            t.Text = "Obecność"
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
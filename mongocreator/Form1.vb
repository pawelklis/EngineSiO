Imports EngineSiO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim st As Date = Now


        Dim l As New List(Of MongoDBReportsCore.pipeObject)

        Dim sb As New System.Text.StringBuilder

        Dim sx As String
        Dim sy As String

        For Each row As DataGridViewRow In dgf.Rows

            Dim pole As String = row.Cells("pole").Value
            Dim typ As String = row.Cells("typ").Value
            Dim v As String = row.Cells("val").Value

            If row.Cells("cx").Value = True Then
                sx = pole
                If typ = "sum" Then
                    sx = "SUM(" & pole & ")"
                End If
                If typ = "count" Then
                    sx = "COUNT(" & pole & ")"
                End If
            End If
            If row.Cells("cy").Value = True Then
                sy = pole
                If typ = "sum" Then
                    sy = "SUM(" & pole & ")"
                End If
                If typ = "count" Then
                    sy = "COUNT(" & pole & ")"
                End If
            End If

            Dim o As New MongoDBReportsCore.pipeObject
            o.fieldname = pole

            If typ = "filtruj" Then o.typ = MongoDBReportsCore.pipeObject.pipefieldType.filtruj
            If typ = "pokaz" Then o.typ = MongoDBReportsCore.pipeObject.pipefieldType.grupuj
            If typ = "grupuj" Then o.typ = MongoDBReportsCore.pipeObject.pipefieldType.grupuj
            If typ = "count" Then o.typ = MongoDBReportsCore.pipeObject.pipefieldType.count
            If typ = "sum" Then o.typ = MongoDBReportsCore.pipeObject.pipefieldType.sum
            ' If typ = "distinct" Then o.typ = MongoDBReportsCore.pipeObject.pipefieldType.distinct


            o.value = v


            If Not IsNothing(o.fieldname) Then
                l.Add(o)
            End If



            sb.AppendLine("l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = """ & pole & """, .typ = " & o.typ & ", .value = """ & o.value & """})")

        Next


        sb.AppendLine("sx=""" & sx & """")
        sb.AppendLine("sy=""" & sy & """")


        Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.CreatePipe(l, "tf"), "tf")

        dg1.DataSource = dt

        RichTextBox1.Text = sb.ToString


        Try
            Chart1.DataSource = dt
            Chart1.Series(0).Name = dt.Columns(1).ColumnName
            '      Chart1.Series(0).ChartType = CType(Integer.Parse(rblChartType.SelectedItem.Value), SeriesChartType)
            Chart1.Legends(0).Enabled = True
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


        Dim ts As Date = Now

        Dim ti As Integer = DateDiff(DateInterval.Second, st, ts)
        Label1.Text = ti & " sekund"


    End Sub


    Private Sub dgf_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgf.CellDoubleClick
        Try
            dgf.Rows.Remove(dgf.Rows(e.RowIndex))
        Catch ex As Exception

        End Try


    End Sub


End Class

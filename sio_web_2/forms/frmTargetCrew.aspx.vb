Imports EngineSiO

Public Class frmTargetCrew
    Inherits System.Web.UI.Page

    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("dg1", 0, False, dg1.Columns.Count), False)

        If Not IsPostBack Then
            Bind()
        End If



    End Sub
    Sub Bind()
        Try
            Dim ldel As List(Of delType) = delType.Load(s.Zone.Id)


            Dim dt As DataTable = MongoDBReportsCore.Harmonogram_Zadania(Now, s.Zone.Id, True)

            '_id, WorkerCode, WorkerName, Exe_StartTime, Exe_WorkTypeID , Exe_WorkTime, Exe_EndWorkTime  ,Present ,Target 

            Dim l As New List(Of HarmonogramType)

            If Not dt.Columns.Contains("Target") Then
                dt.Columns.Add("Target")
            End If

            For i = 0 To dt.Rows.Count - 1

                Dim h As New HarmonogramType
                h._id = dt.Rows(i)("_id")
                h.WorkerName = dt.Rows(i)("WorkerName")
                h.Exe_StartTime = dt.Rows(i)("Exe_StartTime")
                h.Exe_WorkTime = dt.Rows(i)("Exe_WorkTime")
                h.Exe_EndWorkTime = dt.Rows(i)("Exe_EndWorkTime")
                h.Target = dt.Rows(i)("Target").ToString
                h.Present = dt.Rows(i)("present")

                h.tempstatus = ""

                For Each dl In ldel
                    If dl.WorkerName.ToLower = h.WorkerName.ToLower Then
                        If dl.idzonefrom <> s.Zone.Id Then
                            h.tempstatus = "Ze strefy " & dl.ZoneFrom
                        End If
                        If dl.idzoneTo <> s.Zone.Id Then
                            h.tempstatus = "W strefie " & dl.ZoneTo
                        End If
                    End If
                Next


                l.Add(h)

            Next

            If dt.Rows.Count = 0 Then
                If Not IsNothing(ldel) AndAlso ldel.Count > 0 Then

                    For Each d In ldel

                        If d.idzonefrom <> s.Zone.Id Then
                            dt = MongoDBReportsCore.Harmonogram_Zadania(Now, d.idzonefrom, True)
                        Else
                            dt = MongoDBReportsCore.Harmonogram_Zadania(Now, d.idzoneTo, True)
                        End If

                        For i = 0 To dt.Rows.Count - 1
                            Dim h As New HarmonogramType
                            h._id = dt.Rows(i)("_id")
                            h.WorkerName = dt.Rows(i)("WorkerName")
                            h.Exe_StartTime = dt.Rows(i)("Exe_StartTime")
                            h.Exe_WorkTime = dt.Rows(i)("Exe_WorkTime")
                            h.Exe_EndWorkTime = dt.Rows(i)("Exe_EndWorkTime")
                            h.Target = dt.Rows(i)("Target").ToString
                            h.Present = dt.Rows(i)("present")

                            h.tempstatus = ""
                            Dim okW As Boolean = False
                            For Each dl In ldel
                                If dl.WorkerName.ToLower = h.WorkerName.ToLower Then
                                    okW = True
                                    If dl.idzonefrom <> s.Zone.Id Then
                                        h.tempstatus = "Ze strefy " & dl.ZoneFrom
                                    End If
                                    If dl.idzoneTo <> s.Zone.Id Then
                                        h.tempstatus = "W strefie " & dl.ZoneTo
                                    End If
                                End If
                            Next


                            Dim ok As Boolean = True
                            For Each o In l
                                If o.WorkerName = h.WorkerName Then
                                    ok = False
                                    Exit For
                                End If
                            Next

                            If ok = True Then
                                If okW = True Then
                                    l.Add(h)
                                End If

                            End If
                        Next

                    Next




                End If
            End If



            dg1.DataSource = l
            dg1.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dg1_RowCommand(sender As Object, e As GridViewCommandEventArgs)


        Dim row As GridViewRow = CType(((CType(e.CommandSource, Control)).NamingContainer), GridViewRow)

        Dim tx As TextBox = TryCast(row.FindControl("labelx1"), TextBox)

        Dim id As String = TryCast(row.FindControl("lbid"), Label).Text

        If e.CommandName = "start" Then
            Dim h As HarmonogramType = HarmonogramType.Load(id)
            h.Exe_StartTime = h.Plan_StartTime
            h.Exe_WorkTime = h.Plan_WorkTime

            h.Save()

        End If


        Bind()

    End Sub
    Protected Sub dg1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")

        If dg1.Rows.Count > 0 Then
            dg1.UseAccessibleHeader = True
            dg1.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg1, "Select$" & e.Row.RowIndex)
            'e.Row.ToolTip = "Click to select this row."
            Dim id As String = TryCast(e.Row.FindControl("lbname"), Label).ToolTip

            Dim lbstart As Label = TryCast(e.Row.FindControl("planstart"), Label)
            Dim lbstop As Label = TryCast(e.Row.FindControl("planstop"), Label)

            Dim d As Date

            d = lbstart.Text
            lbstart.Text = d.ToShortTimeString

            d = lbstop.Text
            lbstop.Text = d.ToShortTimeString


            Dim status As Label = TryCast(e.Row.FindControl("lbtempstatus"), Label)


            If Not String.IsNullOrEmpty(status.Text) Then
                If status.Text.ToLower.StartsWith("ze") Then
                    e.Row.Style.Add("background-color", "lightgreen")
                Else
                    e.Row.Style.Add("background-color", "silver")
                End If

            End If

        End If
    End Sub

    Protected Sub txstart_TextChanged(sender As Object, e As EventArgs)
        Dim tx As TextBox = sender


        Dim Exe_EndWorkTime As String = tx.Text
        Dim h As HarmonogramType = HarmonogramType.Load(tx.ValidationGroup)




        h.Target = tx.Text

        h.Save()

        Dim m As mySQLcore = mySQLcore.DB_Main

        If m.GetCount("select count(*) from targetdict where content='" & tx.Text & "'") = 0 Then
            m.ExecuteNonQuery("insert into targetdict (content) values ('" & h.Target & "')")
        End If


        Bind()

    End Sub

    <System.Web.Script.Services.ScriptMethod(),
System.Web.Services.WebMethod()>
    Public Shared Function auto(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        Dim m As mySQLcore = mySQLcore.DB_Main

        Dim dt As DataTable = m.FillDatatable("select * from targetdict where content like '%" & prefixText & "%';")

        Dim l As New List(Of String)
        For i = 0 To dt.Rows.Count - 1
            l.Add(dt.Rows(i)("content"))
        Next


        Return l

    End Function

    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Bind()
    End Sub

End Class
Imports EngineSiO


Public Class frmCrewSummary
    Inherits System.Web.UI.Page

    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")

        If Not IsPostBack Then
            BindDDL
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("dg2", 0, False, dg2.Columns.Count), False)

    End Sub

    Sub BindDDL()

        Dim l As List(Of ZoneType) = ZoneType.Load(5)

        ddlZone.DataSource = l
        ddlZone.DataTextField = "name"
        ddlZone.DataValueField = "id"
        ddlZone.DataBind()

        ddlDate.Items.Clear()

        For y = Year(Now) - 5 To Year(Now) + 5
            Dim year As Integer = y
            For i = 1 To 12
                Dim month As Integer = i
                Dim m As String = i

                If month < 10 Then
                    m = "0" & i
                Else
                    m = i
                End If
                ddlDate.Items.Add(year & "-" & m)
            Next
        Next



    End Sub
    Sub Bind()
        BindAlternative()
        Exit Sub



        Dim idzone As Integer = ddlZone.SelectedValue

        Dim d As Date = ddlDate.SelectedValue & "-01"

        Dim lh As List(Of HarmonogramType) = HarmonogramType.Load(d, idzone)
        Dim lw As List(Of WorkerEntryType) = WorkerEntryType.Load(d, idzone)

        Dim l As New List(Of HarmonogramType.HarmonogramRozliczenieType)

        For Each h In lh
            Dim o As New HarmonogramType.HarmonogramRozliczenieType With {
            ._id = Guid.NewGuid.ToString,
            .Descr = h.Descr,
            .Exe_Data = h.Exe_Data,
            .Exe_EndWorkTime = h.Exe_EndWorkTime,
            .Exe_StartTime = h.Exe_StartTime,
            .Exe_WorkTime = h.Exe_WorkTime,
            .Exe_WorkTypeID = h.Exe_WorkTypeID,
            .idworker = h.idworker,
            .orgid = h.orgid,
            .Plan_Data = h.Plan_Data,
            .Plan_EndWorkTime = h.Plan_EndWorkTime,
            .Plan_StartTime = h.Plan_StartTime,
            .Plan_WorkTime = h.Plan_WorkTime,
            .Plan_WorkTypeID = h.Plan_WorkTypeID,
            .Present = h.Present,
            .ScanStart = h.ScanStart,
            .ScanStop = h.ScanStop,
            .Target = h.Target,
            .tempstatus = h.tempstatus,
            .WorkerCode = h.WorkerCode,
            .WorkerName = h.WorkerName,
            .zoneid = h.zoneid
            }



            Dim wl = From entry In lw
                     Select entry Where entry.idworker = o.idworker And entry.starttime.ToShortDateString = o.Plan_Data.ToShortDateString


            o.Entries = wl.ToList

            If o.Entries.Count > 0 Then

                For Each ent In o.Entries
                    Select Case ent.Reason.ReasonType
                        Case ReasonType.ReasonEnum.Prywatne
                            o.SumEntryPrivate += ent.timelenght
                        Case ReasonType.ReasonEnum.Służbowe
                            o.SumEntryWork += ent.timelenght
                    End Select
                Next



            End If

            l.Add(o)

        Next

        Dim dt As New DataTable
        dt.Columns.Add("_id")
        dt.Columns.Add("idworker")
        dt.Columns.Add("workercode")
        dt.Columns.Add("workername")
        dt.Columns.Add("day")
        dt.Columns.Add("plan_starttime")
        dt.Columns.Add("plan_endworktime")
        dt.Columns.Add("plan_worktime")
        dt.Columns.Add("plan_worktypeid")
        dt.Columns.Add("exe_starttime")
        dt.Columns.Add("exe_endworktime")
        dt.Columns.Add("exe_worktime")
        dt.Columns.Add("exe_worktypeid")
        dt.Columns.Add("scanstart")
        dt.Columns.Add("scanstop")
        dt.Columns.Add("present")
        dt.Columns.Add("target")
        dt.Columns.Add("descr")
        dt.Columns.Add("sumentryprivate")
        dt.Columns.Add("sumentrywork")
        dt.Columns.Add("r1")
        dt.Columns.Add("r2")
        dt.Columns.Add("scantime")


        Dim lr As List(Of RodzajGodzinType) = RodzajGodzinType.Load

        For Each o In l
            Dim _id As String = o._id
            Dim idworker As String = o.idworker
            Dim workercode As String = o.WorkerCode
            Dim workername As String = o.WorkerName
            Dim dd As String = o.Plan_StartTime.ToShortDateString & " " & o.Plan_Data.ToString("dddd")
            Dim plan_starttime As String = o.Plan_StartTime.ToShortTimeString
            Dim plan_endworktime As String = o.Plan_EndWorkTime.ToShortTimeString
            Dim tm As TimeSpan = TimeSpan.FromMinutes(o.Plan_WorkTime)
            Dim plan_worktime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            Dim rg As RodzajGodzinType
            For Each r In lr
                If r.idrodzajgodzin = o.Plan_WorkTypeID Then
                    rg = r
                    Exit For
                End If
            Next
            Dim plan_worktypeid As String = rg.nazwa
            Dim exe_starttime As String = o.Exe_StartTime.ToShortTimeString
            Dim exe_endworktime As String = o.Exe_EndWorkTime.ToShortTimeString
            tm = TimeSpan.FromMinutes(o.Exe_WorkTime)
            Dim exe_worktime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            For Each r In lr
                If r.idrodzajgodzin = o.Exe_WorkTypeID Then
                    rg = r
                    Exit For
                End If
            Next
            Dim exe_worktypeid As String = rg.nazwa
            Dim scanstart As String = o.ScanStart.ToShortTimeString
            Dim scanstop As String = o.ScanStop.ToShortTimeString
            Dim present As String = o.Present
            Dim target As String = o.Target
            Dim descr As String = o.Descr
            tm = TimeSpan.FromMinutes(o.SumEntryPrivate)
            Dim sumentryprivate As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            tm = TimeSpan.FromMinutes(o.SumEntryWork)
            Dim sumentrywork As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            tm = TimeSpan.FromMinutes((o.Exe_WorkTime - o.SumEntryPrivate) - o.Plan_WorkTime)
            Dim r1 As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")

            Dim sc As Integer = DateDiff(DateInterval.Minute, o.ScanStart, o.ScanStop)
            If sc < 0 Then sc = -sc
            tm = TimeSpan.FromMinutes((sc - o.SumEntryPrivate) - o.Plan_WorkTime)
            Dim r2 As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            tm = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, o.ScanStart, o.ScanStop))
            Dim scantime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")

            dt.Rows.Add(
            _id,
idworker,
workercode,
workername,
dd,
plan_starttime,
plan_endworktime,
plan_worktime,
plan_worktypeid,
exe_starttime,
exe_endworktime,
exe_worktime,
exe_worktypeid,
scanstart,
scanstop,
present,
target,
descr,
sumentryprivate,
sumentrywork,
r1,
r2,
scantime
)



        Next

        'dg1.DataSource = dt
        'dg1.DataBind()

        'If dg1.Rows.Count > 0 Then
        '    dg1.UseAccessibleHeader = True
        '    dg1.HeaderRow.TableSection = TableRowSection.TableHeader
        'End If



    End Sub
    Sub BindAlternative()
        Dim idzone As Integer = ddlZone.SelectedValue

        Dim d As Date = ddlDate.SelectedValue & "-01"

        Dim lh As List(Of HarmonogramType) = HarmonogramType.Load(d, idzone)
        Dim lw As List(Of WorkerEntryType) = WorkerEntryType.Load(d, idzone)
        Dim lr As List(Of RodzajGodzinType) = RodzajGodzinType.Load

        Session("lh") = lh
        Session("lw") = lw
        Session("lr") = lr


        Dim l As New List(Of HarmonogramType.HarmonogramRozliczenieType)

        For Each h In lh
            Dim o As New HarmonogramType.HarmonogramRozliczenieType With {
            ._id = Guid.NewGuid.ToString,
            .Descr = h.Descr,
            .Exe_Data = h.Exe_Data,
            .Exe_EndWorkTime = h.Exe_EndWorkTime,
            .Exe_StartTime = h.Exe_StartTime,
            .Exe_WorkTime = h.Exe_WorkTime,
            .Exe_WorkTypeID = h.Exe_WorkTypeID,
            .idworker = h.idworker,
            .orgid = h.orgid,
            .Plan_Data = h.Plan_Data,
            .Plan_EndWorkTime = h.Plan_EndWorkTime,
            .Plan_StartTime = h.Plan_StartTime,
            .Plan_WorkTime = h.Plan_WorkTime,
            .Plan_WorkTypeID = h.Plan_WorkTypeID,
            .Present = h.Present,
            .ScanStart = h.ScanStart,
            .ScanStop = h.ScanStop,
            .Target = h.Target,
            .tempstatus = h.tempstatus,
            .WorkerCode = h.WorkerCode,
            .WorkerName = h.WorkerName,
            .zoneid = h.zoneid
            }



            Dim wl = From entry In lw
                     Select entry Where entry.idworker = o.idworker And entry.starttime.ToShortDateString = o.Plan_Data.ToShortDateString


            o.Entries = wl.ToList

            If o.Entries.Count > 0 Then

                For Each ent In o.Entries
                    Select Case ent.Reason.ReasonType
                        Case ReasonType.ReasonEnum.Prywatne
                            o.SumEntryPrivate += ent.timelenght
                        Case ReasonType.ReasonEnum.Służbowe
                            o.SumEntryWork += ent.timelenght
                    End Select
                Next



            End If

            l.Add(o)

        Next



        Dim distWorkers = From o In lh
                          Select o.idworker Distinct

        Dim lista As New List(Of HarmonogramType.HarmonogramRozliczenieMasterType)
        For Each w In distWorkers.ToList
            Dim o As New HarmonogramType.HarmonogramRozliczenieMasterType(w, l, lr)
            lista.Add(o)
        Next

        Dim dt As New DataTable
        dt.Columns.Add("Pracownik")
        dt.Columns.Add("Planowanyczaspracy")
        dt.Columns.Add("Wykonanyczaspracy")
        dt.Columns.Add("Czaspracyskan")
        dt.Columns.Add("Sumarodzajówgodzin")
        dt.Columns.Add("idworker")
        dt.Columns.Add("roznica")

        For Each w In lista

            Dim workername As String = w.First.WorkerName
            Dim sumaplan As String = TimeSpan.FromMinutes(w.SumPlanWorkTime).TotalHours.ToString("00") & ":" & (TimeSpan.FromMinutes(w.SumPlanWorkTime).TotalMinutes - (TimeSpan.FromMinutes(w.SumPlanWorkTime).TotalHours * 60)).ToString("00")
            Dim exeplan As String = TimeSpan.FromMinutes(w.SumExeWorkTime).TotalHours.ToString("00") & ":" & (TimeSpan.FromMinutes(w.SumExeWorkTime).TotalMinutes - (TimeSpan.FromMinutes(w.SumExeWorkTime).TotalHours * 60)).ToString("00")
            Dim scantime As String = TimeSpan.FromMinutes(w.SumScanWorkTime).TotalHours.ToString("00") & ":" & (TimeSpan.FromMinutes(w.SumScanWorkTime).TotalMinutes - (TimeSpan.FromMinutes(w.SumScanWorkTime).TotalHours * 60)).ToString("00")
            Dim rr As String = ""

            Dim rm As Integer = w.SumExeWorkTime - w.SumPlanWorkTime
            Dim tm As TimeSpan = TimeSpan.FromMinutes(rm)
            Dim roznica As String = tm.TotalHours.ToString("00") & ":" & TimeSpan.FromMinutes((tm.TotalMinutes - (tm.TotalHours * 60))).TotalMinutes.ToString("00")

            For Each dd In w.SumWorkTypes

                Dim rg As String = "Brak"
                For Each r In lr
                    If r.idrodzajgodzin.ToString = dd.Key Then
                        rg = r.nazwa
                        Exit For
                    End If
                Next

                rr = rr & rg & ":" & dd.Value & "<br> "
            Next


            dt.Rows.Add(workername, sumaplan, exeplan, scantime, rr, w.idworker, roznica)

        Next

        dg2.DataSource = dt
        dg2.DataBind()



    End Sub



    Protected Sub ddlZone_SelectedIndexChanged(sender As Object, e As EventArgs)
        Bind()

    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Try


                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='silver'")
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")


                Dim r1 As Label = TryCast(e.Row.FindControl("Label82"), Label)
                Dim r2 As Label = TryCast(e.Row.FindControl("Label84"), Label)

                If r1.Text <> "00:00" Then
                    r1.ForeColor = System.Drawing.Color.Red
                Else
                    r1.ForeColor = System.Drawing.Color.Black
                End If

                If r2.Text <> "00:00" Then
                    r2.ForeColor = System.Drawing.Color.Red
                Else
                    r2.ForeColor = System.Drawing.Color.Black
                End If


                If r1.Text = "00:00" And r2.Text = "00:00" Then
                    e.Row.Style.Add("background-color", "lightgreen")
                Else
                    e.Row.Style.Remove("background-color")
                End If


            Catch ex As Exception

            End Try
        End If

    End Sub

    Protected Sub dg2_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = dg2.SelectedRow

        Dim idw As Integer = TryCast(row.FindControl("Label3"), Label).ToolTip

        Dim dg3 As GridView = TryCast(row.FindControl("dg3"), GridView)



        Dim pn As Panel = TryCast(row.FindControl("pn1"), Panel)
        If pn.Visible = False Then
            bindDG3(dg3, idw)
            pn.Visible = True
            row.Attributes.Remove("onmouseover")
            row.Attributes.Remove("onmouseout")
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("dg2_dg3_" & row.RowIndex, 0, False, dg3.Columns.Count), False)

        Else
            pn.Visible = False

            row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='coral'")
            row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")
        End If

    End Sub

    Protected Sub dg2_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub

    Protected Sub dg2_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(dg2, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Kliknij aby wyświetlić szczegóły."
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='coral'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")
        End If

    End Sub





    Sub bindDG3(dg As GridView, idworke As Integer)


        Dim idzone As Integer = ddlZone.SelectedValue

        Dim d As Date = ddlDate.SelectedValue & "-01"

        Dim lh As List(Of HarmonogramType) = Session("lh")
        Dim lw As List(Of WorkerEntryType) = Session("lw")
        Dim lr As List(Of RodzajGodzinType) = Session("lr")

        Dim l As New List(Of HarmonogramType.HarmonogramRozliczenieType)

        For Each h In lh
            If h.idworker = idworke Then


                Dim o As New HarmonogramType.HarmonogramRozliczenieType With {
            ._id = Guid.NewGuid.ToString,
            .Descr = h.Descr,
            .Exe_Data = h.Exe_Data,
            .Exe_EndWorkTime = h.Exe_EndWorkTime,
            .Exe_StartTime = h.Exe_StartTime,
            .Exe_WorkTime = h.Exe_WorkTime,
            .Exe_WorkTypeID = h.Exe_WorkTypeID,
            .idworker = h.idworker,
            .orgid = h.orgid,
            .Plan_Data = h.Plan_Data,
            .Plan_EndWorkTime = h.Plan_EndWorkTime,
            .Plan_StartTime = h.Plan_StartTime,
            .Plan_WorkTime = h.Plan_WorkTime,
            .Plan_WorkTypeID = h.Plan_WorkTypeID,
            .Present = h.Present,
            .ScanStart = h.ScanStart,
            .ScanStop = h.ScanStop,
            .Target = h.Target,
            .tempstatus = h.tempstatus,
            .WorkerCode = h.WorkerCode,
            .WorkerName = h.WorkerName,
            .zoneid = h.zoneid
            }



                Dim wl = From entry In lw
                         Select entry Where entry.idworker = o.idworker And entry.starttime.ToShortDateString = o.Plan_Data.ToShortDateString


                o.Entries = wl.ToList

                If o.Entries.Count > 0 Then

                    For Each ent In o.Entries
                        Select Case ent.Reason.ReasonType
                            Case ReasonType.ReasonEnum.Prywatne
                                o.SumEntryPrivate += ent.timelenght
                            Case ReasonType.ReasonEnum.Służbowe
                                o.SumEntryWork += ent.timelenght
                        End Select
                    Next



                End If

                l.Add(o)

            End If

        Next

        Dim dt As New DataTable
        dt.Columns.Add("_id")
        dt.Columns.Add("idworker")
        dt.Columns.Add("workercode")
        dt.Columns.Add("workername")
        dt.Columns.Add("day")
        dt.Columns.Add("plan_starttime")
        dt.Columns.Add("plan_endworktime")
        dt.Columns.Add("plan_worktime")
        dt.Columns.Add("plan_worktypeid")
        dt.Columns.Add("exe_starttime")
        dt.Columns.Add("exe_endworktime")
        dt.Columns.Add("exe_worktime")
        dt.Columns.Add("exe_worktypeid")
        dt.Columns.Add("scanstart")
        dt.Columns.Add("scanstop")
        dt.Columns.Add("present")
        dt.Columns.Add("target")
        dt.Columns.Add("descr")
        dt.Columns.Add("sumentryprivate")
        dt.Columns.Add("sumentrywork")
        dt.Columns.Add("r1")
        dt.Columns.Add("r2")
        dt.Columns.Add("scantime")




        For Each o In l
            Dim _id As String = o._id
            Dim idworker As String = o.idworker
            Dim workercode As String = o.WorkerCode
            Dim workername As String = o.WorkerName
            Dim dd As String = o.Plan_StartTime.ToShortDateString & " " & o.Plan_Data.ToString("dddd")
            Dim plan_starttime As String = o.Plan_StartTime.ToShortTimeString
            Dim plan_endworktime As String = o.Plan_EndWorkTime.ToShortTimeString
            Dim tm As TimeSpan = TimeSpan.FromMinutes(o.Plan_WorkTime)
            Dim plan_worktime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            Dim rg As RodzajGodzinType
            For Each r In lr
                If r.idrodzajgodzin = o.Plan_WorkTypeID Then
                    rg = r
                    Exit For
                End If
            Next
            Dim plan_worktypeid As String = rg.nazwa
            Dim exe_starttime As String = o.Exe_StartTime.ToShortTimeString
            Dim exe_endworktime As String = o.Exe_EndWorkTime.ToShortTimeString
            tm = TimeSpan.FromMinutes(o.Exe_WorkTime)
            Dim exe_worktime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            For Each r In lr
                If r.idrodzajgodzin = o.Exe_WorkTypeID Then
                    rg = r
                    Exit For
                End If
            Next
            Dim exe_worktypeid As String = rg.nazwa
            Dim scanstart As String = o.ScanStart.ToShortTimeString
            Dim scanstop As String = o.ScanStop.ToShortTimeString
            Dim present As String = o.Present
            Dim target As String = o.Target
            Dim descr As String = o.Descr
            tm = TimeSpan.FromMinutes(o.SumEntryPrivate)
            Dim sumentryprivate As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            tm = TimeSpan.FromMinutes(o.SumEntryWork)
            Dim sumentrywork As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            tm = TimeSpan.FromMinutes((o.Exe_WorkTime - o.SumEntryPrivate) - o.Plan_WorkTime)
            Dim r1 As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")

            Dim sc As Integer = DateDiff(DateInterval.Minute, o.ScanStart, o.ScanStop)
            If sc < 0 Then sc = -sc
            tm = TimeSpan.FromMinutes((sc - o.SumEntryPrivate) - o.Plan_WorkTime)
            Dim r2 As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
            tm = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, o.ScanStart, o.ScanStop))
            Dim scantime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")

            dt.Rows.Add(
            _id,
idworker,
workercode,
workername,
dd,
plan_starttime,
plan_endworktime,
plan_worktime,
plan_worktypeid,
exe_starttime,
exe_endworktime,
exe_worktime,
exe_worktypeid,
scanstart,
scanstop,
present,
target,
descr,
sumentryprivate,
sumentrywork,
r1,
r2,
scantime
)



        Next

        dg.DataSource = dt
        dg.DataBind()

        If dg.Rows.Count > 0 Then
            dg.UseAccessibleHeader = True
            dg.HeaderRow.TableSection = TableRowSection.TableHeader
        End If



    End Sub




End Class
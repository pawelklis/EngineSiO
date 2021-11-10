Imports System.Drawing
Imports EngineSiO

Public Class frmTodayCrew
    Inherits System.Web.UI.Page


    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "filter", PublicGlobalClass.ShowTableFilter("dg1", 0, False, dg1.Columns.Count), False)

        If Not IsPostBack Then
            Bind()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "Script", "reftarget()”, True)
        End If



    End Sub
    Sub Bind()
        Dim dt As DataTable = MongoDBReportsCore.Harmonogram_DzisiejszaObsada(Year(Now), Month(Now), Day(Now), s.Zone.Id)



        Dim l As New List(Of HarmonogramType)

        For i = 0 To dt.Rows.Count - 1

            Dim h As New HarmonogramType
            h._id = dt.Rows(i)("_id")
            h.WorkerName = dt.Rows(i)("WorkerName")
            h.Plan_StartTime = dt.Rows(i)("Plan_StartTime")
            h.Plan_WorkTime = dt.Rows(i)("Plan_WorkTime")
            h.Plan_WorkTypeID = RodzajGodzinType.Load(CInt(dt.Rows(i)("Plan_WorkTypeID"))).idrodzajgodzin
            h.Exe_StartTime = dt.Rows(i)("Exe_StartTime")
            h.Exe_WorkTime = dt.Rows(i)("Exe_WorkTime")
            h.Exe_WorkTypeID = RodzajGodzinType.Load(CInt(dt.Rows(i)("Exe_WorkTypeID"))).idrodzajgodzin
            h.WorkerCode = dt.Rows(i)("workercode")
            h.Plan_EndWorkTime = dt.Rows(i)("Plan_EndWorkTime")
            h.Exe_EndWorkTime = dt.Rows(i)("Exe_EndWorkTime")
            h.Present = dt.Rows(i)("present")

            If dt.Columns.Contains("ScanStart") Then
                If IsDate(dt.Rows(i)("ScanStart").ToString) Then
                    h.ScanStart = Date.Parse(dt.Rows(i)("ScanStart").ToString)
                End If
            End If
            If dt.Columns.Contains("ScanStop") Then
                If IsDate(dt.Rows(i)("ScanStop").ToString) Then
                    h.ScanStop = Date.Parse(dt.Rows(i)("ScanStop"))
                End If
            End If



            'h.Save()

            l.Add(h)

        Next





        dg1.DataSource = l
        dg1.DataBind()
    End Sub
    Protected Sub dg1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "ed" Then
            Dim id As String = e.CommandArgument

            ScriptManager.RegisterStartupScript(Me, Me.GetType, "md", "showModal('../forms/frmAddWorkerAdnotation.aspx?id=" & id & "')", True)

        End If



        'Dim row As GridViewRow = CType(((CType(e.CommandSource, LinkButton)).NamingContainer), GridViewRow) 'CType(((CType(e.CommandSource, Control)).NamingContainer), GridViewRow)
        ''If e.CommandName = "Select" Then
        ''    dg1.EditIndex = index
        ''End If
        'Dim tx As TextBox = TryCast(row.FindControl("labelx1"), TextBox)

        'Dim id As String = TryCast(row.FindControl("lbid"), Label).Text

        'If e.CommandName = "start" Then
        '    Dim h As HarmonogramType = HarmonogramType.Load(id)
        '    h.Exe_StartTime = h.Plan_StartTime
        '    h.Exe_WorkTime = h.Plan_WorkTime

        '    h.Save()

        'End If


        'Bind()

    End Sub
    Protected Sub dg1_SelectedIndexChanged(sender As Object, e As EventArgs)




        For Each row As GridViewRow In dg1.Rows
            If row.RowIndex = dg1.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
                row.Attributes.Add("selected", "1")

                TryCast(row.FindControl("lbid"), Label).CssClass = "1"

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
                TryCast(row.FindControl("lbid"), Label).CssClass = "0"
            End If
        Next



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
            Dim id As String = TryCast(e.Row.FindControl("lbid"), Label).Text
            'Dim h As HarmonogramType = HarmonogramType.Load(id)

            Dim lbname As Label = TryCast(e.Row.FindControl("lbname"), Label)

            Dim lbrodzajgodzin As Label = TryCast(e.Row.FindControl("Label144"), Label)

            Dim lbstart As Label = TryCast(e.Row.FindControl("planstart"), Label)
            Dim lbstop As Label = TryCast(e.Row.FindControl("planstop"), Label)

            Dim txstart As TextBox = TryCast(e.Row.FindControl("txstart"), TextBox)
            Dim txstop As TextBox = TryCast(e.Row.FindControl("txstop"), TextBox)

            Dim ck As CheckBox = TryCast(e.Row.FindControl("ckPresent"), CheckBox)

            Dim ddlZP As DropDownList = TryCast(e.Row.FindControl("ddlzp"), DropDownList)

            Dim scanStart As Label = TryCast(e.Row.FindControl("scanstart"), Label)
            Dim scanStop As Label = TryCast(e.Row.FindControl("scanstop"), Label)

            Dim zp As RodzajGodzinType

            Dim PlanStartTime As Date = lbstart.Text
            Dim PlanEndWorkTime As Date = lbstop.Text

            Dim ExeStartTime As Date = txstart.Text
            Dim ExeStopTime As Date = txstop.Text



            If IsNothing(ViewState("zp")) Then
                ViewState("zp") = RodzajGodzinType.Load
            End If

            'If ck.ValidationGroup = 0 Then
            '    ck.Checked = False
            'Else
            '    ck.Checked = True
            'End If



            For Each rr As RodzajGodzinType In ViewState("zp")
                Dim item As New ListItem
                item.Value = rr.idrodzajgodzin
                item.Text = rr.nazwa
                item.Attributes.Add("Title", rr.opis)
                ddlZP.Items.Add(item)

                If rr.idrodzajgodzin = lbrodzajgodzin.ToolTip Then
                    zp = rr
                End If

            Next

            If Not String.IsNullOrEmpty(lbrodzajgodzin.ToolTip) Then
                If lbrodzajgodzin.ToolTip <> 0 Then
                    ddlZP.SelectedValue = lbrodzajgodzin.ToolTip
                Else
                    ddlZP.SelectedValue = lbrodzajgodzin.Text
                End If
            Else
                ddlZP.SelectedValue = lbrodzajgodzin.Text
            End If

            Dim labelplanrodzajgodzin As Label = TryCast(e.Row.FindControl("Label144"), Label)
            labelplanrodzajgodzin.Text = ddlZP.SelectedItem.Text

            Dim d As DateTime
            d = lbstart.Text
            lbstart.Text = d.ToShortTimeString
            d = lbstop.Text
            lbstop.Text = d.ToShortTimeString
            d = txstart.Text
            txstart.Text = d.ToString.Replace(" ", "T")
            d = txstop.Text
            txstop.Text = d.ToString.Replace(" ", "T")
            d = scanStart.Text
            scanStart.Text = d.ToShortTimeString
            d = scanStop.Text
            scanStop.Text = d.ToShortTimeString

            If scanStart.Text = "00:00" Then
                scanStart.Text = "Brak skanu"
                scanStart.ForeColor = Color.Red
            Else
                scanStart.ForeColor = Color.Black
            End If

            If scanStop.Text = "00:00" Then
                scanStop.Text = "Brak skanu"
                scanStop.ForeColor = Color.Red
            Else
                scanStop.ForeColor = Color.Black
            End If

            d = lbname.ToolTip

            'Dim questionableDate As Date = Now
            'Dim fromDate As Date = h.Exe_StartTime
            'Dim toDate As Date = h.Exe_EndWorkTime

            'If (fromDate <= questionableDate) AndAlso (questionableDate <= toDate) Then
            '    e.Row.ToolTip = "Pracownik obecny w pracy."
            '    e.Row.Style.Add("background-color", "lightgreen")

            'Else
            '    If toDate < questionableDate Then
            '        If h.Exe_StartTime.ToShortTimeString <> "00:00" And h.Exe_EndWorkTime <> "00:00" Then
            '            e.Row.ToolTip = "Pracownik zakończył pracę."
            '            e.Row.Style.Add("background-color", "dimgrey")
            '        End If
            '    End If
            'End If

            'If h.Exe_StartTime.ToShortTimeString = "00:00" And h.Exe_EndWorkTime = "00:00" Then

            '    e.Row.ToolTip = "Pracownik powinien rozpocząć pracę."
            '    e.Row.Style.Add("color", "red")

            'Else

            'End If





            Dim status As ObsadaStatus = -1


            If status = -1 Then
                If Not IsNothing(zp) Then
                    If zp.CzyPraca = False Then
                        status = ObsadaStatus.nieobecny
                    End If
                End If
            End If


            If status = -1 Then
                If PlanStartTime.ToShortDateString <> Now.ToShortDateString Then
                    status = ObsadaStatus.pracujeodwczoraj
                End If
            End If
            If status = -1 Then
                If PlanStartTime > Now Then
                    status = ObsadaStatus.rozpocznieprace
                End If
            End If
            If status = -1 Then
                If ExeStartTime = #1/1/0001 12:00:00 AM# Then
                    If ck.Checked = False And PlanStartTime <= Now Then
                        status = ObsadaStatus.powinienpracowac
                    End If

                Else
                    If ck.Checked = False And ExeStartTime <= Now Then
                        status = ObsadaStatus.powinienpracowac
                    End If
                End If
            End If



            If status = -1 Then
                If ck.Checked = True And ExeStartTime < Now And ExeStopTime >= Now Then
                    status = ObsadaStatus.pracujeobecnie
                End If
            End If
            'If status = -1 Then
            If ck.Checked = True And ExeStopTime < Now Then
                status = ObsadaStatus.zakonczylprace
            End If
            'End If


            If status = -1 Then
                Debug.Print("a")
            End If








            Dim im As HtmlImage = TryCast(e.Row.FindControl("im"), HtmlImage)

            Select Case status


                Case ObsadaStatus.nieobecny
                    If Not IsNothing(zp) Then
                        e.Row.ToolTip = "Pracownik nieobecny - " & zp.nazwa & "."
                        e.Row.Style.Add("background-color", "tomato")
                        im.Src = "~/images/icons/appbar.timer.record.png"
                    Else
                        e.Row.ToolTip = "Pracownik nieobecny - " & "Przyczyna nieznana" & "."
                        e.Row.Style.Add("background-color", "tomato")
                        im.Src = "~/images/icons/appbar.timer.record.png"
                    End If


                Case ObsadaStatus.pracujeobecnie
                    e.Row.ToolTip = "Obecnie pracuje."
                    e.Row.Style.Add("background-color", "lightgreen")
                    im.Src = "~/images/icons/appbar.timer.play.png"

                Case ObsadaStatus.pracujeodwczoraj
                    e.Row.ToolTip = "Pracownik rozpoczął pracę w dniu wczorajszym."
                    e.Row.Style.Add("background-color", "powderblue")
                    im.Src = "~/images/icons/appbar.timer.rewind.png"

                Case ObsadaStatus.rozpocznieprace
                    e.Row.ToolTip = "Pracownik rozpocznie prace."
                    e.Row.Style.Add("background-color", "darkseagreen")
                    im.Src = "~/images/icons/appbar.timer.resume.png"

                Case ObsadaStatus.zakonczylprace
                    e.Row.ToolTip = "Pracownik zakończył pracę."
                    e.Row.Style.Add("background-color", "ivory")
                    im.Src = "~/images/icons/appbar.timer.check.png"

                Case ObsadaStatus.powinienpracowac
                    e.Row.ToolTip = "Pracownik powinien rozpocząć pracę."
                    e.Row.Style.Add("background-color", "orange")
                    im.Src = "~/images/icons/appbar.timer.alert.png"

            End Select

            Dim wt As Label = TryCast(e.Row.FindControl("lbwt"), Label)

            Dim ti As Integer = DateDiff(DateInterval.Minute, ExeStartTime, ExeStopTime)
            Dim ts As TimeSpan = TimeSpan.FromMinutes(ti)

            Dim hh As String = ts.Hours
            Dim mm As String = ts.Minutes
            If hh < 10 Then hh = "0" & ts.Hours
            If mm < 10 Then mm = "0" & ts.Minutes
            wt.Text = hh & ":" & mm

        End If
    End Sub
    Public Enum ObsadaStatus
        nieobecny = 0
        pracujeodwczoraj = 1
        pracujeobecnie = 2
        rozpocznieprace = 3
        zakonczylprace = 4
        powinienpracowac = 5
    End Enum
    Protected Sub txstart_TextChanged(sender As Object, e As EventArgs)

        Dim tx As TextBox = sender


        Dim Exe_StartTime As String = tx.Text
        Dim h As HarmonogramType = HarmonogramType.Load(tx.ValidationGroup)

        If IsDate(tx.Text) Then

            Dim d As DateTime = tx.Text
            h.ChangeWorkStart(d)

        End If



        Bind()

    End Sub

    Protected Sub txstop_TextChanged(sender As Object, e As EventArgs)


        Dim tx As TextBox = sender


        Dim Exe_EndWorkTime As String = tx.Text
        Dim h As HarmonogramType = HarmonogramType.Load(tx.ValidationGroup)


        If IsDate(tx.Text) Then

            Dim d As DateTime = tx.Text
            h.Exe_EndWorkTime = d

            h.ChangeWorkEnd(d)

        End If

        Bind()


    End Sub

    Protected Sub ddlZP_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim rowid As String = sender.ValidationGroup
        Dim row As GridViewRow = dg1.Rows(rowid)
        Dim id As String = TryCast(row.FindControl("lbid"), Label).Text


        Dim h As HarmonogramType = HarmonogramType.Load(id)

        h.ChangeWorkType(sender.selectedvalue)

        Bind()




    End Sub

    Protected Sub ckPresent_CheckedChanged(sender As Object, e As EventArgs)

        Dim ck As CheckBox = sender
        Dim id As String = ck.ValidationGroup

        Dim h As HarmonogramType = HarmonogramType.Load(id)
        h.SetPresent(ck.Checked)









        Bind()

    End Sub
    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Bind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)


        HarmonogramType.Scan("IQ0E6", Now, s.Zone.Id, s.OrganizationUnit.Id)

        Bind()

    End Sub

    Protected Sub txTarget_TextChanged(sender As Object, e As EventArgs)

    End Sub

    <System.Web.Script.Services.ScriptMethod(),
System.Web.Services.WebMethod()>
    Public Shared Function auto(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        Dim m As mySQLcore = mySQLcore.DB_Main

        Dim dt As DataTable = m.FillDatatable("select fullname from workers where fullname like '%" & prefixText & "%';")

        Dim l As New List(Of String)
        For i = 0 To dt.Rows.Count - 1
            l.Add(dt.Rows(i)("fullname"))
        Next


        Return l

    End Function

    Protected Sub btnAdd_Click(sender As Object, e As ImageClickEventArgs)
        Dim w As WorkerType = WorkerType.LoadByName(txTarget.Text)

        If Not IsNothing(w) Then


            For Each r As GridViewRow In dg1.Rows
                Dim wm As String = TryCast(r.FindControl("lbname"), Label).Text
                If wm.ToLower = w.fullname.ToLower Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType, "al", "alert('Pracownik jest na liście');", True)

                    Exit Sub
                End If
            Next


            Dim shift As shiftType = shiftType.Load(s.Zone.Id, Now.ToShortTimeString)




            Dim h As New HarmonogramType
            h.Plan_Data = Now
            h.Plan_StartTime = Now.ToShortDateString & " " & shift.starttime
            h.Plan_EndWorkTime = Now.ToShortDateString & " " & shift.endtime
            h.Plan_WorkTime = shift.LenghtMinutes
            h.WorkerCode = w.Code

            h.Exe_Data = h.Plan_Data
            h.Exe_StartTime = h.Plan_StartTime
            h.Exe_EndWorkTime = h.Plan_EndWorkTime
            h.Exe_WorkTime = h.Plan_WorkTime
            h.Exe_WorkTypeID = h.Plan_WorkTypeID


            h.zoneid = s.Zone.Id
            h.Plan_WorkTypeID = shift.idrg
            h.WorkerName = w.fullname
            h.Present = 1
            h.orgid = s.OrganizationUnit.Id
            h.Save()
            Bind()


            ViewState("worker") = Nothing

        Else

            Dim n As String = ""
            Dim i As String = ""

            Dim sn As String() = txTarget.Text.Split(" ")
            If sn.Length > 1 Then
                n = sn(0)
                i = sn(1)
            End If


            ScriptManager.RegisterStartupScript(Me, Me.GetType, "md", "showModal('../forms/frmWorkerDetails.aspx?id=0&n=" & n & "&i=" & i & "')", True)
        End If



    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs)

        For Each row As GridViewRow In dg1.Rows


            Dim id As String = TryCast(row.FindControl("lbid"), Label).Text

                Dim h As HarmonogramType = HarmonogramType.Load(id)


            Dim ck As CheckBox = TryCast(row.FindControl("ckPresent"), CheckBox)
            Dim pr As Integer = 0
            If ck.Checked = True Then pr = 1

            If h.Present <> pr Then
                h.SetPresent(ck.Checked)
            End If

            Dim ddl As DropDownList = TryCast(row.FindControl("ddlZP"), DropDownList)
            If ddl.SelectedValue <> h.Exe_WorkTypeID And h.Exe_WorkTypeID <> 0 Then h.ChangeWorkType(ddl.SelectedValue)

            Dim txstart As TextBox = TryCast(row.FindControl("txstart"), TextBox)
                Dim Exe_StartTime As String = txstart.Text

                If IsDate(txstart.Text) Then

                Dim d As DateTime = txstart.Text

                If h.Exe_StartTime <> d Then
                    If d <> #1/1/0001 12:00:00 AM# Then
                        h.ChangeWorkStart(d)
                    End If
                End If

                End If

                Dim txend As TextBox = TryCast(row.FindControl("txstop"), TextBox)
                If IsDate(txend.Text) Then

                    Dim d As DateTime = txend.Text
                    h.Exe_EndWorkTime = d

                If h.Exe_EndWorkTime <> d Then
                    If d <> #1/1/0001 12:00:00 AM# Then
                        h.ChangeWorkEnd(d)
                    End If
                End If

            End If


                h.Save()


        Next

        Bind()
    End Sub
End Class
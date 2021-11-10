Imports EngineSiO

Public Class frmStartWork
    Inherits System.Web.UI.Page

    Dim operationID As Integer
    Dim OP As OperationType
    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")
        Dim idop = Request.QueryString("id")

        OP = OperationType.Load(idop)
        If IsNothing(OP) Then Exit Sub

        If Not IsPostBack Then

            For Each p In OP.Parameters
                If p.Key = "Pracownicy zakres" Then
                    Select Case p.Value
                        Case WorkerLevels.Jednostka_Organizacyjna
                            ddlWorkers.DataSource = WorkerType.Load(p.Value, s.OrganizationUnit.Id, True)
                        Case WorkerLevels.Komórka_Organizacyjna
                            ddlWorkers.DataSource = WorkerType.Load(p.Value, s.Zone.Id, True)
                        Case WorkerLevels.Organizacja
                            ddlWorkers.DataSource = WorkerType.Load(p.Value, 0, True)
                    End Select


                    ddlWorkers.DataTextField = "fullname"
                    ddlWorkers.DataValueField = "id"
                    ddlWorkers.DataBind()


                End If

                If p.Key = "Pole Uwagi" Then
                    txUwagi.Visible = p.Value

                End If
            Next

            txdate.Text = Now.ToShortDateString
            txtime.Text = Now.ToShortTimeString

        End If

    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs)

        'Dim idop = Request.QueryString("id")
        'OP = OperationType.Load(idop)

        'Dim wDate As DateTime = txdate.Text & " " & txtime.Text

        'Dim a As Integer = ddlWorkers.SelectedValue
        'Dim worker As WorkerType = WorkerType.Load(a)

        'Dim hl As List(Of HarmonogramType) = HarmonogramType.Load(worker.Code, wDate.ToShortDateString)


        'For Each h In hl
        '    h.Exe_Data = wDate.ToShortDateString
        '    h.Exe_StartTime = h.Plan_Data & " " & TimeSpan.Parse(wDate.ToShortTimeString).ToString
        '    h.Exe_WorkTypeID = h.Plan_WorkTypeID
        '    h.Save()

        'Next


        'If hl.Count = 0 Then
        '    'Pracownik nie był w planie!
        '    Dim h As New HarmonogramType

        '    h.Plan_Data = wDate.ToShortDateString
        '    h.Plan_StartTime = h.Plan_Data & " " & TimeSpan.Parse("00:00").ToString
        '    h.Plan_WorkTime = TimeSpan.Parse("00:00").TotalMinutes
        '    h.WorkerCode = worker.Code
        '    h.WorkerName = worker.fullname
        '    h.orgid = s.OrganizationUnit.Id
        '    h.zoneid = s.Zone.Id


        '    h.Exe_Data = wDate.ToShortDateString
        '    h.Exe_StartTime = h.Plan_Data & " " & TimeSpan.Parse(wDate.ToShortTimeString).ToString
        '    h.Exe_WorkTypeID = h.Plan_WorkTypeID
        '    h.Save()


        'End If

        'For Each rec In OP.Notifies.RecipientsIDList

        '    Dim n As New NotifyType("Pracownik " & worker.fullname & " rozpoczął pracę </br> w strefie " & s.Zone.Name & " o: " & wDate, rec)


        'Next


        ''dodaj informacje


        'Response.Redirect("~/forms/frmStartWork.aspx?id=" & Request.QueryString("id"))
    End Sub




End Class
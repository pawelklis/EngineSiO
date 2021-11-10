Imports EngineSiO
Imports EngineSiO.MongoDBQuery

Public Class frmWorkerEntry
    Inherits System.Web.UI.Page

    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")

        If Not IsPostBack Then
            bindWorkers()
        End If

    End Sub

    Sub bindWorkers()

        Dim dt As DataTable = MongoDBReportsCore.Harmonogram_Zadania(Now, s.Zone.Id, True)

        ddlworker.DataSource = dt
        ddlworker.DataTextField = "workername"
        ddlworker.DataValueField = "workername"
        ddlworker.DataBind()

        ddlreason.DataSource = ReasonType.Load()
        ddlreason.DataTextField = "name"
        ddlreason.DataValueField = "id"
        ddlreason.DataBind()

        txstart.Text = Now.ToShortDateString & "T" & Now.ToShortTimeString
        txstop.Text = Now.ToShortDateString & "T" & Now.ToShortTimeString



    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        Dim we As New WorkerEntryType

        Dim w As WorkerType = WorkerType.LoadByName(ddlworker.SelectedValue)

        we.idzone = s.Zone.Id
        we.Reason = ReasonType.Load(CInt(ddlreason.SelectedValue))
        we.starttime = txstart.Text
        we.endtime = txstop.Text
        we.Descr = txdescr.Text

        we.Save()

        bindWorkers()


    End Sub


End Class
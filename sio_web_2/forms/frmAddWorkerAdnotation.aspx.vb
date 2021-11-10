Imports EngineSiO

Public Class frmAddWorkerAdnotation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim id As String = Request.QueryString("id")

        If Not IsPostBack Then
            Dim h As HarmonogramType = HarmonogramType.Load(id)
            tx.Text = h.Descr
            wn.Text = h.WorkerName


        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        Dim s As sessionClass
        s = Session("sesja")

        Dim id As String = Request.QueryString("id")
        Dim h As HarmonogramType = HarmonogramType.Load(id)

        If h.Descr <> tx.Text Then
            h.Descr = tx.Text & " " & Now & " " & s.User.Name & " " & s.User.Surname
        End If


        h.Save()
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "cl", "Close();", True)

    End Sub


End Class
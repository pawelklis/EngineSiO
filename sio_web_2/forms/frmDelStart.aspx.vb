Imports EngineSiO
Imports EngineSiO.MongoDBQuery

Public Class frmDelStart
    Inherits System.Web.UI.Page

    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")
        If Not IsPostBack Then
            txStartTime.Text = Now.ToShortDateString & "T" & Now.ToShortTimeString
            BindZones()
            BindWorkers()

        End If
    End Sub
    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
        BindWorkers()
    End Sub

    Sub BindZones()
        Dim l As List(Of ZoneType) = ZoneType.Load(s.OrganizationUnit.Id)

        With ddlStrefa
            .DataSource = l
            .DataTextField = "name"
            .DataValueField = "id"
            .DataBind()
        End With

    End Sub
    Sub BindWorkers()
        Dim dt As DataTable = MongoDBReportsCore.Harmonogram_Zadania(Now, s.Zone.Id, True)
        Dim l As List(Of delType) = delType.Load(s.Zone.Id)
        dg1.DataSource = l
        dg1.DataBind()




        ckWorkers.Items.Clear()

        For i = 0 To dt.Rows.Count - 1
            Dim ok As Boolean = True
            For Each o In l
                If o.WorkerName.ToLower = dt.Rows(i)("workername").ToString.ToLower Then
                    ok = False
                    Exit For
                End If
            Next
            If ok = True Then
                Dim item As New ListItem
                item.Text = dt.Rows(i)("workername")
                item.Value = dt.Rows(i)("workercode")
                item.Selected = False

                ckWorkers.Items.Add(item)
            End If
        Next



    End Sub
    Protected Sub btnStartDel_Click(sender As Object, e As EventArgs)
        Dim d As Date = txStartTime.Text

        For Each i As ListItem In ckWorkers.Items
            If i.Selected = True Then
                Dim w As WorkerType = WorkerType.Load(i.Value)
                Dim z As ZoneType = ZoneType.LoadID(ddlStrefa.SelectedValue)

                delType.StartDel(w, s.Zone, z, d)
            End If
        Next

        BindWorkers()




    End Sub

    Protected Sub dg1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim row As GridViewRow = CType(((CType(e.CommandSource, Control)).NamingContainer), GridViewRow)
        Dim id As String = e.CommandArgument

        Dim time As Date = TryCast(row.FindControl("delstop"), TextBox).Text

        Dim del As delType = delType.Load(id)
        del.StopDel(time)


        BindWorkers()




    End Sub

    Protected Sub dg1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim time As TextBox = TryCast(e.Row.FindControl("delstop"), TextBox)
            time.Text = Now.ToShortDateString & "T" & Now.ToShortTimeString
        End If


    End Sub
End Class
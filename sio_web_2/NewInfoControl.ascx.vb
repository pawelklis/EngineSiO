Imports EngineSiO


Public Class NewInfoControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCategory()
        End If

    End Sub
    Sub BindCategory()
        Me.frm1.Src = ""
        ddlCategory.DataSource = OperationCategoryType.Load()
        ddlCategory.DataTextField = "name"
        ddlCategory.DataValueField = "id"
        ddlCategory.DataBind()


        ddlCategory.Items.Insert(0, "Wybierz")

    End Sub
    Sub BindOperation()

        Me.frm1.Src = ""
        Dim s As sessionClass = Session("sesja")
        ddlOperation.DataSource = Nothing
        ddlOperation.DataBind()
        If ddlCategory.SelectedValue = "Wybierz" Then
            ddlOperation.DataSource = Nothing
            ddlOperation.DataBind()
            Exit Sub
        End If

        ddlOperation.DataSource = OperationType.Load(ddlCategory.SelectedValue, s.Zone.Id)
        ddlOperation.DataTextField = "name"
        ddlOperation.DataValueField = "id"
        ddlOperation.DataBind()

        ddlOperation.Items.Insert(0, "Wybierz")

    End Sub
    Protected Sub ddlCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindOperation()

    End Sub

    Protected Sub ddlOperation_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.frm1.Src = ""

        If ddlOperation.SelectedValue = "Wybierz" Then
            Exit Sub

        End If

        Dim o As OperationType = OperationType.Load(ddlOperation.SelectedValue)
        If o.formatkaid = Formatka.PobierzSkaner Then
            Me.frm1.Src = "~/forms/frmgetscanner.aspx?id=" & ddlOperation.SelectedValue
        End If

        If o.formatkaid = Formatka.StartPracy Then
            Me.frm1.Src = "~/forms/frmStartWork.aspx?id=" & ddlOperation.SelectedValue
        End If

        If o.formatkaid = Formatka.WyjściePracownika Then
            Me.frm1.Src = "~/forms/frmWorkerEntry.aspx?id=" & ddlOperation.SelectedValue
        End If

    End Sub
End Class
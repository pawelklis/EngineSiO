Imports EngineSiO

Public Class swfHarmonogramImport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim s As sessionClass = Session("sesja")

        If Not IsPostBack Then
            ddlzone.DataSource = ZoneType.Load(s.OrganizationUnit.Id)
            ddlzone.DataTextField = "name"
            ddlzone.DataValueField = "id"
            ddlzone.DataBind()



        End If



    End Sub

    Protected Sub btnHarmImport_Click(sender As Object, e As EventArgs)
        Dim s As sessionClass = Session("sesja")


        If FileUpload1.HasFile Then
            Dim pat As String = System.Web.HttpContext.Current.Server.MapPath(FileUpload1.FileName)
            FileUpload1.SaveAs(pat)
            xlsWorker.SavetoCSV(pat, "^")
            Dim dt As DataTable = ConvertCore.csvToDatatable(pat.Replace(".xlsx", ".csv"), "^", 1)



            HarmonogramType.Import(dt, ddlzone.SelectedValue, s.OrganizationUnit.Id)

            Try
                Kill(pat)
                Kill(pat.Replace(".csv", ".xlsx"))
            Catch ex As Exception

            End Try
        End If



    End Sub



End Class
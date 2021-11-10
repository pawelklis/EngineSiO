Public Class wfImports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnImportHarm_Click(sender As Object, e As EventArgs)
        Me.ifr1.Src = "~/konf/swfHarmonogramImport.aspx"
    End Sub
End Class
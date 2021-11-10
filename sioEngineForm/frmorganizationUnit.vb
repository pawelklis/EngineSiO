Imports enginesio


Public Class frmorganizationUnit
    Private Sub organizationUnit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bind()
    End Sub

    Sub Bind()
        Dim l As New List(Of organizationunittype)
        l = OrganizationUnitType.Load(True)
        DataGridView1.DataSource = l

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim o As New OrganizationUnitType
        Dim f As New frmEdit
        f.o = o
        f.T = GetType(OrganizationUnitType)
        If f.ShowDialog() = DialogResult.OK Then
            o = f.o
            o.Save()
            Bind()
        End If


    End Sub
End Class

Public Class OperationCategoryType

    Public Property Id As Integer
    Public Property Name As String

    Public Property Active As Integer

    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        If Me.Id = 0 Then
            m.Insert("opercat", "id", Me)
        Else
            m.Update("opercat", "id", Me)
        End If

    End Sub
    Public Shared Function Load(id As Integer) As OperationCategoryType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As OperationCategoryType = m.GetSingleObject(Of OperationCategoryType)("select * from opercat where id =" & id & "")
        Return oo
    End Function
    Public Shared Function Load() As List(Of OperationCategoryType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As List(Of OperationCategoryType) = m.GetObject(Of OperationCategoryType)("select * from opercat where active =1")
        Return oo
    End Function


End Class

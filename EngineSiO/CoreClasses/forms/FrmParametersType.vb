Public Class FrmParametersType


    Public Property Id As Integer
    Public Property Key As String
    Public Property Value As String
    Public Property ValueType As String
    Public Property OperationID As Integer




    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        If Me.Id = 0 Then
            m.Insert("frmparameters", "id", Me)
        Else
            m.Update("frmparameters", "id", Me)
        End If

    End Sub
    Public Shared Function Load(id As Integer) As FrmParametersType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As FrmParametersType = m.GetSingleObject(Of FrmParametersType)("select * from frmparameters where id =" & id & "")
        Return oo
    End Function
    Public Shared Function Load() As List(Of FrmParametersType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As List(Of FrmParametersType) = m.GetObject(Of FrmParametersType)("select * from frmparameters where active =1")
        Return oo
    End Function

    Public Shared Function Load(OperationID As String) As List(Of FrmParametersType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As List(Of FrmParametersType) = m.GetObject(Of FrmParametersType)("select * from frmparameters where operationid =" & OperationID)
        Return oo
    End Function

End Class

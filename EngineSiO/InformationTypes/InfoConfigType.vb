

Public Class InfoConfigType


    Public Property Id As Integer
    Public Property Name As String
    Public Property OrgId As Integer
    Public Property ZoneId As Integer
    Public Property Active As Integer
    Public Property Priority As Priorities
    Public Property Msg As InfoMessage



    Public Sub save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        If Me.Id = 0 Then
            m.Insert("infoconfig", "id", Me)
        Else
            m.Update("infoconfig", "id", Me)
        End If
    End Sub

    Public Shared Function Load(id As Integer) As InfoConfigType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As InfoConfigType = m.GetSingleObject(Of InfoConfigType)("select * from infoconfig where id=" & id)

        Return o
    End Function
    Public Shared Function Load() As List(Of InfoConfigType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As List(Of InfoConfigType) = m.GetObject(Of InfoConfigType)("select * from infoconfig where active=1")

        Return o
    End Function
    Public Shared Function Load(orgid As Integer, zoneid As Integer) As List(Of InfoConfigType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As List(Of InfoConfigType) = m.GetObject(Of InfoConfigType)("select * from infoconfig where orgid=" & orgid & " and zoneid=" & zoneid)

        Return o
    End Function
End Class

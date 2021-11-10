
Imports MongoDB.Bson

Public Class delType

    Public Property _id As String
    Public Property idWorker As String
    Public Property WorkerName As String
    Public Property delStart As DateTime
    Public Property delStop As DateTime
    Public Property idzonefrom As Integer
    Public Property idzoneTo As Integer
    Public Property ZoneFrom As String
    Public Property ZoneTo As String
    Public Property enddel As Integer

    Public Shared Sub StartDel(W As WorkerType, zoneFrom As ZoneType, zoneTo As ZoneType, time As DateTime)
        Dim del As New delType
        del.idWorker = W.id
        del.WorkerName = W.fullname
        del.delStart = time
        del.idzonefrom = zoneFrom.Id
        del.ZoneFrom = zoneFrom.Name
        del.ZoneTo = zoneTo.Name
        del.idzoneTo = zoneTo.Id
        del.Save()
    End Sub
    Public Shared Sub StartDel(Workername As String, idworker As Integer, zoneFrom As String, zoneTo As String, idZonefrom As Integer, idzoneto As Integer, time As DateTime)
        Dim del As New delType
        del.idWorker = idworker
        del.WorkerName = Workername
        del.delStart = time
        del.idzonefrom = idZonefrom
        del.ZoneFrom = zoneFrom
        del.ZoneTo = zoneTo
        del.idzoneTo = idzoneto
        del.Save()
    End Sub
    Public Sub StopDel(time As DateTime)
        Me.delStop = time
        Me.enddel = 1
        Me.Save()
    End Sub

    Public Sub Save()
        Dim m As New mongoDBCore()
        If String.IsNullOrEmpty(Me._id) Then Me._id = Guid.NewGuid.ToString
        m.Update(Of NotifyType)("del", Me._id, Me)
    End Sub

    Public Shared Function Load(id) As delType

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("_id", id)


        Load = m.GetSingleObject(Of delType)("del", filters)

    End Function

    Public Shared Function Load(idzonefrom As Integer) As List(Of delType)

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)

        filters.Add("delStop", "0001-01-01T00:00:00")
        filters.Add("idzonefrom", New BsonInt64(idzonefrom))


        Load = m.GetObjectList(Of delType)("del", filters)



        filters = New Dictionary(Of String, Object)
        filters.Add("delStop", "0001-01-01T00:00:00")
        filters.Add("idzoneTo", New BsonInt64(idzonefrom))

        Dim ld As List(Of delType) = m.GetObjectList(Of delType)("del", filters)
        If Not IsNothing(ld) Then
            For Each o In ld
                Load.Add(o)
            Next
        End If




    End Function

End Class

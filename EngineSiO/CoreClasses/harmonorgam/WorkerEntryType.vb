

Imports MongoDB.Bson

Public Class WorkerEntryType

    Public Property _id As String
    Public Property idworker As Integer
    Public Property starttime As Date
    Public Property endtime As Date
    Public Property timelenght As Integer
    Public Property Reason As ReasonType
    Public Property idzone As Integer
    Public Property Descr As String

    Sub New()
        Me._id = Guid.NewGuid.ToString
    End Sub

    Public Sub Save()

        Me.timelenght = DateDiff(DateInterval.Minute, Me.starttime, Me.endtime)
        If Me.timelenght < 0 Then Me.timelenght = -Me.timelenght

        Dim m As New mongoDBCore
        m.Update(Of HarmonogramType)("workerentry", Me._id, Me)

    End Sub

    Public Shared Function LoadID(id As Integer) As WorkerEntryType
        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("_id", id)

        LoadID = m.GetSingleObject(Of WorkerEntryType)("workerentry", filters)
    End Function

    Public Shared Function Load(idWorker As Integer) As List(Of WorkerEntryType)
        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("idworker", idWorker)

        Load = m.GetObjectList(Of WorkerEntryType)("workerentry", filters)
    End Function

    Public Shared Function Load(data As Date, Optional zoneid As Integer = 0) As List(Of WorkerEntryType)
        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("starttime", New BsonRegularExpression("^" & Year(data) & "-" & Month(data).ToString("00") & ".*$", "i"))

        Load = m.GetObjectList(Of WorkerEntryType)("workerentry", filters)


    End Function



End Class

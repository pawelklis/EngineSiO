
Public Class NotifyType

    Public Property _id As String
    Public Property CreateTime As DateTime
    Public Property Content As String
    Public Property userId As String
    Public Property Readed As String


    Sub New()

    End Sub
    Public Sub New(Content As String, userid As Integer)
        Me.CreateTime = Now
        Me.Content = Content
        Me.userId = userid
        Me.Readed = "false"
        Me._id = Guid.NewGuid.ToString
        Me.Save()

    End Sub
    Public Sub Save()
        Dim m As New mongoDBCore()
        m.Update(Of NotifyType)("notify", Me._id, Me)
    End Sub
    Public Shared Function Load(userID As Integer, readed As Boolean) As List(Of NotifyType)
        Load = New List(Of NotifyType)

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("userId", userID)
        filters.Add("Readed", "false")

        Load = m.GetObjectList(Of NotifyType)("notify", filters)

    End Function
End Class

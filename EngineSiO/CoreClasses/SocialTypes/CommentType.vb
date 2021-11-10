
Public Class CommentType

    Public Property _Id As String
    Public Property CreateTime As DateTime
    Public Property OrganizationId As Integer
    Public Property ZoneID As Integer
    Public Property UserId As Integer
    Public Property Content As ContentType

    Public Property Comments As List(Of CommentType)
    Public Property Reactions As List(Of ReactionType)

    Sub New()
        Me._Id = Guid.NewGuid.ToString

    End Sub

End Class

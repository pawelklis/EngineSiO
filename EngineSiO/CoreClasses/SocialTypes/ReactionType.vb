
Public Class ReactionType


    Public Property _Id As String
    Public Property CreateTime As DateTime
    Public Property UserId As Integer
    Public Property ReactionType As ReactionEnum


    Sub New()
        Me._Id = Guid.NewGuid.ToString

    End Sub


End Class

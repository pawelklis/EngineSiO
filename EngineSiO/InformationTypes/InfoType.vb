Public Class InfoType
    Public Property _id As String


    Public Property OrganizationUnit As OrganizationUnitType
    Public Property User As UserType
    Public Property Zone As ZoneType
    Public Property Active As Integer
    Public Property Reactions As List(Of ReactionType)
    Public Property Comments As List(Of CommentType)
    Public Property Content As List(Of ContentType)
    Public Property CreateTime As DateTime


    Public Sub save()
        Dim m As mySQLcore = mySQLcore.DB_Main




        If Me._id = 0 Then
            m.Insert("infoconfig", "id", Me)
        Else
            m.Update("infoconfig", "id", Me)
        End If


    End Sub

    Public Shared Function Load(id As String) As InfoType

    End Function
    Public Shared Function Load() As List(Of InfoType)

    End Function
End Class

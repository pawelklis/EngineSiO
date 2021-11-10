

Public Class ReasonType

    Public Property Id As Integer
    Public Property Name As String
    Public Property ReasonType As Integer

    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        If Me.Id = 0 Then
            m.Insert("reasons", "id", Me)
        Else
            m.Update("reasons", "id", Me)
        End If


    End Sub

    Public Shared Function Load() As List(Of ReasonType)
        Dim m As mySQLcore = mySQLcore.DB_Main

        Load = m.GetObject(Of ReasonType)("select * from reasons;")


    End Function
    Public Shared Function Load(id As Integer) As ReasonType
        Dim m As mySQLcore = mySQLcore.DB_Main

        Load = m.GetSingleObject(Of ReasonType)("select * from reasons where id=" & id)


    End Function
    Public Shared Function Load(name As String) As ReasonType
        Dim m As mySQLcore = mySQLcore.DB_Main

        Load = m.GetSingleObject(Of ReasonType)("select * from reasons where name='" & name & "';")


    End Function

    Public Enum ReasonEnum
        Prywatne = 0
        Służbowe = 1
    End Enum

End Class

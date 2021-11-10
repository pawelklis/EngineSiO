Public Class terminytype

    Public Property id As Integer
    Public Property kodp As String
    Public Property typp As String
    Public Property termin As String


    Public Shared Function Load() As List(Of terminytype)
        Dim m As mySQLcore = mySQLcore.DB_Main

        Load = m.GetObject(Of terminytype)("select * from terminydor")

    End Function

End Class

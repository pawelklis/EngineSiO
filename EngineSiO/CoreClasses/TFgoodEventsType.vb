Public Class TFgoodEventsType

    Public Property prefixregion As String
    Public Property eventName As String
    Public Property wejsciewyjscieio As tfgio

    Public Property nazwafazy As String



    Public Shared Function GetList()
        Dim m As mySQLcore = mySQLcore.DB_Main

        GetList = m.GetObject(Of TFgoodEventsType)("Select * from tfeventsdict;")

    End Function
    Public Enum tfgio
        wejscie = 0
        wyjscie = 1
    End Enum
    Public Shared Function Check(prefixregion As String, eventname As String, l As List(Of TFgoodEventsType), io As tfgio, nazwafazy As String) As Integer
        If IsNothing(prefixregion) Then prefixregion = ""
        If IsNothing(eventname) Then eventname = ""
        For Each o In l
            If prefixregion.ToLower.StartsWith(o.prefixregion.ToLower) Then
                If o.eventName.ToLower = eventname.ToLower Then
                    If o.nazwafazy.ToLower = nazwafazy.ToLower Then
                        If o.wejsciewyjscieio = io Then
                            Return 1
                        End If
                    End If
                End If
            End If
        Next
        Return 0
    End Function

End Class

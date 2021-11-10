Public Class shiftType

    Public Property id As Integer
    Public Property idzone As Integer
    Public Property starttime As String
    Public Property endtime As String
    Public Property idrg As Integer


    Public Function LenghtMinutes() As Integer

        Dim ds As Date = "0001-01-01 " & Me.starttime
        Dim de As Date = "0001-01-01 " & Me.endtime

        Dim w As Integer = DateDiff(DateInterval.Minute, ds, de)
        If w < 0 Then w = -w
        Return w
    End Function

    Public Shared Function Load(idzone As Integer, time As String) As shiftType

        Dim m As mySQLcore = mySQLcore.DB_Main

        Load = m.GetSingleObject(Of shiftType)("select * from shifts where idzone =" & idzone & " and starttime < '" & time & "' and endtime > '" & time & "'; ")



        If IsNothing(Load) Then
            Load = New shiftType
            Load.starttime = "08:00"
            Load.endtime = "16:00"
            Load.idrg = RodzajGodzinType.Load("D").idrodzajgodzin
        End If

    End Function



End Class

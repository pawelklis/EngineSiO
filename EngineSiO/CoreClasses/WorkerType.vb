
Public Class WorkerType

    Public Property id As Integer
    Public Property Name As String
    Public Property Surname As String
    Public Property ZoneId As Integer
    Public Property OrgID As Integer
    Public Property Title As String
    Public Property Active As Integer
    Public Property fullname As String
    Public Property Code As String
    Public Property LastTime As DateTime

    Public Property Login As String

    Public Sub save()
        Me.LastTime = Now
        Dim m As mySQLcore = mySQLcore.DB_Main
        Me.fullname = Me.Surname & " " & Me.Name
        If Me.id = 0 Then

            Try
                Dim l As New List(Of A_Directory.UserInfoProps)
                l.Add(A_Directory.UserInfoProps.givenName)
                l.Add(A_Directory.UserInfoProps.title)
                l.Add(A_Directory.UserInfoProps.sn)
                l.Add(A_Directory.UserInfoProps.employeeNumber)
                Dim lg As String = ConvertCore.ZnakiPL(Me.fullname.Replace(" ", ""))

                Dim uinfo As List(Of String) = A_Directory.GetuserAdInformation(lg, l)
                If Not IsNothing(uinfo) Then
                    If String.IsNullOrEmpty(Me.Name) Then Me.Name = uinfo(0)
                    If String.IsNullOrEmpty(Me.Surname) Then Me.Surname = uinfo(2)
                    If String.IsNullOrEmpty(Me.Title) Then Me.Title = uinfo(1)
                    If String.IsNullOrEmpty(Me.Code) Then Me.Code = uinfo(3)
                End If


            Catch ex As Exception

            End Try

            If String.IsNullOrEmpty(Me.Code) Then
                Me.Code = ConvertCore.GenereteWorkerCode
            End If

            m.Insert("workers", "id", Me)
        Else
            m.Update("workers", "id", Me)
        End If
    End Sub
    Public Shared Function Load(code As String) As WorkerType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As WorkerType = m.GetSingleObject(Of WorkerType)("select * from workers where code='" & code & "';")
        If Not IsNothing(o) Then
            o.LastTime = Now
            o.save()
        End If


        Return o
    End Function

    Public Shared Function LoadByName(fullname As String) As WorkerType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As WorkerType = m.GetSingleObject(Of WorkerType)("select * from workers where fullname='" & fullname & "';")
        If Not IsNothing(o) Then
            o.LastTime = Now
            o.save()
        End If


        Return o
    End Function
    Public Shared Function Load(id As Integer) As WorkerType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As WorkerType = m.GetSingleObject(Of WorkerType)("select * from workers where id=" & id)
        o.LastTime = Now
        o.save()

        Return o
    End Function
    Public Shared Function Load(level As WorkerLevels, id As Integer, active As Boolean) As List(Of WorkerType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim l As List(Of WorkerType)
        If active = True Then
            Select Case level
                Case WorkerLevels.Jednostka_Organizacyjna
                    l = m.GetObject(Of WorkerType)("select * from workers where orgid=" & id & " and active =1")
                    m.ExecuteNonQuery("update workers set lasttime='" & Now & "' where orgid=" & id & " and active =1")
                Case WorkerLevels.Komórka_Organizacyjna
                    l = m.GetObject(Of WorkerType)("select * from workers where zoneid=" & id & " and active =1")
                    m.ExecuteNonQuery("update workers set lasttime='" & Now & "' where zoneid=" & id & " and active =1")
                Case WorkerLevels.Organizacja
                    l = m.GetObject(Of WorkerType)("select * from workers where   active =1")
                    m.ExecuteNonQuery("update workers set lasttime='" & Now & "' where   active =1")
            End Select
        Else
            Select Case level
                Case WorkerLevels.Jednostka_Organizacyjna
                    l = m.GetObject(Of WorkerType)("select * from workers where orgid=" & id & " ")
                    m.ExecuteNonQuery("update workers set lasttime='" & Now & "'  where orgid=" & id & " ")
                Case WorkerLevels.Komórka_Organizacyjna
                    l = m.GetObject(Of WorkerType)("select * from workers where zoneid=" & id & " ")
                    m.ExecuteNonQuery("update workers set lasttime='" & Now & "' where zoneid=" & id & " ")
                Case WorkerLevels.Organizacja
                    l = m.GetObject(Of WorkerType)("select * from workers ")
                    m.ExecuteNonQuery("update workers set lasttime='" & Now & "'")
            End Select
        End If



        Return l


    End Function


End Class

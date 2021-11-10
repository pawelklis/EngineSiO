

Imports Newtonsoft.Json

Public Class ZoneType

    Public Property Id As Integer
    Public Property Name As String
    Public Property Code As String
    Public Property AdditionalInfoField As String
    Public AdditionalInfo As Dictionary(Of String, String)
    Public Property OrganizationUnitId As Integer
    Public Property LastTime As DateTime
    Public Property active As Integer




    Public Sub New()
        Me.AdditionalInfo = New Dictionary(Of String, String)

    End Sub

    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        Me.LastTime = Now

        Me.AdditionalInfoField = JsonConvert.SerializeObject(Me.AdditionalInfo)


        If Me.Id = 0 Then
            If m.GetCount("select count(*) from zones where name='" & Me.Name & "';") > 0 Then
                Exit Sub
            End If
            m.Insert("zones", "id", Me)
        Else
            m.Update("zones", "id", Me)
        End If
    End Sub

    Public Shared Function Load(name As String) As ZoneType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As ZoneType = m.GetSingleObject(Of ZoneType)("select * from zones where name='" & name & "';")

        o.AdditionalInfo = JsonConvert.DeserializeObject(o.AdditionalInfoField, GetType(Dictionary(Of String, String)))

        o.LastTime = Now
        o.Save()

        Return o

    End Function

    Public Shared Function Load(OrganizationUnitId As Integer) As List(Of ZoneType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim ol As List(Of ZoneType) = m.GetObject(Of ZoneType)("select * from zones where OrganizationUnitId='" & OrganizationUnitId & "';")
        For Each o In ol
            o.AdditionalInfo = JsonConvert.DeserializeObject(o.AdditionalInfoField, GetType(Dictionary(Of String, String)))

            o.LastTime = Now
            o.Save()
        Next


        Return ol

    End Function

    Public Shared Function Load() As List(Of ZoneType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim ol As List(Of ZoneType) = m.GetObject(Of ZoneType)("select * from zones where active='" & 1 & "';")
        For Each o In ol
            o.AdditionalInfo = JsonConvert.DeserializeObject(o.AdditionalInfoField, GetType(Dictionary(Of String, String)))

            o.LastTime = Now
            o.Save()
        Next


        Return ol

    End Function

    Public Shared Function LoadID(id As Integer) As ZoneType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As ZoneType = m.GetSingleObject(Of ZoneType)("select * from zones where id='" & id & "';")

        o.AdditionalInfo = JsonConvert.DeserializeObject(o.AdditionalInfoField, GetType(Dictionary(Of String, String)))

            o.LastTime = Now
            o.Save()



        Return o

    End Function

End Class

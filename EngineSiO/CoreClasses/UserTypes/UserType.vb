
Imports Newtonsoft.Json

Public Class UserType

    Public Property Id As Integer
    Public Property Login As String
    Public Property LastTime As DateTime
    Public Property Name As String
    Public Property Surname As String
    Public Property Emplyeeid As Integer
    Public Property AccessField As String
    Public Property Title As String

    Public Property Active As Integer


    Public Access As UserAccesssType
    Public ADINFO As List(Of String)

    Sub New()
        Me.Access = New UserAccesssType

    End Sub


    Public Function GetOrganizationAccess(organiationID As Integer) As Boolean
        For Each o In Me.Access.OrganizationUnits
            If o.Key = organiationID Then
                Return o.Value
            End If
        Next
        Return False

    End Function
    Public Function GetZoneAccess(zoneID As Integer) As Boolean
        For Each o In Me.Access.Zones
            If o.Key = zoneID Then
                Return o.Value
            End If
        Next
        Return False

    End Function
    Public Function GetAccess(accessID As AccessList) As Boolean
        For Each o In Me.Access.Access
            If o.Key = accessID Then
                Return o.Value
            End If
        Next
        Return False

    End Function
    ''' <summary>
    ''' Dodaje / zmienia uprawnienia
    ''' </summary>
    ''' <param name="Level"></param>
    ''' <param name="value"></param>
    Public Sub ChangeAccess(Level As AccessList, value As Boolean)
        For Each a In Me.Access.Access
            If a.Key = Level.ToString Then
                Me.Access.Access(Level.ToString) = value
                Exit Sub
            End If
        Next

        Me.Access.Access.Add(Level.ToString, value)

    End Sub
    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        Me.LastTime = Now

        Me.AccessField = JsonConvert.SerializeObject(Me.Access)

        If Me.Id = 0 Then
            If m.GetCount("select count(*) from users where login='" & Login & "';") > 0 Then
                Exit Sub
            End If
            m.Insert("users", "id", Me)
        Else
            m.Update("users", "id", Me)
        End If
    End Sub

    Public Shared Function Load(login As String) As UserType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim u As UserType = m.GetSingleObject(Of UserType)("select * from users where login='" & login & "';")
        If Not IsNothing(u) Then
            u.Access = JsonConvert.DeserializeObject(u.AccessField, GetType(UserAccesssType))
            u.LastTime = Now
            u.Save()
        End If


        Return u

    End Function
    Public Shared Function Load(id As Integer) As UserType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim u As UserType = m.GetSingleObject(Of UserType)("select * from users where id='" & id & "';")
        If Not IsNothing(u) Then
            u.Access = JsonConvert.DeserializeObject(u.AccessField, GetType(UserAccesssType))
            u.LastTime = Now
            u.Save()
        End If


        Return u

    End Function
    Public Shared Function Load() As List(Of UserType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim u As List(Of UserType) = m.GetObject(Of UserType)("select * from users where active=1;")



        Return u

    End Function


    Public Shared Function AccessList() As DataTable

        AccessList = New DataTable
        AccessList.Columns.Add("id")
        AccessList.Columns.Add("val")

        With AccessList
            .Rows.Add(0, "Edycja użytkowników")
        End With


        Dim l As List(Of OrganizationUnitType) = OrganizationUnitType.Load(True)
        For Each o In l
            AccessList.Rows.Add(o.Id, o.Name)
        Next

        Dim zl As List(Of ZoneType) = ZoneType.Load

        For Each z In zl
            AccessList.Rows.Add(z.Id, z.Name)
        Next


    End Function

End Class

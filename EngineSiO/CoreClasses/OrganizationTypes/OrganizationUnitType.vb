
Imports Newtonsoft.Json

Public Class OrganizationUnitType

    Public Property Id As Integer
    Public Property Name As String
    Public Property InfoField As String
    Public Info As Dictionary(Of String, String)

    Public Property AddressField As String
    Public Address As AddressType

    Public Property SoftwareCodesField As String
    Public SoftwareCodes As Dictionary(Of SoftwareCodesKeys, String)

    Public Property LastTime As DateTime

    Public Property Active As Integer

    Public Sub New()
        Me.Address = New AddressType
        Me.Info = New Dictionary(Of String, String)
        Me.SoftwareCodes = New Dictionary(Of SoftwareCodesKeys, String)
        Me.Active = 1

    End Sub

    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        Me.LastTime = Now

        Me.AddressField = JsonConvert.SerializeObject(Me.Address)
        Me.SoftwareCodesField = JsonConvert.SerializeObject(Me.SoftwareCodes)
        Me.InfoField = JsonConvert.SerializeObject(Me.Info)

        If Me.Id = 0 Then
            If m.GetCount("select count(*) from organizationunits where name='" & Me.Name & "';") > 0 Then
                Exit Sub
            End If
            m.Insert("organizationunits", "id", Me)
        Else
            m.Update("organizationunits", "id", Me)
        End If
    End Sub

    Public Shared Function Load(name As String) As OrganizationUnitType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As OrganizationUnitType = m.GetSingleObject(Of OrganizationUnitType)("select * from organizationunits where name='" & name & "';")

        o.Address = JsonConvert.DeserializeObject(o.AddressField, GetType(AddressType))
        o.SoftwareCodes = JsonConvert.DeserializeObject(o.SoftwareCodesField, GetType(Dictionary(Of SoftwareCodesKeys, String)))
        o.Info = JsonConvert.DeserializeObject(o.InfoField, GetType(Dictionary(Of String, String)))

        o.LastTime = Now
        o.Save()

        Return o

    End Function
    Public Shared Function Load(id As Integer) As OrganizationUnitType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim o As OrganizationUnitType = m.GetSingleObject(Of OrganizationUnitType)("select * from organizationunits where id='" & id & "';")

        o.Address = JsonConvert.DeserializeObject(o.AddressField, GetType(AddressType))
        o.SoftwareCodes = JsonConvert.DeserializeObject(o.SoftwareCodesField, GetType(Dictionary(Of SoftwareCodesKeys, String)))
        o.Info = JsonConvert.DeserializeObject(o.InfoField, GetType(Dictionary(Of String, String)))

        o.LastTime = Now
        o.Save()

        Return o

    End Function
    Public Shared Function Load(active As Boolean) As List(Of OrganizationUnitType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim ol As List(Of OrganizationUnitType)
        If active = True Then
            ol = m.GetObject(Of OrganizationUnitType)("select * from organizationunits where active=" & 1 & ";")

        Else
            ol = m.GetObject(Of OrganizationUnitType)("select * from organizationunits ;")

        End If


        For Each o In ol
            o.Address = JsonConvert.DeserializeObject(o.AddressField, GetType(AddressType))
            o.SoftwareCodes = JsonConvert.DeserializeObject(o.SoftwareCodesField, GetType(Dictionary(Of SoftwareCodesKeys, String)))
            o.Info = JsonConvert.DeserializeObject(o.InfoField, GetType(Dictionary(Of String, String)))

            o.LastTime = Now
            o.Save()
        Next


        Return ol

    End Function

    Public Shared Function Load(FieldName As String, Value As String) As List(Of OrganizationUnitType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim ol As List(Of OrganizationUnitType) = m.GetObject(Of OrganizationUnitType)("select * from organizationunits where " & FieldName & "='" & Value & "';")

            For Each o In ol

            o.Address = JsonConvert.DeserializeObject(o.AddressField, GetType(AddressType))
            o.SoftwareCodes = JsonConvert.DeserializeObject(o.SoftwareCodesField, GetType(Dictionary(Of SoftwareCodesKeys, String)))
            o.Info = JsonConvert.DeserializeObject(o.InfoField, GetType(Dictionary(Of String, String)))

            o.LastTime = Now
            o.Save()
        Next

        Return ol

    End Function





End Class

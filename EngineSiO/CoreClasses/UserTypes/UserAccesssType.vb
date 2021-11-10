
Public Class UserAccesssType

    Public Property Access As Dictionary(Of String, Boolean)
    Public Property OrganizationUnits As Dictionary(Of Integer, Boolean)
    Public Property Zones As Dictionary(Of Integer, Boolean)


    Sub New()
        Me.Access = New Dictionary(Of String, Boolean)
        Me.OrganizationUnits = New Dictionary(Of Integer, Boolean)
        Me.Zones = New Dictionary(Of Integer, Boolean)


    End Sub


End Class

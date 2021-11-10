


Module MainProgram



    Public Sub AddUser(login As String)
        Dim u As New UserType
        u.Login = login
        u.Save()

    End Sub

    Public Sub AddOrganiation(o As OrganizationUnitType)
        o.Save()
    End Sub
    Public Sub AddZone(z As ZoneType)
        z.Save()
    End Sub





End Module

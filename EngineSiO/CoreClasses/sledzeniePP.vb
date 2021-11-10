Imports EngineSiO.ServiceReference1

Public Class sledzeniePP



    Public Shared Function SprawdzPRzesylke(numer As String) As ServiceReference1.Przesylka
        numer = numer.Replace(" ", "").Replace("`", "").Replace("'", "")


        Dim service As SledzeniePortTypeClient = New SledzeniePortTypeClient()
        service.ClientCredentials.UserName.UserName = "sledzeniepp"
        service.ClientCredentials.UserName.Password = "PPSA"

        Dim zstp As ServiceReference1.Przesylka = service.sprawdzPrzesylkePl(numer)
        Return zstp

    End Function
End Class

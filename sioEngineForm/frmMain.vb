Imports EngineSiO

Public Class frmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim o As New OrganizationUnitType


        o.Name = "Jednostka Testowa"
        o.Address = New AddressType
        With o.Address
            .Name = "WER Testowy"
            .Street = "Zmyślona"
            .HouseNumber = 12
            .City = "Wrocław"
            .Borough = "Wrocław gmina"
            .Country = "Polska"
            .County = "Dolnośląskie"
            .District = "Wrocławski"
            .ZIPCode = "50900"
        End With

        o.Info = New Dictionary(Of String, String)
        o.Info.Add("Posiada DERY", "NIE")

        o.SoftwareCodes = New Dictionary(Of SoftwareCodesKeys, String)
        o.SoftwareCodes.Add(SoftwareCodesKeys.ZST, "TAK")

        o.Save()

        o = OrganizationUnitType.Load("Jednostka Testowa")



        Dim z As New ZoneType
        z.Name = "Strefa testowa 1"
        z.OrganizationUnitId = o.Id
        z.AdditionalInfo = New Dictionary(Of String, String)
        z.AdditionalInfo.Add("Liczba drukarek", "15")

        z.Save()
        z = ZoneType.Load("Strefa testowa 1")
        z.Code = "ST1"
        z.Save()

        Dim icm As New InfoCommandType
        icm.Name = "Komenda test"
        icm.MethodName = CommandsNames.UnblockScanner
        icm.Save()


        Dim ec As New EventConfigurationType
        ec.Name = "Zadrzenie Testowe"
        ec.InfoCommandsIds = New List(Of InfoCommandType)
        ec.InfoCommandsIds.Add(InfoCommandType.Load(icm.Id))
        ec.Save()








        Dim ic As New InfoCategoryType
        ic.Name = "Kategoria 1"
        ic.OrganizationId = o.Id
        ic.Priority = Priorities.central
        ic.EventsList = New List(Of EventConfigurationType)
        ic.EventsList.Add(ec)
        ic.Save()


        Dim info As New InfoType With {
        .Comments = New List(Of CommentType),
        .Content = New List(Of ContentType),
        .CreateTime = Now,
        .InfoCategoryTypeId = ic.Id,
        .OrganizationId = o.Id,
        .Reactions = New List(Of ReactionType),
        .UserId = 0,
        .ZoneId = z.Id,
        ._id = Guid.NewGuid.ToString
        }

        Dim ct As New ContentType
        ct.CreateTime = Now
        ct.Key = icm.MethodName.ToString
        ct.Value = "Wypisano skaner 00 pracownikowi: X Y"
        info.Content.Add(ct)

        info.Save()




        info.Comments.Add(New CommentType With {
        .ZoneID = info.ZoneId,
        .UserId = info.UserId,
        .Content = New ContentType With {
        .Key = "1",
        .Value = "Komentarz do informacji 1"
        }
        })


        info.Reactions.Add(New ReactionType With {
        .ReactionType = ReactionEnum.Likes,
        .UserId = info.UserId,
        .CreateTime = Now
                })

        info.Save()





    End Sub
End Class
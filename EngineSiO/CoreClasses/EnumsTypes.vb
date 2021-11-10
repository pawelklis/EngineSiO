Public Module EnumsTypes
    Public Enum SoftwareCodesKeys
        ZST = 0
        SP2000 = 1
        EN = 2
        MRUMC = 3
        HD = 4
    End Enum

    Public Enum Formatka
        PobierzSkaner = 0
        ZdajSkaner = 1

        StartPracy = 10
        KoniecPracy = 11
        WyjściePracownika = 12

    End Enum
    Public Enum Condition
        Sprawny = 0
        Wada = 1
        Uszkodzony = 2
    End Enum

    Public Enum FieldEnumTypes
        TextSingleLine = 0
        TextMultiLine = 1
        DropDownList = 2
    End Enum
    Public Enum FieldBindingCommands
        Brak = -1
        Data_Czas = 0
        Pracownicy_Jednostka = 1
        Pracownicy_Strefa = 2
        Skanery_Jednostka = 3
        Skanery_Strefa = 4

    End Enum

    Public Enum WorkerLevels
        Jednostka_Organizacyjna = 1
        Komórka_Organizacyjna = 2
        Organizacja = 3

    End Enum

    Public Enum RangeLevels
        Jednostka_Organizacyjna = 1
        Komórka_Organizacyjna = 2
        Organizacja = 3

    End Enum
    Public Enum CommandsNames
        Skanery_AD_Zablokuj = 0
        Skanery_AD_Odblokuj = 1

        Pracownicy_Obsada_Start_Pracy = 20
        Pracownicy_Obsada_Stop_Pracy = 21

    End Enum

    Public Enum InfoMessage
        PobranoSkaner = 0
        ZdanoSkaner = 1
        StartPracy = 10
        KoniecPracy = 11
    End Enum
    Public Enum YesNo
        NIE = 0
        TAK = 1
    End Enum
    Public Enum Priorities
        Centralny = 0
        JednostkiOrganizacyjne = 10
        KomórkiOrganizacyjne = 20





    End Enum



    Public Enum AccessList
        Edycja_Użytkowników = 0
        Edycja_Jednostek_Organizacyjnych = 1
        Edycja_Komórek_organizacyjnych = 2
    End Enum
    Public Enum NotifyRange
        Jednostka_Organizacyjna = 0
        Komórka_Organizacyjna = 1
        Użytkownik = 2

    End Enum

    Public Enum ReactionEnum
        Likes = 0
        Super = 1
        Love = 3
        NotLike = 4
        Good = 5
        Bad = 6
        Cry = 7
        Smile = 8
    End Enum

































End Module



Public Class frmTypes

    Public Shared Function GetScanner() As List(Of frmParameters)
        GetScanner = New List(Of frmParameters)
        Dim f As frmParameters
        f = New frmParameters
        f.key = "Pracownicy zakres"
        f.value = "0"
        f.valuetype = "WorkerLevels"
        GetScanner.Add(f)

        f = New frmParameters
        f.key = "Dodawanie pracownika"
        f.value = "0"
        f.valuetype = "YesNo"
        GetScanner.Add(f)

        f = New frmParameters
        f.key = "Skanery zakres"
        f.value = "0"
        f.valuetype = "RangeLevels"
        GetScanner.Add(f)

        f = New frmParameters
        f.key = "Pole Uwagi"
        f.value = "0"
        f.valuetype = "YesNo"
        GetScanner.Add(f)
    End Function



    Public Shared Function LeftScanner() As List(Of frmParameters)
        LeftScanner = New List(Of frmParameters)
        Dim f As frmParameters
        f = New frmParameters
        f.key = "Pole Uwagi"
        f.value = "0"
        f.valuetype = "YesNo"
        LeftScanner.Add(f)

        f = New frmParameters
        f.key = "Dodaj usterke"
        f.value = "0"
        f.valuetype = "YesNo"
        LeftScanner.Add(f)

        f = New frmParameters
        f.key = "Kondycja usterki"
        f.value = "0"
        f.valuetype = "Condition"
        LeftScanner.Add(f)


    End Function


    Public Shared Function StartPracy() As List(Of frmParameters)
        StartPracy = New List(Of frmParameters)
        Dim f As frmParameters
        f = New frmParameters
        f.key = "Pracownicy zakres"
        f.value = "0"
        f.valuetype = "WorkerLevels"
        StartPracy.Add(f)

        f = New frmParameters
        f.key = "Pole Uwagi"
        f.value = "0"
        f.valuetype = "YesNo"
        StartPracy.Add(f)



    End Function


    Public Shared Function KoniecPracy() As List(Of frmParameters)
        KoniecPracy = New List(Of frmParameters)
        Dim f As frmParameters
        f.key = "Pracownicy zakres"
        f.value = "0"
        f.valuetype = "WorkerLevels"
        StartPracy.Add(f)

        f = New frmParameters
        f.key = "Pole Uwagi"
        f.value = "0"
        f.valuetype = "YesNo"
        StartPracy.Add(f)



    End Function















    Public Class frmParameters
        Public Property key As String
        Public Property value As String
        Public Property valuetype As String

    End Class
End Class

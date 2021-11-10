Public Class AdresSektorType

    Public Property PNA3 As String
    Public Property Kierunek As String
    Public Property Rozdzielnia As String



    Public Shared Function GetSektor(pna As String, Optional l As List(Of AdresSektorType) = Nothing) As AdresSektorType

        If IsNothing(pna) Then
            Return New AdresSektorType With {.PNA3 = "", .Kierunek = "", .Rozdzielnia = ""}
        End If

        If IsNothing(l) Then l = GetList()
        If pna.Length < 3 Then Return New AdresSektorType With {.PNA3 = "", .Kierunek = "", .Rozdzielnia = ""}
        pna = pna.Replace("-", "")
        If pna.Length > 3 Then
            pna = pna.Substring(0, 3)
        End If

        For Each o In l
            If o.PNA3 = pna Then
                Return o
            End If
        Next

        Return New AdresSektorType With {.PNA3 = "", .Kierunek = "", .Rozdzielnia = ""}

    End Function

    Public Shared Function GetList() As List(Of AdresSektorType)
        GetList = New List(Of AdresSektorType)
        Dim o As AdresSektorType
        o = New AdresSektorType With {.PNA3 = "000", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "001", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "002", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "003", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "004", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "005", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "006", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "007", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "008", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "009", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "010", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "011", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "012", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "013", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "014", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "015", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "016", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "017", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "018", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "019", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "020", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "021", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "022", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "023", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "024", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "025", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "026", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "027", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "028", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "029", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "030", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "031", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "032", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "033", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "034", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "035", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "036", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "037", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "038", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "039", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "040", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "041", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "042", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "043", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "044", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "045", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "046", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "047", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "048", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "049", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "050", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "051", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "052", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "053", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "054", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "055", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "056", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "058", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "061", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ciechanów"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "062", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ostrołęka"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "063", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ostrołęka"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "064", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ciechanów"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "065", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ciechanów"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "071", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Siedlce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "072", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "073", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ostrołęka"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "074", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ostrołęka"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "081", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Siedlce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "082", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Siedlce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "083", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Siedlce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "084", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "085", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "091", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ciechanów"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "092", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Płock"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "093", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Ciechanów"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "094", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Płock"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "095", .Kierunek = "WER Warszawa", .Rozdzielnia = "DER Płock"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "100", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "101", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "102", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "103", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "104", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "105", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "106", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "107", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "108", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "109", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "110", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "111", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "112", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "113", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "114", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "115", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "116", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "117", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "121", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "122", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "131", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "132", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "133", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "141", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "142", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "143", .Kierunek = "WER Olsztyn", .Rozdzielnia = "WER Olsztyn"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "144", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "145", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "150", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "151", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "152", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "153", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "154", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "155", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "156", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "157", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "158", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "159", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "160", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "161", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "162", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "163", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "164", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "165", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "171", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "172", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "173", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "181", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "182", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "183", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "184", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "185", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "191", .Kierunek = "WER Białystok", .Rozdzielnia = "WER Białystok"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "192", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "193", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "194", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "195", .Kierunek = "WER Białystok", .Rozdzielnia = "DER Ełk"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "200", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "201", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "202", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "203", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "204", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "205", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "206", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "207", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "208", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "209", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "210", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "211", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "212", .Kierunek = "WER Lublin", .Rozdzielnia = "DER Radzyń Podlaski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "213", .Kierunek = "WER Lublin", .Rozdzielnia = "DER Radzyń Podlaski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "214", .Kierunek = "WER Lublin", .Rozdzielnia = "DER Radzyń Podlaski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "215", .Kierunek = "WER Lublin", .Rozdzielnia = "DER Radzyń Podlaski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "221", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "222", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "223", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "224", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "225", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "226", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "231", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "232", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "233", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "234", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "241", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "242", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "243", .Kierunek = "WER Lublin", .Rozdzielnia = "WER Lublin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "250", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "251", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "252", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "253", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "254", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "255", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "256", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "257", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "258", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "259", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "260", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "261", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "262", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "263", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "264", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "265", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "266", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "267", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "268", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "269", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "271", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "272", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "273", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "274", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "275", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "276", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "281", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "282", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "283", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "284", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "285", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "291", .Kierunek = "WER Kielce", .Rozdzielnia = "WER Kielce"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "300", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "301", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "302", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "303", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "304", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "305", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "306", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "307", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "308", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "309", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "310", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "311", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "312", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "313", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "314", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "315", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "316", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "317", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "318", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "319", .Kierunek = "WER Kraków M", .Rozdzielnia = "WER Kraków Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "320", .Kierunek = "RS Kraków 32-0", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "321", .Kierunek = "RS Kraków 32-1", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "322", .Kierunek = "RS Kraków 32-2", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "323", .Kierunek = "RS Kraków 32-3", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "324", .Kierunek = "RS Kraków 32-4", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "325", .Kierunek = "RS Kraków 32-5", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "326", .Kierunek = "RS Kraków 32-6", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "327", .Kierunek = "RS Kraków 32-7", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "328", .Kierunek = "RS Kraków 32-8", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "331", .Kierunek = "RS Kraków 33-1", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "332", .Kierunek = "RS Kraków 33-2", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "333", .Kierunek = "RS Kraków 33-3", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "341", .Kierunek = "RS Kraków 34-1", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "342", .Kierunek = "RS Kraków 34-2", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "343", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "344", .Kierunek = "RS Kraków 34-4", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "345", .Kierunek = "RS Kraków 34-5", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "346", .Kierunek = "RS Kraków 34-6", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "347", .Kierunek = "RS Kraków 34-7", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "350", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "351", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "352", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "353", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "354", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "355", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "356", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "357", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "358", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "359", .Kierunek = "WER Rudna Mała M", .Rozdzielnia = "WER Rudna Mała Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "360", .Kierunek = "RS Rzeszów 36-0", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "361", .Kierunek = "RS Rzeszów 36-1", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "362", .Kierunek = "RS Rzeszów 36-2", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "371", .Kierunek = "RS Rzeszów 37-1", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "372", .Kierunek = "RS Rzeszów 37-2", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "373", .Kierunek = "RS Rzeszów 37-3", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "374", .Kierunek = "RS Rzeszów 37-4", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "375", .Kierunek = "RS Rzeszów 37-5", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "376", .Kierunek = "RS Rzeszów 37-6", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "377", .Kierunek = "RS Rzeszów 37-7", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "381", .Kierunek = "RS Rzeszów 38-1", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "382", .Kierunek = "RS Rzeszów 38-2", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "383", .Kierunek = "RS Kraków 38-3", .Rozdzielnia = "WER Kraków"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "384", .Kierunek = "RS Rzeszów 38-4", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "385", .Kierunek = "RS Rzeszów 38-5", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "386", .Kierunek = "RS Rzeszów 38-6", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "387", .Kierunek = "RS Rzeszów 38-7", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "391", .Kierunek = "RS Rzeszów 39-1", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "392", .Kierunek = "RS Rzeszów 39-2", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "393", .Kierunek = "RS Rzeszów 39-3", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "394", .Kierunek = "RS Rzeszów 39-4", .Rozdzielnia = "WER Rudna Mała"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "400", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "401", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "402", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "403", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "404", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "405", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "406", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "407", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "408", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "409", .Kierunek = "WER Zabrze", .Rozdzielnia = "Katowice 2 Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "411", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "412", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "413", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "414", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "415", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "416", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "417", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "418", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "419", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "421", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "422", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "423", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "424", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "425", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "426", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "427", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "431", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "432", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "433", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "434", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "435", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "436", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "441", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "442", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "443", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "450", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "451", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "452", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "453", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "454", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "455", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "456", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "457", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "458", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "459", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "460", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "461", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "462", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "463", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "471", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "472", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "473", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "474", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "481", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "482", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "483", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "491", .Kierunek = "WER Zabrze", .Rozdzielnia = "WER Zabrze"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "492", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "493", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "500", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "501", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "502", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "503", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "504", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "505", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "506", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "507", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "508", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "509", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "510", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "511", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "512", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "513", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "514", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "515", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "516", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "517", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "518", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "519", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "520", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "521", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "522", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "523", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "524", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "525", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "526", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "527", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "528", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "529", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "530", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "531", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "532", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "533", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "534", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "535", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "536", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "537", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "538", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "539", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "540", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "541", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "542", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "543", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "544", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "545", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "546", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "547", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "548", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "549", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "550", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "551", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "552", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "553", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "561", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "562", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "563", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "564", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "565", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "571", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "572", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "573", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "574", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "575", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "581", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "582", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "583", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "584", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "585", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "591", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "592", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "593", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "594", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "595", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "596", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "597", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "598", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "599", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "600", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "601", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "602", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "603", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "604", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "605", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "606", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "607", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "608", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "609", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "610", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "611", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "612", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "613", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "614", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "615", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "616", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "617", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "618", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "619", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "620", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "621", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "622", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "623", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "624", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "625", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "626", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "627", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "628", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Ostrów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "630", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "631", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "632", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "633", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Ostrów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "634", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Ostrów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "635", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Ostrów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "636", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Ostrów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "637", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Ostrów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "638", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "639", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "640", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "641", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "642", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "643", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "644", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "645", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "646", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "647", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "648", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "649", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "650", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "651", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "652", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "653", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "654", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "655", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "656", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "657", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "658", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "659", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "660", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "661", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "662", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Gorzów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "663", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Gorzów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "664", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Gorzów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "665", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Gorzów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "666", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "671", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "672", .Kierunek = "WER Wrocław", .Rozdzielnia = "WER Wrocław"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "673", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "674", .Kierunek = "WER Komorniki", .Rozdzielnia = "WER Komorniki"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "681", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "682", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "683", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Zielona Góra"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "691", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Gorzów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "692", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Gorzów Wielkopolski"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "700", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "701", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "702", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "703", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "704", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "705", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "706", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "707", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "708", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "709", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "710", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "711", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "712", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "713", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "714", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "715", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "716", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "717", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "718", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "719", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "720", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "721", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "722", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "723", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "724", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "725", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "726", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "731", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "732", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "741", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "742", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "743", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "744", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "745", .Kierunek = "WER Szczecin", .Rozdzielnia = "WER Szczecin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "750", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "751", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "752", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "753", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "754", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "755", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "756", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "757", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "758", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "759", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "760", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "761", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "762", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "771", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "772", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "773", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "774", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "781", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "782", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "783", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "784", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "785", .Kierunek = "WER Komorniki", .Rozdzielnia = "DER Koszalin"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "786", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "800", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "801", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "802", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "803", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "804", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "805", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "806", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "807", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "808", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "809", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański Miasto "}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "810", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "811", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "812", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "813", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "814", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "815", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "816", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "817", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "818", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "819", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "821", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "822", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "823", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "824", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "825", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "830", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "831", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "832", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "833", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "834", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "841", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "842", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "843", .Kierunek = "WER Pruszcz Gdański", .Rozdzielnia = "WER Pruszcz Gdański"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "850", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "851", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "852", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "853", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "854", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "855", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "856", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "857", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "858", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "859", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "860", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "861", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "862", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "863", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "871", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "872", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "873", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "874", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "875", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "876", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "877", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "878", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "881", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "882", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "883", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "884", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "891", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "892", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "893", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "894", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "895", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "896", .Kierunek = "WER Lisi Ogon", .Rozdzielnia = "WER Lisi Ogon"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "900", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "901", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "902", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "903", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "904", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "905", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "906", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "907", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "908", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "909", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "910", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "911", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "912", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "913", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "914", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "915", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "916", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "917", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "918", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "919", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "920", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "921", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "922", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "923", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "924", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "925", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "926", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "927", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "928", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "929", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "930", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "931", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "932", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "933", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "934", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "935", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "936", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "937", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "938", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "939", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "940", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "941", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "942", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "943", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "944", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "945", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "946", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "947", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "948", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "949", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź Miasto"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "950", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "951", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "952", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "961", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "962", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "963", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "965", .Kierunek = "WER Warszawa", .Rozdzielnia = "WER Warszawa"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "972", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "973", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "974", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "975", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "981", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "982", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "983", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "984", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "991", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "992", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "993", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
        o = New AdresSektorType With {.PNA3 = "994", .Kierunek = "WER Łódź", .Rozdzielnia = "WER Łódź"}
        GetList.Add(o)
    End Function


End Class

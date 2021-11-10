

<DebuggerDisplay("Faza:{NazwaFazy},UP:{Jednostka}")>
Public Class tfTrackerType

    Public Property NumerPRzesylki As String
    Public Property tp As tPrzesylkaType
    Public Property kursy As List(Of kursType)
    Public Property CzasWJednostce As TimeSpan
    Public Property CzasDoNastępnejJednostki As TimeSpan
    Public Property PrzesylkaZST As ServiceReference1.Przesylka
    Public Property ZdarzeniaZST As List(Of ServiceReference1.Zdarzenie)
    Public Property NazwaFazy As String
    Public Property Jednostka As ListaUPtype
    Public Property NextJO As tfTrackerType
    Public Property Pierwszykurs As kursType
    Public Property PotencjalneKursy As List(Of kursType)
    Public Property Track As List(Of tfTrackerType)


    Public Shared Function GetData(numer As String) As tfTrackerType
        Dim m As New mongoDBCore


        numer = numer.Replace(" ", "").Replace("`", "").Replace("'", "")
        Dim f As New Dictionary(Of String, Object)
        f.Add("Identyfikator_przesylki", numer)
        Dim tp As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", f)

        Dim lsort As New List(Of tPrzesylkaType)

        For Each p In tp
            If p.Nazwa_fazy = "nadania" Then p.lp = 1
            If p.Nazwa_fazy = "zbiórkowa" Then p.lp = 2
            If p.Nazwa_fazy = "koncentracji" Then p.lp = 3
            If p.Nazwa_fazy = "przewozu" Then p.lp = 4
            If p.Nazwa_fazy = "dekoncentracji" Then p.lp = 5
            If p.Nazwa_fazy = "rozwózki" Then p.lp = 6
            If p.Nazwa_fazy = "doręczenia" Then p.lp = 7
            If p.Nazwa_fazy = "nieokreślona" Then p.lp = 8
        Next
        lsort = tp.OrderBy(Function(mts) mts.Rzeczywisty_data_czas_wejscia_Do_jednostki).ThenBy(Function(mts) mts.lp).ToList

        Dim l As New List(Of tfTrackerType)

        Dim x As Integer = 0

        Dim zstp = sledzeniePP.SprawdzPRzesylke(numer)
        Dim o As tfTrackerType = tfTrackerType.Create(x, lsort, zstp)






        Return o

    End Function

    Private Function GenereteTrack() As tfTrackerType

        Dim lt As New List(Of tfTrackerType)
        lt.Add(Me)
        Dim u As tfTrackerType = Me.NextJO
        Do Until u Is Nothing
            lt.Add(u)
            u = u.NextJO
        Loop
        Me.Track = lt
    End Function




    Private Shared Function Create(startindex As Integer, l As List(Of tPrzesylkaType), zstp As ServiceReference1.Przesylka) As tfTrackerType
        Dim p As tPrzesylkaType = l(startindex)
        Dim o As New tfTrackerType
        o.NumerPRzesylki = p.Identyfikator_przesylki
        o.tp = p
        Dim kursy As List(Of kursType) = kursType.Load(p.Kod_jednostki)
        o.kursy = kursy
        o.Jednostka = ListaUPtype.Load(o.tp.PNI)
        o.NazwaFazy = p.Nazwa_fazy

        o.CzasWJednostce = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, p.Rzeczywisty_data_czas_wejscia_Do_jednostki, p.Rzeczywisty_data_czas_wyjscia_z_jednostki))



        Dim kodnastepnej As String
        Dim pierwszykurs As kursType

        Dim nextp As tPrzesylkaType

        If startindex + 1 < l.Count Then

            nextp = l(startindex + 1)

            If Not IsNothing(nextp) Then
                kodnastepnej = nextp.Kod_jednostki
                Dim rzeczwyj As TimeSpan = TimeSpan.Parse(p.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToShortTimeString)
                'proba

                Dim potencjalnekursy As New List(Of kursType)

                For Each k In kursy
                    Debug.Print(k.nrkursu)
                    If k.CzyPogodzinie(p.Kod_jednostki, kodnastepnej, rzeczwyj) = True Then
                        potencjalnekursy.Add(k)
                    End If
                Next

                If potencjalnekursy.Count = 0 Then
                    Debug.Print(1)
                    For Each k In kursy
                        If k.CzyPolaczenie(p.Kod_jednostki, kodnastepnej) = True Then
                            potencjalnekursy.Add(k)
                        End If
                    Next
                End If

                If potencjalnekursy.Count = 1 Then
                    pierwszykurs = potencjalnekursy(0)
                Else
                    If potencjalnekursy.Count > 0 Then
                        pierwszykurs = potencjalnekursy(0)

                        For Each pk In potencjalnekursy
                            If pk.Przystanek(p.Kod_jednostki).odjazd < pierwszykurs.Przystanek(p.Kod_jednostki).odjazd Then
                                pierwszykurs = pk
                            End If
                        Next
                    Else
                        pierwszykurs = Nothing
                    End If
                End If

                o.Pierwszykurs = pierwszykurs
                o.PotencjalneKursy = potencjalnekursy


            End If

            o.CzasDoNastępnejJednostki = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, p.Rzeczywisty_data_czas_wyjscia_z_jednostki, nextp.Rzeczywisty_data_czas_wejscia_Do_jednostki))

            o.NextJO = Create(startindex + 1, l, zstp)
        End If



        o.ZdarzeniaZST = New List(Of ServiceReference1.Zdarzenie)
        If Not IsNothing(zstp) Then
            If Not IsNothing(zstp.danePrzesylki.zdarzenia) Then

                Dim jo = From z In zstp.danePrzesylki.zdarzenia
                         Select z.jednostka.nazwa Distinct

                For Each j In jo.ToList

                    If IsNothing(j) Then j = "#EN$"

                    If j.StartsWith("UP ") Then j = j.Replace("UP ", "")

                    If o.Jednostka.UP.StartsWith(j) Then
                        o.PrzesylkaZST = zstp

                        For Each z In zstp.danePrzesylki.zdarzenia
                            Dim nz As String = z.jednostka.nazwa
                            If IsNothing(nz) Then nz = "#EN$"

                            If nz.StartsWith("UP ") Then nz = nz.Replace("UP ", "")

                            If o.Jednostka.UP.StartsWith(nz) Then
                                o.ZdarzeniaZST.Add(z)
                            End If
                        Next


                    End If



                Next
            End If
        End If

        o.GenereteTrack()

        Return o
    End Function



End Class

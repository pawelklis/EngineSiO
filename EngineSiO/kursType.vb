Imports System.Windows.Forms

Public Class kursType
    Public Property nrkursu As String
    Public Property nazwakursu As String
    Public Property przyjazdstart As TimeSpan
    Public Property odjazdstop As TimeSpan
    Public Property Przystanki As List(Of PrzystanekType)

    Public Sub New()
        Me.Przystanki = New List(Of PrzystanekType)
    End Sub

    Public Function Przystanek(kodjednostki As String) As PrzystanekType
        For Each p In Me.Przystanki
            If p.kodjednostki = kodjednostki Then
                Return p
            End If
        Next
    End Function
    Public Function CzyPolaczenie(ZkodJednostki As String, DoKodJednostki As String) As Boolean

        If Me.nrkursu.Contains("P") Then
            Return False
        End If

        For Each p In Me.Przystanki
            If p.kodjednostki = ZkodJednostki Then

                For Each pp In Me.Przystanki
                    If pp.kodjednostki = DoKodJednostki Then
                        If pp.nrkolejny > p.nrkolejny Then
                            'ten kursy sie nadaje, teraz godzina
                            Return True
                        End If
                    End If
                Next

            End If
        Next

        Return False
    End Function
    Public Function CzyPogodzinie(ZkodJednostki As String, DoKodJednostki As String, godzinaWyjazduZ As TimeSpan) As Boolean

        If Me.nrkursu.Contains("P") Then
            Return False
        End If

        For Each p In Me.Przystanki
            If p.kodjednostki = ZkodJednostki Then

                For Each pp In Me.Przystanki
                    If pp.kodjednostki = DoKodJednostki Then
                        If pp.nrkolejny > p.nrkolejny Then
                            'ten kursy sie nadaje, teraz godzina
                            If p.odjazd <> TimeSpan.FromSeconds(0) Then
                                If p.odjazd >= godzinaWyjazduZ Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                Next

            End If
        Next

        Return False

    End Function

    Public Shared Function Import()

        Dim kursy As New List(Of Object)

        Dim lup As List(Of ListaUPtype) = ListaUPtype.Load


        Dim opf As New OpenFileDialog
        If opf.ShowDialog = DialogResult.OK Then

            Dim dt As DataTable = ConvertCore.csvToDatatable(opf.FileName, ";")


            mongoDBCore.drop("kursymatryca")


            If IsNothing(kursy) Then kursy = New List(Of Object)
            kursy.Clear()

            For i = 0 To dt.Rows.Count - 1

                If dt.Rows(i)("TYP_PRZYSTANKU").ToString.ToLower = "s" Then

                    Dim kurs As New kursType

                    kurs.nrkursu = dt.Rows(i)(0)
                    kurs.nazwakursu = dt.Rows(i)("nazwakursu")

                    kursy.Add(kurs)

                End If


            Next

            Dim ii As Integer = 0

            For Each k In kursy
                Console.Clear()
                Console.Write(ii & "/" & kursy.Count)
                ii += 1

                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)(0) = k.nrkursu Then
                        Dim p As New PrzystanekType

                        For Each o In lup
                            If o.KOD = dt.Rows(i)("kod_jednostki") Then
                                p.jednostka = o
                                Exit For
                            End If
                        Next


                        p.kodjednostki = dt.Rows(i)("kod_jednostki")
                        p.nazwajednostki = dt.Rows(i)("nazwa_jednostki")
                        p.nrkolejny = dt.Rows(i)("nr_kolejny")
                        p.rodzajprzes = dt.Rows(i)("rodzajprzes").ToString.Split(",").ToList
                        p.typprzystanku = dt.Rows(i)("typ_przystankU")

                        Dim odd As String = dt.Rows(i)("PLANOWY_DTCZAS_ODJAZDU")
                        Dim doo As String = dt.Rows(i)("PLANOWY_DTCZAS_PRZYJAZDU")
                        Dim d As Date
                        If IsDate(odd) Then
                            d = odd
                            odd = d.ToShortTimeString
                        End If
                        TimeSpan.TryParse(odd, p.odjazd)

                        If IsDate(doo) Then
                            d = doo
                            doo = d.ToShortTimeString
                        End If
                        TimeSpan.TryParse(doo, p.przyjazd)



                        If dt.Rows(i)("nazwakursu").ToString.ToLower = k.nazwakursu.ToString.ToLower Then
                            k.Przystanki.Add(p)
                        End If

                    End If

                    'Debug.Print(i)
                Next

            Next




        End If

        Dim m As New mongoDBCore





        m.InsertList(Of kursType)(kursy, "kursymatryca")




    End Function



    Public Shared Function Load() As List(Of kursType)


        Dim m As New mongoDBCore



        Load = m.GetObjectList(Of kursType)("kursymatryca")




    End Function


    Public Shared Function Load(kodjednostki As String) As List(Of kursType)


        Dim m As New mongoDBCore

        Dim f As New Dictionary(Of String, Object)
        f.Add("Przystanki.kodjednostki", kodjednostki)

        Load = m.GetObjectList(Of kursType)("kursymatryca", f)




    End Function

End Class

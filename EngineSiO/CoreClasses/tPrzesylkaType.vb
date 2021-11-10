


<DebuggerDisplay("faza {Nazwa_fazy}")>
Public Class tPrzesylkaType
    Public lp As Integer
    Public Property _id As String
    Public Property Dzien As Date
    Public Property Nazwa_typu_przesylki As String
    Public Property Nazwa_serwisu As String
    Public Property swiadczenia As String
    Public Property Jednostki_fazy_Region As String
    Public Property Nazwa_jednostki As String
    Public Property Kod_jednostki As String
    Public Property PNI As String
    Public Property Nazwa_fazy As String
    Public Property Nazwa_rodzaju_fazy As String
    Public Property PNA_i_miejscowosc_adresata As String
    Public Property Identyfikator_przesylki As String
    Public Property Data_czas_nadania As DateTime
    Public Property Gwarantowany_termin_doręczenia As DateTime
    Public Property Planowy_data_czas_wejscia_Do_jednostki As DateTime
    Public Property Rzeczywisty_data_czas_wejscia_Do_jednostki As DateTime
    Public Property Planowy_data_czas_wyjscia_z_jednostki As DateTime
    Public Property Rzeczywisty_data_czas_wyjscia_z_jednostki As DateTime
    Public Property Terminowosc_fazy_dla_jednostki As Integer  '_[1-terminowa,_0-nieterminowa,_puste-brak_danych]  
    Public Property Terminowosc_E2E As Integer  '_[1-terminowa,_0-nieterminowa,_puste-brak_danych]  
    Public Property Sparametryzowana As Integer
    Public Property Data_czas_zdarzenia_konczacego_terminowosc_E2E As DateTime
    Public Property idkarta As String
    Public Property ID_MRUMC_klienta As String
    Public Property Kod_klienta_w_ZST As String
    Public Property Nazwa_klienta As String
    Public Property Klient_kluczowy As Integer
    Public Property Nazwa_zdarzenia_wejscia As String
    Public Property Nazwa_zdarzenia_wyjscia As String
    Public Property PNA_poczatek As String     '2cyfry PNA
    Public Property tydzien As String
    Public Property idlok As Integer
    Public Property Jednostka_nad As String
    Public Property Jednostka_nad_kod As String
    Public Property Jednostka_nad_PNA As String
    Public Property Jednostka_nad_kierunek As String
    Public Property Jednostka_nad_rozdzielnia As String
    Public Property Jednostka_dor_kierunek As String
    Public Property Jednostka_dor_PNA As String
    Public Property Jednostka_dor_rozdzielnia As String
    Public Property Jednostka_dor As String
    Public Property jednostka_dor_kod As String
    Public Property godzinaWE As Integer
    Public Property godzinaWY As Integer
    Public Property czassobslminut As Integer
    Public Property NSTD As Integer
    Public Property OPZ As Integer

    Public Property termin As String

    Public Property Poprawne_WE As Integer
    Public Property Poprawne_WY As Integer


    Public Shared Event OpenFileX(filename As String)
    Public Shared Event EndSavingFileX(rowcount As Integer)
    Public Shared Event LoadProgressX(current As Integer, all As Integer)
    Public Shared Event FileProgress(current As Integer, all As Integer, Percent As Double)


    Public Function CZasWjEdnostce() As String


        Try
            Dim ti As Integer = DateDiff(DateInterval.Minute, Me.Rzeczywisty_data_czas_wejscia_Do_jednostki, Me.Rzeczywisty_data_czas_wyjscia_z_jednostki)
            If ti < 0 Then ti = -ti

            Dim ts As TimeSpan = TimeSpan.FromMinutes(ti)
            Dim s1 As String = (ts.Days * 24) + ts.Hours
            Dim s2 As String = ts.Minutes

            If s1 < 10 Then s1 = "0" & s1
            If s2 < 10 Then s2 = "0" & s2

            If Me.Rzeczywisty_data_czas_wejscia_Do_jednostki = #1/1/0001 12:00:00 AM# Or Me.Rzeczywisty_data_czas_wyjscia_z_jednostki = #1/1/0001 12:00:00 AM# Then
                Return "bd."
            End If


            Return s1 & ":" & s2

        Catch ex As Exception
            Return "00:00"
        End Try


    End Function
    Sub New()
        Me._id = Guid.NewGuid.ToString
    End Sub

    Public Sub save()
        Dim m As New mongoDBCore
        m.Update(Of tPrzesylkaType)("tf", Me._id, Me)
    End Sub

    Shared Sub updateprogres(a As Integer, b As Integer)
        RaiseEvent LoadProgressX(a, b)
        Console.SetCursorPosition(0, row + 4)
        Console.Write(LSet("", 200))
        Console.SetCursorPosition(0, row + 4)
        Console.Write(a & "/" & b)
    End Sub
    Shared Sub OpenFile(filename As String)
        RaiseEvent OpenFileX(filename)
        Console.SetCursorPosition(0, row + 2)
        Console.Write(LSet("", 200))
        Console.SetCursorPosition(0, row + 2)
        Console.Write("Zapisuje plik: " & filename)
    End Sub
    Shared Sub EndSavingFile(rowcount As Integer)
        RaiseEvent EndSavingFileX(rowcount)
        Console.SetCursorPosition(0, row + 3)
        Console.Write(LSet("", 200))
        Console.SetCursorPosition(0, row + 3)
        Console.Write("Zakończono zapis pliku, wierszy: " & rowcount)
    End Sub
    Shared row As Integer = 0


    Shared Sub CheckDBProgres()
        Dim m As mySQLcore = mySQLcore.DB_Main
        If m.GetCount("select count(*) from progres where proces='TF'") = 0 Then
            m.ExecuteNonQuery("Insert into progres set proces='TF'")
        End If

    End Sub
    Shared Sub UpdateFileProgres(current As Integer, all As Integer, Percent As Double)
        RaiseEvent FileProgress(current, all, Percent)

        Dim m As mySQLcore = mySQLcore.DB_Main
        m.ExecuteNonQuery("Update progres set curent=" & current & " ,`all`=" & all & ", percent='" & Percent & "', updatetime='" & Now & "' where proces='TF';")

    End Sub

    Public Shared Function UploadFileRegionType(idlok As Integer, files As String())
        Dim currentIFile As Integer = 1
        Dim filesCount As Integer = files.Count
        Dim m As mySQLcore = mySQLcore.DB_Main


        Dim lkluczowi As New List(Of Integer)
        Dim lt As DataTable = m.FillDatatable("select idkarta from kluczowi;")
        For i = 0 To lt.Rows.Count - 1
            lkluczowi.Add(lt.Rows(i)(0))
        Next

        Dim rtro As New xlsWorker.RTR

        For Each pathfilexls In files



            Console.SetCursorPosition(0, row)
            Console.Write(LSet("", 200))
            Console.SetCursorPosition(0, row)
            Console.WriteLine("Start: " & Now & " " & pathfilexls)

            CheckDBProgres()

            Dim per As Double
            Try
                per = currentIFile / filesCount
                per = Math.Round(per, 2)
            Catch ex As Exception

            End Try
            UpdateFileProgres(currentIFile, filesCount, per)

            Dim imppat As String = System.IO.Path.GetDirectoryName(pathfilexls)
            imppat = imppat & "\imported\"
            If Not System.IO.Directory.Exists(imppat) Then
                System.IO.Directory.CreateDirectory(imppat)
            End If



            Dim w As String
            'Dim csvpath As String = xlsWorker.SavetoCSV(pathfilexls, "^")
            'Dim dt As DataTable = ConvertCore.csvToDatatable(csvpath, "^")

            AddHandler xlsWorker.LoadProgress, AddressOf updateprogres
            AddHandler xlsWorker.OpenFile, AddressOf OpenFile
            AddHandler xlsWorker.EndSavingFile, AddressOf EndSavingFile


            rtro = xlsWorker.ExcelToTprzesylkaListSubObjects(pathfilexls, idlok, lkluczowi)

            If Not IsNothing(rtro.region) Then
                Try
                    FileCopy(pathfilexls, imppat & System.IO.Path.GetFileName(pathfilexls))
                    Kill(pathfilexls)
                Catch ex As Exception

                End Try
            End If



            Console.SetCursorPosition(0, row + 5)
            Console.Write(LSet("", 200))
            Console.SetCursorPosition(0, row + 5)
            Console.WriteLine("Start: " & Now)
            Console.WriteLine("Stop: " & Now)

            row += 8

            'per file
            'Try
            '    tfObrot(rtro)
            'Catch ex As Exception

            'End Try
            'Try
            '    HourSums(rtro.rok, rtro.tydzien, rtro.region)
            'Catch ex As Exception

            'End Try
            'Try
            '    tPrzesylkaType.UpdatetfSums(rtro.region, rtro.tydzien, rtro.rok)
            'Catch ex As Exception

            'End Try

            currentIFile += 1
        Next

        'per all
        'tPrzesylkaType.UpdateDistinctLISTAUPTYPE()




    End Function


    Public Shared Function UploadFile(idlok As Integer, files As String())
        Dim currentIFile As Integer = 1
        Dim filesCount As Integer = files.Count
        Dim m As mySQLcore = mySQLcore.DB_Main


        Dim lkluczowi As New List(Of Integer)
        Dim lt As DataTable = m.FillDatatable("select idkarta from kluczowi;")
        For i = 0 To lt.Rows.Count - 1
            lkluczowi.Add(lt.Rows(i)(0))
        Next

        Dim rtro As New xlsWorker.RTR

        For Each pathfilexls In files



            Console.SetCursorPosition(0, row)
            Console.Write(LSet("", 200))
            Console.SetCursorPosition(0, row)
            Console.WriteLine("Start: " & Now & " " & pathfilexls)

            CheckDBProgres()

            Dim per As Double
            Try
                per = currentIFile / filesCount
                per = Math.Round(per, 2)
            Catch ex As Exception

            End Try
            UpdateFileProgres(currentIFile, filesCount, per)

            Dim imppat As String = System.IO.Path.GetDirectoryName(pathfilexls)
            imppat = imppat & "\imported\"
            If Not System.IO.Directory.Exists(imppat) Then
                System.IO.Directory.CreateDirectory(imppat)
            End If



            Dim w As String
            'Dim csvpath As String = xlsWorker.SavetoCSV(pathfilexls, "^")
            'Dim dt As DataTable = ConvertCore.csvToDatatable(csvpath, "^")

            AddHandler xlsWorker.LoadProgress, AddressOf updateprogres
            AddHandler xlsWorker.OpenFile, AddressOf OpenFile
            AddHandler xlsWorker.EndSavingFile, AddressOf EndSavingFile


            rtro = xlsWorker.ExcelToTprzesylkaList(pathfilexls, idlok, lkluczowi)

            If Not IsNothing(rtro.region) Then
                Try
                    FileCopy(pathfilexls, imppat & System.IO.Path.GetFileName(pathfilexls))
                    Kill(pathfilexls)
                Catch ex As Exception

                End Try
            End If



            Console.SetCursorPosition(0, row + 5)
            Console.Write(LSet("", 200))
            Console.SetCursorPosition(0, row + 5)
            Console.WriteLine("Start: " & Now)
            Console.WriteLine("Stop: " & Now)

            row += 8

            'per file
            Try
                tfObrot(rtro)
            Catch ex As Exception

            End Try
            Try
                HourSums(rtro.rok, rtro.tydzien, rtro.region)
            Catch ex As Exception

            End Try
            Try
                tPrzesylkaType.UpdatetfSums(rtro.region, rtro.tydzien, rtro.rok)
            Catch ex As Exception

            End Try

            currentIFile += 1
        Next

        'per all
        tPrzesylkaType.UpdateDistinctLISTAUPTYPE()




    End Function
    Public Shared Function tfObrot(rtr As xlsWorker.RTR)
        Dim m As mySQLcore = mySQLcore.DB_Main
        m.ExecuteNonQuery("delete from tfobrot  where region='" & rtr.region & "' and rok=" & rtr.rok & " and tydzien=" & rtr.tydzien & ";")

        Dim l As New List(Of Object)

        For Each r In rtr.DistinctID
            Dim o As New tfobrot
            o.region = rtr.region
            o.tydzien = rtr.tydzien
            o.pni = r.pni
            o.dzien = r.dzien
            o.lp = r.lp.Count
            o.rok = rtr.rok
            l.Add(o)

        Next
        m.InsertList("tfobrot", "id", l)

    End Function
    Public Shared Sub HourSums(rok As String, tydzien As Integer, region As String)
        Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.PipeHourSums(region, tydzien, rok), "tf")

        Dim m As mySQLcore = mySQLcore.DB_Main

        m.ExecuteNonQuery("delete from tfhoursums where region='" & region & "' and rok=" & rok & " and tydzien=" & tydzien & ";")

        Dim l As New List(Of Object)

        For i = 0 To dt.Rows.Count - 1
            Dim o As New tfhoursums
            o.region = dt.Rows(i)(0)
            o.pni = dt.Rows(i)(1)
            o.tydzien = dt.Rows(i)(2)
            o.dzien = dt.Rows(i)(3)
            o.faza = dt.Rows(i)(4)
            o.typP = dt.Rows(i)(5)
            o.godzinaWE = dt.Rows(i)(6)
            o.godzinaWY = dt.Rows(i)(7)
            o.wszystkie = dt.Rows(i)(8)
            o.terminowefaza = dt.Rows(i)(9)
            o.terminoweE2e = dt.Rows(i)(10)
            o.param = dt.Rows(i)(11)
            l.Add(o)
        Next
        m.InsertList("tfhoursums", "id", l)

    End Sub
    Public Shared Sub UpdatetfSums(region As String, tydzien As Integer, rok As Integer)



        Console.WriteLine("Aktualizacja danych sumarycznych " & Now)
        Dim m As mySQLcore = mySQLcore.DB_Main


        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("Dodano wierszy:")



        m.ExecuteNonQuery("delete from tfsummary where rok=" & rok & " and tydzien = " & tydzien & " and region='" & region & "';")

        Console.WriteLine(region)
        Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.PipeTerminowoscFAZ_Sumarycznie_Wg_Regionu_Ogolem(region, tydzien, rok), "tf")

        Dim l As New List(Of Object)
        For ii = 0 To dt.Rows.Count - 1



            Dim o As New tfsummary
            o.pni = dt.Rows(ii)(0)
            o.faza = dt.Rows(ii)(1)
            o.wszystkie = dt.Rows(ii)(2)
            o.tfaza = dt.Rows(ii)(3)
            o.tparam = dt.Rows(ii)(4)
            o.te2e = dt.Rows(ii)(5)
            o.tydzien = tydzien
            o.rok = rok
            o.region = region

            l.Add(o)
        Next
        m.InsertList("tfsummary", "id", l)

        Dim nd As Integer = tfnad(region, tydzien, rok)

        sb.AppendLine(LSet(region, 40) & "|" & LSet(l.Count, 10) & "|" & LSet(nd, 10) & "|")


        Console.WriteLine(sb.ToString)

        Console.WriteLine("Aktualizacja danych sumarycznych zakończona " & Now)
    End Sub
    Public Shared Sub UpdatetfSums(tydzien As Integer, rok As Integer)



        Console.WriteLine("Aktualizacja danych sumarycznych " & Now)
        Dim m As mySQLcore = mySQLcore.DB_Main



        Dim lregion As DataTable = m.FillDatatable("select distinct region from listaup")

        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("Dodano wierszy:")

        For i = 0 To lregion.Rows.Count - 1
            Dim region As String = lregion.Rows(i)(0)

            m.ExecuteNonQuery("delete from tfsummary where rok=" & rok & " and tydzien = " & tydzien & " and region='" & region & "';")

            Console.WriteLine(region)
            Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.PipeTerminowoscFAZ_Sumarycznie_Wg_Regionu_Ogolem(region, tydzien, rok), "tf")

            Dim l As New List(Of Object)
            For ii = 0 To dt.Rows.Count - 1



                Dim o As New tfsummary
                o.pni = dt.Rows(ii)(0)
                o.faza = dt.Rows(ii)(1)
                o.wszystkie = dt.Rows(ii)(2)
                o.tfaza = dt.Rows(ii)(3)
                o.tparam = dt.Rows(ii)(4)
                o.te2e = dt.Rows(ii)(5)
                o.tydzien = tydzien
                o.rok = rok
                o.region = region

                l.Add(o)
            Next
            m.InsertList("tfsummary", "id", l)

            Dim nd As Integer = tfnad(region, tydzien, rok)

            sb.AppendLine(LSet(region, 40) & "|" & LSet(l.Count, 10) & "|" & LSet(nd, 10) & "|")
        Next

        Console.WriteLine(sb.ToString)

        Console.WriteLine("Aktualizacja danych sumarycznych zakończona " & Now)
    End Sub

    Public Shared Function tfnad(region As String, tydzien As Integer, rok As Integer)
        Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.Pipetfnad(region, tydzien, rok), "tf")
        Dim m As mySQLcore = mySQLcore.DB_Main
        m.ExecuteNonQuery("delete from tfnad where rok=" & rok & " and tydzien = " & tydzien & " and region='" & region & "';")
        Dim l As New List(Of Object)

        For i = 0 To dt.Rows.Count - 1
            Dim o As New tfnad
            o.dzien = dt.Rows(i)(3)
            If Not String.IsNullOrEmpty(dt.Rows(i)(5).ToString) Then o.karta = dt.Rows(i)(5)
            o.lp = dt.Rows(i)(6)
            o.pni = dt.Rows(i)(1)
            o.region = dt.Rows(i)(0)
            o.typp = dt.Rows(i)(4)
            o.tydzien = dt.Rows(i)(2)
            l.Add(o)
        Next
        m.InsertList("tfnad", "id", l)

        Return l.Count
    End Function
    Public Shared Sub UpdateDistinctLISTAUPTYPE()
        Console.WriteLine("Aktualizacja listy UP " & Now)
        Dim dt As DataTable = MongoDBReportsCore.GetReport(MongoDBReportsCore.PipeDistinct("Nazwa_jednostki", "PNI", "Jednostki_fazy_Region", "Kod_jednostki"), "tf")
        Console.WriteLine("Analiza listy UP " & Now)
        Dim l As New List(Of Object)
        Dim m As mySQLcore = mySQLcore.DB_Main
        For i = 0 To dt.Rows.Count - 1
            Dim o As New ListaUPtype
            o.UP = dt.Rows(i)("Nazwa_jednostki")
            o.REGION = dt.Rows(i)("Jednostki_fazy_Region")
            o.PNI = dt.Rows(i)("PNI")
            o.KOD = dt.Rows(i)("Kod_jednostki")

            If m.GetCount("Select count(*) from listaup where up='" & o.UP & "';") = 0 Then
                l.Add(o)
            End If

        Next

        m.InsertList("listaup", "id", l)
        Console.WriteLine("Dodano rekordów:" & l.Count)




    End Sub
    Public Shared Function tfimportlog(exmsg As String, file As String)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Try
            m.ExecuteNonQuery("insert into tfimportlog (time,ex,file) VALUES ('" & Now & "','" & exmsg & "','" & file & "')")
        Catch ex As Exception

        End Try
    End Function
    Public Shared Function GetPrzesylka(filters As Dictionary(Of String, Object)) As tPrzesylkaType
        Dim m As New mongoDBCore

        Dim tp As tPrzesylkaType = m.GetSingleObject(Of tPrzesylkaType)("tf", filters)
        If IsNothing(tp) Then tp = New tPrzesylkaType

        Return tp

    End Function


    Public Shared Event RowImported(rowcount As Integer, parcel As tPrzesylkaType)

End Class

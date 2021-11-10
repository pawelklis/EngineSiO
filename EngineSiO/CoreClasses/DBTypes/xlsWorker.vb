Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Text.RegularExpressions
Imports DocumentFormat.OpenXml
Imports ClosedXML.Excel


Public Class xlsWorker


    Public Shared Event OpenFile(filename As String)
    Public Shared Event SavingFile()
    Public Shared Event EndSavingFile(rowcount As Integer)
    Public Shared Event LoadProgress(current As Integer, all As Integer)


    Public Shared Function ExcelToDS(ByVal Path As String, ByVal sheetname As String) As DataSet
        Dim xlsConn As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" _
                    + (Path + ";Extended Properties=Excel 8.0;"))
        Dim xlsxConn As String = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" _
                    + (Path + ";Extended Properties=Excel 12.0"))
        Dim conn As OleDbConnection = New OleDbConnection(xlsxConn)
        conn.Open()
        Dim strExcel As String = ("select * from [" _
                    + (sheetname + "$]"))
        Dim oledbda As OleDbDataAdapter = New OleDbDataAdapter(strExcel, xlsxConn)
        Dim ds As DataSet = New DataSet
        oledbda.Fill(ds, sheetname)
        conn.Close()
        Return ds
    End Function

    Public Shared Function ExcelToDSOLEDB(FileName As String) As DataSet
        Dim ds As New DataSet

        'Console.Clear()

        Dim Format As String = ""
        If IO.Path.GetExtension(FileName) = ".xls" Then
            Format = "Excel 8.0"
        ElseIf IO.Path.GetExtension(FileName) = ".xlsx" Then
            Format = "Excel 12.0"
        End If

        Dim constr As String = String.Format("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & FileName & "';Extended Properties='" & Format & ";HDR=YES;IMEX=1;'")

        Using Connection As New OleDb.OleDbConnection(constr)
            Connection.Open()
            Dim a = Connection.GetSchema("Tables")
            For i = 0 To a.Rows.Count - 1
                Dim DataTable As New DataTable
                Dim TableName As String = Connection.GetSchema("Tables").Rows(i)("TABLE_NAME")

                Dim SQLCommand As New System.Text.StringBuilder
                SQLCommand.AppendLine("SELECT *")
                SQLCommand.AppendLine("FROM [{0}]")

                Dim Command As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(String.Format(SQLCommand.ToString, TableName), Connection)

                Command.Fill(DataTable)
                DataTable.TableName = TableName
                ds.Tables.Add(DataTable)
            Next

            If a.Rows.Count = 0 Then
                Dim Command As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select * from [Sheet1$]", Connection)
                Dim DataTable As New DataTable

                Command.Fill(DataTable)
                DataTable.TableName = "Sheet1"
                ds.Tables.Add(DataTable)
            End If

            Connection.Close()
        End Using




        Return ds
    End Function


    Public Shared Function HtmlXlstoDT(filename As String) As DataTable
        Dim ds As DataSet = HTML_DO_DATASET(filename)
        Return ds.Tables(0)
    End Function

    Public Shared Function SavetoCSV(FileName As String, separator As String) As String
        Dim csvFilename As String = FileName.Replace("xlsx", "csv")
        RaiseEvent OpenFile(FileName)
        Dim workBook As New XLWorkbook(FileName)
        RaiseEvent SavingFile()
        Dim worksheet = workBook.Worksheets(0)
        File.WriteAllLines(csvFilename, worksheet.RowsUsed().[Select](Function(row) String.Join(separator, row.Cells(1, row.LastCellUsed(False).Address.ColumnNumber).[Select](Function(cell) cell.GetValue(Of String)()))), System.Text.Encoding.GetEncoding(1250))
        workBook = Nothing
        RaiseEvent EndSavingFile(0)
        Return csvFilename

    End Function

    Public Class RTR
        Public Property region As String
        Public Property rok As Integer
        Public Property tydzien As Integer
        Public Property DistinctID As List(Of Statday)


        Public Sub AddValue(pni As Integer, day As Date, identyfikator_przesylki As String)
ss:
            Dim pniok As Boolean = False
            Dim dayok As Boolean = False
            For Each o In Me.DistinctID
                If o.pni = pni Then
                    pniok = True
                    If o.dzien = day Then
                        dayok = True
                        If Not o.lp.Contains(identyfikator_przesylki) Then
                            o.lp.Add(identyfikator_przesylki)
                        End If
                    End If
                End If
            Next

            If pniok = False Then
                Dim o As New Statday
                o.pni = pni
                o.dzien = day
                Me.DistinctID.Add(o)
                GoTo ss
            End If
            If dayok = False Then
                Dim o As New Statday
                o.pni = pni
                o.dzien = day
                Me.DistinctID.Add(o)
                GoTo ss
            End If

        End Sub

        Public Class Statday
            Sub New()
                Me.lp = New List(Of String)
            End Sub
            Public Property pni As Integer
            Public Property dzien As Date
            Public Property lp As List(Of String)
        End Class
    End Class

    Public Shared Function ExcelToTprzesylkaListSubObjects(filename As String, idlok As Integer, lkluczowi As List(Of Integer)) As RTR
        Dim sektorList As List(Of AdresSektorType) = AdresSektorType.GetList
        Dim m As New mongoDBCore
        Dim rtr As New RTR
        rtr.DistinctID = New List(Of RTR.Statday)

        Dim ListOfEvents As List(Of TFgoodEventsType) = TFgoodEventsType.GetList

        RaiseEvent OpenFile(filename)

        Dim l As New List(Of tPrzesylkaType)
        RaiseEvent OpenFile(filename)
        Dim dt As DataTable

        Dim a As Integer = -1

        Dim terminy As List(Of terminytype) = terminytype.Load



        Try
            dt = ExcelToDSOLEDB(filename).Tables(0)
        Catch ex As Exception
            Console.WriteLine("No OLeBD Access DataDriver " & ex.ToString)
            tPrzesylkaType.tfimportlog(ex.ToString, filename)
        End Try

        If Not IsNothing(dt) Then
            a = dt.Rows.Count - 1
        End If

        Dim deleted As Boolean = False

        If a > 0 Then
            Try



                RaiseEvent EndSavingFile(a)

                Dim firstline As Boolean = True
                Dim ii As Integer = 0
                For i = 0 To dt.Rows.Count - 1
                    'If firstline = True Then
                    '    firstline = False

                    'Else
                    Try
                        Dim tp As New tPrzesylkaType

                        Dim test = dt.Rows(i)(12).ToString ' row.Cell("M").Value

                        With tp
                            .idlok = idlok

                            If IsDate(dt.Rows(i)(12).ToString) Then .Data_czas_nadania = dt.Rows(i)(12).ToString '
                            If IsDate(dt.Rows(i)(25).ToString) Then .Data_czas_zdarzenia_konczacego_terminowosc_E2E = dt.Rows(i)(25).ToString
                            If IsDate(dt.Rows(i)(0).ToString) Then .Dzien = dt.Rows(i)(0).ToString
                            If IsDate(dt.Rows(i)(13).ToString) Then .Gwarantowany_termin_doręczenia = dt.Rows(i)(13).ToString
                            If IsDate(dt.Rows(i)(14).ToString) Then .Planowy_data_czas_wejscia_Do_jednostki = dt.Rows(i)(14).ToString
                            If IsDate(dt.Rows(i)(16).ToString) Then .Planowy_data_czas_wyjscia_z_jednostki = dt.Rows(i)(16).ToString
                            If IsDate(dt.Rows(i)(15).ToString) Then .Rzeczywisty_data_czas_wejscia_Do_jednostki = dt.Rows(i)(15).ToString
                            If IsDate(dt.Rows(i)(17).ToString) Then .Rzeczywisty_data_czas_wyjscia_z_jednostki = dt.Rows(i)(17).ToString

                            .Identyfikator_przesylki = dt.Rows(i)(11).ToString
                            .idkarta = dt.Rows(i)(26).ToString
                            .ID_MRUMC_klienta = dt.Rows(i)(27).ToString
                            .Jednostki_fazy_Region = dt.Rows(i)(4).ToString
                            .Kod_jednostki = dt.Rows(i)(6).ToString
                            .Kod_klienta_w_ZST = dt.Rows(i)(28).ToString
                            .Nazwa_fazy = dt.Rows(i)(8).ToString
                            .Nazwa_jednostki = dt.Rows(i)(5).ToString
                            .Nazwa_klienta = dt.Rows(i)(29).ToString
                            .Nazwa_rodzaju_fazy = dt.Rows(i)(9).ToString
                            .Nazwa_serwisu = dt.Rows(i)(2).ToString
                            .Nazwa_typu_przesylki = dt.Rows(i)(1).ToString
                            .Nazwa_zdarzenia_wejscia = dt.Rows(i)(30).ToString
                            .Nazwa_zdarzenia_wyjscia = dt.Rows(i)(31).ToString

                            .PNA_i_miejscowosc_adresata = dt.Rows(i)(10).ToString
                            .PNI = dt.Rows(i)(7).ToString

                            .swiadczenia = dt.Rows(i)(3).ToString

                            'Debug.Print(row.Cell("Y").Value)
                            If String.IsNullOrEmpty(dt.Rows(i)(24).ToString) Then
                                .Terminowosc_E2E = 0
                            Else
                                .Terminowosc_E2E = dt.Rows(i)(24).ToString
                            End If

                            If String.IsNullOrEmpty(dt.Rows(i)(18).ToString) Then
                                .Terminowosc_fazy_dla_jednostki = 0
                                .Sparametryzowana = 0
                            Else
                                .Terminowosc_fazy_dla_jednostki = dt.Rows(i)(18).ToString
                                .Sparametryzowana = 1
                            End If

                            tp.Poprawne_WE = TFgoodEventsType.Check(tp.Jednostki_fazy_Region, tp.Nazwa_zdarzenia_wejscia, ListOfEvents, TFgoodEventsType.tfgio.wejscie, tp.Nazwa_fazy)
                            tp.Poprawne_WY = TFgoodEventsType.Check(tp.Jednostki_fazy_Region, tp.Nazwa_zdarzenia_wyjscia, ListOfEvents, TFgoodEventsType.tfgio.wyjscie, tp.Nazwa_fazy)


                        End With

                        Try
                            For Each t In terminy
                                If t.typp.ToLower.Replace(" ", "") = tp.Nazwa_typu_przesylki.ToLower.Replace(" ", "") Then
                                    tp.termin = t.termin
                                End If
                            Next
                        Catch ex As Exception

                        End Try




                        If String.IsNullOrEmpty(rtr.region) Then rtr.region = tp.Jednostki_fazy_Region
                        If rtr.rok = 0 Then rtr.rok = Year(tp.Dzien)


                        If tp.Terminowosc_fazy_dla_jednostki <> 0 And tp.Terminowosc_fazy_dla_jednostki <> 1 Then
                            tp.Terminowosc_fazy_dla_jednostki = 1
                        End If
                        If tp.Terminowosc_E2E <> 0 And tp.Terminowosc_E2E <> 1 Then
                            tp.Terminowosc_E2E = 1
                        End If

                        tp.godzinaWE = Hour(tp.Rzeczywisty_data_czas_wejscia_Do_jednostki)
                        tp.godzinaWY = Hour(tp.Rzeczywisty_data_czas_wyjscia_z_jednostki)

                        If tp.swiadczenia.Contains("OP-") Or tp.swiadczenia.Contains("OPZ-") Then tp.OPZ = 1
                        If tp.swiadczenia.Contains("NG-") Then
                            tp.NSTD = 1
                        End If

                        If String.IsNullOrEmpty(tp.idkarta) Then tp.idkarta = 0
                        If Not IsNumeric(tp.idkarta) Then tp.idkarta = 0
                        If lkluczowi.Contains(tp.idkarta) Then
                            tp.Klient_kluczowy = 1
                        Else
                            tp.Klient_kluczowy = 0
                        End If



                        Dim obsl As Integer
                        Try
                            obsl = DateDiff(DateInterval.Minute, tp.Rzeczywisty_data_czas_wejscia_Do_jednostki, tp.Rzeczywisty_data_czas_wyjscia_z_jednostki)

                        Catch ex As Exception

                        End Try
                        tp.czassobslminut = obsl

                        'If tp.Nazwa_fazy = "nadania" Then
                        '    tp.Jednostka_nad = tp.Nazwa_jednostki
                        '    tp.Jednostka_nad_kod = tp.Kod_jednostki

                        '    Dim ofl As New Dictionary(Of String, Object)
                        '    ofl.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)

                        '    Dim lpp As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", ofl)
                        '    If Not IsNothing(lpp) Then
                        '        For Each p In lpp
                        '            If p.Nazwa_fazy <> "nadania" Then
                        '                If String.IsNullOrEmpty(p.Jednostka_nad) Then
                        '                    p.Jednostka_nad = tp.Jednostka_nad
                        '                    p.Jednostka_nad_kod = tp.Kod_jednostki
                        '                    p.save()
                        '                End If
                        '            End If
                        '        Next
                        '    End If

                        'Else
                        '    Dim filters As New Dictionary(Of String, Object)
                        '    filters.Add("Nazwa_fazy", "nadania")
                        '    filters.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)
                        '    Dim opt As tPrzesylkaType = tPrzesylkaType.GetPrzesylka(filters)
                        '    tp.Jednostka_nad = opt.Nazwa_jednostki
                        '    tp.Jednostka_nad_kod = opt.Kod_jednostki
                        'End If




                        If Len(tp.PNA_i_miejscowosc_adresata) > 4 Then
                            tp.PNA_poczatek = tp.PNA_i_miejscowosc_adresata.Substring(0, 5)
                        Else
                            tp.PNA_poczatek = ""
                        End If

                        Dim WeekNumber As Integer = DatePart(DateInterval.WeekOfYear, tp.Dzien, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFourDays)

                        tp.tydzien = "Tydzien " & WeekNumber & " " & Year(tp.Dzien)
                        If rtr.tydzien = 0 Then rtr.tydzien = WeekNumber

                        Dim adr As AdresSektorType = AdresSektorType.GetSektor(tp.PNA_i_miejscowosc_adresata, sektorList)
                        tp.Jednostka_dor_kierunek = adr.Kierunek
                        tp.Jednostka_dor_rozdzielnia = adr.Rozdzielnia
                        tp.Jednostka_dor_PNA = adr.PNA3

                        adr = AdresSektorType.GetSektor(tp.Jednostka_nad_kod, sektorList)
                        If Not IsNothing(adr) Then
                            tp.Jednostka_nad_PNA = adr.Kierunek
                            tp.Jednostka_nad_rozdzielnia = adr.Rozdzielnia
                            tp.Jednostka_nad_PNA = adr.PNA3
                        End If

                        'If tp.Nazwa_fazy = "doręczenia" Then
                        '    tp.Jednostka_dor = tp.Nazwa_jednostki
                        '    tp.jednostka_dor_kod = tp.Kod_jednostki

                        '    Dim ofl As New Dictionary(Of String, Object)
                        '    ofl.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)

                        '    Dim lpp As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", ofl)
                        '    If Not IsNothing(lpp) Then
                        '        For Each p In lpp
                        '            If p.Nazwa_fazy <> "doręczenia" Then
                        '                If String.IsNullOrEmpty(p.Jednostka_nad) Then
                        '                    p.Jednostka_dor = tp.Jednostka_dor
                        '                    p.jednostka_dor_kod = tp.jednostka_dor_kod
                        '                    p.save()
                        '                End If
                        '            End If
                        '        Next
                        '    End If

                        'Else
                        '    Dim filters As New Dictionary(Of String, Object)
                        '    filters.Add("Nazwa_fazy", "doręczenia")
                        '    filters.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)
                        '    Dim opt As tPrzesylkaType = tPrzesylkaType.GetPrzesylka(filters)
                        '    tp.Jednostka_dor = opt.Nazwa_jednostki
                        '    tp.jednostka_dor_kod = opt.Kod_jednostki
                        'End If



                        Try
                            If deleted = False Then
                                Console.WriteLine()
                                Console.WriteLine("Usuwanie " & tp.tydzien)
                                Dim f As New Dictionary(Of String, Object)

                                Dim kastydz As Integer = DatePart(DateInterval.WeekOfYear, tp.Dzien.AddDays(-14),
        FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFourDays)
                                Dim kasrok As Integer = Year(tp.Dzien.AddDays(-14))

                                f.Add("Tydzien", "Tydzien " & kastydz & " " & kasrok)
                                f.Add("Region", tp.Jednostki_fazy_Region)

                                Console.WriteLine("Usunięto wierszy: " & mongoDBCore.Delete("tfdata", f))
                                deleted = True
                            End If
                        Catch ex As Exception

                        End Try




                        Dim fl As New Dictionary(Of String, Object)
                        fl.Add("Region", tp.Jednostki_fazy_Region)
                        fl.Add("Tydzien", tp.tydzien)
                        Dim ifexists As tPrzesylkaType = m.GetSingleObject(Of tPrzesylkaType)("tfdata", fl)
                        If Not IsNothing(ifexists) Then
                            m.Delete(Of tPrzesylkaType)("tfdata", ifexists)
                        End If


                        RaiseEvent LoadProgress(ii, a)

                        rtr.AddValue(tp.PNI, tp.Dzien, tp.Identyfikator_przesylki)
                        l.Add(tp)
                        If l.Count > 5000 Then
                            ' Polacz.InsertList("tf", "id", l)
                            'm.InsertList(Of List(Of tPrzesylkaType))(l, "tf")
                            'l.Clear()

                            'Console.WriteLine("Rows inserted")
                        End If

                    Catch ex As Exception
                        ' w & vbNewLine & " błąd przesyłki: " & dt.Rows(i)("Identyfikator przesyłki").ToString & " ex:" & ex.ToString
                        tPrzesylkaType.tfimportlog(ex.ToString, filename)
                    End Try

                    'RaiseEvent LoadProgress(ii, a)
                    ii += 1
                    'End If




                Next

                ' m.InsertList(Of List(Of tPrzesylkaType))(l, "tf")
                ' l.Clear()

                dt = Nothing

            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                tPrzesylkaType.tfimportlog(ex.ToString, filename)
            End Try




            Dim joDistinct As List(Of String) = (From o In l
                                                 Select o.Nazwa_jednostki Distinct).ToList

            For Each jo In joDistinct


                Dim tfjo As New tfJednostkaDataType
                tfjo.Nazwa = jo
                tfjo.Tydzien = (From o In l
                                Where o.Nazwa_jednostki = jo
                                Select o.tydzien).ToList(0)

                tfjo.Region = (From o In l
                               Where o.Nazwa_jednostki = jo
                               Select o.Jednostki_fazy_Region).ToList(0)


                'Dim fnadania As New tfJednostkaDataType.FazaType
                'With fnadania
                '    .NazwaFazy = "nadania"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "nadania" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "nadania" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "nadania" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fnadania)
                'End With

                'Dim fzbiórkowa As New tfJednostkaDataType.FazaType
                'With fzbiórkowa
                '    .NazwaFazy = "zbiórkowa"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "zbiórkowa" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "zbiórkowa" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "zbiórkowa" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fzbiórkowa)
                'End With

                'Dim fkoncentracji As New tfJednostkaDataType.FazaType
                'With fkoncentracji
                '    .NazwaFazy = "koncentracji"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "koncentracji" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "koncentracji" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "koncentracji" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fkoncentracji)
                'End With

                'Dim fprzewozu As New tfJednostkaDataType.FazaType
                'With fprzewozu
                '    .NazwaFazy = "przewozu"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "przewozu" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "przewozu" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "przewozu" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fprzewozu)
                'End With

                'Dim fdekoncentracji As New tfJednostkaDataType.FazaType
                'With fdekoncentracji
                '    .NazwaFazy = "dekoncentracji"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "dekoncentracji" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "dekoncentracji" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "dekoncentracji" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fdekoncentracji)
                'End With

                'Dim frozwózki As New tfJednostkaDataType.FazaType
                'With frozwózki
                '    .NazwaFazy = "rozwózki"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "rozwózki" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "rozwózki" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "rozwózki" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(frozwózki)
                'End With

                'Dim fdoreczenia As New tfJednostkaDataType.FazaType
                'With fdoreczenia
                '    .NazwaFazy = "doręczenia"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "doręczenia" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "doręczenia" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "doręczenia" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fdoreczenia)
                'End With

                'Dim fnieokreslona As New tfJednostkaDataType.FazaType
                'With fnieokreslona
                '    .NazwaFazy = "nieokreślona"
                '    .Terminowe = (From o In l
                '                  Where o.Nazwa_fazy = "nieokreślona" And o.Terminowosc_fazy_dla_jednostki = 1 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                  Select o).ToList

                '    .Nieterminowe = (From o In l
                '                     Where o.Nazwa_fazy = "nieokreślona" And o.Terminowosc_fazy_dla_jednostki = 0 And o.Sparametryzowana = 1 And o.Nazwa_jednostki = jo
                '                     Select o).ToList

                '    .Niesparametryzowane = (From o In l
                '                            Where o.Nazwa_fazy = "nieokreślona" And o.Sparametryzowana = 0 And o.Nazwa_jednostki = jo
                '                            Select o).ToList

                '    tfjo.Fazy.Add(fnieokreslona)
                'End With





                m.Insert(Of tfJednostkaDataType)("tfdata", tfjo)
                Console.WriteLine("Insert " & jo)
            Next







        Else
            Console.WriteLine("Błąd. nie zaimportowano pliku!")
            tPrzesylkaType.tfimportlog("Nie zaimportowano pliki, xlsworker, exceltotpprzesylkalist - dt.rows =0 lub nothing w linii:180", filename)

        End If









        Return rtr

    End Function

    Public Shared Function ExcelToTprzesylkaList(filename As String, idlok As Integer, lkluczowi As List(Of Integer)) As RTR
        Dim sektorList As List(Of AdresSektorType) = AdresSektorType.GetList
        Dim m As New mongoDBCore
        Dim rtr As New RTR
        rtr.DistinctID = New List(Of RTR.Statday)

        Dim ListOfEvents As List(Of TFgoodEventsType) = TFgoodEventsType.GetList

        RaiseEvent OpenFile(filename)

        Dim l As New List(Of Object)
        RaiseEvent OpenFile(filename)
        Dim dt As DataTable

        Dim a As Integer = -1

        Dim terminy As List(Of terminytype) = terminytype.Load



        Try
            dt = ExcelToDSOLEDB(filename).Tables(0)
        Catch ex As Exception
            Console.WriteLine("No OLeBD Access DataDriver " & ex.ToString)
            tPrzesylkaType.tfimportlog(ex.ToString, filename)
        End Try

        If Not IsNothing(dt) Then
            a = dt.Rows.Count - 1
        End If

        Dim deleted As Boolean = False

        If a > 0 Then
            Try



                RaiseEvent EndSavingFile(a)

                Dim firstline As Boolean = True
                Dim ii As Integer = 0
                For i = 0 To dt.Rows.Count - 1
                    'If firstline = True Then
                    '    firstline = False

                    'Else
                    Try
                        Dim tp As New tPrzesylkaType

                        Dim test = dt.Rows(i)(12).ToString ' row.Cell("M").Value

                        With tp
                            .idlok = idlok

                            If IsDate(dt.Rows(i)(12).ToString) Then .Data_czas_nadania = dt.Rows(i)(12).ToString '
                            If IsDate(dt.Rows(i)(25).ToString) Then .Data_czas_zdarzenia_konczacego_terminowosc_E2E = dt.Rows(i)(25).ToString
                            If IsDate(dt.Rows(i)(0).ToString) Then .Dzien = dt.Rows(i)(0).ToString
                            If IsDate(dt.Rows(i)(13).ToString) Then .Gwarantowany_termin_doręczenia = dt.Rows(i)(13).ToString
                            If IsDate(dt.Rows(i)(14).ToString) Then .Planowy_data_czas_wejscia_Do_jednostki = dt.Rows(i)(14).ToString
                            If IsDate(dt.Rows(i)(16).ToString) Then .Planowy_data_czas_wyjscia_z_jednostki = dt.Rows(i)(16).ToString
                            If IsDate(dt.Rows(i)(15).ToString) Then .Rzeczywisty_data_czas_wejscia_Do_jednostki = dt.Rows(i)(15).ToString
                            If IsDate(dt.Rows(i)(17).ToString) Then .Rzeczywisty_data_czas_wyjscia_z_jednostki = dt.Rows(i)(17).ToString

                            .Identyfikator_przesylki = dt.Rows(i)(11).ToString
                            .idkarta = dt.Rows(i)(26).ToString
                            .ID_MRUMC_klienta = dt.Rows(i)(27).ToString
                            .Jednostki_fazy_Region = dt.Rows(i)(4).ToString
                            .Kod_jednostki = dt.Rows(i)(6).ToString
                            .Kod_klienta_w_ZST = dt.Rows(i)(28).ToString
                            .Nazwa_fazy = dt.Rows(i)(8).ToString
                            .Nazwa_jednostki = dt.Rows(i)(5).ToString
                            .Nazwa_klienta = dt.Rows(i)(29).ToString
                            .Nazwa_rodzaju_fazy = dt.Rows(i)(9).ToString
                            .Nazwa_serwisu = dt.Rows(i)(2).ToString
                            .Nazwa_typu_przesylki = dt.Rows(i)(1).ToString
                            .Nazwa_zdarzenia_wejscia = dt.Rows(i)(30).ToString
                            .Nazwa_zdarzenia_wyjscia = dt.Rows(i)(31).ToString

                            .PNA_i_miejscowosc_adresata = dt.Rows(i)(10).ToString
                            .PNI = dt.Rows(i)(7).ToString

                            .swiadczenia = dt.Rows(i)(3).ToString

                            'Debug.Print(row.Cell("Y").Value)
                            If String.IsNullOrEmpty(dt.Rows(i)(24).ToString) Then
                                .Terminowosc_E2E = 0
                            Else
                                .Terminowosc_E2E = dt.Rows(i)(24).ToString
                            End If

                            If String.IsNullOrEmpty(dt.Rows(i)(18).ToString) Then
                                .Terminowosc_fazy_dla_jednostki = 0
                                .Sparametryzowana = 0
                            Else
                                .Terminowosc_fazy_dla_jednostki = dt.Rows(i)(18).ToString
                                .Sparametryzowana = 1
                            End If

                            tp.Poprawne_WE = TFgoodEventsType.Check(tp.Jednostki_fazy_Region, tp.Nazwa_zdarzenia_wejscia, ListOfEvents, TFgoodEventsType.tfgio.wejscie, tp.Nazwa_fazy)
                            tp.Poprawne_WY = TFgoodEventsType.Check(tp.Jednostki_fazy_Region, tp.Nazwa_zdarzenia_wyjscia, ListOfEvents, TFgoodEventsType.tfgio.wyjscie, tp.Nazwa_fazy)


                        End With

                        Try
                            For Each t In terminy
                                If t.typp.ToLower.Replace(" ", "") = tp.Nazwa_typu_przesylki.ToLower.Replace(" ", "") Then
                                    tp.termin = t.termin
                                End If
                            Next
                        Catch ex As Exception

                        End Try




                        If String.IsNullOrEmpty(rtr.region) Then rtr.region = tp.Jednostki_fazy_Region
                        If rtr.rok = 0 Then rtr.rok = Year(tp.Dzien)


                        If tp.Terminowosc_fazy_dla_jednostki <> 0 And tp.Terminowosc_fazy_dla_jednostki <> 1 Then
                            tp.Terminowosc_fazy_dla_jednostki = 1
                        End If
                        If tp.Terminowosc_E2E <> 0 And tp.Terminowosc_E2E <> 1 Then
                            tp.Terminowosc_E2E = 1
                        End If

                        tp.godzinaWE = Hour(tp.Rzeczywisty_data_czas_wejscia_Do_jednostki)
                        tp.godzinaWY = Hour(tp.Rzeczywisty_data_czas_wyjscia_z_jednostki)

                        If tp.swiadczenia.Contains("OP-") Or tp.swiadczenia.Contains("OPZ-") Then tp.OPZ = 1
                        If tp.swiadczenia.Contains("NG-") Then
                            tp.NSTD = 1
                        End If

                        If String.IsNullOrEmpty(tp.idkarta) Then tp.idkarta = 0
                        If Not IsNumeric(tp.idkarta) Then tp.idkarta = 0
                        If lkluczowi.Contains(tp.idkarta) Then
                            tp.Klient_kluczowy = 1
                        Else
                            tp.Klient_kluczowy = 0
                        End If



                        Dim obsl As Integer
                        Try
                            obsl = DateDiff(DateInterval.Minute, tp.Rzeczywisty_data_czas_wejscia_Do_jednostki, tp.Rzeczywisty_data_czas_wyjscia_z_jednostki)

                        Catch ex As Exception

                        End Try
                        tp.czassobslminut = obsl

                        If tp.Nazwa_fazy = "nadania" Then
                            tp.Jednostka_nad = tp.Nazwa_jednostki
                            tp.Jednostka_nad_kod = tp.Kod_jednostki

                            Dim ofl As New Dictionary(Of String, Object)
                            ofl.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)

                            Dim lpp As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", ofl)
                            If Not IsNothing(lpp) Then
                                For Each p In lpp
                                    If p.Nazwa_fazy <> "nadania" Then
                                        If String.IsNullOrEmpty(p.Jednostka_nad) Then
                                            p.Jednostka_nad = tp.Jednostka_nad
                                            p.Jednostka_nad_kod = tp.Kod_jednostki
                                            p.save()
                                        End If
                                    End If
                                Next
                            End If

                        Else
                            Dim filters As New Dictionary(Of String, Object)
                            filters.Add("Nazwa_fazy", "nadania")
                            filters.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)
                            Dim opt As tPrzesylkaType = tPrzesylkaType.GetPrzesylka(filters)
                            tp.Jednostka_nad = opt.Nazwa_jednostki
                            tp.Jednostka_nad_kod = opt.Kod_jednostki
                        End If




                        If Len(tp.PNA_i_miejscowosc_adresata) > 4 Then
                            tp.PNA_poczatek = tp.PNA_i_miejscowosc_adresata.Substring(0, 5)
                        Else
                            tp.PNA_poczatek = ""
                        End If

                        Dim WeekNumber As Integer = DatePart(DateInterval.WeekOfYear, tp.Dzien, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFourDays)

                        tp.tydzien = "Tydzien " & WeekNumber & " " & Year(tp.Dzien)
                        If rtr.tydzien = 0 Then rtr.tydzien = WeekNumber

                        Dim adr As AdresSektorType = AdresSektorType.GetSektor(tp.PNA_i_miejscowosc_adresata, sektorList)
                        tp.Jednostka_dor_kierunek = adr.Kierunek
                        tp.Jednostka_dor_rozdzielnia = adr.Rozdzielnia
                        tp.Jednostka_dor_PNA = adr.PNA3

                        adr = AdresSektorType.GetSektor(tp.Jednostka_nad_kod, sektorList)
                        If Not IsNothing(adr) Then
                            tp.Jednostka_nad_PNA = adr.Kierunek
                            tp.Jednostka_nad_rozdzielnia = adr.Rozdzielnia
                            tp.Jednostka_nad_PNA = adr.PNA3
                        End If

                        If tp.Nazwa_fazy = "doręczenia" Then
                            tp.Jednostka_dor = tp.Nazwa_jednostki
                            tp.jednostka_dor_kod = tp.Kod_jednostki

                            Dim ofl As New Dictionary(Of String, Object)
                            ofl.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)

                            Dim lpp As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", ofl)
                            If Not IsNothing(lpp) Then
                                For Each p In lpp
                                    If p.Nazwa_fazy <> "doręczenia" Then
                                        If String.IsNullOrEmpty(p.Jednostka_nad) Then
                                            p.Jednostka_dor = tp.Jednostka_dor
                                            p.jednostka_dor_kod = tp.jednostka_dor_kod
                                            p.save()
                                        End If
                                    End If
                                Next
                            End If

                        Else
                            Dim filters As New Dictionary(Of String, Object)
                            filters.Add("Nazwa_fazy", "doręczenia")
                            filters.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)
                            Dim opt As tPrzesylkaType = tPrzesylkaType.GetPrzesylka(filters)
                            tp.Jednostka_dor = opt.Nazwa_jednostki
                            tp.jednostka_dor_kod = opt.Kod_jednostki
                        End If



                        Try
                            If deleted = False Then
                                Console.WriteLine()
                                Console.WriteLine("Usuwanie " & tp.tydzien)
                                Dim f As New Dictionary(Of String, Object)

                                Dim kastydz As Integer = DatePart(DateInterval.WeekOfYear, tp.Dzien.AddDays(-14),
        FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFourDays)
                                Dim kasrok As Integer = Year(tp.Dzien.AddDays(-14))

                                f.Add("tydzien", "Tydzien " & kastydz & " " & kasrok)
                                f.Add("Jednostki_fazy_Region", tp.Jednostki_fazy_Region)

                                Console.WriteLine("Usunięto wierszy: " & mongoDBCore.Delete("tf", f))
                                deleted = True
                            End If
                        Catch ex As Exception

                        End Try




                        Dim fl As New Dictionary(Of String, Object)
                        fl.Add("Identyfikator_przesylki", tp.Identyfikator_przesylki)
                        fl.Add("Nazwa_fazy", tp.Nazwa_fazy)
                        fl.Add("Nazwa_jednostki", tp.Nazwa_jednostki)
                        Dim ifexists As tPrzesylkaType = m.GetSingleObject(Of tPrzesylkaType)("tf", fl)
                        If Not IsNothing(ifexists) Then
                            m.Delete(Of tPrzesylkaType)("tf", ifexists)
                        End If


                        RaiseEvent LoadProgress(ii, a)

                        rtr.AddValue(tp.PNI, tp.Dzien, tp.Identyfikator_przesylki)
                        l.Add(tp)
                        If l.Count > 5000 Then
                            ' Polacz.InsertList("tf", "id", l)
                            m.InsertList(Of List(Of tPrzesylkaType))(l, "tf")
                            l.Clear()

                            'Console.WriteLine("Rows inserted")
                        End If

                    Catch ex As Exception
                        ' w & vbNewLine & " błąd przesyłki: " & dt.Rows(i)("Identyfikator przesyłki").ToString & " ex:" & ex.ToString
                        tPrzesylkaType.tfimportlog(ex.ToString, filename)
                    End Try

                    'RaiseEvent LoadProgress(ii, a)
                    ii += 1
                    'End If




                Next

                m.InsertList(Of List(Of tPrzesylkaType))(l, "tf")
                l.Clear()

                dt = Nothing

            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                tPrzesylkaType.tfimportlog(ex.ToString, filename)
            End Try
        Else
            Console.WriteLine("Błąd. nie zaimportowano pliku!")
            tPrzesylkaType.tfimportlog("Nie zaimportowano pliki, xlsworker, exceltotpprzesylkalist - dt.rows =0 lub nothing w linii:180", filename)

        End If





        Return rtr

    End Function


    Public Shared Function ExcelToDataset(filename As String) As DataSet

        Dim ds As New DataSet
        Dim workBook As New XLWorkbook(filename)

        For Each worksheet In workBook.Worksheets

            Dim a = worksheet.RowsUsed.Count

            Dim dt As New DataTable
            dt.TableName = worksheet.Name


            Dim firstline As Boolean = True
            Dim ii As Integer = 0
            For Each row In worksheet.RowsUsed
                If firstline = True Then
                    firstline = False
                    For Each o In row.CellsUsed
                        dt.Columns.Add(o.Value)
                    Next
                Else
                    dt.Rows.Add()


                    Dim x As Integer = 0
                    For Each o In row.CellsUsed
                        Try

                            dt.Rows(dt.Rows.Count - 1)(x) = o.Value

                        Catch ex As Exception
                            dt.Rows(dt.Rows.Count - 1)(x) = o.Value
                        End Try


                        x += 1
                    Next

                End If


                ii += 1
            Next

            ds.Tables.Add(dt)
        Next


        Return ds
    End Function

    Public Shared Function ExcelToDataTable(filename As String) As DataTable
        Dim dt As New DataTable
        Dim workBook As New XLWorkbook(filename)
        Dim worksheet = workBook.Worksheets(0)
        'Dim Content = worksheet.RowsUsed().[Select](Function(row) String.Join("^", row.Cells(1, row.LastCellUsed(False).Address.ColumnNumber).[Select](Function(cell) cell.GetValue(Of String)()))).ToList




        Dim a = worksheet.RowsUsed.Count


        Dim firstline As Boolean = True
        Dim ii As Integer = 0
        For Each row In worksheet.RowsUsed
            If firstline = True Then
                firstline = False
                For Each o In row.CellsUsed
                    dt.Columns.Add(o.Value)
                Next
            Else
                dt.Rows.Add()




                Dim x As Integer = 0
                For Each o In row.CellsUsed
                    Try
                        'A,M,N,O,P,Q,R,Z
                        If o.Address.ColumnLetter = "A" Or o.Address.ColumnLetter = "M" Or
                             o.Address.ColumnLetter = "N" Or o.Address.ColumnLetter = "O" Or
                            o.Address.ColumnLetter = "P" Or o.Address.ColumnLetter = "Q" Or
                             o.Address.ColumnLetter = "R" Or o.Address.ColumnLetter = "Z" Then

                            If IsDate(Date.FromOADate(o.Value)) Then
                                dt.Rows(dt.Rows.Count - 1)(x) = Date.FromOADate(o.Value)
                            Else
                                dt.Rows(dt.Rows.Count - 1)(x) = o.Value
                            End If
                        Else
                            dt.Rows(dt.Rows.Count - 1)(x) = o.Value
                            End If
                    Catch ex As Exception
                        dt.Rows(dt.Rows.Count - 1)(x) = o.Value
                    End Try


                    x += 1
                Next

            End If

            RaiseEvent LoadProgress(ii, a)
            ii += 1
        Next



        Return dt


        workBook = Nothing
    End Function
    Public Shared Function ExcelToDS(FileName As String) As DataSet
        Dim ds As New DataSet
        Dim filePath As String = FileName
        'Open the Excel file using ClosedXML.
        Using workBook As New XLWorkbook(filePath)
            'Read the first Sheet from Excel file.

            For Each workSheet In workBook.Worksheets
                Dim rowIndex As Integer = 0




                'Create a new DataTable.
                Dim dt As New DataTable()
                dt.TableName = workSheet.Name
                'Loop through the Worksheet rows.


                Dim firstRow As Boolean = True
                For Each row As IXLRow In workSheet.Rows()
                    Dim c As IXLCell = row.Cell(1)
                    If c.Value.ToString.StartsWith("Raport Przesyłki") Then
                        row.Delete()
                    Else
                        'Use the first row to add columns to DataTable.
                        If firstRow Then
                            For Each cell As IXLCell In row.Cells()
                                Dim b As String = cell.Value.ToString()
                                b = b.Replace(vbNewLine, "").Replace(vbLf, "").Replace(vbTab, " ")
                                cell.Value = b
                                dt.Columns.Add(b)
                            Next
                            firstRow = False
                        Else

                            'Add rows to DataTable.
                            dt.Rows.Add()
                            Dim i As Integer = 0
                            For Each cell As IXLCell In row.Cells()
                                Dim a As String = cell.WorksheetColumn.FirstCell.Value.ToString
                                a = a.Replace(vbTab, " ")
                                If Not dt.Columns.Contains(a) Then dt.Columns.Add(a)
                                If Not String.IsNullOrEmpty(a) Then dt.Rows(dt.Rows.Count - 1)(a) = cell.Value.ToString()
                                i += 1
                            Next


                        End If
                    End If


                    rowIndex += 1
                Next

                ds.Tables.Add(dt)
            Next
        End Using

        Return ds
    End Function

    Public Shared Function ExcelToDS(workBook As XLWorkbook, FileName As String, firstRowIndex As Integer, LastRowIndex As Integer) As DataSet

        'firstRowIndex = 509965
        'LastRowIndex = 528476


        Dim ds As New DataSet
        Dim filePath As String = FileName
        'Open the Excel file using ClosedXML.
        Dim wn As Integer = 0
        'Read the first Sheet from Excel file.

        For Each workSheet In workBook.Worksheets
            Dim rowIndex As Integer = 0

            'Create a new DataTable.
            Dim dt As New DataTable()
            dt.TableName = wn
            'Loop through the Worksheet rows.
            Dim rwc As Integer = workSheet.RowCount

            Dim firstRow As Boolean = True
            If firstRowIndex < 1 Then firstRowIndex = 1
            If firstRowIndex > rwc Then Exit For
            If LastRowIndex > rwc Then LastRowIndex = rwc
            For Each row As IXLRow In workSheet.Rows(firstRowIndex, LastRowIndex)
                'Debug.Print(rowIndex & " " & rwc)


                Dim c As IXLCell = row.Cell(1)
                If c.Value.ToString.StartsWith("Raport Przesyłki") Then
                    row.Delete()
                Else


                    If Not String.IsNullOrEmpty(c.Value.ToString) Then

                        'Use the first row to add columns to DataTable.
                        If firstRow Then
                            For Each cell As IXLCell In workSheet.Rows(1, 1).Cells()
                                Dim b As String = cell.Value.ToString()
                                b = b.Replace(vbNewLine, "").Replace(vbLf, "").Replace(vbTab, " ")
                                cell.Value = b
                                If Not dt.Columns.Contains(b) Then
                                    If dt.Columns.Count < 33 Then
                                        dt.Columns.Add(b)
                                    End If
                                End If
                            Next
                            firstRow = False
                        Else



                            'Add rows to DataTable.
                            dt.Rows.Add()
                            Dim i As Integer = 0
                            For Each cell As IXLCell In row.Cells()
                                Dim a As String = cell.WorksheetColumn.FirstCell.Value.ToString
                                a = a.Replace(vbTab, " ")
                                If Not dt.Columns.Contains(a) Then
                                    dt.Columns.Add(a)
                                End If
                                If Not String.IsNullOrEmpty(a) Then dt.Rows(dt.Rows.Count - 1)(a) = cell.Value.ToString()
                                i += 1
                            Next

                        End If

                    Else
                        'Debug.Print("null")
                    End If

                End If


                rowIndex += 1



            Next

            ds.Tables.Add(dt)
            wn += 1
        Next


        Return ds
    End Function

    Private Shared Function HTML_DO_DATASET(ByVal Sciezka_pliku As String) As DataSet
        Dim readText As String = File.ReadAllText(Sciezka_pliku)


        Dim ds As New DataSet
        ds = ConvertHTMLTablesToDataSet(readText)
        Return (ds)
    End Function
    Private Shared Function ConvertHTMLTablesToDataSet(ByVal HTML As String) As DataSet
        ' Declarations  
        Dim ds As New DataSet
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dc As DataColumn
        Dim TableExpression As String = "<table[^>]*>(.*?)</table>"
        Dim HeaderExpression As String = "<th[^>]*>(.*?)</th>"
        Dim RowExpression As String = "<tr[^>]*>(.*?)</tr>"
        Dim ColumnExpression As String = "<td[^>]*>(.*?)</td>"
        Dim HeadersExist As Boolean = False
        Dim iCurrentColumn As Integer = 0
        Dim iCurrentRow As Integer = 0

        ' Get a match for all the tables in the HTML  
        Dim Tables As MatchCollection = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        ' Loop through each table element  
        For Each Table As Match In Tables

            ' Reset the current row counter and the header flag  
            iCurrentRow = 0
            HeadersExist = False

            ' Add a new table to the DataSet  
            dt = New DataTable

            ' Create the relevant amount of columns for this table (use the headers if they exist, otherwise use default names)  
            If Table.Value.Contains("<th") Then
                ' Set the HeadersExist flag  
                HeadersExist = True

                ' Get a match for all the rows in the table  
                Dim Headers As MatchCollection = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                ' Loop through each header element  
                For Each Header As Match In Headers
                    dt.Columns.Add(Header.Groups(1).ToString)
                Next
            Else
                For iColumns As Integer = 1 To Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Item(0).ToString, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase).Count
                    dt.Columns.Add("Column " & iColumns)
                Next
            End If

            ' Get a match for all the rows in the table  
            Dim Rows As MatchCollection = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            ' Loop through each row element  
            For Each Row As Match In Rows

                ' Only loop through the row if it isn't a header row  
                If Not (iCurrentRow = 0 And HeadersExist = True) Then

                    ' Create a new row and reset the current column counter  
                    dr = dt.NewRow
                    iCurrentColumn = 0

                    ' Get a match for all the columns in the row  
                    Dim Columns As MatchCollection = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                    ' Loop through each column element  
                    For Each Column As Match In Columns

                        ' Add the value to the DataRow  
                        dr(iCurrentColumn) = Column.Groups(1).ToString

                        ' Increase the current column   
                        iCurrentColumn += 1
                    Next

                    ' Add the DataRow to the DataTable  
                    dt.Rows.Add(dr)

                End If

                ' Increase the current row counter  
                iCurrentRow += 1
            Next

            ' Add the DataTable to the DataSet  
            ds.Tables.Add(dt)

        Next

        Return (ds)

    End Function


















End Class

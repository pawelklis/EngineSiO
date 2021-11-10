Imports System.Reflection
Imports EngineSiO
Imports EngineSiO.ServiceReference1

Public Class wftfTracker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PlaceHolder1.Controls.Clear()
        PlaceHolder2.Controls.Clear()
        PlaceHolder3.Controls.Clear()

        If Not IsNothing(Request.QueryString("id")) Then
            txid.Visible = False
            btnfindID.Visible = False
            h3.InnerText = Request.QueryString("id")
            ShowData(Request.QueryString("id"))
        End If

    End Sub


    Function GetCalendarControl(month As Integer, year As Integer, dates As List(Of Date)) As LiteralControl
        'year = 2021
        'month = 4

        Dim daysinmonth As Integer = DateTime.DaysInMonth(year, month)

        Dim rowscount As Integer = Math.Ceiling(daysinmonth / 7)


        Dim sb As New StringBuilder

        Dim rowcounter As Integer = 0
        Dim i As Integer = 1


        Dim dt As New DataTable


        dt.Columns.Add("Pn")
        dt.Columns.Add("Wt")
        dt.Columns.Add("Śr")
        dt.Columns.Add("Cz")
        dt.Columns.Add("Pt")
        dt.Columns.Add("Sb")
        dt.Columns.Add("Nd")

        For i = 1 To rowscount
            dt.Rows.Add()
        Next

        Dim line As Integer = 0
        For i = 1 To daysinmonth
            Dim d As Date = year & "-" & month & "-" & i

            Dim dn As Integer = 0
            If d.DayOfWeek = DayOfWeek.Monday Then dn = 0
            If d.DayOfWeek = DayOfWeek.Tuesday Then dn = 1
            If d.DayOfWeek = DayOfWeek.Wednesday Then dn = 2
            If d.DayOfWeek = DayOfWeek.Thursday Then dn = 3
            If d.DayOfWeek = DayOfWeek.Friday Then dn = 4
            If d.DayOfWeek = DayOfWeek.Saturday Then dn = 5
            If d.DayOfWeek = DayOfWeek.Sunday Then dn = 6

            dt.Rows(line)(dn) = i

            If d.DayOfWeek = DayOfWeek.Sunday Then
                line += 1
            End If

        Next


        sb.AppendLine("<Table style='border-style:solid;border-width:1px;border-collapse:collapse;'> ")

        sb.AppendLine("<tr>")
        sb.AppendLine("<td colspan='7'  style='background-color:silver;'>" & MonthName(month, False) & " " & year & "</td>")
        sb.AppendLine("</tr>")

        sb.AppendLine("<tr >")
        sb.AppendLine("<td style='background-color:silver;'>Pn</td>")
        sb.AppendLine("<td style='background-color:silver;'>Wt</td>")
        sb.AppendLine("<td style='background-color:silver;'>Śr</td>")
        sb.AppendLine("<td style='background-color:silver;'>Cz</td>")
        sb.AppendLine("<td style='background-color:silver;'>Pt</td>")
        sb.AppendLine("<td style='background-color:silver;'>Sb</td>")
        sb.AppendLine("<td style='background-color:silver;'>Nd</td>")
        sb.AppendLine("</tr>")

        For i = 0 To dt.Rows.Count - 1
            sb.AppendLine("     <tr style='height:26px;'> ")

            For x = 0 To dt.Columns.Count - 1

                Dim daystyle As String = ""
                If x = 6 Then
                    daystyle = " style='background-color:floralwhite;' "
                End If
                If x = 7 Then
                    daystyle = " style='background-color:antiquewhite;' "
                End If

                If IsDBNull(dt.Rows(i)(x)) Then
                    sb.AppendLine("         <td " & daystyle & "> ")

                    sb.AppendLine("         </td> ")
                Else
                    Dim d As Date = year & "-" & month & "-" & dt.Rows(i)(x)

                    If dates.Contains(d) Then
                        sb.AppendLine("         <td " & daystyle & "> ")
                        sb.AppendLine("<div style='background-color: lightgreen;'>" & dt.Rows(i)(x) & "</div>")
                        sb.AppendLine("         </td> ")
                    Else
                        sb.AppendLine("         <td " & daystyle & "> ")
                        sb.AppendLine("<div class=''>" & dt.Rows(i)(x) & "</div>")
                        sb.AppendLine("         </td> ")
                    End If
                End If


            Next

            sb.AppendLine("</tr>")
        Next



        sb.AppendLine("</table> ")

        Dim ctl As New LiteralControl(sb.ToString)
        Return ctl
    End Function
    Protected Sub btnfindID_Click(sender As Object, e As EventArgs)
        ShowData(txid.Text)

    End Sub

    Sub ShowData(nr As String)
        Dim tracker As tfTrackerType = tfTrackerType.GetData(nr)

        lptyp.Text = tracker.tp.Nazwa_typu_przesylki

        lbGT.Text = tracker.tp.Gwarantowany_termin_doręczenia
        lbdtE2E.Text = tracker.tp.Data_czas_zdarzenia_konczacego_terminowosc_E2E

        ltet.Text = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, tracker.tp.Data_czas_nadania, tracker.tp.Data_czas_zdarzenia_konczacego_terminowosc_E2E)).ToString


        If tracker.tp.Terminowosc_E2E = 1 Then
            ime2e.ImageUrl = "~/images/icons/appbar.smiley.happy.png"
        Else
            ime2e.ImageUrl = "~/images/icons/appbar.smiley.frown.png"
        End If

        Me.PlaceHolder1.Controls.Clear()

        Dim pnmain As New Panel
        pnmain.ID = "pnmain" & Guid.NewGuid.ToString
        pnmain.CssClass = "maindiv"

        Dim xid As Integer = 0
        For Each o In tracker.Track

            Me.PlaceHolder2.Controls.Add(ParcelDataControl(o.tp))

            Dim pn As New Panel
            pn.ID = "pn" & xid
            pn.CssClass = "framediv"

            Dim l As Label

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lfaza"
            l.Text = o.NazwaFazy
            l.ToolTip = o.NazwaFazy
            pn.Controls.Add(l)

            pn.Controls.Add(New LiteralControl("</br>"))

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lregion"
            l.Text = o.tp.Jednostki_fazy_Region
            l.ToolTip = o.tp.Jednostki_fazy_Region
            pn.Controls.Add(l)

            pn.Controls.Add(New LiteralControl("</br>"))

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lup"
            l.Text = o.Jednostka.UP
            l.ToolTip = o.tp.Nazwa_jednostki
            pn.Controls.Add(l)

            pn.Controls.Add(New LiteralControl("</br>"))


            Dim pin As New Panel
            pin.CssClass = "pin"
            pin.ID = "pin1"


            Dim im As New Image
            im.ID = xid & "imga"
            im.CssClass = "arrowin"
            im.ImageUrl = "../images/icons/appbar.arrow.right.png"
            im.Style.Add("position", "absolute")
            im.Style.Add("left", "0px")
            pin.Controls.Add(im)


            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lin"
            l.Text = o.tp.Rzeczywisty_data_czas_wejscia_Do_jednostki.Date.ToString("ddd") & " " & o.tp.Rzeczywisty_data_czas_wejscia_Do_jednostki.Day & " " & o.tp.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToString("MMM") & " " & o.tp.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToShortTimeString
            l.ToolTip = "Rzeczywisty_data_czas_wejscia_Do_jednostki"



            If o.tp.Terminowosc_fazy_dla_jednostki = 1 Then
                pin.BackColor = System.Drawing.Color.LightGreen
            Else
                If o.tp.Sparametryzowana = 1 Then
                    pin.BackColor = System.Drawing.Color.IndianRed
                Else
                    pin.BackColor = System.Drawing.Color.PeachPuff
                End If
            End If
            pin.Controls.Add(l)

            pin.Controls.Add(New LiteralControl("</br>"))

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "linplan"
            l.Text = o.tp.Nazwa_zdarzenia_wejscia
            l.ToolTip = "Nazwa_zdarzenia_wejscia"
            pin.Controls.Add(l)


            Dim weim As New Image
            weim.CssClass = "weim"
            If o.tp.Poprawne_WE = 1 Then
                weim.ImageUrl = "../images/icons/appbar.check.png"
                weim.ToolTip = "Prawidłowe zdarzenie wejścia do fazy"
            Else
                weim.ImageUrl = "../images/icons/appbar.close.png"
                weim.ToolTip = "Nierawidłowe zdarzenie wejścia do fazy"
            End If
            pin.Controls.Add(weim)


            pin.Controls.Add(New LiteralControl("</br>"))
            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "linplan"
            l.Text = o.tp.Planowy_data_czas_wejscia_Do_jednostki
            l.ToolTip = "Planowy_data_czas_wejscia_Do_jednostki"
            pin.Controls.Add(l)

            pn.Controls.Add(pin)

            pn.Controls.Add(New LiteralControl("</br>"))

            Dim pon As New Panel
            pon.ID = "pon1"
            pon.CssClass = "pin"

            im = New Image
            im.ID = xid & "imgb"
            im.CssClass = "arrowout"
            im.ImageUrl = "../images/icons/appbar.arrow.right.png"
            im.Style.Add("position", "absolute")
            im.Style.Add("right", "0px")
            pon.Controls.Add(im)

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lout"
            l.Text = o.tp.Rzeczywisty_data_czas_wyjscia_z_jednostki.Date.ToString("ddd") & " " & o.tp.Rzeczywisty_data_czas_wyjscia_z_jednostki.Day & " " & o.tp.Rzeczywisty_data_czas_wyjscia_z_jednostki.ToString("MMM") & " " & o.tp.Rzeczywisty_data_czas_wyjscia_z_jednostki.ToShortTimeString
            l.ToolTip = "Rzeczywisty_data_czas_wyjscia_z_jednostki"
            pon.Controls.Add(l)

            If o.tp.Terminowosc_fazy_dla_jednostki = 1 Then
                pon.BackColor = System.Drawing.Color.LightGreen
            Else
                If o.tp.Sparametryzowana = 1 Then
                    pon.BackColor = System.Drawing.Color.IndianRed
                Else
                    pon.BackColor = System.Drawing.Color.PeachPuff
                End If
            End If

            pon.Controls.Add(New LiteralControl("</br>"))


            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "outplan"
            l.Text = o.tp.Nazwa_zdarzenia_wyjscia
            l.ToolTip = "Nazwa_zdarzenia_wyjscia"
            pon.Controls.Add(l)


            weim = New Image
            weim.CssClass = "weim"
            If o.tp.Poprawne_WE = 1 Then
                weim.ImageUrl = "../images/icons/appbar.check.png"
                weim.ToolTip = "Prawidłowe zdarzenie wejścia do fazy"
            Else
                weim.ImageUrl = "../images/icons/appbar.close.png"
                weim.ToolTip = "Nierawidłowe zdarzenie wejścia do fazy"
            End If
            pon.Controls.Add(weim)

            pon.Controls.Add(New LiteralControl("</br>"))

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "outplan"
            l.Text = o.tp.Planowy_data_czas_wyjscia_z_jednostki
            l.ToolTip = "Planowy_data_czas_wyjscia_z_jednostki"
            pon.Controls.Add(l)


            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lunp"
            l.Text = "Brak parametryzacji"
            'l.ToolTip = "Nazwa_zdarzenia_wyjscia"
            If pon.BackColor = System.Drawing.Color.PeachPuff Then
                pon.Controls.Add(New LiteralControl("</br>"))
                pon.Controls.Add(l)
            End If

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "luntf"
            l.Text = "Brak terminowości fazy"
            'l.ToolTip = "Nazwa_zdarzenia_wyjscia"
            If pon.BackColor = System.Drawing.Color.IndianRed Then
                pon.Controls.Add(New LiteralControl("</br>"))
                pon.Controls.Add(l)
            End If




            pn.Controls.Add(pon)

            pn.Controls.Add(New LiteralControl("</br>"))


            Dim c As New Calendar
            c.ID = "cal" & xid & Guid.NewGuid.ToString
            c.SelectedDates.Add(o.tp.Rzeczywisty_data_czas_wejscia_Do_jednostki)
            c.SelectedDates.Add(o.tp.Rzeczywisty_data_czas_wyjscia_z_jednostki)
            c.SelectionMode = CalendarSelectionMode.None

            'pn.Controls.Add(c)

            pn.Controls.Add(New LiteralControl("</br>"))

            Dim dl As New List(Of Date)
            dl.Add(o.tp.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToShortDateString)
            dl.Add(o.tp.Rzeczywisty_data_czas_wyjscia_z_jednostki.ToShortDateString)

            pn.Controls.Add(GetCalendarControl(Month(o.tp.Dzien), Year(o.tp.Dzien), dl))

            Dim kpn As New Panel
            kpn.CssClass = "kpn"
            If Not IsNothing(o.Pierwszykurs) Then



                l = New Label
                l.ID = "lb" & xid & Guid.NewGuid.ToString
                l.CssClass = "lin"
                l.Text = o.Pierwszykurs.nrkursu & " odj.: " & o.Pierwszykurs.Przystanek(o.Jednostka.KOD).odjazd.ToString
                l.ToolTip = o.Pierwszykurs.nazwakursu
                kpn.Controls.Add(l)


                Dim pkn As New Panel
                pkn.ID = "pkn" & xid & Guid.NewGuid.ToString

                Dim sb As New StringBuilder
                sb.AppendLine("<table class='tableprzys'>")
                sb.AppendLine("<tr class='unrow'>")
                sb.AppendLine("<th class='tdrow'>Przyjazd</th>")
                sb.AppendLine("<th class='tdrow'>Jednostka</th>")
                sb.AppendLine("<th class='tdrow'>Odjazd</th>")
                sb.AppendLine("</tr>")
                For Each przys In o.Pierwszykurs.Przystanki

                    l = New Label
                    l.ID = "lb" & xid & Guid.NewGuid.ToString
                    l.CssClass = ""

                    Dim przyj As String = przys.przyjazd.ToString
                    Dim odj As String = przys.odjazd.ToString
                    If przyj = "00:00:00" Then przyj = "START"
                    If odj = "00:00:00" Then odj = "STOP"

                    'l.Text = przyj & " " & przys.nazwajednostki & " " & odj
                    'l.ToolTip = przys.nrkolejny
                    'pkn.Controls.Add(l)

                    sb.AppendLine("<tr class='unrow'>")
                    sb.AppendLine("<td class='tdrow'>" & przyj & "</td>")


                    If przys.nazwajednostki = o.Jednostka.UP Then
                        sb.AppendLine("<td class='tdrow' style='background-color:lightgreen'>" & przys.nazwajednostki & "</td>")
                    Else
                        sb.AppendLine("<td class='tdrow'>" & przys.nazwajednostki & "</td>")
                    End If

                    sb.AppendLine("<td class='tdrow'>" & odj & "</td>")
                    sb.AppendLine("</tr>")

                    'pkn.Controls.Add(New LiteralControl("</br>"))

                Next
                sb.AppendLine("</table>")

                pkn.Controls.Add(New LiteralControl(sb.ToString))

                kpn.Controls.Add(pkn)

            Else
                l = New Label
                l.ID = "lb" & xid & Guid.NewGuid.ToString
                l.CssClass = "lin"
                l.Text = "Nie znaleziono KPS"
                'l.ToolTip = o.Pierwszykurs.nazwakursu
                kpn.Controls.Add(l)
            End If


            pn.Controls.Add(kpn)
            pn.Controls.Add(New LiteralControl("</br>"))


            pn.Controls.Add(New LiteralControl("</br>"))

            Dim ttj As New Panel
            ttj.CssClass = "ttj"
            l = New Label
            l.ID = "lbtj" & xid & Guid.NewGuid.ToString
            l.CssClass = ""
            l.Text = "Czas obsługi w jednostce"
            l.ToolTip = ("Czas w jednostce")
            ttj.Controls.Add(l)
            ttj.Controls.Add(New LiteralControl("</br>"))
            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = ""
            l.Text = o.CzasWJednostce.ToString
            l.ToolTip = ("Czas w jednostce")

            ttj.Controls.Add(l)

            pn.Controls.Add(ttj)


            pn.Controls.Add(New LiteralControl("</br>"))

            Dim ttt As New Panel
            ttt.CssClass = "ttt"

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = ""
            l.Text = "Czas od wyjścia do wejścia w następnej jednostce"
            l.ToolTip = ("Czas do następnej jednostki")

            ttt.Controls.Add(l)

            ttt.Controls.Add(New LiteralControl("</br>"))

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = ""
            l.Text = o.CzasDoNastępnejJednostki.ToString
            l.ToolTip = ("Czas do następnej jednostki")

            ttt.Controls.Add(l)

            pn.Controls.Add(ttt)
            pn.Controls.Add(New LiteralControl("</br>"))

            Dim pnz As New Panel
            pnz.ID = "pnz" & xid & Guid.NewGuid.ToString

            l = New Label
            l.ID = "lb" & xid & Guid.NewGuid.ToString
            l.CssClass = "lin"
            l.Text = "Zdarzenia ZST"
            l.ToolTip = "Zdarzenie ZST"
            pnz.Controls.Add(l)


            Dim sbb As New StringBuilder
            sbb.AppendLine("<table class='tableprzys'>")

            For Each z In o.ZdarzeniaZST
                sbb.AppendLine("<tr class='unrow'>")

                sbb.AppendLine("<td class='tdrow'>" & z.czas & "</td>")
                sbb.AppendLine("<td class='tdrow'>" & z.nazwa & "</td>")
                sbb.AppendLine("<td class='tdrow'>" & z.jednostka.nazwa & "</td>")

                sbb.AppendLine("</tr>")


                'l = New Label
                'l.ID = "lb" & xid & Guid.NewGuid.ToString
                'l.CssClass = ""
                'l.Text = z.czas & " " & z.nazwa & " " & z.jednostka.nazwa
                'l.ToolTip = "Zdarzenie ZST"
                'pnz.Controls.Add(l)


                'pnz.Controls.Add(New LiteralControl("</br>"))


            Next

            sbb.AppendLine("</table>")

            pnz.Controls.Add(New LiteralControl(sbb.ToString))

            pn.Controls.Add(pnz)

            pnmain.Controls.Add(pn)
            xid += 1



        Next

        PlaceHolder1.Controls.Add(pnmain)



        'Exit Sub









        'Dim m As New mongoDBCore

        'Dim numer As String = txid.Text
        'numer = numer.Replace(" ", "").Replace("`", "").Replace("'", "")

        'Dim f As New Dictionary(Of String, Object)
        'f.Add("Identyfikator_przesylki", numer)

        'Dim tp As List(Of tPrzesylkaType) = m.GetObjectList(Of tPrzesylkaType)("tf", f)

        'PlaceHolder1.Controls.Clear()
        'PlaceHolder2.Controls.Clear()
        'PlaceHolder3.Controls.Clear()
        'Try
        '    PlaceHolder3.Controls.Add(GETZSTDane(numer))

        'Catch ex As Exception

        'End Try


        'Dim lsort As New List(Of tPrzesylkaType)

        'For Each p In tp
        '    If p.Nazwa_fazy = "nadania" Then p.lp = 1
        '    If p.Nazwa_fazy = "zbiórkowa" Then p.lp = 2
        '    If p.Nazwa_fazy = "koncentracji" Then p.lp = 3
        '    If p.Nazwa_fazy = "przewozu" Then p.lp = 4
        '    If p.Nazwa_fazy = "dekoncentracji" Then p.lp = 5
        '    If p.Nazwa_fazy = "rozwózki" Then p.lp = 6
        '    If p.Nazwa_fazy = "doręczenia" Then p.lp = 7

        '    lptyp.Text = p.Nazwa_typu_przesylki


        'Next


        'lsort = tp.OrderBy(Function(mts) mts.lp).ThenBy(Function(mts) mts.Rzeczywisty_data_czas_wejscia_Do_jednostki).ToList



        'Dim x As Integer = 0

        'Dim pierwszykurs As kursType
        'For Each p In lsort



        '    Dim kursy As List(Of kursType) = kursType.Load(p.Kod_jednostki)

        '    Dim kodnastepnej As String

        '    If x + 1 < lsort.Count Then
        '        kodnastepnej = lsort(x + 1).Kod_jednostki
        '        Dim rzeczwyj As TimeSpan = TimeSpan.Parse(p.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToShortTimeString)
        '        'proba

        '        Dim potencjalnekursy As New List(Of kursType)

        '        For Each k In kursy
        '            Debug.Print(k.nrkursu)
        '            If k.CzyPogodzinie(p.Kod_jednostki, kodnastepnej, rzeczwyj) = True Then
        '                potencjalnekursy.Add(k)
        '            End If
        '        Next

        '        If potencjalnekursy.Count = 0 Then
        '            Debug.Print(1)
        '            For Each k In kursy
        '                If k.CzyPolaczenie(p.Kod_jednostki, kodnastepnej) = True Then
        '                    potencjalnekursy.Add(k)
        '                End If
        '            Next
        '        End If




        '        If potencjalnekursy.Count = 1 Then
        '            pierwszykurs = potencjalnekursy(0)
        '        Else
        '            If potencjalnekursy.Count > 0 Then
        '                pierwszykurs = potencjalnekursy(0)

        '                For Each pk In potencjalnekursy
        '                    If pk.Przystanek(p.Kod_jednostki).odjazd < pierwszykurs.Przystanek(p.Kod_jednostki).odjazd Then
        '                        pierwszykurs = pk
        '                    End If
        '                Next
        '            Else
        '                pierwszykurs = Nothing
        '            End If
        '        End If


        '        '////




        '        '                For Each k In kursy
        '        '                    For Each przys In k.Przystanki
        '        '                        If przys.kodjednostki = p.Kod_jednostki Then

        '        '                            If przys.odjazd >= rzeczwyj Then

        '        '                                For Each pp In k.Przystanki
        '        '                                    If pp.kodjednostki = kodnastepnej Then
        '        '                                        If pp.nrkolejny > przys.nrkolejny Then
        '        '                                            pierwszykurs = k
        '        '                                            'GoTo jestkurs


        '        '                                        End If
        '        '                                    End If
        '        '                                Next

        '        '                            End If
        '        '                        End If
        '        '                    Next
        '        '                Next

        '    End If
        '    'jestkurs:

        '    x += 1


        '    PlaceHolder1.Controls.Add(AddTFControl(p, pierwszykurs))



        '    If p.Terminowosc_E2E = 1 Then
        '        ime2e.ImageUrl = "~/images/icons/appbar.smiley.happy.png"
        '    Else
        '        If String.IsNullOrEmpty(p.Data_czas_zdarzenia_konczacego_terminowosc_E2E) Then
        '            ime2e.ImageUrl = "~/images/icons/appbar.question.png"
        '        Else
        '            If p.Data_czas_zdarzenia_konczacego_terminowosc_E2E = #1/1/0001 12:00:00 AM# Then
        '                ime2e.ImageUrl = "~/images/icons/appbar.question.png"
        '            Else
        '                ime2e.ImageUrl = "~/images/icons/appbar.smiley.frown.png"
        '            End If
        '        End If
        '    End If
        '    lbdtE2E.Text = p.Data_czas_zdarzenia_konczacego_terminowosc_E2E
        '    lbGT.Text = p.Gwarantowany_termin_doręczenia

        '    If p.Data_czas_zdarzenia_konczacego_terminowosc_E2E > p.Gwarantowany_termin_doręczenia Then
        '        lbdtE2E.ForeColor = System.Drawing.Color.Red
        '    Else
        '        lbdtE2E.ForeColor = System.Drawing.Color.DarkGreen
        '    End If

        '    PlaceHolder2.Controls.Add(ParcelDataControl(p))

        'Next




        'Div14.Visible = False
        'Div15.Visible = False
        'Div16.Visible = False
        'Div17.Visible = False
        'Div18.Visible = False
        'Div19.Visible = False



        'Dim t1, t2, t3, t4, t5, t6 As TimeSpan

        'If lsort.Count > 1 Then
        '    Label2.Text = lsort(0).Nazwa_jednostki
        '    Label3.Text = lsort(1).Nazwa_jednostki

        '    t1 = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, lsort(0).Rzeczywisty_data_czas_wyjscia_z_jednostki, lsort(1).Rzeczywisty_data_czas_wejscia_Do_jednostki))
        '    Div14.Visible = True
        '    Dim s1 As String = (t1.Days * 24) + t1.Hours
        '    Dim s2 As String = t1.Minutes
        '    If s1 < 0 Then s1 = -s1
        '    If s2 < 0 Then s2 = -s2

        '    If s1 < 10 Then s1 = "0" & s1
        '    If s2 < 10 Then s2 = "0" & s2

        '    nadania_l_transp.Text = s1 & ":" & s2
        '    If t1.Days > 30 Then nadania_l_transp.Text = "bd."

        'End If
        'If lsort.Count > 2 Then
        '    Label4.Text = lsort(1).Nazwa_jednostki
        '    Label6.Text = lsort(2).Nazwa_jednostki
        '    t2 = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, lsort(1).Rzeczywisty_data_czas_wyjscia_z_jednostki, lsort(2).Rzeczywisty_data_czas_wejscia_Do_jednostki))
        '    Div15.Visible = True
        '    Dim s1 As String = (t2.Days * 24) + t2.Hours
        '    Dim s2 As String = t2.Minutes
        '    If s1 < 0 Then s1 = -s1
        '    If s2 < 0 Then s2 = -s2

        '    If s1 < 10 Then s1 = "0" & s1
        '    If s2 < 10 Then s2 = "0" & s2

        '    zbiorkowa_l_transp.Text = s1 & ":" & s2
        '    If t2.Days > 30 Then zbiorkowa_l_transp.Text = "bd."
        'End If
        'If lsort.Count > 3 Then
        '    Label7.Text = lsort(2).Nazwa_jednostki
        '    Label8.Text = lsort(3).Nazwa_jednostki
        '    t3 = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, lsort(2).Rzeczywisty_data_czas_wyjscia_z_jednostki, lsort(3).Rzeczywisty_data_czas_wejscia_Do_jednostki))
        '    Div16.Visible = True
        '    Dim s1 As String = (t3.Days * 24) + t3.Hours
        '    Dim s2 As String = t3.Minutes
        '    If s1 < 0 Then s1 = -s1
        '    If s2 < 0 Then s2 = -s2
        '    If s1 < 10 Then s1 = "0" & s1
        '    If s2 < 10 Then s2 = "0" & s2

        '    koncentracji_l_transp.Text = s1 & ":" & s2
        '    If t3.Days > 30 Then koncentracji_l_transp.Text = "bd."
        'End If
        'If lsort.Count > 4 Then
        '    Label10.Text = lsort(3).Nazwa_jednostki
        '    Label11.Text = lsort(4).Nazwa_jednostki
        '    t4 = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, lsort(3).Rzeczywisty_data_czas_wyjscia_z_jednostki, lsort(4).Rzeczywisty_data_czas_wejscia_Do_jednostki))
        '    Div17.Visible = True
        '    Dim s1 As String = (t4.Days * 24) + t4.Hours
        '    Dim s2 As String = t4.Minutes
        '    If s1 < 0 Then s1 = -s1
        '    If s2 < 0 Then s2 = -s2

        '    If s1 < 10 Then s1 = "0" & s1
        '    If s2 < 10 Then s2 = "0" & s2

        '    przewozu_l_transp.Text = s1 & ":" & s2
        '    If t4.Days > 30 Then przewozu_l_transp.Text = "bd."
        'End If
        'If lsort.Count > 5 Then
        '    Label12.Text = lsort(4).Nazwa_jednostki
        '    Label14.Text = lsort(5).Nazwa_jednostki
        '    t5 = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, lsort(4).Rzeczywisty_data_czas_wyjscia_z_jednostki, lsort(5).Rzeczywisty_data_czas_wejscia_Do_jednostki))
        '    Div18.Visible = True
        '    Dim s1 As String = (t5.Days * 24) + t5.Hours
        '    Dim s2 As String = t5.Minutes
        '    If s1 < 0 Then s1 = -s1
        '    If s2 < 0 Then s2 = -s2

        '    If s1 < 10 Then s1 = "0" & s1
        '    If s2 < 10 Then s2 = "0" & s2

        '    dekoncentracji_l_transp.Text = s1 & ":" & s2
        '    If t5.Days > 30 Then dekoncentracji_l_transp.Text = "bd."
        'End If
        'If lsort.Count > 6 Then
        '    Label15.Text = lsort(5).Nazwa_jednostki
        '    Label16.Text = lsort(6).Nazwa_jednostki
        '    t6 = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, lsort(5).Rzeczywisty_data_czas_wyjscia_z_jednostki, lsort(6).Rzeczywisty_data_czas_wejscia_Do_jednostki))
        '    Div19.Visible = True
        '    Dim s1 As String = (t6.Days * 24) + t6.Hours
        '    Dim s2 As String = t6.Minutes
        '    If s1 < 0 Then s1 = -s1
        '    If s2 < 0 Then s2 = -s2

        '    If s1 < 10 Then s1 = "0" & s1
        '    If s2 < 10 Then s2 = "0" & s2

        '    doreczenia_l_transp.Text = s1 & ":" & s2
        '    If t6.Days > 30 Then doreczenia_l_transp.Text = "bd."
        'End If





    End Sub


    Function GETZSTDane(numer As String) As Control
        Dim zstp = sledzeniePP.SprawdzPRzesylke(numer)


        If Not IsNothing(zstp) Then
            If Not IsNothing(zstp.danePrzesylki.zdarzenia) Then


                Dim pn As New Panel
                pn.ID = "zstpanel"
                pn.CssClass = "zstp"

                Dim i As Integer = 0


                Dim jo = From z In zstp.danePrzesylki.zdarzenia
                         Select z.jednostka.nazwa.Distinct

                jo = From z In zstp.danePrzesylki.zdarzenia
                     Select z.jednostka.nazwa Distinct

                For Each j In jo.ToList

                    If IsNothing(j) Then j = "EN"



                    Dim pnx As New Panel
                        pnx.ID = "pndet" & i
                        pnx.CssClass = "tfpc2"
                    If j.ToString <> "Centralna Baza Danych ZST" Then

                        For Each z In zstp.danePrzesylki.zdarzenia
                            If z.jednostka.nazwa = j.ToString Then

                                Dim ppn As New Panel
                                ppn.ID = "pnn" & i
                                ppn.CssClass = "pnn tfpc"

                                Dim l As Label
                                l = New Label
                                l.ID = "la" & i
                                l.Text = z.czas
                                l.CssClass = "ln2"
                                ppn.Controls.Add(l)

                                pnx.Controls.Add(New LiteralControl("</br>"))

                                l = New Label
                                l.ID = "lc" & i
                                l.Text = z.jednostka.daneSzczegolowe.pna & " " & z.jednostka.nazwa
                                l.CssClass = "ln2"
                                ppn.Controls.Add(l)

                                l = New Label
                                l.ID = "lb" & i
                                l.Text = z.nazwa
                                l.CssClass = "ln2"
                                ppn.Controls.Add(l)


                                i += 1

                                pnx.Controls.Add(ppn)
                            End If
                        Next


                    End If
                    If pnx.Controls.Count > 0 Then
                        pn.Controls.Add(pnx)
                    End If

                Next





                Return pn
            End If
        End If


    End Function

    Function AddTFControl(p As tPrzesylkaType, k As kursType) As Control
        Dim l As New List(Of Control)





        Dim pn As New Panel
        pn.ID = "pn" & p.Nazwa_fazy
        pn.CssClass = "framediv"

        Dim l0 As New Label
        l0.ID = p.Nazwa_fazy & "lheadeREGION"
        l0.Text = p.Jednostki_fazy_Region
        l0.CssClass = "labelfaza"

        pn.Controls.Add(l0)
        pn.Controls.Add(New LiteralControl("</br>"))

        Dim l1 As New Label
        l1.ID = p.Nazwa_fazy & "lheader"
        l1.Text = "Faza " & p.Nazwa_fazy
        l1.CssClass = "labelfaza"

        pn.Controls.Add(l1)

        pn.Controls.Add(New LiteralControl("</br>"))

        Dim l2 As New Label
        l2.ID = p.Nazwa_fazy & "upheader"
        l2.Text = p.Nazwa_jednostki
        l2.CssClass = "labelup"

        pn.Controls.Add(l2)


        Dim pn2 As New Panel
        pn2.ID = p.Nazwa_fazy & "pnwe"
        If p.Sparametryzowana = 1 And p.Terminowosc_fazy_dla_jednostki = 0 Then
            pn2.CssClass = "czaswewycontainerbad"
        Else
            pn2.CssClass = "czaswewycontainer"
        End If

        If String.IsNullOrEmpty(p.Nazwa_zdarzenia_wejscia) Then
            pn2.CssClass = "czaswewycontainerbadNN"
        End If

        Dim im2 As New Image
        im2.CssClass = "arowim"
        im2.ImageUrl = "../images/icons/appbar.arrow.right.png"

        pn2.Controls.Add(im2)

        Dim l3 As New Label
        l3.ID = p.Nazwa_fazy & "_czaswe"
        l3.Text = p.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToString("ddd") & " " & p.Rzeczywisty_data_czas_wejscia_Do_jednostki.ToShortTimeString
        l3.ToolTip = "Rzeczywisty_data_czas_wejscia_Do_jednostki: " & p.Rzeczywisty_data_czas_wejscia_Do_jednostki
        l3.CssClass = "labelczaswewy"

        pn2.Controls.Add(l3)
        pn2.Controls.Add(New LiteralControl("</br>"))

        Dim l4 As New Label
        l4.ID = p.Nazwa_fazy & "_czaswePLAN"
        l4.Text = p.Planowy_data_czas_wejscia_Do_jednostki
        l4.ToolTip = "Planowy_data_czas_wejscia_Do_jednostki"
        l4.Style.Add("font-size", "smaller")
        l4.CssClass = "labelczaswewy"

        pn2.Controls.Add(l4)
        pn2.Controls.Add(New LiteralControl("</br>"))

        Dim l4x As New Label
        l4x.ID = p.Nazwa_fazy & "_czaswePLAN"
        l4x.Text = p.Nazwa_zdarzenia_wejscia
        l4x.ToolTip = "Nazwa_zdarzenia_wejscia"
        l4x.Style.Add("font-size", "smaller")
        l4x.CssClass = "labelczaswewy"

        pn2.Controls.Add(l4x)





        pn.Controls.Add(pn2)



        Dim pn3 As New Panel
        pn3.ID = p.Nazwa_fazy & "pnwy"
        If p.Sparametryzowana = 1 And p.Terminowosc_fazy_dla_jednostki = 0 Then
            pn3.CssClass = "czaswewycontainerbad"
        Else
            pn3.CssClass = "czaswewycontainer"
        End If
        If String.IsNullOrEmpty(p.Nazwa_zdarzenia_wyjscia) Then
            pn3.CssClass = "czaswewycontainerbadNN"
        End If

        Dim im22 As New Image
        im22.CssClass = "arowim"
        im22.ImageUrl = "../images/icons/appbar.arrow.right.png"

        pn3.Controls.Add(im22)

        Dim l33 As New Label
        l33.ID = p.Nazwa_fazy & "_czaswy"
        l33.Text = p.Rzeczywisty_data_czas_wyjscia_z_jednostki.ToString("ddd") & " " & p.Rzeczywisty_data_czas_wyjscia_z_jednostki.ToShortTimeString
        l33.ToolTip = "Rzeczywisty_data_czas_wyjscia_z_jednostki: " & p.Rzeczywisty_data_czas_wyjscia_z_jednostki
        l33.CssClass = "labelczaswewy"

        pn3.Controls.Add(l33)
        pn3.Controls.Add(New LiteralControl("</br>"))

        Dim l44 As New Label
        l44.ID = p.Nazwa_fazy & "_czaswyPLAN"
        l44.Text = p.Planowy_data_czas_wyjscia_z_jednostki
        l44.ToolTip = "Planowy_data_czas_wyjscia_z_jednostki"
        l44.Style.Add("font-size", "smaller")
        l44.CssClass = "labelczaswewy"
        pn3.Controls.Add(l44)


        pn3.Controls.Add(New LiteralControl("</br>"))

        Dim l4xy As New Label
        l4xy.ID = p.Nazwa_fazy & "_czaswePLAN"
        l4xy.Text = p.Nazwa_zdarzenia_wyjscia
        l4xy.ToolTip = "Nazwa_zdarzenia_wyjscia"
        l4xy.Style.Add("font-size", "smaller")
        l4xy.CssClass = "labelczaswewy"

        pn3.Controls.Add(l4xy)

        pn3.Controls.Add(New LiteralControl("</br>"))

        If Not IsNothing(k) Then
            If p.Nazwa_fazy <> "doręczenia" Then



                Dim l4xt As New Label
                l4xt.ID = p.Nazwa_fazy & "_firstkps"
                For Each pr In k.Przystanki
                    If pr.kodjednostki = p.Kod_jednostki Then
                        l4xt.Text = k.nrkursu & " " & pr.odjazd.ToString
                        Exit For
                    End If
                Next

                l4xt.ToolTip = k.nazwakursu
                l4xt.Style.Add("font-size", "smaller")
                l4xt.CssClass = "labelczaswewy"

                pn3.Controls.Add(l4xt)

            End If
        End If




        pn.Controls.Add(pn3)


        Dim pn4 As New Panel
        pn4.ID = p.Nazwa_fazy & "procfaza"
        pn4.CssClass = "processingdiv"

        Dim pn5 As New Panel
        pn5.ID = p.Nazwa_fazy & "pnprocchild"
        pn5.CssClass = "procestimecontainer"

        Dim im225 As New Image
        im225.CssClass = "arowim"
        im225.ImageUrl = "../images/icons/appbar.man.suitcase.run.png"
        pn5.Controls.Add(im225)

        Dim l5 As New Label
        l5.ID = p.Nazwa_fazy & "_l_proc"
        l5.CssClass = "labelczaswewy"
        l5.Text = p.CZasWjEdnostce
        l5.ToolTip = "Czas przebywania przesyłki w jednostce"

        pn5.Controls.Add(l5)

        pn4.Controls.Add(pn5)
        pn.Controls.Add(pn4)




        Dim cal As New Calendar
        cal.ID = p.Nazwa_fazy & "cal" & Guid.NewGuid.ToString.Replace("-", "")
        cal.SelectedDates.Clear()
        cal.SelectionMode = CalendarSelectionMode.Day

        Dim d1 As Date = p.Rzeczywisty_data_czas_wejscia_Do_jednostki
        Dim d2 As Date = p.Rzeczywisty_data_czas_wyjscia_z_jednostki

        'd1 = d1.ToShortDateString
        'd2 = d2.ToShortDateString

        Dim ld As Integer = DateDiff(DateInterval.Day, d1, d2)
        If ld < 0 Then ld = -ld

        Dim dd As Date = d1
        If ld = 0 Then
            'cal.SelectedDate = dd
            cal.SelectedDates.Add(dd.Date)
        Else

            For i = 0 To ld

                cal.SelectedDates.Add(dd.Date)

                dd = dd.AddDays(1)
            Next
        End If



        cal.CssClass = "calendar"
        cal.SelectedDayStyle.BackColor = System.Drawing.Color.DarkGreen
        'cal.Enabled = False
        'cal.SelectedDate = cal.SelectedDates(0)
        'cal.VisibleDate = cal.SelectedDates(0)

        pn.Controls.Add(cal)


        l.Add(pn)

        Return pn
    End Function

    Function Calendartest(sd As List(Of Date))

        Dim sb As New StringBuilder

        sb.AppendLine("<table>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<th>Pn</th>")
        sb.AppendLine("<th>Wt</th>")
        sb.AppendLine("<th>Śr</th>")
        sb.AppendLine("<th>Cz</th>")
        sb.AppendLine("<th>Pt</th>")
        sb.AppendLine("<th>Sb</th>")
        sb.AppendLine("<th>Nd</th>")
        sb.AppendLine("</tr>")

        Dim liczbadni As Integer = DateTime.DaysInMonth(Year(sd(0)), Month(sd(0)))


        sb.AppendLine("<tr>")

        sb.AppendLine("</tr>")



        sb.AppendLine("</table>")





    End Function
    Function ParcelDataControl(p As tPrzesylkaType) As Control
        Dim pn As New Panel
        pn.ID = "ctl" & p.Identyfikator_przesylki
        pn.CssClass = "tfpm"

        Dim props As PropertyInfo() = p.GetType.GetProperties
        Dim i As Integer = 1
        For Each prop In props
            Dim pn1 As New Panel
            pn1.ID = i & "mctl"
            pn1.CssClass = "tfpc"

            Dim l As New Label
            l.ID = p.Identyfikator_przesylki & "lbctln"
            l.Text = prop.Name
            l.CssClass = "ln"
            'l.Width = 300
            pn1.Controls.Add(l)

            Dim ll As New Label
            ll.ID = p.Identyfikator_przesylki & "lbctlval"
            ll.Text = prop.GetValue(p)
            ll.CssClass = "lv"
            pn1.Controls.Add(ll)

            pn.Controls.Add(pn1)
            i += 1
        Next


        Return pn
    End Function

End Class
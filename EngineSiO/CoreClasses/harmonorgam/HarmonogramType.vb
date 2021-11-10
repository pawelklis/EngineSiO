
Imports MongoDB.Bson
Imports MongoDB.Driver

Public Class HarmonogramType

    Public Property _id As String
    Public Property idworker As Integer
    Public Property orgid As Integer
    Public Property zoneid As Integer

    Public Property WorkerCode As String
    Public Property WorkerName As String

    Public Property Plan_Data As Date
    Public Property Plan_StartTime As DateTime
    Public Property Plan_WorkTime As Integer
    Public Property Plan_EndWorkTime As DateTime
    Public Property Plan_WorkTypeID As Integer

    Public Property Exe_Data As Date
    Public Property Exe_StartTime As DateTime
    Public Property Exe_WorkTime As Integer
    Public Property Exe_WorkTypeID As Integer
    Public Property Exe_EndWorkTime As DateTime


    Public Property ScanStart As DateTime
    Public Property ScanStop As DateTime


    Public Property Present As Integer

    Public Property Target As String


    Public Property tempstatus As String

    Public Property Descr As String

    Public Shared Sub Scan(workercode As String, time As DateTime, zoneid As Integer, orgid As Integer)
        Dim h As HarmonogramType = HarmonogramType.Load(workercode, time.ToShortDateString)

        If IsNothing(h) Then
            Dim shift As shiftType = shiftType.Load(zoneid, time.ToShortTimeString)

            Dim w As WorkerType = WorkerType.Load(workercode)

            h = New HarmonogramType
            h.Plan_Data = Now
            h.Plan_StartTime = time.ToShortDateString & " " & shift.starttime
            h.Plan_EndWorkTime = time.ToShortDateString & " " & shift.endtime
            h.Plan_WorkTime = shift.LenghtMinutes
            h.WorkerCode = workercode

            h.Exe_Data = h.Plan_Data
            h.Exe_StartTime = h.Plan_StartTime
            h.Exe_WorkTypeID = h.Plan_WorkTypeID


            h.zoneid = zoneid
            h.Plan_WorkTypeID = shift.idrg
            h.WorkerName = w.fullname
            h.Present = 1
            h.orgid = orgid
            h.Save()
        End If



        If h.ScanStart = #1/1/0001 12:00:00 AM# Then
            h.ScanStart = time
            If h.Exe_StartTime = #1/1/0001 12:00:00 AM# Then

            End If
            h.Exe_StartTime = time
            h.Present = 1

            If h.Plan_WorkTime = 0 Then
                h.Plan_WorkTime = 8 * 60
            End If

            Dim rg As RodzajGodzinType = RodzajGodzinType.Load(h.Plan_WorkTypeID)
            If rg.CzyPraca = False Then
                rg = RodzajGodzinType.Load("D")
            End If

            If h.Exe_WorkTime = 0 Then h.Exe_WorkTime = h.Plan_WorkTime
            h.Exe_WorkTypeID = rg.idrodzajgodzin
            h.Save()
            Exit Sub
        End If

        If h.ScanStop = #1/1/0001 12:00:00 AM# Then
            h.ScanStop = time
            If h.Exe_EndWorkTime = #1/1/0001 12:00:00 AM# Then

            End If
            h.Exe_EndWorkTime = time
            h.Present = 1
            If h.Exe_WorkTime = 0 Then h.Exe_WorkTime = h.Plan_WorkTime
            If h.Exe_WorkTypeID = 0 Then h.Exe_WorkTypeID = h.Plan_WorkTypeID
            h.Save()
            Exit Sub
        End If


    End Sub
    Public Sub ChangeWorkStart(newStart As DateTime)
        Me.Exe_StartTime = newStart


        Dim it As Integer = DateDiff(DateInterval.Minute, Me.Exe_StartTime, Me.Exe_EndWorkTime)
        If it < 0 Then it = -it
        Me.Exe_WorkTime = it
        Me.Save()


    End Sub
    Public Sub ChangeWorkEnd(newEnd As DateTime)
        Me.Exe_EndWorkTime = newEnd


        Dim it As Integer = DateDiff(DateInterval.Second, Me.Exe_StartTime, Me.Exe_EndWorkTime)
        If it < 0 Then it = -it
        Me.Exe_WorkTime = it
        Me.Save()


    End Sub

    Public Sub ChangeWorkType(newWorkTypeid As Integer)
        Dim rg As RodzajGodzinType = RodzajGodzinType.Load(newWorkTypeid)
        SetPresent(rg.obecny)
        Me.Exe_WorkTypeID = newWorkTypeid
        Me.Save()
    End Sub
    Public Sub SetPresent(Optional presentstate As Integer = 1)
        If presentstate = -1 Then presentstate = 1
        Me.Present = presentstate

        If Me.Present = 1 Then
            Me.Exe_StartTime = Me.Plan_StartTime
            Me.Exe_WorkTime = Me.Plan_WorkTime
            Me.Exe_WorkTypeID = Me.Plan_WorkTypeID
        Else

            Me.Exe_StartTime = "0001-01-01 00:00:00"
            Me.Exe_WorkTime = 0

        End If


        Me.Save()
    End Sub


    Public Sub New()
        Me._id = Guid.NewGuid.ToString
        Me.Present = 0
    End Sub

    Function Obecny(rg As RodzajGodzinType) As Boolean

        If IsNothing(rg) Then
            Return Obecny
        End If



        Dim zp As RodzajGodzinType = rg
        If IsNothing(zp) Then
            Return False
        End If


        If Me.Exe_StartTime.ToString <> "" And Me.Exe_WorkTime <> 0 Then
            If zp.CzyPraca = True Then
                Return True
            End If
        End If


        Return False

    End Function
    Function Obecny() As Boolean



        Dim zp As RodzajGodzinType = RodzajGodzinType.Load(Me.Exe_WorkTypeID)
        If IsNothing(zp) Then
            Return False
        End If


        If Me.Exe_StartTime.ToString <> "" And Me.Exe_WorkTime <> 0 Then
            If zp.CzyPraca = True Then
                Return True
            End If
        End If


        Return False

    End Function
    Public Sub Save()

        Me.Plan_EndWorkTime = Me.Plan_StartTime.Add(TimeSpan.FromMinutes(Me.Plan_WorkTime))

        Me.Exe_EndWorkTime = Me.Exe_StartTime.Add(TimeSpan.FromMinutes(Me.Exe_WorkTime))

        Me.Plan_Data = Me.Plan_StartTime.ToShortDateString


        Dim it As Integer = DateDiff(DateInterval.Minute, Me.Exe_StartTime, Me.Exe_EndWorkTime)
        If it < 0 Then it = -it
        'Me.Exe_WorkTime = it


        Dim m As New mongoDBCore
        m.Update(Of HarmonogramType)("harmonogram", Me._id, Me)
    End Sub
    Public Shared Function Load(data As Date, Optional zoneid As Integer = 0) As List(Of HarmonogramType)
        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("Plan_Data", New BsonRegularExpression("^" & Year(data) & "-" & Month(data).ToString("00") & ".*$", "i"))

        Load = m.GetObjectList(Of HarmonogramType)("harmonogram", filters)


    End Function
    Public Shared Function Load(id As String) As HarmonogramType

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("_id", id)



        Load = m.GetSingleObject(Of HarmonogramType)("harmonogram", filters)

    End Function
    Public Shared Function Load(orgid As Integer, Optional zoneid As Integer = 0, Optional workerCode As String = "") As List(Of HarmonogramType)
        Load = New List(Of HarmonogramType)

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("orgid", orgid)
        If zoneid <> 0 Then filters.Add("zoneid", zoneid)
        If workerCode <> "" Then filters.Add("WorkerCode", workerCode)

        Load = m.GetObjectList(Of HarmonogramType)("harmonogram", filters)

    End Function
    Public Shared Function Load(workerCode As String, data As String, plan_worktypeiid As Integer) As List(Of HarmonogramType)
        Load = New List(Of HarmonogramType)

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("WorkerCode", workerCode)
        filters.Add("Plan_WorkTypeID", plan_worktypeiid)

        Dim l As List(Of HarmonogramType) = m.GetObjectList(Of HarmonogramType)("harmonogram", filters)
        Load = New List(Of HarmonogramType)

        For Each o In l
            If o.Plan_Data.ToString.Contains(data) Then
                Load.Add(o)
            End If
        Next




    End Function
    Public Shared Function Load(workerCode As String, data As String) As HarmonogramType

        Dim m As New mongoDBCore()
        Dim filters As New Dictionary(Of String, Object)
        filters.Add("WorkerCode", workerCode)


        Dim l As List(Of HarmonogramType) = m.GetObjectList(Of HarmonogramType)("harmonogram", filters)

        For Each o In l
            If o.Plan_Data.ToString.Contains(data) Then
                Load = o
            End If
        Next


    End Function


    Public Shared Function Import(dt As DataTable, zoneid As Integer, orgid As Integer)

        Dim l As New List(Of HarmonogramType)
        Dim m As New mongoDBCore()


        For i = 0 To dt.Rows.Count - 1
            Dim h As New HarmonogramType
            h.zoneid = zoneid
            h.orgid = orgid
            h.WorkerCode = dt.Rows(i)("Nr prac")
            h.WorkerName = dt.Rows(i)("Nazwisko i imię")
            h.Plan_Data = dt.Rows(i)("Data")

            Dim st As String = dt.Rows(i)("Godz.rozpoczęcia")
            If String.IsNullOrEmpty(st) Then st = 0

            If InStr(st, ",", CompareMethod.Text) <> 0 Then
                Try
                    If st.Split(",")(1) < 10 Then
                        st = st & "0"
                    End If
                Catch ex As Exception

                End Try
                st = st.Replace(",", ":") & ":00"
            End If
            If InStr(st, ":", CompareMethod.Text) = 0 Then
                st = st & ":00"
            End If
            h.Plan_StartTime = h.Plan_Data & " " & TimeSpan.Parse(st).ToString

            st = dt.Rows(i)("Godz. przeprac.")
            If InStr(st, ",", CompareMethod.Text) <> 0 Then
                st = st.Replace(",", ":")
            End If
            If InStr(st, ":", CompareMethod.Text) = 0 Then
                st = st & ":00"
            End If
            h.Plan_WorkTime = TimeSpan.Parse(st).TotalMinutes
            h.Plan_WorkTypeID = RodzajGodzinType.Load(dt.Rows(i)("Rodzaj pracy").ToString).idrodzajgodzin


            h.Exe_WorkTime = 0

            l.Add(h)


            Dim w As WorkerType = WorkerType.Load(h.WorkerCode)
            If IsNothing(w) Then
                w = New WorkerType
                w.Active = 1
                w.Code = h.WorkerCode
                w.fullname = h.WorkerName
                Try
                    w.Surname = h.WorkerName.Split(" ")(0)
                    w.Name = h.WorkerName.Split(" ")(1)

                Catch ex As Exception

                End Try
                w.ZoneId = h.zoneid
                w.OrgID = h.orgid
                w.save()
                h.idworker = w.id
            Else
                h.idworker = w.id
            End If


            Dim hold As List(Of HarmonogramType) = HarmonogramType.Load(h.WorkerCode, h.Plan_Data.ToShortDateString, h.Plan_WorkTypeID)
            For Each ho In hold
                m.Delete(Of HarmonogramType)("harmonogram", ho)
            Next

            h.Save()

        Next






    End Function





    Public Class HarmonogramRozliczenieMasterType
        Public Property idworker As Integer
        Public Property l As List(Of HarmonogramRozliczenieType)

        Public Property SumPlanWorkTime As Integer
        Public Property SumExeWorkTime As Integer
        Public Property SumScanWorkTime As Integer
        Public Property SumWorkTypes As Dictionary(Of String, Integer)


        Public Function First() As HarmonogramRozliczenieType
            If Me.l.Count > 0 Then
                Return l(0)
            Else
                Return Nothing
            End If
        End Function

        Public Sub New(idworker As Integer, lh As List(Of HarmonogramRozliczenieType), lr As List(Of RodzajGodzinType))

            Me.l = New List(Of HarmonogramRozliczenieType)
            Me.idworker = idworker
            For Each o In lh
                If o.idworker = Me.idworker Then
                    Me.l.Add(o)
                End If
            Next


            SumWorkTypes = New Dictionary(Of String, Integer)

            Dim hourtypes = From o In l
                            Select o.Exe_WorkTypeID Distinct

            For Each r In hourtypes.ToList



                Me.SumWorkTypes.Add(r, 0)

            Next

            Me.SumPlanWorkTime = 0
            Me.SumExeWorkTime = 0
            Me.SumScanWorkTime = 0

            For Each h In l

                Me.SumPlanWorkTime += h.Plan_WorkTime
                Me.SumExeWorkTime += h.Exe_WorkTime
                Dim st As Integer = DateDiff(DateInterval.Minute, h.ScanStart, h.ScanStop)
                If st < 0 Then st = -st
                Me.SumScanWorkTime += st

                For Each hg In Me.SumWorkTypes
                    If hg.Key = h.Exe_WorkTypeID Then
                        Me.SumWorkTypes(hg.Key) += 1
                        Exit For

                    End If
                Next

            Next




        End Sub




        Public Function toDataTAble(lr As List(Of RodzajGodzinType)) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("_id")
            dt.Columns.Add("idworker")
            dt.Columns.Add("workercode")
            dt.Columns.Add("workername")
            dt.Columns.Add("day")
            dt.Columns.Add("plan_starttime")
            dt.Columns.Add("plan_endworktime")
            dt.Columns.Add("plan_worktime")
            dt.Columns.Add("plan_worktypeid")
            dt.Columns.Add("exe_starttime")
            dt.Columns.Add("exe_endworktime")
            dt.Columns.Add("exe_worktime")
            dt.Columns.Add("exe_worktypeid")
            dt.Columns.Add("scanstart")
            dt.Columns.Add("scanstop")
            dt.Columns.Add("present")
            dt.Columns.Add("target")
            dt.Columns.Add("descr")
            dt.Columns.Add("sumentryprivate")
            dt.Columns.Add("sumentrywork")
            dt.Columns.Add("r1")
            dt.Columns.Add("r2")
            dt.Columns.Add("scantime")


            For Each o In Me.l
                Dim _id As String = o._id
                Dim idworker As String = o.idworker
                Dim workercode As String = o.WorkerCode
                Dim workername As String = o.WorkerName
                Dim dd As String = o.Plan_StartTime.ToShortDateString & " " & o.Plan_Data.ToString("dddd")
                Dim plan_starttime As String = o.Plan_StartTime.ToShortTimeString
                Dim plan_endworktime As String = o.Plan_EndWorkTime.ToShortTimeString
                Dim tm As TimeSpan = TimeSpan.FromMinutes(o.Plan_WorkTime)
                Dim plan_worktime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
                Dim rg As RodzajGodzinType
                For Each r In lr
                    If r.idrodzajgodzin = o.Plan_WorkTypeID Then
                        rg = r
                        Exit For
                    End If
                Next
                Dim plan_worktypeid As String = rg.nazwa
                Dim exe_starttime As String = o.Exe_StartTime.ToShortTimeString
                Dim exe_endworktime As String = o.Exe_EndWorkTime.ToShortTimeString
                tm = TimeSpan.FromMinutes(o.Exe_WorkTime)
                Dim exe_worktime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
                For Each r In lr
                    If r.idrodzajgodzin = o.Exe_WorkTypeID Then
                        rg = r
                        Exit For
                    End If
                Next
                Dim exe_worktypeid As String = rg.nazwa
                Dim scanstart As String = o.ScanStart.ToShortTimeString
                Dim scanstop As String = o.ScanStop.ToShortTimeString
                Dim present As String = o.Present
                Dim target As String = o.Target
                Dim descr As String = o.Descr
                tm = TimeSpan.FromMinutes(o.SumEntryPrivate)
                Dim sumentryprivate As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
                tm = TimeSpan.FromMinutes(o.SumEntryWork)
                Dim sumentrywork As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
                tm = TimeSpan.FromMinutes((o.Exe_WorkTime - o.SumEntryPrivate) - o.Plan_WorkTime)
                Dim r1 As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")

                Dim sc As Integer = DateDiff(DateInterval.Minute, o.ScanStart, o.ScanStop)
                If sc < 0 Then sc = -sc
                tm = TimeSpan.FromMinutes((sc - o.SumEntryPrivate) - o.Plan_WorkTime)
                Dim r2 As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")
                tm = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, o.ScanStart, o.ScanStop))
                Dim scantime As String = tm.Hours.ToString("00") & ":" & tm.Minutes.ToString("00")

                dt.Rows.Add(
                _id,
    idworker,
    workercode,
    workername,
    dd,
    plan_starttime,
    plan_endworktime,
    plan_worktime,
    plan_worktypeid,
    exe_starttime,
    exe_endworktime,
    exe_worktime,
    exe_worktypeid,
    scanstart,
    scanstop,
    present,
    target,
    descr,
    sumentryprivate,
    sumentrywork,
    r1,
    r2,
    scantime
    )



            Next

            Return dt
        End Function

    End Class

    Public Class HarmonogramRozliczenieType
        Public Property _id As String
        Public Property idworker As Integer
        Public Property orgid As Integer
        Public Property zoneid As Integer

        Public Property WorkerCode As String
        Public Property WorkerName As String

        Public Property Plan_Data As Date
        Public Property Plan_StartTime As DateTime
        Public Property Plan_WorkTime As Integer
        Public Property Plan_EndWorkTime As DateTime
        Public Property Plan_WorkTypeID As Integer

        Public Property Exe_Data As Date
        Public Property Exe_StartTime As DateTime
        Public Property Exe_WorkTime As Integer
        Public Property Exe_WorkTypeID As Integer
        Public Property Exe_EndWorkTime As DateTime


        Public Property ScanStart As DateTime
        Public Property ScanStop As DateTime


        Public Property Present As Integer

        Public Property Target As String


        Public Property tempstatus As String

        Public Property Descr As String

        Public Property Entries As List(Of WorkerEntryType)

        Public Property SumEntryPrivate As Integer
        Public Property SumEntryWork As Integer



    End Class






End Class

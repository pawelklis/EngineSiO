Imports MongoDB.Bson
Imports MongoDB.Driver
Imports Newtonsoft.Json
Imports System
Imports System.Text
Imports System.Threading.Tasks


Public Class MongoDBReportsCore


    Public Shared Function PipeDistinct(fieldname As String) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$project", New BsonDocument().Add(fieldname, "$" & fieldname).Add("_id", 0)), New BsonDocument("$group", New BsonDocument().Add("_id", BsonNull.Value).Add("distinct", New BsonDocument().Add("$addToSet", "$$ROOT"))), New BsonDocument("$unwind", New BsonDocument().Add("path", "$distinct").Add("preserveNullAndEmptyArrays", New BsonBoolean(False))), New BsonDocument("$replaceRoot", New BsonDocument().Add("newRoot", "$distinct"))}
        Return pipeline
    End Function
    Public Shared Function PipeDistinct(fieldname As String, SecondFieldName As String) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$project", New BsonDocument().Add(fieldname, "$" & fieldname).Add(SecondFieldName, "$" & SecondFieldName).Add("_id", 0)), New BsonDocument("$group", New BsonDocument().Add("_id", BsonNull.Value).Add("distinct", New BsonDocument().Add("$addToSet", "$$ROOT"))), New BsonDocument("$unwind", New BsonDocument().Add("path", "$distinct").Add("preserveNullAndEmptyArrays", New BsonBoolean(False))), New BsonDocument("$replaceRoot", New BsonDocument().Add("newRoot", "$distinct"))}
        Return pipeline
    End Function
    Public Shared Function PipeDistinct(fieldname As String, SecondFieldName As String, ThirdFieldName As String) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$project", New BsonDocument().Add(fieldname, "$" & fieldname).Add(SecondFieldName, "$" & SecondFieldName).Add(ThirdFieldName, "$" & ThirdFieldName).Add("_id", 0)), New BsonDocument("$group", New BsonDocument().Add("_id", BsonNull.Value).Add("distinct", New BsonDocument().Add("$addToSet", "$$ROOT"))), New BsonDocument("$unwind", New BsonDocument().Add("path", "$distinct").Add("preserveNullAndEmptyArrays", New BsonBoolean(False))), New BsonDocument("$replaceRoot", New BsonDocument().Add("newRoot", "$distinct"))}
        Return pipeline
    End Function
    Public Shared Function PipeDistinct(fieldname As String, SecondFieldName As String, ThirdFieldName As String, FourthFieldname As String) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$project", New BsonDocument().Add(fieldname, "$" & fieldname).Add(SecondFieldName, "$" & SecondFieldName).Add(ThirdFieldName, "$" & ThirdFieldName).Add(FourthFieldname, "$" & FourthFieldname).Add("_id", 0)), New BsonDocument("$group", New BsonDocument().Add("_id", BsonNull.Value).Add("distinct", New BsonDocument().Add("$addToSet", "$$ROOT"))), New BsonDocument("$unwind", New BsonDocument().Add("path", "$distinct").Add("preserveNullAndEmptyArrays", New BsonBoolean(False))), New BsonDocument("$replaceRoot", New BsonDocument().Add("newRoot", "$distinct"))}
        Return pipeline
    End Function
    Public Shared Function PipeTerminowoscFAZ_Sumarycznie_Wg_Regionu_Ogolem(region As String, tydzien As Integer, rok As Integer) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {
            New BsonDocument("$match", New BsonDocument().Add("Jednostki_fazy_Region", region).Add("tydzien", "Tydzien " & tydzien & " " & rok)),
            New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Nazwa_fazy", "$Nazwa_fazy").Add("PNI", "$PNI")).Add("COUNT(Identyfikator_przesylki)", New BsonDocument().Add("$sum", 1)).Add("SUM(Terminowosc_fazy_dla_jednostki)", New BsonDocument().Add("$sum", "$Terminowosc_fazy_dla_jednostki")).Add("SUM(Sparametryzowana)", New BsonDocument().Add("$sum", "$Sparametryzowana")).Add("SUM(Terminowosc_E2E)", New BsonDocument().Add("$sum", "$Terminowosc_E2E"))),
            New BsonDocument("$project", New BsonDocument().Add("PNI", "$_id.PNI").Add("Nazwa_fazy", "$_id.Nazwa_fazy").Add("COUNT(Identyfikator_przesylki)", "$COUNT(Identyfikator_przesylki)").Add("SUM(Terminowosc_fazy_dla_jednostki)", "$SUM(Terminowosc_fazy_dla_jednostki)").Add("SUM(Sparametryzowana)", "$SUM(Sparametryzowana)").Add("SUM(Terminowosc_E2E)", "$SUM(Terminowosc_E2E)").Add("_id", 0))
        }

        Return pipeline
    End Function
    Public Shared Function PipeRegionTF0E2E0(tydzien As Integer, rok As Integer) As PipelineDefinition(Of BsonDocument, BsonDocument)

        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("tydzien", "Tydzien " & tydzien & " " & rok).Add("Terminowosc_E2E", New BsonInt64(0L)).Add("Terminowosc_fazy_dla_jednostki", New BsonInt64(0L))), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Jednostki_fazy_Region", "$Jednostki_fazy_Region").Add("Nazwa_fazy", "$Nazwa_fazy")).Add("COUNT(Identyfikator_przesylki)", New BsonDocument().Add("$sum", 1))), New BsonDocument("$project", New BsonDocument().Add("Jednostki_fazy_Region", "$_id.Jednostki_fazy_Region").Add("Nazwa_fazy", "$_id.Nazwa_fazy").Add("COUNT(Identyfikator_przesylki)", "$COUNT(Identyfikator_przesylki)").Add("_id", 0))}

        Return pipeline
    End Function
    Public Class pipeObject
        Public Property fieldname As String
        Public Property value As String
        Public Property typ As pipefieldType


        Public Enum pipefieldType
            filtruj = 0
            grupuj = 2
            count = 3
            sum = 4
        End Enum
    End Class
    Private Shared Function MakeMatch(fmatch As List(Of pipeObject)) As BsonValue
        Dim o As New BsonDocument
        For Each el In fmatch
            If el.typ = pipeObject.pipefieldType.filtruj Then
                o.Add(el.fieldname, el.value)
            End If
        Next

        Return o
    End Function
    Private Shared Function MakeGroup(fgroup As List(Of pipeObject)) As BsonValue

        Dim group As New BsonDocument
        Dim show As New BsonDocument
        Dim mathdoc As New List(Of BsonDocument)

        For Each el In fgroup

            If el.typ = pipeObject.pipefieldType.grupuj Then ' wcześniej było grupuj osobno ale bez sensu
                show.Add(el.fieldname, "$" & el.fieldname)
            End If
            If el.typ = pipeObject.pipefieldType.sum Then
                Dim o As New BsonDocument
                o.Add("SUM(" & el.fieldname & ")", New BsonDocument("$sum", "$" & el.fieldname))
                mathdoc.Add(o)
            End If
            If el.typ = pipeObject.pipefieldType.count Then
                Dim o As New BsonDocument
                o.Add("COUNT(" & el.fieldname & ")", New BsonDocument("$sum", 1))
                mathdoc.Add(o)

            End If
        Next

        group.Add("_id", show)

        For Each bs In mathdoc
            group.Add(bs)
        Next

        Return group
    End Function
    Private Shared Function MakeShow(fshow As List(Of pipeObject)) As BsonValue
        Dim o As New BsonDocument
        For Each el In fshow
            If el.typ = pipeObject.pipefieldType.grupuj Then
                o.Add(el.fieldname, "$_id." & el.fieldname)
            End If
            If el.typ = pipeObject.pipefieldType.sum Then
                o.Add("SUM(" & el.fieldname & ")", "$SUM(" & el.fieldname & ")")
            End If
            If el.typ = pipeObject.pipefieldType.count Then
                o.Add("COUNT(" & el.fieldname & ")", "$COUNT(" & el.fieldname & ")")


            End If


        Next
        o.Add("_id", 0)
        Return o
    End Function

    Public Shared Function CreatePipe(pipeList As List(Of pipeObject), tablename As String) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Try



            'Dim l As New List(Of pipeObject)
            'l.Add(New pipeObject With {.fieldname = "Jednostki_fazy_Region", .typ = pipeObject.pipefieldType.filtruj, .value = "RS Poznań"})
            'l.Add(New pipeObject With {.fieldname = "tydzien", .typ = pipeObject.pipefieldType.filtruj, .value = "Tydzien 5 2021"})

            'l.Add(New pipeObject With {.fieldname = "Nazwa_fazy", .typ = pipeObject.pipefieldType.grupuj, .value = ""})
            'l.Add(New pipeObject With {.fieldname = "PNI", .typ = pipeObject.pipefieldType.grupuj, .value = ""})

            'l.Add(New pipeObject With {.fieldname = "Nazwa_fazy", .typ = pipeObject.pipefieldType.grupuj, .value = ""})
            'l.Add(New pipeObject With {.fieldname = "PNI", .typ = pipeObject.pipefieldType.grupuj, .value = ""})

            'l.Add(New pipeObject With {.fieldname = "Identyfikator_przesylki", .typ = pipeObject.pipefieldType.count, .value = ""})
            'l.Add(New pipeObject With {.fieldname = "Terminowosc_fazy_dla_jednostki", .typ = pipeObject.pipefieldType.sum, .value = ""})
            'l.Add(New pipeObject With {.fieldname = "Sparametryzowana", .typ = pipeObject.pipefieldType.sum, .value = ""})

            Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument)

            pipeline = New BsonDocument() {
                New BsonDocument("$match", MakeMatch(pipeList)),
                New BsonDocument("$group", MakeGroup(pipeList)),
                New BsonDocument("$project", MakeShow(pipeList))
                }





            'Dim t As DataTable = GetReport(pipeline, tablename)  '1338


            'Debug.Print(t.ToString)

            Return pipeline
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Function

    Public Shared Function PipeTerminowoscFazwgDniaiUPirodzajuprzesylki(UP As String, tydzien As Integer, rok As Integer) As PipelineDefinition(Of BsonDocument, BsonDocument)

        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("Nazwa_jednostki", UP).Add("tydzien", "Tydzien " & tydzien & " " & rok)), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Nazwa_jednostki", "$Nazwa_jednostki").Add("tydzien", "$tydzien").Add("Nazwa_typu_przesylki", "$Nazwa_typu_przesylki").Add("Jednostki_fazy_Region", "$Jednostki_fazy_Region").Add("Dzien", "$Dzien").Add("PNI", "$PNI")).Add("COUNT(Identyfikator_przesylki)", New BsonDocument().Add("$sum", 1)).Add("SUM(Terminowosc_fazy_dla_jednostki)", New BsonDocument().Add("$sum", "$Terminowosc_fazy_dla_jednostki")).Add("SUM(Sparametryzowana)", New BsonDocument().Add("$sum", "$Sparametryzowana")).Add("SUM(Terminowosc_E2E)", New BsonDocument().Add("$sum", "$Terminowosc_E2E"))), New BsonDocument("$project", New BsonDocument().Add("Dzien", "$_id.Dzien").Add("PNI", "$_id.PNI").Add("Nazwa_jednostki", "$_id.Nazwa_jednostki").Add("Jednostki_fazy_Region", "$_id.Jednostki_fazy_Region").Add("tydzien", "$_id.tydzien").Add("Nazwa_typu_przesylki", "$_id.Nazwa_typu_przesylki").Add("COUNT(Identyfikator_przesylki)", "$COUNT(Identyfikator_przesylki)").Add("SUM(Terminowosc_fazy_dla_jednostki)", "$SUM(Terminowosc_fazy_dla_jednostki)").Add("SUM(Sparametryzowana)", "$SUM(Sparametryzowana)").Add("SUM(Terminowosc_E2E)", "$SUM(Terminowosc_E2E)").Add("_id", 0))}

        Return pipeline
    End Function
    Public Shared Function PipeTerminowoscStrukturaRodzajowPrzesylek(region As String, tydzien As Integer, rok As Integer) As PipelineDefinition(Of BsonDocument, BsonDocument)

        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("Jednostki_fazy_Region", region).Add("tydzien", "Tydzien " & tydzien & " " & rok)), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Nazwa_typu_przesylki", "$Nazwa_typu_przesylki")).Add("COUNT(Identyfikator_przesylki)", New BsonDocument().Add("$sum", 1)).Add("SUM(NSTD)", New BsonDocument().Add("$sum", "$NSTD")).Add("SUM(OPZ)", New BsonDocument().Add("$sum", "$OPZ")).Add("SUM(Terminowosc_fazy_dla_jednostki)", New BsonDocument().Add("$sum", "$Terminowosc_fazy_dla_jednostki")).Add("SUM(Sparametryzowana)", New BsonDocument().Add("$sum", "$Sparametryzowana"))), New BsonDocument("$project", New BsonDocument().Add("Nazwa_typu_przesylki", "$_id.Nazwa_typu_przesylki").Add("COUNT(Identyfikator_przesylki)", "$COUNT(Identyfikator_przesylki)").Add("SUM(NSTD)", "$SUM(NSTD)").Add("SUM(OPZ)", "$SUM(OPZ)").Add("SUM(Terminowosc_fazy_dla_jednostki)", "$SUM(Terminowosc_fazy_dla_jednostki)").Add("SUM(Sparametryzowana)", "$SUM(Sparametryzowana)").Add("_id", 0))}

        Return pipeline
    End Function
    Public Shared Function PipeHourSums(region As String, tydzien As Integer, rok As Integer) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("Jednostki_fazy_Region", region).Add("tydzien", "Tydzien " & tydzien & " " & rok)), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("godzinaWE", "$godzinaWE").Add("godzinaWY", "$godzinaWY").Add("tydzien", "$tydzien").Add("Nazwa_typu_przesylki", "$Nazwa_typu_przesylki").Add("Jednostki_fazy_Region", "$Jednostki_fazy_Region").Add("Dzien", "$Dzien").Add("Nazwa_fazy", "$Nazwa_fazy").Add("PNI", "$PNI")).Add("COUNT(Identyfikator_przesylki)", New BsonDocument().Add("$sum", 1)).Add("SUM(Terminowosc_fazy_dla_jednostki)", New BsonDocument().Add("$sum", "$Terminowosc_fazy_dla_jednostki")).Add("SUM(Terminowosc_E2E)", New BsonDocument().Add("$sum", "$Terminowosc_E2E")).Add("SUM(Sparametryzowana)", New BsonDocument().Add("$sum", "$Sparametryzowana"))), New BsonDocument("$project", New BsonDocument().Add("Jednostki_fazy_Region", "$_id.Jednostki_fazy_Region").Add("PNI", "$_id.PNI").Add("tydzien", "$_id.tydzien").Add("Dzien", "$_id.Dzien").Add("Nazwa_fazy", "$_id.Nazwa_fazy").Add("Nazwa_typu_przesylki", "$_id.Nazwa_typu_przesylki").Add("godzinaWE", "$_id.godzinaWE").Add("godzinaWY", "$_id.godzinaWY").Add("COUNT(Identyfikator_przesylki)", "$COUNT(Identyfikator_przesylki)").Add("SUM(Terminowosc_fazy_dla_jednostki)", "$SUM(Terminowosc_fazy_dla_jednostki)").Add("SUM(Terminowosc_E2E)", "$SUM(Terminowosc_E2E)").Add("SUM(Sparametryzowana)", "$SUM(Sparametryzowana)").Add("_id", 0))}

        Return pipeline
    End Function
    Public Shared Function Pipetfnad(region As String, tydzien As Integer, rok As Integer) As PipelineDefinition(Of BsonDocument, BsonDocument)
        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("Nazwa_fazy", "nadania").Add("Jednostki_fazy_Region", region).Add("tydzien", "Tydzien " & tydzien & " " & rok)), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("tydzien", "$tydzien").Add("Nazwa_typu_przesylki", "$Nazwa_typu_przesylki").Add("Jednostki_fazy_Region", "$Jednostki_fazy_Region").Add("Dzien", "$Dzien").Add("Nazwa_fazy", "$Nazwa_fazy").Add("PNI", "$PNI").Add("idkarta", "$idkarta")).Add("COUNT(Identyfikator_przesylki)", New BsonDocument().Add("$sum", 1))), New BsonDocument("$project", New BsonDocument().Add("Jednostki_fazy_Region", "$_id.Jednostki_fazy_Region").Add("PNI", "$_id.PNI").Add("tydzien", "$_id.tydzien").Add("Dzien", "$_id.Dzien").Add("Nazwa_typu_przesylki", "$_id.Nazwa_typu_przesylki").Add("idkarta", "$_id.idkarta").Add("COUNT(Identyfikator_przesylki)", "$COUNT(Identyfikator_przesylki)").Add("_id", 0))}

        Return pipeline
    End Function
    Public Shared Function GetReport(pipeline As PipelineDefinition(Of BsonDocument, BsonDocument), table As String) As DataTable
        Dim m As New mongoDBCore


        Dim client As IMongoClient = New MongoClient("mongodb://localhost/")
        Dim database As IMongoDatabase = client.GetDatabase("testowa")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)(table)
        Dim options = New AggregateOptions() With {
                .AllowDiskUse = False
            }



        Dim l As New StringBuilder
        l.AppendLine("[")

        Using cursor = collection.Aggregate(pipeline, options)

            While cursor.MoveNext()
                Dim batch = cursor.Current

                For Each document As BsonDocument In batch
                    Dim js As String = document.ToJson
                    'Console.WriteLine(document.ToJson())
                    l.AppendLine(js & ",")
                Next
            End While
        End Using
        l.AppendLine("]")
        Dim sl As String = l.ToString
        sl = sl.Replace(" { },", "0,").Replace("{ ""idrodzajgodzin"" :", "").Replace(" }, """, ",").Replace("  ", "")

        Dim returnData As DataTable = JsonConvert.DeserializeObject(Of DataTable)(sl)
        Return returnData

    End Function
    Public Shared Function test(year As Integer, month As Integer, zoneid As Integer) As DataTable

        End Function


        Public Shared Function Harmonogram_Pracownik_LiczbaDni(year As Integer, month As Integer, zoneid As Integer) As DataTable


            Dim m As New mongoDBCore


            Dim client As IMongoClient = New MongoClient("mongodb://localhost/")
            Dim database As IMongoDatabase = client.GetDatabase("testowa")
            Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("harmonogram")
            Dim options = New AggregateOptions() With {
                .AllowDiskUse = True
            }
            Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match",
New BsonDocument().Add("Plan_Data", New BsonRegularExpression("^" & year & "-" & month & ".*$", "i")).Add("zoneid",
New BsonInt64(zoneid))), New BsonDocument("$group", New BsonDocument().Add("_id",
New BsonDocument().Add("Exe_WorkTypeID", "$Exe_WorkTypeID").Add("Plan_WorkTypeID", "$Plan_WorkTypeID").Add("WorkerName", "$WorkerName")).Add("COUNT(*)",
New BsonDocument().Add("$sum", 1)).Add("SUM(Plan_WorkTime)", New BsonDocument().Add("$sum", "$Plan_WorkTime")).Add("SUM(Exec_WorkTime)",
New BsonDocument().Add("$sum", "$Exec_WorkTime"))), New BsonDocument("$project",
New BsonDocument().Add("COUNT(*)", "$COUNT(*)").Add("SUM(Plan_WorkTime)", "$SUM(Plan_WorkTime)").Add("SUM(Exec_WorkTime)", "$SUM(Exec_WorkTime)").Add("WorkerName", "$_id.WorkerName").Add("Plan_WorkTypeID", "$_id.Plan_WorkTypeID").Add("Exe_WorkTypeID", "$_id.Exe_WorkTypeID").Add("_id", 0)),
                New BsonDocument("$sort", New BsonDocument().Add("WorkerName", 1))}



            'Dim dt = collection.Aggregate(pipeline, options)

            Dim l As New StringBuilder
            l.AppendLine("[")

            Using cursor = collection.Aggregate(pipeline, options)

                While cursor.MoveNext()
                    Dim batch = cursor.Current

                    For Each document As BsonDocument In batch
                        Dim js As String = document.ToJson
                        Console.WriteLine(document.ToJson())
                        l.AppendLine(js & ",")
                    Next
                End While
            End Using
            l.AppendLine("]")

            Dim returnData As DataTable = JsonConvert.DeserializeObject(Of DataTable)(l.ToString)
            Return returnData
        End Function

        Public Shared Function Harmonogram_Zadania(d As Date, zoneid As Integer, onlycurrent As Boolean) As DataTable

            Dim m As New mongoDBCore


            Dim client As IMongoClient = New MongoClient("mongodb://localhost/")
            Dim database As IMongoDatabase = client.GetDatabase("testowa")
            Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("harmonogram")
            Dim options = New AggregateOptions() With {
                .AllowDiskUse = True
            }



            Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("$or", New BsonArray().Add(New BsonDocument().Add("$and", New BsonArray().Add(New BsonDocument().Add("Present", New BsonInt64(1L))).Add(New BsonDocument().Add("Exe_StartTime", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i"))).Add(New BsonDocument().Add("zoneid", New BsonInt64(zoneid))))).Add(New BsonDocument().Add("$and", New BsonArray().Add(New BsonDocument().Add("Present", New BsonInt64(1L))).Add(New BsonDocument().Add("Exe_EndWorkTime", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i"))).Add(New BsonDocument().Add("zoneid", New BsonInt64(zoneid))))))), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Exe_EndWorkTime", "$Exe_EndWorkTime").Add("idworker", "idworker").Add("Target", "$Target").Add("WorkerCode", "$WorkerCode").Add("Exe_StartTime", "$Exe_StartTime").Add("_id", "$_id").Add("Present", "$Present").Add("WorkerName", "$WorkerName").Add("Exe_WorkTypeID", "$Exe_WorkTypeID").Add("Exe_WorkTime", "$Exe_WorkTime"))), New BsonDocument("$project", New BsonDocument().Add("_id", "$_id._id").Add("WorkerCode", "$_id.WorkerCode").Add("WorkerName", "$_id.WorkerName").Add("idworker", "idworker").Add("Exe_StartTime", "$_id.Exe_StartTime").Add("Exe_WorkTypeID", "$_id.Exe_WorkTypeID").Add("Exe_WorkTime", "$_id.Exe_WorkTime").Add("Exe_EndWorkTime", "$_id.Exe_EndWorkTime").Add("Present", "$_id.Present").Add("Target", "$_id.Target").Add("Plan_StartTime", "$_id.Plan_StartTime")), New BsonDocument("$sort", New BsonDocument().Add("WorkerName", 1).Add("Plan_StartTime", 1)), New BsonDocument("$project", New BsonDocument().Add("_id", "$_id").Add("WorkerCode", "$WorkerCode").Add("WorkerName", "$WorkerName").Add("Exe_StartTime", "$Exe_StartTime").Add("Exe_WorkTypeID", "$Exe_WorkTypeID").Add("Exe_WorkTime", "$Exe_WorkTime").Add("Exe_EndWorkTime", "$Exe_EndWorkTime").Add("Present", "$Present").Add("Target", "$Target"))}



            Dim l As New StringBuilder
            l.AppendLine("[")

            Using cursor = collection.Aggregate(pipeline, options)

                While cursor.MoveNext()
                    Dim batch = cursor.Current

                    For Each document As BsonDocument In batch
                        Dim js As String = document.ToJson
                        Console.WriteLine(document.ToJson())
                        l.AppendLine(js & ",")
                    Next
                End While
            End Using
            l.AppendLine("]")
            Dim sl As String = l.ToString
            sl = sl.Replace(" { },", "0,").Replace("{ ""idrodzajgodzin"" :", "").Replace(" }, """, ",").Replace("  ", "")

            Dim returnData As New DataTable
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(sl)


            For x = 0 To dt.Columns.Count - 1
                returnData.Columns.Add(dt.Columns(x).ColumnName)
            Next

            If onlycurrent = True Then
                For i = 0 To dt.Rows.Count - 1
                    Dim st As Date = dt.Rows(i)("exe_starttime")
                    Dim et As Date = dt.Rows(i)("Exe_EndWorkTime")


                    If d >= st And d <= et Then
                        returnData.ImportRow(dt.Rows(i))
                    End If

                Next

            Else
                For i = 0 To dt.Rows.Count - 1
                    returnData.ImportRow(dt.Rows(i))
                Next

            End If



            Return returnData
        End Function

        Public Shared Function Harmonogram_Obecnosc_chart(d As Date, zoneid As Integer)
            Dim m As New mongoDBCore


            Dim client As IMongoClient = New MongoClient("mongodb://localhost/")
            Dim database As IMongoDatabase = client.GetDatabase("testowa")
            Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("harmonogram")
            Dim options = New AggregateOptions() With {
                .AllowDiskUse = True
            }


            Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("$or", New BsonArray().Add(New BsonDocument().Add("Plan_StartTime", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i"))).Add(New BsonDocument().Add("Plan_EndWorkTime", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i")))).Add("zoneid", New BsonInt64(zoneid))), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Plan_StartTime", "$Plan_StartTime")).Add("COUNT(*)", New BsonDocument().Add("$sum", 1)).Add("SUM(Present)", New BsonDocument().Add("$sum", "$Present"))), New BsonDocument("$project", New BsonDocument().Add("Plan_StartTime", "$_id.Plan_StartTime").Add("COUNT(*)", "$COUNT(*)").Add("SUM(Present)", "$SUM(Present)").Add("_id", 0)), New BsonDocument("$sort", New BsonDocument().Add("Plan_StartTime", 1))}

            Dim l As New StringBuilder
            l.AppendLine("[")

            Using cursor = collection.Aggregate(pipeline, options)

                While cursor.MoveNext()
                    Dim batch = cursor.Current

                    For Each document As BsonDocument In batch
                        Dim js As String = document.ToJson
                        Console.WriteLine(document.ToJson())
                        l.AppendLine(js & ",")
                    Next
                End While
            End Using
            l.AppendLine("]")
            Dim sl As String = l.ToString
            sl = sl.Replace(" { },", "0,").Replace("{ ""idrodzajgodzin"" :", "").Replace(" }, """, ",").Replace("  ", "")

            Dim returnData As DataTable = JsonConvert.DeserializeObject(Of DataTable)(sl)

            For i = 0 To returnData.Rows.Count - 1
                Dim ct As Integer = returnData.Rows(i)(1)
                Dim pt As Integer = returnData.Rows(i)(2)
                returnData.Rows(i)(1) = ct - pt


            Next


            Return returnData
        End Function
        Public Shared Function CrewTargetChart(d As Date, orgid As Integer)
            Dim m As New mongoDBCore


            Dim client As IMongoClient = New MongoClient("mongodb://localhost/")
            Dim database As IMongoDatabase = client.GetDatabase("testowa")
            Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("harmonogram")
            Dim options = New AggregateOptions() With {
                .AllowDiskUse = True
            }


            Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("Exe_StartTime", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i")).Add("orgid", New BsonInt64(orgid))), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Target", "$Target").Add("zoneid", "$zoneid")).Add("COUNT(*)", New BsonDocument().Add("$sum", 1))), New BsonDocument("$project", New BsonDocument().Add("zoneid", "$_id.zoneid").Add("Target", "$_id.Target").Add("COUNT(*)", "$COUNT(*)").Add("_id", 0))}


            Dim l As New StringBuilder
            l.AppendLine("[")

            Using cursor = collection.Aggregate(pipeline, options)

                While cursor.MoveNext()
                    Dim batch = cursor.Current

                    For Each document As BsonDocument In batch
                        Dim js As String = document.ToJson
                        Console.WriteLine(document.ToJson())
                        l.AppendLine(js & ",")
                    Next
                End While
            End Using
            l.AppendLine("]")
            Dim sl As String = l.ToString
            sl = sl.Replace(" { },", "0,").Replace("{ ""idrodzajgodzin"" :", "").Replace(" }, """, ",").Replace("  ", "")

            Dim returnData As DataTable = JsonConvert.DeserializeObject(Of DataTable)(sl)
            Return returnData
        End Function

    Public Shared Function Harmonogram_DzisiejszaObsada(year As Integer, month As Integer, day As Integer, zoneid As Integer) As DataTable

        Dim d As Date = year & "-" & month & "-" & day
        Dim d2 As Date = d.AddDays(-1)


        Dim m As New mongoDBCore


        Dim client As IMongoClient = New MongoClient("mongodb://localhost/")
        Dim database As IMongoDatabase = client.GetDatabase("testowa")
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("harmonogram")
        Dim options = New AggregateOptions() With {
            .AllowDiskUse = True
        }


        Dim md1 As String
        md1 = year & "-" & month & "-" & day
        If month < 10 Then
            md1 = year & "-0" & month & "-" & day
        End If
        If day < 10 Then
            md1 = year & "-" & month & "-0" & day
        End If
        If month < 10 And day < 10 Then
            md1 = year & "-0" & month & "-0" & day
        End If

        Dim md2 As String
        md2 = d2.Year & "-" & d2.Month & "-" & d2.Day
        If d2.Month < 10 Then
            md2 = d2.Year & "-0" & d2.Month & "-" & d2.Day
        End If
        If d2.Day < 10 Then
            md2 = d2.Year & "-" & d2.Month & "-0" & d2.Day
        End If
        If d2.Month < 10 And d2.Day < 10 Then
            md2 = d2.Year & "-0" & d2.Month & "-0" & d2.Day
        End If


        d = md1

        Dim pipeline As PipelineDefinition(Of BsonDocument, BsonDocument) = New BsonDocument() {New BsonDocument("$match", New BsonDocument().Add("$or", New BsonArray().Add(New BsonDocument().Add("$and", New BsonArray().Add(New BsonDocument().Add("Plan_Data", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i"))).Add(New BsonDocument().Add("zoneid", New BsonInt64(zoneid))).Add(New BsonDocument().Add("Plan_WorkTime", New BsonDocument().Add("$ne", New BsonInt64(0L)))))).Add(New BsonDocument().Add("$and", New BsonArray().Add(New BsonDocument().Add("Plan_EndWorkTime", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i"))).Add(New BsonDocument().Add("zoneid", New BsonInt64(zoneid))).Add(New BsonDocument().Add("Plan_WorkTime", New BsonDocument().Add("$ne", New BsonInt64(0L)))))).Add(New BsonDocument().Add("$and", New BsonArray().Add(New BsonDocument().Add("ScanStart", New BsonRegularExpression("^" & d.ToShortDateString & ".*$", "i"))).Add(New BsonDocument().Add("zoneid", New BsonInt64(zoneid))))))), New BsonDocument("$group", New BsonDocument().Add("_id", New BsonDocument().Add("Exe_EndWorkTime", "$Exe_EndWorkTime").Add("WorkerCode", "$WorkerCode").Add("Plan_WorkTypeID", "$Plan_WorkTypeID").Add("Exe_StartTime", "$Exe_StartTime").Add("_id", "$_id").Add("Plan_WorkTime", "$Plan_WorkTime").Add("ScanStop", "$ScanStop").Add("Plan_StartTime", "$Plan_StartTime").Add("Plan_EndWorkTime", "$Plan_EndWorkTime").Add("Present", "$Present").Add("ScanStart", "$ScanStart").Add("WorkerName", "$WorkerName").Add("Exe_WorkTypeID", "$Exe_WorkTypeID").Add("Exe_WorkTime", "$Exe_WorkTime"))), New BsonDocument("$project", New BsonDocument().Add("_id", "$_id._id").Add("WorkerCode", "$_id.WorkerCode").Add("WorkerName", "$_id.WorkerName").Add("Plan_StartTime", "$_id.Plan_StartTime").Add("Plan_WorkTime", "$_id.Plan_WorkTime").Add("Plan_EndWorkTime", "$_id.Plan_EndWorkTime").Add("Plan_WorkTypeID", "$_id.Plan_WorkTypeID").Add("Exe_StartTime", "$_id.Exe_StartTime").Add("Exe_WorkTypeID", "$_id.Exe_WorkTypeID").Add("Exe_WorkTime", "$_id.Exe_WorkTime").Add("Exe_EndWorkTime", "$_id.Exe_EndWorkTime").Add("Present", "$_id.Present").Add("ScanStart", "$_id.ScanStart").Add("ScanStop", "$_id.ScanStop")), New BsonDocument("$sort", New BsonDocument().Add("Plan_StartTime", 1).Add("WorkerName", 1))}


        Dim l As New StringBuilder
        l.AppendLine("[")

        Using cursor = collection.Aggregate(pipeline, options)

            While cursor.MoveNext()
                Dim batch = cursor.Current

                For Each document As BsonDocument In batch
                    Dim js As String = document.ToJson
                    Console.WriteLine(document.ToJson())
                    l.AppendLine(js & ",")
                Next
            End While
        End Using
        l.AppendLine("]")
        Dim sl As String = l.ToString
        sl = sl.Replace(" { },", "0,").Replace("{ ""idrodzajgodzin"" :", "").Replace(" }, """, ",").Replace("  ", "")

        Dim returnData As DataTable = JsonConvert.DeserializeObject(Of DataTable)(sl)
        Return returnData
    End Function







    Public Class GlobalReportData
        Public Property _id As String
        Public Property rok As Integer
        Public Property tydzien As Integer
        Public Property sources As List(Of GRDSource)

        Sub New()
            Me._id = Guid.NewGuid.ToString
            Me.sources = New List(Of GRDSource)
        End Sub
        Public Sub save()
            Dim m As New mongoDBCore
            m.Update(Of GlobalReportData)("grd", Me._id, Me)
        End Sub

        Public Function GetSource(number As Integer) As GRDSource
            For Each s In Me.sources
                If s.Number = number Then Return s
            Next
        End Function
        Public Shared Function Load(tydzien As Integer, rok As Integer) As GlobalReportData
            Dim m As New mongoDBCore
            Dim f As New Dictionary(Of String, Object)
            f.Add("tydzien", tydzien)
            f.Add("rok", rok)
            Return m.GetSingleObject(Of GlobalReportData)("grd", f)
        End Function
        Public Class GRDSource
            Public Property Number As Integer
            Public Property Name As String
            Public Property dt As DataTable
        End Class

    End Class

    Public Shared Function getGlobalReportData(tydzien As Integer, rok As Integer)
        Return GlobalReportData.Load(tydzien, rok)
    End Function
    Public Shared Function CreateGlobalReportData(tydzien As Integer, rok As Integer)
        Dim m As mySQLcore = mySQLcore.DB_Main



        Dim GRD As New GlobalReportData
        GRD.Rok = rok
        GRD.Tydzien = tydzien

        Dim source As GlobalReportData.GRDSource

        source = New GlobalReportData.GRDSource
        source.Number = 1
        source.Name = "Liczba przesyłek wg regionu, tydzień:" & tydzien & " " & rok
        source.dt = m.FillDatatable("select region as 'Region',sum(lp) as 'lp' from tfobrot where tydzien =" & tydzien & " and rok=" & rok & " group by region;")
        GRD.sources.Add(source)

        source = New GlobalReportData.GRDSource
        source.Number = 2
        source.Name = "Udział poszczególnych rodzajów przesyłek w ogólnej liczbie przesyłek, tydzień:" & tydzien & " " & rok
        source.dt = m.FillDatatable("select typp,sum(wszystkie) as 'lp' from tfhoursums where tydzien ='Tydzien " & tydzien & " " & rok & "' group by typp;")

        source.dt.Columns.Add("udzial")
        Dim sumall As Integer = 0
        For i = 0 To source.dt.Rows.Count - 1
            sumall += source.dt.Rows(i)("lp")
        Next
        For i = 0 To source.dt.Rows.Count - 1
            Dim lp As Integer = source.dt.Rows(i)("lp")
            source.dt.Rows(i)("udzial") = Math.Round(lp / sumall, 2)
        Next
        GRD.sources.Add(source)

        source = New GlobalReportData.GRDSource
        source.Number = 3
        source.Name = "Liczba przesyłek ze świadczeniem NG wg regionu w fazie nadania, tydzień:" & tydzien & " " & rok

        Dim l As New List(Of MongoDBReportsCore.pipeObject)
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Jednostki_fazy_Region", .typ = 2, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "NSTD", .typ = 4, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "OPZ", .typ = 4, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Terminowosc_fazy_dla_jednostki", .typ = 4, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Sparametryzowana", .typ = 4, .value = ""})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "tydzien", .typ = 0, .value = "Tydzien " & tydzien & " " & rok})
        l.Add(New MongoDBReportsCore.pipeObject With {.fieldname = "Nazwa_fazy", .typ = 0, .value = "nadania"})

        source.dt = MongoDBReportsCore.GetReport(MongoDBReportsCore.CreatePipe(l, "tf"), "tf")

        source.dt.Columns("SUM(NSTD)").ColumnName = "NSTD"
        source.dt.Columns("SUM(OPZ)").ColumnName = "OPZ"
        source.dt = source.dt
        GRD.sources.Add(source)


        source = New GlobalReportData.GRDSource
        source.Number = 4
        source.Name = "Liczba przesyłek wg regionu, tydzień:" & tydzien & " " & rok
        source.dt = MongoDBReportsCore.GetReport(MongoDBReportsCore.PipeRegionTF0E2E0(tydzien, rok), "tf")

        source.dt.Columns("COUNT(Identyfikator_przesylki)").ColumnName = "lp"
        source.dt.Columns.Add("udzial")

        sumall = 0
        For i = 0 To source.dt.Rows.Count - 1
            sumall += source.dt.Rows(i)("lp")
        Next


        For i = 0 To source.dt.Rows.Count - 1
            Dim lp As Integer = source.dt.Rows(i)("lp")
            source.dt.Rows(i)("udzial") = Math.Round(lp / sumall, 2)
        Next
        GRD.sources.Add(source)


        GRD.save()

    End Function





End Class



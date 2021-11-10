


Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports MongoDB.Bson
Imports MongoDB.Bson.Serialization
Imports MongoDB.Bson.Serialization.Serializers
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Newtonsoft.Json

Public Class CoreMongoDB
    ''' <summary>
    ''' "mongodb://localhost/"
    ''' </summary>
    ''' <returns></returns>
    Public Property ConnectionString As String = "mongodb://localhost/"
    Public Property DBName As String = "testowa"
    Property DataBase As MongoDatabase

    Sub New(Optional ConnectionString As String = "mongodb://localhost/", Optional DBName As String = "testowa")
        Me.ConnectionString = ConnectionString
        Me.DBName = DBName

        Me.DataBase = Me.Connect()

    End Sub

    Private Function Connect() As MongoDatabase
        Dim server As MongoServer
        Dim client As MongoClient
        Dim db As MongoDatabase

        client = New MongoClient(Me.ConnectionString)
        db = client.GetServer().GetDatabase(Me.DBName)
        Return db


    End Function

    Public Function GetDistinct(TableName As String, FieldName As String) As List(Of String)
        Dim coll = Me.DataBase.GetCollection(TableName)
        Dim bl = coll.Distinct(FieldName).ToList
        Dim l As New List(Of String)

        For Each b In bl
            l.Add(b.ToString)
        Next

        Return l
    End Function
    Public Function GetSingleObject(Of T As New)(TableName As String, Optional Filters As Dictionary(Of String, String) = Nothing)
        Dim qf
        Dim queries As New List(Of IMongoQuery)

        For Each f In Filters
            Dim qu As IMongoQuery
            qu = Query.EQ(f.Key, f.Value)
            queries.Add(qu)
        Next

        qf = Query.And(queries.ToArray)

        Dim coll = Me.DataBase.GetCollection(TableName)


        Dim result



        If IsNothing(Filters) Then
            result = coll.FindAll.ToList
        Else
            result = coll.Find(qf).ToList
        End If


        Dim x
        If result.count > 0 Then x = BsonToObject(Of T)(result(0))
        Return x
    End Function
    Public Function GetObjectList(Of T As New)(TableName As String, Optional FieldName As String = Nothing, Optional Value As String = Nothing) As List(Of T)


        Dim qu
        If Not IsNothing(FieldName) Then
            qu = Query.EQ(FieldName, Value)
        End If


        Dim coll = Me.DataBase.GetCollection(TableName)


        Dim result



        If IsNothing(FieldName) Or IsNothing(Value) Then
            result = coll.FindAll.ToList
        Else
            result = coll.Find(qu).ToList
        End If

        Dim l As New List(Of T)
        For Each o In result
            l.Add(BsonToObject(Of T)(o))
        Next

        Return l
    End Function
    Public Function Insert(Of T As New)(TableName As String, ob As Object)
        Dim coll = Me.DataBase.GetCollection(TableName)

        Dim JsonString As String = JsonConvert.SerializeObject(ob)

        Dim bs As BsonDocument = BsonDocument.Parse(JsonString)


        coll.Insert(bs)

    End Function
    Public Function Update(Of T As New)(TableName As String, _id As String, ob As Object)
        Dim coll = Me.DataBase.GetCollection(TableName)

        Dim JsonString As String = JsonConvert.SerializeObject(ob)

        Dim bs As BsonDocument = BsonDocument.Parse(JsonString)


        coll.Save(bs)



    End Function

    Class testclas
        Public Property _id As String
        Public Property Dzień As String

        Public Property Identyfikator_przesyłki As String

        Public Property Kod__jednostki As String

        Public Property Nazwa_jednostki As String

        Public Property Region As String

        Public Property Nazwa_fazy As String

    End Class

    Function ObjectToBson(Of T As New)(ob As Object) As BsonDocument



        Dim ds As New Dictionary(Of String, Object)

        Dim Props = GetType(T).GetProperties()
        For Each p In Props
            If p.Name.ToLower = "_id" Then
                ds.Add(p.Name.ToString, p.GetValue(ob))
            Else
                ds.Add(p.Name.ToString.Replace("_", " "), p.GetValue(ob))
            End If
        Next

        Dim bs As New BsonDocument(ds)
        Return bs
    End Function
    Function BsonToObject(Of T As New)(bs As BsonDocument) As T

        Dim Props = GetType(T).GetProperties()
        Dim a
        Dim JsonString As String = bs.ToJson
        JsonString = JsonString.Replace("ObjectId(", "").Replace("),", ",")
        a = JsonConvert.DeserializeObject(JsonString, GetType(T))

        Return a
    End Function







End Class



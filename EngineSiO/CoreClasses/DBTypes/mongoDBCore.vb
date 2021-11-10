

Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports MongoDB.Bson
Imports MongoDB.Bson.Serialization
Imports MongoDB.Bson.Serialization.Serializers
Imports MongoDB.Driver
Imports MongoDB.Driver.Builders
Imports Newtonsoft.Json

Public Class mongoDBCore
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
    Public Function GetSingleObject(Of T As New)(TableName As String, Optional Filters As Dictionary(Of String, Object) = Nothing)

        Dim qf
        Dim queries As New List(Of IMongoQuery)
        If Not IsNothing(Filters) Then
            For Each f In Filters
                Dim qu As IMongoQuery
                Dim b = BsonValue.Create(f.Value).AsBsonValue
                If IsNumeric(b) Then
                    qu = Query.EQ(f.Key, b)
                Else
                    qu = Query.EQ(f.Key, b)
                End If

                queries.Add(qu)
            Next

            qf = Query.And(queries.ToArray)
        End If



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
    Public Function GetObjectList(Of T As New)(TableName As String, Optional Filters As Dictionary(Of String, Object) = Nothing) As List(Of T)


        Dim qf
        Dim queries As New List(Of IMongoQuery)
        If Not IsNothing(Filters) Then
            For Each f In Filters
                Dim qu As IMongoQuery
                Dim b = BsonValue.Create(f.Value).AsBsonValue
                If IsNumeric(b) Then
                    qu = Query.EQ(f.Key, b)
                Else
                    qu = Query.EQ(f.Key, b)
                End If

                queries.Add(qu)
            Next

            qf = Query.And(queries.ToArray)
        End If







        Dim coll = Me.DataBase.GetCollection(TableName)


        Dim result


        If IsNothing(Filters) Then
            result = coll.FindAll.ToList
        Else
            result = coll.Find(qf).ToList
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

    Public Function InsertList(Of T As New)(l As List(Of Object), TableName As String)
        Dim coll = Me.DataBase.GetCollection(TableName)

        Dim mongoClient = New MongoClient(ConnectionString)
        Dim db = mongoClient.GetDatabase(Me.DataBase.Name)

        Dim products = Me.DataBase.GetCollection(TableName)

        Using session = mongoClient.StartSession()

            Try
                session.StartTransaction()

                For Each o In l
                    Dim JsonString As String = JsonConvert.SerializeObject(o)

                    Dim bs As BsonDocument = BsonDocument.Parse(JsonString)

                    coll.Insert(bs)
                Next



                session.CommitTransaction()
            Catch __unusedException1__ As Exception
                session.AbortTransaction()
            End Try
        End Using


    End Function

    Public Function Delete(Of T As New)(TableName As String, ob As Object)
        Dim coll = Me.DataBase.GetCollection(TableName)

        Dim id As String = ob._id

        Dim q = New QueryDocument("_id", id)
        coll.Remove(q)

    End Function
    Public Shared Function Delete(coll As MongoCollection, id As String)

        If Not IsNothing(id) Then
            Dim q = New QueryDocument("_id", id)
            coll.Remove(q)
        End If




    End Function

    Public Shared Function drop(tablename As String)
        Dim m As New mongoDBCore
        Dim coll = m.DataBase.GetCollection(tablename)
        Return coll.Drop()

    End Function
    Public Shared Function Delete(TableName As String, filters As Dictionary(Of String, Object))
        Dim m As New mongoDBCore
        Dim coll = m.DataBase.GetCollection(TableName)



        Dim qf
        Dim queries As New List(Of IMongoQuery)
        If Not IsNothing(filters) Then
            For Each f In filters
                Dim qu As IMongoQuery
                Dim b = BsonValue.Create(f.Value).AsBsonValue
                If IsNumeric(b) Then
                    qu = Query.EQ(f.Key, b)
                Else
                    qu = Query.EQ(f.Key, b)
                End If

                queries.Add(qu)
            Next

            qf = Query.And(queries.ToArray)
        End If

        Dim a As WriteConcernResult = coll.Remove(qf)
        Return a.DocumentsAffected
    End Function
    Public Function Update(Of T As New)(TableName As String, _id As String, ob As Object)
        Dim coll = Me.DataBase.GetCollection(TableName)

        Dim JsonString As String = JsonConvert.SerializeObject(ob)

        Dim bs As BsonDocument = BsonDocument.Parse(JsonString)

        Delete(coll, _id)

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

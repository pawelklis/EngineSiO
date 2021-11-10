Imports System.ComponentModel
Imports System.Reflection

<Serializable> Public Class RodzajGodzinType

    Public Shared NazwaTabeli As String = "rodzajgodzin"
    Public Shared KolumnaID As String = "idrodzajgodzin"

    Public Property idrodzajgodzin As Integer
    Public Property nazwa As String
    Public Property opis As String
    Public Property zmianapracy As Integer
    Public Property domdzien As Integer
    Public Property domnoc As Integer
    Public Property urlop As Integer
    Public Property krytyczne As Integer
    Public Property aktywny As Integer
    Public Property abplan As Integer
    Public Property ab As Integer
    Public Property rodzajpracycsip As String
    Public Property obecny As Integer


    Public Function CzyPraca() As Boolean
        If Me.aktywny = 1 And Me.abplan = 0 And ab = 0 And urlop = 0 And obecny = 1 Then
            Return True
        End If


        Return False
    End Function
    Public Function Nazwa_opis() As String
        Return Me.nazwa & " - " & Me.opis
    End Function
    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        m.InsertOrUpdate(NazwaTabeli, KolumnaID, Me)

    End Sub
    Public Shared Function Load(iudrodzajgodzin As Integer) As RodzajGodzinType

        If iudrodzajgodzin = 0 Then
            Dim r As New RodzajGodzinType
            r.idrodzajgodzin = 0
            Return r
        End If


        Dim m As mySQLcore = mySQLcore.DB_Main

        Dim l As List(Of RodzajGodzinType)
        l = m.GetObject(Of RodzajGodzinType)("Select * from rodzajgodzin where  idrodzajgodzin  = '" & iudrodzajgodzin & "';")
        'c_lok_idc_lok='" & idc_lok & "' and 
        If Not IsNothing(l) Then
            If l.Count > 0 Then
                Return l(0)
            End If
        End If






    End Function
    Public Shared Function Load() As List(Of RodzajGodzinType)
        Dim m As mySQLcore = mySQLcore.DB_Main

        Dim l As List(Of RodzajGodzinType)
        l = m.GetObject(Of RodzajGodzinType)("Select * from rodzajgodzin;")
        'c_lok_idc_lok='" & idc_lok & "' and 
        Return l



    End Function
    Public Shared Function Load(nazwa As String) As RodzajGodzinType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Return m.GetSingleObject(Of RodzajGodzinType)("select * from rodzajgodzin where nazwa='" & nazwa & "';")
    End Function
End Class

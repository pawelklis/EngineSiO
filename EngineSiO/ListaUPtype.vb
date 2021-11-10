
<DebuggerDisplay("UP:{UP},Region:{REGION},PNI:{PNI}")>
Public Class ListaUPtype

    Public Property id As Integer
    Public Property UP As String
    Public Property REGION As String
    Public Property PNI As String

    Public Property KOD As String


    Public Shared Function Load() As List(Of ListaUPtype)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Load = m.GetObject(Of ListaUPtype)("select * from listaup")
    End Function
    Public Shared Function Load(PNI As Integer) As ListaUPtype
        Dim m As mySQLcore = mySQLcore.DB_Main
        Load = m.GetSingleObject(Of ListaUPtype)("select * from listaup where pni=" & PNI)
    End Function
End Class

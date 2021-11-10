



Public Class tfJednostkaDataType
    Public Property _id As String
    Public Property Region As String
    Public Property Tydzien As String


    Public Property Nazwa As String
        Public Property Kod As String

        Public Property Fazy As List(Of FazaType)

    Sub New()
        Me._id = Guid.NewGuid.ToString
        Me.Fazy = New List(Of FazaType)
    End Sub







    Public Class FazaType
        Public Property _id As String
        Public Property NazwaFazy As String
        Public Property Terminowe As List(Of tfdzienType)
        Public Property Nieterminowe As List(Of tfdzienType)
        Public Property Niesparametryzowane As List(Of tfdzienType)

        Sub New()
            Me._id = Guid.NewGuid.ToString
            Me.Terminowe = New List(Of tfdzienType)
            Me.Nieterminowe = New List(Of tfdzienType)
            Me.Niesparametryzowane = New List(Of tfdzienType)

        End Sub


        Public Class tfdzienType
            Public Property _id As String
            Public Property Przesylki As List(Of tPrzesylkaType)


            Sub New()
                Me._id = Guid.NewGuid.ToString
                Me.Przesylki = New List(Of tPrzesylkaType)
            End Sub


        End Class

    End Class

End Class





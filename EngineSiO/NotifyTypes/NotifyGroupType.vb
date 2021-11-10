Imports Newtonsoft.Json

Public Class NotifyGroupType
    Public Property id As Integer
    Public Property name As String
    Public Property RecipientListField As String
    Public Recipients As List(Of UserType)
    Public RecipientsIDList As List(Of Integer)

    Public Property Active As Integer

    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main


        Me.RecipientListField = JsonConvert.SerializeObject(Me.RecipientsIDList)

        If Me.id = 0 Then
            m.Insert("notifygroup", "id", Me)
        Else
            m.Update("notifygroup", "id", Me)
        End If

    End Sub
    Public Shared Function Load(id As Integer) As NotifyGroupType
        If id = 0 Then Return Nothing
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As NotifyGroupType = m.GetSingleObject(Of NotifyGroupType)("select * from notifygroup where id =" & id & "")

        oo.RecipientsIDList = JsonConvert.DeserializeObject(Of List(Of Integer))(oo.RecipientListField)

        If IsNothing(oo.RecipientsIDList) Then oo.RecipientsIDList = New List(Of Integer)

        oo.Recipients = New List(Of UserType)
        For Each i In oo.RecipientsIDList
            oo.Recipients.Add(UserType.Load(i))
        Next

        Return oo
    End Function
    Public Shared Function Load() As List(Of NotifyGroupType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As List(Of NotifyGroupType) = m.GetObject(Of NotifyGroupType)("select * from notifygroup where active =1")

        For Each o In oo
            o.RecipientsIDList = JsonConvert.DeserializeObject(Of List(Of Integer))(o.RecipientListField)
        Next



        Return oo
    End Function


End Class

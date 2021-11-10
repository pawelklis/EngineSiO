Public Class OperationType

    Public Property Id As Integer
    Public Property Name As String
    Public Property formatkaid As Integer
    Public Property OperationCategoryID As Integer
    Public Property Active As Integer
    Public Property OrgID As Integer
    Public Property ZoneID As Integer
    Public Property InfoId As Integer
    Public Property NotifyGroupID As Integer

    Public Parameters As List(Of FrmParametersType)
    Public Notifies As NotifyGroupType
    Public Info As InfoConfigType

    Sub New()

    End Sub
    Public Sub New(f As Formatka)
        Me.Save()

        Select Case f
            Case Formatka.PobierzSkaner
                Dim l As New List(Of FrmParametersType)
                For Each fp In frmTypes.GetScanner
                    Dim p As New FrmParametersType
                    p.Key = fp.key
                    p.Value = fp.value
                    p.ValueType = fp.valuetype
                    p.OperationID = Me.Id
                    p.Save()
                Next



        End Select
    End Sub
    Public Sub Save()
        Dim m As mySQLcore = mySQLcore.DB_Main

        If Me.Id = 0 Then
            m.Insert("oper", "id", Me)



            AddParameters()

        Else



            Dim o As OperationType = Load(Me.Id)
            If o.formatkaid <> Me.formatkaid Then
                m.ExecuteNonQuery("delete from frmparameters where operationid=" & Me.Id)
                AddParameters()
            End If




            m.Update("oper", "id", Me)
        End If

    End Sub

    Sub AddParameters()
        Select Case Me.formatkaid
            Case Formatka.PobierzSkaner

                For Each fp In frmTypes.GetScanner
                    Dim p As New FrmParametersType
                    p.Key = fp.key
                    p.Value = fp.value
                    p.ValueType = fp.valuetype
                    p.OperationID = Me.Id
                    p.Save()
                Next

            Case Formatka.ZdajSkaner
                For Each fp In frmTypes.LeftScanner
                    Dim p As New FrmParametersType
                    p.Key = fp.key
                    p.Value = fp.value
                    p.ValueType = fp.valuetype
                    p.OperationID = Me.Id
                    p.Save()
                Next
            Case Formatka.StartPracy
                For Each fp In frmTypes.StartPracy
                    Dim p As New FrmParametersType
                    p.Key = fp.key
                    p.Value = fp.value
                    p.ValueType = fp.valuetype
                    p.OperationID = Me.Id
                    p.Save()
                Next


        End Select
    End Sub
    Public Shared Function Load(id As Integer) As OperationType
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As OperationType = m.GetSingleObject(Of OperationType)("select * from oper where id =" & id & "")

        If Not IsNothing(oo) Then
            oo.Parameters = FrmParametersType.Load(oo.Id.ToString)
            oo.Info = InfoConfigType.Load(oo.InfoId)
            oo.Notifies = NotifyGroupType.Load(oo.NotifyGroupID)
        End If



        Return oo
    End Function
    Public Shared Function Load() As List(Of OperationType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As List(Of OperationType) = m.GetObject(Of OperationType)("select * from oper where active =1")
        Return oo
    End Function

    Public Shared Function Load(opercatid As Integer, idzone As Integer) As List(Of OperationType)
        Dim m As mySQLcore = mySQLcore.DB_Main
        Dim oo As List(Of OperationType) = m.GetObject(Of OperationType)("select * from oper where operationcategoryid=" & opercatid & " and zoneid=" & idzone & " and active =1")
        Return oo
    End Function
End Class

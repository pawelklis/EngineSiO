Imports System.Reflection

Public Class frmEdit

    Public o As Object
    Public T As Type


    Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddControls()

    End Sub
    Sub AddControls()
        Dim props As PropertyInfo() = T.GetProperties

        Dim level As Integer = 20

        For Each p In props
            Dim l As New Label
            l.Text = p.Name

            l.Left = 10
            l.Top = level

            Me.Controls.Add(l)

            Dim tx As New TextBox
            tx.Name = p.Name
            tx.Text = p.GetValue(o)

            tx.Left = 300
            tx.Top = level

            Me.Controls.Add(tx)

            level += 30


        Next


        Dim ff = T.GetFields



        For Each f In ff


            props = f.FieldType.GetProperties

            For Each p In props
                Dim l As New Label
                l.Text = p.Name

                l.Left = 10
                l.Top = level

                Me.Controls.Add(l)

                Dim tx As New TextBox
                tx.Name = p.Name

                Dim inf As FieldInfo = o.GetType.GetField(f.Name)

                tx.Text = inf.GetValue(o)

                tx.Left = 300
                tx.Top = level

                Me.Controls.Add(tx)

                level += 30
            Next




        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim props As PropertyInfo() = T.GetProperties

        For Each c As Control In Me.Controls
            If c.GetType() = GetType(TextBox) Then



                For Each p In props
                    If p.Name = c.Name Then
                        p.SetValue(o, Convert.ChangeType(c.Text, p.PropertyType))
                    End If
                Next

                Dim ff = T.GetFields

                If c.Name <> "Id" Then
                    For Each f In ff


                        props = f.FieldType.GetProperties

                        For Each p In props


                            Dim inf As FieldInfo = o.GetType.GetField(f.Name)

                            inf.SetValue(o, Convert.ChangeType(c.Text, p.PropertyType))


                        Next




                    Next
                End If

            End If

        Next















        Me.DialogResult = DialogResult.OK
        Me.Close()


    End Sub




End Class
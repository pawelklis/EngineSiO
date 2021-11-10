Imports EngineSiO

Public Class frmGetScanner
    Inherits System.Web.UI.Page

    Dim operationID As Integer
    Dim CFG As OperationType
    Dim s As sessionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        s = Session("sesja")
        Dim idop = Request.QueryString("id")


        If Not IsPostBack Then


            CFG = OperationType.Load(idop)
            If Not IsNothing(CFG) Then

                For Each p In CFG.Parameters
                    If p.Key = "Pracownicy zakres" Then
                        Select Case p.Value
                            Case WorkerLevels.Jednostka_Organizacyjna
                                ddlWorkers.DataSource = WorkerType.Load(p.Value, s.OrganizationUnit.Id, True)
                            Case WorkerLevels.Komórka_Organizacyjna
                                ddlWorkers.DataSource = WorkerType.Load(p.Value, s.Zone.Id, True)
                            Case WorkerLevels.Organizacja
                                ddlWorkers.DataSource = WorkerType.Load(p.Value, 0, True)
                        End Select


                        ddlWorkers.DataTextField = "fullname"
                        ddlWorkers.DataValueField = "id"
                        ddlWorkers.DataBind()


                    End If

                    If p.Key = "Dodawanie pracownika" Then
                        Select Case p.Value
                            Case YesNo.TAK
                                ddlWorkers.DropDownStyle = AjaxControlToolkit.ComboBoxStyle.DropDown
                            Case YesNo.NIE
                                ddlWorkers.DropDownStyle = AjaxControlToolkit.ComboBoxStyle.DropDownList
                        End Select

                    End If

                    If p.Key = "Skanery zakres" Then
                        Select Case p.Value
                            Case RangeLevels.Jednostka_Organizacyjna

                            Case RangeLevels.Komórka_Organizacyjna
                            Case RangeLevels.Organizacja

                        End Select
                    End If

                    If p.Key = "Pole Uwagi" Then
                        txUwagi.Visible = p.Value

                    End If
                Next

            End If

        End If
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs)

        Dim idop = Request.QueryString("id")
        CFG = OperationType.Load(idop)


            Dim a = ddlWorkers.SelectedValue
        'odblokuj AD
        'dodaj rekord o pobraniu skanera
        'wyślij powiadomienie

        For Each rec In CFG.Notifies.RecipientsIDList

            Dim n As New NotifyType(" Pobrano skaner " & CFG.Name, rec)


        Next


        'dodaj informacje


        Response.Redirect("~/forms/frmgetscanner.aspx?id=" & Request.QueryString("id"))
    End Sub
End Class
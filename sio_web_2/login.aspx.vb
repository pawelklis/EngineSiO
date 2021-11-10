Imports System.Web.Http
Imports EngineSiO

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            txLogin.Focus()

        End If

        Dim bewr As String = CheckBrowser()

        If InStr(bewr.ToLower, "chrome") = 0 Then
            If InStr(bewr.ToLower, "edge") = 0 Then
                Response.Redirect("~/wfbadbrowser.aspx")
            End If
        End If

    End Sub

    Public Function CheckBrowser()
        Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
        Dim s As String = "Browser Capabilities\n" & "Type = " & browser.Type & "\n" & "Name = " & browser.Browser & "\n" &
         "Version = " & browser.Version & "\n" &
         "Major Version = " & browser.MajorVersion & "\n" &
         "Minor Version = " & browser.MinorVersion & "\n" &
         "Platform = " & browser.Platform & "\n" &
         "Is Beta = " & browser.Beta & "\n" &
         "Is Crawler = " & browser.Crawler & "\n" &
         "Is AOL = " & browser.AOL & "\n" &
         "Is Win16 = " & browser.Win16 & "\n" &
         "Is Win32 = " & browser.Win32 & "\n" &
         "Supports Frames = " & browser.Frames & "\n" &
         "Supports Tables = " & browser.Tables & "\n" &
         "Supports Cookies = " & browser.Cookies & "\n" &
         "Supports VBScript = " & browser.VBScript & "\n" &
         "Supports JavaScript = " &
            browser.EcmaScriptVersion.ToString() & "\n" &
         "Supports Java Applets = " & browser.JavaApplets & "\n" &
         "Supports ActiveX Controls = " & browser.ActiveXControls &
               "\n" &
         "Supports JavaScript Version = " &
            browser("JavaScriptVersion") & "\n"

        Return s
    End Function

    Function GetIP() As String
        Dim IPAdd As String = String.Empty
        IPAdd = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(IPAdd) Then
            IPAdd = Request.ServerVariables("REMOTE_ADDR")
        End If
        Return IPAdd
    End Function
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim l As New List(Of A_Directory.UserInfoProps)
        l.Add(A_Directory.UserInfoProps.givenName)
        l.Add(A_Directory.UserInfoProps.mail)
        l.Add(A_Directory.UserInfoProps.title)
        l.Add(A_Directory.UserInfoProps.sn)
        l.Add(A_Directory.UserInfoProps.description)
        l.Add(A_Directory.UserInfoProps.employeeNumber)
        l.Add(A_Directory.UserInfoProps.manager)
        l.Add(A_Directory.UserInfoProps.streetAddress)
        l.Add(A_Directory.UserInfoProps.department)
        l.Add(A_Directory.UserInfoProps.mobile)
        l.Add(A_Directory.UserInfoProps.extensionAttribute13)
        l.Add(A_Directory.UserInfoProps.badPasswordTime)





        Dim u As UserType = UserType.Load(txLogin.Text)
        If IsNothing(u) Then
            u = New UserType
            Dim uinfo As List(Of String) = A_Directory.GetuserAdInformation(txLogin.Text, l)
            If IsNothing(uinfo) Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Błędny login');", True)
                Exit Sub
            End If



            u.Login = txLogin.Text
            u.Name = uinfo(3)
            u.Surname = uinfo(0)
            u.Title = uinfo(1)

            u.Access = New UserAccesssType
            u.ADINFO = uinfo

            Dim ip As String = GetIP()
            Dim lorg As List(Of OrganizationUnitType) = OrganizationUnitType.Load(True)

            For Each o In lorg
                If ip.StartsWith(o.Info("ip")) Then
                    u.Access.Access.Add("OU_" & o.Id, True)
                Else
                    u.Access.Access.Add("OU_" & o.Id, False)
                End If
            Next

            u.Save()

        Else

            u.ADINFO = A_Directory.GetuserAdInformation(txLogin.Text, l)


        End If


        Dim result As Boolean = A_Directory.ValidateActiveDirectoryLogin(txLogin.Text, txPassword.Text, 0)

        If result = True Then


            Dim s As New sessionClass
            s.User = u

            Dim ok As Boolean = False
            For Each o In u.Access.OrganizationUnits
                If o.Value = True Then
                    ok = True
                    Exit For
                End If
            Next


            If ok = False Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Nie masz przypisanych lokalizacji, skontaktuj się z administratorem');", True)
                Exit Sub
            End If

            ok = False
            For Each z In u.Access.Zones
                If z.Value = True Then
                    If u.GetOrganizationAccess(ZoneType.LoadID(z.Key).OrganizationUnitId) = True Then
                        ok = True
                        Exit For
                    End If
                End If
            Next

            If ok = False Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Nie masz przypisanych lokalizacji, skontaktuj się z administratorem');", True)
                Exit Sub
            End If

            Session("sesja") = s
            Response.Redirect("~/wbMap.aspx")
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Błędne hasło');", True)
            txPassword.Text = ""
            txPassword.Focus()
        End If

    End Sub
End Class
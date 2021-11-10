Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices.Protocols
Imports System.Globalization
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Principal
Imports System.Threading


Public Class A_Directory
#Region "public Variables"
    Public Shared ADAdminUser As String = "SVC_Aktyw_Skaner_Wro"

    Public Shared ADAdminPassword As String = "da{rQ,KgC$pTt[!2eGZ6e$Q7=Gs?oX"

    Public Shared ADFullPath As String = "net.pp"
    ' = "LDAP://192.168.0.3"; 

    Public Shared ADServer As String = "net.pp"
    ' = "sakura.com";
    '		public static string ADPath= ADFullPath ; 
    '		public static string ADUser = ADAdminUser ;
    '		public static string ADPassword = ADAdminPassword ;

#End Region
#Region "Enumerations"
    Public Enum ADAccountOptions
        UF_TEMP_DUPLICATE_ACCOUNT = 256
        UF_NORMAL_ACCOUNT = 512
        UF_INTERDOMAIN_TRUST_ACCOUNT = 2048
        UF_WORKSTATION_TRUST_ACCOUNT = 4096
        UF_SERVER_TRUST_ACCOUNT = 8192
        UF_DONT_EXPIRE_PASSWD = 65536
        UF_SCRIPT = 1
        UF_ACCOUNTDISABLE = 2
        UF_HOMEDIR_REQUIRED = 8
        UF_LOCKOUT = 16
        UF_PASSWD_NOTREQD = 32
        UF_PASSWD_CANT_CHANGE = 64
        UF_ACCOUNT_LOCKOUT = 16
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 128
    End Enum


    Public Enum LoginResult
        LOGIN_OK = 0
        LOGIN_USER_DOESNT_EXIST
        LOGIN_USER_ACCOUNT_INACTIVE
    End Enum

#End Region
    Public Shared Function IsAccountActive(ByVal userLogin As String, idlok As Integer) As Boolean
        Try
            Dim us As DirectoryEntry = GetUser(userLogin, idlok)
            If IsNothing(us) Then Return False
            Dim userAccountControl As Integer = CInt(us.Properties("userAccountControl").Value)

            Dim accountDisabled As Integer = Convert.ToInt32(ADAccountOptions.UF_ACCOUNTDISABLE)
            Dim flagExists As Integer = userAccountControl And accountDisabled
            'if a match is found, then the disabled flag exists within the control flags
            If flagExists > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception

        End Try

    End Function

    Public Shared Function GetDirectoryEntry(idlok As Integer) As DirectoryEntry

        If idlok = 8 Then
            ADAdminUser = "SVC_Aktyw_Skaner_Wro"
            ADAdminPassword = "da{rQ,KgC$pTt[!2eGZ6e$Q7=Gs?oX"

            Dim dirEntry As DirectoryEntry = New DirectoryEntry("LDAP://10.32.30.25/OU=Wroclaw,OU=SkaneryRadiowe,DC=net,DC=pp", ADAdminUser, ADAdminPassword, AuthenticationTypes.Secure) 'GetDirectoryObject("/" + GetLDAPDomain())

            Return dirEntry
        End If

        If idlok = 15 Or idlok = 0 Then
            ADAdminUser = "SVC_Aktyw_Skaner_KRA"
            ADAdminPassword = "Hi1NzuQPM%$ycWjL$T4t9XORfoSGY!"


            Dim dirEntry As DirectoryEntry = New DirectoryEntry("LDAP://10.32.30.25/OU=Krakow,OU=SkaneryRadiowe,DC=net,DC=pp", ADAdminUser, ADAdminPassword, AuthenticationTypes.Secure) 'GetDirectoryObject("/" + GetLDAPDomain())

            Return dirEntry
        End If

    End Function
    Public Class DirEntryProps
        Public Property LDAP
        Public Property UserLogin
        Public Property UserPass
        Public Property Secure
    End Class
    Public Shared Function GetDirectoryEntryString(idlok As Integer) As DirEntryProps





        If idlok = 8 Or idlok = 0 Then
            ADAdminUser = "SVC_Aktyw_Skaner_Wro"
            ADAdminPassword = "da{rQ,KgC$pTt[!2eGZ6e$Q7=Gs?oX"

            Dim p As New DirEntryProps
            p.LDAP = "LDAP://10.32.30.25/OU=Wroclaw,OU=SkaneryRadiowe,DC=net,DC=pp"
            p.UserLogin = ADAdminUser
            p.UserPass = ADAdminPassword
            p.Secure = AuthenticationTypes.Secure

            Return p
        End If

        If idlok = 15 Or idlok = 0 Then
            ADAdminUser = "SVC_Aktyw_Skaner_KRA"
            ADAdminPassword = "Hi1NzuQPM%$ycWjL$T4t9XORfoSGY!"

            Dim p As New DirEntryProps
            p.LDAP = "LDAP://10.32.30.25/OU=Krakow,OU=SkaneryRadiowe,DC=net,DC=pp"
            p.UserLogin = ADAdminUser
            p.UserPass = ADAdminPassword
            p.Secure = AuthenticationTypes.Secure

            Return p
        End If

    End Function
    Public Shared Function GetUser(ByVal UserName As String, idlok As Integer) As DirectoryEntry

        Try


            If IsNothing(UserName) Then Return Nothing
            If String.IsNullOrEmpty(UserName) Then Return Nothing
            'create an instance of the DirectoryEntry
            'Dim dirEntry As DirectoryEntry = GetDirectoryEntry(idlok)
            Dim dirEntry As DirectoryEntry = New DirectoryEntry("LDAP://10.32.30.25/OU=Wroclaw,DC=net,DC=pp", ADAdminUser, ADAdminPassword, AuthenticationTypes.Secure) 'GetDirectoryObject("/" + GetLDAPDomain())

            'create instance fo the direcory searcher
            Dim dirSearch As New DirectorySearcher(dirEntry)

            dirSearch.SearchRoot = dirEntry
            'set the search filter

            dirSearch.Filter = "(&(objectCategory=*)(cn=" + UserName + "))"
            dirSearch.SearchScope = DirectoryServices.SearchScope.Subtree

            'find the first instance
            Dim searchResults As SearchResult = dirSearch.FindOne()


            If IsNothing(searchResults) Then
                dirEntry = GetDirectoryEntry(idlok) 'New DirectoryEntry("LDAP://10.32.30.25/OU=SkaneryRadiowe,DC=net,DC=pp", ADAdminUser, ADAdminPassword, AuthenticationTypes.Secure) 'GetDirectoryObject("/" + GetLDAPDomain())
                dirSearch = New DirectorySearcher(dirEntry)
                dirSearch.SearchRoot = dirEntry


                dirSearch.Filter = "(&(objectCategory=*)(cn=" & UserName & "))"
                dirSearch.SearchScope = DirectoryServices.SearchScope.OneLevel

                'find the first instance
                searchResults = dirSearch.FindOne()



            End If

            'if found then return, otherwise return Null
            If Not searchResults Is Nothing Then
                'de= new DirectoryEntry(results.Path,ADAdminUser,ADAdminPassword,AuthenticationTypes.Secure);
                'if so then return the DirectoryEntry object
                Dim a = searchResults.GetDirectoryEntry

                Return searchResults.GetDirectoryEntry()

            Else





                Return Nothing
            End If



        Catch ex As Exception
            Return Nothing

        End Try


    End Function
    Public Enum UserInfoProps
        objectClass
        cn
        sn
        l
        title
        description
        postalCode
        telephoneNumber
        givenName
        distinguishedName
        instanceType
        whenCreated
        whenChanged
        displayName
        uSNCreated
        memberOf
        uSNChanged
        department
        proxyAddresses
        streetAddress
        nTSecurityDescriptor
        employeeNumber
        name
        objectGUID
        userAccountControl
        badPwdCount
        codePage
        countryCode
        employeeID
        badPasswordTime
        lastLogon
        pwdLastSet
        primaryGroupID
        objectSid
        accountExpires
        logonCount
        sAMAccountName
        sAMAccountType
        showInAddressBook
        legacyExchangeDN
        userPrincipalName
        lockoutTime
        objectCategory
        dSCorePropagationData
        lastLogonTimestamp
        mail
        mobile
        manager
        pager
        msExchRecipientTypeDetails
        msRTCSIP_UserRoutingGroupId
        msRTCSIP_UserPolicies
        extensionAttribute13
        extensionAttribute14
        msExchRemoteRecipientType
        msExchPoliciesExcluded
        msRTCSIP_OptionFlags
        msRTCSIP_DeploymentLocator
        msRTCSIP_PrimaryHomeServer
        msRTCSIP_FederationEnabled
        msRTCSIP_InternetAccessEnabled
        msExchUMDtmfMap
        targetAddress
        msExchRecipientDisplayType
        msRTCSIP_PrimaryUserAddress
        msExchVersion
        msRTCSIP_UserEnabled
        mailNickname
    End Enum



    Public Shared Function GetuserAdInformation(userName As String, propNames As List(Of UserInfoProps)) As List(Of String)
        Dim DE = A_Directory.GetUser(userName, 8)
        Dim sb As New List(Of String)
        Try
            For Each p As System.DirectoryServices.PropertyValueCollection In DE.Properties
                For Each propName In propNames
                    If p.PropertyName = propName.ToString.Replace("_", "-") Then
                        sb.Add(p.Value.ToString)
                    End If
                Next
            Next
        Catch ex As Exception

        End Try

        Return sb

    End Function
    Public Shared Function ValidateActiveDirectoryLogin(ByVal Username As String, ByVal Password As String, idlok As Integer) As Boolean
        Dim Success As Boolean = False

        Dim ld As DirEntryProps = GetDirectoryEntryString(idlok)

        Dim Entry As New System.DirectoryServices.DirectoryEntry(ld.LDAP, Username, Password)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
        Try
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
        End Try
        Return Success
    End Function

    Public Shared Sub DisableAccount(ByVal sLogin As String, idlok As Integer)



        Dim strError As String
        Try
            Dim child As New System.DirectoryServices.DirectoryEntry(GetDirectoryEntryString(idlok).LDAP, GetDirectoryEntryString(idlok).UserLogin, GetDirectoryEntryString(idlok).UserPass, GetDirectoryEntryString(idlok).Secure)
            Dim searcher As New DirectorySearcher(child)
            Dim result As SearchResult
            Dim userEntry As DirectoryEntry
            searcher.Filter = "(SAMAccountName=" & sLogin & ")"
            searcher.CacheResults = False
            result = searcher.FindOne
            userEntry = result.GetDirectoryEntry
            With userEntry
                userEntry.NativeObject.accountdisabled = True
            End With
            userEntry.CommitChanges()
        Catch ex As Exception

        End Try


    End Sub


    Public Shared Sub EnableAccount(ByVal de As DirectoryEntry, idlok As Integer)
        Try


            'UF_DONT_EXPIRE_PASSWD 0x10000
            Dim exp As Integer = CInt(de.Properties("userAccountControl").Value)
            de.Properties("userAccountControl").Value = exp Or &H1
            de.CommitChanges()
            'UF_ACCOUNTDISABLE 0x0002
            Dim val As Integer = CInt(de.Properties("userAccountControl").Value)
            de.Properties("userAccountControl").Value = val And Not &H2
            de.CommitChanges()


        Catch ex As Exception

        End Try
    End Sub
End Class

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmWorkerDetails.aspx.vb" Inherits="sio_web_2.frmWorkerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />


        <style>
            .ct{
                width:400px;
                font-size:20px;
            }
        </style>

        <div>
            <asp:Button ID="txClose" OnClientClick="Close();" CausesValidation="false" runat="server" Text="X" CssClass="btnclose" />
            <h2>Edycja pracownika</h2>

            <table class=" with-100 Centered " style="font-size:20px;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Imie"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox class="ct" ID="txname" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red"  ControlToValidate="txname" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nazwisko"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox class="ct"  ID="txsurname" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red"  ControlToValidate="txsurname" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Login AD"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox class="ct"  ID="txLogin" runat="server" AutoPostBack="true" OnTextChanged="txlogin_TextChanged"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txLogin" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Jednostka organizacyjna"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:DropDownList class="ct"  ID="ddlorg" AutoPostBack="true" OnSelectedIndexChanged="ddlorg_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red"  ControlToValidate="ddlorg" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Komórka organizacyjna"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:DropDownList class="ct"  ID="ddlzone" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red"  ControlToValidate="ddlzone" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Stanowisko"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox class="ct"  ID="txtitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red"  ControlToValidate="txtitle" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Kod"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox  class="ct" ID="txcode" runat="server"></asp:TextBox><asp:Button CausesValidation="false" ID="btnAddCode" runat="server" OnClick="btnAddCode_Click"  Text="Wygeneruj"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" ControlToValidate="txcode" runat="server" ErrorMessage="Wymagane"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn-success" runat="server" Text="Zapisz"  />


            </table>

        </div>



        <script>
            function Close() {
                parent.document.getElementById('pnEdit2').style.visibility = 'hidden';
            }

        </script>
    </form>
</body>
</html>

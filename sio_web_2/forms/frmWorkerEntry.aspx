<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmWorkerEntry.aspx.vb" Inherits="sio_web_2.frmWorkerEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />

        <div>

            <asp:DropDownList ID="ddlworker" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddlreason" runat="server"></asp:DropDownList>

            <asp:TextBox ID="txstart" TextMode="DateTimeLocal" runat="server"></asp:TextBox>
            <asp:TextBox ID="txstop" TextMode="DateTimeLocal" runat="server"></asp:TextBox>

            <asp:TextBox ID="txdescr" TextMode="MultiLine"  runat="server"></asp:TextBox>

            <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn-success" runat="server" Text="Zapisz" />

        </div>
        
    </form>
</body>
</html>

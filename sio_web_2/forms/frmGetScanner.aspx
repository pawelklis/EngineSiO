<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="frmGetScanner.aspx.vb" Inherits="sio_web_2.frmGetScanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pobierz skaner</title>
    <link href="../StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="Centered ">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

                <h2>Pobierz skaner</h2>

                <ajaxToolkit:ComboBox ID="ddlWorkers" runat="server"></ajaxToolkit:ComboBox>
                <br />
                <asp:DropDownList ID="ddlScanners" runat="server"></asp:DropDownList>
                <br />
                <asp:TextBox ID="txUwagi" TextMode="MultiLine" runat="server"></asp:TextBox>
                <br />

                <asp:Button ID="btnsave" OnClick="btnsave_Click" CssClass="btn-success" runat="server" Text="Pobierz skaner" />


</ContentTemplate></asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

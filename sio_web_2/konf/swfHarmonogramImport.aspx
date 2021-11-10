<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="swfHarmonogramImport.aspx.vb" Inherits="sio_web_2.swfHarmonogramImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />
        <asp:ScriptManager runat="server"></asp:ScriptManager>


        <div>
            <asp:DropDownList ID="ddlzone" runat="server"></asp:DropDownList>




            <asp:FileUpload ID="FileUpload1" runat="server" />

            <asp:Button ID="btnHarmImport" OnClick="btnHarmImport_Click" runat="server" Text="Importuj harmonogram" />


        </div>

    </form>
</body>
</html>

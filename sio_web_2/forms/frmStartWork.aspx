<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="frmStartWork.aspx.vb" Inherits="sio_web_2.frmStartWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
                     <h2>Rozpoczęcie pracy</h2>

            <ajaxToolkit:ComboBox ID="ddlWorkers" runat="server"></ajaxToolkit:ComboBox>
            <br />
            <asp:TextBox ID="txdate" type="date" runat="server"></asp:TextBox><asp:TextBox ID="txtime" type="time" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txUwagi" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnsave" OnClick="btnsave_Click" CssClass="btn-success" runat="server" Text="Pobierz skaner" />
        </div>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmAddWorkerAdnotation.aspx.vb" Inherits="sio_web_2.frmAddWorkerAdnotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />



        <div class="Centered">
            <asp:Button ID="txClose" OnClientClick="Close();" CausesValidation="false" runat="server" Text="X" CssClass="btnclose" />

            <h2>Adnotacja</h2>
            <asp:label id="wn" runat="server"></asp:label>

            <asp:TextBox ID="tx" TextMode="MultiLine" style="width:900px;height:400px;" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSave" CssClass="btn-success " runat="server" OnClick="btnSave_Click" Text="Zapisz" />

        </div>


          <script>
            function Close() {
                parent.document.getElementById('pnEdit2').style.visibility = 'hidden';
            }

          </script>

    </form>
</body>
</html>

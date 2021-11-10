<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="login.aspx.vb" Inherits="sio_web_2.login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <link href="StyleSheet1.css" rel="stylesheet" />




            <div class="Centered" style="text-align:center;width:348px;height:378px;opacity:0.8;background-color:#f7f9fa;">

                <img src="images/icons/icoUserLock.PNG" />

                <asp:TextBox ID="txLogin" CssClass="margins-5px" BorderStyle="None" style="background-color:#f7f9fa;border-bottom:solid 1px black;" runat="server" Width="308" Height="57"  TabIndex="1" placeholder="Login"></asp:TextBox>

                <br />

                <asp:TextBox ID="txPassword" Width="308" Height="57" BorderStyle="None" style="background-color:#f7f9fa;border-bottom:solid 1px black;"  CssClass="margins-5px"   TextMode="Password" TabIndex="2" runat="server" placeholder="Hasło"></asp:TextBox>

                <br />
                <br />
                <asp:Button ID="btnLogin" CssClass="btn-success" runat="server" TabIndex="3" Text="Zaloguj" />
            </div>
            
  
        </div>
    </form>
</body>
</html>

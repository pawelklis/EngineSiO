﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCrewPresentChart.aspx.vb" Inherits="sio_web_2.frmCrewPresentChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onfocus="reftarget();">
    <form id="form1" runat="server">
         <script>
            function reftarget() {
                //alert('pos');
                //__doPostBack('', '');
                document.getElementById('btnRefresh').click();
            };

            function sleepFor(sleepDuration) {
                var now = new Date().getTime();
                while (new Date().getTime() < now + sleepDuration) { /* do nothing */ }
            }
         </script>

        <div>

          

            <asp:Chart id="c1" runat="server" >
                <series><asp:Series Name="Series1"></asp:Series></series>
                <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
            </asp:Chart>

        </div>


         <asp:Button ID="btnRefresh" runat="server"  Text="Odśwież" style="visibility:hidden;" OnClick="btnRefresh_Click" />
    </form>
</body>
</html>

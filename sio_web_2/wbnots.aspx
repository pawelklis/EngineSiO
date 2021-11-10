<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="wbnots.aspx.vb" Inherits="sio_web_2.wbnots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
<asp:ScriptManager runat="server"></asp:ScriptManager>


                  <%--    Powiadomienia--%>
     <script>
         var NotifcationsTest = {
             VerifyBrowserSupport: function () {
                 return ("Notification" in window);
             },
             ShowNotification: function (msg) {
                 var notification = new Notification(msg);
                 
             },
             RequestForPermissionAndShow: function (msg) {
                 // Mamy prawo wyświetlać powiadomienia
                 if (Notification.permission === "granted") {
                     NotifcationsTest.ShowNotification(msg);
                 }
                 // Brak wsparcia w Chrome dla właściwości permission
                 else if (Notification.permission !== "denied") {
                     Notification.requestPermission(function (permission) {
                         // Dodajemy właściwość permission do obiektu Notification
                         if (!("permission" in Notification)) {
                             Notification.permission = permission;
                         }
                         if (permission === "granted") {
                             NotifcationsTest.ShowNotification(msg);
                         }
                     });
                 }
             }
         }

         function Shown(msg) {
             if (!NotifcationsTest.VerifyBrowserSupport()) {
                 alert("Brak wsparcia dla Notifications API");
             }
             NotifcationsTest.RequestForPermissionAndShow(msg);
         };


     </script>
<%--    -Powiadomienia--%>



        <div>
                <asp:Timer ID="Timer1" runat="server" OnTick="Unnamed_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>

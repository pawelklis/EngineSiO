<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wftfTracker.aspx.vb" Inherits="sio_web_2.wftfTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <style>
                .framediv{
                    border-style:solid;
                    border-color:#0259f5;
                    border-radius:15px;
                    padding:15px;
                    width:400px;
                    text-align:center;
                    margin-left:25px;
                    position:relative;
                    display:inline-block;
                }
                .maindiv{
                    display:inline-flex;
                }

                .lfaza{
                    font-size:medium;
                }
                .lregion{
                    font-size:small;
                }
                .lup{
                    font-size:large;
                    font-weight:600;
                }
                .lin{
                    font-size:xx-large ;
                    font-weight:600;

                }
                .weim{
                    width:30px;
                    height:30px;
                }
                .pin{
                    padding:10px;
                    border-radius:5px;
                    margin:3px;
                    position:relative;
                    height:110px;
                }
                .kpn{
                    height:200px;
                    overflow:auto;
                    margin:5px;
                }
                .lout{
                    font-size:xx-large;
                    font-weight:600;
                    padding:10px;
                    border-radius:5px;
                    margin:15px;
                }
                .linplan{
                    font-size:smaller;
                }
                .outplan{
                    font-size:smaller;
                }
                .tableprzys {
                    border-collapse: collapse;
                    border-style: solid;
                    border-width: 1px;
                }

                .unrow{
                    border-bottom-style:solid;
                    border-width:1px;
                    padding:5px;
                }
                .tdrow{
                    padding:5px;
                }

                .arrowin {
                    position: absolute;
                    left: -5px;
                    top:-10px;
                }
                .arrowout {
                    position: absolute;
                    right: 0px;
                    bottom:-10px;
                }


                .processingdiv{
                    border-style:solid;
                    border-color:white;
                    border-radius:15px;                  
                    text-align:center;
                    margin-top:30px;
                   
                }
                .transportdiv{
                     
                    border-color:white;
                    border-radius:15px;
                    padding:15px;
                    width:200px;
                    text-align:center;
                    margin-left:25px;
                    position:relative;
                    display:inline-block;
                }
                .labelfaza{
                    margin:10px;
                    font-weight:600;
                    font-size:18px;
                }
                .labelup{
                    margin:10px;
                    font-weight:600;
                    font-size:18px;
                }
                .labelczaswewy{
                    font-size:25px;
                }
                .arowim{
                    width:35px;
                    height:35px;
                }
                .czaswewycontainer {
                    margin: auto;
                    border: 3px solid green;
                    padding: 10px;
                    background-color:lightgreen;
                }
                .czaswewycontainerbad {
                    margin: auto;
                    border: 3px solid green;
                    padding: 10px;
                    background-color:#d43838;
                }
                .czaswewycontainerbadNN {
                    margin: auto;
                    border: 3px solid green;
                    padding: 10px;
                    background-color:#ff6a00;
                }
                .procestimecontainer{
                    border-style:solid;
                    border-color:black;
                    border-radius:15px;
                }
                .transporttimecontainer{
                    border-style:solid;
                    border-color:black;
                    border-radius:15px;
                    background-color:white;
                }
                .labeltrp{
                    color:black;
                }
                .calendar{
                    width:50px;
                }
                table{
                    width:100%;
                }
                td{
                    vertical-align:middle;
                    text-align:center;                    
                    justify-content:center;
                    
                }
                .luntf{
                    color:darkred;
                    font-size:x-large;
                }
                .lunp{
                        color:darkred;
                    font-size:x-large;
                }
                .tfpm {
                    margin: 10px;
                    border-style: solid;
                    border-radius: 15px;
                    padding: 20px;
                }

                .tfpc {
                    margin: 5px;
                    padding: 5px;
                    border-bottom: solid silver 0.5px;
                }

                .ln {
                    margin-right: 10px;
                    display: inline-block;
                    width: 400px;
                }

                .tfpc2 {
                    border-style: solid;
                    border-color: #0259f5;
                    border-radius: 15px;
                    padding: 15px;
                    width: 200px;
                    text-align: center;
                    margin-left: 25px;
                    position: relative;
                    display: inline-block;
                }

                .ln2 {
                    margin-right: 10px;
                    display: inline-block;
                }

                .lv {
                    color: darkblue;
                    font-weight: 600;
                }
                .pnn{

                }
                .zstp{
                    display:inline-flex;
                }

                .ttj {
                    padding:5px;
                    border-style:solid;
                    border-width:1px;
                    border-radius:10px;
                }
                .ttt {
                    padding:5px;
                    border-style:solid;
                    border-width:1px;
                    border-radius:10px;
                }

                @keyframes truckgo {
                    from {
                        left: -60px;
                        opacity: 0;
                    }

                    to {
                        left: 1280px;
                        opacity: 0;
                    }
                }

                .truck {
                    position: absolute;
                    top: 100px;
                    opacity: 0;
                    width: 50px;
                    height: 50px;
                    left: -60px;
                    animation-name: truckgo;
                    animation-duration: 10s;
                    animation-iteration-count: 1;
                }


          

            
          
          
         

         
            </style>


            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

      </ContentTemplate>
            </asp:UpdatePanel>


       
            <table>
                <tr>
                    <td style="width: 400px;">
                        <h3 id="h3" runat="server">Identyfikator przesyłki</h3>
                        <asp:TextBox ID="txid" Style="width: 300px;" runat="server"></asp:TextBox>
                        <asp:Button ID="btnfindID" runat="server" OnClick="btnfindID_Click" Text="Znajdź" />
                    </td>
                    <td>
                        <div>

                            <table style="width: 500px;" class="tableprzys">
                                <tr class="unrow">
                                    <td colspan="3" class="tdrow">
                                        <asp:Label ID="lptyp" runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr class="unrow">
                                    <td class="tdrow">
                                        <div style="text-align: left;">
                                            Gwarantowany termin doręczenia:
                                            <br />
                                            Rzeczywisty czas doręczenia:
                                            <br />
                                            Czas obsługi przesyłki:
                                        </div>
                                    </td>
                                    <td class="tdrow">
                                        <asp:Label ID="lbGT" runat="server" Font-Bold="true" Text=""></asp:Label>
                                        <br />
                                        <asp:Label ID="lbdtE2E" runat="server" Font-Bold="true" Text=""></asp:Label>
                                        <br />
                                        <asp:Label ID="ltet" runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </td>
                                    <td rowspan="3">
                                        <asp:Image ID="ime2e" runat="server" ImageUrl="~/images/icons/appbar.smiley.happy.png" />
                                    </td>
                                </tr>
                            </table>



                        </div>
                    </td>
                </tr>
            </table>



            <br />
            <img class="truck" src="../images/truck (1).gif" />



         

<%--            <div style="background-image:url('/images/road.jpg'); background-repeat: repeat-x;">

                <div class="transportdiv"></div>

                <div class="transportdiv">
                    <div id="Div14" runat="server" class="transporttimecontainer">
                        <asp:Label ID="Label2" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                        <img class="arowim" src="../images/icons/appbar.truck.png" />
                        <br />
                        <asp:Label ID="nadania_l_transp" CssClass="labelczaswewy" runat="server" Style="height: 100%;" Text="Pn 08:35"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                    </div>
                </div>

                <div class="transportdiv">
                    <div id="Div15" runat="server" class="transporttimecontainer">
                        <asp:Label ID="Label4" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                        <img class="arowim" src="../images/icons/appbar.truck.png" />
                        <br />
                        <asp:Label ID="zbiorkowa_l_transp" CssClass="labelczaswewy" runat="server" Style="height: 100%;" Text="Pn 08:35"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                    </div>
                </div>
                <div class="transportdiv">
                    <div id="Div16" runat="server" class="transporttimecontainer">
                        <asp:Label ID="Label7" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                        <img class="arowim" src="../images/icons/appbar.truck.png" />
                        <br />
                        <asp:Label ID="koncentracji_l_transp" CssClass="labelczaswewy" runat="server" Style="height: 100%;" Text="Pn 08:35"></asp:Label>
                        <br />
                        <asp:Label ID="Label8" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                    </div>
                </div>

                <div class="transportdiv">
                    <div id="Div17" runat="server" class="transporttimecontainer">
                        <asp:Label ID="Label10" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                        <img class="arowim" src="../images/icons/appbar.truck.png" />
                        <br />
                        <asp:Label ID="przewozu_l_transp" CssClass="labelczaswewy" runat="server" Style="height: 100%;" Text="Pn 08:35"></asp:Label>
                        <br />
                        <asp:Label ID="Label11" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                    </div>
                </div>

                <div class="transportdiv">
                    <div id="Div18" runat="server" class="transporttimecontainer">
                        <asp:Label ID="Label12" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                        <img class="arowim" src="../images/icons/appbar.truck.png" />
                        <br />
                        <asp:Label ID="dekoncentracji_l_transp" CssClass="labelczaswewy" runat="server" Style="height: 100%;" Text="Pn 08:35"></asp:Label>
                        <br />
                        <asp:Label ID="Label14" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                    </div>
                </div>

                <div class="transportdiv">
                    <div id="Div19" runat="server" class="transporttimecontainer">
                        <asp:Label ID="Label15" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                        <img class="arowim" src="../images/icons/appbar.truck.png" />
                        <br />
                        <asp:Label ID="doreczenia_l_transp" CssClass="labelczaswewy" runat="server" Style="height: 100%;" Text="Pn 08:35"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" CssClass="labeltrp" runat="server" Text="Pn 08:35"></asp:Label>
                    </div>
                </div>



            </div>--%>


            <div style="width: 100%; overflow: auto;">

                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            </div>

            <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>

            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>

        </div>



          
    </form>
    
</body>
</html>

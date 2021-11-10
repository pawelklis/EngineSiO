<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="start.aspx.vb" Inherits="sio_web_2.start" %>

<%@ Register Src="~/PostControl.ascx" TagPrefix="uc1" TagName="PostControl" %>
<%@ Register Src="~/contentControl.ascx" TagPrefix="uc1" TagName="contentControl" %>
<%@ Register Src="~/EditorControl.ascx" TagPrefix="uc1" TagName="EditorControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>

    <style>
        #tbmain tr{
            vertical-align:top;
        }

/* (A1) CONTAINER - BIG SCREEN */
.thegrid {
  display: grid;
  grid-template-columns: auto auto auto auto;
  /* OR SPECIFY WIDTH
  grid-template-columns: 40% 20% 20% 20%;
  */
  grid-gap: 5px;
}
/* (A2) CONTAINER - SMOL SCREEN */
@media screen and (max-width:768px) {
  .thegrid { grid-template-columns: auto auto; }
}
/* (B) CELLS */
.thegrid .head, .thegrid .cell {
  padding: 10px;
}
/* (C) HEADER CELLS */
.thegrid .head {
  font-weight: bold;
  background: #ffe4d1;
}
/* (D) DATA CELLS */
.thegrid .cell {
  background: #d1f2ff;
}
</style>

    <div class="thegrid">
    <table id="tbmain">
        <tr>
            <td>
                <div id="InfoContainer" style="width: 800px; height: 500px;" class="container">
                    <div class="container-header">
                        <asp:Label ID="lbTitle_InfoContainer" runat="server" Text="Informacje"></asp:Label>
                        <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize1" onclick="minimize('InfoContainer','infocontainerchild');">_</a>
                    </div>
                    <div id="infocontainerchild" class="container-content">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                         <iframe src="forms/frmCrewTargetChart.aspx" class="iframeuc " style="height:460px;"></iframe>
                    </div>
                    </div>
           
            </td>

            <td>
                <div id="InfoContainer3" style="width: 800px; height: 500px;" class="container">
                    <div class="container-header">
                        <asp:Label ID="Label2" runat="server" Text="Informacje"></asp:Label>
                        <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize3" onclick="minimize('InfoContainer3','infocontainerchild3');">_</a>
                    </div>
                    <div id="infocontainerchild3" class="container-content">
                        <iframe src="forms/frmTodayCrew.aspx" class="iframeuc " style="height:460px;"></iframe>
                    </div>
                </div>
            </td>
        </tr>


        <tr>
            <td>
                <div id="InfoContainer4" style="width: 800px; height: 500px;" class="container">
                    <div class="container-header">
                        <asp:Label ID="Label3" runat="server" Text="Informacje"></asp:Label>
                        <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize4" onclick="minimize('InfoContainer4','infocontainerchild4');">_</a>
                    </div>
                    <div id="infocontainerchild4" class="container-content">
                        <iframe id="wtarget" src="forms/frmTargetCrew.aspx" class="iframeuc " style="height:460px;"></iframe>
                    </div>
                </div>
            </td>
            <td>
                <div id="InfoContainer5" style="width: 800px; height: 500px;" class="container">
                    <div class="container-header">
                        <asp:Label ID="Label4" runat="server" Text="Informacje"></asp:Label>
                        <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize5" onclick="minimize('InfoContainer5','infocontainerchild5');">_</a>
                    </div>
                    <div id="infocontainerchild5" class="container-content">
                        <iframe id="wdel" src="forms/frmDelStart.aspx" class="iframeuc " style="height:460px;"></iframe>
                    </div>
                </div>
            </td>
        </tr>


        <tr>
            <td>
                <div id="InfoContainer6" style="width: 800px; height: 500px;" class="container">
                    <div class="container-header">
                        <asp:Label ID="Label5" runat="server" Text="Informacje"></asp:Label>
                        <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize6" onclick="minimize('InfoContainer6','infocontainerchild6');">_</a>
                    </div>
                    <div id="infocontainerchild6" class="container-content">
                        <iframe id="w6" src="forms/frmTargetCrew.aspx" class="iframeuc " style="height:460px;"></iframe>
                    </div>
                </div>
            </td>
            <td>
                <div id="InfoContainer7" style="width: 800px; height: 500px;" class="container">
                    <div class="container-header">
                        <asp:Label ID="Label6" runat="server" Text="Informacje"></asp:Label>
                        <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize7" onclick="minimize('InfoContainer7','infocontainerchild7');">_</a>
                    </div>
                    <div id="infocontainerchild7" class="container-content">
                        <iframe id="w7" src="forms/frmCrewPresentChart.aspx" class="iframeuc " style="height:460px;"></iframe>
                    </div>
                </div>
            </td>
        </tr>

    </table>
    </div>




    <div id="InfoContainer2" style="width: 800px; height: 500px;" class="container">
        <div class="container-header">
            <asp:Label ID="Label1" runat="server" Text="Informacje"></asp:Label>
            <a class="emoti_small cursors-pointer borders-solid-_1px" style="float: right; text-align: center;" id="btnMinimize2" onclick="minimize('InfoContainer2','infocontainerchild2');">_</a>
        </div>
        <div id="infocontainerchild2" class="container-content">
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </div>
    </div>




    <div ID="pnEdit2" class="modal-tlo"  style="visibility:hidden;">
        <asp:Panel ID="Panel3" CssClass="modal" Style="overflow: auto;width:50%;height:60%;" runat="server">
            <iframe id="ifrmodal" class="iframeuc" style="width:99%;height:95%;"></iframe>
        </asp:Panel>
    </div>







    <script>

      
        function myFunction(id) {
            var x = document.getElementById(id);
            if (x.className == "show") {
                x.className = "hide";
            } else {
                x.className = "show";
            }
        }
        function minimize(id, idchild) {
            var x = document.getElementById(id);
            var y = document.getElementById(idchild);
            if (x.style.height == "30px") {
                x.style.height = "500px";
                y.style.height = "470px";
            } else {
                x.style.height = "30px";
                y.style.height = "0px";
            }
        }


        function reftarget() {
            var iframe = document.getElementById('wtarget');
            iframe.src = iframe.src;
        }
    </script>
</asp:Content>

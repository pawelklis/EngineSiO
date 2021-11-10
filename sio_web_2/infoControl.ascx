<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="infoControl.ascx.vb" Inherits="sio_web_2.infoControl" ClientIDMode="AutoID" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link href="StyleSheet1.css" rel="stylesheet" />

<div class="borders-solid-_1px borders-radius margins-10px paddings-5px  ">

    <asp:Label ID="lbTime" runat="server" Text="lbTime"></asp:Label>
    <asp:Label ID="lbUser" runat="server" Text="lbUser"></asp:Label>
    <asp:Label ID="lbCategory" CssClass="texts-fonts-bold" runat="server" Text="lbCategory"></asp:Label>
    <br />
    <asp:Label ID="lbOrg" runat="server" Text="lbOrg"></asp:Label>
    <asp:Label ID="lbZone" runat="server" Text="lbZone"></asp:Label>
    <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>


    <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



           <asp:LinkButton ID="lnkAddComment" runat="server" style="float:right;" OnClick="lnkAddComment_Click">Dodaj komentarz</asp:LinkButton>

    <br />
    <ajaxtoolkit:accordion id="MyAccordion"  runat="server" selectedindex="-1" 
        headercssclass=" with-98 background-Black-to-white paddings-5px borders-radius margins-5px  paddings-5px cursors-pointer"
        headerselectedcssclass=" with-98  background-Black-to-white paddings-5px borders-radius margins-5px paddings-5px cursors-pointer " 
        contentcssclass="accordionContent" fadetransitions="false" framespersecond="40" transitionduration="250" autosize="None" requireopenedpane="false" suppressheaderpostbacks="true" style="width:100%;">
     <panes>
         <ajaxtoolkit:accordionpane id="AccordionPane1" runat="server">
             <header>              
                 
                 <asp:Label ID="Label1" runat="server" Text="Komentarze" />
        
             </header>
      
             <content>
  <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
             </content>
         </ajaxtoolkit:accordionpane>
   
     </panes>
 </ajaxtoolkit:accordion>

      <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
</div>



<asp:Panel ID="pnNewComment"  CssClass="modal-tlo" runat="server" Visible="false">
    <asp:Panel ID="Panel2" CssClass="modal" runat="server" Width="450" Height="280">
        <center>
        <asp:Button ID="btn_pncomment_close" OnClick="btn_pncomment_close_Click" CssClass="btnclose" runat="server" Text="X" />
            <h4>Nowy komentarz</h4>

        <asp:Label ID="lbCommentInfoId" runat="server" Text="lbCommentInfoId" style="visibility:hidden;"></asp:Label>

        <asp:TextBox ID="txNewComment" width="420" height="150" TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnAddNewComment" runat="server" Text="Dodaj" OnClick="btnAddNewComment_Click" />
        <br />
        </center>
    </asp:Panel>    
</asp:Panel>


                    </ContentTemplate>
    </asp:UpdatePanel>




        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modalload">
                <div class="center">
                    <img alt="" src="../loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#loadingImage').hide();
            document.getElementById('load').style.visibility = 'hidden';
        });



    </script>
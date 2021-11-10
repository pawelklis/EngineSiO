<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="frmTodayCrew.aspx.vb" Inherits="sio_web_2.frmTodayCrew" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../StyleSheet1.css" rel="stylesheet" />
</head>
<body onfocus="reftarget();"  >
    <form id="form1tc" runat="server"    onchange="reftarget();" >
         <script>
             function reftarget() {
                 //alert('pos');
                 //__doPostBack('', '');
                 document.getElementById('btnRefresh').click();
             };

             function sav() {
                 //alert('pos');
                 //__doPostBack('', '');
                 document.getElementById('btnsave').click();
             };

             function sleepFor(sleepDuration) {
                 var now = new Date().getTime();
                 while (new Date().getTime() < now + sleepDuration) { /* do nothing */ }
             }
         </script>

          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
     <div>
      <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />   <asp:Button ID="btnsave" runat="server"  Text="Odśwież" style="visibility:visible;" CssClass="btn-success" OnClick="btnsave_Click" />

                     <h2>Dzisiejsza obsada</h2>
         
   
           <asp:textbox Font-Size="20" placeholder="Nazwisko Imię"  AutoPostBack="true" ID="txTarget"  style="width:90%;"  runat="server"></asp:textbox> 
           <ajaxToolkit:AutoCompleteExtender TargetControlID="txTarget" ServiceMethod="auto" ID="AutoCompleteExtender1" runat="server"></ajaxToolkit:AutoCompleteExtender>
         <asp:ImageButton ID="btnAdd" Width="30" Height="30" ImageUrl="~/images/icons/add.png" runat="server" OnClick="btnAdd_Click" />
    
            <asp:GridView ID="dg1" CssClass="with-100 tableheader " RowStyle-VerticalAlign="Middle" style="z-index:99;" HeaderStyle-CssClass="tableheader" OnSelectedIndexChanged="dg1_SelectedIndexChanged" OnRowDataBound="dg1_RowDataBound" OnRowCommand="dg1_RowCommand" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="300">
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server"  Text="Pracownik"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
  <asp:CheckBox ID="ckPresent" Checked='<%# Bind("present") %>' ValidationGroup='<%# Bind("_id") %>' OnCheckedChanged="ckPresent_CheckedChanged" AutoPostBack="true" ToolTip="Obecność" runat="server" />
<img id="im" style="border:none;width:50px;height:50px;" runat="server" src="~/images/icons/add.png"/>
                            <asp:Label ID="lbname"  runat="server" ToolTip='<%# Bind("Plan_StartTime") %>' Text='<%# Bind("WorkerName") %>'></asp:Label>
        
                   
                            <asp:ImageButton ID="btnedit" runat="server" CommandArgument='<%# Bind("_id") %>' CommandName="ed" ImageUrl="~/images/icons/appbar.edit.box.png"  width="50" Height="50" style="float:right;"/>
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label21" runat="server" Text="Planowany czas pracy"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="planstart" runat="server" Text='<%# Bind("Plan_StartTime") %>' TOOLTIP='<%# Bind("Plan_StartTime") %>'></asp:Label>-<asp:Label ID="planstop" runat="server" Text='<%# Bind("Plan_EndWorkTime") %>' ToolTip='<%# Bind("Plan_EndWorkTime") %>'></asp:Label>
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label14" runat="server" Text="Rodzaj pracy"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label144" runat="server" ToolTip='<%# Bind("Exe_WorkTypeID") %>' Text='<%# Bind("Plan_WorkTypeID") %>'></asp:Label>
                            <asp:DropDownList ID="ddlZP"  ValidationGroup ='<%# Container.DataItemIndex %>' OnSelectedIndexChanged="ddlZP_SelectedIndexChanged" AutoPostBack="true"   runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label15" runat="server" Text="Faktyczny czas pracy"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <div style="display: inline-table;">
                                            <asp:TextBox OnTextChanged="txstart_TextChanged" AutoPostBack="true" ID="txstart" TextMode="DateTimeLocal" runat="server" ValidationGroup='<%# Bind("_id") %>' Text='<%# Bind("Exe_StartTime") %>' ToolTip='<%# Bind("Exe_StartTime") %>'></asp:TextBox>
                                            
                                            <asp:TextBox OnTextChanged="txstop_TextChanged" AutoPostBack="true" TextMode="DateTimeLocal" ID="txstop" ValidationGroup='<%# Bind("_id") %>' runat="server" Text='<%# Bind("Exe_EndWorkTime") %>' ToolTip='<%# Bind("Exe_EndWorkTime") %>'></asp:TextBox>
                                            <br />
                                            <asp:Label ID="scanstart" runat="server" Text='<%# Bind("ScanStart") %>' ToolTip='<%# Bind("ScanStart") %>'></asp:Label>
                                            -
                                            <asp:Label ID="scanstop" runat="server" Text='<%# Bind("ScanStop") %>' ToolTip='<%# Bind("ScanStop") %>'></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbwt" runat="server" Text="" Style="font-size: 40px;"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                   
               
                            <asp:Label ID="lbid" runat="server" Text='<%# Bind("_id") %>' Style="visibility: hidden; font-size: 0.1px; width: 0px; height: 0px; color: lightsteelblue;"></asp:Label>
                      
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>
            </asp:GridView>
         
        </div >
            </ContentTemplate>
        </asp:UpdatePanel>

   

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
        <ProgressTemplate>
            <div class="modalload">
                <div class="center">
                    <img alt="" src="../loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

   

         <asp:Button ID="btnRefresh" runat="server"  Text="Odśwież" style="visibility:hidden;" OnClick="btnRefresh_Click" />
      
    </form>

    <script>

        function showModal(page) {
            var iframe = parent.document.getElementById('ifrmodal');
            iframe.src = page;

            var modal = parent.document.getElementById('pnEdit2');
            modal.style.visibility = 'visible';
        };


        function reftarget() {
            
            var iframe = parent.document.getElementById('wtarget');
            iframe.src = iframe.src;
            
            };

        function sleepFor(sleepDuration) {
            var now = new Date().getTime();
            while (new Date().getTime() < now + sleepDuration) { /* do nothing */ }
        }

    </script>





</body>
</html>

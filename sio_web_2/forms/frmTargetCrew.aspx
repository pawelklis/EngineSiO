<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="frmTargetCrew.aspx.vb" Inherits="sio_web_2.frmTargetCrew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../StyleSheet1.css" rel="stylesheet" />
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

          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
     <div>
                     <h2>Zadania pracowników</h2>
        

            <asp:GridView ID="dg1" CssClass="with-100 tableheader " RowStyle-VerticalAlign="Middle" style="z-index:99;" HeaderStyle-CssClass="tableheader" OnSelectedIndexChanged="dg1_SelectedIndexChanged" OnRowDataBound="dg1_RowDataBound" OnRowCommand="dg1_RowCommand" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server"  Text="Pracownik"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbname" runat="server" ToolTip='<%# Bind("_id") %>' Text='<%# Bind("WorkerName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="lbtempstatus" Font-Size="Small" runat="server" Text='<%# Bind("tempstatus") %>'></asp:Label>
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label21" runat="server" Text="Czas pracy"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="planstart" runat="server" ToolTip='<%# Bind("Exe_StartTime") %>' Text='<%# Bind("Exe_StartTime") %>'></asp:Label> - <asp:Label ID="planstop" runat="server" ToolTip='<%# Bind("Exe_EndWorkTime") %>' Text='<%# Bind("Exe_EndWorkTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label15" runat="server" Text="Zadania" ></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
         
                            <asp:textbox OnTextChanged="txstart_TextChanged" AutoPostBack="true"  ID="txTarget"  style="width:90%;"  TextMode="MultiLine" runat="server"  ValidationGroup='<%# Bind("_id") %>'  Text='<%# Bind("Target") %>'></asp:textbox> 
                            <ajaxToolkit:AutoCompleteExtender TargetControlID="txTarget" ServiceMethod="auto" ID="AutoCompleteExtender1" runat="server"></ajaxToolkit:AutoCompleteExtender>
   
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
</body>
</html>

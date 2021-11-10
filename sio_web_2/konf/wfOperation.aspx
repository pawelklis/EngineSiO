<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="wfOperation.aspx.vb" EnableEventValidation="false" Inherits="sio_web_2.wfOperation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <link href="../StyleSheet1.css" rel="stylesheet" />



    <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>

    <table>
        <tr>
            <td>
                <asp:ImageButton ID="btnAdd" ImageUrl="~/images/icons/add.png" CssClass="btnadd" runat="server" OnClick="btnAdd_Click" />
            </td>
            <td>
                <h2>Kategorie operacji</h2>
            </td>
        </tr>
    </table>

    <div class="container-content  shadow" style="height: calc(100% - 85px); width: calc(100%-20px); margin: 10px;">
        <asp:GridView ID="dg1" CssClass="with-100" HeaderStyle-CssClass="tableheader" OnSelectedIndexChanged="dg1_SelectedIndexChanged" OnRowDataBound="dg1_RowDataBound" OnRowCommand="dg1_RowCommand" runat="server" AutoGenerateColumns="false">

            <Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Nazwa"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txid" runat="server" Text='<%# Bind("id") %>' Style="visibility: hidden;"></asp:Label>
                        <asp:Label ID="txname" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>        
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Edycja"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CommandName="edition" CssClass="btn-edit" runat="server" Text="Edytuj" CommandArgument='<%# Bind("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>




            </Columns>


        </asp:GridView>
    </div>

    <asp:Panel ID="pnEdit" CssClass="modal-tlo" runat="server" Visible="false">
        <asp:Panel ID="Panel2" CssClass="modal" Style="overflow: auto;" runat="server">

            <asp:ImageButton ID="btnpnEditClose1" CssClass="btnclose" ImageUrl="~/images/icons/close.png" runat="server" OnClick="btnpnEditClose_Click" />

            <asp:Label ID="labelID" Style="visibility: hidden;" runat="server" Text="0"></asp:Label>

            <h2 id="tt" runat="server" style="margin: 3px;"></h2>

            <div class="modalContent">

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Nazwa"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
               
                           
             
                </table>

            </div>

            <asp:Button ID="btnSave" CssClass="btn-success " runat="server" Text="Zapisz" OnClick="btnSave_Click" />

            <asp:ImageButton ID="btnDelete" CssClass="btnDelete" ToolTip="Usuń" ImageUrl="~/images/icons/delete.png" OnClick="btnDelete_Click" runat="server" OnClientClick="return confirm('Czy na pewno chcesz usunąć element?');" />
        </asp:Panel>
    </asp:Panel>





         <table>
        <tr>
            <td>
                <asp:ImageButton ID="btnAdd2" ImageUrl="~/images/icons/add.png" CssClass="btnadd" runat="server" OnClick="btnAdd2_Click" />
            </td>
            <td>
                <h2>Operacje</h2>
            </td>
        </tr>
    </table>


            <div class="container-content  shadow" style="height: calc(100% - 85px); width: calc(100%-20px); margin: 10px;">
        <asp:GridView ID="dg2" CssClass="with-100" HeaderStyle-CssClass="tableheader" OnSelectedIndexChanged="dg2_SelectedIndexChanged" OnRowDataBound="dg2_RowDataBound" OnRowCommand="dg2_RowCommand" runat="server" AutoGenerateColumns="false">

            <Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Nazwa"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txid2" runat="server" Text='<%# Bind("id") %>' Style="visibility: hidden;"></asp:Label>
                        <asp:Label ID="txname2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>      
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Polecenie"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>                       
                        <asp:Label ID="txpolecenie" runat="server" Text='<%# Bind("formatkaid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Informacja"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>                       
                        <asp:Label ID="txinfo" runat="server" Text='<%# Bind("infoid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Grupa powiadomień"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>                       
                        <asp:Label ID="txnot" runat="server" Text='<%# Bind("NotifyGroupID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Edycja"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit2" CommandName="edition" CssClass="btn-edit" runat="server" Text="Edytuj" CommandArgument='<%# Bind("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>




            </Columns>


        </asp:GridView>
    </div>

    <asp:Panel ID="pnEdit2" CssClass="modal-tlo" runat="server" Visible="false">
        <asp:Panel ID="Panel3" CssClass="modal" Style="overflow: auto;" runat="server">

            <asp:ImageButton ID="btnEdit2close" CssClass="btnclose" ImageUrl="~/images/icons/close.png" runat="server" OnClick="btnpnEdit2Close_Click" />

            <asp:Label ID="lbid2" Style="visibility: hidden;" runat="server" Text="0"></asp:Label>
            <asp:Label ID="lbopercat2" Style="visibility: hidden;" runat="server" Text="0"></asp:Label>
            <h2 id="H2" runat="server" style="margin: 3px;"></h2>

            <div class="modalContent">

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Nazwa"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txname2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Polecenie"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFormatka" runat="server"></asp:DropDownList>
                        </td>
                    </tr>                           
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Informacja"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlinfo" runat="server"></asp:DropDownList>
                        </td>
                    </tr>       
                                        <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Grupa powiadomień"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlnotify" runat="server"></asp:DropDownList>
                        </td>
                    </tr>       

                </table>

            </div>

            <asp:Button ID="btn2Save" CssClass="btn-success " runat="server" Text="Zapisz" OnClick="btn2Save_Click" />

            <asp:ImageButton ID="btndelete2" CssClass="btnDelete" ToolTip="Usuń" ImageUrl="~/images/icons/delete.png" OnClick="btnDelete2_Click" runat="server" OnClientClick="return confirm('Czy na pewno chcesz usunąć element?');" />
        </asp:Panel>
    </asp:Panel>









        
         <table>
        <tr>
            <td>
                <asp:ImageButton ID="btnAdd3" Visible="false" ImageUrl="~/images/icons/add.png" CssClass="btnadd" runat="server" OnClick="btnAdd3_Click" />
            </td>
            <td>
                <h3>Parametry</h3>
            </td>
        </tr>
    </table>


            <div class="container-content  shadow" style="height: calc(100% - 85px); width: calc(100%-30px); margin: 10px;">
        <asp:GridView ID="dg3" CssClass="with-100" HeaderStyle-CssClass="tableheader" OnSelectedIndexChanged="dg3_SelectedIndexChanged" OnRowDataBound="dg3_RowDataBound" OnRowCommand="dg3_RowCommand" runat="server" AutoGenerateColumns="false">

            <Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Nazwa"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txid3" runat="server" Text='<%# Bind("id") %>' Style="visibility: hidden;"></asp:Label>
                        <asp:Label ID="txname3" runat="server" ToolTip='<%# Bind("valuetype") %>' Text='<%# Bind("key") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>      
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Wartość"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>                       
                        <asp:Label ID="txvalue" runat="server" Text='<%# Bind("value") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Edycja"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit3" CommandName="edition" CssClass="btn-edit" runat="server" Text="Edytuj"   CommandArgument='<%# Bind("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>




            </Columns>


        </asp:GridView>
    </div>

    <asp:Panel ID="pnEdit3" CssClass="modal-tlo" runat="server" Visible="false">
        <asp:Panel ID="Panel1" CssClass="modal" Style="overflow: auto;" runat="server">

            <asp:ImageButton ID="btnEdit3close" CssClass="btnclose" ImageUrl="~/images/icons/close.png" runat="server" OnClick="btnpnEdit3Close_Click" />

            <asp:Label ID="lbid3" Style="visibility: hidden;" runat="server" Text="0"></asp:Label>
            <asp:Label ID="lbopercat3" Style="visibility: hidden;" runat="server" Text="0"></asp:Label>
            <h3 id="H3" runat="server" style="margin: 3px;"></h3>

            <div class="modalContent">

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Parametr"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txname3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Wartość"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlvalue" runat="server"></asp:DropDownList>
                        </td>
                    </tr>                           
             
                </table>

            </div>

            <asp:Button ID="btn3Save" CssClass="btn-success " runat="server" Text="Zapisz" OnClick="btn3Save_Click" />

            <asp:ImageButton ID="btndelete3" Visible="false" CssClass="btnDelete" ToolTip="Usuń" ImageUrl="~/images/icons/delete.png" OnClick="btnDelete3_Click" runat="server" OnClientClick="return confirm('Czy na pewno chcesz usunąć element?');" />
        </asp:Panel>
    </asp:Panel>

















</ContentTemplate></asp:UpdatePanel>


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

</asp:Content>


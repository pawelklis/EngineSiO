<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="wfUsers.aspx.vb" Inherits="sio_web_2.wfUsers" %>
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
                <h2>Użytkownicy</h2>
            </td>
        </tr>
    </table>

    <div class="container-content  shadow" style="height: calc(100% - 85px); width: calc(100%-20px); margin: 10px;">
        <asp:GridView ID="dg1" CssClass="with-100" HeaderStyle-CssClass="tableheader" OnRowDataBound="dg1_RowDataBound" OnRowCommand="dg1_RowCommand" runat="server" AutoGenerateColumns="false">

            <Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Imię"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txid" runat="server" Text='<%# Bind("id") %>' Style="visibility: hidden;"></asp:Label>
                        <asp:Label ID="txname33" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Nazwisko"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txSN33" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label4" runat="server" Text="Login"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="txLogin33" runat="server" Text='<%# Bind("login") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label6" runat="server" Text="Stanowisko"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Dostęp"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label94444" runat="server" Text='<%# Bind("AccessField") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Ostatni czas użycia"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label955555" runat="server" Text='<%# Bind("lasttime") %>'></asp:Label>
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
                            <asp:Label ID="Label10" runat="server" Text="Imię"></asp:Label>
                        </td>
                        <td>
                            <asp:label ID="txname" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Nazwisko"></asp:Label>
                        </td>
                        <td>
                            <asp:label ID="txSN" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Login"></asp:Label>
                        </td>
                        <td>
                            <asp:label ID="txLogin" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Stanowisko"></asp:Label>
                        </td>
                        <td>
                            <asp:label ID="txTitle" runat="server"></asp:label>
                        </td>
                    </tr>
              
                </table>


               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <h4 style="margin-bottom: 1px;">Lokalizacje</h4>
                        
                        <asp:GridView ID="dg2" CssClass="with-100" ShowHeader="false" GridLines="None"  AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:label Style="visibility: visible ;width:1px;height:1px;" ID="txkey" runat="server"  Text='<%# Bind("key") %>'></asp:label>
                                       <asp:label Style="visibility: hidden  ;width:1px;height:1px;" ID="lborgid" runat="server"  Text='<%# Bind("id") %>'></asp:label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:checkbox Style="visibility: visible ;width:1px;height:1px;" ID="txval" runat="server"  checked='<%# Bind("value") %>'></asp:checkbox>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

          
               <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>

                        <h4 style="margin-bottom: 1px;">Strefy</h4>
                        <asp:GridView ID="dg4" CssClass="with-100" ShowHeader="false" GridLines="None" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:label Style="visibility: visible ;width:1px;height:1px;" ID="txkey" runat="server"  Text='<%# Bind("key") %>'></asp:label>
                                       <asp:label Style="visibility: hidden  ;width:1px;height:1px;" ID="lborgid" runat="server"  Text='<%# Bind("id") %>'></asp:label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:checkbox Style="visibility: visible ;width:1px;height:1px;" ID="txval" runat="server"  checked='<%# Bind("value") %>'></asp:checkbox>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
          

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <h4 style="margin-bottom: 1px;">Uprawnienia</h4>
                        <asp:GridView ID="dg3" CssClass="with-100" ShowHeader="false" GridLines="None" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox Style="visibility: hidden;width:1px;height:1px;" ID="txkey" runat="server"  Text='<%# Bind("key") %>'></asp:TextBox>
                                         <asp:label Style="visibility: visible   ;width:1px;height:1px;" ID="lborgid" runat="server"  Text='<%# Bind("id") %>'></asp:label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:checkbox Style="visibility: visible;width:1px;height:1px;" ID="txval" runat="server"  checked='<%# Bind("value") %>'></asp:checkbox>
                                  

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

            <asp:Button ID="btnSave" CssClass="btn-success " runat="server" Text="Zapisz" OnClick="btnSave_Click" />

            <asp:ImageButton ID="btnDelete" CssClass="btnDelete" ToolTip="Usuń" ImageUrl="~/images/icons/delete.png" OnClick="btnDelete_Click" runat="server" OnClientClick="return confirm('Czy na pewno chcesz usunąć element?');" />
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

<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="wfNotifies.aspx.vb" EnableEventValidation="false" Inherits="sio_web_2.wfNotifies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../StyleSheet1.css" rel="stylesheet" />



    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>

            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="btnAdd" ImageUrl="~/images/icons/add.png" CssClass="btnadd" runat="server" OnClick="btnAdd_Click" />
                    </td>
                    <td>
                        <h2>Grupy powiadomień</h2>
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

                        <asp:DropDownList ID="ddluser" runat="server" Width="300" Height="40" Font-Size="Large"></asp:DropDownList>

                        <asp:ImageButton ID="btnAdd2" ImageUrl="~/images/icons/add.png" CssClass="btnadd" runat="server" OnClick="btnAdd2_Click" />
                    </td>
                    <td>
                        <h2>Lista odbiorców</h2>
                    </td>
                </tr>
            </table>


            <div class="container-content  shadow" style="height: calc(100% - 85px); width: calc(100%-20px); margin: 10px;">
                <asp:GridView ID="dg2" CssClass="with-100" HeaderStyle-CssClass="tableheader" OnSelectedIndexChanged="dg2_SelectedIndexChanged" OnRowDataBound="dg2_RowDataBound" OnRowCommand="dg2_RowCommand" runat="server" AutoGenerateColumns="false">

                    <Columns>
           
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txid2" runat="server" Text='<%# Bind("id") %>' Style="visibility: hidden;"></asp:Label>
                                <asp:Label ID="txname2" runat="server" Text='<%# Bind("login") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Imię"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txpolecenie" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Nazwisko"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txinfo" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Stanowisko"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="txtitle" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label8" runat="server" Text="Edycja"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit2" CommandName="edition" CssClass="btn-edit" runat="server" Text="Usuń" CommandArgument='<%# Bind("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>




                    </Columns>


                </asp:GridView>
            </div>

      

























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

</asp:Content>



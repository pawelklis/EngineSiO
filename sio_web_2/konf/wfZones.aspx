<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="wfZones.aspx.vb" Inherits="sio_web_2.wfZones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <link href="../StyleSheet1.css" rel="stylesheet" />

      <style>
        .ddlstyle
        {
            width: 200px;
        }
        option
        {
            padding-left: 20px;
            font-size: 12px;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>

    <table>
        <tr>
            <td>
                <asp:ImageButton ID="btnAdd" ImageUrl="~/images/icons/add.png" CssClass="btnadd" runat="server" OnClick="btnAdd_Click" />
            </td>
            <td>
                <h2>Komórki Organizacyjne</h2>
            </td>
        </tr>
    </table>

    <div class="container-content  shadow" style="height: calc(100% - 85px); width: calc(100%-20px); margin: 10px;">
        <asp:GridView ID="dg1" CssClass="with-100" HeaderStyle-CssClass="tableheader" OnRowDataBound="dg1_RowDataBound" OnRowCommand="dg1_RowCommand" runat="server" AutoGenerateColumns="false">

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
                        <asp:Label ID="Label2" runat="server" Text="Kod"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
           
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label6" runat="server" Text="Informacje dodatkowe"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("AdditionalInfoField") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Ostatni czas użycia"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("lasttime") %>'></asp:Label>
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
               
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Kod"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Ikona"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIcon" OnSelectedIndexChanged="ddlIcon_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                            <asp:Image ID="im1" runat="server" />
                        </td>
                    </tr>             
                </table>




                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <h4 style="margin-bottom: 1px;">Informacje dodatkowe</h4>
                        <asp:Button ID="btnAddInfo" OnClick="btnAddInfo_Click" runat="server" Text="Dodaj informację" CssClass="btn-edit" />
                        <asp:GridView ID="dg2"  CssClass="with-100" ShowHeader="false" GridLines="None" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txkey" runat="server" Text='<%# Bind("key") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txval" runat="server" Text='<%# Bind("value") %>'></asp:TextBox>
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

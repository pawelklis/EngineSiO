<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDelStart.aspx.vb" Inherits="sio_web_2.frmDelStart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onfocus="reftarget();">
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />
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
        <div>

            <h2>Delegowanie pracownika</h2>

            <table>
                <tr style="height:200px;overflow:auto;">
                    <td style="height:200px;overflow:auto;">
                        <asp:Label ID="Label2" runat="server" Text="Pracownicy do delegowania"></asp:Label>
                        <div style="height:200px;overflow:auto;">
                            <asp:CheckBoxList ID="ckWorkers" runat="server"></asp:CheckBoxList>
                        </div>                        
                    </td>
                    <td style="vertical-align:top;height:200px;overflow:auto;" class="Centered">
                        <asp:Label ID="Label1" runat="server" Text="Strefa docelowa"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlStrefa" Width="200" runat="server"></asp:DropDownList>
                        <br />
                        <asp:TextBox ID="txStartTime" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnStartDel" Width="200" OnClick="btnStartDel_Click" CssClass="btn-success" runat="server" Text="Deleguj" />
                    </td>
                </tr>
            </table>



            <asp:GridView ID="dg1" AutoGenerateColumns="false" HeaderStyle-CssClass="tableheader " CssClass=" with-100" OnRowCommand="dg1_RowCommand" OnRowDataBound="dg1_RowDataBound" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Pracownik"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="workername" runat="server" ToolTip='<%# Bind("idworker") %>' Text='<%# Bind("WorkerName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label12" runat="server" Text="Strefa macierzysta"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="zonefrom" runat="server"  ToolTip='<%# Bind("idzonefrom") %>' Text='<%# Bind("zonefrom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label13" runat="server" Text="Strefa docelowa"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="zoneto" runat="server" ToolTip='<%# Bind("idzoneto") %>'  Text='<%# Bind("zoneto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label14" runat="server" Text="Początek"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="delstart" runat="server" Text='<%# Bind("delstart") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label15" runat="server" Text="Koniec"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:textbox TextMode="DateTimeLocal" ID="delstop" runat="server" Text='<%# Bind("delstop") %>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
<asp:Button ID="btnEnd" runat="server" CssClass="btn-success" CommandArgument='<%# Bind("_id") %>' CommandName="" Text="Zakończ"  />
    </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
   


      

    <asp:Button ID="btnRefresh" runat="server"  Text="Odśwież" style="visibility:hidden;" OnClick="btnRefresh_Click" />
        </div>


     
    </form>
</body>
</html>

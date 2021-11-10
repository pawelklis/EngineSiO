<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfAllregions.aspx.vb" Inherits="sio_web_2.wfAllregions" EnableEventValidation="false" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>
            <asp:Panel ID="pn1"  runat="server" Style="width: 100%;">
                <center>
                <asp:Chart ID="Chart1"  runat="server" Height="400">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    </center>
                <div style="height: 200px; overflow: auto;">
                    <asp:GridView ID="dg1" OnRowDataBound="dg1_RowDataBound" OnSelectedIndexChanged="dg1_SelectedIndexChanged" AutoGenerateColumns="false" Style="width: 100%; height: 300px; overflow: auto;" Height="300" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Region"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Region") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="Liczba przesyłek"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("lp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </asp:Panel>
            

                 <asp:Panel ID="pn2"  runat="server" Style="width: 100%;">
                <center>
                <asp:Chart ID="Chart2"  runat="server" Height="400px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    </center>
                <div style="height: 200px; overflow: auto;">
                    <asp:GridView ID="dg2"  OnRowDataBound="dg2_RowDataBound" OnSelectedIndexChanged="dg2_SelectedIndexChanged" AutoGenerateColumns="false" Style="width: 100%; height: 300px; overflow: auto;" Height="300" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Region"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("typp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="Liczba przesyłek"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("lp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </asp:Panel>



                 <asp:Panel ID="pn3"  runat="server" Style="width: 100%;">
                     <asp:Label ID="Label5" runat="server" Text="Dane dla fazy: "></asp:Label>
                     <asp:DropDownList ID="ddlfaza" AutoPostBack="true" OnSelectedIndexChanged="ddlfaza_SelectedIndexChanged" runat="server" Height="16px" Width="298px">
                         <asp:ListItem>nadania</asp:ListItem>
                         <asp:ListItem>zbiórkowa</asp:ListItem>
                         <asp:ListItem>koncentracji</asp:ListItem>
                         <asp:ListItem>przewozu</asp:ListItem>
                         <asp:ListItem>dekoncentracji</asp:ListItem>
                         <asp:ListItem>rozwózki</asp:ListItem>
                         <asp:ListItem>doręczenia</asp:ListItem>
                         <asp:ListItem>nieokreślona</asp:ListItem>
                     </asp:DropDownList>

                <center>
                <asp:Chart ID="Chart3"  runat="server" Height="400px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    <br />
                 <asp:Chart ID="Chart4"  runat="server" Height="600px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

                    </center>
                <div style="height: 200px; overflow: auto;">
                    <asp:GridView ID="dg3"  OnRowDataBound="dg3_RowDataBound" OnSelectedIndexChanged="dg3_SelectedIndexChanged" AutoGenerateColumns="false" Style="width: 100%; height: 300px; overflow: auto;" Height="300" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Region"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("region") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="Liczba przesyłek"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("tf") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </asp:Panel>



            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

      
                                 <asp:Panel ID="pn4"  runat="server" Style="width: 100%;">
                <center>
                <asp:Chart ID="Chart5"  runat="server" Height="400px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    <br />
                     <asp:Chart ID="Chart6"  runat="server" Height="400px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    </center>
                <div style="height: 200px; overflow: auto;">
                    <asp:GridView ID="dg4"  OnRowDataBound="dg4_RowDataBound" OnSelectedIndexChanged="dg4_SelectedIndexChanged" AutoGenerateColumns="false" Style="width: 100%; height: 300px; overflow: auto;" Height="300" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Region"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Jednostki_fazy_Region") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="NSTD"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("NSTD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label5" runat="server" Text="NSTD"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("OPZ") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>
            </asp:Panel>


               </ContentTemplate>
            </asp:UpdatePanel>

             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                       <asp:DropDownList ID="ddl2" AutoPostBack="true" OnSelectedIndexChanged="ddl2_SelectedIndexChanged" runat="server" Height="16px" Width="298px">
                         <asp:ListItem>nadania</asp:ListItem>
                         <asp:ListItem>zbiórkowa</asp:ListItem>
                         <asp:ListItem>koncentracji</asp:ListItem>
                         <asp:ListItem>przewozu</asp:ListItem>
                         <asp:ListItem>dekoncentracji</asp:ListItem>
                         <asp:ListItem>rozwózki</asp:ListItem>
                         <asp:ListItem>doręczenia</asp:ListItem>
                         <asp:ListItem>nieokreślona</asp:ListItem>
                     </asp:DropDownList>
      
                          <asp:Panel ID="Panel1"  runat="server" Style="width: 100%;">
                <center>
                <asp:Chart ID="Chart7"  runat="server" Height="800px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    </center>
                <div style="height: 200px; overflow: auto;">
                    <asp:GridView ID="dg5"  OnRowDataBound="dg2_RowDataBound" OnSelectedIndexChanged="dg2_SelectedIndexChanged" AutoGenerateColumns="false" Style="width: 100%; height: 300px; overflow: auto;" Height="300" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Region"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Jednostki_fazy_Region") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="Liczba przesyłek"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("lp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </asp:Panel>


               </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

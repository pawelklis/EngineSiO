<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCrewSummary.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="sio_web_2.frmCrewSummary" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../StyleSheet1.css" rel="stylesheet" />

          <asp:DropDownList ID="ddlDate" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" runat="server"></asp:DropDownList>

        <asp:DropDownList ID="ddlZone" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" runat="server"></asp:DropDownList>


        <style>
            .cellright{
                border-right-style:solid;
                border-right-color:lightgray;
                border-right-width:0.5px;
            }

            .cellLeft{
                        border-left-style:solid;
                border-left-color:lightgray;
                border-left-width:0.5px;
            }
            .cellDown{
                              border-bottom-style:solid;
                border-bottom-color:lightgray;
                border-bottom-width:0.5px;
            }

            .cellUp{
                                     border-top-style:solid;
                border-top-color:lightgray;
                border-top-width:0.5px;
            }
        </style>

        <div>
        <%--    <asp:GridView ID="dg1" AutoGenerateColumns="false" Font-Size="Smaller" OnRowDataBound="dg1_RowDataBound" HeaderStyle-CssClass="tableheader"   CssClass="with-100 tableheader " runat="server">

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Pracownik"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"                                   Text='<%# Bind("workername") %>'></asp:Label>
                            <asp:Label ID="Label3" ToolTip='<%# Bind("idworker") %>' runat="server" Text='<%# Bind("workercode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label21" runat="server" Text="Dzień"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label212" runat="server" Text='<%# Bind("day") %>'></asp:Label>              
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label21" runat="server" Text="Planowana praca"></asp:Label>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21x" runat="server" Text="Początek"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4x" runat="server" Text="Koniec"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label22" runat="server" Text='<%# Bind("plan_starttime") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label24" runat="server" Text='<%# Bind("plan_endworktime") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4xx" runat="server" Text="Czas pracy"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5yy" runat="server" Text="Rodzaj godzin"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label25" runat="server" Text='<%# Bind("plan_worktime") %>'></asp:Label>
                                    </td>
                                    <td>
       <asp:Label ID="Label26" runat="server" Text='<%# Bind("plan_worktypeid") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>



                            
                            
                            <br />
                            
                     
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label31" runat="server" Text="Wykonana praca"></asp:Label></HeaderTemplate>
                        <ItemTemplate>

                                            <table>
                                <tr>
                                    <td class="cellright ">
                                        <asp:Label ID="Label21xt" runat="server" Text="Początek"></asp:Label>
                                    </td>
                                    <td class="cellLeft ">
                                        <asp:Label ID="Label4xt" runat="server" Text="Koniec"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cellright ">
<asp:Label ID="Label32" runat="server" Text='<%# Bind("exe_starttime") %>'></asp:Label>
                                    </td>
                                    <td class="cellLeft">
<asp:Label ID="Label34" runat="server" Text='<%# Bind("exe_endworktime") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cellright cellUp  ">
                                        <asp:Label ID="Label4xxt" runat="server" Text="Czas pracy"></asp:Label>
                                    </td>
                                    <td class="cellLeft cellUp">
                                        <asp:Label ID="Label5yyt" runat="server" Text="Rodzaj godzin"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cellright ">
<asp:Label ID="Label35" runat="server" Text='<%# Bind("exe_worktime") %>'></asp:Label>
                                    </td>
                                    <td class="cellLeft">
<asp:Label ID="Label36" runat="server" Text='<%# Bind("exe_worktypeid") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>

                            
                            
                            <br />
                            
                            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label41" runat="server" Text="Skan We/Wy"></asp:Label>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label41a" runat="server" Text="Wejście"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4bb" runat="server" Text="Wyjście"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5cc" runat="server" Text="Czas"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label42" runat="server" Text='<%# Bind("scanstart") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label44" runat="server" Text='<%# Bind("scanstop") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label45" runat="server" Text='<%# Bind("scantime") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            

                            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label51" runat="server" Text="Ewidencja wyjść"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label51a" runat="server" Text="Prywatne"></asp:Label></HeaderTemplate>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4b" runat="server" Text="Służbowe"></asp:Label></HeaderTemplate>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label52" runat="server" Text='<%# Bind("sumentryprivate") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label54" runat="server" Text='<%# Bind("sumentrywork") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label61" runat="server" Text="Obecny"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label62" runat="server" Text='<%# Bind("present") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label71" runat="server" Text="Uwagi"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label72" runat="server" Text='<%# Bind("descr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label81" runat="server" Text="Różnica"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label82" runat="server" Text='<%# Bind("r1") %>'></asp:Label>
                            <asp:Label ID="Label84" runat="server" Text='<%# Bind("r2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>--%>




            <asp:GridView ID="dg2" AutoGenerateColumns="false" Font-Size="Smaller" OnRowDataBound="dg2_RowDataBound" OnSelectedIndexChanged="dg2_SelectedIndexChanged" OnRowCommand="dg2_RowCommand" HeaderStyle-CssClass="tableheader"   CssClass="with-100  " runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>

                            <table class=" with-100 cursors-pointer">
                                <thead>
                                <td>
                                    <asp:Label ID="Label8" runat="server" text="Pracownik" style="width:16%;"></asp:Label>
                                </td>                             
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Planowany czas pracy" style="width:16%;"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Wykonany czas pracy" style="width:16%;"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Czas pracy skan" style="width:16%;"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Suma rodzajów godzin"  style="width:16%;"></asp:Label>
                                </td>
                                   <td>
                                    <asp:Label ID="Label145" runat="server" Text="Różnica"  style="width:16%;"></asp:Label>
                                </td>
                                </thead>
                                <tr>
                                 <td style="width:16%;">
                                    <asp:Label ID="Label3" runat="server" ToolTip='<%# Bind("idworker") %>' Text='<%# Bind("Pracownik") %>'></asp:Label>
                                </td>                             
                                <td style="width:16%;">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Planowanyczaspracy") %>'></asp:Label>
                                </td>
                                <td style="width:16%;">
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Wykonanyczaspracy") %>'></asp:Label>
                                </td>
                                <td style="width:16%;">
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Czaspracyskan") %>'></asp:Label>
                                </td>
                                <td style="width:16%;">
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Sumarodzajówgodzin") %>'></asp:Label>
                                </td>
                                <td style="width:16%;">
                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("roznica") %>'></asp:Label>
                                </td>
                                </tr>
                            </table>

                            <asp:Panel ID="pn1" runat="server" Visible="false">

                                <div>
             <asp:GridView ID="dg3" AutoGenerateColumns="false" Font-Size="Smaller" OnRowDataBound="dg1_RowDataBound" HeaderStyle-CssClass="tableheader"   CssClass="with-100  " runat="server">

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Pracownik"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"                                   Text='<%# Bind("workername") %>'></asp:Label>
                            <asp:Label ID="Label3" ToolTip='<%# Bind("idworker") %>' runat="server" Text='<%# Bind("workercode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label21" runat="server" Text="Dzień"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label212" runat="server" Text='<%# Bind("day") %>'></asp:Label>              
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label21" runat="server" Text="Planowana praca"></asp:Label>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21x" runat="server" Text="Początek"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4x" runat="server" Text="Koniec"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label22" runat="server" Text='<%# Bind("plan_starttime") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label24" runat="server" Text='<%# Bind("plan_endworktime") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4xx" runat="server" Text="Czas pracy"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5yy" runat="server" Text="Rodzaj godzin"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label25" runat="server" Text='<%# Bind("plan_worktime") %>'></asp:Label>
                                    </td>
                                    <td>
       <asp:Label ID="Label26" runat="server" Text='<%# Bind("plan_worktypeid") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>



                            
                            
                            <br />
                            
                     
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label31" runat="server" Text="Wykonana praca"></asp:Label></HeaderTemplate>
                        <ItemTemplate>

                                            <table>
                                <tr>
                                    <td class="cellright ">
                                        <asp:Label ID="Label21xt" runat="server" Text="Początek"></asp:Label>
                                    </td>
                                    <td class="cellLeft ">
                                        <asp:Label ID="Label4xt" runat="server" Text="Koniec"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cellright ">
<asp:Label ID="Label32" runat="server" Text='<%# Bind("exe_starttime") %>'></asp:Label>
                                    </td>
                                    <td class="cellLeft">
<asp:Label ID="Label34" runat="server" Text='<%# Bind("exe_endworktime") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cellright cellUp  ">
                                        <asp:Label ID="Label4xxt" runat="server" Text="Czas pracy"></asp:Label>
                                    </td>
                                    <td class="cellLeft cellUp">
                                        <asp:Label ID="Label5yyt" runat="server" Text="Rodzaj godzin"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cellright ">
<asp:Label ID="Label35" runat="server" Text='<%# Bind("exe_worktime") %>'></asp:Label>
                                    </td>
                                    <td class="cellLeft">
<asp:Label ID="Label36" runat="server" Text='<%# Bind("exe_worktypeid") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>

                            
                            
                            <br />
                            
                            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label41" runat="server" Text="Skan We/Wy"></asp:Label>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label41a" runat="server" Text="Wejście"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4bb" runat="server" Text="Wyjście"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5cc" runat="server" Text="Czas"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label42" runat="server" Text='<%# Bind("scanstart") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label44" runat="server" Text='<%# Bind("scanstop") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label45" runat="server" Text='<%# Bind("scantime") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            

                            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label51" runat="server" Text="Ewidencja wyjść"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label51a" runat="server" Text="Prywatne"></asp:Label></HeaderTemplate>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4b" runat="server" Text="Służbowe"></asp:Label></HeaderTemplate>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:Label ID="Label52" runat="server" Text='<%# Bind("sumentryprivate") %>'></asp:Label>
                                    </td>
                                    <td>
<asp:Label ID="Label54" runat="server" Text='<%# Bind("sumentrywork") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label61" runat="server" Text="Obecny"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label62" runat="server" Text='<%# Bind("present") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label71" runat="server" Text="Uwagi"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label72" runat="server" Text='<%# Bind("descr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label81" runat="server" Text="Różnica"></asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label82" runat="server" Text='<%# Bind("r1") %>'></asp:Label>
                            <asp:Label ID="Label84" runat="server" Text='<%# Bind("r2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>

                                </div>

                            </asp:Panel>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
       
            </asp:GridView>



        </div>
    </form>
</body>
</html>

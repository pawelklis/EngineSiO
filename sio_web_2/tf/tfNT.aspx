<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tfNT.aspx.vb" Inherits="sio_web_2.tfNT" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modalload">
                <div class="center">
                    <img alt="" src="../loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <style>
        .modalload {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            left:0px;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
            transition: all 2s;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>                

        <div>

            <table>
                <tr>
                    <td>
          <asp:Panel ID="Panel1" runat="server">

                 <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                <asp:GridView ID="dgf" OnRowDataBound="dgf_RowDataBound" OnRowCommand="dgf_RowCommand" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Pole"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                               <asp:TextBox ID="lf" runat="server" style="visibility:hidden;" Text='<%#Eval("f") %>'></asp:TextBox>
                                <asp:DropDownList ID="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                                    <asp:ListItem Text="Dzien" Value="Dzien"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_typu_przesylki" Value="Nazwa_typu_przesylki"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_serwisu" Value="Nazwa_serwisu"></asp:ListItem>
                                    <asp:ListItem Text="swiadczenia" Value="swiadczenia"></asp:ListItem>
                                    <asp:ListItem Text="Jednostki_fazy_Region" Value="Jednostki_fazy_Region"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_jednostki" Value="Nazwa_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="Kod_jednostki" Value="Kod_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="PNI" Value="PNI"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_fazy" Value="Nazwa_fazy"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_rodzaju_fazy" Value="Nazwa_rodzaju_fazy"></asp:ListItem>
                                    <asp:ListItem Text="PNA_i_miejscowosc_adresata" Value="PNA_i_miejscowosc_adresata"></asp:ListItem>
                                    <asp:ListItem Text="Identyfikator_przesylki" Value="Identyfikator_przesylki"></asp:ListItem>
                                    <asp:ListItem Text="Data_czas_nadania" Value="Data_czas_nadania"></asp:ListItem>
                                    <asp:ListItem Text="Gwarantowany_termin_doręczenia" Value="Gwarantowany_termin_doręczenia"></asp:ListItem>
                                    <asp:ListItem Text="Planowy_data_czas_wejscia_Do_jednostki" Value="Planowy_data_czas_wejscia_Do_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="Rzeczywisty_data_czas_wejscia_Do_jednostki" Value="Rzeczywisty_data_czas_wejscia_Do_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="Planowy_data_czas_wyjscia_z_jednostki" Value="Planowy_data_czas_wyjscia_z_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="Rzeczywisty_data_czas_wyjscia_z_jednostki" Value="Rzeczywisty_data_czas_wyjscia_z_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="Terminowosc_fazy_dla_jednostki" Value="Terminowosc_fazy_dla_jednostki"></asp:ListItem>
                                    <asp:ListItem Text="Terminowosc_E2E" Value="Terminowosc_E2E"></asp:ListItem>
                                    <asp:ListItem Text="Sparametryzowana" Value="Sparametryzowana"></asp:ListItem>
                                    <asp:ListItem Text="Data_czas_zdarzenia_konczacego_terminowosc_E2E" Value="Data_czas_zdarzenia_konczacego_terminowosc_E2E"></asp:ListItem>
                                    <asp:ListItem Text="idkarta" Value="idkarta"></asp:ListItem>
                                    <asp:ListItem Text="ID_MRUMC_klienta" Value="ID_MRUMC_klienta"></asp:ListItem>
                                    <asp:ListItem Text="Kod_klienta_w_ZST" Value="Kod_klienta_w_ZST"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_klienta" Value="Nazwa_klienta"></asp:ListItem>
                                    <asp:ListItem Text="Klient_kluczowy" Value="Klient_kluczowy"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_zdarzenia_wejscia" Value="Nazwa_zdarzenia_wejscia"></asp:ListItem>
                                    <asp:ListItem Text="Nazwa_zdarzenia_wyjscia" Value="Nazwa_zdarzenia_wyjscia"></asp:ListItem>
                                    <asp:ListItem Text="PNA_poczatek" Value="PNA_poczatek"></asp:ListItem>
                                    <asp:ListItem Text="tydzien" Value="tydzien"></asp:ListItem>
                                    <asp:ListItem Text="idlok" Value="idlok"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_nad" Value="Jednostka_nad"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_nad_kod" Value="Jednostka_nad_kod"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_nad_PNA" Value="Jednostka_nad_PNA"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_nad_kierunek" Value="Jednostka_nad_kierunek"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_nad_rozdzielnia" Value="Jednostka_nad_rozdzielnia"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_dor_kierunek" Value="Jednostka_dor_kierunek"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_dor_PNA" Value="Jednostka_dor_PNA"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_dor_rozdzielnia" Value="Jednostka_dor_rozdzielnia"></asp:ListItem>
                                    <asp:ListItem Text="Jednostka_dor" Value="Jednostka_dor"></asp:ListItem>
                                    <asp:ListItem Text="jednostka_dor_kod" Value="jednostka_dor_kod"></asp:ListItem>
                                    <asp:ListItem Text="godzinaWE" Value="godzinaWE"></asp:ListItem>
                                    <asp:ListItem Text="godzinaWY" Value="godzinaWY"></asp:ListItem>
                                    <asp:ListItem Text="czassobslminut" Value="czassobslminut"></asp:ListItem>
                                    <asp:ListItem Text="NSTD" Value="NSTD"></asp:ListItem>
                                    <asp:ListItem Text="OPZ" Value="OPZ"></asp:ListItem>
                                    <asp:ListItem Text="termin" Value="termin"></asp:ListItem>
                                    <asp:ListItem Text="Poprawne_WE" Value="Poprawne_WE"></asp:ListItem>
                                    <asp:ListItem Text="Poprawne_WY" Value="Poprawne_WY"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Jest równe"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txval" runat="server" Text='<%#Eval("v") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="Button3" runat="server" Text="X" CommandArgument='<%#Eval("f") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

            </asp:Panel>
                    </td>
                    <td>
                        <asp:Chart ID="Chart1" runat="server" Width="700">
                            <Series>
                                <asp:Series Name="Series1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                  </td>
                  <td>
                        <asp:Chart ID="Chart2" runat="server"  Width="700">
                            <Series>
                                <asp:Series Name="Series1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                </tr>

            </table>
  


            <asp:Panel ID="pnmod" runat="server"  style="position:fixed;left:0px;top:0px;width:100%;height:99vh;background-color:white;visibility:hidden;">
                <input type="button" value="Zamknij" style="height:35px;" onclick="hide();" />
                <br />
                <iframe id="ifr" runat="server" style="width:100%;height:98vh;" ></iframe>
            </asp:Panel>

            <asp:GridView ID="dg1" runat="server" OnRowCommand="dg1_RowCommand" AutoGenerateColumns="true">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="l1" runat="server" Text ="Identyfikator_przesylki"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input type="button"  style="height:35px;" value='<%#Eval("Identyfikator_przesylki") %>' onclick="show('<%# eval("Identyfikator_przesylki") %>');" />
                        </ItemTemplate>
                    </asp:TemplateField>


  

              <%--       <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="l211" runat="server" Text ="Rozdzielnia nadania"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Label ID="l222" runat="server" Text ='<%# Bind("Jednostka_nad_rozdzielnia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                     <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="l21" runat="server" Text ="Jednostka nadania"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Label ID="l22" runat="server" Text ='<%# Bind("Jednostka_nad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="l31" runat="server" Text ="Jednostka doręczenia"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Label ID="l32" runat="server" Text ='<%# Bind("Jednostka_dor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

                              <script>
                                  function show(nr) {
                                      var fr = document.getElementById('ifr');
                                      fr.src = 'wftfTracker.aspx?id=' + nr;
                                      var pn = document.getElementById('pnmod');
                                      pn.style.visibility = "visible";
                                  }
                                  function hide() {
                                      var pn = document.getElementById('pnmod');
                                      pn.style.visibility = "hidden";
                                  }
                              </script>

        </div>

</ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>

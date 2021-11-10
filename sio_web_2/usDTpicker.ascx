<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="usDTpicker.ascx.vb" Inherits="sio_web_2.usDTpicker" %>
<link href="StyleSheet1.css" rel="stylesheet" />
<asp:UpdatePanel ID="UpdatePanel1" style="background-color:white;z-index:999;" runat="server">
    <ContentTemplate>

<div style="position:relative;border:none;width:178px;height:22px;text-align:center;background-color:white;z-index:999999999999;width:210px;">

    <style>
        .dd{
                font-size: 30px;
    font-family: fantasy;
    cursor:pointer;
    width:46%;
    text-align:center;
    border:none;
        }

        .pnsc1{
            background-color:white;z-index:999999; position:absolute;
        }

 
    </style>
 
        <asp:TextBox ID="txDateTime" style="text-align:center;cursor:pointer;" ReadOnly="true" MaxLength="0" runat="server" onclick="showhide(this.id.replace('txDateTime', 'pn1'));" ></asp:TextBox>

    
<div style="position:fixed;bottom:400px;left:0px;" class="Centered">

        <asp:Panel ID="pn1" CssClass="pnsc1"  runat="server"   style="visibility:hidden; vertical-align:top;" >

            <asp:Button ID="Button1" OnClick="Button1_Click"  CssClass="btnclose" style="bottom:0px!important;border-radius:0px!important;height:20px;width:100%;" runat="server" Text="^^^" />
            
            <br />


            <asp:Calendar Font-Size="Smaller" ID="Calendar1" runat="server"  OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>

            <asp:dropdownlist ID="ddH" CssClass="dd anime"  OnSelectedIndexChanged="ddH_SelectedIndexChanged"  size="3" runat="server" AutoPostBack="true"   
                onfocus='this.size=3;' 
onblur='this.size=3;' 
onchange='this.size=3; this.blur();'>
                <asp:ListItem Text="00" Value="00"></asp:ListItem>
       <asp:ListItem Text="01" Value="01"></asp:ListItem>
       <asp:ListItem Text="02" Value="02"></asp:ListItem>
       <asp:ListItem Text="03" Value="03"></asp:ListItem>
       <asp:ListItem Text="04" Value="04"></asp:ListItem>
       <asp:ListItem Text="05" Value="05"></asp:ListItem>
       <asp:ListItem Text="06" Value="06"></asp:ListItem>
       <asp:ListItem Text="07" Value="07"></asp:ListItem>
       <asp:ListItem Text="08" Value="08"></asp:ListItem>
       <asp:ListItem Text="09" Value="09"></asp:ListItem>
       <asp:ListItem Text="10" Value="10"></asp:ListItem>
       <asp:ListItem Text="11" Value="11"></asp:ListItem>
       <asp:ListItem Text="12" Value="12"></asp:ListItem>
       <asp:ListItem Text="13" Value="13"></asp:ListItem>
       <asp:ListItem Text="14" Value="14"></asp:ListItem>
       <asp:ListItem Text="15" Value="15"></asp:ListItem>
       <asp:ListItem Text="16" Value="16"></asp:ListItem>
       <asp:ListItem Text="17" Value="17"></asp:ListItem>
       <asp:ListItem Text="18" Value="18"></asp:ListItem>
       <asp:ListItem Text="19" Value="19"></asp:ListItem>
       <asp:ListItem Text="20" Value="20"></asp:ListItem>
       <asp:ListItem Text="21" Value="21"></asp:ListItem>
       <asp:ListItem Text="22" Value="22"></asp:ListItem>
       <asp:ListItem Text="23" Value="23"></asp:ListItem>

            </asp:dropdownlist><asp:Label ID="Label1" CssClass="dd" runat="server" Text=":"></asp:Label>
            <asp:dropdownlist ID="ddM" CssClass="dd anime" size="3" runat="server"  OnSelectedIndexChanged="ddM_SelectedIndexChanged" AutoPostBack="true"      
                onfocus='this.size=3;' 
onblur='this.size=3;' 
onchange='this.size=3; this.blur();'>
                       <asp:ListItem Text="00" Value="00"></asp:ListItem>
       <asp:ListItem Text="01" Value="01"></asp:ListItem>
       <asp:ListItem Text="02" Value="02"></asp:ListItem>
       <asp:ListItem Text="03" Value="03"></asp:ListItem>
       <asp:ListItem Text="04" Value="04"></asp:ListItem>
       <asp:ListItem Text="05" Value="05"></asp:ListItem>
       <asp:ListItem Text="06" Value="06"></asp:ListItem>
       <asp:ListItem Text="07" Value="07"></asp:ListItem>
       <asp:ListItem Text="08" Value="08"></asp:ListItem>
       <asp:ListItem Text="09" Value="09"></asp:ListItem>
       <asp:ListItem Text="10" Value="10"></asp:ListItem>
       <asp:ListItem Text="11" Value="11"></asp:ListItem>
       <asp:ListItem Text="12" Value="12"></asp:ListItem>
       <asp:ListItem Text="13" Value="13"></asp:ListItem>
       <asp:ListItem Text="14" Value="14"></asp:ListItem>
       <asp:ListItem Text="15" Value="15"></asp:ListItem>
       <asp:ListItem Text="16" Value="16"></asp:ListItem>
       <asp:ListItem Text="17" Value="17"></asp:ListItem>
       <asp:ListItem Text="18" Value="18"></asp:ListItem>
       <asp:ListItem Text="19" Value="19"></asp:ListItem>
       <asp:ListItem Text="20" Value="20"></asp:ListItem>
       <asp:ListItem Text="21" Value="21"></asp:ListItem>
       <asp:ListItem Text="22" Value="22"></asp:ListItem>
       <asp:ListItem Text="23" Value="23"></asp:ListItem>
       <asp:ListItem Text="24" Value="24"></asp:ListItem>
       <asp:ListItem Text="25" Value="25"></asp:ListItem>
       <asp:ListItem Text="26" Value="26"></asp:ListItem>
       <asp:ListItem Text="27" Value="27"></asp:ListItem>
       <asp:ListItem Text="28" Value="28"></asp:ListItem>
       <asp:ListItem Text="29" Value="29"></asp:ListItem>
       <asp:ListItem Text="30" Value="30"></asp:ListItem>
       <asp:ListItem Text="31" Value="31"></asp:ListItem>
       <asp:ListItem Text="32" Value="32"></asp:ListItem>
       <asp:ListItem Text="33" Value="33"></asp:ListItem>
       <asp:ListItem Text="34" Value="34"></asp:ListItem>
       <asp:ListItem Text="35" Value="35"></asp:ListItem>
       <asp:ListItem Text="36" Value="36"></asp:ListItem>
       <asp:ListItem Text="37" Value="37"></asp:ListItem>
       <asp:ListItem Text="38" Value="38"></asp:ListItem>
       <asp:ListItem Text="39" Value="39"></asp:ListItem>
       <asp:ListItem Text="40" Value="40"></asp:ListItem>
       <asp:ListItem Text="41" Value="41"></asp:ListItem>
       <asp:ListItem Text="42" Value="42"></asp:ListItem>
       <asp:ListItem Text="43" Value="43"></asp:ListItem>
       <asp:ListItem Text="44" Value="44"></asp:ListItem>
       <asp:ListItem Text="45" Value="45"></asp:ListItem>
       <asp:ListItem Text="46" Value="46"></asp:ListItem>
       <asp:ListItem Text="47" Value="47"></asp:ListItem>
       <asp:ListItem Text="48" Value="48"></asp:ListItem>
       <asp:ListItem Text="49" Value="49"></asp:ListItem>
       <asp:ListItem Text="50" Value="50"></asp:ListItem>
       <asp:ListItem Text="51" Value="51"></asp:ListItem>
       <asp:ListItem Text="52" Value="52"></asp:ListItem>
       <asp:ListItem Text="53" Value="53"></asp:ListItem>
       <asp:ListItem Text="54" Value="54"></asp:ListItem>
       <asp:ListItem Text="55" Value="55"></asp:ListItem>
       <asp:ListItem Text="56" Value="56"></asp:ListItem>
       <asp:ListItem Text="57" Value="57"></asp:ListItem>
       <asp:ListItem Text="58" Value="58"></asp:ListItem>
       <asp:ListItem Text="59" Value="59"></asp:ListItem>

            </asp:dropdownlist>
        </asp:Panel>
  
</div>
    </div>

<script>


    function showhide(id) {

        var pn = document.getElementById(id);

        if (pn.style.visibility == "hidden") {
            pn.style.visibility = "visible";
        } else {
            pn.style.visibility = "hidden";
        }

    }

</script>




    </ContentTemplate>
</asp:UpdatePanel>
<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="contentControl.ascx.vb" Inherits="sio_web_2.contentControl" %>


<link href="StyleSheet1.css" rel="stylesheet" />

<div class="borders-radius borders-solid-_1px margins-10px paddings-5px ">

    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="lbTime" runat="server" Text="a"></asp:Label>
            </td>
            <td  class="texts-align-right ">
                <asp:Label ID="lbUser" runat="server" Text="b"></asp:Label>
            </td>
        </tr>
    </table>
    
    
    <br />
    <asp:Label ID="lbKey" CssClass="texts-fonts-bold" runat="server" Text="c"></asp:Label>
    <br />
    <asp:Label ID="lbValue" runat="server" Text="d"></asp:Label>

    <br />

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</div>


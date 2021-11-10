<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="PostControl.ascx.vb" Inherits="sio_web_2.PostControl" %>






<div>
    
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

</div>


<style>
    .cm{
        animation-name:example;
        animation-duration:1s;
        animation-iteration-count:1;
    }



    @keyframes example {
  from {opacity: 0;}
  to {opacity: 1;}
}
</style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <div class="">
<asp:Timer ID="Timer1" runat="server"></asp:Timer>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
</ContentTemplate></asp:UpdatePanel>
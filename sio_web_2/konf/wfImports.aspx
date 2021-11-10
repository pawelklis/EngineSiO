<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="wfImports.aspx.vb" Inherits="sio_web_2.wfImports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Button ID="btnImportHarm" runat="server" Text="ImportHarmonogramu" OnClick="btnImportHarm_Click" />


    <iframe id="ifr1" runat="server"  class="iframeuc">

    </iframe>


</asp:Content>

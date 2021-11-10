<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="NewInfoControl.ascx.vb" Inherits="sio_web_2.NewInfoControl" %>
<link href="StyleSheet1.css" rel="stylesheet" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

<asp:DropDownList ID="ddlCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>

<asp:DropDownList ID="ddlOperation" AutoPostBack="true" OnSelectedIndexChanged="ddlOperation_SelectedIndexChanged" runat="server"></asp:DropDownList>

<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <br />
    <iframe id="frm1" runat="server" class="iframeuc">

    </iframe>

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
<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="controlReaction.ascx.vb" Inherits="sio_web_2.controlReaction" %>
<link href="StyleSheet1.css" rel="stylesheet" />



<asp:updatepanel ID="up1" runat="server" ><ContentTemplate>
<a class="emoti-container"><asp:ImageButton ID="ImageButton1" CssClass="emoti_small" runat="server" ImageUrl="~/images/emoticons/likes.png" /><asp:Label ID="Label1" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton2" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/super.png" /><asp:Label ID="Label2" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton3" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/love.png" /><asp:Label ID="Label3" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton4" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/notlike.png" /><asp:Label ID="Label4" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton5" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/good.png" /><asp:Label ID="Label5" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton6" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/bad.png" /><asp:Label ID="Label6" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton7" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/cry.png" /><asp:Label ID="Label7" runat="server" Text="0"></asp:Label></a>
<a class="emoti-container"><asp:ImageButton ID="ImageButton8" CssClass="emoti_small"  runat="server" ImageUrl="~/images/emoticons/smile.png" /><asp:Label ID="Label8" runat="server" Text="0"></asp:Label></a>
</ContentTemplate></asp:updatepanel>


    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
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
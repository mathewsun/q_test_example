<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1Testt.aspx.cs" Inherits="Solo.WebForm1Testt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="3">Реф. ссылка:</td>
        </tr>
        <tr>
            <td colspan="3" class="height: 50px;">
                <input id="refferalLink" onclick="copyToClipboardUrl()" type="text" style="height: 20px; border: none; background: transparent; color: #181A1C; font-size: 17px; width: 350px; -webkit-appearance: none; box-shadow: inset 0px 0px 0px 0px red; cursor: pointer;" title="Скопировать" value="https://www.Solo-systems.net" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var topMenu = $("#top-navigation"),
            menuItems = topMenu.find("a");
            menuItems.parent().removeClass("active");
            menuItems.filter("[id*='CabinetLink']").parent().addClass("active");
        });

        function copyToClipboardUrl() {
            var copyText = document.getElementById("refferalLink");
            copyText.select();
            document.execCommand("copy");
        }

        function copyToClipboardAccountId() {
            var copyText = document.getElementById("accountId");
            copyText.select();
            document.execCommand("copy");
        }
    </script>
</asp:Content>

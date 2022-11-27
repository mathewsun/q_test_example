<%@ Page Title="Заработок" Language="C#" MasterPageFile="~/SiteBalance.Master" AutoEventWireup="true" CodeBehind="Profit.aspx.cs" Inherits="Solo.Account.Profit" %>

<%@ Register Src="Menu.ascx" TagName="AccountMenu" TagPrefix="uc1" %>

<%@ Register Src="/Account/ManageTopUserControl.ascx" TagName="TopManageControl" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" runat="server">
    <uc1:AccountMenu ID="AccountMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/jquery.tablesorter.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:TopManageControl ID="TopManageMenu" runat="server" />
    <br />
    <hr />
    <br />
    <div>
        Ваша ссылка для привлечения рефералов - <strong>
            <asp:Label ID="LabelReferralLink" runat="server" /></strong>
    </div>
    <br />
    <hr />
    <br />
    Добавьте аккаунты и получайте постоянный доход.
    <br />
    <br />
    Чтобы аккаунты начали работать скачайте клиент SmmZilla, и запустите - аккаунты будут сами выполнять свои действия.
    <br />
    <br />
    <div id="download">
        <table>
            <tr>
                <td colspan="2"><strong>Текущая версия - 1.2.27</strong></td>
            </tr>
            <tr onclick="document.location = '/Content/SmmZilla.rar';">
                <td>
                    <strong><a href="/Content/SmmZilla.rar" class="nounderline" title="Rar архив">Rar</a></strong>
                </td>
                <td>
                    <a href="/Content/SmmZilla.rar" class="nounderline" title="Rar архив">
                        <img src="../Images/download.png" alt="download smmzilla" class="dowload-img" /></a>
                </td>
            </tr>
            <tr onclick="document.location = '/Content/SmmZilla.sfx.exe';">
                <td>
                    <strong><a href="/Content/SmmZilla.sfx.exe" class="nounderline" title="Самораспаковывающийся архив">Sfx</a></strong>
                </td>
                <td>
                    <a href="/Content/SmmZilla.sfx.exe" class="nounderline" title="Самораспаковывающийся архив Sfx">
                        <img src="../Images/download.png" alt="download smmzilla" class="dowload-img" /></a>
                </td>
            </tr>
            <tr onclick="document.location = '/Content/SmmZilla.zip';">
                <td>
                    <strong><a href="/Content/SmmZilla.zip" class="nounderline" title="Zip архив">Zip</a></strong>
                </td>
                <td>
                    <a href="/Content/SmmZilla.zip" class="nounderline" title="Zip архив">
                        <img src="../Images/download.png" alt="download smmzilla" class="dowload-img" /></a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

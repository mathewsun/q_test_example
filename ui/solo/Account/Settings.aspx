<%@ Page Title="Настройки" Language="C#" MasterPageFile="~/SiteBalance.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Solo.Account.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function EditValue(value) {

            $("#TextBox" + value).addClass("cabinetTextBoxVisible");
            $("#TextBox" + value).prop('readonly', false);
            $('#edit' + value).hide();
            $('#edit' + value + 'Ok').show();
        }

        function SaveValue(value) {

            $("#TextBox" + value).removeClass("cabinetTextBoxVisible");

            if ($('#TextBox' + value).val().length == 0 && value == 'Referrer')
            {
                swal('Укажите id реферера', '', 'warning');
                return false;
            }

            if (value == 'Referrer') {
                $('#editReferrerOk').hide();
            }

            $('#TextBox' + value).prop('readonly', true);
            $('#edit' + value + 'Ok').hide();
            $('#edit' + value).show();

            var result = $('#TextBox' + value).val();

            $.ajax({
                url: "Result.ashx?eventName=saveUserParam&id=" + value + "&result=" + result
            }).done(function () { }
            );
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <table class="marginTable settingsTable">
        <tr>
            <td>Реферер:</td>
            <td>
                <asp:TextBox ID="TextBoxReferrer" ClientIDMode="Static" CssClass="settingsTextBoxVisible" runat="server"></asp:TextBox></td>
            <td>
                <img alt="Сохранить" runat="server" ClientIDMode="Static" src="/Images/slready16.png" id="editReferrerOk" title="Сохранить" class="pointer" onclick="SaveValue('Referrer')" />
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="TextBoxEmail" ClientIDMode="Static" ReadOnly="true" CssClass="settingsTextBoxVisible" runat="server"></asp:TextBox></td>
            <td>
                <img alt="Редактировать" src="/Images/icon_edit.png" id="editEmail" title="Редактировать" class="pointer" onclick="EditValue('Email')" />
                <img alt="Сохранить" src="/Images/slready16.png" id="editEmailOk" style="display: none;" title="Сохранить" class="pointer" onclick="SaveValue('Email')" />
            </td>
        </tr>
        <tr>
            <td>Телефон:</td>
            <td>
                <asp:TextBox ID="TextBoxCommunication" ClientIDMode="Static" ReadOnly="true" CssClass="settingsTextBoxVisible" runat="server"></asp:TextBox></td>
            <td>
                <img alt="Редактировать" src="/Images/icon_edit.png" id="editCommunication" title="Редактировать" class="pointer" onclick="EditValue('Communication')" />
                <img alt="Сохранить" src="/Images/slready16.png" id="editCommunicationOk" style="display: none;" title="Сохранить" class="pointer" onclick="SaveValue('Communication')" />
            </td>
        </tr>
        <tr>
            <td>Vk.com:</td>
            <td>
                <asp:TextBox ID="TextBoxVkontakteId" ClientIDMode="Static" ReadOnly="true" CssClass="settingsTextBoxVisible" runat="server"></asp:TextBox></td>
            <td>
                <img alt="Редактировать" src="/Images/icon_edit.png" id="editVkontakteId" title="Редактировать" class="pointer" onclick="EditValue('VkontakteId')" />
                <img alt="Сохранить" src="/Images/slready16.png" id="editVkontakteIdOk" style="display: none;" title="Сохранить" class="pointer" onclick="SaveValue('VkontakteId')" />
            </td>
        </tr>
        <tr>
            <td>Skype:</td>
            <td>
                <asp:TextBox ID="TextBoxSkype" ClientIDMode="Static" ReadOnly="true" CssClass="settingsTextBoxVisible" runat="server"></asp:TextBox></td>
            <td>
                <img alt="Редактировать" src="/Images/icon_edit.png" id="editSkype" title="Редактировать" class="pointer" onclick="EditValue('Skype')" />
                <img alt="Сохранить" src="/Images/slready16.png" id="editSkypeOk" style="display: none;" title="Сохранить" class="pointer" onclick="SaveValue('Skype')" />
            </td>
        </tr>
        <tr>
            <td>Icq:</td>
            <td>
                <asp:TextBox ID="TextBoxIcq" ClientIDMode="Static" ReadOnly="true" CssClass="settingsTextBoxVisible" runat="server"></asp:TextBox></td>
            <td>
                <img alt="Редактировать" src="/Images/icon_edit.png" id="editIcq" title="Редактировать" class="pointer" onclick="EditValue('Icq')" />
                <img alt="Сохранить" src="/Images/slready16.png" id="editIcqOk" style="display: none;" title="Сохранить" class="pointer" onclick="SaveValue('Icq')" />
            </td>
        </tr>
    </table>
</asp:Content>

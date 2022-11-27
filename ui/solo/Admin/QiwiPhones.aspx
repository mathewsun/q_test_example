<%@ Page Title="Киви номера" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QiwiPhones.aspx.cs" Inherits="Solo.Admin.QiwiPhones" %>

<%@ Import Namespace="Solo.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/jquery.tablesorter.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <a href="/Admin/QiwiPhones.aspx"><h2><%: Title %></h2></a>

    <br />
    <a href="QiwiPhoneOne.aspx" title="Добавить номер">Добавить номер</a>
    <br />
    <br />
    <asp:Button ID="ButtonUpdateWorkNumber" runat="server" Text="Обновить баланс у меньшего" OnClick="ButtonUpdateWorkNumber_Click" />
    <br />
    <br />
    <table class="basicTable numbersTable">
        <thead>
            <tr>
                <th>№
                </th>
                <th>Номер
                </th>
                <th>Баланс
                </th>
                <th></th>
                <th>За месяц</th>
                <th>LastActive</th>
                <th>WhenHistoryChecked</th>
                <th>Заблокирован</th>

            </tr>
        </thead>
        <tbody>
            <% for (int i = 0; i < ListItems.Count; i++)
                {%>
            <tr <%if (ListItems[i].Blocked)
                {%>style="background: #B18904;" <%} %>>
                <td style="vertical-align: top;">
                    <%= i + 1%>
                </td>
                <td style="vertical-align: top;">
                    <%= ListItems[i].Number%>
                </td>
                <td>
                    <span class="balance"><%= ListItems[i].Balance%></span>
                </td>
                <td>
                    <a href="QiwiPhones.aspx?update=<%= ListItems[i].Number%>">
                        <img src="/Images/slready20.png" class="button-update-phones" alt="Обновить историю и баланс" title="Обновить историю и баланс">
                    </a>
                </td>
                <td>
                    <%= ListItems[i].BalanceUpdatePerMonth%>
                </td>
                <td>
                    <%= ListItems[i].LastActive.ToString("dd.MM.yyyy HH:mm")%>
                </td>
                <td>
                    <%= ListItems[i].WhenHistoryChecked.ToString("dd.MM.yyyy HH:mm")%>
                </td>
                <td>
                    <%if (ListItems[i].Blocked)
                        {%>Да<%}
                             else
                             { %>Нет<%} %>
                </td>

            </tr>
            <% } %>
        </tbody>
        <tfoot>
            <tr style="border-top: 1px dashed #69c;">
                <td colspan="2">Итого:</td>
                <td><span id="TotalBalance"></span>руб.</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </tfoot>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".numbersTable").tablesorter({ dateFormat: "uk" });

            var TotalBalance = 0;

            $(this).find(".balance").each(function () {
                var txt = $(this).text();
                var sum = txt ? txt.replace(',', '.') * 1 : 0;
                TotalBalance = TotalBalance + sum;
            });

            $("#TotalBalance").text(TotalBalance.toFixed(2));

        });
    </script>
</asp:Content>


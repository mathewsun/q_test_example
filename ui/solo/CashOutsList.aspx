<%@ Page Title="500 последних выводов средств" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CashOutsList.aspx.cs" Inherits="Solo.CashOutsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    Всего выведено: <%= FullCashOut %> руб.
    <br />
    Выведено за 24 часа: <%= TodayCashOut %> руб.
    <br />
    Сумма последних 500 выводов: <%=(from x in ListCashOuts select x.Value).Sum().ToString("N2") %> руб.

    <table class="basicTable">
        <tr>
            <th>№
            </th>
            <th>Дата
            </th>
            <th>Кошелек
            </th>
            <th>Сумма
            </th>
        </tr>
        <% for (int i = 0; ListCashOuts != null && i < ListCashOuts.Count; i++)
            {%>
        <tr>
            <td>
                <%= ListCashOuts[i].Id%>
            </td>
            <td>
                <%= ListCashOuts[i].WhenDate.ToString("dd.MM.yyyy HH:mm")%>
            </td>
            <td>
                <a href="/Account/Payment.aspx?id=<%= ListCashOuts[i].PublicId%>" title="Перевести средства"><%= ListCashOuts[i].PublicId%></a>
            </td>
            <td class="center">
                <%= ListCashOuts[i].Value.ToString("N2")%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>

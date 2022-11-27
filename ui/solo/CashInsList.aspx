<%@ Page Title="500 последних зачислений средств" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CashInsList.aspx.cs" Inherits="Solo.CashInsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    Всего зачислено: <%= FullCashIn %> руб.
    <br />
    Зачислено за 24 часа: <%= TodayCashIn %> руб.
    <br />
    Сумма последних 500 зачислений: <%=(from x in ListCashIns select x.Value).Sum().ToString("N2") %> руб.

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
        <% for (int i = 0; ListCashIns != null && i < ListCashIns.Count; i++)
            {%>
        <tr>
            <td>
                <%= ListCashIns[i].Id%>
            </td>
            <td>
                <%= ListCashIns[i].WhenDate.ToString("dd.MM.yyyy HH:mm")%>
            </td>
            <td>
                <a href="/Account/Payment.aspx?id=<%= ListCashIns[i].PublicId%>" title="Перевести средства"><%= ListCashIns[i].PublicId%></a>
            </td>
            <td class="center">
                <%= ListCashIns[i].Value.ToString("N2")%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>

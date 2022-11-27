<%@ Page Title="Пополнения" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CashIns.aspx.cs" Inherits="Solo.Admin.CashIns" %>

<%@ Import Namespace="Solo.Model" %>

<%@ Register Src="AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <table class="basicTable">
        <tr>
            <th>Номер</th>
            <th>Пользователь</th>
            <th>Сумма</th>
            <th>Способ</th>
            <th>Дата</th>
        </tr>
        <% for (int i = 0; list != null && i < list.Count; i++)
            {%>
        <tr>
            <td>
                <%= list.Count - i%>
            </td>
            <td>
                <a href="User.aspx?id=<%=list[i].UserId%>"><%= DataHelper.GetUser(list[i].UserId).UserName%></a>
            </td>
            <td>
                <%= list[i].Value%>
            </td>
            <td>
                <%= list[i].Sposob%>
            </td>
            <td>
                <%= list[i].WhenDate.AddHours(HoursDifference).ToString("dd.MM.yyyy HH:mm")%>
            </td>
        </tr>
        <% } %>
    </table>

</asp:Content>

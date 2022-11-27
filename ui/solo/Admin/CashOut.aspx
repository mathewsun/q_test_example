<%@ Page Title="Вывод средств" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CashOut.aspx.cs" Inherits="Solo.Admin.CashOut" %>

<%@ Import Namespace="Solo.Model" %>

<%@ Register Src="AdminMenu.ascx" TagName="AdminMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <table class="basicTable cashOut-table">
        <tr>
            <th>Номер</th>
            <th>User</th>
            <th>Сумма</th>
            <th>Способ</th>
            <th>Номер счета</th>
            <th>Статус</th>
            <th style="width: 25px;"></th>
            <th style="width: 25px;"></th>
            <th>Комментарий</th>
            <th>Запрошен</th>
            <th>Отработан</th>
        </tr>
        <% for (int i = 0; list != null && i < list.Count; i++)
            {%>
        <tr class="<% if (list[i].State == (int)CashOutStatesEnum.Finished)
            { %>greenRow<% } %>
                    <% if (list[i].State == (int)CashOutStatesEnum.Entered)
            { %>orangeRow<% } %>
                    <% if (list[i].State == (int)CashOutStatesEnum.Rejected)
            { %>redRow<% } %>
            ">
            <td>
                <%= list[i].Id%>
            </td>
            <td>
                <a href="User.aspx?id=<%=list[i].UserId%>"><%= Solo.Model.Helper.TruncateLongString(DataHelper.GetUser(list[i].UserId).UserName, 10)%></a>
            </td>
            <td>
                <%= list[i].Value%>
            </td>
            <td>
                <%= list[i].Type != 0 ? CashOutTypes.GetName(list[i].Type) : list[i].Sposob%>
            </td>
            <td>
                <%= list[i].Number%>
            </td>
            <td>
                <%= CashOutStates.GetName(list[i].State)%>
            </td>
            <td style="padding: 2px 2px; width: 25px;">
                <% if (list[i].State == 1)
                    { %>
                <img src="/Images/slready20.png" alt="Подтвердить" title="Подтвердить" onclick="AccetptCashOut(<%= list[i].Id%>)" class="cashOut-confirm" />
                <% } %>
            </td>
            <td style="padding: 2px 2px; width: 25px;">
                <% if (list[i].State == 1)
                    { %>
                <img src="/Images/delete.png" alt="Отклонить" title="Отклонить" onclick="CancelCashOut(<%= list[i].Id%>)" class="cashOut-reject" />
                <% } %>
            </td>
            <td style="width:  110px;">
                <% if (list[i].State == 1)
                    { %>
                <input type="text" id="comment<%= list[i].Id%>" class="cashOut-comment" style="width: 100px;" />
                <% }
                    else
                    {%>
                <%= Solo.Model.Helper.TruncateLongString(list[i].Comment, 15)%>
                <% } %>
            </td>
            <td>
                <%= list[i].WhenDate.AddHours(HoursDifference).ToString("dd.MM.yyyy HH:mm")%>
            </td>
            <td>
                <%= list[i].WhenAdminEvent.HasValue ? list[i].WhenAdminEvent.Value.AddHours(HoursDifference).ToString("dd.MM.yyyy HH:mm") : ""%>
            </td>
        </tr>
        <% } %>

        <script type="text/javascript">

            function CancelCashOut(id) {
                $.ajax({
                    url: "Result.ashx?eventName=cashoutresult&result=3&id=" + id + "&comment=" + $('#comment' + id).val()
                }).done(function () {
                    swal("Вывод отменен!", "", "success");
                });

                setTimeout(function () {
                    window.location.href = "CashOut.aspx";
                }, 2000);
            }

            function AccetptCashOut(id) {
                $.ajax({
                    url: "Result.ashx?eventName=cashoutresult&result=2&id=" + id + "&comment=" + $('#comment' + id).val()
                }).done(function () {
                    swal("Вывод подтвержден!", "", "success");
                });

                setTimeout(function () {
                    window.location.href = "CashOut.aspx";
                }, 2000);
            }

            function ShowResult(result) {
                if (result == "0") {
                    //swal('Укажите Url', '', 'warning');
                }

                if (result == "1") {
                    swal("Задание добавлено!", "", "success");
                }

                if (result == "2") {
                    //swal('Недостаточно средств', 'Пополните счет!', 'warning');
                }
            }
        </script>
    </table>

</asp:Content>

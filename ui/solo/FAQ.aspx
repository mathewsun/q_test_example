<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Solo.FAQ" %>

<%@ Import Namespace="Solo.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">window.NREUM || (NREUM = {}), __nr_require = function (e, n, t) { function r(t) { if (!n[t]) { var o = n[t] = { exports: {} }; e[t][0].call(o.exports, function (n) { var o = e[t][1][n]; return r(o ? o : n) }, o, o.exports) } return n[t].exports } if ("function" == typeof __nr_require) return __nr_require; for (var o = 0; o < t.length; o++) r(t[o]); return r }({ QJf3ax: [function (e, n) { function t(e) { function n(n, t, a) { e && e(n, t, a), a || (a = {}); for (var u = c(n), f = u.length, s = i(a, o, r), p = 0; f > p; p++) u[p].apply(s, t); return s } function a(e, n) { f[e] = c(e).concat(n) } function c(e) { return f[e] || [] } function u() { return t(n) } var f = {}; return { on: a, emit: n, create: u, listeners: c, _events: f } } function r() { return {} } var o = "nr@context", i = e("gos"); n.exports = t() }, { gos: "7eSDFh" }], ee: [function (e, n) { n.exports = e("QJf3ax") }, {}], 3: [function (e, n) { function t(e) { return function () { r(e, [(new Date).getTime()].concat(i(arguments))) } } var r = e("handle"), o = e(1), i = e(2); "undefined" == typeof window.newrelic && (newrelic = window.NREUM); var a = ["setPageViewName", "addPageAction", "setCustomAttribute", "finished", "addToTrace", "inlineHit", "noticeError"]; o(a, function (e, n) { window.NREUM[n] = t("api-" + n) }), n.exports = window.NREUM }, { 1: 12, 2: 13, handle: "D5DuLP" }], gos: [function (e, n) { n.exports = e("7eSDFh") }, {}], "7eSDFh": [function (e, n) { function t(e, n, t) { if (r.call(e, n)) return e[n]; var o = t(); if (Object.defineProperty && Object.keys) try { return Object.defineProperty(e, n, { value: o, writable: !0, enumerable: !1 }), o } catch (i) { } return e[n] = o, o } var r = Object.prototype.hasOwnProperty; n.exports = t }, {}], D5DuLP: [function (e, n) { function t(e, n, t) { return r.listeners(e).length ? r.emit(e, n, t) : void (r.q && (r.q[e] || (r.q[e] = []), r.q[e].push(n))) } var r = e("ee").create(); n.exports = t, t.ee = r, r.q = {} }, { ee: "QJf3ax" }], handle: [function (e, n) { n.exports = e("D5DuLP") }, {}], XL7HBI: [function (e, n) { function t(e) { var n = typeof e; return !e || "object" !== n && "function" !== n ? -1 : e === window ? 0 : i(e, o, function () { return r++ }) } var r = 1, o = "nr@id", i = e("gos"); n.exports = t }, { gos: "7eSDFh" }], id: [function (e, n) { n.exports = e("XL7HBI") }, {}], G9z0Bl: [function (e, n) { function t() { var e = d.info = NREUM.info, n = f.getElementsByTagName("script")[0]; if (e && e.licenseKey && e.applicationID && n) { c(p, function (n, t) { n in e || (e[n] = t) }); var t = "https" === s.split(":")[0] || e.sslForHttp; d.proto = t ? "https://" : "http://", a("mark", ["onload", i()]); var r = f.createElement("script"); r.src = d.proto + e.agent, n.parentNode.insertBefore(r, n) } } function r() { "complete" === f.readyState && o() } function o() { a("mark", ["domContent", i()]) } function i() { return (new Date).getTime() } var a = e("handle"), c = e(1), u = window, f = u.document; e(2); var s = ("" + location).split("?")[0], p = { beacon: "bam.nr-data.net", errorBeacon: "bam.nr-data.net", agent: "js-agent.newrelic.com/nr-686.min.js" }, d = n.exports = { offset: i(), origin: s, features: {} }; f.addEventListener ? (f.addEventListener("DOMContentLoaded", o, !1), u.addEventListener("load", t, !1)) : (f.attachEvent("onreadystatechange", r), u.attachEvent("onload", t)), a("mark", ["firstbyte", i()]) }, { 1: 12, 2: 3, handle: "D5DuLP" }], loader: [function (e, n) { n.exports = e("G9z0Bl") }, {}], 12: [function (e, n) { function t(e, n) { var t = [], o = "", i = 0; for (o in e) r.call(e, o) && (t[i] = n(o, e[o]), i += 1); return t } var r = Object.prototype.hasOwnProperty; n.exports = t }, {}], 13: [function (e, n) { function t(e, n, t) { n || (n = 0), "undefined" == typeof t && (t = e ? e.length : 0); for (var r = -1, o = t - n || 0, i = Array(0 > o ? 0 : o) ; ++r < o;) i[r] = e[n + r]; return i } n.exports = t }, {}] }, {}, ["G9z0Bl"]);</script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>

    <link rel="stylesheet" type="text/css" href="/Content/jquery.formstyler.css" />
    <link rel="stylesheet" type="text/css" href="/Content/common.css" />
    <link rel="stylesheet" type="text/css" href="/Content/style.css" />
    <link rel="stylesheet" type="text/css" href="/Content/style2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
    <h1><%: Title %></h1>
</hgroup>
    <br />

    <p>
        <div class="question">1. Можно ли добавлять новые (только что зарегистрированные) аккаунты в систему?</div>
        <br />
        <div class="answer">- Да. Можно. Для аккаунтов, у которых после регистрации не прошло еще 2 недели, задания выдаются не чаще одного раза в час. Это сделано для избежания блокировки новых акков.</div>
    </p>
    <p>
        <div class="question">2. Не хочу чтобы мой аккаунт репостил себе на стену все подряд. Что делать?</div>
        <br />
        <div class="answer">- Заработок -> Аккаунт -> Оставляете только те действия, которые будет выполнять ваш аккаунт.</div>
    </p>
    <p>
        <div class="question">3. Сколько зарабатывает аккаунт в день?</div>
        <br />
        <div class="answer">
            - Акк, приносит Вам, как хозяину - 70% прибыли от выполненных заданий. 10% уходит на рефереральный заработок, 10% на вывод средств, 10% прибыль площадки.
        </div>
    </p>
    <p>
        <div class="question">4. Как часто выдаются задания аккаунтам?</div>
        <br />
        <div class="answer">- Аккаунтам, зарегистрированным Вконтакте меньше 2х недель, задания выдаются не чаще 1 раза в час. Аккам с регистрацией больше 2х недель задания выдаются каждые 10-20 секунд.</div>
    </p>
    <p>
        <div class="question">5. Сколько я получаю от рефералов?</div>
        <br />
        <div class="answer">
            - У нас трёхуровневая система рефералов. Когда ваш реферал делает заказ или зарабатывает деньги - вы получаете от этой суммы доход.
            <br />
            для I уровня - <%=DataHelper.ReferralPercentFirstLevel %>%
            <br />
            для II уровня - <%=DataHelper.ReferralPercentSecondLevel %>%
            <br />
            для III уровня - <%=DataHelper.ReferralPercentThirdLevel %>%
            <br />Доход от рефералов начисляется раз в сутки.
        </div>
    </p>
    <p>
        <div class="question">6. Если аккаунт заблокирован в SmmZilla, как его разблокировать?</div>
        <br />
        <div class="answer">- Заходите в аккаунт, обновляете пароль, если это нужно, сохраняете. Блокировка сбрасывается. Или нажимаете кнопку "Снять блокировку со всех аккаунтов в системе".</div>
    </p>
    <p>
        <div class="question">7. Не получается войти в клиент, пишет ошибка авторизации.</div>
        <br />
        <div class="answer">- В клиент нужно входить под своей учетной записью на сайте, а не под аккаунтом контакта.</div>
    </p>
    <p>
        <div class="question">8. Сколько можно загрузить аккаунтов?</div>
        <br />
        <div class="answer">- Любое количество. Проверено больше 10 тысяч.</div>
    </p>
    <p>
        <div class="question">9. Как узнать средний доход аккаунта в сутки?</div>
        <br />
        <div class="answer">- Навести мышкой на значение общего дохода аккаунта.</div>
    </p>
    <p>
        <div class="question">10. Как узнать какой аккаунт больше приносит дохода?</div>
        <br />
        <div class="answer">- На странице Заработок в таблице с аккаунтами работает сортировка по всем полям.</div>
    </p>
    <p>
        <div class="question">11. Если в клиенте все аккаунты блокируются? Сбросил блокировку - и опять все заблокировались?</div>
        <br />
        <div class="answer">
            - Значит один из ваших купленных аккаунтов "плохой" и при логине после него всегда будет требоваться капча на данном ip. Ищем в логе клиента первый заблокированный аккаунт. 
            <br />
            Удаляем его из системы. Меняем свой ip (обычно просто перезагрузка роутера помогает). Сбрасываем блокировку для всех пользователей.
        </div>
    </p>
    <p>
        <div class="question">12. Какой минимум на вывод?</div>
        <br />
        <div class="answer">- Минимальная сумма на вывод - 1 рубль.</div>
    </p>
    <p>
        <div class="question">13. Что если добавить один аккаунт несколько раз?</div>
        <br />
        <div class="answer">- Если один аккаунт добавить дважды например используя почту и телефон, при выполнении задания второй будет удален.</div>
    </p>
    <p>
        <div class="question">14. Как работает чекер аккаунтов?</div>
        <br />
        <div class="answer">- В правом нижнем углу есть галочка - нажимаете и выбираете чекер.</div>
    </p>
</asp:Content>

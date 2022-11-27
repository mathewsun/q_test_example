<%@ Page Title="Solo Systems" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Solo._Default" EnableEventValidation="false" %>

<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <!-- Load Roboto font -->
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,700&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
    <!-- Load css styles -->
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap-responsive.css" />
    <link rel="stylesheet" type="text/css" href="Content/style.css?222221121" />
    <link rel="stylesheet" type="text/css" href="Content/pluton.css" />
    <!--[if IE 7]>
            <link rel="stylesheet" type="text/css" href="css/pluton-ie7.css" />
        <![endif]-->
    <link rel="stylesheet" type="text/css" href="Content/jquery.cslider.css" />
    <link rel="stylesheet" type="text/css" href="Content/jquery.bxslider.css" />
    <link rel="stylesheet" type="text/css" href="Content/animate.css" />
    <!-- Fav and touch icons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/apple-touch-icon-72.png">
    <link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57.png">
    <link rel="shortcut icon" href="images/favicon.ico">

</head>

<body>
    <form id="Form1" runat="server">
        <div class="navbar">
            <div class="navbar-inner">
                <div class="container">
                   
                    <!-- Navigation button, visible on small resolution -->
                    <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                        <i class="icon-menu"></i>
                    </button>
                    <!-- Main navigation -->
                    <div class="nav-collapse collapse pull-right">
                        <ul class="nav" id="top-navigation">
                            <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled">
                                <AnonymousTemplate>
                                    <li><a id="loginLink" runat="server" href="~/Account/Login.aspx">Вход</a></li>
                                    <li><a id="registerLink" runat="server" href="~/Account/Register.aspx">Регистрация</a></li>
                                </AnonymousTemplate>
                                <LoggedInTemplate>
                                    <li><a href="/Account/CashIn.aspx">Зачисление</a></li>
                                    
                                    <li><a id="CabinetLink" runat="server" class="username" href="~/Account/Cabinet.aspx" title="Личный кабинет">Кабинет (<asp:LoginName ID="LoginName1" runat="server" CssClass="username" />
                                        )
                                    </a></li>
                                    <li>
                                        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" OnLoggedOut="LoginStatus1_LoggedOut" LogoutText="Выйти" LogoutPageUrl="~/" />
                                    </li>
                                </LoggedInTemplate>
                            </asp:LoginView>
                        </ul>
                    </div>
                    <!-- End main navigation -->
                </div>
            </div>
        </div>
        <!-- Start home section -->
        
        <!-- End home section -->
        <!-- Service section start -->
        
        <!-- Service section end -->
        <!-- Client section start -->
        
        <!-- Newsletter section start -->
        
        <!-- Newsletter section end -->
        <!-- Contact section start -->
        
        <!-- Contact section edn -->
        <!-- ScrollUp button start -->
        
        <!-- ScrollUp button end -->
        <!-- Include javascript -->
        <script src="Scripts/jquery.js"></script>
        <script type="text/javascript" src="Scripts/jquery.mixitup.js"></script>
        <script type="text/javascript" src="Scripts/bootstrap.js"></script>
        <script type="text/javascript" src="Scripts/modernizr.custom.js"></script>
        <script type="text/javascript" src="Scripts/jquery.bxslider.js"></script>
        <script type="text/javascript" src="Scripts/jquery.cslider.js"></script>
        <script type="text/javascript" src="Scripts/jquery.placeholder.js"></script>
        <script type="text/javascript" src="Scripts/jquery.inview.js"></script>
        <!-- Load google maps api and call initializeMap function defined in app.js -->
        <!-- css3-mediaqueries.js for IE8 or older -->
        <!--[if lt IE 9]>
            <script src="Scripts/respond.min.js"></script>
        <![endif]-->
        <script type="text/javascript" src="Scripts/app.js"></script>
        <script src="/Scripts/helper.js"></script>
        
    </form>
    
</body>
</html>

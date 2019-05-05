<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" %>

<!DOCTYPE html>
<html style="overflow: hidden;">
<head>
    <title>某平台管理平台</title>
    <link href="/Content/css/framework-font.css" rel="stylesheet" />
    <script src="/Content/js/jquery/jquery-2.1.1.min.js"></script>
    <script src="/Content/js/bootstrap/bootstrap.js"></script>
    <link href="/Content/js/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="/Content/js/dialog/dialog.js"></script>
    <script src="/Content/js/cookie/jquery.cookie.js"></script>
    <link href="/Content/css/framework-theme.css" rel="stylesheet" />
    <script src="/Content/js/framework-ui.js"></script>
    <script src="/Content/js/framework-clientdata.js"></script>
</head>
<body style="overflow: hidden;">
    <div id="ajax-loader" style="cursor: progress; position: fixed; top: -50%; left: -50%; width: 200%; height: 200%; background: #fff; z-index: 10000; overflow: hidden;">
        <img src="/Content/img/ajax-loader.gif" style="position: absolute; top: 0; left: 0; right: 0; bottom: 0; margin: auto;" />
    </div>
    <div id="theme-wrapper">
        <header class="navbar" id="header-navbar">
            <div class="container" style="padding-right: 0px;">
                <a href="#" id="logo" class="navbar-brand">某平台管理平台</a>
                <div class="clearfix">
                    <div class="nav-no-collapse navbar-left pull-left hidden-sm hidden-xs">
                        <ul class="nav navbar-nav pull-left">
                            <li>
                                <a class="btn" id="make-small-nav"><i class="fa fa-bars"></i></a>
                            </li>
                        </ul>
                    </div>
                    <div class="nav-no-collapse pull-right" id="header-nav">
                        <ul class="nav navbar-nav pull-right">
                           
                            <li class="dropdown profile-dropdown">
                                <a href="#" class="dropdown" data-toggle="dropdown">
                                    <img src="/Content/img/samples/scarlet-159.png" alt="" />
                                    <span class="hidden-xs"><%= nickName %></span>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li><a class="menuItem" data-id="userInfo" href="systemmanage/updatepwd.aspx"><i class="fa fa-user"></i>修改资料</a></li>
                                    <li class="divider"></li>
                                    <li><a href="loginout.aspx"><i class="ace-icon fa fa-power-off"></i>安全退出</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </header>
        <div id="page-wrapper" class="container">
            <div class="row">
                <div id="nav-col">
                    <section id="col-left" class="col-left-nano">
                        <div id="col-left-inner" class="col-left-nano-content" style="padding-top:20px;">
                            <div class="collapse navbar-collapse navbar-ex1-collapse" id="sidebar-nav">



                                <ul class="nav nav-pills nav-stacked">
                                    <li><a href="#" class="dropdown-toggle"><i class="fa fa-gears"></i><span>基础设置</span><i class="fa fa-angle-right drop-icon"></i></a>
                                        <ul class="submenu">
                                        <li><a class="menuItem"  href="SystemManage/website.aspx">站点设置</a></li>
                                        <li><a class="menuItem"  href="SystemManage/wechatsite.aspx">公众号设置</a></li>
                                        <li><a class="menuItem"  href="SystemManage/bankinfo.aspx">收款信息</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#" class="dropdown-toggle"><i class="fa fa-desktop"></i><span>粉丝管理</span><i class="fa fa-angle-right drop-icon"></i></a>
                                        <ul class="submenu">
                                        <li><a class="menuItem"  href="user/list.aspx">粉丝信息</a></li>
                                        <li><a class="menuItem"  href="user/userstatistics.aspx">粉丝统计</a></li>
                                        <li><a class="menuItem"  href="user/rechargelist.aspx">充值记录</a></li>
                                    </ul>
                                    </li>
                                    <li><a  href="#" class="dropdown-toggle"><i class="fa fa-bar-chart-o"></i><span>推广管理</span><i class="fa fa-angle-right drop-icon"></i></a>
                                        <ul class="submenu">
                                        <li><a class="menuItem"  href="channel/list.aspx" >渠道管理</a></li>
                                        <li><a class="menuItem"  href="spreadlink/walist.aspx" >提取链接</a></li>
                                        <li><a class="menuItem"  href="channel/tjlist.aspx" >渠道统计</a></li>
                                    </ul>
                                    </li>
                                   
                                    <li class="nav-header hidden-sm hidden-xs">快捷操作
                                        <i class="fa fa-gear" style="color: #868b98; font-size: 12px; margin-top: -6px; position: absolute; right: 23px; top: 50%; cursor: pointer;"></i>
                                    </li>
                                    <li class="common">
                                        <a class="menuItem" href="channel/list.aspx">
                                            <i class="fa fa-star-o"></i>
                                            <span>渠道管理</span>
                                        </a>
                                    </li>
                                    <li class="common">
                                       <a class="menuItem" href="spreadlink/walist.aspx">
                                            <i class="fa fa-star-o"></i>
                                            <span>提取链接</span>
                                        </a>
                                    </li>
                                    <li class="common">
                                       <a class="menuItem" href="finance/settlement.aspx">
                                            <i class="fa fa-star-o"></i>
                                            <span>结算单</span>
                                        </a>
                                    </li>
                                    <li class="common">
                                       <a class="menuItem"  href="finance/advertiserdaytj.aspx">
                                            <i class="fa fa-star-o"></i>
                                            <span>每日统计</span>
                                        </a>
                                    </li>
                                </ul>



                            </div>
                        </div>
                    </section>
                </div>
                <div id="content-wrapper">
                    <div class="content-tabs">
                        <button class="roll-nav roll-left tabLeft">
                            <i class="fa fa-backward"></i>
                        </button>
                        <nav class="page-tabs menuTabs">
                            <div class="page-tabs-content" style="margin-left: 0px;">
                                <a href="javascript:;" class="menuTab active" data-id="/Home/Default">欢迎首页</a>
                            </div>
                        </nav>
                        <button class="roll-nav roll-right tabRight">
                            <i class="fa fa-forward" style="margin-left: 3px;"></i>
                        </button>
                        <div class="btn-group roll-nav roll-right">
                            <button class="dropdown tabClose" data-toggle="dropdown">
                                页签操作<i class="fa fa-caret-down" style="padding-left: 3px;"></i>
                            </button>
                            <ul class="dropdown-menu dropdown-menu-right">
                                <li><a class="tabReload" href="javascript:void();">刷新当前</a></li>
                                <li><a class="tabCloseCurrent" href="javascript:void();">关闭当前</a></li>
                                <li><a class="tabCloseAll" href="javascript:void();">全部关闭</a></li>
                                <li><a class="tabCloseOther" href="javascript:void();">除此之外全部关闭</a></li>
                            </ul>
                        </div>
                        <button class="roll-nav roll-right fullscreen"><i class="fa fa-arrows-alt"></i></button>
                    </div>
                    <div class="content-iframe" style="background-color: #f9f9f9; overflow: hidden;">
                        <div class="mainContent" id="content-main" style="margin: 10px; margin-bottom: 0px; padding: 0;">
                            <iframe class="NFine_iframe" width="100%" height="100%" src="welcome.aspx" frameborder="0" data-id="/Home/Default"></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="loadingPage" style="display: none;">
        <div class="loading-shade"></div>
        <div class="loading-content" onclick="$.loading(false)">数据加载中，请稍后…</div>
    </div>
    <script src="/Content/js/index.js"></script>
    <script src="/Content/js/indextab.js"></script>
    <script src="/Content/js/loading/pace.min.js"></script>
</body>
</html>


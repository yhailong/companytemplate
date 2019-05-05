<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>某平台管理平台</title>
    <link href="/Content/css/framework-font.css" rel="stylesheet" />
    <link href="/Content/css/framework-login.css" rel="stylesheet" />
    <script src="/Content/js/jquery/jquery-2.1.1.min.js"></script>
    <script src="/Content/js/cookie/jquery.cookie.js"></script>
    <script src="/Content/js/md5/jquery.md5.js"></script>
    <!--[if lte IE 8]>
        <div id="errorie"><div>您还在使用老掉牙的IE，正常使用系统前请升级您的浏览器到 IE8以上版本 <a target="_blank" href="http://windows.microsoft.com/zh-cn/internet-explorer/ie-8-worldwide-languages">点击升级</a>&nbsp;&nbsp;强烈建议您更改换浏览器：<a href="http://down.tech.sina.com.cn/content/40975.html" target="_blank">谷歌 Chrome</a></div></div>
    <![endif]-->
</head>
<body>
    <div style="position: absolute; z-index: 999; top: 20px; left: 20px; color: #fff; font-size: 13px; line-height: 22px;">
    </div>
    <div class="wrapper">
        <div class="container">
            <div class="logo">
                <i class="fa fa-modx"></i>
                <h1><span>某平台</span>管理平台</h1>
            </div>
            <form class="form" runat="server" id="form1">
                <div class="row">
                    <asp:TextBox id="TxtUName" type="text" placeholder="登录账户" runat="server" />
                </div>
                <div class="row">
                    <asp:TextBox id="TxtUPass" type="password" placeholder="登录密码" runat="server"/>
                </div>
                <div class="row">
                    <asp:TextBox id="Txtcheckcode" maxlength="4" type="text" placeholder="验证码" style="width: 190px; float: left;" runat="server" />
                        <img id="imgcode" class="authcode" src="checkcode.aspx" width="80" height="25" />
                    </div>
                <div class="row">
                    <asp:Button ID="Button1" Text="登录" runat="server" class="button" OnClick="Button1_Click"/>
                </div>
                <div class="row">
                    <asp:Label ID="LabErr" runat="server"></asp:Label>
                </div>
            </form>
        </div>
        <ul class="bg-bubbles">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>
    <div class="copyright">
        <br>
        适用浏览器：IE8以上、360、FireFox、Chrome、Safari、Opera、傲游、搜狗、世界之窗.
    </div>
    <script type="text/javascript">
        (function ($) {
            $(function () {
                $('.wrapper').height($(window).height());
                $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
                $(window).resize(function (e) {
                    $('.wrapper').height($(window).height());
                    $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
                });
            });
        })(jQuery);
    </script>
</body>
</html>
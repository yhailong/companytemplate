<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title><%=webName %>后台管理</title>
    <link rel="stylesheet" type="text/css" href="../themes/default/easyui.css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../jquery.easyui.min.js"></script>
    <script src="../javascript/YT.js" type="text/javascript"></script>
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .logo{font-size:12px;color:#0e2d5f;font-weight:bold;padding-left:20px;}
    #loginOther{text-align:left;}
    #loginOther a{margin-left:10px;margin-right:5px;}
    </style>
</head>
<body class="easyui-layout">

    <div region="north" border="false" style="height: 25px;background-color:#e6f0ff;">
        <table cellpadding="0" cellspacing="0" class="aTable">
            <tr>
                <td width="200">
                   <div class="logo"><a href="welcome.aspx" target="sysMain"  onclick="showTitle('主窗口');"><%=webName %>后台管理系统</a></div>
                </td>
                <td><div id="loginOther"><asp:Literal ID="LtlPlatForm" runat="server"></asp:Literal></div></td>
                <td></td>
                <td align="right">
                  当前登用户：<asp:Literal ID="LtlCurrentUser" runat="server"></asp:Literal> | <a href="userinfo.aspx" target="sysMain"  onclick="showTitle('个人信息维护');">个人信息修改</a> | <a href="logout.aspx">退出系统</a>
                </td>
            </tr>
        </table>
    </div>
    <div region="west" split="true"  style="width: 150px;">
        <div class="easyui-accordion" fit="true" border="false">
            <asp:Literal ID="LtlNav" runat="server"></asp:Literal>
        </div>
    </div>
    
    <div region="center" id="sysMainTitle" title="主窗口">
        <iframe frameborder="0" id="sysMain" name="sysMain" scrolling="auto" src="welcome.aspx"
            style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
    </div>
    
</body>
</html>
<script language="javascript" type="text/javascript">
    function showTitle(str) {
        $("#sysMainTitle").panel("setTitle", str);
    }
</script>
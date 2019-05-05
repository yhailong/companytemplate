<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type="text/javascript" src="../jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../jquery.easyui.min.js"></script>
    <script src="../javascript/YT.js" type="text/javascript"></script>
    <link type="text/css" href="./css/admin.css" rel="stylesheet" />
   
</head>
<body class="login_bg">
<div id="Div1">
 <form id="form1" runat="server">
	<div class="login_log">
		<table width="250" cellspacing="0" cellpadding="0" border="0" class="tab">
			<thead>
				<tr>
					<td colspan="2"><a href="/" target="_blank"><img src="./images/admin/logo.png" alt="" /></a></td>
				</tr>
			
			</thead>
			<tbody>
				<tr>
					<td colspan="2"><asp:TextBox ID="TxtUName" runat="server" onblur="if(this.value==''){this.value='用户名'}" onclick="this.value=''" value="用户名" >
                                        </asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2"><asp:TextBox ID="TxtUPass" runat="server" TextMode="Password" onblur="if(this.value==''){this.value='请输入密码'}" onclick="this.value=''" value="请输入密码" >
                                        </asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:TextBox ID="Txtcheckcode" runat="server"></asp:TextBox></td>
					<td><img align="absmiddle" src="checkcode.aspx" class="Txtcode"/></td>
				</tr>
				<tr>
					<td colspan="2"><asp:Button ID="btnLogin" runat="server" Text="" 
                                                OnClientClick="return checklogin();"
                                                onclick="btnLogin_Click" /></td>
				</tr>
				<tr>
					<td align="center" height="30" colspan="2"><asp:Label ID="LabErr" runat="server"></asp:Label></td>
				</tr>
			</tbody>
		</table>
	</div>
    </form>
</div>
</body>
</html>
<script type="text/javascript" language="javascript">
    function checklogin() {
        var uname = document.getElementById("<%=TxtUName.ClientID %>").value;
        var upass = document.getElementById("<%=TxtUPass.ClientID %>").value;
        var lcode = document.getElementById("<%=Txtcheckcode.ClientID %>").value;
        var mess = "";
        if (uname == "" || uname == null) {
             $.messager.alert('提示','请输入用户名！');   
            return false;
        }
        else if (upass==""||upass==null) {
            $.messager.alert('提示', '请输密码！');   
            return false;
        }
        else if (lcode == "" || lcode==null)
        {
            $.messager.alert('提示', '请输入验证码！');   
            return false;
        }

    }
</script>
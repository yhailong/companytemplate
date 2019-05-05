<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userinfo.aspx.cs" Inherits="syscc_userinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="../themes/default/easyui.css" />
    <script type="text/javascript" src="../jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../locale/easyui-lang-zh_CN.js"></script>
    <script src="../javascript/YT.js" type="text/javascript"></script>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="easyui-panel" fit="true">
    <form runat="server" id="form1" onsubmit='return $(this).form("validate");'>
    
        <div class="topnote">
            标<span class="notes">*</span>为必填项。 &nbsp;
        </div>
        <table class="tableContent" cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    登录名：
                </th>
                <td>
                    <asp:Label ID="LabUName" runat="server"></asp:Label>
                </td>
                 
                
            </tr>
            <tr><th>
                    所属部门：
                </th>
                <td>
                    <asp:Label ID="LabDepartment" runat="server"></asp:Label>
                </td></tr>
            <tr>
            <th>
                    登录密码：
                </th>
                <td>
                    <asp:TextBox ID="TxtUPass" runat="server" class="easyui-validatebox input w100"  validType="isPassWord" TextMode="Password"></asp:TextBox>（5-15位字母数字下滑线组成）
                </td>
                
               

            </tr>
            <tr>
            <th>
                    重复密码：
                </th>
                <td>
                    <asp:TextBox ID="TxtUPass1" runat="server" class="easyui-validatebox input w100"  validType="equalTo['#TxtUPass']" TextMode="Password" invalidMessage="两次输入密码不匹配"></asp:TextBox>
                </td>
                
               

            </tr>
            <tr><th>
                    <span class="notes">*</span>真实姓名：
                </th>
                <td>
                    <asp:TextBox ID="TxtTrueName" runat="server"  class="easyui-validatebox input w100" data-options="required:true"></asp:TextBox>
                </td></tr>
         
            <tr>
                <th valign="top">
                    联系方式：
                </th>
                <td>
                    <asp:TextBox ID="TxtContact" runat="server" class="easyui-validatebox input w300" data-options="required:true"></asp:TextBox>
                </td>
                
            </tr>
            
           <tr>
                <th>
                    状态：
                </th>
                <td>
                    <asp:Label ID="LabStatus" runat="server" ></asp:Label>
                </td>
                
            </tr>
            <tr><th>
                  所属权限组：
                </th>
                <td>
                 <asp:Label ID="LabGroupId" runat="server"></asp:Label>
                </td></tr>
            <tr>
                <th>
                    创建时间：
                </th>
                <td>
                    <asp:Label ID="LabCreateDate" runat="server"></asp:Label>
                </td>
                
            </tr>
            <tr><th>
                    最后修改时间：
                </th>
                <td>
                    <asp:Label ID="LabLastDate" runat="server"></asp:Label>
                </td></tr>
            <tr>
                <td>
                </td>
                <td  class="tdp">
                    <asp:Button CssClass="btn" Text="修改" ID="BtnSave" runat="server" OnClick="BtnSave_Click" />
                    
                </td>
            </tr>
        </table>
    
    <asp:HiddenField ID="HidLd" runat="server" Value="0" />
    </form></div>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admuseradd.aspx.cs" Inherits="admin_sysmanager_admuseradd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc:meta ID="meta" runat="server"/>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .bclass {
        width:100px;float:left;border-bottom-width:0px;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1" onsubmit='return $(this).form("validate");'>
   
        <div class="topnote">
            标<span class="notes">*</span>为必填项。 &nbsp;
        </div>
        <table class="tableContent" cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    <span class="notes">*</span>登录名：
                </th>
                <td>
                    <asp:TextBox ID="TxtUName" runat="server" class="easyui-validatebox input" data-options="required:true" ></asp:TextBox>
                </td>
                <th>
                    登录密码：
                </th>
                <td>
                    <asp:TextBox ID="TxtUPass" runat="server" CssClass="easyui-validatebox input"  TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="notes">*</span>真实姓名：
                </th>
                <td>
                    <asp:TextBox ID="TxtTrueName" runat="server"   class="easyui-validatebox input" data-options="required:true"></asp:TextBox>
                </td>
                <th>
                    重复密码：
                </th>
                <td>
                    <asp:TextBox ID="TxtUPass1" runat="server" CssClass="easyui-validatebox input" Text="" TextMode="Password" validType="isConfirmPassword($('#TxtUPass'))"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th valign="top">
                    联系方式：
                </th>
                <td colspan="3">
                    <asp:TextBox ID="TxtContact" runat="server" class="easyui-validatebox input" data-options="required:true" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                </td>
                
            </tr>
            
           <tr>
                <th>
                    状态：
                </th>
                <td>
                    <asp:RadioButtonList ID="RblStatus" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </td>
               <th>
                    职务：
                </th>
                <td>
                   <asp:RadioButtonList ID="RblUPost" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <th>
                   
                </th>
                <td>
                    
                </td>
               <th>
                    职务性别：
                </th>
                <td>
                   <asp:RadioButtonList ID="RblUPostSex" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </td>
            </tr>
            <tr> 
                 <th valign="top">
                  所属权限组：
                </th>
                <td colspan="3">
                        <asp:Literal ID="LtlGroupIdList" runat="server"></asp:Literal>
                </td>
         
            </tr>
             <tr> 
                 <th valign="top">
                  可用平台：
                </th>
                <td colspan="3">
                        <asp:Literal ID="LtlPlatForm" runat="server"></asp:Literal>
                </td>
         
            </tr>
            <tr>
                <th>
                    创建时间：
                </th>
                <td>
                    <asp:Label ID="LabCreateDate" runat="server"></asp:Label>
                    
                </td>
                <th>
                    最后修改时间：
                </th>
                <td>
                    <asp:Label ID="LabLastDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3" class="tdp">
                    <asp:Button CssClass="btn" Text="添加" ID="BtnSave" runat="server" OnClick="BtnSave_Click" />
                    
                </td>
            </tr>
            <tr><th></th><td colspan="3" class="notes">
            1、职务；<br />
            2、权限组支持多选，用户的总权限为所选权限组的权限之和（第一个超级管理员为超级权限）；
            </td></tr>
        </table>
    
    <asp:HiddenField ID="HidLd" runat="server" Value="0" />
    </form>
</body>
</html>
   <script type="text/javascript">

    </script>  


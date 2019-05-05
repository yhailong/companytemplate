<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admmoduleadd.aspx.cs" Inherits="admin_sysmanager_admmoduleadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <uc:meta ID="meta" runat="server"/>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server" id="form1" onsubmit='return $(this).form("validate");'>
        <div class="topnote">
            标<span class="notes">*</span>为必填项。 &nbsp;
        </div>
        <table class="tableContent" cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    <span class="notes">*</span>模块名称：
                </th>
                <td>
                    <asp:TextBox ID="TxtName" runat="server" CssClass="easyui-validatebox input" data-options="required:true"></asp:TextBox>
                </td>
                <th>
                    <span class="notes">*</span>模块地址：
                </th>
                <td>
                    <asp:TextBox ID="TxtUrl" runat="server" CssClass="easyui-validatebox input" data-options="required:true" Text="javascript:void(0);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="notes">*</span>模块标题：
                </th>
                <td colspan="3">
                   <asp:TextBox ID="TxtTitle" runat="server" CssClass="easyui-validatebox input w300" data-options="required:true"></asp:TextBox>(默认和名称一样)
                </td>
                
            </tr>
            <tr>
                <th>
                    <span class="notes">*</span>权限编号：
                </th>
                <td>
                    <asp:TextBox ID="TxtKeyCode" runat="server" CssClass="easyui-validatebox input w50" data-options="required:true"></asp:TextBox>
                </td>
                <th>
                    对应图标：
                </th>
                <td>
                    <asp:TextBox ID="TxtIcon" runat="server" CssClass="input" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <span class="notes">*</span>父模块编号：
                </th>
                <td>
                    <asp:TextBox ID="TxtParentId" runat="server" CssClass="easyui-validatebox input w50" data-options="required:true" Text="0"></asp:TextBox>
                </td>
                <th>
                    <span class="notes">*</span>排序：
                </th>
                <td>
                    <asp:TextBox ID="TxtRank" runat="server" CssClass="easyui-validatebox input w50" data-options="required:true" Text="0"></asp:TextBox>
                </td>
            </tr>
              <tr style="display:none;">
                <th>
                    <span class="notes">*</span>是否左侧显示：
                </th>
                <td colspan="3">
                   <asp:RadioButtonList ID="RblIsSysMenu" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </td>
                
            </tr>
           <tr>
                <th>
                    <span class="notes">*</span>状态：
                </th>
                <td>
                    <asp:RadioButtonList ID="RblStatus" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </td>
                <th>
                    创建时间：
                </th>
                <td>
                    <asp:Label ID="LabCreateDate" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td>
                </td>
                <td colspan="3" class="tdp">
                    <asp:Button CssClass="btn" Text="添加" ID="BtnSave" runat="server" OnClick="BtnSave_Click" />
                    
                </td>
            </tr>
        </table>
    <asp:HiddenField ID="HidLd" runat="server" Value="0" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admusergroupadd.aspx.cs" Inherits="admin_sysmanager_admusergroupadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <span class="notes">*</span>组编号：
                </th>
                <td>
                    <asp:TextBox ID="TxtGroupId" runat="server" CssClass="easyui-validatebox input" data-options="required:true"></asp:TextBox>
                </td>
                <th>
                    <span class="notes">*</span>组名称：
                </th>
                <td>
                    <asp:TextBox ID="TxtName" runat="server" CssClass="easyui-validatebox input" data-options="required:true"></asp:TextBox>
                </td>
            </tr>
            <tr>
          <th valign="top">
                    权限编号：
                </th>
                <td colspan="3">
                    <asp:Literal ID="LtlKeyCode" runat="server"></asp:Literal>
                </td>
            </tr>
             <tr>
          
           <tr>
                <th>
                    创建时间：
                </th>
                <td><asp:Label ID="LabCreateDate" runat="server"></asp:Label>
                   
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
        </table>
   
    <asp:HiddenField ID="HidLd" runat="server" Value="0" />
    </form>
</body>
</html>


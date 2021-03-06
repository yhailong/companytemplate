﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsadd.aspx.cs" Inherits="admin_news_newsadd" %>

<!DOCTYPE html>

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
                    <span class="notes">*</span>新闻类别：
                </th>
                <td>
                    <asp:DropDownList ID="DdlNewsClass" runat="server"></asp:DropDownList>
                </td>
                
            </tr><tr>
                <th>
                    <span class="notes">*</span>新闻标题：
                </th>
                <td>
                    <asp:TextBox ID="TxtTitle" runat="server" CssClass="easyui-validatebox input w300" data-options="required:true"></asp:TextBox>
                </td>
                
            </tr>
             <tr>
                <th>
                    <span class="notes">*</span>作者：
                </th>
                <td>
                    <asp:TextBox ID="TxtAuthor" runat="server" CssClass="easyui-validatebox input" data-options="required:true"></asp:TextBox>
                </td>
                
            </tr>
             <tr>
                <th>
                    <span class="notes">*</span>新闻内容：
                </th>
                <td>
                    <asp:TextBox ID="TxtContent" runat="server" CssClass="easyui-validatebox input" data-options="required:true" TextMode="MultiLine" Height="200px"></asp:TextBox>
                </td>
                
            </tr>
            
           <tr>
                <th>
                    <span class="notes">*</span>状态：
                </th>
                <td>
                    <asp:RadioButtonList ID="RblState" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </td>
                
            </tr>
            <tr>
                <th>
                    最后修改：
                </th>
                <td>
                    <asp:Label ID="LabLastDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
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
                <td  class="tdp">
                    <asp:Button CssClass="btn" Text="添加" ID="BtnSave" runat="server" OnClick="BtnSave_Click" />
                    
                </td>
            </tr>
        </table>
    <asp:HiddenField ID="HidLd" runat="server" Value="0" />
    </form>
</body>
</html>


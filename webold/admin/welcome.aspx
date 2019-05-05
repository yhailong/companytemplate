<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="adm_welcome" %>
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
   
        <table class="tableContent" cellpadding="0" cellspacing="0" style="border:solid 1px #e6f0ff; width:500px;margin:auto;margin-top:100px;line-height:30px;">
            <asp:Repeater ID="rep" runat="server">
                <ItemTemplate>
            <tr>
            <th>
            <%# DataBinder.Eval(Container.DataItem, "PId")%>：
            </th>
            <td>
           昨日分成<span class="red"><%# DataBinder.Eval(Container.DataItem, "TotalTrueInCome")%></span>书币
            </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
  
</body>
</html>


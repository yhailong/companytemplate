<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdmHistory.aspx.cs" Inherits="admin_sysmanager_AdmHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../../jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../locale/easyui-lang-zh_CN.js"></script>
    <script src="../../javascript/YT.js" type="text/javascript"></script>
</head>
<body>
    <div class="easyui-panel" fit="true">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="border-bottom: 1px solid #ddd; height: 40px; padding: 2px 5px; background: #fafafa;">
                <div style="float: left;">
                    <form id="Form1" runat="server">
                        <table>
                            <tr>
                                <td>时间 从:
                                <asp:TextBox ID="TxtStart" runat="server" CssClass="easyui-datebox inpMain w100"></asp:TextBox>
                                </td>
                                 <td>到:
                                <asp:TextBox ID="TxtEnd" runat="server" CssClass="easyui-datebox inpMain w100"></asp:TextBox>
                                </td>
                                <td>类别：<asp:DropDownList ID="DdlActClass" runat="server">
                                </asp:DropDownList>
                                </td>
                                <td>
                                    数据Id：<asp:TextBox ID="TxtDataId" runat="server"></asp:TextBox></td>
                                <td>
                                    <a href="#" type="button" id="btn-save" class="easyui-linkbutton" plain="true" onclick="CreateGrid()"
                                        icon="icon-search">查询</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
            <div region="center" border="false" class="tabdatalist">
                <table id="tt">
                </table>
            </div>
        </div>
    </div>
</body>
</html>
<script language="javascript" type="text/javascript">
    function CreateGrid() {
        var Start = $("#TxtStart").datebox('getValue');
        var ActClass = $("#DdlActClass").val();
        var End = $("#TxtEnd").datebox('getValue');
 
            $('#tt').datagrid({
                url: '../../api/adm/acthistory.aspx?act=get&start=' + Start + '&actClass=' + ActClass + '&end=' + End + '&dataLd=' + escape($("#TxtDataId").val()),
                singleSelect: true,
                fit: true,
                fitColumns: true,
                columns: [[
                { field: 'Ld', title: '序号', width: 50, align: 'center' },
        { field: 'ActClass', title: '操作类型', width: 100, align: 'center', formatter: function (value, rec, index) { return YT.Dirt.GetName("EnumAdmActClass", rec.ActClass); } },
        { field: 'DataId', title: '操作数据编号', width: 100, align: 'center' },
        { field: 'AdmUId', title: '责编', width: 100, align: 'center' },
        { field: 'Remark', title: '其他备注', width: 100, align: 'center' },
        {
            field: 'CreateDate', title: '时间', width: 170, align: 'center',
            formatter: function (value, rec, index)
            {
                return YT.Fun.formatDate(rec.CreateDate);
            }
        }
                ]],
                pagination: true,
                rownumbers: true,
                pageNumber: 1,
                pageSize: 20
            });
        }

    function CreateGridReload() {
        $('#tt').datagrid('reload');
    }

    $(function () {
        CreateGrid();
    });
</script>

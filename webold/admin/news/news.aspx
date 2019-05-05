<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="admin_news_news" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <uc:meta ID="meta" runat="server"/>
</head>
    <body>
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="border-bottom: 1px solid #ddd; height: 32px;
                padding: 2px 5px; background: #fafafa;">
                <div style="float: left;"> 
                    <form id="Form1" runat="server">
                        <table>
                            <tr>
                                <td>类别:
                                <asp:DropDownList ID="DdlClass" runat="server"></asp:DropDownList>
                                </td>
                                
                                <td>
                                    <a href="#" type="button" id="btn-save" class="easyui-linkbutton" plain="true" onclick="CreateGrid()"
                                        icon="icon-search">查询</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
                <div style="float: right;">
                    <a href="#" class="easyui-linkbutton" plain="true" icon="icon-add" onclick="javascript:YT.Fun.NewPanel('newsadd.aspx','新增新闻',800,500);">
                        新增</a>
                </div>
            </div>
            <div region="center" border="false" class="tabdatalist">
                <table id="tt">
                </table>
            </div>
        </div>
</body>
</html>
<script language="javascript" type="text/javascript">
    function CreateGrid() {
        $('#tt').datagrid({
            url: '../../api/adm/news.aspx?act=get&classid='+$("#DdlClass").val(),
            singleSelect: true,
            fit: true,
            fitColumns: true,
            columns: [[
    { field: 'Ld', title: '编号', width: 50 },
    { field: 'Title', title: '标题', width: 400 },
    { field: 'Author', title: '作者', width: 100 },
    { field: 'State', title: '状态', width: 100, formatter: function (value, rec, index) { return YT.Dirt.GetName("AvailablesStatus", rec.State); } },
    { field: 'CreateDate', title: '创建时间', width: 100, formatter: function (value, rec, index) { return YT.Fun.formatDate(rec.CreateDate); } },
    { field: 'LastDate', title: '最后修改', width: 100, formatter: function (value, rec, index) { return YT.Fun.formatDate(rec.LastDate); } },
    { field: 'opt', title: '操作', width: 100, align: 'center',
        formatter: function (value, rec, index) {
            var a = '<a href="#" mce_href="#" onclick="YT.Fun.NewPanel(\'newsadd.aspx?id=' + rec.Ld + '\',\'编辑模块\',800,500);" class="lista">编辑</a>';
            var d = '|<a href="#" mce_href="#" onclick="DelItem(\'' + rec.Ld + '\');" class="lista">删除</a>';
            return a+ d;
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

    function DelItem(idList) {
        if (confirm('确定要删除该信息吗？')) {
            $.post("../../api/adm/news.aspx", { ids: idList, act: "del" }, function (data, textStatus) {
                if (data == "") {
                    CreateGrid();
                }
                else
                {
                    alert("发生错误，请稍后再试！");
                }
            }, "html");
        }
    }
    CreateGrid();
 
</script>

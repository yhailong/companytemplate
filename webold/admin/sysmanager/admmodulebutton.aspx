<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admmodulebutton.aspx.cs" Inherits="admin_sysmanager_admmodulebutton" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <uc:meta id="meta" runat="server" />
</head>
<body>
    <div class="easyui-panel" fit="true">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="border-bottom: 1px solid #ddd; height: 32px; padding: 2px 5px; background: #fafafa;">
                <div style="float: left;"></div>
                <div style="float: right;">
                    <a href="#" class="easyui-linkbutton" plain="true" icon="icon-add" onclick="javascript:YT.Fun.NewPanel('admmodulebuttonadd.aspx?parentid=<%=parentId %>','新增模块按钮',600,250);">新增</a>
                </div>
            </div>
            <div region="center" border="false">
                <table id="tt">
                </table>
            </div>
        </div>
    </div>
</body>
</html>
<script language="javascript" type="text/javascript">
    function CreateGrid() {
        $('#tt').datagrid({
            url: '../../api/adm/admmodule.aspx?act=get&typeid=2&parentid=<%=parentId %>',
            singleSelect: true,
            fit: true,
            fitColumns: true,
            columns: [[
    { field: 'Ld', title: '编号', width: 50 },
    { field: 'Name', title: '按钮名称', width: 100 },
    { field: 'Url', title: '连接地址', width: 100 },
    { field: 'KeyCode', title: '按钮编号', width: 30 },
    { field: 'Icon', title: '图标', width: 100 },
    { field: 'ParentId', title: '父级栏目', width: 30, formatter: function () { return "<%= parentName %>"; } },
    { field: 'Status', title: '状态', width: 100, formatter: function (value, rec, index) { return YT.Dirt.GetName("AvailablesStatus", rec.Status); } },
    { field: 'Rank', title: '排序', width: 100 },
    { field: 'CreateDate', title: '创建时间', width: 100, formatter: function (value, rec, index) { return YT.Fun.formatDate(rec.CreateDate); } },
    {
        field: 'opt', title: '操作', width: 100, align: 'center',
        formatter: function (value, rec, index) {
            var e = '<a href="#" mce_href="#" onclick="YT.Fun.NewPanel(\'admmodulebuttonadd.aspx?id=' + rec.Ld + '\',\'编辑按钮\',600,250);" class="lista">编辑</a>|';
            var d = '<a href="#" mce_href="#" onclick="DelItem(\'' + rec.Ld + '\');" class="lista">删除</a>';
            return e + d;
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
        $.post("../../api/adm/admmodule.aspx", { ids: idList, act: "del" }, function (data, textStatus) {
            if (data == "") {
                CreateGrid();
            }
            else {
                alert("发生错误，请稍后再试！");
            }
        }, "html");
    }
}
CreateGrid();

</script>

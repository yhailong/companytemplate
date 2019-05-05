<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admuser.aspx.cs" Inherits="admin_sysmanager_admuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <uc:meta id="meta" runat="server" />
</head>
<body>
    <div class="easyui-panel" fit="true">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="border-bottom: 1px solid #ddd; height: 32px; padding: 2px 5px; background: #fafafa;">
                <div style="float: left;">
                    <form runat="server">
                        权限组：<asp:DropDownList ID="DdlRole" runat="server">
                       
                        </asp:DropDownList>
                        <a href="#" type="button" id="btn-save" class="easyui-linkbutton" plain="true" onclick="CreateGrid()"
                            icon="icon-search">查询</a>
                    </form>
                </div>
                <div style="float: right;">
                    <a href="#" class="easyui-linkbutton" plain="true" icon="icon-add" onclick="javascript:YT.Fun.NewPanel('admuseradd.aspx','新增用户',850,550);">新增</a>
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
        var roles = $C("DdlRole").value;

        $('#tt').datagrid({
            url: '../../api/adm/admuser.aspx?act=get&roleid=' + roles,
            singleSelect: true,
            fit: true,
            fitColumns: true,
            columns: [[
            { field: 'Ld', title: '编号', width: 50 },
    { field: 'UName', title: '登录名', width: 100 },
    { field: 'TrueName', title: '真实姓名', width: 100 },
    { field: 'UPost', title: '职务', width: 100, formatter: function (value, rec, index) { return YT.Dirt.GetName("EnumUPostClass", rec.UPost); } },
    { field: 'Contact', title: '联系方式', width: 100 },
    {
        field: 'GroupIdList', title: '所属组', width: 100
    },
    { field: 'LastLoginDate', title: '最后登录', width: 100, formatter: function (value, rec, index) { return YT.Fun.formatDate(rec.LastLoginDate); } },
    { field: 'Status', title: '状态', width: 100, formatter: function (value, rec, index) { return YT.Dirt.GetName("AvailablesStatus", rec.Status); } },
    { field: 'CreateDate', title: '创建时间', width: 100, formatter: function (value, rec, index) { return YT.Fun.formatDate(rec.CreateDate); } },
    {
        field: 'opt', title: '操作', align: 'center',
        formatter: function (value, rec, index) {
            var e = '<a href="#" mce_href="#" onclick="YT.Fun.NewPanel(\'admuseract.aspx?id=' + rec.Ld + '\',\'操作日志\',600,450);" class="lista">操作日志</a>|<a href="#" mce_href="#" onclick="YT.Fun.NewPanel(\'admuserhistory.aspx?id=' + rec.Ld + '\',\'登录日志\',500,450);" class="lista">登录日志</a>|<a href="#" mce_href="#" onclick="YT.Fun.NewPanel(\'admuseradd.aspx?id=' + rec.Ld + '\',\'编辑用户信息\',850,550);" class="lista">编辑</a>|';
            var f = '<a href="#" mce_href="#" onclick="ModifyCheckCode(\'' + rec.Ld + '\');" class="lista">踢出</a>|';
            var d = '<a href="#" mce_href="#" onclick="DelItem(\'' + rec.Ld + '\');" class="lista">删除</a>';
            return e +f+ d;
        }
    }
            ]],
            pagination: true,
            rownumbers: true,
            pageNumber: 1,
            pageSize: 20
            ,
            onLoadSuccess: function (data) {
                if (data.total == 0) {
                    var body = $(this).data().datagrid.dc.body2;
                    body.find('table tbody').append('<tr><td width="' + body.width() + '" style="height: 35px; text-align: center;"><h1>暂无数据</h1></td></tr>');
                }
                else {
                    for (var i = 0; i < data.rows.length; i++) {
                        var u = i;
                        objItemValue = data.rows[i].GroupIdList;
                        var arr = objItemValue.split(',');
                        var GroupName = "";
                        for (var j = 1; j < arr.length - 1; j++) {
                            if (j > 1) {
                                GroupName += ",";
                            }
                            var t = arr[j];
                            GroupName += getGroupName(t);
                        }
                        data.rows[i].GroupIdList = GroupName;
                    }
                    for (var s = 0; s < data.rows.length; s++) {
                        $('#tt').datagrid("refreshRow", s);
                    }
                }
            }
        });
    }

    function getGroupName(id) {
        var objs = "";
    $("#DdlRole option").each(function()
    {
        if($(this).val()==id)
        {
            objs= $(this).text();
        }
    });
    return objs;
    }

    function CreateGridReload() {
        $('#tt').datagrid('reload');
    }

    function DelItem(idList) {
        if (confirm('确定要删除该信息吗？')) {
            $.post("../../api/adm/admuser.aspx", { ids: idList, act: "del" }, function (data, textStatus) {
                if (data == "") {
                    CreateGrid();
                }
                else {
                    alert("发生错误，请稍后再试！");
                }
            }, "html");
        }
    }

    function ModifyCheckCode(idList) {
        if (confirm('确定要将该用户退出登录吗？')) {
            $.post("../../api/adm/admuser.aspx", { ids: idList, act: "modifycheckcode" }, function (data, textStatus) {
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

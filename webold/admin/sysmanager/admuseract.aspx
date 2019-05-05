<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admuseract.aspx.cs" Inherits="admin_sysmanager_admuseract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
 <uc:meta ID="meta" runat="server"/>
</head>
<body>
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="border-bottom: 1px solid #ddd; height: 32px;
                padding: 2px 5px; background: #fafafa;">
                <div style="float: left;">
                <form runat="server">
                <table class="querytable">
                        <tr> 
                            <td>
                                开始日期：<input type="text" id="TxtStartDate" value="" class="easyui-datebox w100" />
                            </td>
                            <td>
                                结束日期：<input type="text" id="TxtEndDate" value="" class="easyui-datebox w100" />
                            </td>
                            <td><asp:DropDownList ID="DdlAct" runat="server"></asp:DropDownList></td>
                            <td>
                                <a href="#" class="easyui-linkbutton" plain="true" onclick="CreateGrid();" icon="icon-search">
                                    查询</a>
                            </td>
                        </tr>
                    </table></form> </div>
                <div style="float: right;">
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
    function CreateGrid(objs) {
        var sTime, eTime;
        if (typeof (objs) == 'undefined') {
            sTime = $("#TxtStartDate").datebox('getValue');
            eTime = $("#TxtEndDate").datebox('getValue');
        }

        $('#tt').datagrid({
            url: '../../api/adm/admuserhistory.aspx?act=getact&id=<%=Id %>&stime=' + sTime + '&etime=' + eTime+'&actclass='+$C("DdlAct").value,
            singleSelect: true,
            fit: true,
            fitColumns: true,
            columns: [[
            { field: 'Ld', title: '编号', width: 50 },
    { field: 'ActId', title: '操作类型', width: 100, formatter: function (value, rec, index) { return YT.Dirt.GetName("EnumCCActiveClass", rec.ActId); } },
    { field: 'DataId', title: '数据编号', width: 100 },
    { field: 'CreateDate', title: '时间', width: 100, formatter: function (value, rec, index) { return YT.Fun.formatDate(rec.CreateDate); } },
    { field: 'Remark', title: '备注', width: 100 }

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

    CreateGrid(0);
 
</script>



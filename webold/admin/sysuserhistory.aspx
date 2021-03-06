﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sysuserhistory.aspx.cs" Inherits="syscc_sysuserhistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../themes/default/easyui.css" />
    <link href="../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../locale/easyui-lang-zh_CN.js"></script>
    <script src="../javascript/YT.js" type="text/javascript"></script>
</head>
<body>
    <div class="easyui-panel" fit="true">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="border-bottom: 1px solid #ddd; height: 32px;
                padding: 2px 5px; background: #fafafa;">
                <div style="float: left;"><table class="querytable">
                        <tr> 
                            <td>
                                开始日期：<input type="text" id="TxtStartDate" value="" class="easyui-datebox w100" />
                            </td>
                            <td>
                                结束日期：<input type="text" id="TxtEndDate" value="" class="easyui-datebox w100" />
                            </td>
                            
                            <td>
                                <a href="#" class="easyui-linkbutton" plain="true" onclick="CreateGrid();" icon="icon-search">
                                    查询</a>
                            </td>
                        </tr>
                    </table> </div>
                <div style="float: right;">
                    
                    <!--<a href="#" class="easyui-linkbutton" plain="true" icon="icon-remove">删除</a>-->
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
    function CreateGrid(objs) {
        var sTime, eTime;
        if (typeof (objs) == 'undefined') {
            sTime = $("#TxtStartDate").datebox('getValue');
            eTime = $("#TxtEndDate").datebox('getValue');
        }

        $('#tt').datagrid({
            url: '../aspx/cc/sysuserhistory.aspx?act=getlogin&id=<%=Id %>&stime='+sTime+'&etime='+eTime,
            singleSelect: true,
            fit: true,
            fitColumns: true,
            columns: [[
            { field: 'Ld', title: '编号', width: 50 },
    { field: 'Ip', title: 'ip地址', width: 100 },
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


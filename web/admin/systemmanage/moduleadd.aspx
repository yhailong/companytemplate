<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moduleadd.aspx.cs" Inherits="admin_systemmanage_moduleadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/css/framework-font.css" rel="stylesheet" />
    <link href="../../Content/css/framework-theme.css" rel="stylesheet" />
    <script src="../../Content/js/jquery/jquery-2.1.1.min.js"></script>
    <script src="../../Content/js/bootstrap/bootstrap.js"></script>
    <link href="../../Content/js/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/js/jqgrid/jqgrid.min.js"></script>
    <link href="../../Content/js/jqgrid/jqgrid.css" rel="stylesheet" />
    <script src="../../Content/js/jqgrid/grid.locale-cn.js"></script>
    <script src="../../Content/js/wdtree/tree.js"></script>
    <link href="../../Content/js/wdtree/tree.css" rel="stylesheet" />
    <link href="../../Content/js/wizard/wizard.css" rel="stylesheet" />
    <script src="../../Content/js/wizard/wizard.js"></script>
    <script src="../../Content/js/validate/jquery.validate.min.js"></script>
    <script src="../../Content/js/datepicker/WdatePicker.js"></script>
    <link href="../../Content/css/framework-ui.css" rel="stylesheet" />
    <script src="../../Content/js/framework-ui.js"></script>
    <script src="../../Content/js/public.js"></script>
</head>
<body>
    
    <form id="form1" runat="server" onsubmit="return submitForm();">

        <script>
            $(function () {
                $('.wrapper').height($(window).height() - 11);
            })
        </script>
        <div class="wrapper">
            <div class="tab-content" style="padding-top: 5px;">
                <div id="a" class="tab-pane active" style="padding: 15px;">
                    <table class="form">
                        <tr>
                            <th class="formTitle">渠道名称<span>*</span></th>
                            <td class="formValue">
                                <asp:TextBox ID="TxtTitle" runat="server" CssClass="form-control required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="formTitle">渠道经理<span>*</span></th>
                            <td class="formValue">
                                <div class="rule-single-select">
                                    <select id="SelChannelUID" runat="server"></select>
                                </div>
                            </td>
                        </tr>
                      
                        <tr style="display:none;">
                            <th class="formTitle">强制关注章节<span>*</span></th>
                            <td class="formValue">
                                <asp:TextBox ID="TxtAttentionChapterNum" CssClass="form-control digits" runat="server">0</asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <th class="formTitle">渠道成本<span>*</span></th>
                            <td class="formValue">
                                <asp:TextBox ID="TxtCostMoney" CssClass="form-control required digits" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <th class="formTitle">渠道备注</th>
                            <td class="formValue">
                                <asp:TextBox ID="TxtRemark" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                          <tr class="infodata">
                            <th class="formTitle">引导人数</th>
                            <td class="formValue">
                               <label id="lblUserNum" runat="server">0</label>
                            </td>
                        </tr>
                          <tr class="infodata">
                            <th class="formTitle">充值次数</th>
                            <td class="formValue">
                                <label id="lblCZCNum" runat="server">0</label>
                            </td>
                        </tr>
                           <tr class="infodata">
                            <th class="formTitle">充值金额</th>
                            <td class="formValue">
                                <label id="lblCZMoney" runat="server">0</label>
                            </td>
                        </tr>
                        <tr>
                            <th class="formTitle"></th>
                            <td class="formValue">
                                <asp:Button ID="btnSubmit" runat="server" Text="确认" OnClick="btnSubmit_Click" />
                                <asp:HiddenField ID="HidLd" runat="server" Value="0" />
                                <label id="lblGetMoney" runat="server" style="display:none;">0</label>
                            </td>
                        </tr>

                    </table>

                </div>
            </div>
        </div>

    </form>
    <script type="text/javascript">
        function submitForm() {
            if (!$('#form1').formValid()) {
                return false;
            }
            else {
                $("#btnSubmit").click();
            }
        }
    </script>
</body>
</html>

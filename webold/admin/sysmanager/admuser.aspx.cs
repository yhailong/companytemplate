using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Bll;

public partial class admin_sysmanager_admuser : baseCC
{
    public string StrName;
    /// <summary>
    /// 本页面的浏览权限,不填写表示不受权限控制
    /// </summary>
    public override PageCodeEnum ThisPageCodeEnum
    {
        get
        {
            return PageCodeEnum.无;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlRole.DataSource = new BllAdmUserGroup().GetAll("GroupId,Name", "1=1", " Ld ", 0);
            DdlRole.DataTextField = "Name";
            DdlRole.DataValueField = "GroupId";
            DdlRole.DataBind();

            DdlRole.Items.Insert(0, new ListItem("系统超级管理员", "0"));
            DdlRole.Items.Insert(0, new ListItem("全部", "-1"));
        }
    }
}
using CompanyT.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_news_news : baseCC
{
    public override PageCodeEnum ThisPageCodeEnum
    {
        get
        {
            return PageCodeEnum.模块管理;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DdlClass.DataSource = new BllCompanyNewsClass().GetAll("Ld,Title", "state=1", "rank,ld", 0);
        DdlClass.DataTextField = "Title";
        DdlClass.DataValueField = "Ld";
        DdlClass.DataBind();
        DdlClass.Items.Insert(0, new ListItem("全部", "0"));
    }
}
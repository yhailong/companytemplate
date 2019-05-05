using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Bll;
using CompanyT.Entity;

public partial class admin_news_newsadd : baseCC
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
        if (!Page.IsPostBack)
        {
            CFun.BindListControl<AvailablesStatus>(RblState, false);

            DdlNewsClass.DataSource = new BllCompanyNewsClass().GetAll("Ld,Title", "state=1", "rank,ld", 0);
            DdlNewsClass.DataTextField = "Title";
            DdlNewsClass.DataValueField = "Ld";
            DdlNewsClass.DataBind();
            
            int id = CFun.RequestPamInt("id");
            if (id > 0)
            {
                CompanyNews cont = new BllCompanyNews().GetItem(id);
                if (cont != null)
                {
                    CFun.BindPageData<CompanyNews>(this, cont);
                    BtnSave.Text = "修改";
                }
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        CompanyNews cont = new CompanyNews();
        CFun.GetPageData<CompanyNews>(cont, this);
        if (cont.Ld == 0)
        {
            cont.CreateDate = DateTime.Now;
        }
        cont.LastDate = DateTime.Now;

        if(new BllCompanyNews().InsertorUpdateitem(cont))
        {
            CFun.AlertMegT("保存成功！", "closeFlowPanel", "");
        }
        else
        {
            CFun.AlertMegT("发生错误，请稍后再试!", "back", "");
        }
    }
}
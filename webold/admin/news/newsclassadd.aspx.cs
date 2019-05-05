using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Entity;
using CompanyT.Bll;

public partial class admin_news_newsclassadd : baseCC
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
            int id = CFun.RequestPamInt("id");
            if (id > 0)
            {
                CompanyNewsClass cont = new BllCompanyNewsClass().GetItem(id);
                if (cont != null)
                {
                    CFun.BindPageData<CompanyNewsClass>(this, cont);
                    BtnSave.Text = "修改";
                }
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        CompanyNewsClass cont = new CompanyNewsClass();
        CFun.GetPageData<CompanyNewsClass>(cont, this);

        if (cont.Ld == 0)
        {
            cont.CreateDate = DateTime.Now;
        }
        cont.LastDate = DateTime.Now;
        if (new BllCompanyNewsClass().InsertorUpdateitem(cont))
        {
            CFun.AlertMegT("保存成功！", "closeFlowPanel", "");
        }
        else
        {
            CFun.AlertMegT("发生错误，请稍后再试!", "back", "");
        }
    }
}
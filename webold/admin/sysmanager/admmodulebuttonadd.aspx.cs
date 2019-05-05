using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Entity;
using CompanyT.Bll;

public partial class admin_sysmanager_admmodulebuttonadd : baseCC
{
    /// <summary>
    /// 本页面的浏览权限,不填写表示不受权限控制
    /// </summary>
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
            CFun.BindListControl<AvailablesStatus>(RblStatus, false);

            int id = CFun.RequestPamInt("id");
            int pId = CFun.RequestPamInt("parentid");
            if (id > 0)
            {
                AdmUserModule cont = new BllAdmUserModule().GetItem(id);
                if (cont != null)
                {
                    CFun.BindPageData<AdmUserModule>(this, cont);
                    BtnSave.Text = "修改";
                }
            }
            else
            {
                TxtParentId.Text = pId.ToString();
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        AdmUserModule cont = new AdmUserModule();
        CFun.GetPageData<AdmUserModule>(cont, this);
        if (cont.Ld == 0)
        {
            cont.CreateDate = DateTime.Now;
        }
        cont.LastDate = DateTime.Now;

        if (new BllAdmUserModule("newconnstring").InsertorUpdateitem(cont))
        {
            CFun.AlertMegT("保存成功！", "closeFlowPanel", "");
        }
        else
        {
            CFun.AlertMegT("发生错误，请稍后再试!", "back", "");
        }
    }
}
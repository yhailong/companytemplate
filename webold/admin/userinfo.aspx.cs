using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Bll;
using CompanyT.Entity;
using YUTIAN.Tools;

public partial class syscc_userinfo : baseCC
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdmUser cont = new BllAdmUser().GetItem(base.CurrentUId);
            if (cont != null)
            {
                CFun.BindPageData<AdmUser>(this, cont);
                LabStatus.Text = Enum.GetName(typeof(AvailablesStatus), cont.Status.Value);
                LabGroupId.Text = new BllAdmUserGroup().GetGroupName(cont.GroupIdList);
                LabDepartment.Text = Enum.GetName(typeof(EnumUPostClass), cont.UPost);
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        AdmUser cont = new AdmUser();
        CFun.GetPageData<AdmUser>(cont, this);
        if (TxtUPass.Text.Trim() != "")
        {
            cont.UPassword = CFun.MD5(TxtUPass.Text.Trim());
        }
        cont.LastDate = DateTime.Now;

        if (new BllAdmUser().InsertorUpdateitem(cont))
        {
            CFun.AlertMegT("信息修改成功！", "", "userinfo.aspx");
        }
        else
        {
            CFun.AlertMegT("发生错误，请稍后再试！", "back", "");
        }
    }
}
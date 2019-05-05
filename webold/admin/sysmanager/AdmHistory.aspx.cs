using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Entity;
using YUTIAN.Tools;

public partial class admin_sysmanager_AdmHistory : baseCC
{
    public override PageCodeEnum ThisPageCodeEnum
    {
        get
        {
            return PageCodeEnum.无;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CFun.BindListControl<EnumAdmActClass>(DdlActClass, true);
        int act = CFun.RequestPamInt("act");
        if (act > 0)
        {
            DdlActClass.SelectedValue = act.ToString();
        }
    }
}
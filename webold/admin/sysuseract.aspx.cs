using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Bll;
using CompanyT.Entity;

public partial class syscc_sysuseract : baseCC
{
    public string Id="0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Id = CFun.RequestPamInt("id").ToString();
            CFun.BindListControl<EnumCCActiveClass>(DdlAct, true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;

public partial class syscc_sysuserhistory : baseCC
{
    public string Id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = CFun.RequestPamInt("id").ToString();
    }
}
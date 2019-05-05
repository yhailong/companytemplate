using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Bll;

public partial class admin_main :baseCC
{
    public string nickName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        nickName = BllAdmUser.GetCurrentUName();
    }
}
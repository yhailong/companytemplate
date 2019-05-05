using CompanyT.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_logout : baseCC
{
    protected void Page_Load(object sender, EventArgs e)
    {
        new BllAdmUser().LogOut();
    }
}
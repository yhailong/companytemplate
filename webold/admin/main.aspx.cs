using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Bll;
using CompanyT.Entity;
using System.Text;
using System.Data;
using YUTIAN.Tools;

public partial class admin_main : baseCC
{
    public string webName = "";
    string url = "/admin/login.aspx";


    protected void Page_Load(object sender, EventArgs e)
    {
        
        LtlCurrentUser.Text = CurrentTureName;
        webName = CFun.GetAppStr("webName");
        
        LoadMenu();

    }
 

    private void LoadMenu()
    {
        StringBuilder sb2 = new StringBuilder();
        DataTable dt = new BllAdmGroupRoleList().GetAdmModuleInfoByGroupIDs("ld,url,keycode,name,parentid,icon,Title", 0, "rank asc", CurrentRoleId);
        

        DataRow[] rowList;

        int i = 0;
        foreach (DataRow dr in dt.Select("parentid=0"))
        {
            if (i == 0)
            {
                sb2.Append("<div title=\"" + dr["name"] + "\"  selected=\"true\">");
            }
            else
            {
                sb2.Append("<div title=\"" + dr["name"] + "\">");
            }
            sb2.Append("<ul class=\"mleft\">");
            rowList = dt.Select(" parentid=" + dr["Ld"].ToString());
            foreach (DataRow drChild in rowList)
            {
                sb2.Append("<li><a href=\"" + drChild["Url"].ToString() + "\" target=\"sysMain\"  onclick=\"showTitle('" + drChild["Title"].ToString() + "');\">" + drChild["Name"].ToString() + "</a></li>");
            }
            sb2.Append("</ul>");
            sb2.Append("</div>");
            i++;
        }
        LtlNav.Text = sb2.ToString();

    }
}
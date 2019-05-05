using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Bll;
using CompanyT.Entity;
using System.Text;
using System.Data;

public partial class aspx_adm_admuserhistory : BaseAjaxPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string rStr = "";
        string act = CFun.RequestPamStr("act");
        switch (act)
        {
            case "getlogin":
                rStr = GetValueLogin();
                break;
            case "getact":
                rStr = GetValueAct();
                break;
        }

        Response.Write(rStr);
        Response.End();
    }

    private string GetValueAct()
    {
        int id = CFun.RequestPamInt("id");
        string sTime, eTime;
        sTime = CFun.RequestPamStr("stime");
        eTime = CFun.RequestPamStr("etime");
        int actClass = CFun.RequestPamInt("actclass");

        string sqlWhere = " uid=" + id.ToString();

        if (CFun.StrIsDate(sTime))
        {
            sqlWhere += " and CreateDate>'" + sTime + "'";
        }
        if (CFun.StrIsDate(eTime))
        {
            sqlWhere += " and CreateDate<'" + eTime + " 23:59:59'";
        }
        if (actClass > 0)
        {
            sqlWhere += " and ActId="+actClass.ToString();
        }

        int pageSize = CFun.RequestPamInt("rows");
        if (pageSize <= 0)
        {
            pageSize = CFun.pagesize();
        }

        int pageCurrent = CFun.RequestPamInt("page");
        if (pageCurrent <= 0)
        {
            pageCurrent = 1;
        }

        return new BllAdmActHistory().GetAllByPage("*", pageSize, pageCurrent, sqlWhere, "Ld desc");
    }

    private string GetValueLogin()
    {
        int id = CFun.RequestPamInt("id");
        string sTime, eTime;
        sTime = CFun.RequestPamStr("stime");
        eTime = CFun.RequestPamStr("etime");

        string sqlWhere = " uid="+id.ToString();

        if (CFun.StrIsDate(sTime))
        {
            sqlWhere += " and CreateDate>'"+sTime+"'";
        }
        if (CFun.StrIsDate(eTime))
        {
            sqlWhere += " and CreateDate<'"+eTime+" 23:59:59'";
        }

        int pageSize = CFun.RequestPamInt("rows");
        if (pageSize <= 0)
        {
            pageSize = CFun.pagesize();
        }

        int pageCurrent = CFun.RequestPamInt("page");
        if (pageCurrent <= 0)
        {
            pageCurrent = 1;
        }

        return new BllAdmLoginHistory().GetAllByPage("*", pageSize, pageCurrent, sqlWhere, "Ld desc");
    }
}
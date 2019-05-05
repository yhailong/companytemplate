using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Entity;
using CompanyT.Bll;
using YUTIAN.Tools;
public partial class api_adm_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string rStr = "";
        string act = CFun.RequestPamStr("act");
        switch (act)
        {
            case "get":
                rStr = GetValue();
                break;
            case "del":
                rStr = DelItem();
                break;
            case "getclass":
                rStr = GetClass();
                break;
            case "delclass":
                rStr = DelClass();
                break;

        }
        Response.Write(rStr);
        Response.End();
    }

    private string GetClass()
    {
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
        return new BllCompanyNewsClass().GetAllByPage("*", pageSize, pageCurrent, "", "Ld desc");
    }

    private string DelClass()
    {
        int id = CFun.RequestPamInt("ids");
        if (new BllCompanyNewsClass().DeleteItem(id))
        {
            return "";
        }
        else
        {
            return "1";
        }
    }


    private string GetValue()
    {
        int classId = CFun.RequestPamInt("classid");
        string Sqlwhere = "";
        if (classId>0)
        {
            Sqlwhere = " newsclass=" + classId + "";
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
        return new BllCompanyNews().GetAllByPage("*", pageSize, pageCurrent, Sqlwhere, "Ld desc");
    }

    private string DelItem()
    {
        int id = CFun.RequestPamInt("ids");
        if (new BllCompanyNews().DeleteItem(id))
        {
            return "";
        }
        else
        {
            return "1";
        }
    }
}
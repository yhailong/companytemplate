﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Entity;
using CompanyT.Bll;
using YUTIAN.Tools;

public partial class aspx_adm_admmodule : BaseAjaxPage
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
        }

        Response.Write(rStr);
        Response.End();
    }

    private string GetValue()
    {
        int parentId = CFun.RequestPamInt("parentid");
        string sqlWhere = " parentid={0} ";
        sqlWhere = String.Format(sqlWhere, parentId);

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

        return new BllAdmUserModule().GetAllByPage("*", pageSize, pageCurrent, sqlWhere, "rank,Ld desc");
    }

    private string DelItem()
    {
        int id = CFun.RequestPamInt("ids");
        if (new BllAdmUserModule().DeleteItem(id))
        {
            return "";
        }
        else
        {
            return "1";
        }
    }
}
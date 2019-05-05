using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YUTIAN.Tools;
using System.Data;
using CompanyT.Bll;
using CompanyT.Entity;

public class baseCC : baseAdminPage
{
    /// <summary>
    /// 登录用户名
    /// </summary>
    public string CurrentUName;

    /// <summary>
    /// 真实姓名
    /// </summary>
    public string CurrentTureName;

    /// <summary>
    /// 登录用户编号
    /// </summary>
    public int CurrentUId;

    /// <summary>
    /// 当前用户角色编号
    /// </summary>
    public string CurrentRoleId;


    /// <summary>
    /// 登录用户职务
    /// </summary>
    public int CurrentUPost;


    /// <summary>
    /// 登录校验字
    /// </summary>
    public int CurrentCheckCode;


    string url = "/admin/login.aspx";

    #region 浏览权限验证

    /// <summary>
    /// 本页面的浏览权限，空字符串表示本页面不受权限控制
    /// </summary>
    public virtual PageCodeEnum ThisPageCodeEnum
    {
        get
        {
            return PageCodeEnum.无;
        }
    }

    /// <summary>
    /// 本页面的浏览权限，空字符串表示本页面不受权限控制
    /// </summary>
    public virtual PageCodeEnum[] ThisPageCodeEnums
    {
        get
        {
            return new PageCodeEnum[] { };
        }
    }

    public bool ValidatePageCode()
    {
        // 当前登陆用户的权限列表
        List<string> roleModuleKeyCode = GetRoleModuleKeyCode();

        List<string> listPageCode = new List<string>();
        listPageCode.Add(GetPageCodeFromEnum(ThisPageCodeEnum));
        foreach (PageCodeEnum pce in ThisPageCodeEnums)
        {
            listPageCode.Add(GetPageCodeFromEnum(pce));
        }
        if (listPageCode.Exists(p => p == "" || roleModuleKeyCode.Contains(p)))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 获取当前登录用户拥有的全部权限列表
    /// </summary>
    /// <param name="roleIDs"></param>
    /// <returns></returns>
    protected List<string> GetRoleModuleKeyCode()
    {
        List<string> listKeyCode = GetCookieObject<List<string>>(CFun.GetAppStr("LoginUserModuleCookieName"));
        if (listKeyCode == null)
        {
            listKeyCode = new List<string>();
            DataTable dt = new BllAdmGroupRoleList().GetAdmModuleInfoByGroupIDs("keycode", 0, "", CurrentRoleId);
            foreach (DataRow dr in dt.Rows)
            {
                listKeyCode.Add(dr["KeyCode"].ToString());
            }
            SetCookieDomain(CFun.GetAppStr("LoginUserModuleCookieName"), listKeyCode, 1);
        }
        return listKeyCode;
    }

    #endregion

    #region 页面初始化

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        // 此用户是否有访问此页面的权限
        if (CurrentRoleId != "" && !ValidatePageCode())
        {
            var mainPage = "/admin/welcome.aspx";
            var tipHtml = "<script language=\"javascript\" type=\"text/javascript\">alert('抱歉，您没有访问该页面的权限！');window.location.href=\"" + mainPage + "\";</script>";
            System.Web.HttpContext.Current.Response.Write(tipHtml);
            System.Web.HttpContext.Current.Response.End();
        }
    }

    #endregion



    public baseCC()
    {

        CurrentUId = 0;
        CurrentUName = "admin";
        CurrentTureName = "管理员";

        //检查用户登录状态
        try
        {
            HttpCookie co1 = System.Web.HttpContext.Current.Request.Cookies[CFun.GetAppStr("LoginCookieName")];
            CurrentUId = Convert.ToInt32(co1["i"]);
            CurrentUName = co1["n"];
            CurrentTureName = System.Web.HttpUtility.UrlDecode(co1["t"]);
            CurrentCheckCode = CFun.ParseInt(co1["c"]);
            CurrentRoleId = CFun.DESDecrypt(co1["r"], CFun.GetAppStr("DESKey"));
            CurrentRoleId = CurrentRoleId == "" ? "-1" : CurrentRoleId;
            CurrentRoleId = ("," + CurrentRoleId + ",").IndexOf(",0,") >= 0 ? "" : CurrentRoleId;
            CurrentUPost = Convert.ToInt32(CFun.DESDecrypt(co1["g"], CFun.GetAppStr("DESKey")));


            //处理踢人下线
            checkUserAvailable();
        }
        catch
        {
            System.Web.HttpContext.Current.Response.Redirect(url);
            return;
        }

        if (CurrentUId <= 0)
        {
            System.Web.HttpContext.Current.Response.Redirect(url);
            return;
        }
    }


    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    public void pageFalse()
    {
        System.Web.HttpContext.Current.Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert('发生错误！');history.go(-1);</script>发生错误！");
        System.Web.HttpContext.Current.Response.End();
    }


    private void checkUserAvailable()
    {
        int times = 0;
        HttpCookie co = System.Web.HttpContext.Current.Request.Cookies["ccUserTimes"];
        if (co != null)
        {
            times = CFun.ParseInt(co.Value);
            times++;
            if (times > 10)
            {
                times = 0;
            }
        }
        else
        {
            co = new HttpCookie("ccUserTimes");
        }

        co.Value = times.ToString();
        System.Web.HttpContext.Current.Response.Cookies.Add(co);
        if (times == 0)
        {
            if (ExecSql.GetDataSet("select ld from AdmUser where Ld=" + CurrentUId + " and CheckCode<>" + CurrentCheckCode).Tables[0].Rows.Count > 0)
            {
                new BllAdmUser().LogOut();
                return;
            }
        }
    }

    public string GetUserInfoJson()
    {
        string UserJson = "";
        List<AdmUser> list = new BllAdmUser().GetItem("");
        foreach (AdmUser model in list)
        {
            UserJson += "{\"ID\":\"" + model.Ld + "\",\"Name\":\"" + model.TrueName + "\"},";
        }
        UserJson = UserJson.Length > 0 ? "[" + UserJson.Substring(0, UserJson.Length - 1) + "]" : "";
        return UserJson;
    }
}
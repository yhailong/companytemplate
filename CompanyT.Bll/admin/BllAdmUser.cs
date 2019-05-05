/*系统自动生成的 sql server 版业务类
* 开发时间：2019/4/25 16:00:34
* 版权所有：andy
* 其他联系：
* Email：yhailong@sina.com
* MSN：yhailong@hotmail.com
* QQ:2363609963
* 声明：仅限于您自己使用，不得进行商业传播，违者必究！
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CompanyT.Entity;
using CompanyT.SqlClient;
using YUTIAN.Tools;
using System.Web;

namespace CompanyT.Bll
{
    /// <summary>
    /// AdmUser 的数据库方法
    /// </summary>
    public class BllAdmUser :Bll_Base<AdmUser,Sql_AdmUser>
    {

       #region  
       /// <summary>
       /// 
       /// </summary>
       public BllAdmUser() : base() { }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sqlConn">数据库连接名</param>
       public BllAdmUser(string sqlConn) : base(sqlConn) { }
        #endregion


        #region 人工定义方法 by  

        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPass"></param>
        /// <returns></returns>
        public int UserLoginIn(string uName, string uPass)
        {
            DataTable dtUser = null;
            int resultInt = new Sql_AdmUser().CheckUser(uName, CFun.MD5(uPass), CFun.GetRemoteIP(), out dtUser);
            if (resultInt == 1)
            {
                DataRow dr = dtUser.Rows[0];
                if (dr["Status"].ToString() == "1")
                {
                    HttpCookie co1 = new HttpCookie(CFun.GetAppStr("LoginCookieName"));
                    co1.Values["i"] = dr["Ld"].ToString();
                    co1.Values["n"] = dr["UName"].ToString();
                    co1.Values["c"] = dr["checkcode"].ToString();
                    co1.Values["r"] = CFun.DESEncrypt(dr["GroupIdList"].ToString().TrimStart(',').TrimEnd(','), CFun.GetAppStr("DESKey"));
                    co1.Values["t"] = System.Web.HttpContext.Current.Server.UrlEncode(dr["TrueName"].ToString());
                    co1.Values["g"] = CFun.DESEncrypt(dr["UPost"].ToString(), CFun.GetAppStr("DESKey"));
                    co1.Domain = CFun.GetAppStr("webDomain");
                    System.Web.HttpContext.Current.Response.Cookies.Add(co1);
                }
                else
                {
                    return 5;
                }
            }
            return resultInt;
        }


        /// <summary>
        /// 返回当前登录的用户编号
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentUId()
        {
            try
            {
                HttpCookie co1 = System.Web.HttpContext.Current.Request.Cookies[CFun.GetAppStr("LoginCookieName")];
                return CFun.ParseInt(co1["i"]);
            }
            catch
            {
                return 0;
            }


        }

        /// <summary>
        /// 返回当前登录的用户名
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUName()
        {
            try
            {
                HttpCookie co1 = System.Web.HttpContext.Current.Request.Cookies[CFun.GetAppStr("LoginCookieName")];
                return co1["n"];
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 处理用户登出
        /// </summary>
        public void LogOut()
        {
            HttpCookie co1 = new HttpCookie(CFun.GetAppStr("LoginCookieName"));
            co1.Value = "";
            co1.Domain = CFun.GetAppStr("webDomain");
            System.Web.HttpContext.Current.Response.Cookies.Add(co1);
        }
        #endregion

    }
}

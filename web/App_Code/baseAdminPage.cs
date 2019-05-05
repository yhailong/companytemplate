using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using YUTIAN.Tools;

/// <summary>
/// baseAdminPage 的摘要说明
/// </summary>
public class baseAdminPage : Page
{
    public baseAdminPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }


    #region Cookie操作
    public void SetCookieDomain(string cookiename, object cookievalue, int hour)
    {
        try
        {
            System.Runtime.Serialization.IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            string result = string.Empty;
            //将字符串进行base64编码，解决中文问题。然后进行序列化化，将shopcart保存至cookie
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bf.Serialize(ms, cookievalue);
                byte[] byt = new byte[ms.Length];
                byt = ms.ToArray();
                result = System.Convert.ToBase64String(byt);
                ms.Flush();
            }
            HttpCookie hc = new HttpCookie(cookiename);
            hc.Value = result;
            hc.HttpOnly = false;
            if (hour != 0)
            {
                hc.Expires = DateTime.Now.AddHours(hour);  //设置过期时间
            }
            else
            {
                hc.Expires = DateTime.MaxValue;
            }
            hc.Domain = CFun.GetAppStr("webDomain");
            HttpContext.Current.Response.Cookies.Add(hc);
        }
        catch
        {
        }
    }

    public T GetCookieObject<T>(string strCookieName)
    {
        try
        {
            System.Runtime.Serialization.IFormatter bf = new BinaryFormatter();
            byte[] byt = Convert.FromBase64String(GetCookieValue(strCookieName));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byt, 0, byt.Length))
            {
                return (T)bf.Deserialize(ms);
            }
        }
        catch
        {
            return default(T);
        }
    }

    public string GetCookieValue(string cookiename)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
        string str = string.Empty;
        if (cookie != null)
        {
            str = cookie.Value;
        }
        return str;
    }

    //删除Cookie
    public void DeleteCoolie(string cookieName)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddYears(-3);
            cookie.Domain = CFun.GetAppStr("webDomain");
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
    #endregion

    #region 页面对应Code枚举值
    public enum PageCodeEnum
    {
        [System.ComponentModel.Description("")]
        无,
        [System.ComponentModel.Description("AA")]
        系统管理,
        [System.ComponentModel.Description("AC")]
        模块管理

    }

    /// <summary>
    /// 获取当前页面对应的keycode
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    public string GetPageCodeFromEnum(Enum en)
    {
        Type type = en.GetType();
        System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
                return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
        }
        return en.ToString();
    }
    #endregion
}
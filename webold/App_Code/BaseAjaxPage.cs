using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using YUTIAN.Tools;

/// <summary>
/// BaseAjaxPage 的摘要说明
/// </summary>
public class BaseAjaxPage : baseCC
{
	public BaseAjaxPage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//

	}

    protected override void OnLoad(EventArgs e)
    {
        var formUrl = Request.ServerVariables["HTTP_REFERER"];  //调用当前页面的网址
        formUrl = formUrl == null ? "" : formUrl.ToString();
        string webDomain = CFun.GetAppStr("webDomain");
        if (formUrl.IndexOf(webDomain) < 0) //非指定网址访问
        {
            var tipHtml = "非法访问来源";
            System.Web.HttpContext.Current.Response.Write(tipHtml);
            System.Web.HttpContext.Current.Response.End();
        }
        else
        {
            base.OnLoad(e);
        }
    }
}
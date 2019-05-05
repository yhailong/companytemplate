using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;

public partial class admin_sysmanager_admmodule : baseCC
{
    public string parentId = "0";
    /// <summary>
    /// 本页面的浏览权限,不填写表示不受权限控制
    /// </summary>
    public override PageCodeEnum ThisPageCodeEnum
    {
        get
        {
            return PageCodeEnum.模块管理;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        parentId = CFun.RequestPamStr("id");
		if (parentId == "")
		{
			parentId = "0";
		}
    }
}
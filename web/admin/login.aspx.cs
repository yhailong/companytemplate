using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyT.Bll;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string uName = TxtUName.Text.Trim();
        string uPass = TxtUPass.Text.Trim();
        if (BaseFun.StrIsUName(uName) && BaseFun.StrIsUPass(uPass))
        {
            if (Session["bcode"] != null && Txtcheckcode.Text.Trim() == Session["bcode"].ToString())
            {
                int logStatus = new BllAdmUser().UserLoginIn(uName, uPass);

                switch (logStatus)
                {
                    case 1:

                        Response.Redirect("main.aspx");
                        break;
                    case -1:
                        LabErr.Text = "登录密码错误，请重新输入！";
                        break;
                    case -2:

                        LabErr.Text = "无此用户名，请检查是否输入错误！";
                        break;
                    case -3:
                        LabErr.Text = "您的帐号已被禁用，请联系管理员为您处理！";
                        break;
                    case -4:
                        LabErr.Text = "超过登录次数限制，请稍候再试！";
                        break;
                }
            }
            else
            {
                LabErr.Text = "验证码有误！";
            }
        }
        else
        {
            LabErr.Text = "用户名或密码格式错误！";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Entity;
using CompanyT.Bll;
using System.Data;
using System.Text;

public partial class admin_sysmanager_admuseradd : baseCC
{

    /// <summary>
    /// 本页面的浏览权限,不填写表示不受权限控制
    /// </summary>
    public override PageCodeEnum ThisPageCodeEnum
    {
        get
        {
            return PageCodeEnum.无;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CFun.BindListControl<AvailablesStatus>(RblStatus, false);
            CFun.BindListControl<EnumUPostClass>(RblUPost, false);
            CFun.BindListControl<EnumSexClass>(RblUPostSex, false);

            RblUPostSex.SelectedIndex = 0;
            RblUPost.SelectedIndex = 1;
            RblStatus.SelectedIndex = 1;

            int id = CFun.RequestPamInt("id");
            if (id > 0)
            {
                AdmUser cont = new BllAdmUser().GetItem(id);
                if (cont != null)
                {
                    CFun.BindPageData<AdmUser>(this, cont);
                    
                    BtnSave.Text = "修改";
                    initRoleList(cont.GroupIdList);
                }
                else
                {
                    initRoleList("");
                }
            }
            else
            {
                initRoleList("");
            }
          
        }
    }

    

    private void initRoleList(string roleList)
    {
        StringBuilder strB = new StringBuilder();
        List<AdmUserGroup> contList = new BllAdmUserGroup().GetItem(" 1=1", "Ld desc");

        //虚拟超级管理员
        strB.Append("<div class=\"bclass\">");
        strB.Append("<div><input type=checkbox name=\"gname\" value=\"0\" " + checkRole(roleList, 0) + ">超级管理员</div>");
        //strB.Append("<div class=\"secclass\">");
        strB.Append("</div>");

        foreach (AdmUserGroup cont in contList)
        {
            strB.Append("<div class=\"bclass\">");
            strB.Append("<div><input type=checkbox name=\"gname\" value=\"" + cont.GroupId + "\" " + checkRole(roleList, (int)cont.GroupId) + ">" + cont.Name + "</div>");
            //strB.Append("<div class=\"secclass\">");
            strB.Append("</div>");
        }
        
        LtlGroupIdList.Text = strB.ToString();
    }

    private string checkRole(string roleList, int id)
    {
        if (roleList == "")
        {
            return "";
        }

        roleList = "," + roleList + ",";
        string strId = id.ToString();
        if (strId == "")
        {
            return "";
        }

        strId = "," + strId + ",";
        if (roleList.IndexOf(strId) >= 0)
        {
            return " checked ";
        }

        return "";
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        AdmUser cont = new AdmUser();
        CFun.GetPageData<AdmUser>(cont, this);
        //cont.GroupIdList = CFun.RequestPamStr("gname");
        string GroupIdList = CFun.RequestPamStr("gname");
        string platformList = CFun.RequestPamStr("platformname");
        cont.GroupIdList=","+GroupIdList+',';
        if (cont.Ld == 0)
        {
            cont.CreateDate = DateTime.Now;
        }
        cont.LastDate = DateTime.Now;

        if (TxtUPass.Text != "")
        {
            cont.UPassword = CFun.MD5(TxtUPass.Text);
        }

        if (new BllAdmUser().InsertorUpdateitem(cont))
        {
            BllAdmActHistory.SaveLog(CurrentUId, (int)EnumCCActiveClass.客服人员管理, cont.Ld.Value, "");
            CFun.AlertMegT("保存成功！", "closeFlowPanel", "");
        }
        else
        {
            CFun.AlertMegT("发生错误，请稍后再试!", "back", "");
        }
    }
}
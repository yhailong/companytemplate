using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YUTIAN.Tools;
using CompanyT.Entity;
using CompanyT.Bll;
using System.Text;
using System.Collections;
using System.Data;

public partial class admin_sysmanager_admusergroupadd : baseCC
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
            ArrayList al = new ArrayList();
            int id = CFun.RequestPamInt("id");
            if (id > 0)
            {
                AdmUserGroup usergroup = new BllAdmUserGroup().GetItem(id);
                if (usergroup != null)
                {
                    int GroupId = (int)usergroup.GroupId;
                    CFun.BindPageData<AdmUserGroup>(this, usergroup);
                    DataTable dt = new BllAdmGroupRoleList().GetItemByGroupId(GroupId);
                    if (dt.Rows.Count > 0)
                    {
                        BtnSave.Text = "修改";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string K = dt.Rows[i]["KeyCode"].ToString();
                            al.Add(K);

                        }
                        string roleList = string.Join(",", (string[])al.ToArray(typeof(string)));
                        initRoleList(roleList);
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
            else
            {
                initRoleList("");

            }
        }

    }

    #region
    private void initRoleList(string roleList)
    {
        StringBuilder strB = new StringBuilder();
        List<AdmUserModule> contList = new BllAdmUserModule().GetItem(" parentid>0 and status=1", " parentid,rank,ld ");
        List<AdmUserModule> contFirst = new BllAdmUserModule().GetItem(" parentid=0 ", " parentid,rank,ld ");

        foreach (AdmUserModule cont in contFirst)
        {
            strB.Append("<div class=\"bclass\">");
            strB.Append("<div><input type=checkbox name=\"mname\" value=\"" + cont.KeyCode + "\" " + checkRole(roleList, cont.KeyCode) + ">" + cont.Name + "</div>");
            strB.Append("<div class=\"secclass\">");
            foreach (AdmUserModule cont1 in contList)
            {
                if (cont1.ParentId == cont.Ld)
                {
                    strB.Append("<input type=checkbox name=\"mname\" value=\"" + cont1.KeyCode + "\" " + checkRole(roleList, cont1.KeyCode) + ">" + cont1.Name + "&nbsp;");
                }
            }
            strB.Append("</div></div>");
        }

        LtlKeyCode.Text = strB.ToString();
    }



    private string checkRole(string roleList, string rId)
    {
        if (roleList == "")
        {
            return "";
        }

        roleList = "," + roleList + ",";
        string strId = rId.ToString();
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

    #endregion


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        bool error = false;
        AdmUserGroup usergroup = new AdmUserGroup();
        CFun.GetPageData<AdmUserGroup>(usergroup, this);
        AdmGroupRoleList cont = new AdmGroupRoleList();
        string KeyCode = CFun.RequestPamStr("mname");
        if (usergroup.Ld == 0)
        {
            usergroup.CreateDate = DateTime.Now;
        }
        usergroup.LastDate = DateTime.Now;
        
        if (new BllAdmUserGroup().InsertorUpdateitem(usergroup))
        {
            int GroupId = usergroup.GroupId.Value;
            new BllAdmGroupRoleList().DeleteItemByGroupId(GroupId);
            cont.GroupId = GroupId;
            cont.Ld = 0;

            if (KeyCode != null)
            {
                string[] ss = KeyCode.Trim().Split(new char[] { ',' });
                if (ss.Length > 0)
                {
                    for (int i = 0; i < ss.Length; i++)
                    {
                        cont.KeyCode = ss[i];
                        error = new BllAdmGroupRoleList().InsertorUpdateitem(cont);
                    }
                }
            }
            error = true;
        }

        if (error)
        {
            BllAdmActHistory.SaveLog(CurrentUId, (int)EnumCCActiveClass.权限组管理, usergroup.Ld.Value, "");
            CFun.AlertMegT("保存成功！", "closeFlowPanel", "");
        }
        else
        {
            CFun.AlertMegT("发生错误，请稍后再试!", "back", "");
        }
    }
}
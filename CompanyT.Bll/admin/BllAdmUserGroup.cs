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
using System.Collections;

namespace CompanyT.Bll
{
    /// <summary>
    /// AdmUserGroup 的数据库方法
    /// </summary>
    public class BllAdmUserGroup :Bll_Base<AdmUserGroup,Sql_AdmUserGroup>
    {

       #region  
       /// <summary>
       /// 
       /// </summary>
       public BllAdmUserGroup() : base() { }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sqlConn">数据库连接名</param>
       public BllAdmUserGroup(string sqlConn) : base(sqlConn) { }
        #endregion


        #region 人工定义方法 by  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupIdList"></param>
        /// <returns></returns>
        public string GetGroupName(string GroupIdList)
        {
            string name = GetItembyGroupIdList(GroupIdList);
            return name;
        }

        private string GetItembyGroupIdList(string GroupIdList)
        {
            GroupIdList = GroupIdList.Trim(',');
            AdmUserGroup cont = new AdmUserGroup();
            ArrayList al = new ArrayList();

            GroupIdList = CFun.RegularIdlist(GroupIdList, true);
            string[] ss = GroupIdList.Trim().Split(new char[] { ',' });

            //第一种方法
            for (int j = 0; j < ss.Length; j++)
            {
                if (ss[j] == "0")
                {
                    cont.Name = "系统超级管理员";
                    al.Add(cont.Name);
                }
                else
                {
                    List<AdmUserGroup> contList = GetItem(" GroupId=" + ss[j]);
                    if (contList != null && contList.Count > 0)
                    {
                        cont = contList[0];
                        al.Add(cont.Name);
                    }
                }
            }
            //直接装换为String 类型。
            cont.Name = string.Join(",", (string[])al.ToArray(typeof(string)));
            return cont.Name;

        }
        #endregion

    }
}

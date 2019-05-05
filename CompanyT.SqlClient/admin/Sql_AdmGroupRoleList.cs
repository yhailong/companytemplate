/*系统自动生成的 sql server 版数据库操作类
* 开发时间：2019/4/25 16:00:33
* 版权所有：andy
* 其他联系：
* Email：yhailong@sina.com
* MSN：yhailong@hotmail.com
* QQ:2363609963
* 声明：仅限于您自己使用，不得进行商业传播，违者必究！
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CompanyT.Entity;
using System.Reflection;
using YUTIAN.Tools;

namespace CompanyT.SqlClient
{
    public class Sql_AdmGroupRoleList : SqlBase<AdmGroupRoleList>
    {

        #region 人工定义方法 by  
        public DataTable GetAdmModuleInfoByGroupIDs(string column, int top, string sort = "", string groupIDs = "")
        {
            string sqlSelect = " select " + column + " from AdmUserModule where Status=1";

            if (groupIDs != "")
            {
                sqlSelect += " and   KeyCode in ( select distinct(keycode) from admgrouprolelist where GroupId in (" + groupIDs + "))";
            }

            if (sort != "")
            {
                sqlSelect += " order by " + sort;
            }

            return ExecSqlConn.GetDataSet(sqlSelect, sqlConn).Tables[0];
        }

        public DataTable GetItemByGroupId(int GroupId)
        {
            SqlString = " select KeyCode from AdmGroupRoleList where GroupId=" + GroupId;
            return ExecSqlConn.GetDataSet(SqlString, sqlConn).Tables[0];
        }

        public void DeleteItemByGroupId(int GroupId)
        {
            SqlString = "delete AdmGroupRoleList where GroupId= " + GroupId;
            ExecSqlConn.SqlExecNoquery(SqlString, sqlConn);
        }
        #endregion

    }
}

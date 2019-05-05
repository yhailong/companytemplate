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
    public class Sql_AdmActHistory : SqlBase<AdmActHistory>
    {

        #region 人工定义方法 by  
        public void SaveLog(int uId, int actId, int dataId, string remark)
        {
            SqlParameter[] pam = new SqlParameter[4];
            pam[0] = new SqlParameter("@uId", uId);
            pam[1] = new SqlParameter("@actId", actId);
            pam[2] = new SqlParameter("@dataId", dataId);
            pam[3] = new SqlParameter("@remark", remark);

            ExecSql.SqlExecNoquery("insert into admacthistory(admuid,actclass,dataid,remark,createdate) values(@uId,@actId,@dataId,@remark,getdate())", pam);
        }
        #endregion

    }
}

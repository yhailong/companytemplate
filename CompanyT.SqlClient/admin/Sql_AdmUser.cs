/*系统自动生成的 sql server 版数据库操作类
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
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CompanyT.Entity;
using System.Reflection;
using YUTIAN.Tools;

namespace CompanyT.SqlClient
{
    public class Sql_AdmUser : SqlBase<AdmUser>
    {

        #region 人工定义方法 by  
        public int CheckUser(string UserName, string UserPassword, string CurrentIp, out DataTable dtUser)
        {
            UserName = CFun.VerifySQL(UserName);
            int loginRate = 0;
            int loginState = 0;
            string SqlStr = "";
            SqlParameter[] pam = new SqlParameter[3];
            pam[0] = new SqlParameter("@userName", UserName);
            pam[1] = new SqlParameter("@userPassword", UserPassword);
            pam[2] = new SqlParameter("@logninIP", CurrentIp);

            DataSet dst = ExecSql.GetDataSetByStoredProcedure("[AdmUserLogin]", pam);

            loginRate = Convert.ToInt32(dst.Tables[0].Rows[0][0].ToString());
            loginState = Convert.ToInt32(dst.Tables[1].Rows[0][0].ToString());
            dtUser = dst.Tables[2];
            if (loginRate <= 0)
            {
                loginState = -4;
            }
            return loginState;
        }
        #endregion

    }
}

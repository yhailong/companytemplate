﻿/*系统自动生成的 sql server 版业务类
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
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CompanyT.Entity;
using CompanyT.SqlClient;
using YUTIAN.Tools;


namespace CompanyT.Bll
{
    /// <summary>
    /// AdmActHistory 的数据库方法
    /// </summary>
    public class BllAdmActHistory :Bll_Base<AdmActHistory,Sql_AdmActHistory>
    {

       #region  
       /// <summary>
       /// 
       /// </summary>
       public BllAdmActHistory() : base() { }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sqlConn">数据库连接名</param>
       public BllAdmActHistory(string sqlConn) : base(sqlConn) { }
        #endregion


        #region 人工定义方法 by  
        /// <summary>
        /// 保存用户操作历史
        /// </summary>
        /// <param name="uId">操作人员编号</param>
        /// <param name="actId">操作类别id</param>
        /// <param name="remark">备注</param>
        public static void SaveLog(int uId, int actId, int dataId, string remark)
        {
            new Sql_AdmActHistory().SaveLog(uId, actId, dataId, remark);
        }
        #endregion

    }
}

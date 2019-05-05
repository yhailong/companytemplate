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


namespace CompanyT.Bll
{
    /// <summary>
    /// AdmUserModule 的数据库方法
    /// </summary>
    public class BllAdmUserModule :Bll_Base<AdmUserModule,Sql_AdmUserModule>
    {

       #region  
       /// <summary>
       /// 
       /// </summary>
       public BllAdmUserModule() : base() { }
       
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sqlConn">数据库连接名</param>
       public BllAdmUserModule(string sqlConn) : base(sqlConn) { }
       #endregion 


       #region 人工定义方法 by  

       #endregion 

    }
}

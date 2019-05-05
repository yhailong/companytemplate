/*系统所需基类
* 开发时间：2013-11-1
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
using YUTIAN.Tools;
using System.Data;
using System.Data.SqlClient;
using CompanyT.Entity;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;

namespace CompanyT.SqlClient
{
    public class SqlBase<T> : ISqlFunction<T>
    {
        protected string SqlString = "";
        protected string sqlConn = CFun.GetAppStr("newconnstring");
        public string tableName = "";

        public SqlBase()
        {
            tableName = typeof(T).Name;
        }

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="con"></param>
        public void SetSqlConn(string con)
        {
            if (con != "")
            {
                sqlConn = CFun.GetAppStr(con);
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strColumn">查询的字段名,空则返回全部</param>
        /// <param name="currentPage"></param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="pageCount">返回页数总数</param>
        /// <param name="recordCount">返回记录总数</param>
        /// <returns></returns>
        public List<T> GetAllByPage(string strColumn, int currentPage, string strWhere, string orderBy, out int pageCount, out int recordCount)
        {
            pageCount = 1;
            List<T> allLog = ExecSqlConn.GetTableList<T>(tableName, strColumn, orderBy, "Ld", CFun.pagesize(), currentPage, strWhere, sqlConn, out recordCount);
            pageCount = CFun.pagecount(recordCount);
            return allLog;
        }

        


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strColumn">查询的字段名,空则返回全部</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="pageCount">返回页数总数</param>
        /// <param name="recordCount">返回记录总数</param>
        /// <returns></returns>
        public List<T> GetAllByPage(string strColumn, int pageSize, int currentPage, string strWhere, string orderBy, out int pageCount, out int recordCount)
        {
            pageCount = 1;
            List<T> allLog = ExecSqlConn.GetTableList<T>(tableName, strColumn, orderBy, "Ld", pageSize, currentPage, strWhere,sqlConn, out recordCount);
            pageCount = CFun.pagecount(recordCount);
            return allLog;
        }


        /// <summary>
        /// 返回所有符合条件的信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序规则</param>
        /// <param name="pam">参数列</param>
        /// <returns></returns>
        public List<T> GetAll(string strWhere, string orderBy, params SqlParameter[] pam)
        {
            if (strWhere != "")
                SqlString = "select * from " + tableName + " where " + strWhere;
            else
                SqlString = "select * from " + tableName + " ";
            if (orderBy != "")
                SqlString += " order by " + orderBy;
            try
            {
                return ExecSqlConn.GetTableList<T>(SqlString,sqlConn, pam);
            }
            catch { return null; }
        }


        /// <summary>
        /// 返回一条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetItem(int id)
        {
            try
            {
                return ExecSqlConn.GetTableList<T>("select * from " + tableName + " where Ld=" + id.ToString() + "",sqlConn)[0];
            }
            catch { return default(T); }
        }


        #region 删除
        /// <summary>
        /// 删除符合条件的信息
        /// </summary>
        /// <param name="strWhere">条件表达式</param>
        /// <param name="pam">参数列</param>
        /// <returns></returns>
        public bool DeleteItem(string strWhere, params SqlParameter[] pam)
        {
            if (pam == null)
            {
                return (ExecSqlConn.SqlExecNoquery("delete from " + tableName + " where " + strWhere,sqlConn) > 0) ? true : false;
            }
            else
            {
                return (ExecSqlConn.SqlExecNoquery("delete from " + tableName + " where " + strWhere,sqlConn, pam) > 0) ? true : false;
            }
        }


        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteItem(int id)
        {
            return (ExecSqlConn.SqlExecNoquery("delete from " + tableName + " where Ld=" + id.ToString(),sqlConn) > 0) ? true : false;
        }


        /// <summary>
        /// 删除一批数据
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteItem(string idList)
        {
            idList = CFun.RegularIdlist(idList, true);
            return (ExecSqlConn.SqlExecNoquery("delete from " + tableName + " where Ld in (" + idList + ")",sqlConn) > 0) ? true : false;
        }
        #endregion


        /// <summary>
        /// 新增或修改一条信息
        /// </summary>
        /// <param name="_UserModule"></param>
        /// <returns></returns>
        public bool InsertOrUpdate(T _UserModule)
        {
            return ExecSqlConn.InsertOrUpdateData<T>(_UserModule,sqlConn);
        }


        /// <summary>
        /// 新增或修改一条信息
        /// </summary>
        /// <param name="_UserModule"></param>
        /// <param name="id">返回自动编号的值</param>
        /// <returns></returns>
        public bool InsertOrUpdate(T _UserModule, out int id)
        {
            return ExecSqlConn.InsertOrUpdateData<T>(_UserModule,sqlConn, out id);
        }


        /// <summary>
        /// 新增或修改一条信息
        /// </summary>
        /// <param name="_UserModule">实体类</param>
        /// <param name="Expired">返回是否过期</param>
        /// <returns></returns>
        public bool InsertOrUpdate(T _UserModule, out bool Expired)
        {
            Expired = false;
            string idStr = "";
            PropertyInfo p = typeof(T).GetProperty("LastDate");
            if (p != null)
            {
                try
                {
                    object obj = p.GetValue(_UserModule, null);
                    if (obj != null)
                    {
                        DateTime lastDate = (DateTime)obj;
                        if (lastDate != null)
                        {
                            PropertyInfo p1 = typeof(T).GetProperty("Ld");
                            if (p1 != null)
                            {
                                object obj1 = p1.GetValue(_UserModule, null);
                                if (obj1 != null)
                                {
                                    idStr = ((Int32)obj1).ToString();
                                    string dataLastDate = ExecSql.GetDataSet("select LastDate from " + tableName + " where Ld=" + idStr).Tables[0].Rows[0][0].ToString();
                                    if (dataLastDate != "")
                                    {
                                        DateTime nDate = Convert.ToDateTime(dataLastDate);
                                        if (nDate > lastDate)
                                        {
                                            Expired = true;
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            return ExecSqlConn.InsertOrUpdateData<T>(_UserModule,sqlConn);
        }



        #region DataSet 老方法
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="Fields">查询的字段列</param>
        /// <param name="page">当前页数</param>
        /// <param name="StrWhere">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <param name="KeyName">主键</param>
        /// <returns></returns>
        public DataSet GetAllByPage(string strColumn, int currentPage, string strWhere, string orderBy, string keyName)
        {
            return ExecSqlConn.AddParamFrKeyField(tableName, strColumn, orderBy, keyName, CFun.pagesize(), currentPage, strWhere,sqlConn);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="Fields">查询的字段列</param>
        /// <param name="page">当前页数</param>
        /// <param name="StrWhere">查询条件</param>
        /// <param name="OrderBy">排序条件</param>
        /// <param name="KeyName">主键</param>
        /// <returns></returns>
        public DataSet GetAllByPage(string strColumn, int currentPage,int pageSize, string strWhere, string orderBy, string keyName)
        {
            return ExecSqlConn.AddParamFrKeyField(tableName, strColumn, orderBy, keyName, pageSize, currentPage, strWhere,sqlConn);
        }

        /// <summary> 
        /// 获取指定内容 
        /// </summary> 
        /// <param name="Fields">指定字段</param> 
        /// <param name="StrWhere">条件</param> 
        /// <param name="OrderBy">排序规则</param> 
        /// <param name="Totals">记录条数，默认0=全部</param> 
        /// <returns></returns> 
        public DataTable GetAll(string strColumn, string strWhere, string orderBy, int totalRecord)
        {
            SqlString = "select ";
            if (totalRecord > 0)
                SqlString += " top " + totalRecord.ToString();
            SqlString += " " + strColumn + " from " + tableName + " ";
            if (strWhere != "")
                SqlString += " where " + strWhere;
            if (orderBy != "")
                SqlString += " order by " + orderBy;

            return ExecSqlConn.GetDataSet(SqlString,sqlConn).Tables[0];
        }
        #endregion 


    

        
    }
}

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
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YUTIAN.Tools;
using CompanyT.Entity;

namespace CompanyT.Bll
{
    public class Bll_Base<TModule, TSqlClient>
    where TSqlClient : ISqlFunction<TModule>, new()//定义类型T的约束，表示T类型必须有不带参数的构造函数
    where TModule:class
    {
        /// <summary>
        /// 数据库连接名
        /// </summary>
        public string sqlConn = "";

        public Bll_Base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCon">数据库连接名</param>
        public Bll_Base(string sqlCon)
        {
            sqlConn = sqlCon;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strColumn">查询的字段名，空则返回全部</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<TModule> GetAllByPage(string strColumn, int currentPage, string strWhere, string orderBy, out int pageCount, out int recordCount)
        {
            if (strWhere == "")
                strWhere = " 1=1 ";
            if (strColumn == "")
                strColumn = " * ";
            if (orderBy == "")
                orderBy = " ld desc ";

            TSqlClient tSqlClient= new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAllByPage(strColumn, currentPage, strWhere, orderBy, out pageCount, out recordCount);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strColumn">查询的字段名，空则返回全部</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<TModule> GetAllByPage(string strColumn, int pageSize,int currentPage, string strWhere, string orderBy, out int pageCount, out int recordCount)
        {
            if (strWhere == "")
                strWhere = " 1=1 ";
            if (strColumn == "")
                strColumn = " * ";
            if (orderBy == "")
                orderBy = " id desc ";

            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAllByPage(strColumn, pageSize, currentPage, strWhere, orderBy, out pageCount, out recordCount);
        }


        /// <summary>
        /// 获得所有符合条件的记录
        /// </summary>
        /// <param name="strSearch">查询条件</param>
        /// <returns></returns>
        public List<TModule> GetItem(string strSearch)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAll(strSearch, "");
        }


        /// <summary>
        /// 获得所有符合条件的记录
        /// </summary>
        /// <param name="strSearch">查询条件</param>
        /// <param name="pam">参数列</param>
        /// <returns></returns>
        public List<TModule> GetItem(string strSearch, params SqlParameter[] pam)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAll(strSearch, "", pam);
        }


        /// <summary>
        /// 获得所有符合条件的记录
        /// </summary>
        /// <param name="strSearch">查询条件</param>
        /// <param name="orderBy">排序规则</param>
        /// <param name="pam">参数列</param>
        /// <returns></returns>
        public List<TModule> GetItem(string strSearch, string orderBy, params SqlParameter[] pam)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAll(strSearch, orderBy, pam);
        }


        /// <summary>
        /// 获得所有符合条件的记录
        /// </summary>
        /// <param name="strSearch">查询条件</param>
        /// <param name="orderBy">排序规则</param>
        /// <returns></returns>
        public List<TModule> GetItem(string strSearch, string orderBy)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAll(strSearch, orderBy);
        }


        /// <summary>
        /// 获得一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TModule GetItem(int id)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetItem(id);
        }


        #region 删除
        /// <summary>
        /// 删除符合条件的记录
        /// </summary>
        /// <param name="strWhere">条件表达式</param>
        /// <param name="pam">参数列</param>
        /// <returns></returns>
        public bool DeleteItem(string strWhere, params SqlParameter[] pam)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.DeleteItem(strWhere, pam);
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteItem(int id)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.DeleteItem(id);
        }


        /// <summary>
        /// 删除一系列数据
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteItem(string idList)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.DeleteItem(idList);
        }
        #endregion


        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="_log"></param>
        /// <returns></returns>
        public bool InsertorUpdateitem(TModule DataItem)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.InsertOrUpdate(DataItem);
        }

        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="DataItem">实体类</param>
        /// <param name="Expired">信息是否过期</param>
        /// <returns></returns>
        public bool InsertorUpdateitem(TModule DataItem, out bool Expired)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.InsertOrUpdate(DataItem, out Expired);
        }


        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="DataItem">实体类</param>
        /// <param name="id">返回自动编号id的值</param>
        /// <returns></returns>
        public bool InsertorUpdateitem(TModule DataItem, out int id)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.InsertOrUpdate(DataItem, out id);
        }



        #region DataSet 老方法
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strColumn">查询的字段列</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="keyName">主键</param>
        /// <returns></returns>
        public DataSet GetallByPage(string strColumn, int currentPage, string strWhere, string orderBy, string keyName)
        {
            if (strWhere == "")
                strWhere = " 1=1 ";

            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAllByPage(strColumn, currentPage, strWhere, orderBy, keyName);
        }

        public DataSet GetallByPage(string strColumn, int currentPage,int pageSize, string strWhere, string orderBy, string keyName)
        {
            if (strWhere == "")
                strWhere = " 1=1 ";

            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAllByPage(strColumn, currentPage, pageSize, strWhere, orderBy, keyName);
        }

        /// <summary> 
        /// 获取指定内容 
        /// </summary> 
        /// <param name="strColumn">指定字段</param> 
        /// <param name="strWhere">条件</param> 
        /// <param name="orderBy">排序规则</param> 
        /// <param name="totalRecord">记录条数，默认0=全部</param> 
        /// <returns></returns> 
        public DataTable GetAll(string strColumn, string strWhere, string orderBy, int totalRecord)
        {
            TSqlClient tSqlClient = new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            return tSqlClient.GetAll(strColumn, strWhere, orderBy, totalRecord);
        }

        #endregion


        #region  json 方法
        /// <summary>
        /// 分页查询,返回json数据
        /// </summary>
        /// <param name="strColumn">查询的字段列</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="currentPage">当前页数</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <returns></returns
        public string GetAllByPage(string strColumn, int pageSize, int currentPage, string strWhere, string orderBy)
        {
            int pageCount = 0;
            int recordCount = 0;
            if (strWhere == "")
                strWhere = " 1=1 ";
            if (strColumn == "")
                strColumn = " * ";
            if (orderBy == "")
                orderBy = " ld desc ";

            TSqlClient tSqlClient= new TSqlClient();
            tSqlClient.SetSqlConn(sqlConn);
            List<TModule> contList = tSqlClient.GetAllByPage(strColumn, pageSize, currentPage, strWhere, orderBy, out pageCount, out recordCount);
            StringBuilder rStr = new StringBuilder();
            
            rStr.Append("{\"total\":" + recordCount.ToString() + ",");
            if (contList != null)
            {
                rStr.Append("\"rows\":" + CFun.JsonToString<TModule>(contList));
            }
            else
            {
                rStr.Append("\"rows\":[]");
            }
            rStr.Append("}");
            return rStr.ToString();
        }
        #endregion 
    }
}

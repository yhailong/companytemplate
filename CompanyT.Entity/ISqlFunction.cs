/*系统所需基础接口
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
using System.Data.SqlClient;
using System.Data;

namespace CompanyT.Entity
{
    public interface ISqlFunction<T>
    {
        void SetSqlConn(string con);
        List<T> GetAllByPage(string strColumn, int currentPage, string strWhere, string orderBy, out int pageCount, out int recordCount);
        List<T> GetAllByPage(string strColumn, int pageSize, int currentPage, string strWhere, string orderBy, out int pageCount, out int recordCount);
        List<T> GetAll(string strWhere, string orderBy, params SqlParameter[] pam);
        T GetItem(int id);
        bool DeleteItem(string strWhere, params SqlParameter[] pam);
        bool DeleteItem(int id);
        bool DeleteItem(string idList);
        bool InsertOrUpdate(T _UserModule);
        bool InsertOrUpdate(T _UserModule, out bool Expired);
        bool InsertOrUpdate(T _UserModule, out int id);
        DataSet GetAllByPage(string strColumn, int currentPage, string strWhere, string orderBy, string keyName);
        DataSet GetAllByPage(string strColumn, int currentPage,int pageSize, string strWhere, string orderBy, string keyName);
        DataTable GetAll(string strColumn, string strWhere, string orderBy, int totalRecord);
    }
}

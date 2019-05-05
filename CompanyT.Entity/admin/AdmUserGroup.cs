/*系统自动生成的 sql server 版数据库实体类
* 开发时间：2019/4/25 16:00:34
* 版权所有：andy
* 其他联系：
* Email：yhailong@sina.com
* MSN：yhailong@hotmail.com
* QQ:9502855
* 声明：仅限于您自己使用，不得进行商业传播，违者必究！
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;
using YUTIAN.Tools;

namespace CompanyT.Entity
{
    #region AdmUserGroup
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("AdmUserGroup")]
    [DataContract]
    public class AdmUserGroup
   {


        #region 公共属性 


         /// <summary>
         /// 自动编号
         /// </summary>
         [DataFieldAttribute("Ld", "pk")]
         [DataMember]
         public int? Ld
         {
             get ;
             set ;
         }

         /// <summary>
         /// 组编号
         /// </summary>
         [DataFieldAttribute("GroupId")]
         [DataMember]
         public int? GroupId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 组名
         /// </summary>
         [DataFieldAttribute("Name")]
         [DataMember]
         public string Name
         {
             get ;
             set ;
         }

         /// <summary>
         /// 创建时间
         /// </summary>
         [DataFieldAttribute("CreateDate")]
         [DataMember]
         public DateTime? CreateDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 最后修改时间
         /// </summary>
         [DataFieldAttribute("LastDate")]
         [DataMember]
         public DateTime? LastDate
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

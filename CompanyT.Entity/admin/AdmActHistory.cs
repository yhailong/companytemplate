/*系统自动生成的 sql server 版数据库实体类
* 开发时间：2019/4/25 16:00:33
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
    #region AdmActHistory
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("AdmActHistory")]
    [DataContract]
    public class AdmActHistory
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
         /// 操作类型
         /// </summary>
         [DataFieldAttribute("ActClass")]
         [DataMember]
         public int? ActClass
         {
             get ;
             set ;
         }

         /// <summary>
         /// 数据编号
         /// </summary>
         [DataFieldAttribute("DataId")]
         [DataMember]
         public Int64? DataId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 操作员编号
         /// </summary>
         [DataFieldAttribute("AdmUId")]
         [DataMember]
         public int? AdmUId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 备注
         /// </summary>
         [DataFieldAttribute("Remark")]
         [DataMember]
         public string Remark
         {
             get ;
             set ;
         }

         /// <summary>
         /// 记录时间
         /// </summary>
         [DataFieldAttribute("CreateDate")]
         [DataMember]
         public DateTime? CreateDate
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

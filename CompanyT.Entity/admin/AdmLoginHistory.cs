/*系统自动生成的 sql server 版数据库实体类
* 开发时间：2019/5/5 16:52:52
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
    #region AdmLoginHistory
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("AdmLoginHistory")]
    [DataContract]
    public class AdmLoginHistory
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
         /// 用户编号
         /// </summary>
         [DataFieldAttribute("UId")]
         [DataMember]
         public int? UId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登陆时间
         /// </summary>
         [DataFieldAttribute("CreateDate")]
         [DataMember]
         public DateTime? CreateDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// ip
         /// </summary>
         [DataFieldAttribute("Ip")]
         [DataMember]
         public string Ip
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

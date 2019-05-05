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
    #region UserLoginLog
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("UserLoginLog")]
    [DataContract]
    public class UserLoginLog
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
         /// 登录时间
         /// </summary>
         [DataFieldAttribute("LogDate")]
         [DataMember]
         public DateTime? LogDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登录类型（1=web\0=app）
         /// </summary>
         [DataFieldAttribute("LogType")]
         [DataMember]
         public int? LogType
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登录ip
         /// </summary>
         [DataFieldAttribute("LogIp")]
         [DataMember]
         public string LogIp
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登录来源
         /// </summary>
         [DataFieldAttribute("LogFrom")]
         [DataMember]
         public string LogFrom
         {
             get ;
             set ;
         }

         /// <summary>
         /// 其他说明
         /// </summary>
         [DataFieldAttribute("Comment")]
         [DataMember]
         public string Comment
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

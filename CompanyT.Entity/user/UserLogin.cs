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
    #region UserLogin
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("UserLogin")]
    [DataContract]
    public class UserLogin
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
         /// 登录名
         /// </summary>
         [DataFieldAttribute("LogName")]
         [DataMember]
         public string LogName
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登录密码
         /// </summary>
         [DataFieldAttribute("LogPass")]
         [DataMember]
         public string LogPass
         {
             get ;
             set ;
         }

         /// <summary>
         /// 用户状态
         /// </summary>
         [DataFieldAttribute("Status")]
         [DataMember]
         public int? Status
         {
             get ;
             set ;
         }

         /// <summary>
         /// 
         /// </summary>
         [DataFieldAttribute("CheckCode")]
         [DataMember]
         public string CheckCode
         {
             get ;
             set ;
         }

         /// <summary>
         /// 
         /// </summary>
         [DataFieldAttribute("CheckCodeLastDate")]
         [DataMember]
         public DateTime? CheckCodeLastDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 0：本地注册用户 1:微博用户 2：qq用户 3：微信用户
         /// </summary>
         [DataFieldAttribute("UserFrom")]
         [DataMember]
         public int? UserFrom
         {
             get ;
             set ;
         }

         /// <summary>
         /// 用户禁用到期时间
         /// </summary>
         [DataFieldAttribute("LimitDate")]
         [DataMember]
         public DateTime? LimitDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 所属区(0-9)
         /// </summary>
         [DataFieldAttribute("BaseId")]
         [DataMember]
         public int? BaseId
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

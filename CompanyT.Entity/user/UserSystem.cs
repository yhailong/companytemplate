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
    #region UserSystem
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("UserSystem")]
    [DataContract]
    public class UserSystem
   {


        #region 公共属性 


         /// <summary>
         /// 用户ID
         /// </summary>
         [DataFieldAttribute("UId", "pk")]
         [DataMember]
         public int? UId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 注册日期
         /// </summary>
         [DataFieldAttribute("RegDate")]
         [DataMember]
         public DateTime? RegDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 上次登录日期
         /// </summary>
         [DataFieldAttribute("LastDate")]
         [DataMember]
         public DateTime? LastDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 上次登录地址
         /// </summary>
         [DataFieldAttribute("LastAddress")]
         [DataMember]
         public string LastAddress
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登录总次数
         /// </summary>
         [DataFieldAttribute("LogTotal")]
         [DataMember]
         public int? LogTotal
         {
             get ;
             set ;
         }

         /// <summary>
         /// 介绍人编号
         /// </summary>
         [DataFieldAttribute("ParentId")]
         [DataMember]
         public int? ParentId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 是否开通推介服务 0=没开通 1=开通
         /// </summary>
         [DataFieldAttribute("PassRecommend")]
         [DataMember]
         public int? PassRecommend
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

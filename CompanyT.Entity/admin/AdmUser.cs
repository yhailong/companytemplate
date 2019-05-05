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
    #region AdmUser
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("AdmUser")]
    [DataContract]
    public class AdmUser
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
         [DataFieldAttribute("UName")]
         [DataMember]
         public string UName
         {
             get ;
             set ;
         }

         /// <summary>
         /// 登录密码
         /// </summary>
         [DataFieldAttribute("UPassword")]
         [DataMember]
         public string UPassword
         {
             get ;
             set ;
         }

         /// <summary>
         /// 真实姓名
         /// </summary>
         [DataFieldAttribute("TrueName")]
         [DataMember]
         public string TrueName
         {
             get ;
             set ;
         }

         /// <summary>
         /// 职务组长or组员
         /// </summary>
         [DataFieldAttribute("UPost")]
         [DataMember]
         public int? UPost
         {
             get ;
             set ;
         }

         /// <summary>
         /// 联系方式
         /// </summary>
         [DataFieldAttribute("Contact")]
         [DataMember]
         public string Contact
         {
             get ;
             set ;
         }

         /// <summary>
         /// 所属组
         /// </summary>
         [DataFieldAttribute("GroupIdList")]
         [DataMember]
         public string GroupIdList
         {
             get ;
             set ;
         }

         /// <summary>
         /// 最后登录时间
         /// </summary>
         [DataFieldAttribute("LastLoginDate")]
         [DataMember]
         public DateTime? LastLoginDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 最后登录ip
         /// </summary>
         [DataFieldAttribute("LastLoginIp")]
         [DataMember]
         public string LastLoginIp
         {
             get ;
             set ;
         }

         /// <summary>
         /// 最后登录错误时间
         /// </summary>
         [DataFieldAttribute("LastFalseDateTime")]
         [DataMember]
         public DateTime? LastFalseDateTime
         {
             get ;
             set ;
         }

         /// <summary>
         /// 可用登陆次数
         /// </summary>
         [DataFieldAttribute("AvailableTimes")]
         [DataMember]
         public int? AvailableTimes
         {
             get ;
             set ;
         }

         /// <summary>
         /// 状态
         /// </summary>
         [DataFieldAttribute("Status")]
         [DataMember]
         public int? Status
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

         /// <summary>
         /// 登录校验码(用于判断是否需要重新登录)
         /// </summary>
         [DataFieldAttribute("CheckCode")]
         [DataMember]
         public int? CheckCode
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

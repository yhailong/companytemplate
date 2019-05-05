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
    #region UserDetail
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("UserDetail")]
    [DataContract]
    public class UserDetail
   {


        #region 公共属性 


         /// <summary>
         /// 用户编号
         /// </summary>
         [DataFieldAttribute("UId", "pk")]
         [DataMember]
         public int? UId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 用户昵称
         /// </summary>
         [DataFieldAttribute("LogName")]
         [DataMember]
         public string LogName
         {
             get ;
             set ;
         }

         /// <summary>
         /// 用户头像
         /// </summary>
         [DataFieldAttribute("LogoImg")]
         [DataMember]
         public string LogoImg
         {
             get ;
             set ;
         }

         /// <summary>
         /// 用户真实姓名
         /// </summary>
         [DataFieldAttribute("Name")]
         [DataMember]
         public string Name
         {
             get ;
             set ;
         }

         /// <summary>
         /// 身份证号码
         /// </summary>
         [DataFieldAttribute("CardNumber")]
         [DataMember]
         public string CardNumber
         {
             get ;
             set ;
         }

         /// <summary>
         /// 真实性别
         /// </summary>
         [DataFieldAttribute("Garder")]
         [DataMember]
         public int? Garder
         {
             get ;
             set ;
         }

         /// <summary>
         /// 手机号码
         /// </summary>
         [DataFieldAttribute("Mobile")]
         [DataMember]
         public string Mobile
         {
             get ;
             set ;
         }

         /// <summary>
         /// 出生年月日
         /// </summary>
         [DataFieldAttribute("Birthday")]
         [DataMember]
         public DateTime? Birthday
         {
             get ;
             set ;
         }

         /// <summary>
         /// qq
         /// </summary>
         [DataFieldAttribute("QQ")]
         [DataMember]
         public string QQ
         {
             get ;
             set ;
         }

         /// <summary>
         /// msn
         /// </summary>
         [DataFieldAttribute("MSN")]
         [DataMember]
         public string MSN
         {
             get ;
             set ;
         }

         /// <summary>
         /// email
         /// </summary>
         [DataFieldAttribute("EMail")]
         [DataMember]
         public string EMail
         {
             get ;
             set ;
         }

         /// <summary>
         /// 其他网上联系方式
         /// </summary>
         [DataFieldAttribute("Other")]
         [DataMember]
         public string Other
         {
             get ;
             set ;
         }

         /// <summary>
         /// 受教育程度
         /// </summary>
         [DataFieldAttribute("Education")]
         [DataMember]
         public int? Education
         {
             get ;
             set ;
         }

         /// <summary>
         /// 职业
         /// </summary>
         [DataFieldAttribute("Work")]
         [DataMember]
         public int? Work
         {
             get ;
             set ;
         }

         /// <summary>
         /// 收入
         /// </summary>
         [DataFieldAttribute("Sale")]
         [DataMember]
         public int? Sale
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

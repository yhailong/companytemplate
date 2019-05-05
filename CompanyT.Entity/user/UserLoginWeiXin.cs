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
    #region UserLoginWeiXin
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("UserLoginWeiXin")]
    [DataContract]
    public class UserLoginWeiXin
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
         /// 微信用户编号
         /// </summary>
         [DataFieldAttribute("WXUId")]
         [DataMember]
         public string WXUId
         {
             get ;
             set ;
         }

         /// <summary>
         /// 微信昵称
         /// </summary>
         [DataFieldAttribute("WXNiceName")]
         [DataMember]
         public string WXNiceName
         {
             get ;
             set ;
         }

         /// <summary>
         /// 本地用户编号
         /// </summary>
         [DataFieldAttribute("UId")]
         [DataMember]
         public int? UId
         {
             get ;
             set ;
         }

         /// <summary>
         /// Token
         /// </summary>
         [DataFieldAttribute("Token")]
         [DataMember]
         public string Token
         {
             get ;
             set ;
         }

         /// <summary>
         /// 有效期至
         /// </summary>
         [DataFieldAttribute("ExpDate")]
         [DataMember]
         public DateTime? ExpDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 创建日期
         /// </summary>
         [DataFieldAttribute("CreateDate")]
         [DataMember]
         public DateTime? CreateDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 最后登录日期
         /// </summary>
         [DataFieldAttribute("LastDate")]
         [DataMember]
         public DateTime? LastDate
         {
             get ;
             set ;
         }

         /// <summary>
         /// 0=新建  1=正常可登录
         /// </summary>
         [DataFieldAttribute("Status")]
         [DataMember]
         public int? Status
         {
             get ;
             set ;
         }

         /// <summary>
         /// 刷新token
         /// </summary>
         [DataFieldAttribute("refreshToken")]
         [DataMember]
         public string refreshToken
         {
             get ;
             set ;
         }

         /// <summary>
         /// 
         /// </summary>
         [DataFieldAttribute("unionId")]
         [DataMember]
         public string unionId
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

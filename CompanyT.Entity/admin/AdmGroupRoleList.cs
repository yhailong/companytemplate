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
    #region AdmGroupRoleList
    /// <summary>
    /// 
    /// </summary>
    [DataFieldAttribute("AdmGroupRoleList")]
    [DataContract]
    public class AdmGroupRoleList
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
         /// 权限编号
         /// </summary>
         [DataFieldAttribute("KeyCode")]
         [DataMember]
         public string KeyCode
         {
             get ;
             set ;
         }

         /// <summary>
         /// 权限级别0:查1:增 2:删3:改
         /// </summary>
         [DataFieldAttribute("KeyClass")]
         [DataMember]
         public int? KeyClass
         {
             get ;
             set ;
         }



        #endregion


    }
    #endregion
}

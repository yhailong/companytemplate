using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using YUTIAN.Tools;
using System.Text.RegularExpressions;
using MSXML2;
using System.Web;
using System.Collections;
using CompanyT.Entity;
using System.Drawing.Drawing2D;

namespace CompanyT.Bll
{
    /// <summary>
    /// 一些公用方法
    /// </summary>
    public class BaseFun
    {
        public static bool StrIsUName(string uName)
        {
            Regex r = new Regex("[a-zA-Z0-9_]{5,15}");
            return r.IsMatch(uName);
        }

        public static bool StrIsUPass(string uPass)
        {
            Regex r = new Regex("[a-zA-Z0-9_]{5,15}");
            return r.IsMatch(uPass);
        }



        public static string GUKey(string str)
        {
            str = CFun.MD5("B" + str);
            return str.TrimStart(new char[] { '0' });
        }

        /// <summary>
        /// web 校验字符串(和shuchuyc项目保持一致)
        /// </summary>
        /// <param name="uId">用户id</param>
        /// <returns></returns>
        public static string WebGUKey(int uId)
        {
            string str = CFun.MD5("w" + uId);
            return str.Substring(2, 5);
        }

        /// <summary>
        /// 获取图片并保存本地，以月份为单位保存
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetImg(string url, string fileDir, int bookLd, string imgName)
        {
            try
            {
                string newUrl = "/upload/book/" + bookLd + "/";
                string outUrl = newUrl;
                newUrl = fileDir + newUrl;
                if (!Directory.Exists(newUrl))
                {
                    Directory.CreateDirectory(newUrl);
                }

                if (url.Equals(""))
                {
                    return "";
                }

                string defaultType = ".jpg";
                string[] imgTypes = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                string imgType = url.ToString().Substring(url.ToString().LastIndexOf("."));
                foreach (string it in imgTypes)
                {
                    if (imgType.ToLower().Equals(it))
                        break;
                    if (it.Equals(".bmp"))
                        imgType = defaultType;
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/6.0 (MSIE 6.0; Windows NT 5.1; Natas.Robot)";
                request.Timeout = 3000;

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();

                if (response.ContentType.ToLower().StartsWith("image/"))
                {
                    byte[] arrayByte = new byte[1024];
                    int imgLong = (int)response.ContentLength;
                    int l = 0;
                    newUrl = newUrl + imgName + imgType;
                    outUrl = outUrl + imgName + imgType;
                    FileStream fso = new FileStream(newUrl, FileMode.Create);
                    while (l < imgLong)
                    {
                        int i = stream.Read(arrayByte, 0, 1024);
                        fso.Write(arrayByte, 0, i);
                        l += i;
                    }

                    fso.Close();
                    stream.Close();
                    response.Close();

                    return outUrl;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 保存内容到文件
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="fileDir">路径（绝对路径）</param>
        /// <returns></returns>
        public static bool SaveFile(string content, string filePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
                sw.Write(content);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 读文件中的字符串
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            string str = "", tempStr = "";
            while ((str = sr.ReadLine()) != null)
            {
                tempStr = tempStr + str + "\r\n";
            }
            sr.Close();
            return tempStr;
        }


        /// <summary>
        /// 生成价格
        /// </summary>
        /// <param name="txtLength">字数</param>
        /// <param name="unitPrice">每千字价格，分</param>
        /// <returns></returns>
        public static int CreatePrice(int txtLength, int unitPrice)
        {
            float f = txtLength;
            f = f / 1000 * unitPrice;
            return (int)Math.Round(f, 0);

        }

        public static int GetNeed(string str)
        {
            if (str == null)
            {
                return 0;
            }
            if (str.IndexOf("微博") > 0)
            {
                return 1;
            }
            else
            {
                Regex r = new Regex("(\\d{5,20})");
                if (r.Match(str).Value != "")
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 上传图片返回 0则超过规定大小；1文件格式错误；
        /// </summary>
        /// <param name="files">文件框名称</param>
        /// <param name="paths">上传文件路径，url</param>
        /// <param name="fmax">文件的最大值，单位为字节</param>
        /// <param name="ftype">类型：1表示图片；0表示所有文件</param>
        /// <returns></returns>
        public static string upfiles(System.Web.UI.HtmlControls.HtmlInputFile files, string paths, long fmax, string ftype, string fileName)
        {

            //files 文件上传组件的名称；paths 要上传到的目录;fmax是上传文件最大值；ftype是上传文件的类型
            //默认上传文件最大值100k,文件类型为所有文件
            //1为图片jpg or gif；0为所有文件
            //如果文件大于设定值，返回代码0
            //如果文件类型错误，返回代码1
            //初始化
            long fileMax = 100000;
            string fileType = "0";
            string fileTypet = "";

            fileMax = fmax;
            fileType = ftype;



            if (files.PostedFile.ContentLength > fileMax)
            {
                return "0";
                //返回错误代码，结束程序
            }

            fileTypet = System.IO.Path.GetExtension(files.PostedFile.FileName).ToLower();
            if (fileType == "1")
            {
                if (fileTypet != ".jpg" && fileTypet != ".jpeg" && fileTypet != ".gif")
                {
                    return "1";
                    //返回错误代码，结束程序
                }
            }
            string destdir = System.Web.HttpContext.Current.Server.MapPath(paths);
            if (!Directory.Exists(destdir))
            {
                Directory.CreateDirectory(destdir);
            }
            string filename = fileName + fileTypet;
            string destpath = System.IO.Path.Combine(destdir, filename);

            //检查是否有名称重复,如果重复就在前面加从0开始的数字
            int i = 0;
            string tempfilename = filename;

            //没有重复，保存文件
            files.PostedFile.SaveAs(destpath);
            //返回文件名称
            return tempfilename;
        }



        public static string GetUrlInfo(string zheUrl, Encoding ecode)
        {
            try
            {
                Uri uri = new Uri(zheUrl);
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
                myReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
                myReq.Accept = "*/*";
                myReq.KeepAlive = true;
                myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();

                Stream s = result.GetResponseStream();
                StreamReader sr = new StreamReader(s, ecode);
                string str = sr.ReadToEnd();

                result.Close();
                myReq.Abort();
                return str;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string GetSinaValue(string url)
        {
            ServerXMLHTTP xmlhttp = new ServerXMLHTTP();
            string errmsg = "";
            string responsejson = "";
            string jsonurl = url;
            try
            {
                xmlhttp.open("GET", jsonurl, false, null, null);
                xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                xmlhttp.send("");

                if (xmlhttp.readyState == 4)
                {
                    if (xmlhttp.responseText.Trim() != "")
                    {
                        responsejson = xmlhttp.responseText;
                    }
                    else
                    {
                        responsejson = "";
                        errmsg = "ErrEmpty";
                    }
                }
            }
            catch
            {
                errmsg = "ErrConnect";

            }
            finally { xmlhttp.abort(); }

            if (errmsg != "")
            {
                return errmsg;
            }
            else
            {
                return responsejson;
            }
        }

        public static string GetSinaValue(string url,string sendData)
        {
            ServerXMLHTTP xmlhttp = new ServerXMLHTTP();
            string errmsg = "";
            string responsejson = "";
            string jsonurl = url;
            try
            {
                xmlhttp.open("POST", jsonurl, false, null, null);
                xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                xmlhttp.send(sendData);

                if (xmlhttp.readyState == 4)
                {
                    if (xmlhttp.responseText.Trim() != "")
                    {
                        responsejson = xmlhttp.responseText;
                    }
                    else
                    {
                        responsejson = "";
                        errmsg = "ErrEmpty";
                    }
                }
            }
            catch
            {
                errmsg = "ErrConnect";

            }
            finally { xmlhttp.abort(); }

            if (errmsg != "")
            {
                return errmsg;
            }
            else
            {
                return responsejson;
            }
        }


        public static bool IsGuid(string strSrc)
        {

            Regex reg = new Regex("^[a-f0-9]{8}(-[a-f0-9]{4}){3}-[a-f0-9]{12}$", RegexOptions.Compiled);

            return reg.IsMatch(strSrc);

        }


        /// <summary>
        /// 获取时间差的描述
        /// </summary>
        /// <param name="startTime">小</param>
        /// <param name="endTime">大</param>
        /// <returns></returns>
        public static string GetDateTimeDiff(DateTime startTime, DateTime endTime)
        {
            try
            {
                TimeSpan ts = endTime - startTime;

                int difference = Convert.ToInt32(ts.TotalMinutes);

                if (difference == 0)
                {
                    return "（刚刚更新）";
                }
                else if (difference < 60)
                {
                    return "（" + difference + "分钟前更新）";
                }
                else if (difference < 1440)
                {
                    return "（1小时前更新）";
                }
                else
                {
                    return "（更新时间：" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "）";
                }
            }
            catch
            {
            }
            return "（1月前更新）";

        }

        /// <summary>
        /// 获取时间之间的分钟数
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static int GetDateTimeDiffMinutes(DateTime startTime, DateTime endTime)
        {
            try
            {
                TimeSpan ts = endTime - startTime;

                int difference = Convert.ToInt32(ts.TotalMinutes);

                return difference;
            }
            catch
            {
            }
            return 0;

        }

        /// <summary>
        /// 将10位时间戳砖换成时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime TimestampToDate(int time)
        {
            DateTime d = ((new DateTime(1970, 1, 1))).AddHours(8);//1970-1-1 08:00:00
            //加上秒数
            d = d.AddSeconds(time);
            return d;
        }

       
        /// <summary>
        /// 订阅日志用户分库（10个）
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public static int GetUBaseLog(int uId)
        {
            return uId % 10;
        }

        /// <summary>
        /// 存储用户分区信息
        /// </summary>
        public static Hashtable UBaseNew = new Hashtable();



        /// <summary>
        /// 获取订阅记录表的全局唯一编号
        /// </summary>
        /// <param name="databaseNo">数据库编号0-19</param>
        /// <param name="tableNo">数据表编号 0-9</param>
        /// <returns></returns>
        public static int GetBookingTableNo(int databaseNo, int tableNo)
        {
            return (100 + databaseNo) * 10 + tableNo;
        }

        public static int GetSignMoney()
        {
            //3 66%
            //5 30%
            //7 3%
            //9 1%
            int money = 3;
            int k = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);

            if (k < 66)
            {
                money = 3;
            }
            else if (k < 96)
            {
                money = 5;
            }
            else if (k < 99)
            {
                money = 7;
            }
            else
            {
                money = 9;
            }
            return money;
        }


        /// <summary>
        /// 设置永久cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="cookieValue"></param>
        public static void setCookie(string cookieName, string cookieValue)
        {
            HttpCookie co1 = new HttpCookie(cookieName);
            co1.Value = cookieValue;
            co1.Domain = CFun.GetAppStr("webDomain");
            co1.Expires = DateTime.Now.AddYears(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(co1);
        }

        /// <summary>
        /// 判断是否手机浏览器
        /// </summary>
        /// <returns></returns>
        public static bool IsMobile()
        {
            string agent = (HttpContext.Current.Request.UserAgent + "").ToLower().Trim();
            if (agent == "" || agent.IndexOf("mozilla") != -1 || agent.IndexOf("opera") != -1)
                return false;
            return true;
        }

        /// <summary>
        /// 处理手机号码
        /// </summary>
        /// <param name="rStr"></param>
        /// <returns></returns>
        public static string FilterMobile(string rStr)
        {
            if (CFun.strismobile(rStr))
            {
                return rStr.Substring(0, 4) + "****" + rStr.Substring(8, 3);
            }
            else
            {
                return rStr;
            }
        }

        /// <summary>
        /// 生成1分钟过期的加密字符串
        /// </summary>
        /// <param name="key">需要传递的值</param>
        /// <param name="attachKey">约定的附加字符串</param>
        /// <returns></returns>
        public static string GetDesEncryptMinite(int key, string attachKey)
        {
            string t = CFun.GetTimeStamp(DateTime.Now, true);
            decimal t1 = Convert.ToDecimal(t);
            t1 = Math.Round(t1 / 60);
            t = t1.ToString();
            t1 = t1 + key;

            string v = CFun.DESEncrypt(attachKey + t1.ToString() + "," + t, t);
            return v;
        }

        /// <summary>
        /// 获取采集时候新章节的状态，1000（书橱）、1001（红薯） 1005(喵阅读)的状态为1，其他需要审核为0
        /// </summary>
        /// <param name="partnerId">合作商编号</param>
        /// <returns></returns>
        public static int GetPartnerStatus(int partnerId)
        {
            if (partnerId == 1000 || partnerId == 1001 || partnerId == 1007 || partnerId == 1005)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        


       

        /// <summary>
        /// 获取当前的免费活动类别
        /// </summary>
        /// <returns></returns>
        public static int GetFreeActClass()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return (int)EnumFreeBookActClassNew.周一周二;
                case DayOfWeek.Tuesday:
                    return (int)EnumFreeBookActClassNew.周一周二;
                case DayOfWeek.Wednesday:
                    return (int)EnumFreeBookActClassNew.周三周四;
                case DayOfWeek.Thursday:
                    return (int)EnumFreeBookActClassNew.周三周四;
                default:
                    return (int)EnumFreeBookActClassNew.周五到周日;
            }
        }




        
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static string GetSubString(string sourceStr, int total)
        {
            if (sourceStr.Length > total)
            {
                return sourceStr.Substring(0, total - 1) + "……";
            }
            else
            {
                return sourceStr;
            }
        }

        /// <summary>
        /// 过滤书描述种的特殊字符
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetIntroduce(string content)
        {
            content = CFun.CleanHTML(content, 9);
            content = content.Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("　", "") ;
            return content;
        }


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using CompanyT.Bll;

public partial class syscc_checkcode : System.Web.UI.Page
{
    public string GenerateCheckCode()
    {
        int number;
        char code;
        string checkCode = String.Empty;

        System.Random random = new Random();

        for (int i = 0; i < 4; i++)
        {
            number = random.Next();

            code = (char)('0' + (char)(number % 10));


            checkCode += code.ToString();
        }
        return checkCode;
    }

    public Color GetControllableColor(int colorBase)
    {
        Color color = Color.Black;

        Random random = new Random();
        //确保 R,G,B 均大于 colorBase，这样才能保证背景色较浅 
        color = Color.FromArgb(random.Next(56) + colorBase, random.Next(56) + colorBase, random.Next(56) + colorBase);
        return color;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        string checkCode = GenerateCheckCode();
        this.CreateCheckCodeImage(checkCode);
        //Response.Cookies.Add(new HttpCookie("ccodes", checkCode));
        Session.Add("bcode", checkCode);
    }

    private void CreateCheckCodeImage(string checkCode)
    {
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;
        int width = (int)Math.Ceiling((checkCode.Length * 12.1));
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(86, 35); //new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.1)), 20);
        
        Graphics g = Graphics.FromImage(image);

        try
        {
            //生成随机生成器
            Random random = new Random();

            //清空图片背景色
            g.Clear(Color.White);

            for (int i = 0; i < 8; i++)
            {
                Pen backPen = new Pen(GetControllableColor(100), 1);
                //线条起点 
                int x = random.Next(86);
                int y = random.Next(38);
                //线条终点 
                int x2 = random.Next(86);
                int y2 = random.Next(38);
                //划线 
                g.DrawLine(backPen, x, y, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 2.0f, true);
            g.DrawString(checkCode, font, brush, 20, 10);

           

            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
}
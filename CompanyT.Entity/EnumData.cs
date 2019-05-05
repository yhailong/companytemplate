using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyT.Entity
{
    class EnumData
    {
    }

    /// <summary>
    /// 是否状态
    /// </summary>
    public enum TrueOrFalse : int
    {
        否 = 0,
        是 = 1
    }


    /// <summary>
    /// 有无状态
    /// </summary>
    public enum HaveOrNo : int
    {
        无 = 0,
        有 = 1

    }

    /// <summary>
    /// 可用状态
    /// </summary>
    public enum AvailablesStatus : int
    {
        可用 = 1,
        禁用 = 0
    }


    /// <summary>
    /// 后台操作类型
    /// </summary>
    public enum EnumCCActiveClass : int
    {
        用户状态管理 = 50,
        用户密码修改,
        客服人员管理,
        权限组管理,
        全站配置修改,
        修改用户书橱币,
        签约等级修改,
        章节审核 = 100,
        章节修改 = 101
    }

    /// <summary>
    /// 小说大类
    /// </summary>
    public enum EnumBookClass : int
    {
        网络小说 = 1,
        出版小说 = 5
    }

    /// <summary>
    /// 性别类别
    /// </summary>
    public enum EnumSexClass : int
    {
        请选择 = 0,
        男 = 1,
        女 = 2
    }

    /// <summary>
    /// 性别类别
    /// </summary>
    public enum EnumSexClassOnly : int
    {
        男 = 1,
        女 = 2
    }

    /// <summary>
    /// 周
    /// </summary>
    public enum EnumWeekClass : int
    {
        周一 = 1,
        周二 = 2,
        周三 = 3,
        周四 = 4,
        周五 = 5,
        周六 = 6,
        周日 = 7
    }


    /// <summary>
    /// 采集类型
    /// </summary>
    public enum EnumGetClass : int
    {
        增量采集 = 0,
        全部采集 = 1
    }


    /// <summary>
    /// 数据采集类型（接口对应）
    /// </summary>
    public enum EnumGetDataClass : int
    {
        书籍列表 = 1,
        书籍详情 = 2,
        书籍卷信息 = 3,
        书籍章节列表 = 4,
        书籍章节详情 = 5
    }


    /// <summary>
    /// 推荐频道定义
    /// </summary>
    public enum EnumBookChannel : int
    {
        精选 = 1,
        男频 = 2,
        女频 = 3,
        完本 = 4
    }

    /// <summary>
    /// 推荐小类
    /// </summary>
    public enum EnumBookChannelSml : int
    {
        主编推荐 = 1,
        火热推荐 = 2,
        潜力推荐 = 3,
        新书抢鲜 = 4,
        热销红文 = 5,
        排行主编 = 10
    }

    /// <summary>
    /// 图片广告的类别
    /// </summary>
    public enum EnumAdClass : int
    {
        我的书架 = 1,
        书城精品 = 10,
        书城男频 = 11,
        书城女频 = 12,
        书城完本 = 13

    }


    /// <summary>
    /// 搜索内容的类别
    /// </summary>
    public enum EnumSearchKeyWordClass : int
    {
        书名 = 1,
        作者 = 2,
        关键字 = 3
    }

    /// <summary>
    /// 短信类型
    /// </summary>
    public enum EnumSmsClass : int
    {
        注册校验短信 = 1,
        登录校验短信 = 2,
        wap注册校验短信 = 3,
        wap找回密码短信 = 4
    }


    /// <summary>
    /// 33
    /// </summary>
    public enum EnumErrCode : int
    {
        来源错误 = 1,
        需登录 = 2,
        需充值 = 3,
        需提示用户订阅信息 = 4,
        订阅错误 = 5,
        余额不足 = 6,
        章节不存在 = 11,

        //密码相关
        旧密码不匹配 = 7,
        无此用户 = 8,
        //用户注册相关
        用户名重复 = 9,
        安装码错误 = 10,
        邮箱重复 = 21,
        邮箱格式错误 = 22,
        用户名格式错误 = 23,
        密码格式错误 = 24,
        书签已存在 = 25,
        密码错误 = 26,


        用户被停用 = 12,
        用户被禁止访问 = 29,
        短信发送失败 = 13,
        校验码错误 = 14,
        短信校验码错误 = 32,
        校验码过期 = 15,
        用户已绑定手机号 = 16,
        手机号码格式错误 = 17,
        手机号码已绑定 = 27,
        帐号已被绑定 = 28,
        暂不能发表反馈 = 33,
        参数错误 = 34,
        章数不够多章预订 = 35,
        已订阅 = 36,

        无支付类型 = 18,
        用户被禁言 = 19,
        //2015-7-6 新增
        已经点赞 = 20,
        已签到 = 30,
        无权签到 = 31,
        数据库错误 = 50,
        数据已存在 = 51,
        系统维护中 = 60,
        数据不存在 = 61,
        未知错误 = 100,
        暂无数据 = 101,
        系统升级中 = 102,
        成功 = 200

        //28
    }

    /// <summary>
    /// 支付类型
    /// </summary>
    public enum EnumPayClass : int
    {
        支付宝 = 1,
        微信 = 2,
        微信扫码 = 3,
        现在微信 = 4,
        现在微信扫码 = 5,
        现在公众号 = 6,
        PayPal美元 = 50,
        ApplyPay支付 = 7,
        绑定手机奖励 = 100
    }

    /// <summary>
    /// 充值状态
    /// </summary>
    public enum EnumPayStatus : int
    {
        新申请 = 0,
        充值失败 = 2,
        成功 = 3
    }

    /// <summary>
    /// 充值用途类型
    /// </summary>
    public enum EnumPayUsedClass : int
    {
        冲平台币 = 0,
        包月 = 5,
        包年 = 10
    }




    /// <summary>
    /// 书币类型
    /// </summary>
    public enum EnumMoneyClass : int
    {
        购买 = 0,
        赠送 = 1
    }



    /// <summary>
    /// 书籍免费活动类别（新）
    /// </summary>
    public enum EnumFreeBookActClassNew : int
    {
        周一周二 = 151,
        周三周四 = 152,
        周五到周日 = 153
    }


    /// <summary>
    /// app 编号
    /// </summary>
    public enum EnumAppFrom : int
    {
        百看 = 1,
        追阅 = 2,
        百看WAP = 5,
        百看IOS = 6,
        微信小程序 = 7
    }

    /// <summary>
    /// 书橱的来源编号
    /// </summary>
    public enum EnumShuChuFrom : int
    {
        书橱APP = 3,
        书橱WAP = 4,
        书橱原创 = 5,
        书橱IOS = 6,
        微信小程序=7
    }

    /// <summary>
    /// 初阅的来源编号
    /// </summary>
    public enum EnumChuYueFrom : int
    {
        初阅WAP = 13,
        初阅APP = 14,
        初阅原创 = 15,
        初阅IOS = 16,
        微信小程序 = 17
    }

    public enum EnumChannel : int
    {
        百看 = 1,
        书橱 = 2,
        初阅 = 3
    }

    /// <summary>
    /// 全部平台
    /// </summary>
    public enum EnumAllChannel : int
    {
        百看 = 1,
        书橱 = 2,
        初阅 = 3,
        言情梦 = 4,
        言情派 = 5,
        言情志 = 6
    }

    /// <summary>
    /// 用户来源
    /// </summary>
    public enum EnumUserFrom : int
    {
        其他 = 1,
        微博 = 2,
        qq = 3,
        微信 = 4,

        app注册 = 10,
        wap注册 = 11,
        微博绑定 = 12,
        qq绑定 = 13,
        微信绑定 = 14

    }

    /// <summary>
    /// 用户建议状态
    /// </summary>
    public enum EnumUserCommendStatus : int
    {
        新 = 0,
        已处理 = 1,
        已查看 = 2
    }

    /// <summary>
    /// 微信推广账号的类型
    /// </summary>
    public enum EnumWeiXinUserClass : int
    {
        公司号 = 1,
        个人号 = 2
    }

    /// <summary>
    /// 订阅表分表（如果增加，则顺序增加此配置）
    /// </summary>
    public enum EnumBookingTableNo : int
    {
        t0区 = 0,
        t1区 = 1,
        t2区 = 2,
        t3区 = 3,
        t4区 = 4
    }


    /// <summary>
    /// 签到书橱币类型
    /// </summary>
    public enum EnumSignClass : int
    {
        签到获得 = 1,
        充值赠送 = 2
    }


    /// <summary>
    /// 推广渠道类型
    /// </summary>
    public enum EnumChannelAddClass : int
    {
        首选 = 0,
        官方 = 1,
        运营 = 2,
        外部 = 3,
        合作=4
    }

    /// <summary>
    /// 新闻类别
    /// </summary>
    public enum EnumNewsClass : int
    {
        公告 = 1,
        新闻 = 2
    }

    #region 原创
    /// <summary>
    /// 原创首页推荐类别
    /// </summary>
    public enum EnumYCCommentClass : int
    {
        首页大图 = 1,
        首页强推本周 = 2,
        首页强推上周 = 3,
        热门推荐 = 4,
        精品推荐 = 5
    }

    /// <summary>
    /// 原创平台推荐类别
    /// </summary>
    public enum EnumYCBookRankClass : int
    {
        点击榜 = 1,
        推荐榜 = 3,
        新书榜 = 2,
        完结榜 = 8,
        //热销榜 = 4,
        更新榜 = 5,
        收藏榜 = 6,
        评论榜 = 7,
        赞榜 = 9

    }

    #endregion


    /// <summary>
    /// 捧场类型
    /// </summary>
    public enum EnumSupportClass : int
    {
        赠送100书橱币 = 1,
        赠送500书橱币 = 2,
        赠送2000书橱币 = 3,
        赠送5000书橱币 = 4,
        赠送10000书橱币 = 5,
        赠送100000书橱币 = 6
    }

    /// <summary>
    /// 订阅日志库
    /// </summary>
    public enum EnumLogDb : int
    {
        近期订阅 = 0,
        两个月之前 = 1
    }

    /// <summary>
    /// 货币类型
    /// </summary>
    public enum EnumCurrencyType : int
    {
        人民币 = 0,
        美元 = 1
    }

    /// <summary>
    /// 职务类别
    /// </summary>
    public enum EnumUPostClass : int
    {
        组长 = 1,
        组员 = 2
    }

    /// <summary>
    /// 系统栏目类型
    /// </summary>
    public enum AdmModuleTypeID : int
    {
        系统栏目 = 1,
        栏目按钮 = 2
    }

    /// <summary>
    /// 微信账号编码
    /// </summary>
    public enum EnumWeiXinAccount : int
    {
        书橱小说 = 2,
        书橱阅读 = 3,
        书橱看书 = 4,
        倾城阅读 = 5,
        读悦时光 = 6,
        朝夕看书 = 8,
        失眠书单 = 9,
        许你一世花开=10,
        许你一生静好=11,
        人生枕边话=12,
        每周伴你读=13

    }

    /// <summary>
    /// 微信账号编码
    /// </summary>
    public enum EnumWeiXinAccountBK : int
    {
        百看小说 = 1,
        看书生活 = 2,
        闲时看会书 = 3,
        热门小说书单 = 4,
        睡前看会书 = 5,
        百看好书 = 6,
        百看阅读 = 7,
        每周值得看 = 8,
        闲时伴你读 = 9
    }

    /// <summary>
    /// 微信账号编码
    /// </summary>
    public enum EnumWeiXinAccountCY : int
    {
        睡前伴你读 = 1,
        夜深看会书 = 2,
        墨染凝香 = 3,
        睡前看会书 = 4,
        特色小说书单 = 5,
        好书值得看 = 6,
        夜深伴你读 = 7
    }

    /// <summary>
    /// 微信账号编码(bk)
    /// </summary>
    public enum EnumWeiXinBKAccount : int
    {
        百看小说 = 1,
        百看阅读 = 2,
        游记之家 = 3
    }


    /// <summary>
    /// 后台操作类别
    /// </summary>
    public enum EnumAdmActClass : int
    {
        确认支付成功 = 49,
        签约等级修改 = 50,

        章节审核 = 100,
        章节修改 = 101
    }

    /// <summary>
    /// 书状态
    /// </summary>
    public enum EnumBookStatus : int
    {
        下线 = -1,
        隐藏 = 0,
        在线 = 1,
        新采集 = -5
    }

    /// <summary>
    /// 公众号类型
    /// </summary>
    public enum EnumOpenClass : int
    {
        服务号=1,
        订阅号=2
    }

   
}

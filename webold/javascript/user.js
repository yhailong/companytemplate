var UserUtil = {
    msgStyle: 'background-color:#333; color:#fff; text-align:center; border:none; font-size:20px; padding:10px;',
    GetFavoritesNew: function () {
        var bIdList = "";
        $(".book_list").each(function () {
            bIdList += "," + $(this).attr("vals");
        });
        if (bIdList != "") {
            $.post("/api/book.aspx", { act: "getfavnew", bid: bIdList }, function (data, textStatus) {
                if (data != "[]") {
                    eval(data);
                    for (var i = 0; i < c.length; i++) {

                        $(".book_list").each(function () {
                            if ($(this).attr("vals") == c[i].key) {
                                $(this).find(".chapter").html(c[i].value);
                                $(this).find(".bookclass").html('[' + c[i].value1 + ']');
                                var infoList = $(this).find(".chapter").attr("valsc").split('|');
                                if (infoList.length == 3) {
                                    var bId = infoList[0];
                                    var cId = infoList[1];
                                    var cRank = infoList[2];
                                    $(this).find(".goread").html('<a href="/book/' + bId + '/' + cId + '.html">继续阅读</a>');
                                }
                            }
                        });
                    }
                }
            }, "html");
        }
    },
    GetHistory: function () {
        var bIdList = "";
        $(".book_list").each(function () {
            bIdList += "," + $(this).attr("vals");
        });
        if (bIdList != "") {
            $.post("/api/viewhistory.aspx", { act: "getbook", bid: bIdList }, function (data, textStatus) {
                if (data != "[]") {
                    eval(data);
                    for (var i = 0; i < c.length; i++) {

                        $(".book_list").each(function () {
                            if ($(this).attr("vals") == c[i].key) {
                                $(this).find(".chapter").html(c[i].value);
                                $(this).find(".bookclass").html('[' + c[i].value1 + ']');
                                $(this).find(".name a").html(c[i].value2);
                                $(this).find(".time").html(c[i].value3);
                                var infoList = $(this).find(".chapter").attr("valsc").split('|');
                                if (infoList.length == 3) {
                                    var bId = infoList[0];
                                    var cId = infoList[1];
                                    var cRank = infoList[2];
                                    $(this).find(".goread").html('<a href="/book/' + bId + '/' + cId + '.html">继续阅读</a>');
                                }
                            }
                        });
                    }
                }
            }, "html");
        }
    },
    GetChapterInfo: function () {
        var cIdList = "";
        $(".showCName").each(function () {
            cIdList += "," + $(this).attr("vals");
        });
        if (cIdList != "") {
            $.post("/api/viewhistory.aspx", { act: "getchapter", cid: cIdList }, function (data, textStatus) {
                if (data != "[]") {
                    eval(data);
                    for (var i = 0; i < c.length; i++) {
                        $(".showCName").each(function () {
                            if ($(this).attr("vals") == c[i].key) {
                                $(this).html(c[i].value + "<span class=\"goon\">继续阅读</span>");
                            }
                        });
                    }
                }
            }, "html");
        }
    },
    SignDay: function () {
        if (!signed) {
            signed = true;
            $.post("/api/user.aspx", { act: "sign" }, function (data, textStatus) {
                if (data != "") {
                    eval("var rCode=" + data);
                    if (rCode != null) {
                        if (rCode.sCode == 200) {
                            $("#signedshow .tip").html("哇呜~ 抢到" + rCode.sMoney + "点代金券了！");
                        }
                        else if (rCode.sCode == 30) {
                            $("#signedshow .tip").html("今天签过了，明天记得再来哦！");
                        }
                        $("#signshow").hide();
                        $("#signedshow").show();
                        $("#signnote").hide();
                        $("#signednote").show();
                    }
                }
            }, "html");
        }
    },
    SignDayStatus: function () {
        $.post("/api/user.aspx", { act: "signstatus" }, function (data, textStatus) {
            if (data != "") {
                eval("var rCode=" + data);
                if (rCode != null) {
                    if (rCode.sCode != 200) {
                        if (rCode.sCode == 31 || rCode.sCode == 60) {
                            $("#signedshow .btn").html("<img src=\"../images/sign/btn_signeno.png\" alt=\"不可签到\" />");
                            if (rCode.sCode == 31)
                            { $("#signedshow .tip").html("只有微信用户可以签到！"); }
                            else { $("#signedshow .tip").html("系统维护中，请稍后再来！"); }
                        }
                        else if (rCode.sCode == 30) {
                            $("#signedshow .tip").html("今天签过了，明天记得再来哦！");
                            $("#signnote").hide();
                            $("#signednote").show();
                        }
                        $("#signshow").hide();
                        $("#signedshow").show();
                    }
                }
            }
        }, "html");
    },
    RegSendSms: function () {
        var mob = $("#txtUName").val();
        var cCode = $("#TxtChkCode").val();
        if (mob != "" && cCode != "") {
            $("#btnSendSms").attr("disabled", "disabled");
            $("#txtUName").attr("readonly", "true");
            $.post("/api/userreg.aspx", { act: "sendsms", mob: mob, ccode: cCode }, function (data, textStatus) {
                if (data == "200") {
                    UserUtil.RegSmsWait();
                }
                else {
                    var errStr = "";
                    if (data == "14") { errStr = "校验码错误"; }
                    else if (data == "17") {
                        errStr = "手机号码格式错误";
                    } else if (data == "8") { errStr = "无此用户"; }
                    else if (data == "9" || data == "27") { errStr = "用户已存在"; }
                    else { errStr = "未知错误，请稍后重试"; }
                    layer.open({
                        content: errStr,
                        style: UserUtil.msgStyle,
                        time: 2
                    });
                    $("#btnSendSms").removeAttr("disabled");
                    $("#txtUName").removeAttr("readonly");
                }
            }, "html");
        }
        else {
            layer.open({
                content: '手机号码和验证码必须填写',
                style: UserUtil.msgStyle,
                time: 2
            });
        }
    },
    GetPassSendSms: function () {
        var mob = $("#txtMobile").val();
        var cCode = $("#TxtChkCode").val();
        if (mob != "" && cCode != "") {
            $("#btnSendSms").attr("disabled", "disabled");
            $("#txtMobile").attr("readonly", "true");
            $.post("/api/userreg.aspx", { act: "sendsmsg", mob: mob, ccode: cCode }, function (data, textStatus) {
                if (data == "200") {
                    UserUtil.RegSmsWait();
                }
                else {
                    var errStr = "";
                    if (data == "14") { errStr = "校验码错误"; }
                    else if (data == "17") {
                        errStr = "手机号码格式错误";
                    } else if (data == "8") { errStr = "无此用户"; }
                    else { errStr = "未知错误，请稍后重试"; }
                    layer.open({
                        content: errStr,
                        style: UserUtil.msgStyle,
                        time: 2
                    });
                    $("#btnSendSms").removeAttr("disabled");
                    $("#txtMobile").removeAttr("readonly");
                }
            }, "html");
        }
        else {
            layer.open({
                content: '手机号码和验证码必须填写',
                style: UserUtil.msgStyle,
                time: 2
            });
        }
    },
    RegSmsWait: function () {
        if (secondStep > 0) {
            $("#btnSendSms").val("重新发送(" + secondStep + ")");
            secondStep--;
            setTimeout("UserUtil.RegSmsWait()", 1000);
        }
        else {
            secondStep = 180;
            $("#btnSendSms").val("重新获取验证码");
            $("#btnSendSms").removeAttr("disabled");
            $("#txtUName").removeAttr("readonly");
        }
    }
}
﻿var UserPay = {
    czData: [[30, "3000书橱币"], [50, "5000书橱币+500代金券"], [100, "10000书橱币+1200代金券"], [200, "20000书橱币+3000代金券"], [500, "50000书橱币+10000代金券"], [365, "全站包年阅读"] ],
    czPayPalData: [[20, "10000书橱币"], [50, "25000书橱币"], [100, "50000书橱币"], [80, "全站包年阅读"]],
    sendPay: function () {
        $("#payform").submit();
    },
    GetPayState: function (payId) {
        $.post("/api/book.aspx", { act: "getpaystatus", pid: payId }, function (data, textStatus) {
            if (data == "1") {
                location.href = '/pay/wx_return.aspx?out_trade_no=sc'+payId;
            }
            else {
                setTimeout("UserPay.GetPayState("+payId+")",3000);
            }
        }, "html");
    }
}

$(function () {
    $("#ulPayType li").click(function () {
        $($(this).parent()).children().each(function () {
            $(this).removeClass("on");
        });
        $(this).addClass("on");

        var type = $(this).attr("valp");
        if (type == "3") {
            $("#ulPayPal").show();
            $("#ulPayPalXJ").show();
            $("#ulZFWX").hide();
            $("#ulZFWXXJ").hide();
        }
        else {
            $("#ulPayPal").hide();
            $("#ulPayPalXJ").hide();
            $("#ulZFWX").show();
            $("#ulZFWXXJ").show();
        }

        var postUrl = "";
        switch (type)
        {
            case "1":
                postUrl = "sendalipay.aspx";
                break;
            case "2":
                postUrl = "sendwxpaynowqr.aspx";
                break;
            case "3":
                postUrl = "sendpaypal.aspx";
                break;
        }
        $("#payform").attr("action", postUrl);
    })

    $("#ulZFWX li").click(function () {
        $("#ulZFWX li").removeClass("on");
        $(this).addClass("on");
        if ($(this).attr("vals") > 0) {
            $("#pValue").val($(this).attr("vals"));
            $("#showTotal").html('￥' + $(this).attr("vals") + '元');
            for (var i = 0; i < UserPay.czData.length; i++) {
                if (UserPay.czData[i][0] == $(this).attr("vals")) {
                    $("#showRemark").html(UserPay.czData[i][1]);
                    break;
                }
            }
        }
    });
    $("#ulPayPal li").click(function () {
        $("#ulPayPal li").removeClass("on");
        $(this).addClass("on");
        if ($(this).attr("vals") > 0) {
            $("#pValue").val($(this).attr("vals"));
            $("#showPayPalTotal").html($(this).attr("vals") + '美元');
            for (var i = 0; i < UserPay.czData.length; i++) {
                if (UserPay.czPayPalData[i][0] == $(this).attr("vals")) {
                    $("#showPayPalRemark").html(UserPay.czPayPalData[i][1]);
                    break;
                }
            }
        }
    });
});
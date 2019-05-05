var uFans = {
    startSupportRead: function () {
        var uname = jQuery.cookie("waplogname");
        if (uname != undefined && uname != "") {
            if (spmymoney == 0) {
                $.post("/api/user.aspx", { act: "getusermoneyflower" }, function (data, textStatus) {
                    if (data) {
                        spmymoney = data.mavailable;
                        uFans.startSupport();
                    }
                }, "json");
            }
            else {
                uFans.startSupport();
            }
        }
        else {
            layer.open({
                content: '请先登录',
                style: BookDetail.msgStyle,
                time: 2
            });
        }
    },
    startSupport: function () {
        var rStr = '<a class="closePopup" href="javascript:void(0);" onclick="javascript:uFans.closeBox();"></a>';
        rStr += '<div class="popupTit">';
        rStr += '	<h3>我要捧场作品</h3>';
        rStr += '</div>';
        rStr += '<div class="propsList cf">';
        rStr += '	<ul>';
        rStr += '		<li vals="100">';
        rStr += '			<a class="propWrap" href="javascript:void(0);">';
        rStr += '				<i class="icon_check"></i>';
        rStr += '				<span class="propsBox">100书橱币</span>';
        rStr += '			</a>';
        rStr += '		</li>';
        rStr += '		<li class="on"  vals="500">';
        rStr += '			<a class="propWrap" href="javascript:void(0);">';
        rStr += '				<i class="icon_check"></i>';
        rStr += '				<span class="propsBox">500书橱币</span>';
        rStr += '			</a>';
        rStr += '		</li>';
        rStr += '		<li vals="2000">';
        rStr += '			<a class="propWrap" href="javascript:void(0);">';
        rStr += '				<i class="icon_check"></i>';
        rStr += '				<span class="propsBox">2000书橱币</span>';
        rStr += '			</a>';
        rStr += '		</li>';
        rStr += '		<li vals="5000">';
        rStr += '			<a class="propWrap" href="javascript:void(0);">';
        rStr += '				<i class="icon_check"></i>';
        rStr += '				<span class="propsBox">5000书橱币</span>';
        rStr += '			</a>';
        rStr += '		</li>';
        rStr += '		<li vals="10000">';
        rStr += '			<a class="propWrap" href="javascript:void(0);">';
        rStr += '				<i class="icon_check"></i>';
        rStr += '				<span class="propsBox">10000书橱币</span>';
        rStr += '			</a>';
        rStr += '		</li>';
        rStr += '		<li vals="100000">';
        rStr += '			<a class="propWrap" href="javascript:void(0);">';
        rStr += '				<i class="icon_check"></i>';
        rStr += '				<span class="propsBox">100000书橱币</span>';
        rStr += '			</a>';
        rStr += '		</li>';
        rStr += '	</ul>';
        rStr += '</div>';
        rStr += '<p class="have_num">当前剩余<span class="red">' + spmymoney + '</span>书橱币&nbsp;&nbsp;本次捧场<span class="red" id="pcTotal">500</span>书橱币<a class="red" href="../pay/" target="_blank">[充值]</a></p>';
        rStr += '<p><textarea class="popup_text" id="sendSupportNote"   placeholder="感谢您的捧场，留句话鼓励作者吧！"></textarea></p>';
        rStr += '<p class="tc"><a class="btn_red btn_send_pc" href="javascript:void(0);" onclick="javascript:uFans.SendSupport();">立即捧场</a></p>';
        $("#showPC").html(rStr);
        $("#showPC").show();
        $(".maskBox").show();
        $(".pcBox .propsList li").click(function () {
            $(".pcBox .propsList li").removeClass("on");
            $(this).addClass("on");
            $("#pcTotal").html($(this).attr("vals"));
        })
    },
    closeBox: function () {
        $(".pcBox,.flowerBox,.newsTipBox,.maskBox").hide();
    },
    SendSupport: function () {
        var uname = jQuery.cookie("waplogname");
        if (uname != undefined && uname != "") {
            var moneyTotal = spmymoney;
            var moneySupport = parseInt($("#pcTotal").html());
            var sendNote = $("#sendSupportNote").val();
            var clearSendNote = sendNote.replace(/[\ |\~|\`|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\-|\_|\+|\=|\||\\|\[|\]|\{|\}|\;|\:|\"|\'|\,|\<|\.|\>|\/|\?]/g, "");
            if (sendNote == "") {
                layer.open({
                    content: '感谢您的捧场，留句话鼓励作者吧！',
                    style: BookDetail.msgStyle,
                    time: 2
                });
                return;
            }
            if (clearSendNote.length<5)
            {
                layer.open({
                    content: '评论最少5个字符！',
                    style: BookDetail.msgStyle,
                    time: 2
                });
                return;
            }
            if (moneyTotal >= moneySupport) {
                var BId = currentBId;
                $.post("/api/user.aspx", { act: "sendsupport", bid: BId, money: moneySupport }, function (data, textStatus) {
                    if (data == "1") {
                        uFans.showNote('pc');
                        spmymoney = moneyTotal - moneySupport;
                        uFans.GetSupport(BId);
                        $.post("/api/book.aspx", { act: "savecomment", bid: BId, cid: 0, comment: sendNote, status: 1, titleinfo: '捧场' + moneySupport + '书橱币！' }, function (data, textStatus) {
                        }, "html");
                    }
                }, "html");
            }
            else {
                layer.open({
                    content: '书橱币余额不足',
                    style: BookDetail.msgStyle,
                    time: 2
                });
            }
        }
        else {
            layer.open({
                content: '请先登录',
                style: BookDetail.msgStyle,
                time: 2
            });
        }
    },
    GetSupport: function (BId) {
        $.post("/api/bookinfo.aspx", { act: "getsupport", bid: BId }, function (data, textStatus) {
            if (data) {
                $("#spweek").html(data.SupportWeek);
                $("#spweek1").html(data.SupportWeek);
                $("#spday").html(data.SupportDay);
                $("#fltotal").html(data.FlowerTotal);
                var lastStr = '';
                for (var i = 0; i < 4 && i < data.SupportLast.length; i++) {
                    lastStr += '<li><span class="fl"><a href="javascript:void(0)" class="user_name">' + data.SupportLast[i].NiceName + '</a>捧场了' + data.SupportLast[i].Total + '书橱币</span><span class="time fr">[' + uFans.formatDateTime(data.SupportLast[i].CreateDate) + ']</span></li>';
                }
                $("#splast").html(lastStr);
            }
        }, "json");
    },
    GetFlower: function (BId) {
        $.post("/api/bookinfo.aspx", { act: "getflower", bid: BId }, function (data, textStatus) {
            if (data) {
                $("#flday").html(data.FlowerDay);
                $("#flmonth").html(data.FlowerMonth);
                $("#fltotal").html(data.FlowerTotal);
                var lastStr = '';
                var diffPre = -1, diffStr = -1;
                if (data.FlowNear != undefined) {
                    for (var i = 0; i < data.FlowNear.length; i++) {
                        if (data.FlowNear[i].BId != BId) {
                            diffPre = data.FlowNear[i].FlowerMonth;
                        }
                        else {
                            $("#flrank").html(data.FlowNear[i].RowLd);
                            if (diffPre > -1) {
                                diffStr = diffPre - data.FlowNear[i].FlowerMonth;
                            }
                            break;
                        }
                    }
                }
                if (diffStr > -1) {
                    if (diffStr == 0) {
                        diffStr = 1;
                    }
                    $("#flrankdifference").html('只差<i class="red">' + diffStr + '</i>赞就可以超过前一名');
                }
                else {
                    $("#flrankdifference").html('当前赞榜排名第一');
                }
                for (var i = 0; i < 4 && i < data.FlowLast.length; i++) {
                    lastStr += '<li><span class="fl"><a href="javascript:void(0)" class="user_name">' + data.FlowLast[i].NiceName + '</a>点了' + data.FlowLast[i].Total + '个赞</span><span class="time fr">[' + uFans.formatDateTime(data.FlowLast[i].CreateDate) + ']</span></li>';
                }
                $("#fllast").html(lastStr);
            }
        }, "json");
    },
    showNote: function (noteClass) {
        uFans.closeBox();
        $(".maskBox").show();
        var rStr = '<a class="closePopup" href="javascript:void(0);" onclick="javascript:uFans.closeBox();"></a>';
        rStr += '<div class="popupTit">';
        rStr += '	<h3>消息提示</h3>';
        rStr += '</div>';
        if (noteClass == 'pc') {
            rStr += '<div class="tipWrap suc_txt_pc">捧场作品成功！</div>';
        }
        else {
            rStr += '<div class="tipWrap suc_txt_flw">点赞作品成功！</div>';
        }
        rStr += '<div class="tc">';
        rStr += '	<a href="javascript:void(0);" class="btn_red btn_sure"  onclick="javascript:uFans.closeBox();">确定</a>';
        rStr += '</div>';
        $("#showNote").html(rStr);
        $("#showNote").show();
    },
    formatDateTime: function (now) {
        if (now != null && now != "") {
            var dateN = new Date(+/\d+/.exec(now)[0]);
            var year = dateN.getFullYear();
            var month = dateN.getMonth() + 1;
            var date = dateN.getDate();
            var hour = dateN.getHours();
            var minute = dateN.getMinutes();
            var second = dateN.getSeconds();
            minute = parseInt(minute) < 10 ? "0" + minute : minute;

            if (hour == 0 && minute == 0 && second == 0) {
                return year + "-" + month + "-" + date;
            }
            else {
                return month + "-" + date + "   " + hour + ":" + minute;
            }
        }
        else {
            return "";
        }
    }
}
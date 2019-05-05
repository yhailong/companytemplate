var BookDetail = {
    wepDomain: 'shuchu.com',
    msgStyle: 'background-color:#333; color:#fff; text-align:center; border:none; font-size:20px; padding:10px;',
    reShowCover: function () {
        //$(".cCover").height($(".cDetail").height());
        //$(".cCover").width($(".cDetail").width());
    },
    DescriptionMore: function (sClass) {
        if (sClass == "") {
            if ($("#pDesMore").html().length > 150) {
                $("#divDescription").html($("#pDesMore").html().substring(0, 150) + "<a href=\"javascript:void(0);\" class=\"info_txt_more\" onclick=\"javascript:BookDetail.DescriptionMore('down');\">展开<img src=\"../images/arrow_d.png\" /></a>");
            }
            else {
                $("#divDescription").html($("#pDesMore").html());
            }
        }
        else {
            $("#divDescription").html($("#pDesMore").html() + "<a href=\"javascript:void(0);\"  class=\"info_txt_more\"  onclick=\"javascript:BookDetail.DescriptionMore('');\">收起<img src=\"../images/arrow_t.png\" /></a>");
        }
    },
    AddFavorites: function (BId, CId, layerStatus) {
        $.post("/api/book.aspx", { act: "addfavorites", bid: BId, cid: CId }, function (data, textStatus) {
            if (data == "25") {
                layer.open({
                    content: '已加入书架',
                    style: BookDetail.msgStyle,
                    time: 2
                });
                $("#cFavs").hide();
                jQuery.cookie("u-faorites", "1");
            }
            else if (data == "200") {
                if (layerStatus == 1) {
                    $("#cFavs").html("<a class=\"ico_shelf\" href=\"javascript:void(0);\"><b>已收藏</b></a>");
                    jQuery.cookie("u-faorites", "1");
                }
                else {
                    $("#cFavs").html("<a class=\"btn_gray btn_addsj\" href=\"javascript:void(0);\">已加入</a>");
                }
            }
            else {
                var url = '/book/' + BId;
                if (CId > 0) {
                    url = url + '/' + CId;
                }
                url += '.html';
                location.href = '/user/login.aspx?refer=' + escape(url);
            }
        }, "html");
    },
    GetFavorites: function (BId) {
        if (jQuery.cookie("u-faorites") == null) {
            $.post("/api/book.aspx", { act: "getfavorites", bid: BId }, function (data, textStatus) {
                if (data == "1") {
                    $("#cFavs").html("<a class=\"ico_shelf\" href=\"javascript:void(0);\"><b>已加书架</b></a>");
                    jQuery.cookie("u-faorites", "1");
                }
                else {
                    jQuery.cookie("u-faorites", "0");
                }
            }, "html");
        }
        else {
            if (jQuery.cookie("u-faorites") == "1") {
                $("#cFavs").html("<a class=\"ico_shelf\" href=\"javascript:void(0);\"><b>已加书架</b></a>");
            }
        }
        /*BookDetail.SetWholeTip();*/
    },
    GetComment: function (BId) {
        $.post("/api/bookcomment.aspx", { bid: BId }, function (data, textStatus) {
            var noData = true;
            if (data != "") {
                var uList = ',';
                eval('var objRow=' + data);
                if (objRow != null && objRow.rows != null && objRow.rows.length > 0) {
                    noData = false;
                    var cmtStr = '';
                    for (var i = 0; i < objRow.rows.length; i++) {
                        if (uList.indexOf(',' + objRow.rows[i].UId + ',') < 0) {
                            uList += objRow.rows[i].UId + ',';
                        }
                        cmtStr += '<div class="comment_list cf">';
                        cmtStr += '		<div class="user_heads" vals="' + objRow.rows[i].UId + '">';
                        cmtStr += '		    <img src="' + objRow.rows[i].LogoImg + '" class="user_head" alt="" /><span class="user_level1">见习</span>';
                        cmtStr += '		</div>';
                        cmtStr += '		<ul>';
                        cmtStr += '			<li class="li_0">';
                        if (objRow.rows[i].IsTop == 1) {
                            cmtStr += '             <span class="icon_zd">置顶</span>';
                        }
                        if (objRow.rows[i].IsPride == 1) {
                            cmtStr += '             <span class="icon_jh">精华</span>';
                        }
                        if (objRow.rows[i].Title != undefined) {
                            cmtStr += '<strong>' + objRow.rows[i].Title + '</strong>';
                        }
                        cmtStr += '			</li>';
                        cmtStr += '			<li class="li_2">' + objRow.rows[i].Detail + '</li>';
                        cmtStr += '			<li class="li_3"><span class="user_name mr20 fl"><i class="black9 mr5">来自</i>' + objRow.rows[i].UName + '</span><span class="black9 fl">' + BookDetail.formatDate(objRow.rows[i].CreateDate) + '</span><span class="user_dp fr"><a href="javascript:void(0);" onclick="javascript:BookDetail.AddAgreeTotal(' + objRow.rows[i].Ld + ',this);" class="zan">赞<i class="num">(' + objRow.rows[i].AgreeTotal + ')</i></a><a href="comment-' + objRow.rows[i].BId + '-' + objRow.rows[i].Ld + '.html" class="reply">回复<i class="num">(' + objRow.rows[i].CommentTotal + ')</i></a></span></li>';
                        cmtStr += '		</ul>';
                        cmtStr += '	</div>';
                    }
                    $("#commentPanel").html(cmtStr);
                    $("#bookCommentTotal").html("(<a href=\"comment-" + BId + ".html\" target=\"_blank\">共" + objRow.total + "条</a>)");
                    BookDetail.GetUserBookLevel(uList, BId);
                }
            }
            if (noData) {
                $("#commentPanel").hide();
                $("#moreCommentPanel").hide();
                $("#noCommentPanel").show();
            }
        }, "html");
    },
    GetUserBookLevel: function (idList, bId) {
        if (idList.length > 2) {
            $.post("/api/bookinfo.aspx", { act: "getulevel", bid: bId, ulist: idList }, function (data, textStatus) {
                if (data) {
                    var uId, levelMark;
                    for (var i = 0; i < data.length; i++) {
                        $("#commentPanel .user_heads").each(function () {
                            uId = $(this).attr("vals");
                            if (uId == data[i].key) {
                                levelMark = BookDetail.GetUserLevel(data[i].value);
                                $(this).find("span").addClass(levelMark[0]);
                                $(this).find("span").html(levelMark[1]);
                            }
                        });
                    }
                }
            }
            , "json");
        }
    },
    GetUserLevel: function (mTotal) {
        if (mTotal != undefined) {
            var iTotal = parseInt(mTotal);
            if (iTotal < 500) {
                return ["user_level1", "见习"];
            } else if (iTotal < 2000) {
                return ["user_level2", "学徒"];
            } else if (iTotal < 5000) {
                return ["user_level3", "弟子"];
            } else if (iTotal < 10000) {
                return ["user_level4", "执事"];
            } else if (iTotal < 20000) {
                return ["user_level5", "舵主"];
            } else if (iTotal < 30000) {
                return ["user_level6", "堂主"];
            } else if (iTotal < 40000) {
                return ["user_level7", "护法"];
            } else if (iTotal < 50000) {
                return ["user_level8", "长老"];
            } else if (iTotal < 70000) {
                return ["user_level9", "掌门"];
            } else if (iTotal < 100000) {
                return ["user_level10", "宗师"];
            } else {
                return ["user_level11", "盟主"];
            }
        }
        else {
            return ["user_level1", "见习"];
        }
    },
    SaveComment: function (cmtBId, cmtCId, cmtDetail) {
        var cmtDetailTemp = cmtDetail.replace(/(^\s*)/g, "");
        if (cmtDetailTemp == '') {
            layer.open({
                content: '评论内容必须填写',
                style: BookDetail.msgStyle,
                time: 2
            });
            return;
        }
        if (cmtDetailTemp.length < 5) {
            layer.open({
                content: '评论内容必须大于5个字',
                style: BookDetail.msgStyle,
                time: 2
            });
            return;
        }
        if (cmtDetail.length < 5) {
            layer.open({
                content: '评论内容必须大于5个字',
                style: BookDetail.msgStyle,
                time: 2
            });
            return;
        }
        $.post("/api/book.aspx", { act: "savecomment", bid: cmtBId, cid: cmtCId, comment: cmtDetail }, function (data, textStatus) {
            var noteTxt = "";
            if (data == "200") {
                noteTxt = "发表成功，审核通过后即可显示";
            }
            else if (data == "19") {
                noteTxt = "您已被禁言，不可发表评论";
            }
            else if (data == "50") {
                noteTxt = "发生错误，请稍后再试";
            }
            else {
                noteTxt = "请先登录";
            }
            layer.open({
                content: noteTxt,
                style: BookDetail.msgStyle,
                time: 2
            });
            if (data == "200") {
                $("#txtComment").val("");
            }
        }, "html");


    },
    GetFavoritesBook: function (BId) {
        $.post("/api/book.aspx", { act: "getfavorites", bid: BId }, function (data, textStatus) {
            if (data == "1") {
                $("#cFavs").html("<a class=\"btn_gray btn_addsj\" href=\"javascript:void(0);\">已加入</a>");
            }
            BookDetail.GetMoneyFlower();
        }, "html");
    },
    GetMoneyFlower: function () {
        $.post("/api/user.aspx", { act: "getusermoneyflower" }, function (data, textStatus) {
            if (data) {
                $("#usfltotal").html(data.flower);
                usfltotal = data.flower;
                spmymoney = data.mavailable;
            }
        }, "json");
    },
    AddAgreeTotal: function (AId, objs) {
        $.post("/api/book.aspx", { act: "addagree", aid: AId }, function (data, textStatus) {
            if (data == "20") {
                layer.open({
                    content: '已点过赞',
                    style: BookDetail.msgStyle,
                    time: 2
                });
            }
            else if (data == "200") {
                layer.open({
                    content: '点赞成功',
                    style: BookDetail.msgStyle,
                    time: 2
                });
                var iTotal = $($(objs).find("i")[0]);
                var cTotal = iTotal.html();
                cTotal = cTotal.replace("(", "").replace(")", "");
                iTotal.html("(" + (parseInt(cTotal) + 1) + ")");
            }
            else {
                layer.open({
                    content: '请先登录',
                    style: BookDetail.msgStyle,
                    time: 2
                });
            }
        }, "html");
    },
    RelationBook: function () {
        relationStep++;
        var bListCount = 0;
        var bList = $("#relationBookList div");
        bListCount = bList.length;
        var sStep = 0, eStep = 2;
        if (bListCount > relationStep * 3) {
            sStep = relationStep * 3;
            eStep = sStep + 2;
            if (sStep > bListCount - 1) {
                eStep = bListCount;
            }
        }
        else {
            relationStep = -1;
        }
        for (var i = 0; i < bListCount; i++) {
            if (i >= sStep && i <= eStep) {
                bList[i].style.display = "";
            }
            else {
                bList[i].style.display = "none";
            }
        }
    },
    Click: function (bId) {
        //BookDetail.DescriptionMore("");
        $.post("/api/click.aspx", { bid: bId }, function (data, textStatus) {
            if (data > 0) {
                $("#cTotal").html(data);
            }
        }, "html");
    },
    ClickChapter: function (bId, cId, isVip) {
        if (isVip == 1) {
            var m = Math.floor(6 * Math.random());
            if (m == 3) {
                $.post("/api/book.aspx", { act: "getucode" }, function (data, textStatus) {
                    if (data == "29") {
                        location.href = '/user/logout.aspx';
                    }
                }, "html");
            }
        }
        else {
            $.post("/api/click.aspx", { bid: bId, cid: cId }, function (data, textStatus) {
            }, "html");
        }
    },
    SetReadFont: function (fonts) {
        var cFont = parseInt($("#cFonts").html());
        fonts = cFont + fonts;
        if (fonts < 8) {
            fonts = 8;
        }
        if (fonts > 48) {
            fonts = 48;
        }
        $.post("/api/fonts.aspx", { fonts: fonts }, function (data, textStatus) {
            $(".readBox").css("font-size", fonts + "px");
            $("#cFonts").html(fonts);
            BookDetail.reShowCover();
        }, "html");
    },
    SetBackUpColor: function (colorNum) {
        $.post("/api/fonts.aspx", { backup: colorNum }, function (data, textStatus) {
            document.body.className = data;
        }, "html");
    },
    SetReadFontFamily: function (fontNum) {
        BookDetail.SetReadFontFamilyClear(fontNum);
        $.post("/api/fonts.aspx", { fontfamily: fontNum }, function (data, textStatus) {
        }, "html");
    },
    SetReadFontFamilyClear: function (fontNum) {
        $("#setup_font_yahei").removeClass("current");
        $("#setup_font_simsun").removeClass("current");
        $("#setup_font_ks").removeClass("current");
        if (fontNum == 1) {
            $("#setup_font_simsun").addClass("current");
            $(".readBox").css("font-family", "Simsun");
        }
        else if (fontNum == 2) {
            $("#setup_font_ks").addClass("current");
            $(".readBox").css("font-family", "kaiti");
        }
        else {
            $("#setup_font_yahei").addClass("current");
            $(".readBox").css("font-family", "microsoft yahei");
        }
    },
    GetReadSet: function (bid, cid, preId, nextId, crank) {
        $(".nextPageBox .prev,.ico_pagePrev").click(function () {
            if (preId > 0) {
                location.href = '/book/' + bid + '/' + preId + '.html';
            }
            else {
                location.href = '/book/chapterlist-' + bid + '.html';
            }
        });

        $(".nextPageBox .next,.ico_pageNext").click(function () {
            if (nextId > 0) {
                location.href = '/book/' + bid + '/' + nextId + '.html';
            }
            else {
                location.href = '/book/chapterlist-' + bid + '.html';
            }
        });
        $(window).bind('keydown',
            function (e) {
                if (e.keyCode == 37) {
                    if (preId > 0) {
                        location.href = '/book/' + bid + '/' + preId + '.html';
                    }
                    else {
                        location.href = '/book/chapterlist-' + bid + '.html';
                    }
                } else if (e.keyCode == 39) {
                    if (nextId > 0) {
                        location.href = '/book/' + bid + '/' + nextId + '.html';
                    }
                    else {
                        location.href = '/book/chapterlist-' + bid + '.html';
                    }
                }
            });
        BookDetail.SetReadHistory(bid, cid, crank);
    },
    SetReadHistory: function (bid, cid, crank) {
        var strHistory = jQuery.cookie("wapviewhistory");
        if (strHistory != null) {
            var r = new RegExp('b' + bid + '\\\|(.*?),', 'g');
            strHistory = strHistory.replace(r, '')
            strHistory = 'b' + bid + '|' + cid + '|' + crank + ',' + strHistory;
            if (strHistory.length > 500) {
                strHistory = strHistory.substring(0, 500);
                strHistory = strHistory.substring(0, strHistory.lastIndexOf(','));
                strHistory = strHistory + ',';
            }
        }
        else {
            strHistory = 'b' + bid + '|' + cid + '|' + crank + ',';
        }
        jQuery.cookie("wapviewhistory", strHistory, { path: '/', domain: BookDetail.wepDomain, expires: 365 });
    },
    formatDate: function (now, types) {
        if (now != null && now != "") {
            var dateN = new Date(+/\d+/.exec(now)[0]);
            var year = dateN.getFullYear();
            var month = dateN.getMonth() + 1;
            var date = dateN.getDate();
            var hour = dateN.getHours();
            var minute = dateN.getMinutes();
            var second = dateN.getSeconds();
            if (typeof (types) != "undefined" && types != null) {
                return year + "-" + month + "-" + date;
            }
            else if (hour == 0 && minute == 0 && second == 0) {
                return year + "-" + month + "-" + date;
            }
            else {
                return year + "-" + month + "-" + date + "   " + hour + ":" + minute + ":" + second;
            }
        }
        else {
            return "";
        }
    },
    SetWholeTip: function () {
        var str = '<li>1、此书为全网优质作品，按照整本定价折扣销售，购买之后可以阅读该书全部章节。</li>';
        str += '<li>2、支付书橱币即可阅读收费章节，没有书橱币的需要先充值。</li>';
        str += '<li>3、QQ、微信、微博3种账号之间的数据不互通，如果你发现充值成功但没有书橱币到账，请切换账号查看是否充到了别的账号中。</li>';
        if ($("#HidIsWholeBook").val() == "1") {
            $(".tip_list").html(str);
        }
    },
    SetDZChapter: function (bId, cId, isDianZan) {
        if (isDianZan == 1) {
            /*是点赞，设置点赞数+1和不可点状态*/
            var dzData = parseInt($("#read_dz_bar a").text()) + 1;
            $("#read_dz_bar").html('<a class="read_dz on" href="javascript:void(0)"><i></i>' + dzData + '</a>');
        }
        $.post("/api/dianzan.aspx", { bid: bId, cid: cId, isdianzan: isDianZan }, function (data, textStatus) {
            eval(data);
            if (dzObj) {
                if (isDianZan == 0) {
                    /*获取点赞数，设置点赞数*/
                    if (dzObj[1] == 0) {
                        var uSame = jQuery.cookie("waplogname");
                        if (uSame != undefined && uSame != "") {
                            $("#read_dz_bar").html('<a class="read_dz" href="javascript:void(0)" onclick="BookDetail.SetDZChapter(' + bId + ',' + cId + ',1);"><i></i>' + dzObj[0] + '</a>');
                        }
                        else {
                            $("#read_dz_bar").html('<a class="read_dz" href="/user/login.aspx?refer=/book/' + bId + '/' + cId + '.html"><i></i>' + dzObj[0] + '</a>');
                        }
                    }
                    else {
                        $("#read_dz_bar").html('<a class="read_dz on" href="javascript:void(0)"><i></i>' + dzObj[0] + '</a>');
                    }
                }
            }
        }, "html");
    }
}
var rand = {};
rand.get = function (begin, end) {
    return Math.floor(Math.random() * (end - begin)) + begin;
}

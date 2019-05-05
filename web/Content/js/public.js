$(function () {
    //单选下拉框
    $(".rule-single-select").ruleSingleSelect(); 
})

//单选下拉框
$.fn.ruleSingleSelect = function () {
    var isDisplay = true;
    var singleSelect = function (parentObj) {


        var divObj = $('<div class="btn-group"></div>').prependTo(parentObj); //前插入一个DIV
        //创建元素
        var titObj = $(' <a class="btn btn-default dropdown-text" data-toggle="dropdown"></a>').appendTo(divObj);
        var arrowObj= $('<a class="btn btn-default dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></a>').appendTo(divObj);
        var itemObj = $(' <ul class="dropdown-menu"></ul>').appendTo(divObj);
        var selectObj = parentObj.find("select").eq(0); //取得select对象
        selectObj.hide(); //隐藏内容
        //检查控件是否启用
        if (selectObj.prop("disabled") == true || selectObj.attr("disabled") == "disabled") {
            isDisplay = false;
        }

        //遍历option选项
        selectObj.find("option").each(function (i) {
            var indexNum = selectObj.find("option").index(this); //当前索引
            var liObj = $('<li><a href="javascript:void(0)">' + $(this).text() + '</a></li>').appendTo(itemObj); //创建LI
            if ($(this).prop("selected") == true) {
                liObj.addClass("selected");
                titObj.text($(this).text());
            }
            //检查控件是否启用
            if (!isDisplay) {
                liObj.css("cursor", "default");
                return;
            }
            //绑定事件
            liObj.click(function () {
                $(this).siblings().removeClass("selected");
                $(this).addClass("selected"); //添加选中样式
                selectObj.find("option").prop("selected", false);
                selectObj.find("option").eq(indexNum).prop("selected", true); //赋值给对应的option
                titObj.text($(this).text()); //赋值选中值
               //arrowObj.hide();
                itemObj.hide(); //隐藏下拉框
                selectObj.trigger("change"); //触发select的onchange事件
                //alert(selectObj.find("option:selected").text());
            });
        });
        //设置样式
        //titObj.css({ "width": titObj.innerWidth(), "overflow": "hidden" });
        //itemObj.children("ul").css({ "max-height": $(document).height() - titObj.offset().top - 62 });
        //检查控件是否启用
        if (!isDisplay) {
            return;
        }
        else {
            //绑定单击事件
            titObj.click(function (e) {
                DropDownShow();
            });
            //绑定单击事件
            arrowObj.click(function (e) {
                DropDownShow();
            });
        }
        function DropDownShow()
        {
            //查看元素在页面的y轴定位
            var objTop = parentObj.offset().top;
            //整个页面的高度
            var pageHeight = $("body").height();
            //下拉选项的高度
            var optionHeight = titObj.parent().find(".select-items").height();
            if (pageHeight - objTop < optionHeight) //向上显示下拉
            {
                titObj.parent().find(".select-items").css("top", 0 - optionHeight + 10);
            }
          

            //e.stopPropagation();
            if (itemObj.is(":hidden")) {
                //隐藏其它的下位框菜单
                $(".single-select .select-items").hide();
                $(".single-select .arrow").hide();
                //位于其它无素的上面
                arrowObj.css("z-index", "99");
                itemObj.css("z-index", "99");
                //显示下拉框
                //arrowObj.show();
                itemObj.show();
            } else {
                //位于其它无素的上面
                // arrowObj.css("z-index", "");
                itemObj.css("z-index", "");
                //隐藏下拉框
                // arrowObj.hide();
                itemObj.hide();
            }
        }

        //绑定页面点击事件
        $(document).click(function (e) {
            selectObj.trigger("blur"); //触发select的onblure事件
            //arrowObj.hide();
            itemObj.hide(); //隐藏下拉框
        });
    };
    return $(this).each(function () {
        singleSelect($(this));
    });
}

var YT =
    {
        Dirt: {
            /*获取值表示的意义*/
            GetName: function (dirtName, dValue) {
                var obj = eval("DirtInfo." + dirtName);
                if (obj != undefined && obj != null) {
                    for (var i = 0; i < obj.length; i++) {
                        if (obj[i][0] == dValue) {
                            return obj[i][1];
                        }
                    }
                }
                return "";
            },
            Alert: function (state, content, close) {
                //window.parent.location.reload();
                if (state == "success") {
                    $.modalMsg(content, state);
                    if (close) {
                        $.currentWindow().$("#gridList").resetSelection();
                        $.currentWindow().$("#gridList").trigger("reloadGrid");
                        $.modalClose();
                       
                    }
                } else {
                    $.modalAlert(content, state);
                }
            }
        }
    }

var DirtInfo = {
    TrueOrFalse: [[0, "否"], [1, "是"]],
    UserState: [[0, "禁用"], [1, "可用"]],
    AdvertiserLoginType: [[1, "广告主"], [2, "渠道经理"]],
    PayClass: [[1, "支付宝"], [2, "微信"], [3, "微信扫码"], [4, "现在微信"], [5, "现在微信扫码"], [6, "现在公众号"], [7, "Apple支付"], [50, "PayPal美元"], [100, "绑定手机奖励"]]
};
﻿/*
	http://www.rjboy.cn
	By sean during 2010.07 - 2010.12;
	
	Demo:
	$(".productshow").Xslider({//.productshow是要移动对象的外框,页面上所有绑定了类.productshow的对象都会有切换效果;
        unitAll:100,//可以动的总个数
		unitdisplayed:3,//可视的单位个数   必需项;
		numtoMove:1,//要移动的单位个数    必需项;
		viewedSize:120,//可视宽度或高度     不传入则查找要移动对象外层的宽或高度;
		scrollobj:".vscrollobj",//要移动的对象    不传入则查找productshow下的ul;
		unitlen:20,//移动的单位宽或高度      不传入则查找li的尺寸;
		scrollobjSize:$(".vscrollobj").height(),//移动最长宽或高（要移动对象的宽度或高度）   不传入则由li个数乘以unitlen计算;
		dir:"V",//水平移动还是垂直移动       默认H为水平移动，传入V则表示垂直移动（注意是大写字母）;
		loop:"cycle",//循环滚动            不传入则不循环滚动;
		speed:500, //滚动速度      默认为500;
		autoscroll:2000//自动移动间隔时间（毫秒）     不传入则不会自动移动;
        btnL:"", //按钮左i.goL 必须项
        btnR:""//按钮右i.goR 必须项
        btnStatusCss:"on", //按钮状态颜色样式 ,没有则不改变
        offsetnow:0 //初始化的时候第一个显示位置
	});
*/

(function ($) {
    $.extend($.easing, {
        easeInSine: function (x, t, b, c, d) {
            return -c * Math.cos(t / d * (Math.PI / 2)) + c + b;
        }
    });

    $.fn.Xslider = function (settings) {
        settings = $.extend({}, $.fn.Xslider.sn.defaults, settings);
        this.each(function () {
            var scrollobj = settings.scrollobj ? $(this).find(settings.scrollobj) : $(this).find("ul"),
			    viewedSize = settings.viewedSize || (settings.dir == "H" ? scrollobj.parent().width() : scrollobj.parent().height()), //length of the wrapper visible;
			    scrollunits = scrollobj.find("li"), //units to move;
			    unitlen = settings.unitlen,
                unitAll = settings.unitAll ? settings.unitAll : scrollunits.length,
                unitdisplayed = settings.unitdisplayed, //units num displayed;
				numtoMove = settings.numtoMove > unitdisplayed ? unitdisplayed : settings.numtoMove,
			    scrollobjSize = settings.scrollobjSize || unitAll * unitlen, //length of the scrollobj;
			    offset = 0, //max width to move;
			    offsetnow = settings.offsetnow?settings.offsetnow:0, //scrollobj now offset;
			    movelength = unitlen * numtoMove,
				pos = settings.dir == "H" ? "left" : "top",
			    moving = false, //moving now?;
			    btnright = $(this).find(settings.btnR).length > 0 ? $(this).find(settings.btnR) : $(settings.btnR),
			    btnleft = $(this).find(settings.btnL).length > 0 ? $(this).find(settings.btnL) : $(settings.btnL);
            btnStatusClass = (settings.btnStatusCss) ? settings.btnStatusCss : "";
            if (unitAll > unitdisplayed && btnStatusClass != "") {
                btnright.addClass(btnStatusClass);
            }
            btnright.unbind("click");
            btnleft.unbind("click");

            settings.dir == "H" ? scrollobj.css("left", "0px") : scrollobj.css("top", "0px");

            if (scrollobjSize > viewedSize) {
                if (settings.loop == "cycle") {
                    btnleft.removeClass("agrayleft");
                    if (unitAll < 2 * numtoMove + unitdisplayed - numtoMove) {
                        scrollobj.find("li").clone().appendTo(scrollobj);
                    }
                } else {
                    btnleft.addClass("agrayleft");
                    offset = scrollobjSize - viewedSize;
                }
                btnright.removeClass("agrayright");
            } else {
                btnleft.addClass("agrayleft");
                btnright.addClass("agrayright");
            }

            btnleft.click(function () {
                if ($(this).is("[class*='agrayleft']")) { return false; }

                if (btnStatusClass != "") {
                    btnright.addClass(btnStatusClass);
                }
                if (!moving) {
                    moving = true;

                    if (settings.loop == "cycle") {
                        scrollobj.find("li:gt(" + (unitAll - numtoMove - 1) + ")").prependTo(scrollobj);
                        scrollobj.css(pos, "-" + movelength + "px");
                        $.fn.Xslider.sn.animate(scrollobj, 0, settings.dir, settings.speed, function () { moving = false; scrollobj.css("left", "0px"); });
                    } else {
                        offsetnow -= movelength;
                        if (offsetnow > unitlen * unitdisplayed - viewedSize) {
                            $.fn.Xslider.sn.animate(scrollobj, -offsetnow, settings.dir, settings.speed, function () {
                                moving = false;
                                //scrollobj.css("left", "0px");
                            });
                        } else {
                            $.fn.Xslider.sn.animate(scrollobj, 0, settings.dir, settings.speed, function () {
                                moving = false;
                                scrollobj.css("left", "0px");
                                if (btnStatusClass != "") {
                                    btnleft.removeClass(btnStatusClass);
                                }
                            });
                            offsetnow = 0;
                            $(this).addClass("agrayleft");
                        }
                        btnright.removeClass("agrayright");
                    }
                }

                return false;
            });
            btnright.click(function () {
                if ($(this).is("[class*='agrayright']")) { return false; }

                if (btnStatusClass != "") {
                    btnleft.addClass(btnStatusClass);
                }
                if (!moving) {
                    moving = true;

                    if (settings.loop == "cycle") {
                        var callback = function () {
                            scrollobj.find("li:lt(" + numtoMove + ")").appendTo(scrollobj);
                            scrollobj.css(pos, "0px");
                            moving = false;
                        }
                        $.fn.Xslider.sn.animate(scrollobj, -movelength, settings.dir, settings.speed, callback);
                    } else {
                        offsetnow += movelength;
                        if (offsetnow < offset - (unitlen * unitdisplayed - viewedSize)) {
                            $.fn.Xslider.sn.animate(scrollobj, -offsetnow, settings.dir, settings.speed, function () { moving = false; });
                        } else {
                            $.fn.Xslider.sn.animate(scrollobj, -offset, settings.dir, settings.speed, function () {
                                moving = false;
                                if (btnStatusClass != "") {
                                    btnright.removeClass(btnStatusClass);
                                }
                            }); //滚动到最后一个位置;
                            offsetnow = offset;
                            $(this).addClass("agrayright");
                        }
                        btnleft.removeClass("agrayleft");
                    }
                }

                return false;
            });

            if (settings.autoscroll) {
                $.fn.Xslider.sn.autoscroll($(this), settings.autoscroll, btnleft, btnright);
            }
            if (offsetnow>0) {
                $.fn.Xslider.sn.animate(scrollobj, -offsetnow, settings.dir, settings.speed, function () { moving = false; });
                btnleft.removeClass("agrayleft");
            }
        })
    }

    $.fn.Xslider.sn = {
        defaults: {
            dir: "H",
            speed: 500
        },
        animate: function (obj, w, dir, speed, callback) {
            if (dir == "H") {
                obj.animate({
                    left: w
                }, speed, "easeInSine", callback);
            } else if (dir == "V") {
                obj.animate({
                    top: w
                }, speed, "easeInSine", callback);
            }
        },
        autoscroll: function (obj, time, btnL, btnR) {
            var vane = "right";
            function autoscrolling() {
                if (vane == "right") {
                    if (!obj.find("a.agrayright").length) {
                        //obj.find("i.goR").trigger("click");
                        btnR.trigger("click");
                    } else {
                        vane = "left";
                    }
                }
                if (vane == "left") {
                    if (!obj.find("a.agrayleft").length) {
                        //obj.find("i.goL").trigger("click");
                        btnL.trigger("click");
                    } else {
                        vane = "right";
                    }
                }
            }
            var scrollTimmer = setInterval(autoscrolling, time);
            obj.hover(function () {
                clearInterval(scrollTimmer);
            }, function () {
                scrollTimmer = setInterval(autoscrolling, time);
            });
        }
    }
})(jQuery);
var $C = function (objName) {
    if (typeof (document.getElementById(objName)) != "object")
    { return null; }
    else
    { return document.getElementById(objName); }
}
var YU = {
    BaseData: {
        WaitImg: "http://img.shuchu.com/loading.gif"
    },
    BaseCommon: {
        gL: function (x) { var l = 0; while (x) { l += x.offsetLeft; x = x.offsetParent; } return l },
        gT: function (x) { var t = 0; while (x) { t += x.offsetTop; x = x.offsetParent; } return t }
    },
    /*选择相应id*/
    $C: function (objName) {
        if (typeof (document.getElementById(objName)) != "object") { return null; } else { return document.getElementById(objName); }
    },
    Fun: {
        /*选择复选钮内容*/
        $CN: function (objName) {
            if (typeof (document.getElementsByName(objName)) != "object") { return ""; }
            else {
                var rstr = "";
                var fnlist = document.getElementsByName(objName);
                for (var i = 0; i < fnlist.length; i++) {
                    if (fnlist[i].checked) {
                        if (rstr != "")
                            rstr += ",";
                        rstr += fnlist[i].value;
                    }
                }
                return rstr;
            }
        },
        /*显示或隐藏等待框*/
        LoadShow: function () {
            if (YU.$C("LayerShowPic") == null) {
                var sp = document.createElement("div");
                sp.innerHTML = "<div id=\"LayerShowPic\" style=\"position:absolute;width:265px;height:80px;z-index:100;background-color: #fdfce9;border: 1px solid #666666;\"><div align=\"center\" style=\"z-index:91;\"><br><p><img src=\"" + YU.BaseData.WaitImg + "\" align=\"absmiddle\" /> 数据处理中，请稍候！！</p></div></div><iframe id=\"LayerCover\" style=\"position:absolute;width:100%;height:100%;z-index:10;left: 0px;top: 0px;background-color:#eeeeee;FILTER: alpha(opacity=80); \"></iframe>";
                document.body.appendChild(sp);
            }
            YU.$C("LayerShowPic").style.display = '';
            YU.$C("LayerCover").style.display = '';
            YU.$C("LayerCover").style.height = String(document.documentElement.scrollHeight) + 'px';
            YU.Fun.ScreenCenter(YU.$C("LayerShowPic"), 266, 200);

        },
        LoadHide: function () {
            if (YU.$C("LayerShowPic") != null) {
                YU.$C("LayerShowPic").style.display = 'none';
                YU.$C("LayerCover").style.display = 'none';
            }
        },
        /*检查日期格式是否正确*/
        IsDate: function (DateStr) {
            var re = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29))$/;
            if (re.test(DateStr)) {
                return true;
            }
            else
                return false;
        },
        IsEmail: function (dataStr) {
            reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
            return reg.test(dataStr);
        },
        /*判断是否是数字*/
        IsNumb: function (NumbStr) {
            var re = /^\d{1,50}$/;
            if (re.test(NumbStr))
            { return true; }
            else
            { return false; }
        },
        /*获取cookie数据*/
        GetCookie: function (CookieName) {
            var strArg = CookieName + "=";
            var iArgLength = strArg.length;
            var iCookieLength = document.cookie.length;
            var iIndex = 0;
            while (iIndex < iCookieLength) {
                var kIndex = iIndex + iArgLength;
                if (document.cookie.substring(iIndex, kIndex) == strArg) return YU.Fun.getCookieVal(kIndex);
                iIndex = document.cookie.indexOf(" ", iIndex) + 1;
                if (iIndex == 0) break;
            }
            return null;
        },
        SetCookie: function (CookieName, CookieValue) {
            var strArgValue = YU.Fun.SetCookie.arguments;
            var iArgLength = YU.Fun.SetCookie.arguments.length;
            var expires = (2 < iArgLength) ? strArgValue[2] : null;
            var path = "/";
            var domain = (4 < iArgLength) ? strArgValue[4] : null;
            var secure = (5 < iArgLength) ? strArgValue[5] : false;
            document.cookie = CookieName + "=" + escape(CookieValue) + ((expires == null) ? "" : (";expires=" + expires.toGMTString())) +
                    	((path == null) ? "" : (";path=" + path)) + ((domain == null) ? "" : (";domain=" + domain)) +
                    	((secure == true) ? ";secure" : "");
        },
        /*截取cookie数据*/
        getCookieVal: function (offset) {
            var iEndStr = document.cookie.indexOf(";", offset);
            if (iEndStr == -1) iEndStr = document.cookie.length;
            return decodeURI(document.cookie.substring(offset, iEndStr));
        },
        /*获取cookie键值*/
        GetCookieValue: function (cookieStr, name) {
            var cookieArr, i, pos;
            var temp;
            cookieStr = getCookie(cookieStr);
            if (cookieStr == null) return null;
            cookieStr += "";
            if (cookieStr.length == 0) return (null);
            if (name.length == 0) return (cookieStr);
            cookieArr = cookieStr.split("&");
            for (i = 0; i < cookieArr.length; i++) {
                temp = cookieArr[i].toLowerCase();
                if (name.toLowerCase() + "=" == temp.substr(0, name.length) + "=") {
                    return (temp.substr(name.length + 1));
                }
            }
        },
        /*处理页面checkbox的全选与取消*/
        SelectCheckBox: function (obj) {
            l = document.getElementsByTagName('input');
            for (i = 0; i < l.length; i++) {
                if (!obj.checked) {
                    l[i].checked = false;
                }
                else {
                    l[i].checked = true;
                }
            }
        },
        /*添加方法*/
        AddEvents: function (obj, evt, fn) {
            if (obj.addEventListener) {
                obj.addEventListener(evt, fn, false);
            } else if (obj.attachEvent) {
                obj.attachEvent('on' + evt, fn);
            }
        },
        /*屏幕中央显示
        width\height:显示框宽度和高度,obj:要显示的div或其他容器*/
        ScreenCenter: function (obj, width, height) {
            if (obj.style.display == 'none') {
                obj.style.display = '';
            }
            var scrolltop = document.documentElement.scrollTop;
            if (width <= 0) {
                width = obj.offsetWidth;
            }
            if (height <= 0) {
                height = obj.offsetHeight;
            }
            if (scrolltop == null || scrolltop == 0) {
                scrolltop = document.body.scrollTop;
            }
            var offsetHT = window.screen.height / 2 - height / 2;
            if (offsetHT <= 0) { offsetHT = 10; }
            var offsetWT = document.body.clientWidth / 2 - width / 2;
            if (offsetWT <= 0) { offsetWT = 10; }
            obj.style.top = String(scrolltop + offsetHT) + 'px';
            obj.style.left = String(offsetWT) + 'px';
        },
        /*鼠标附近显示弹出框
        鼠标点击处弹出divName,xlong、ylong分别为偏移量*/
        ShowPanel: function (obj, divName, xlong, ylong) {
            var showobj = YU.$C(divName);
            if (showobj) {
                if (showobj.style.display == 'none') {
                    showobj.style.display = '';
                }
                if (xlong)
                { showobj.style.top = YU.BaseCommon.gT(obj) + 20 + xlong + "px"; }
                else
                { showobj.style.top = YU.BaseCommon.gT(obj) + 20 + "px"; }
                if (ylong)
                { showobj.style.left = YU.BaseCommon.gL(obj) + ylong + "px"; }
                else
                { showobj.style.left = YU.BaseCommon.gL(obj) + "px"; }
            }
        },
        InsertScript: function (URL) {
            var script;
            script = document.createElement("script");
            script.type = "text/javascript";
            script.src = URL;
            document.getElementsByTagName("head")[0].appendChild(script);
        },
        ClearHTML: function (str) {
            str = str.replace(/<\/?[^>]*>/g, ''); /*去除HTML tag*/
            str.value = str.replace(/[ | ]*\n/g, '\n'); /*去除行尾空白*/
            return str;
        },
        ChkSelect: function (tagName, obj) {
            var act = obj.checked;
            var l;
            if (tagName != "" && tagName != null) {
                l = YU.$C(tagName).getElementsByTagName('input');
            }
            else {
                l = document.getElementsByTagName('input');
            }
            for (var i = 0; i < l.length; i++) {
                if (l[i].type == 'checkbox') {
                    l[i].checked = act;
                }
            }
        },
        CreateDays: function (date) {
            if (date != null && typeof (date) != 'undefined') {
                var mDay = date.split('-');
                if (mDay.length = 3) {
                    return new Date(mDay[0], mDay[1] - 1, mDay[2]);
                }
            }
            else {
                return null;
            }
        }
    },
    Grid: {
        searchParam: {}, /**/
        setParam: { dataTable: "", navTable: "" },
        showRules: [],
        searchUrl: "",
        /*计算分页时，当前页显示的起始结束页*/
        ComputePage: function (recordCount, cPageSize, cCurrentPage) {
            /*显示 1 2 3 4 [5] 6 7 8 9 页连接*/
            if (cPageSize != null && typeof (cPageSize) != 'undefined') { YU.Grid.searchParam.rows = cPageSize; }
            if (cCurrentPage != null && typeof (cCurrentPage) != 'undefined') { YU.Grid.searchParam.page = cCurrentPage; }
            var pageLink = 10;
            var startPageNo, endPageNo;
            var pageCount = Math.ceil(recordCount / YU.Grid.searchParam.rows);

            if (YU.Grid.searchParam.page <= 5) {
                startPageNo = 1;
                if (pageCount < 10) {
                    endPageNo = pageCount;
                }
                else {
                    endPageNo = startPageNo + 8;
                }
            }
            else {
                if (pageCount - YU.Grid.searchParam.page >= 4) {
                    startPageNo = YU.Grid.searchParam.page - 4;
                    endPageNo = startPageNo + 8;
                }
                else {
                    endPageNo = pageCount;
                    startPageNo = ((endPageNo - 8) < 0) ? 1 : endPageNo - 8;
                }
            }
            return new Array(startPageNo, endPageNo, pageCount);
        },
        highLightColor: '#eafcd5',
        clickColor: '#51b2f6',
        mouseOver: function () {
            var source = event.srcElement;
            if (source == null)
            { return; }
            if (source.tagName == "TR" || source.tagName == "TABLE")
                return;
            while (source.tagName != "TD") {
                source = source.parentElement;
                if (source == null) { return; }
            }
            source = source.parentElement;
            cs = source.children;
            if (cs[0].style.backgroundColor != YU.Grid.highLightColor && source.id != "nc" && cs[0].style.backgroundColor != YU.Grid.clickColor)
                for (i = 0; i < cs.length; i++) {
                    cs[i].style.backgroundColor = YU.Grid.highLightColor;
                }
        },
        mouseOut: function () {
            var source = event.srcElement;
            if (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "nc")
                return;
            source = source.parentElement;
            cs = source.children;
            if (event.toElement != source && cs[0].style.backgroundColor != YU.Grid.clickColor)
                for (i = 0; i < cs.length; i++) {
                    cs[i].style.backgroundColor = "";
                }
        },
        /*通用的返回数据处理方法*/
        SetTable: function (response) {
            /* rules[["Code","代码",200]]*/
            var Record = response;
            if (Record != null) {
                var recordCount = Record.total; /*记录总数*/
                var rows = Record.rows; /*当页记录数*/

                var str = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                str += "<tr>";
                for (var i = 0; i < YU.Grid.showRules.length; i++) {
                    str += "<th";
                    if (YU.Grid.showRules[i][3] != undefined && YU.Grid.showRules[i][3] != "") {
                        str += " class=\"" + YU.Grid.showRules[i][3] + "\"";
                    }
                    if (YU.Grid.showRules[i][2] >= 0) {
                        str += " width=\"" + (YU.Grid.showRules[i][2] == 0 ? "auto" : YU.Grid.showRules[i][2] + "px") + "\"";
                    }
                    str += ">" + YU.Grid.showRules[i][1] + "</th>";

                }
                str += "</tr>";
                if (rows.length == 0) {
                    str += "<tr><td colspan=\"" + YU.Grid.showRules.length + "\"  class=\"tl noborder\"><p class=\"tabs_tip\">抱歉，没有满足查询条件的相关数据！</p></td></tr>";
                }
                else {
                    for (var i = 0; i < rows.length; i++) {
                        str += "<tr>";
                        for (var j = 0; j < YU.Grid.showRules.length; j++) {
                            if (YU.Grid.showRules[j][4] != undefined) {
                                str += "<td>" + YU.Grid.showRules[j][4](eval("rows[i]." + YU.Grid.showRules[j][0]), rows[i], i) + "</td>";
                            }
                            else {
                                str += "<td>" + eval("rows[i]." + YU.Grid.showRules[j][0]) + "</td>";
                            }
                        }
                        str += "</tr>";

                    }
                }
                str += "</table>";
                $C(YU.Grid.setParam.dataTable).innerHTML = str;
                YU.Grid.SetNav(recordCount);
            }
            YU.Fun.LoadHide();
        },
        SetNav: function (recordCount) {
            var pageInfo = YU.Grid.ComputePage(recordCount);
            var str = "";
            if (YU.Grid.searchParam.page != 1 && pageInfo[1] > 1) {
                str += "<a href=\"javascript:void(0);\" onclick=\"javascript:YU.Grid.GoPage(" + (YU.Grid.searchParam.page - 1) + ");\">上一页</a>";
            }
            else {
                str += "<a href=\"javascript:void(0);\"  class=\"nolink\">上一页</a>";

            }
            for (var i = pageInfo[0]; i <= pageInfo[1]; i++) {
                if (YU.Grid.searchParam.page == i) {
                    str += "<span class=\"on\">" + i + "</span>";
                }
                else {
                    str += "<a href=\"javascript:void(0);\" onclick=\"javascript:YU.Grid.GoPage(" + i + ");\">" + i + "</a>";
                }
            }
            if (YU.Grid.searchParam.page < pageInfo[1] && pageInfo[1] > 1) {
                str += "<a href=\"javascript:void(0);\" onclick=\"javascript:YU.Grid.GoPage(" + (YU.Grid.searchParam.page + 1) + ");\">下一页</a>";
            }
            else {
                str += "<a href=\"javascript:void(0);\"  class=\"nolink\">下一页</a>";
            }
            $C(YU.Grid.setParam.navTable).innerHTML = str;
        },
        GoPage: function (page) {
            YU.Grid.searchParam.page = page;
            YU.Grid.DataGrid();
        },
        DataGrid: function (rules, url, param, setParam) {
            if (rules) {
                YU.Grid.showRules = rules;
                YU.Grid.searchParam = param;
                if (setParam.pageSize) {
                    YU.Grid.searchParam.rows = setParam.pageSize;
                }
                else {
                    YU.Grid.searchParam.rows = 10;
                }
                if (setParam.page) {
                    YU.Grid.searchParam.page = setParam.page;
                }
                else {
                    YU.Grid.searchParam.page = 1;
                }
                YU.Grid.setParam.dataTable = setParam.dataTab;
                YU.Grid.setParam.navTable = setParam.navTab;
                YU.Grid.searchUrl = url;
            }
            $C(YU.Grid.setParam.dataTable).innerHTML = "<img src=\""+YU.BaseData.WaitImg+"\"/>";
            $.post(YU.Grid.searchUrl, YU.Grid.searchParam, function (data, textStatus) {
                YU.Grid.SetTable(data);
            }, "json");


        }
    },
    inputRule: {/*扩展检查录入*/
        /* var Rules = [["校验字段id(必须)", "类型(必须)", "错误提示文字(必须)", "输入提示文字", "提示span_,没有默认为id"]];*/
        AttachEvent: function (target, eventName, handler, argsObject) {
            var eventHandler = handler;
            if (argsObject) {
                eventHander = function (e) {
                    handler.call(argsObject, e);
                }
            }
            if (window.attachEvent)/*IE*/
                target.attachEvent("on" + eventName, eventHander);
            else/*FF*/
                target.addEventListener(eventName, eventHander, false);
        },
        actionEvent: function (e) {
            var reg;
            var idName = this.Id;
            var errTxt = this.Txt;
            var typeStr = this.Fun;
            var showStr = this.sText;
            var SObjId = this.SObjId;
            YU.inputRule.CheckInput(idName, typeStr, errTxt, SObjId);
        },
        actionShowNote: function (e) {
            var reg;
            var idName = this.Id;
            var errTxt = this.Txt;
            var typeStr = this.Fun;
            var showStr = this.SText;
            var SObjId = this.SObjId;
            YU.inputRule.addShowNote(idName, typeStr, errTxt, showStr, SObjId);
        },
        addShowNote: function (idName, typeStr, errTxt, showStr, sObjId) {
            var objTxt;
            if (sObjId != '') {
                objTxt = YU.$C("span_" + sObjId);
            }
            else {
                objTxt = YU.$C("span_" + idName);
            }
            objTxt.innerHTML = showStr;
            objTxt.className = "";
        },
        addCheckRule: function (Rules) {
            for (var i = 0; i < Rules.length; i++) {
                var objId = YU.$C(Rules[i][0]);
                var objTxt = YU.$C("span_" + Rules[i][0]);
                var obj = new Object();
                obj.Id = Rules[i][0];
                obj.Fun = Rules[i][1];
                obj.Txt = Rules[i][2];
                obj.SText = '';
                obj.SObjId = '';
                if (Rules[i].length > 3) {
                    obj.SText = Rules[i][3];
                }
                if (Rules[i].length > 4) {
                    obj.SObjId = Rules[i][4];
                    objTxt = YU.$C("span_" + obj.SObjId);
                }
                if (objId != null && objTxt != null) {
                    YU.inputRule.AttachEvent(objId, "blur", YU.inputRule.actionEvent, obj);
                    YU.inputRule.AttachEvent(objId, "focus", YU.inputRule.actionShowNote, obj);
                }
            }
        },
        CheckInput: function (idName, typeStr, errTxt, sObjId) {
            var obj = YU.$C(idName);
            var objTxt;
            if (sObjId == '' || typeof (sObjId) == 'undefined') {
                objTxt = YU.$C("span_" + idName);
            }
            else {
                objTxt = YU.$C("span_" + sObjId);
            }
            switch (typeStr) {
                case "request":
                    if (obj.value.trim() == "") {
                        objTxt.className = "inputerr";
                        objTxt.innerHTML = errTxt;
                        return false;
                    } else {
                        objTxt.className = "inputok";
                        objTxt.innerHTML = "";
                        return true;
                    }
                    break;
                case "email":
                    reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
                    if (!reg.test(obj.value)) {
                        objTxt.className = "inputerr";
                        objTxt.innerHTML = errTxt;
                        return false;
                    } else {
                        objTxt.className = "inputok";
                        objTxt.innerHTML = "";
                        return true;
                    }
                    break;
                case "mobile":
                    reg = /^[0-9]{11}$/;
                    if (!reg.test(obj.value)) {
                        objTxt.className = "inputerr";
                        objTxt.innerHTML = errTxt;
                        return false;
                    } else {
                        objTxt.className = "inputok";
                        objTxt.innerHTML = "";
                        return true;
                    }
                    break;
                case "number":
                    if (!YU.Fun.IsNumb(obj.value)) {
                        objTxt.className = "inputerr";
                        objTxt.innerHTML = errTxt;
                        return false;
                    } else {
                        objTxt.className = "inputok";
                        objTxt.innerHTML = "";
                        return true;
                    }
                    break;
                case "password":
                    reg = /^[0-9a-zA-Z_]{5,15}$/;
                    if (!reg.test(obj.value)) {
                        objTxt.className = "inputerr";
                        objTxt.innerHTML = errTxt;
                        return false;
                    } else {
                        objTxt.className = "inputok";
                        objTxt.innerHTML = "";
                        return true;
                    }
                    break;
            }
            if (typeStr.indexOf("equal|") == 0) {
                var eId = typeStr.replace("equal|", "");
                var boll = (obj.value == $C(eId).value);
                if (boll) {
                    objTxt.className = "inputok";
                    objTxt.innerHTML = "";
                }
                else {
                    objTxt.className = "inputerr";
                    objTxt.innerHTML = errTxt;
                }
                return boll;
            }
        }
    }
};

function addFavorite(site_url, site_name) {
    var PageTitle = site_name;
    var PageUrl = site_url;
    if (PageTitle == "") {
        PageTitle = "1折包邮";
    }
    if (PageUrl == "") {
        PageUrl = "http://www.1zhebaoyou.com/";
    }
    try
    {
    if (window.sidebar) {
        window.sidebar.addPanel(PageTitle, PageUrl, "");
    } else  {
        window.external.addFavorite(PageUrl, PageTitle);
    }
    }catch(e){
        alert("加入收藏失败，请按Ctrl+D进行添加!");
    }
}

function SetHome(obj, vrl) {
    if (vrl == "") {
        vrl = "http://www.1zhebaoyou.com/";
    }
    try {
        obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
    }
    catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {

            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', vrl);
        }
    }
}

var KZuserName = "";
function userLoginStatus() {

    if ($C("ul-info")) {
        KZuserName = YU.Fun.GetCookie("uloginname");
        if (KZuserName != null && KZuserName != "null" && KZuserName!="") {
            $C("ul-info").innerHTML = "<a href=\"/user/default.aspx\" target=\"_blank\">" + KZuserName + '</a> 您好，欢迎与91客栈网一起旅行！  <a href="/user/logout.aspx">退出</a>|<a href="/user/myorder.aspx" target=\"_blank\">我的订单</a>';
        }
        else {
            KZuserName = "";
            var cM = YU.Fun.GetCookie("mobilebookingmobile");
            var tot = "";
            if (cM!=null && cM != "") {

                tot = "(" + cM.split('|')[0] + ")";
            }
            $C("ul-info").innerHTML = '您好，欢迎来到91客栈网！<a href="/user/login.aspx" target=\"_blank\">登录</a>|<a href="/user/register.aspx" target=\"_blank\">免费注册</a>|<a href="/booking/bookresv.aspx" target=\"_blank\">我的订单' + tot + '</a>';
            ad20140718url = "/user/register.aspx";
        }
    }
}

$(function () {
    userLoginStatus();
    $(".toTop").hide();
    $(window).scroll(function () {
        if ($(window).scrollTop() >= 100) {
            $(".toTop").show();
        } else {
            $(".toTop").hide();
        }
    });
});





jQuery.cookie = function (name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        var path = options.path ? '; path=' + options.path : '';
        var domain = options.domain ? '; domain=' + options.domain : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};


/**
* 删除左右两端的空格
*/
String.prototype.trim=function()
{
     return this.replace(/(^\s*)|(\s*$)/g, '');
}
/**
* 删除左边的空格
*/
String.prototype.ltrim=function()
{
     return this.replace(/(^\s*)/g,'');
}
/**
* 删除右边的空格
*/
String.prototype.rtrim=function()
{
     return this.replace(/(\s*$)/g,'');
 }


 function searchProduct() {
     var q = $C("mq").value;
     if (q == "搜索 你想要找的商品") {
         return false;
     }
 }
 function searchProduct1() {
     var q = $C("mq1").value;
     if (q == "搜索") {
         return false;
     }
 }

 function showMoreProduct() {
     $(".dealbox .deal").each(function (i) {
         $(this).css({"display":""});
     });
 }

 $(function () {
     var objLeft = $(".side_nav");
     var navH = objLeft.offset().top;
     $(window).scroll(function () {
         var scroH = $(this).scrollTop();
         if (scroH >= navH) {
             objLeft.addClass("affix");
         } else if (scroH < navH) {
             objLeft.removeClass("affix");
         }

         var bot = 500;
         if ((bot + $(window).scrollTop()) >= ($(document).height() - $(window).height())) {
             showMoreProduct();
         }
     });
 });
/*单一文件上传使用*/
var toElement = function () {
    var div = document.createElement('div');
    return function (html) {
        div.innerHTML = html;
        var el = div.childNodes[0];
        div.removeChild(el);
        return el;
    }
} ();
var getUID = function () {
    var id = 0;
    return function () {
        return 'ValumsAjaxUpload' + id++;
    }
} ();
function uploadFile(formId) {
    var id = getUID();
    FrameId = id;
    var iframe = toElement('<iframe src="javascript:false;" name="' + id + '" />');
    iframe.id = id;
    iframe.style.display = 'none';
    if (iframe.attachEvent) {
        iframe.attachEvent("onload", function () {
            rStr = document.getElementById(id).contentWindow.document.childNodes[document.getElementById(id).contentWindow.document.childNodes.length - 1].outerText;
            eval(rStr);
            if (upResult != undefined) {
                initSuccess(upResult);
            }
        });
    } else {
    iframe.onload = function () {/*ff*/
        rStr = document.getElementById(FrameId).contentWindow.document.childNodes[0].childNodes[1].innerHTML;
        eval(rStr);
        if (typeof (upResult) != 'undefined') {
            initSuccess(upResult);
        }
    };
    }
    document.body.appendChild(iframe);
    document.getElementById(formId).target = iframe.name;
    document.getElementById(formId).submit();
}

function initSuccess(upResult) {
    if (upResult.upSuccess == 1) {
    debugger
        $C("DivUploadImg").innerHTML = "<img src=\"/upload/" + upResult.FileName[0] + "\" width=\"100px;\">";
        $C("HidSendImg").value = upResult.FileName[0];
        
    }
}


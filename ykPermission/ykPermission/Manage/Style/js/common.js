/*
    公共JS类
*/
//显示当前时间
function ShowTime(obj)
{
    var now_time = new Date();
    var years = now_time.getFullYear();
    var months = now_time.getMonth();
    var dates = now_time.getDate();
    var days = now_time.getDay();
    var today = years + "年" + (months + 1) + "月" + dates + "日";
    var weeks;
    if (days == 0)
        weeks = "星期日";
    if (days == 1)
        weeks = "星期一";
    if (days == 2)
        weeks = "星期二";
    if (days == 3)
        weeks = "星期三";
    if (days == 4)
        weeks = "星期四";
    if (days == 5)
        weeks = "星期五";
    if (days == 6)
        weeks = "星期六";
    var hours = now_time.getHours();
    var minutes = now_time.getMinutes();
    var seconds = now_time.getSeconds();
    var timer = hours;
    timer += ((minutes < 10) ? ":0" : ":") + minutes;
    timer += ((seconds < 10) ? ":0" : ":") + seconds;
    var doc = document.getElementById(obj);
    doc.innerHTML = today + " " + timer + " " + weeks;
    setTimeout("ShowTime('" + obj + "')", 1000);
}
//复选框（全选、取消全选
function checkAll(obj, objName)
{
    var tb = document.getElementById("TbList");
    var rows = tb.getElementsByTagName("tr");
    var c_obj = document.getElementsByName(obj);
    if (obj.checked == true) {
        for (var i = 0; i < c_obj.length; i++) {
            if (!c_obj[i].disabled)
                c_obj[i].checked = true;
            rows[i + 1].className = "table_list_row_selected";
        }
    }
    else {
        for (var j = 0; j < c_obj.length; j++) {
            c_obj[j].checked = false;
            if (j % 2 == 0) {
                rows[j + 1].className = "table_list_row_normal";
            }
            else {
                rows[j + 1].className = "table_list_row_alert";
            }
        }
    }
}
//将字符串转换为货币格式
function formatRMB(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
    num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + '.' + cents);
}
//对每一个请求的URL进行处理，确保每一次请求都是新的,
//否则Url相同视为相同请求，浏览器则不执行，而是返回上一次请求结果（避免缓存问题)
function dealAjaxUrl(url) {
    var guid = GetGuid();
    var ajaxurl;
    if (url.lastIndexOf("?") > -1)//url带参数
        ajaxurl = url + "&ajaxGuid=" + guid;
    else //url不带参数
        ajaxurl = url + "?ajaxGuid=" + guid;
    ajaxurl += "&url=" + location.href; //加上URL参数，用于出现错误时返回上一页
    return ajaxurl;
}
//根据时间生成GUID
function GetGuid() {
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth();
    var date = now.getDate();
    var day = now.getDay();
    var hour = now.getHours();
    var minu = now.getMinutes();
    var sec = now.getSeconds();
    var mill = now.getMilliseconds();
    month = month + 1;
    if (month < 10) month = "0" + month;
    if (date < 10) date = "0" + date;
    if (hour < 10) hour = "0" + hour;
    if (minu < 10) minu = "0" + minu;
    if (sec < 10) sec = "0" + sec;
    var guid = month + date + hour + minu + sec + mill;
    return guid;
}
//设置文本框只读/禁用，并设置样式
function setReadonly(obj) {
    obj.attr('readonly', 'readonly');
    obj.addClass('readonly');
}
function setDisable(obj) {
    obj.attr('disabled', true);
    obj.addClass('readonly');
}
//取消文本框只读/禁用，并取消样式
function cancelReadonly(obj) {
    obj.removeAttr('readonly');
    obj.removeClass('readonly');
}
function cancelDisable(obj) {
    obj.removeAttr('disabled');
    obj.removeClass('readonly');
}
//easyui-datagrid设置分页控件
function setPager(p) {
    $(p).pagination({
        pageSize: 10, //每页显示的记录条数，默认为10 
        pageList: [10, 20, 50], //可以设置每页记录条数的列表 
        beforePageText: '第', //页数文本框前显示的汉字 
        afterPageText: '页    共 {pages} 页',
        displayMsg: '<div style="padding-right:20px;">当前显示 <b>{from} - {to}</b> 条记录   共 <b>{total}</b> 条记录<div>'
    });
}
//实现iframe自适应高度
function SetWinHeight(obj,height) {
    var win = obj;
    if (document.getElementById) {
        if (win && !window.opera) {
            if (win.contentDocument && win.contentDocument.body.offsetHeight) {
                win.height = ((win.contentDocument.body.offsetHeight < height) ? height : win.contentDocument.body.offsetHeight);
            }
            else if (win.Document && win.Document.body.scrollHeight) {
                win.height = ((win.Document.body.scrollHeight < height) ? height : win.Document.body.scrollHeight);
            }
        }
    }
}
//js字符过滤html标签互转函数
function htmlencode(str) {
    str = str.replace(/&/g, '&amp;');
    str = str.replace(/</g, '&lt;');
    str = str.replace(/>/g, '&gt;');
    str = str.replace(/(?:t| |v|r)*n/g, '<br />');
    str = str.replace(/ /g, '&nbsp; ');
    str = str.replace(/t/g, '&nbsp;&nbsp;&nbsp;');
    str = str.replace(/x22/g, '&quot;');
    str = str.replace(/x27/g, '&#39;');
    return str;
}

function htmldecode(str) {
    str = str.replace('&lt;', '<');
    str = str.replace('&gt;', '>');
    str = str.replace('&nbsp;', ' ');
    str = str.replace('<br>', '\n');
    str = str.replace('&amp;', '&');
    str = str.replace('&quot;', '"');
    return str;
}

function textencode(str) {
    str = str.replace(/&amp;/gi, '&');
    str = str.replace(/</g, '&lt;');
    str = str.replace(/>/g, '&gt;');
    return str;
}

function textdecode(str) {
    str = str.replace(/&amp;/gi, '&');
    str = str.replace(/&lt;/gi, '<');
    str = str.replace(/&gt;/gi, '>');
    return str;
}
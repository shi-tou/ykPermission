/*
封装easyui的Messager消息窗口
文件：msgbox.js
创建人：杨良斌
==================================================
参数说明：
title--标题
msg--显示消息内容
showType--定义如何显示消息窗口，可选值: null,slide(滑动),fade(渐隐渐显),show(渐大渐小)，默认为slide
==================================================
*/

//顶部左侧
function showTopLeft(title, msg,showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            right: '',
            left: 0,
            top: document.body.scrollTop + document.documentElement.scrollTop,
            bottom: ''
        }
    });
}
//顶部中间
function showTopCenter(title, msg,showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            right: '',
            top: document.body.scrollTop + document.documentElement.scrollTop,
            bottom: ''
        }
    });
}
//顶部右侧
function showTopRight(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            left: '',
            right: 0,
            top: document.body.scrollTop + document.documentElement.scrollTop,
            bottom: ''
        }
    });
}
//中部左侧
function showCenterLeft(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            left: 0,
            right: '',
            bottom: ''
        }
    });
}
//居中
function showCenter(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            right: '',
            bottom: ''
        }
    });
}
//中部右侧
function showCenterRight(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            left: '',
            right: 0,
            bottom: ''
        }
    });
}
//底部左侧
function showBottomLeft(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            left: 0,
            right: '',
            top: '',
            bottom: -document.body.scrollTop - document.documentElement.scrollTop
        }
    });
}
//底部中间
function showBottomCenter(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType,
        style: {
            right: '',
            top: '',
            bottom: -document.body.scrollTop - document.documentElement.scrollTop
        }
    });
}
//底部右侧
function showBottomRight(title, msg, showType) {
    $.messager.show({
        title: title,
        msg: msg,
        showType: showType
    });
}
//确定对话框
function confirmBox(title, msg) {
    $.messager.confirm(title, msg, function (r) {
        if (r) {
            return r;
        }
    });
}
//输入框
function promptBox(title, msg) {
    $.messager.prompt(title, msg, function (r) {
        if (r) {
            return r;
        }
    });
}
//弹出消息框
function AlertMsg(title,msg) {
    $.messager.alert(title,msg);
}
function AlertError(title, msg) {
    $.messager.alert(title, '<div style="line-height:30px;">' + msg + '</div>', 'error');
}
function AlertInfo(title, msg) {
    $.messager.alert(title, '<div style="line-height:30px;">' + msg + '</div>', 'info');
}
function AlertQuestion(title, msg) {
    $.messager.alert(title, '<div style="line-height:30px;">' + msg + '</div>', 'question');
}
function AlertWaring(title, msg) {
    $.messager.alert(title, '<div style="line-height:30px;">' + msg + '</div>', 'warning');
}
//提示信息
function ShowMsg(msg) {
    $.messager.show({
        title: '操作提示',
        msg: msg,
        showType: 'slide'
    });
}
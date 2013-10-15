//文件名：menu.js
//描述：用于点击菜单时，在主框架中显示对应内容（页面）
//时间：2013-02-25
//创建人：杨良斌
var index = 0;
function add(url, obj) {
    var title = $(obj).text().trim();
    if (isTabExist(title))
        return;
    //调用EasyUItabs方法添加选项卡
    $('#nav_tabs').tabs('add', {
        title: title,
        closable: true,
        content: "<iframe scrolling=\"auto\" frameborder=\"0\" src=\"" + url + "\" style=\"width:100%; height:100%;\"></iframe>"
    });
}
//选项卡是否存在，存在则选中并返回true,不存在则
function isTabExist(title) {
    var flag = $('#nav_tabs').tabs('exists', title);
    if (flag) {
        $('#nav_tabs').tabs('select', title);
        return true;
    }
    else
        return false;
}

/*****************************************
文件:Ajax公用JS操作类
时间:2012-08-28
作者:杨良斌
****************************************/
$(document).ready(function () {

});
/************Ajax分页（快速开发，此处只是简单的上页下页，以后可增加页码及跳转的分页导航）*************
container  -- 分页导航窗器
pageSize    -- 每页记录数
recordCount -- 记录总数
currentPage -- 当前页面索引
callBackFun -- 回调函数

**********************************/
function ListPager(container,pageSize,recordCount,currentPage,callBackFun) {   
    // 显示AJAX分页按钮
    this.Show = function () {
        if (recordCount > 0) {
            var html = "";
            //计算总页数" + pds.PageCount + " " + CurrentPage + "</b>页 <b>" + PageSize + "</b>条/页 共<b>" + AllCount + "</b>条记录\n"
            var pageCount = Math.ceil(recordCount / pageSize);
            //if (pageCount != 1) {
                html += "共<b>" + pageCount + "</b>页 第<b>" + currentPage +"</b>页 <b>"+pageSize+"</b>条/页 共<b>"+recordCount+"</b>条记录";
                
                if (currentPage > 1) html += '<a href="javascript:void(0);" toPage="1">首页</a><a href="javascript:void(0);" toPage="' + (currentPage - 1) + '">上一页</a>'
                else {html += '<span>首页</span><span>上一页</span>'};
                if (currentPage < pageCount) html += '<a href="javascript:void(0);" toPage="' + (currentPage + 1) + '">下一页</a><a href="javascript:void(0);" toPage="' + pageCount + '">尾页</a>'
                else html += '<span>下一页</span><span>尾页</span>';
                $("#" + container).html('<div class="listPager">' + html + '</div>');
                $("#" + container).show();
            //} else {
                //$("#" + container).hide();
            //}
            $("#" + container + " a").click(function () {
                var p = $(this).attr("toPage");
                callBackFun(p);
            });
        }
        else {
            $("#" + container).css("display", "none");
        }
    };
}

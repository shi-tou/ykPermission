//文件名：menu.js
//描述：用于点击菜单时，在主框架中显示对应内容（页面）
//时间：2013-02-25
//创建人：杨良斌
var index = 0;
function add(type) {
    var title = '';
    switch (type) {
        //***********个人管理*************  
        case "AccountInfo":
            title = "修改帐号信息";
            if (isTabExist(title))
                return;
            addTab(title, "User/AccountInfo.aspx", true)
            break;
        case "AccountPassword":
            title = "修改账号密码";
            if (isTabExist(title))
                return;
            addTab(title, "User/AccountPassword.aspx", true)
            break;
        case "PostReport":
            title = "个人统计";
            if (isTabExist(title))
                return;
            addTab(title, "User/PostReport.aspx", true)
            break;
        case "SysLog":
            title = "操作日志";
            if (isTabExist(title))
                return;
            addTab(title, "User/SysLog.aspx", true)
            break;
        //***********用户管理*************
        case "AdminGroup":
            title = "管理权限组";
            if (isTabExist(title))
                return;
            addTab(title, "User/AdminGroup.aspx", true)
            break;        
        case "AdminList":
            title = "管理员列表";
            if (isTabExist(title))
                return;
            addTab(title, "User/AdminList.aspx", true)
            break;
        case "AdminPwd":
            title = "修改管理密码";
            if (isTabExist(title))
                return;
            addTab(title, "User/AdminPwd.aspx", true)
            break;
        case "MemberLevel":
            title = "会员等级";
            if (isTabExist(title))
                return;
            addTab(title, "User/MemberLevel.aspx", true)
            break;
        case "MemberAdd":
            title = "添加会员";
            if (isTabExist(title))
                return;
            addTab(title, "User/MemberAdd.aspx", true)
            break;
        case "MemberList":
            title = "会员列表";
            if (isTabExist(title))
                return;
            addTab(title, "User/MemberList.aspx", true)
            break;
        case "MemberSetting":
            title = "会员功能配置";
            if (isTabExist(title))
                return;
            addTab(title, "User/MemberSetting.aspx", true)
            break;
        //***********栏目管理************* 
        case "SortAttributeList":
            title = "网站栏目属性";
            if (isTabExist(title))
                return;
            addTab(title, "Sort/SortAttributeList.aspx", true)
            break;
        case "TemplateList":
            title = "网站栏目模板";
            if (isTabExist(title))
                return;
            addTab(title, "Sort/TemplateList.aspx", true)
            break;
        case "SortList":
            title = "网站栏目管理";
            if (isTabExist(title))
                return;
            addTab(title, "Sort/SortList.aspx", true)
            break;
        case "SortStaticPage":
            title = "栏目静态生成"; 
            if (isTabExist(title))
                return;
            addTab(title, "Sort/SortStaticPage.aspx", true)
            break;
        //***********内容管理*************  
        case "NewsList":
            title = "新闻资讯管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/NewsList.aspx", true)
            break;
        case "GoodsList":
            title = "公司产品管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/GoodsList.aspx", true)
            break;
        case "CaseList":
            title = "成功案例管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/CaseList.aspx", true)
            break;
        case "DownloadList":
            title = "资料下载管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/DownloadList.aspx", true)
            break;
        case "JobList":
            title = "招聘信息管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/JobList.aspx", true)
            break;
        case "SinglePage":
            title = "单页内容管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/SinglePage.aspx", true)
            break;
        case "FileList":
            title = "文件资源管理";
            if (isTabExist(title))
                return;
            addTab(title, "Content/FileList.aspx", true)
            break;
        //***********系统管理*************   
        case "GlobalSetting":
            title = "全局参数配置";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/GlobalSetting.aspx", true)
            break;
        case "QQ":
            title = "网站客服配置";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/QQ.aspx", true)
            break;
        case "Template":
            title = "网站模板管理";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/Template.aspx", true)
            break;
        case "Style":
            title = "网站样式管理";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/Style.aspx", true)
            break;
        case "DataBase":
            title = "数据库管理";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/DataBase.aspx", true)
            break;
        case "WaterImage":
            title = "图片水印管理";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/WaterImage.aspx", true)
            break;
        case "EmailSetting":
            title = "邮件发送设置";
            if (isTabExist(title))
                return;
            addTab(title, "Sys/EmailSetting.aspx", true)
            break;
        //***********SEO优化管理*************     
        case "FriendLink":
            title = "友情链接管理";
            if (isTabExist(title))
                return;
            addTab(title, "Seo/FriendLink.aspx", true)
            break;
        case "StaticSetting":
            title = "生成静态设置";
            if (isTabExist(title))
                return;
            addTab(title, "Seo/StaticSetting.aspx", true)
            break;
        case "KeyWord":
            title = "关键词管理";
            if (isTabExist(title))
                return;
            addTab(title, "Seo/KeyWord.aspx", true)
            break;
        case "EngineSite":
            title = "网站提交入口";
            if (isTabExist(title))
                return;
            addTab(title, "Seo/EngineSite.aspx", true)
            break;
        case "InfoRelease":
            title = "企业信息发布";
            if (isTabExist(title))
                return;
            addTab(title, "Seo/InfoRelease.aspx", true)
            break;
        default:
            alertInfo('温馨提示', '页面建设中……');
            break;
    }
}
//调用EasyUItabs方法添加选项卡
function addTab(title,url,closable) {
    $('#nav_tabs').tabs('add', {
        title: title,
        closable: closable,
        content: "<iframe scrolling=\"auto\" frameborder=\"0\" src=\"" + url + "\" style=\"width:100%;\" onload=\"Javascript:SetWinHeight(this,450);\"></iframe>"
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

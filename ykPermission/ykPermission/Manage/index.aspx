<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ykPermission.Web.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>小杨权限管理系统</title>
    <script src="js/menu.js" type="text/javascript"></script>
    <script language="javascript">
        $(function () {
            ShowTime("time")
        });
    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
        <div data-options="region:'north',border:false,split:false" style="height:70px;background:#E6EEF8;padding:10px;">
            <div class="headL"><h1 style="float:left;">后台权限管理</h1><span style="float:left;">&nbsp;--&nbsp;power by yangliangbin</span></div>
            <div class="headR">当前时间：<span id="time"></span><span onclick="adminLoginOut();">退出登录</span></div>
        </div>
	    <div data-options="region:'west',split:true,title:'系统菜单',iconCls:'icon-menuflag'" style="width:150px;">
            <div class="easyui-accordion" data-options="fit:true,border:false" >
                <div title="系统管理" style="padding:10px 10px 10px 20px;">
                    <ul class="menuUL">
                        <li><a href="javascript:add('AccountInfo')">修改帐号信息</a></li>
                        <li><a href="javascript:add('AccountPassword')">修改账号密码</a></li>
                        <li><a href="javascript:add('PostReport')">个人统计</a></li>
                        <li><a href="javascript:add('SysLog')">操作日志</a></li>                        
                    </ul>
                </div>
                <div title="用户管理" style="padding:10px 10px 10px 20px;">
                    <ul class="menuUL">
                        <li><a href="javascript:add('AdminGroup')">管理权限组</a></li>
                        <li><a href="javascript:add('AdminList')">管理员列表</a></li>
                        <li><a href="javascript:add('MemberLevel')">会员等级管理</a></li>
                        <li><a href="javascript:add('MemberAdd')">会员管理</a></li>
                        <li><a href="javascript:add('MemberList')">会员列表</a></li>
                        <li><a href="javascript:add('MemberSetting')">会员功能配置</a></li>
                    </ul>
                </div>
                <div title="栏目管理" data-options="selected:true" style="padding:10px 10px 10px 20px;">
                    <ul class="menuUL">
                        <li><a href="javascript:add('SortAttributeList')">网站栏目属性</a></li>
                        <li><a href="javascript:add('TemplateList')">网站栏目模板</a></li>
                        <li><a href="javascript:add('SortList')">网站栏目管理</a></li>
                        <li><a href="javascript:add('SortStaticPage')">栏目静态生成</a></li>
                    </ul>
                </div>
				<div title="内容管理" style="padding:10px 10px 10px 20px;">
					<ul class="menuUL">
                        <li><a href="javascript:add('NewsList'))">新闻资讯管理</a></li>
                        <li><a href="javascript:add('GoodsList')">公司产品管理</a></li>
                        <li><a href="javascript:add('CaseList')">成功案例管理</a></li>
                        <li><a href="javascript:add('DownloadList')">资料下载管理</a></li>
                        <li><a href="javascript:add('JobList')">招聘信息管理</a></li>
                        <li><a href="javascript:add('SinglePage'))">单页内容管理</a></li>
                        <li><a href="javascript:add('FileList')">文件资源管理</a></li>
                    </ul>
				</div>
                <div title="系统管理" style="padding:10px 10px 10px 20px;">
					<ul class="menuUL">
                        <li><a href="javascript:add('GlobalSetting')">全局参数配置</a></li>
                        <li><a href="javascript:add('QQ')">网站客服配置</a></li>
                        <li><a href="javascript:add('Template')">网站模板管理</a></li>
                        <li><a href="javascript:add('Style')">网站样式管理</a></li>
                        <li><a href="javascript:add('DataBase')">数据库管理</a></li>
                        <li><a href="javascript:add('WaterImage')">图片水印管理</a></li>
                        <li><a href="javascript:add('EmailSetting')">邮件发送设置</a></li>
                    </ul>
				</div>
				<div title="SEO优化管理" style="padding:10px 10px 10px 20px">
					<ul class="menuUL">
                        <li><a href="javascript:add('FriendLink')">友情链接管理</a></li>
                        <li><a href="javascript:add('StaticSetting')">生成静态设置</a></li>
                        <li><a href="javascript:add('KeyWord')">关键词管理</a></li>
                        <li><a href="javascript:add('EngineSite')">网站提交入口</a></li>
                        <li><a href="javascript:add('InfoRelease')">企业信息发布</a></li>
                    </ul>
				</div>
			</div>
            
        </div>
	    <div data-options="region:'center',title:'欢迎登录云客网站后台',iconCls:'icon-tip'">
            <div id="nav_tabs" class="easyui-tabs" data-options="border:false">
		        <div title="首页" style="padding:10px">
                   
		        </div>		        
	        </div>
        </div>
    </form>
</body>
</html>

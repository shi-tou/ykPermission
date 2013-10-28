<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ykPermission.Web.Manage.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>权限管理系统</title>
    <script src="Style/js/menu.js" type="text/javascript"></script>
    <script language="javascript">
        $(function () {
            ShowTime("time")
        });
    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
        <!--顶部-->
        <div data-options="region:'north',border:false,split:false" style="height:70px;background:#f2f2f2;padding:10px;">
            <div class="headL"><h1 style="float:left;">权限管理系统</h1><span style="float:left;">&nbsp;--&nbsp;power by yangliangbin</span></div>
            <div class="headR">当前时间：<span id="time"></span><span onclick="adminLoginOut();">退出登录</span></div>
        </div>
        <!--左侧菜单-->
	    <div data-options="region:'west',split:true,title:'系统菜单',iconCls:'icon-menuflag'" style="width:150px;">
            <div class="easyui-accordion" data-options="fit:true,border:false" >
                <div title="系统管理" style="padding:10px 10px 10px 20px;">
                    <ul class="menuUL">
                        <li><a href="javascript:void(0)" onclick="add('Master/ActionList.aspx',this)">资源管理</a></li>
                        <li><a href="javascript:void(0)" onclick="add('Master/GroupList.aspx',this)">角色管理</a></li>
                        <li><a href="javascript:void(0)" onclick="add('Master/MasterList.aspx',this)">用户管理</a></li>
                    </ul>
                </div>
			</div>
        </div>
        <!--内容-->
	    <div data-options="region:'center',title:'',iconCls:'icon-tip'">
            <div id="nav_tabs" class="easyui-tabs" data-options="fit:true,border:false">
		        <div title="首页" style="padding:10px">
                   
		        </div>		        
	        </div>
        </div>
        <!--底部-->
        <div data-options="region:'south',border:false" style=" line-height:22px;background:#f2f2f2; text-align:center;">
            权限管理系统
        </div>
    </form>
</body>
</html>

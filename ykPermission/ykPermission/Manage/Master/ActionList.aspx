<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionList.aspx.cs" Inherits="ykPermission.Web.Manage.Master.ActionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<<<<<<< HEAD
    <title>资源管理-<%=AdminTitle %></title>
=======
    <title>权限管理</title>
>>>>>>> 006fc8a778f4be835b44e426de4bda4782222fb2
    <script src="../Style/js/action.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <!--列表-->
    <table id="ListTable" data-options="toolbar:'#tb',iconCls:'icon-tip'">
    </table>
    <!--工具栏-->
    <div id="tb">
        <a href="#"  class="easyui-linkbutton" iconcls="icon-add" plain="true" onclick="Add()">添加</a> 
        <a href="#"  class="easyui-linkbutton" iconcls="icon-edit" plain="true" onclick="Edit()">编辑</a>
        <a href="#"  class="easyui-linkbutton" iconcls="icon-edit" plain="true" onclick="Delete()">删除</a>
    </div>
    <!--弹出窗-->
    <div id="win" class="easyui-window" style=" " data-options="iconCls:'icon-save',top:'50px',closed:true,minimizable:false,maximizable:false,collapsible:false">
        <iframe id="iframe" name="iframe" frameborder="0" style="width: 100%; height: 100%;"></iframe>
    </div>
<<<<<<< HEAD
=======
    <!--右键菜单-->
    <div id="mm" class="easyui-menu" style="width: 120px; background:#fff;" >
        <div onclick="AddMenu(true)" data-options="iconCls:'icon-add'">添加根栏目</div>
		<div onclick="AddMenu(false)" data-options="iconCls:'icon-remove'">添加子栏目</div>
        <div onclick="EditMenu()" data-options="iconCls:'icon-remove'">编辑栏目</div>
		<div class="menu-sep"></div>
		<div onclick="CollapseAll()">收起所有</div>
		<div onclick="ExpandAll()">打开所有</div>
    </div>
>>>>>>> 006fc8a778f4be835b44e426de4bda4782222fb2
    </form>
</body>
</html>

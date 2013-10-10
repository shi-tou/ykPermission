<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="ykPermission.Web.Manage.Master.GroupList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理--<%=AdminTitle %></title>
    <script src="../Style/js/group.js" type="text/javascript"></script>
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
        <a href="#"  class="easyui-linkbutton" iconcls="icon-edit" plain="true" onclick="Edit()">删除</a>
    </div>
    <!--弹出窗-->
    <div id="win" class="easyui-window" style=" " data-options="iconCls:'icon-save',top:'50px',closed:true,minimizable:false,maximizable:false,collapsible:false">
        <iframe id="iframe" name="iframe" frameborder="0" style="width: 100%; height: 100%;"></iframe>
    </div>
    </form>
</body>
</html>

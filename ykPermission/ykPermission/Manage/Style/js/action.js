//文件名：action.js
//描述：权限管理
//时间：2013-09-29
//创建人：杨良斌

$(function() {
    GetList();
});
var url = '/Manage/Ajax/Master.ashx';
//获取用户列表
function GetList() {
    var queryParams = { 'action': 'GetActionList'};
    var tab = $('#ListTable');
    tab.treegrid({
        title: '栏目列表',
        url: dealAjaxUrl(url),
        idField: 'ID',
        treeField: 'ActionName',
        animate: true,
        columns: [[
            { field: 'ID', width: 30, align: '', checkbox: true },
            { field: 'ActionName', title: '名称', width: 180, align: 'center' },
            { field: 'Link', title: '链接', width: 150, align: 'center' },
            { field: 'Action', title: '动作', width: 150, align: 'center' },
            { field: 'Type', title: '类别', width: 100, align: 'center',formatter:GetType },
            { field: 'Sort', title: '排序号', width: 100, align: 'center' },
            { field: 'Disabled', title: '禁用', width: 100, align: 'center', formatter: GetDisabled }
        ]],
        queryParams: queryParams,
        onContextMenu: OnContextMenu
    });
}
//资源类别
function GetType(v) {
    if (v == 1)
        return '分栏';
    else if (v == 2)
        return '菜单';
    else if (v == 3)
        return '功能';
}
//添加
function Add() {
    OpenWin('添加用户', 450, 400, '/Manage/Master/ActionAdd.aspx');
}
//修改
function Edit() {
    var rows = GetSelectValue('ListTable');
    if (rows.length == 1) {
        id = rows[0].ID;
        OpenWin('修改用户',450, 400, '/Manage/Master/ActionAdd.aspx?ID=' + id);
    }
    else {
        AlertInfo('操作提示', '请选择一条要修改的记录！');
    }
}
//删除
function Delete() {
    var code = '';
    var rows = GetSelectValue('ListTable');
    if (rows.length == 1) {
        id = rows[0].ID;
        $.messager.confirm('操作提示', '是否确认删除操作？', function(r) {
            if (r) {
                $.ajax({
                    url: dealAjaxUrl(url),
                    data: 'action=DeleteAction&ID=' + id,
                    dataType: 'json',
                    type: 'POST',
                    success: function(data) {
                        if (data.res == 0) {
                            AlertInfo('操作提示', '删除成功！');
                            GetList();
                        }
                        else {
                            AlertInfo('操作提示', '该数据已在系统中使用，不能删除！');
                        }
                    }
                });
            }
        });
    }
    else {
        AlertInfo('操作提示', '请选择要删除的记录');
    }
}
//右键菜单
function OnContextMenu(e, row) {
    e.preventDefault();
    $(this).treegrid('select', row.ID);
    $('#mm').menu('show', {
        left: e.pageX,
        top: e.pageY
    });
}
//关闭所有节点
function CollapseAll() {
    $('#ListTable').treegrid('collapseAll');
}
//展开所有节点
function ExpandAll() {
    $('#ListTable').treegrid('expandAll');
}
//新增根栏目（IsBoot为true则添加根栏目，false则添加子栏目）
function AddMenu(IsBoot) {
    var tab = $('#ListTable');
    var node = tab.treegrid('getSelected')
    if (IsBoot) {
        openWin('添加根栏目', 600, 430, '/Admin/Sys/MenuAdd.aspx');
    }
    else {
        if (node == null || node == 'undefined')
            alertInfo('操作提示', '请选择一条记录！');
        openWin('添加子栏目', 600, 430, '/Admin/Sys/MenuAdd.aspx?PID=' + node.ID + '&PMenuName=' + node.MenuName);
    }
}
//编辑栏目
function EditMenu() {
    var tab = $('#ListTable');
    var node = tab.treegrid('getSelected')
    if (node) {
        openWin('编辑栏目', 600, 430, '/Admin/Sys/MenuAdd.aspx?ID=' + node.ID);
    }
    else {
        alertInfo('操作提示', '请选择要修改的记录！');
    }
}
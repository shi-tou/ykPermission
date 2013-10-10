//文件名：group.js
//描述：角色管理
//时间：2013-09-29
//创建人：杨良斌

$(function () {
    GetList();
});
var url = '/Manage/Ajax/Master.ashx';
//获取用户列表
function GetList() {
    var queryParams = { 'action': 'GetGroupList' };
    var tab = $('#ListTable');
    tab.datagrid({
        title: '角色列表',
        url: dealAjaxUrl(url),
        columns: [[
                        { field: 'ID', title: '', width: 30, align: 'center', checkbox: true },
                        { field: 'GroupName', title: '角色名称', width: 100, align: 'center' },
                        { field: 'GroupInfo', title: '角色描述', width: 100, align: 'center' },
                        { field: 'MasterName', title: '创建人', width: 120, align: 'center' },
                        { field: 'CreateTime', title: '修改时间', width: 120, align: 'center', formatter: FormatTime }
                        ]],
        loadMsg: '正在加载数据，请稍候……',
        rownumbers: true, //显示记录数
        queryParams: queryParams, //查询参数
        pagination: true,
        singleSelect: true,
        pageSize: 20,
        nowrap: false
    });
    //设置分页
    SetPager(tab);
}
//添加
function Add() {
    OpenWin('添加角色', 500, 450, '/Manage/Master/GroupAdd.aspx');
}
//修改
function Edit() {
    var rows = GetSelectValue('ListTable');
    if (rows.length == 1) {
        id = rows[0].ID;
        OpenWin('修改角色', 500, 450, '/Manage/Master/GroupAdd.aspx?ID=' + id);
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
        $.messager.confirm('操作提示', '是否确认删除操作？', function (r) {
            if (r) {
                $.ajax({
                    url: dealAjaxUrl(url),
                    data: 'action=DeleteGroup&ID=' + id,
                    dataType: 'json',
                    type: 'POST',
                    success: function (data) {
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

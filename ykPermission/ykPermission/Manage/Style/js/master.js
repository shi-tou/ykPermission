//文件名：master.js
//描述：用户管理
//时间：2013-09-29
//创建人：杨良斌

$(function() {
    GetList();
});
var url = '/Manage/Ajax/Master.ashx';
//获取用户列表
function GetList() {
    var queryParams = { 'action': 'GetMasterList'};
    var tab = $('#ListTable');
    tab.datagrid({
        title: '用户列表',
        url: dealAjaxUrl(url),
        columns: [[
                        { field: 'ID', title: '', width: 30, align: 'center',checkbox: true },
                        { field: 'UserName', title: '用户名', width: 100, align: 'center' },
                        { field: 'MasterName', title: '姓名', width: 100, align: 'center' },
                        { field: 'Disabled', title: '禁用', width: 60, align: 'center', formatter: GetDisabled },
                        { field: 'CreateTime', title: '创建时间', width: 120, align: 'center', formatter: FormatTime },
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
    OpenWin('添加用户', 400, 300, '/Manage/Master/MasterAdd.aspx');
}
//修改
function Edit() {
    var rows = GetSelectValue('ListTable');
    if (rows.length == 1) {
        id = rows[0].ID;
        OpenWin('修改用户',400, 300, '/Manage/Master/MasterAdd.aspx?ID=' + id);
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
                    data: 'action=DeleteMaster&ID=' + id,
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
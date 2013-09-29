<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterAdd.aspx.cs" Inherits="ykPermission.Web.Manage.Master.MasterAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="infotable">
            <tr>
                <td style="width:100px;" class="tr">用户名：</td>
                <td><asp:TextBox ID="txtUserName" runat="server" CssClass="easyui-validatebox txt" data-options="required:true" missingmessage="请输入用户名"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">密码：</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="easyui-validatebox txt" data-options="required:true" missingmessage="请输入密码"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">姓名：</td>
                <td><asp:TextBox ID="txtMasterName" runat="server" CssClass="easyui-validatebox txt" data-options="required:true" missingmessage="请输入姓名"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">禁用：</td>
                <td><asp:CheckBox ID="cbDisabled" runat="server" /></td>
            </tr>
        </table>
        <div class="action">
        <asp:Button runat="server" ID="BtnSubmit" Text="确认" CssClass="btn" OnClientClick="return $('#form1').form('validate')" OnClick="BtnSubmit_Click" />
        <asp:Button runat="server" ID="btnCancel" Text="取消" CssClass="btn" OnClientClick="CloseWin()" />
    </div>
    </div>
    </form>
</body>
</html>
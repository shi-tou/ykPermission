<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionAdd.aspx.cs" Inherits="ykPermission.Web.Manage.Master.ActionAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源添加-<%=AdminTitle %></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="infotable" >
            <tr>
                <td class="tr">上一级：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtParentCode" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tr">资源编码：</td>
                <td><asp:TextBox runat="server" ID="txtCode"  CssClass="easyui-validatebox txt" data-options="required:true" missingmessage="请输入编码"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">类型：</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlType" CssClass="txt">
                        <asp:ListItem Value="1">分栏</asp:ListItem>
                        <asp:ListItem Value="2">菜单</asp:ListItem>
                        <asp:ListItem Value="3">功能</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:100px;" class="tr">资源名称：</td>
                <td><asp:TextBox ID="txtName" runat="server" CssClass="easyui-validatebox txt" data-options="required:true" missingmessage="请输入资源名称"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td class="tr">链接：</td>
                <td><asp:TextBox ID="txtLink" runat="server" CssClass="txt"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">事件：</td>
                <td><asp:TextBox ID="txtAction" runat="server" CssClass="txt" ></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">资源图标：</td>
                <td><asp:TextBox ID="txtIcon" runat="server" CssClass="txt"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">排序：</td>
                <td><asp:TextBox ID="txtSort" runat="server" CssClass="easyui-numberbox txt" data-options="min:0,max:100"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">禁用：</td>
                <td><asp:CheckBox ID="cbDisabled" runat="server"/></td>
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

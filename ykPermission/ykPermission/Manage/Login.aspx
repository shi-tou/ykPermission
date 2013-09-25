<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ykPermission.Manage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" top:50%; left:50%; line-height:22px;">
        账号：<br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
         密码：<br />
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>

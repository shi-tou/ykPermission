<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ykPermission.Manage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="bg">
        <div class="box">
            <div class="title">小杨权限管理系统V1.0</div>
            <asp:TextBox ID="txtUserName" runat="server" Text="admin" class="txt"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="txt"></asp:TextBox>
            <div class="action">
                <asp:Button ID="btnLogin" runat="server" Text="登录" class="btn" onclick="btnLogin_Click" />
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div style=" margin-top:15px; line-height:22px; text-align:right;"></div>
        </div>
    </div>
    <div style=" top:50%; left:50%; line-height:22px;  display:none;" >       
        
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupAdd.aspx.cs" Inherits="ykPermission.Web.Manage.Master.GroupAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色添加-<%=AdminTitle %></title>
    <script src="../Style/zTree_v3/js/jquery.ztree.all-3.5.min.js" type="text/javascript"></script>
    <link href="../Style/zTree_v3/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="infotable" >
            <tr>
                <td style="width:100px;" class="tr">角色名称：</td>
                <td><asp:TextBox ID="txtGroupName" runat="server" CssClass="easyui-validatebox txt" Width="200px" data-options="required:true" missingmessage="请输入角色名称"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tr">角色描述：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtGroupInfo" CssClass="txt" Width="200px" Height="50px" Font-Size="13px"  TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tr">权限分配：</td>
                <td>
                    <div style="width:300px; height:200px; overflow:scroll;border:solid 1px #d4d4d4;">
                        <ul id="TreeAction" class="ztree" style="width:260px; overflow:auto;"></ul>
                    </div>
                </td>
            </tr>
        </table>
        <div class="action">
            <asp:Button runat="server" ID="BtnSubmit" Text="确认" CssClass="btn" OnClientClick="return $('#form1').form('validate')" OnClick="BtnSubmit_Click" />
            <asp:Button runat="server" ID="btnCancel" Text="取消" CssClass="btn" OnClientClick="CloseWin()" />
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfAction" />
    <script>
        $(function () {
            var json='<%=ActionJson %>'
            if(json=='')
                return;
            $.fn.zTree.init($("#TreeAction"), setting, <%=ActionJson %>);
            var treeObj = $.fn.zTree.getZTreeObj("TreeAction");
            treeObj.expandAll(true);
        });
        var setting = {
            check: {
                enable: true
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onCheck: getAllCheckNodes
            }
        };
        //获取所有选中的值
        function getAllCheckNodes() {
            var treeObj = $.fn.zTree.getZTreeObj('TreeAction'),
                    nodes = treeObj.getCheckedNodes(true),
                    v = '';
            for (var i = 0; i < nodes.length; i++) {
                if (v != '')
                    v += ',';
                v += nodes[i].id;
            }
            $('#hfAction').val(v);
        }
       
    </script>
    </form>
</body>
</html>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ykPermission.Service;

namespace ykPermission.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        //注入
        private IMasterService masterService;
        public IMasterService MasterService
        {
            set { masterService = value; }
        }
        /// <summary>
        /// 加载
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 登录
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text == "" || this.txtPassword.Text == "")
            {
                this.lblMsg.Text="账号/密码不能为空！";
                return;
            }
            int res = masterService.MasterLogin(this.txtUserName.Text, this.txtPassword.Text);
            if (res == 1)
            {
                this.lblMsg.Text = "账号不存在！";
                this.txtUserName.Text = "";
                this.txtPassword.Text = "";
                this.txtUserName.Focus();
                return;
            }
            if (res == 2)
            {
                this.lblMsg.Text = "账号已禁用，请与管理员联系！";
                return;
            }
            if (res == 3)
            {
                this.lblMsg.Text = "密码不正确，请重新输入！";
                this.txtPassword.Text = "";
                this.txtPassword.Focus();
                return;
            }
            Response.Redirect("Index.aspx");
        }
    }
}
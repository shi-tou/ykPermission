using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ykPermission.Service;
using ykPermission.Common;

namespace ykPermission.Web.Manage.Master
{
    public partial class MasterAdd : AdminPage
    {
        //注入
        private IMasterService masterService;
        public IMasterService MasterService
        {
            set { masterService = value; }
        }
        private int _ID
        {
            get { return GetRequestInt("ID", 0); }
        }

        /// <summary>
        /// 加载
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }
        public void BindInfo()
        {
            if (_ID == 0)
                return;
            DataTable dt = masterService.GetDataByKey("T_Master", "ID", _ID);
            DataRow dr=dt.Rows[0];
            this.txtUserName.Text = Convert.ToString(dr["UserName"]);
            this.txtPassword.Attributes.Remove("data-options");
            this.txtMasterName.Text = Convert.ToString(dr["MasterName"]);
            this.cbDisabled.Checked = Convert.ToBoolean(dr["Disabled"]);
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = masterService.GetDataByKey("T_Master", "ID", _ID);
            DataRow dr = null;
            if (dt.Rows.Count == 0)
            {
                dr = dt.NewRow();
                dr["CreateBy"] = MasterInfo.ID;
                dr["CreateTime"] = DateTime.Now;
            }
            else
            {
                dr = dt.Rows[0];
                dr["UpdateTime"] = DateTime.Now;
            }
            dr["UserName"] = this.txtUserName.Text;
            if (this.txtPassword.Text != "")
                dr["Password"] = DESEncrypt.Encrypt(this.txtPassword.Text);
            dr["MasterName"] = this.txtMasterName.Text;
            dr["Disabled"] = this.cbDisabled.Checked;
            if (dt.Rows.Count == 0)
                dt.Rows.Add(dr);
            int res = masterService.UpdateDataTable(dt);
            if (res > 0)
                InvokeScript("CloseWin('添加成功！',parent.GetList)");
            else
                InvokeScript("CloseWin('添加失败！')");
        }
    }
}

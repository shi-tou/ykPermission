using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ykPermission.Service;
using System.Data;

namespace ykPermission.Web.Manage.Master
{
    public partial class ActionAdd : AdminPage
    {
        //注入
        private IMasterService masterService;
        public IMasterService MasterService
        {
            set { masterService = value; }
        }
        /// <summary>
        /// 修改的资源编码
        /// </summary>
        private int _ID
        {
            get { return GetRequestInt("ID", 0); }
        }
        /// <summary>
        /// 添加子节点的父编码
        /// </summary>
        private string ParentCode
        {
            get { return GetRequestStr("ParentCode", ""); }
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_ID != 0)
                    BindInfo();
                if (ParentCode != "")
                    this.txtParentCode.Text = ParentCode;
                this.txtParentCode.ReadOnly = true;
                this.txtParentCode.Attributes.Add("style","background:#eee;");
            }
        }
        /// <summary>
        /// 绑定资源信息
        /// </summary>
        private void BindInfo()
        {
            DataTable dt=masterService.GetDataByKey("T_Action","ID",_ID);
            if (dt.Rows.Count == 0)
                return;
            DataRow dr = dt.Rows[0];
            this.txtParentCode.Text = Convert.ToString(dr["ParentCode"]);
            this.ddlType.SelectedValue = Convert.ToString(dr["Type"]);
            this.txtCode.Text = Convert.ToString(dr["Code"]);
            this.txtName.Text = Convert.ToString(dr["Name"]);
            this.txtLink.Text = Convert.ToString(dr["Link"]);
            this.txtAction.Text = Convert.ToString(dr["Action"]);
            this.txtIcon.Text = Convert.ToString(dr["Icon"]);
            this.txtSort.Text = Convert.ToString(dr["Sort"]);
            this.cbDisabled.Checked = Convert.ToBoolean(dr["Disabled"]);
        }
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = masterService.GetDataByKey("T_Action", "ID", _ID);
            DataRow dr;
            if (dt.Rows.Count == 0)
                dr = dt.NewRow();
            else
                dr = dt.Rows[0];
            dr["Type"] = this.ddlType.SelectedValue;
            dr["Code"] = this.txtCode.Text;
            dr["Name"] = this.txtName.Text;
            dr["Link"] = this.txtLink.Text;
            dr["Action"] = this.txtAction.Text;
            dr["Icon"] = this.txtIcon.Text;
            dr["ParentCode"] = this.txtParentCode.Text;
            dr["Sort"] = this.txtSort.Text == "" ? "0" : this.txtSort.Text;
            dr["Disabled"] = this.cbDisabled.Checked;
            if (dt.Rows.Count == 0)
                dt.Rows.Add(dr);
            int res = masterService.UpdateDataTable(dt);
            if (res > 0)
                RegistScript("CloseWin('操作成功！',parent.GetList);");
            else
                RegistScript("alert('操作失败');");
        }
    }
}
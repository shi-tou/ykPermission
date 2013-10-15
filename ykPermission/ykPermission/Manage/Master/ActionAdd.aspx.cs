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
        private int _ID
        {
            get { return GetRequestInt("ID", 0); }
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
                BindInfo();
            }
        }
        /// <summary>
        /// 绑定资源信息
        /// </summary>
        private void BindInfo()
        {
            if(_ID==0)
                return;
            DataTable dt=masterService.GetDataByKey("T_Action","ID",_ID);
            if (dt.Rows.Count == 0)
                return;
            DataRow dr = dt.Rows[0];
            this.ddlParent.SelectedValue = Convert.ToString(dr["ParentID"]);
            this.ddlType.SelectedValue = Convert.ToString(dr["Type"]);
            this.txtActionName.Text = Convert.ToString(dr["ActionName"]);
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
            dr["ParentID"] = this.ddlParent.SelectedValue;
            dr["Type"] = this.ddlType.SelectedValue;
            dr["ActionName"] = this.txtActionName.Text;
            dr["Link"] = this.txtLink.Text;
            dr["Action"] = this.txtAction.Text;
            dr["Icon"] = this.txtIcon.Text;
            dr["Sort"] = this.txtSort.Text;
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
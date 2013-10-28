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
using System.Collections.Generic;

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
                BindGroup();
                if(_ID!=0)
                    BindInfo();
            }
        }
        public void BindInfo()
        {
            DataTable dt = masterService.GetDataByKey("T_Master", "ID", _ID);
            DataRow dr=dt.Rows[0];
            this.txtUserName.Text = Convert.ToString(dr["UserName"]);
            this.txtPassword.Attributes.Remove("data-options");
            this.txtMasterName.Text = Convert.ToString(dr["MasterName"]);
            this.cbDisabled.Checked = Convert.ToBoolean(dr["Disabled"]);
            DataTable dtGroup = masterService.GetDataByKey("T_MasterGroup", "MasterID", _ID);
            SetGroup(dtGroup);
        }
        /// <summary>
        /// 绑定权限组
        /// </summary>
        public void BindGroup()
        {
            DataTable dt = masterService.GetData("T_Group");
            cblGroup.DataSource = dt;
            cblGroup.DataTextField = "GroupName";
            cblGroup.DataValueField = "ID";
            cblGroup.DataBind();
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
            int res = masterService.SaveMasterInfo(dt, GetGroup());
            if (res > 0)
                InvokeScript("CloseWin('添加成功！',parent.GetList)");
            else
                InvokeScript("CloseWin('添加失败！')");
        }
        /// <summary>
        /// 获取权限组
        /// </summary>
        /// <returns></returns>
        public List<string> GetGroup()
        {
            List<string> list = new List<string>();
            foreach (ListItem li in this.cblGroup.Items)
            {
                if (li.Selected)
                    list.Add(li.Value);
            }
            return list;
        }
        /// <summary>
        /// 设置权限组
        /// </summary>
        public void SetGroup(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                foreach (ListItem li in this.cblGroup.Items)
                {
                    if (li.Value == Convert.ToString(dr["GroupID"]))
                        li.Selected = true;
                }
            }
        }
    }
}

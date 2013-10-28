using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ykPermission.Service;
using System.Data;
using System.Collections;
using ykPermission.Common;
using System.Text;

namespace ykPermission.Web.Manage.Master
{
    public partial class GroupAdd : AdminPage
    {
        //注入
        private IMasterService masterService;
        public IMasterService MasterService
        {
            set { masterService = value; }
        }
        //ID
        private int _ID
        {
            get { return GetRequestInt("ID", 0); }
        }
        public string ActionJson = "[]";
        /// <summary>
        /// 加载
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
                GetActionJson();
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        public void BindInfo()
        {
            if (_ID == 0)
                return;
            DataTable dt = masterService.GetDataByKey("T_Group", "ID", _ID);
            DataRow dr = dt.Rows[0];
            this.txtGroupName.Text = Convert.ToString(dr["GroupName"]);
            this.txtGroupInfo.Text = Convert.ToString(dr["GroupInfo"]);
        }
        /// <summary>
        /// 获取Ztree需要的json字符
        /// </summary>
        public void GetActionJson()
        {
            Hashtable hs = new Hashtable();
            hs.Add("Disabled", 0);
            DataTable dt = masterService.GetActionList(hs);
            DataTable dtGroupAction = masterService.GetDataByKey("T_ActionGroup", "GroupID", _ID);
            List<string> list = GetAction(dtGroupAction);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                if (sb.Length != 0)
                    sb.Append(",");
                sb.Append("{");
                if (_ID != 0)
                {
                    sb.AppendFormat("\"id\":\"{0}\",\"pId\":\"{1}\",\"name\":\"{2}\",\"value\":\"{3}\",\"checked\":{4}", dr["Code"], dr["ParentCode"], dr["Name"], dr["Code"], list == null ? "false" : list.Contains(dr["Code"].ToString()).ToString().ToLower());
                }
                else
                {
                    sb.AppendFormat("\"id\":\"{0}\",\"pId\":\"{1}\",\"name\":\"{2}\",\"value\":\"{3}\"", dr["Code"], dr["ParentCode"], dr["Name"], dr["Code"]);
                }
                sb.Append("}");
            }
            ActionJson = "[" + sb.ToString() + "]";
        }
            
        /// <summary>
        /// 添加
        /// </summary>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = masterService.GetDataByKey("T_Group", "ID", _ID);
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
            }
            dr["GroupName"] = this.txtGroupName.Text;
            dr["GroupInfo"] = this.txtGroupInfo.Text;
            if (dt.Rows.Count == 0)
                dt.Rows.Add(dr);
            int res = masterService.SaveGroup(dt, GetAction());
            if (res > 0)
                InvokeScript("CloseWin('添加成功！',parent.GetList)");
            else
                InvokeScript("CloseWin('添加失败！')");
        }
        /// <summary>
        /// 添加时获取权限
        /// </summary>
        /// <returns></returns>
        public List<string> GetAction()
        {
            List<string> list = new List<string>();
            string action = this.hfAction.Value;
            foreach (string s in action.Split(",".ToCharArray()))
            {
                if (!string.IsNullOrEmpty(s))
                    list.Add(s.Trim());
            }
            return list;
        }
        /// <summary>
        /// 绑定量获取权限
        /// </summary>
        /// <param name="dt">组对应的权限</param>
        /// <returns></returns>
        public List<string> GetAction(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return null;
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string s = Convert.ToString(dr["ActionCode"]);
                if (!string.IsNullOrEmpty(s))
                    list.Add(s.Trim());
            }
            return list;
        }

    }
}
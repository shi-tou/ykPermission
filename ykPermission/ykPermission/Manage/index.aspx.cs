using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ykPermission.Service;
using System.Data;
using System.Collections;
using ykPermission.Common;

namespace ykPermission.Web.Manage
{
    public partial class index : AdminPage
    {
        #region IOC注入
        private static IMasterService masterService;
        public IMasterService MasterService
        {
            set { masterService = value; }
            get { return masterService; }
        }
        #endregion
        /// <summary>
        /// 菜单
        /// </summary>
        public string StrMenu = "";
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenu();
            }
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        public void GetMenu()
        {
            StringBuilder sb = new StringBuilder();
            Hashtable hs = new Hashtable();
            hs.Add("Disabled","0");
            DataTable dt = masterService.GetActionList(hs);
            DataTable dt1 = Utils.SelectDataTable(dt, "ParentCode is null or ParentCode=''");
            foreach (DataRow dr1 in dt1.Rows)
            {
                sb.Append("<div title=\""+ dr1["Name"].ToString() +"\" style=\"padding:10px 10px 10px 20px;\">");
                sb.Append("    <ul class=\"menuUL\">");
                DataTable dt2 = Utils.SelectDataTable(dt, "ParentCode='"+ dr1["Code"].ToString() +"'");
                foreach (DataRow dr2 in dt2.Rows)
                {
                    sb.Append("        <li><a href=\"javascript:void(0)\" onclick=\"add('"+ dr2["Link"].ToString() +"',this)\">"+ dr2["Name"].ToString() +"</a></li>");
                }
                sb.Append("    </ul>");
                sb.Append("</div>");
            }
            StrMenu = sb.ToString();
        }
    }
}
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using ykPermission.Service;
using ykPermission.Common;
using System.Text;

namespace ykPermission.Web.Manage.Ajax
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Master : BaseAjax, IHttpHandler
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
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="hc"></param>
        public void CheckUserName(HttpContext hc)
        {
            string userName = GetRequestStr("UserName", "");
            DataTable dt = masterService.GetDataByKey("T_Master", "UserName", userName);
            ResponseWrite(hc, dt.Rows.Count > 0 ? "0" : "1");
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        public void GetMasterList(HttpContext hc)
        {
            Hashtable hs = new Hashtable();
            Pager p = new Pager(PageSize, PageIndex, "CreateTime desc");
            masterService.GetMasterList(p, hs);
            ResponseWrite(hc, p);
        }
        /// <summary>
        /// 验证资源Code是否存在
        /// </summary>
        /// <param name="hc"></param>
        public void CheckActinCode(HttpContext hc)
        {
            string code = GetRequestStr("Code", "");
            DataTable dt = masterService.GetDataByKey("T_Action", "Code", code);
            ResponseWrite(hc, dt.Rows.Count > 0 ? "0" : "1");
        }
        /// <summary>
        /// 资源列表
        /// </summary>
        /// <param name="hc"></param>
        public void GetActionList(HttpContext hc)
        {
            Hashtable hs = new Hashtable();
            DataTable dt = masterService.GetActionList(hs);
            strJson = Utils.CreateTreeJson(dt);
            ResponseWrite(hc);
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="hc"></param>
        public void GetGroupList(HttpContext hc)
        {
            Hashtable hs = new Hashtable();
            Pager p = new Pager(PageSize, PageIndex, "a.CreateTime desc");
            masterService.GetGroupList(p, hs);
            ResponseWrite(hc, p);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="hc"></param>
        public void DeleteGroup(HttpContext hc)
        {
            int id = GetRequestInt("ID", 0);
            int res = masterService.Delete("T_Group","ID", id.ToString());
            ResponseWrite(hc, res > 0 ? "0" : "1");
        }
    }
}

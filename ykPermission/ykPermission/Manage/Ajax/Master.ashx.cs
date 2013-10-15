using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using ykPermission.Service;
using ykPermission.Common;

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
        /// 资源列表
        /// </summary>
        /// <param name="hc"></param>
        public void GetActionList(HttpContext hc)
        {
            strJson = masterService.GetActionList();
            ResponseWrite(hc);
        }
    }
}

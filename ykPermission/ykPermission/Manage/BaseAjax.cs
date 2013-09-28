using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ykPermission.Common;
using System.Reflection;

namespace ykPermission.Web.Manage
{
    /// <summary>
    /// Ajax基类
    /// </summary>
    public class BaseAjax : AdminPage
    {
        #region 属性
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get
            {

                return GetRequestInt("rows", 20);
            }
        }
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex
        {
            get
            {
                return GetRequestInt("page", 1);
            }
        }
        /// <summary>
        /// 返回Json字符串
        /// </summary>
        public string strJson = "";
        #endregion

        #region 方法
        /// <summary>
        /// 将返回结果格式化成Json字符串
        /// </summary>
        public string ToJson(Pager p)
        {
            string strJson = "";
            if (p.ItemCount > 0)
                strJson = "{\"rows\":" + ToJson(p.DataSource) + ",\"total\":" + p.ItemCount + "}";
            else
                strJson = "{\"rows\":{},\"total\":0}";
            return strJson;
        }
        /// <summary>
        /// 将datatable数据转换成JSON数据
        /// </summary>
        public string ToJson(DataTable dt)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
        }
        public void ResponseWrite(HttpContext hc)
        {
            hc.Response.ContentType = "text/plain";
            hc.Response.Write(strJson);
        }
        public void ResponseWrite(HttpContext hc, Pager p)
        {
            hc.Response.ContentType = "text/plain";
            hc.Response.Write(ToJson(p));
        }
        public void ResponseWrite(HttpContext hc, DataTable dt)
        {
            hc.Response.ContentType = "text/plain";
            if (dt == null || dt.Rows.Count == 0)
                hc.Response.Write("{\"rows\":{},\"total\":0}");
            else
                hc.Response.Write(ToJson(dt));
        }
        #endregion
        /// <summary>
        /// 利用反射调用方法
        /// </summary>
        public new void ProcessRequest(HttpContext context)
        {
            string method = context.Request["action"].ToString();
            object obj = Assembly.GetExecutingAssembly().CreateInstance(context.Handler.ToString(), false);
            object obj2 = Type.GetType(context.Handler.ToString()).GetMethod(method).Invoke(obj, new HttpContext[] { context });
        }
    }
}

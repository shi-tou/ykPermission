using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading;
using System.Globalization;
using System.Net;
using System.IO;

namespace ykPermission.Web
{
    public class BasePage : System.Web.UI.Page
    {            
        /// <summary>
        /// 构建JS引用
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public HtmlGenericControl RegistJavaScript(string src)
        {
            HtmlGenericControl generic = new HtmlGenericControl("script");
            generic.Attributes["type"] = "text/javascript";
            generic.Attributes["src"] = src;
            return generic;
        }

        /// <summary>
        /// 构建CSS样式引用
        /// </summary>
        /// <param name="href">链接地址</param>
        /// <returns></returns>
        public static HtmlLink RegistCSS(string href)
        {
            HtmlLink generic = new HtmlLink();
            generic.Href = href;
            generic.Attributes.Add("rel", "stylesheet");
            generic.Attributes.Add("type", "text/css");
            generic.Attributes["href"] = href;
            return generic;
        }

        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="message"></param>
        public void Alert(string message)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript((System.Web.UI.Page)HttpContext.Current.CurrentHandler, typeof(System.Web.UI.Page), " ", "alert('" + message + "');", true);
        }
        /// <summary>
        /// 输出JavaScript
        /// </summary>
        /// <param name="strScript"></param>
        public void InvokeScript(string strScript)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript((System.Web.UI.Page)HttpContext.Current.CurrentHandler, typeof(System.Web.UI.Page), " ", strScript, true);
        }
        /// <summary>
        /// 获得request参数的string类型值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数的string类型值</returns>
        public string GetRequestStr(string strName, string defaultValue)
        {
            string vaule = Convert.ToString(HttpContext.Current.Request[strName]);
            if (vaule != null && vaule != "")
            {
                return vaule;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 获得request参数的int类型值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>参数的int类型值</returns>
        public int GetRequestInt(string strName, int defaultValue)
        {
            string vaule = HttpContext.Current.Request[strName];
            if (vaule != null && vaule != "")
                return Convert.ToInt16(HttpContext.Current.Request[strName]);
            else
                return defaultValue;
        }
        /// <summary>
        /// 获得request参数的bool类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public bool GetRequestBool(string strName)
        {
            return Convert.ToBoolean(HttpContext.Current.Request[strName]);
        }
    }

}

using System;
using System.Data;
using System.Configuration;
using System.Linq;
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
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.IO;
using System.Configuration;

namespace ykPermission.Common
{
    public class Utils
    {
        /// <summary>
        /// 从一个Datatable中按条件分离出另一个Datatable
        /// </summary>
        public static DataTable SelectDataTable(DataTable dt, string strWhere)
        {
            DataView view = new DataView();
            view.Table = dt;
            view.RowFilter = strWhere;
            return view.ToTable();
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strContent"></param>
        public static void SaveLog(string strTitle, string strContent)
        {
            try
            {
                string Path = AppDomain.CurrentDomain.BaseDirectory + "Log/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
                string FilePath = Path + DateTime.Now.Day + "_Log.txt";
                if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
                if (!File.Exists(FilePath))
                {
                    FileStream FsCreate = new FileStream(FilePath, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream FsWrite = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
                StreamWriter SwWrite = new StreamWriter(FsWrite);
                SwWrite.WriteLine(string.Format("{0}{1}[{2}]{3}", "--------------------------------", strTitle, DateTime.Now.ToString("HH:mm"), "--------------------------------"));
                SwWrite.Write(strContent);
                SwWrite.WriteLine("\r\n");
                SwWrite.WriteLine(" ");
                SwWrite.Flush();
                SwWrite.Close();
            }
            catch { }
        }

        /// <summary>
        /// 获取配置文件的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                return "";
            }
        }
        #region CteateTreeJson
        public static string CreateTreeJson(DataTable dt)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("[");
            CreateTree(dt, "", ref sb);
            sb.Append("]");
            return sb.ToString();
        }
        /// <summary>
        /// 递归
        /// </summary>
        public static void CreateTree(DataTable dt, string pCode, ref StringBuilder sb)
        {
            DataTable dtTemp = Utils.SelectDataTable(dt, string.Format("isnull(ParentCode,'')='{0}'", pCode));
            if (dtTemp.Rows.Count == 0)
                return;
            foreach (DataRow dr in dtTemp.Rows)
            {
                sb.Append("{");
                sb.AppendFormat("\"ID\":{0},\"Code\":\"{1}\",\"ParentCode\":\"{2}\",\"Type\":{3},\"Name\":\"{4}\" ,\"Action\":\"{5}\",\"Icon\":\"{6}\",\"Link\":\"{7}\",\"Sort\":{8},\"Disabled\":\"{9}\"",
                    dr["ID"], dr["Code"], dr["ParentCode"], dr["Type"], dr["Name"], dr["Action"], dr["Icon"], dr["Link"], dr["Sort"], Convert.ToString(dr["Disabled"]).ToLower());
                sb.Append(",\"children\":[");
                CreateTree(dt, Convert.ToString(dr["Code"]), ref sb);
                sb.Append("]},");
            }
            sb.Remove(sb.Length - 1, 1);
        }
        #endregion
    }
}

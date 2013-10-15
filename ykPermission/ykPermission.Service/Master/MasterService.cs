using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ykPermission.Model;
using ykPermission.Dao;
using ykPermission.Common;
using System.Collections;

namespace ykPermission.Service
{
    public class MasterService : BaseService, IMasterService
    {
        private IMasterDao masterDao;
        public IMasterDao MasterDao
        {
            set
            {
                masterDao = value;
            }
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>0-成功 1-用户名不存在 2-禁用 3-密码不正确</returns>
        public int MasterLogin(string username, string password)
        {
            DataTable dt = GetDataByKey("T_Master", "UserName", username);
            if (dt.Rows.Count == 0)
                return 1;
            DataRow dr = dt.Rows[0];
            if (Convert.ToBoolean(dr["Disabled"]))
                return 2;
            if (Convert.ToString(dr["Password"]) != DESEncrypt.Encrypt(password))
                return 3;
            return 0;
        }
        /// 用户列表
        /// </summary>
        public int GetMasterList(Pager p, Hashtable hs)
        {
            return masterDao.GetMasterList(p, hs);
        }
        /// <summary>
        /// 获取网站栏目列表
        /// </summary>
        /// <returns></returns>
        public string GetActionList()
        {
            DataTable dt = masterDao.GetData("T_Action");
            StringBuilder sb = new StringBuilder("");
            sb.Append("[");
            CreateTreejson(dt, "0", ref sb);
            sb.Append("]");
            return sb.ToString();
        }
        /// <summary>
        /// 递归
        /// </summary>
        public void CreateTreejson(DataTable dt, string pid, ref StringBuilder sb)
        {
            DataTable dtTemp = Utils.SelectDataTable(dt, "ParentID=" + pid);
            if (dtTemp.Rows.Count == 0)
                return;
            foreach (DataRow dr in dtTemp.Rows)
            {
                sb.Append("{");
                sb.AppendFormat("\"ID\":{0},\"PID\":{1},\"Type\":{2},\"ActionName\":\"{3}\" ,\"Action\":\"{4}\",\"Icon\":\"{5}\",\"Link\":\"{6}\",\"Sort\":{7},\"Disabled\":\"{8}\"",
                    dr["ID"], dr["ParentID"],dr["Type"], dr["ActionName"], dr["Action"], dr["Icon"], dr["Link"],dr["Sort"], Convert.ToString(dr["Disabled"]).ToLower());
                sb.Append(",\"children\":[");
                CreateTreejson(dt, Convert.ToString(dr["ID"]), ref sb);
                sb.Append("]},");
            }
            sb.Remove(sb.Length - 1, 1);
        }
    }
}

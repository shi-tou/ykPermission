using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ykPermission.Model;
using ykPermission.Dao;

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
            DataRow  dr=dt.Rows[0];
            if (Convert.ToBoolean(dr["Disabled"]))
                return 2;
            if (Convert.ToString(dr["Password"]) != password)
                return 3;
            MasterInfo minfo = new MasterInfo();
            minfo.ID = Convert.ToInt32(dr["ID"]);
            minfo.UserName = Convert.ToString(dr["UserName"]);
            minfo.MasterName = Convert.ToString(dr["MasterName"]);
            minfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            System.Web.HttpContext.Current.Session["MasterInfo"] = minfo;
            System.Web.HttpContext.Current.Session.Timeout = 20;
            return 0;
        }
    }
}

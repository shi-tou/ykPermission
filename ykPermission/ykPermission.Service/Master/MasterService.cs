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
            DataRow  dr=dt.Rows[0];
            if (Convert.ToBoolean(dr["Disabled"]))
                return 2;
            if (Convert.ToString(dr["Password"]) != password)
                return 3;
            return 0;
        }
        /// 用户列表
        /// </summary>
        public int GetMasterList(Pager p, Hashtable hs)
        {
            return masterDao.GetMasterList(p, hs);
        }
    }
}

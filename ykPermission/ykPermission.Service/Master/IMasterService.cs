using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ykPermission.Service
{
    public interface IMasterService:IBaseService
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int MasterLogin(string username, string password);
    }
}

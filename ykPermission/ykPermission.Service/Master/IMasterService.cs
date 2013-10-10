using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ykPermission.Common;
using System.Collections;
using System.Data;

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
        /// 用户列表
        /// </summary>
        int GetMasterList(Pager p, Hashtable hs);
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <returns></returns>
        DataTable GetActionList(Hashtable hs);
        /// 角色列表
        /// </summary>
        int GetGroupList(Pager p, Hashtable hs);
        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="dtGroup">角色</param>
        /// <param name="dtGroupAction">权限</param>
        /// <returns></returns>
        int SaveGroup(DataTable dtGroup, List<string> groupAction);
    }
}

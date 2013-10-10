using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ykPermission.Common;
using System.Collections;
using System.Data;

namespace ykPermission.Dao
{
    public interface IMasterDao : IBaseDao
    {
        /// 用户列表
        /// </summary>
        int GetMasterList(Pager p, Hashtable hs);
        /// 用户列表
        /// </summary>
        DataTable GetActionList(Hashtable hs);
        /// 用户列表
        /// </summary>
        int GetGroupList(Pager p, Hashtable hs);
    }
}

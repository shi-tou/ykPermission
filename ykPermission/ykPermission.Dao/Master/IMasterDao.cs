using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ykPermission.Common;
using System.Collections;

namespace ykPermission.Dao
{
    public interface IMasterDao : IBaseDao
    {
        /// 用户列表
        /// </summary>
        int GetMasterList(Pager p, Hashtable hs);
    }
}

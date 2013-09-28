using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.Common;
using ykPermission.Common;
using System.Data;
using System.Collections;

namespace ykPermission.Dao
{
    public class MasterDao : BaseDao, IMasterDao
    {
        /// 用户列表
        /// </summary>
        public int GetMasterList(Pager p, Hashtable hs)
        {
            string sql = "select * from T_Master";
            IDbParameters param = AdoTemplate.CreateDbParameters();
            sql = PagerSql(sql, p);
            DataSet ds = AdoTemplate.DataSetCreateWithParams(CommandType.Text, sql, param);
            p.DataSource = ds.Tables[0];
            p.ItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return 0;
        }
    }
}

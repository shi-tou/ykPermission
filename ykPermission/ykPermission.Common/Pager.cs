using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ykPermission.Common
{
    public class Pager
    {
        public Pager() { }
        public Pager(int pagesize, int pageindex, string orderkey)
        {
            PageSize = pagesize;
            PageIndex = pageindex;
            OrderKey = orderkey;
        }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }
        /// <summary>
        /// 页序号
        /// </summary>
        public int PageIndex
        {
            get;
            set;
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int ItemCount
        {
            get;
            set;
        }
        /// <summary>
        /// DataTable
        /// </summary>
        public DataTable DataSource
        {
            get;
            set;
        }
        /// <summary>
        /// sql语句
        /// </summary>
        public string Sql
        {
            get;
            set;
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderKey
        {
            get;
            set;
        }
    }
}

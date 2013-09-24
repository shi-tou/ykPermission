using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ykPermission.Dao;

namespace ykPermission.Service
{
    public class BaseService : IBaseService
    {
        private IBaseDao baseDao;
        public IBaseDao BaseDao
        {
            set
            {
                baseDao = value;
            }
        }
        #region Insert/Update/Delete
        /// <summary>
        /// 插入记录
        /// </summary>
        public int Insert(string tableName, DataTable dt)
        {
            return baseDao.Insert(tableName, dt);
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        public int Update(string tableName, DataTable dt, string where)
        {
            return baseDao.Update(tableName, dt, where);
        }
        /// <summary>
        /// 更新DataTable
        /// </summary>
        public int UpdateDataTable(DataTable dt)
        {
            return baseDao.UpdateDataTable(dt);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(string tableName)
        {
            return baseDao.Delete(tableName);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(string tableName, string where)
        {
            return baseDao.Delete(tableName, where);
        }
        public int Delete(string tableName, string field, object obj)
        {
            return baseDao.Delete(tableName, field, obj);
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 获取DataTable表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>DataTable表数据</returns>
        public DataTable GetData(string tableName)
        {
            return baseDao.GetData(tableName);
        }
        /// <summary>
        /// 获取DataTable表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">数据字段，如：string fields="ID,Name,Sex";如为"*",则为所有字段</param>
        /// <returns>DataTable表数据</returns>
        public DataTable GetData(string tableName, string fields)
        {
            return baseDao.GetData(tableName, fields);
        }
        /// <summary>
        /// 获取DataTable表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">数据字段，如：string fields="ID,Name,Sex";如为"*",则为所有字段</param>
        /// <param name="where">查询条件</param>
        /// <returns>DataTable表数据</returns>
        public DataTable GetData(string tableName, string fields, string where)
        {
            return baseDao.GetData(tableName, fields, where);
        }
        public DataTable GetDataByKey(string tablename, string field, object obj)
        {
            return baseDao.GetDataByKey(tablename, field, obj);
        }

        public DataTable GetSortDataByKey(string tablename, string field, string sortType)
        {
            return baseDao.GetDataByKey(tablename, field, sortType);
        }
        #endregion

        #region 执行Sql语句
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cType">执行类型</param>
        /// <param name="sql">sql语句</param>
        /// <returns>影响记录数</returns>
        public int ExecteSql(CommandType cType, string sql)
        {
            return baseDao.ExecteSql(cType, sql);
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cType">执行类型</param>
        /// <param name="sql">sql语句</param>
        /// <returns>结果集DataSet</returns>
        public DataSet ExecteSqlGetDataSet(CommandType cType, string sql)
        {
            return baseDao.ExecteSqlGetDataSet(cType, sql);
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cType">执行类型</param>
        /// <param name="sql">sql语句</param>
        /// <returns>表数据DataTable</returns>
        public DataTable ExecteSqlGetDataTable(CommandType cType, string sql)
        {
            return baseDao.ExecteSqlGetDataTable(cType, sql);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ykPermission.Service
{
    public interface IBaseService
    {
        #region Insert/Update/Delete
        /// <summary>
        /// 插入记录
        /// </summary>
        int Insert( DataTable dt);
        /// <summary>
        /// 修改记录
        /// </summary>
        int Update( DataTable dt, string where);
        /// <summary>
        /// 更新DataTable
        /// </summary>
        int UpdateDataTable(DataTable dt);
        /// <summary>
        /// 删除记录
        /// </summary>
        int Delete(string tableName);
        /// <summary>
        /// 删除记录
        /// </summary>>
        int Delete(string tableName, string where);
        int Delete(string tableName, string keycol, object obj);
        #endregion

        #region Data
        /// <summary>
        /// 获取DataTable表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>DataTable表数据</returns>
        DataTable GetData(string tableName);
        /// <summary>
        /// 获取DataTable表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">数据字段，如：string fields="ID,Name,Sex";如为"*",则为所有字段</param>
        /// <returns>DataTable表数据</returns>
        DataTable GetData(string tableName, string fields);
        /// <summary>
        /// 获取DataTable表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">数据字段，如：string fields="ID,Name,Sex";如为"*",则为所有字段</param>
        /// <param name="where">查询条件</param>
        /// <returns>DataTable表数据</returns>
        DataTable GetData(string tableName, string fields, string where);
        DataTable GetDataByKey(string tablename, string field, object obj);
        DataTable GetSortDataByKey(string tablename, string field, string sortType);
        #endregion

        #region 执行Sql语句
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cType">执行类型</param>
        /// <param name="sql">sql语句</param>
        /// <returns>影响记录数</returns>
        int ExecteSql(CommandType cType, string sql);
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cType">执行类型</param>
        /// <param name="sql">sql语句</param>
        /// <returns>结果集DataSet</returns>
        DataSet ExecteSqlGetDataSet(CommandType cType, string sql);
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cType">执行类型</param>
        /// <param name="sql">sql语句</param>
        /// <returns>表数据DataTable</returns>
        DataTable ExecteSqlGetDataTable(CommandType cType, string sql);
        #endregion
    }
}

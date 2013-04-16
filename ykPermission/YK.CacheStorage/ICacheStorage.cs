/******************************************************************************
 *  作者：       tianzh
 *  创建时间：   2012/6/7 14:50:04
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TZHSWEET.CacheStorage
{
    /// <summary>
    /// 缓存接口
    /// </summary>
   public interface ICacheStorage
    {
        #region 缓存操作
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Insert(string key, object value);
        /// <summary>
        /// 添加缓存(默认滑动时间为20分钟)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiration">绝对过期时间</param>
        void Insert(string key, object value, DateTime expiration);
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiration">过期时间</param>
        void Insert(string key, object value, TimeSpan expiration);
        /// <summary>
        /// 获得key对应的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Get(string key);
        /// <summary>
        /// 根据key删除缓存
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
        /// <summary>
        /// 缓存是否存在key的value
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        bool Exist(string key);
        /// <summary>
        /// 获取所有的缓存key
        /// </summary>
        /// <returns></returns>
        List<string> GetCacheKeys();
        /// <summary>
        /// 清空缓存
        /// </summary>
        void Flush();
        
        #endregion
    }
  
}

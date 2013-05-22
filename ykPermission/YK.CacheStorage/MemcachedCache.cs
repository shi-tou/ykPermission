/******************************************************************************
 *  作者：       tianzh
 *  创建时间：   2012/6/7 14:47:53
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace YK.CacheStorage
{
    /// <summary>
    /// 分布式Memcached缓存
    /// </summary>
    class MemcachedCache : ICacheStorage
    {
        /// <summary>
        /// 分布式缓存客户端Cache
        /// </summary>
        private MemcachedClient Cache;
        public MemcachedCache()
        {
            Cache = new MemcachedClient();
            List<string> keys = new List<string>();
            Cache.Store(StoreMode.Add, "keys", keys);
        }
        #region ICacheStorage 成员
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void Insert(string key, object value)
        {
            Cache.Store(StoreMode.Set, key, value);

        }
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiration">绝对过期时间</param>
        public void Insert(string key, object value, DateTime expiration)
        {
            Cache.Store(StoreMode.Set, key, value, expiration);
            Updatekeys(key);
        }
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiration">过期时间</param>
        public void Insert(string key, object value, TimeSpan expiration)
        {
            Cache.Store(StoreMode.Set, key, value, expiration);
            Updatekeys(key);
        }
        /// <summary>
        /// 根据key获取value
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public object Get(string key)
        {
            return Cache.Get(key);
        }
        /// <summary>
        /// 删除key的缓存的值
        /// </summary>
        /// <param name="key">key</param>
        public void Remove(string key)
        {
            if (Exist(key))
                Cache.Remove(key);
        }
        /// <summary>
        /// 检验key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exist(string key)
        {
            if (Cache.Get(key) != null)
                return true;
            else return false;
        }
        /// <summary>
        /// 获取所有的key
        /// </summary>
        /// <returns></returns>
        public List<string> GetCacheKeys()
        {
            return Cache.Get("keys") as List<string>;

        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Flush()
        {
            foreach (string s in GetCacheKeys())
            {
                Remove(s);
            }
        }
        /// <summary>
        /// 更新key
        /// </summary>
        /// <param name="key">key</param>
        private void Updatekeys(string key)
        {
            List<string> keys = new List<string>();
            //读取本地keys
            if (Cache.Get("keys") != null)
                keys = Cache.Get("keys") as List<string>;
            //如果keys中不存在
            if (!keys.Contains(key.ToLower()))
                keys.Add(key);
            Cache.Store(StoreMode.Set, "keys", keys);
        }
        #endregion
    }
}

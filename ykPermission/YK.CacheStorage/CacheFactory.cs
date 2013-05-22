/******************************************************************************
 *  作者：       tianzh
 *  创建时间：   2012/6/7 14:47:09
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YK.CacheStorage
{

    /// <summary>
    /// 缓存工厂
    /// </summary>
    public class CacheFactory
    {
        /// <summary>
        /// 缓存类别
        /// </summary>
        public enum CacheType
        {
            //默认缓存
            DefaultCache = 0,
            /// <summary>
            /// 分布式Memcached缓存
            /// </summary>
            MemcachedCache = 1
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ICacheStorage CreateCacheFactory()
        {
           string Cache=ConfigurationManager.AppSettings["CacheType"];
           if (CacheType.MemcachedCache.ToString ()== Cache)
           {
               return new MemcachedCache();
           }
           else
               return new DefaultCacheAdapter();
        }
    }
}

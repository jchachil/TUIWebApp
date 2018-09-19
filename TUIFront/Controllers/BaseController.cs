using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Runtime.Caching;

namespace TUIFront.Controllers
{
    /// <summary>
    /// Base controller class
    /// </summary>
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        protected override void OnException(ExceptionContext filterContext)
        {
        }

        /// <summary>
        /// Get data from cache server by using cachekey , 
        /// if data dose not exist on the cache then call the method to retrive it from backend and put it on the cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <returns></returns>
        public T GetOrSetCacheData<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                // MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddDays(1));                
                System.Runtime.Caching.MemoryCache.Default[cacheKey] = item;
            }
            return item;
        }


    }
}
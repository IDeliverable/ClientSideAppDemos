using System;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace DemoModule.Routing
{
    public class BaseUrlFilter : FilterProvider, IResultFilter
    {
        public BaseUrlFilter(IResourceManager resourceManager, UrlHelper urlHelper)
        {
            mResourceManager = resourceManager;
            mUrlHelper = urlHelper;
        }

        private readonly IResourceManager mResourceManager;
        private readonly UrlHelper mUrlHelper;

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var currentActionUrl = mUrlHelper.RouteUrl(filterContext.RouteData.Values);
            mResourceManager.RegisterHeadScript(String.Format("<base href='{0}' />", currentActionUrl));
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }
    }
}

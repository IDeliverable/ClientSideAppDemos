using System.Web.Mvc;
using Orchard;
using Orchard.Environment;
using Orchard.Mvc;
using Orchard.Settings;
using Orchard.UI.Resources;

namespace DemoModule
{
    public class RuntimeResourceManifest : IResourceManifestProvider
    {
        private readonly Work<WorkContext> mWorkContext;
        private readonly Work<IHttpContextAccessor> mHttpContextAccessor;
        private readonly string mAppRootPath;

        public RuntimeResourceManifest(Work<WorkContext> workContext, Work<IHttpContextAccessor> httpContextAccessor, UrlHelper urlHelper)
        {
            mWorkContext = workContext;
            mHttpContextAccessor = httpContextAccessor;
            mAppRootPath = urlHelper.Content("~/");
        }

        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            var scriptsPath = manifest.BasePath.Replace("~/", mAppRootPath).TrimEnd('/') + "/Scripts";
            var isDebugMode = GetIsDebugMode();

            manifest.DefineScript("SystemJs").SetUrl("https://unpkg.com/systemjs/dist/system.js");
            manifest.DefineScript("System")
                .SetUrl("System.min.js", "System.js")
                .SetDependencies("SystemJs")
                .SetAttribute("data-scripts-path", scriptsPath)
                .SetAttribute("data-is-debug", isDebugMode.ToString());
        }

        private bool GetIsDebugMode()
        {
            var site = mWorkContext.Value.CurrentSite;
            switch (site.ResourceDebugMode)
            {
                case ResourceDebugMode.Enabled:
                    return true;
                case ResourceDebugMode.Disabled:
                    return false;
                default:
                    var context = mHttpContextAccessor.Value.Current();
                    return context != null && context.IsDebuggingEnabled;
            }
        }
    }
}
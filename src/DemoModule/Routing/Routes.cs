using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Orchard.Alias.Implementation.Holder;
using Orchard.Environment.ShellBuilders.Models;
using Orchard.Mvc.Routes;

namespace DemoModule.Routing
{
    public class Routes : IRouteProvider
    {
        private readonly ShellBlueprint mShellBlueprint;
        private readonly IAliasHolder mAliasHolder;

        public Routes(ShellBlueprint blueprint, IAliasHolder aliasHolder)
        {
            mShellBlueprint = blueprint;
            mAliasHolder = aliasHolder;
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            var areaNamesQuery =
                from controllerBlueprint in mShellBlueprint.Controllers
                select controllerBlueprint.AreaName;

            foreach (var areaName in areaNamesQuery.Distinct())
            {
                yield return new RouteDescriptor()
                {
                    Priority = 79,
                    Route = new PartialAliasRoute(mAliasHolder, areaName, new MvcRouteHandler())
                };
            }
        }
    }
}
using DemoModule.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement.Descriptors;
using Orchard.Environment;

namespace DemoModule
{
    public class Shapes : IShapeTableProvider
    {
        private readonly Work<IOrchardServices> mOrchardServices;

        public Shapes(Work<IOrchardServices> orchardServices)
        {
            mOrchardServices = orchardServices;
        }

        public void Discover(ShapeTableBuilder builder)
        {
            builder
                .Describe("Elements_Snippet_Field_Design")
                .OnDisplaying(ctx => ctx.ShapeMetadata.Alternates.Add("Elements_Snippet_Field_Design__" + (string)ctx.Shape.Type));

            builder
                .Describe("StockInfoSnippet")
                .OnDisplaying(ctx =>
                {
                    var apiSettings = mOrchardServices.Value.WorkContext.CurrentSite.As<ApiSiteSettingsPart>();
                    ctx.Shape.ApiUrl = apiSettings.ApiUrl;
                });
        }
    }
}
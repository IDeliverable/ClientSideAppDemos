using Orchard.UI.Resources;

namespace DemoModule
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineScript("StockInfo").SetUrl("StockInfo.min.js", "StockInfo.js").SetDependencies("jQuery");
            manifest.DefineScript("Wizard").SetUrl("Wizard.min.js", "Wizard.js");
        }
    }
}
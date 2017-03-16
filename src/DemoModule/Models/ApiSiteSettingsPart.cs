using Orchard.ContentManagement;

namespace DemoModule.Models
{
	public class ApiSiteSettingsPart : ContentPart
	{
		public string ApiUrl
		{
			get { return this.Retrieve(x => x.ApiUrl) ?? ""; }
			set { this.Store(x => x.ApiUrl, value); }
		}
	}
}
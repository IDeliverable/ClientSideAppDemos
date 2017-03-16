using DemoModule.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;

namespace DemoModule.Handlers
{
	public class ApiSiteSettingsPartHandler : ContentHandler
	{
		public ApiSiteSettingsPartHandler(IRepository<ApiSiteSettingsPart> repository)
		{
			T = NullLocalizer.Instance;
			Filters.Add(new ActivatingFilter<ApiSiteSettingsPart>("Site"));
			Filters.Add(new TemplateFilterForPart<ApiSiteSettingsPart>("ApiSiteSettingsPart", "Parts.ApiSiteSettings", "API"));
		}

		public Localizer T { get; set; }

		protected override void GetItemMetadata(GetContentItemMetadataContext context)
		{
			if (context.ContentItem.ContentType != "Site")
				return;
			base.GetItemMetadata(context);
			context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("API")));
		}
	}
}
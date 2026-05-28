using CMS.ContentEngine;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.Announcements",
    viewComponentType: typeof(Edukate.Components.Widgets.AnnouncementsWidget.AnnouncementsWidgetViewComponent),
    name: "Announcements Widget",
    propertiesType: typeof(Edukate.Components.Widgets.AnnouncementsWidget.AnnouncementsWidgetProperties),
    Description = "Displays latest announcements",
    IconClass = "xp-megaphone")]

namespace Edukate.Components.Widgets.AnnouncementsWidget
{
    public class AnnouncementsWidgetViewComponent : ViewComponent
    {
        private readonly IContentQueryExecutor contentQueryExecutor;

        public AnnouncementsWidgetViewComponent(
            IContentQueryExecutor contentQueryExecutor)
        {
            this.contentQueryExecutor = contentQueryExecutor;
        }

        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<AnnouncementsWidgetProperties> model)
        {
            var properties = model.Properties;

            var query = new ContentItemQueryBuilder()
                .ForContentType(
                    Announcements.CONTENT_TYPE_NAME,
                    config =>
                    {
                        config
                            .WithLinkedItems(2);
                    });

            var result = await contentQueryExecutor.GetMappedResult<Announcements>(query);

            // Map announcement items and sort by publish date
            var announcements = result
                .OrderBy(item => item.Publish_Date)
                .Take(4)
                .Select(item =>
                {
                    string imageUrl = string.Empty;

                    // Get first image
                    var imageItem = item.Announcement_Image?.FirstOrDefault();

                    if (imageItem?.ImageFile != null)
                    {
                        imageUrl = imageItem.ImageFile.Url;
                    }

                    return new AnnouncementItemViewModel
                    {
                        Title = item.Announcement_Title,
                        ShortDescription = item.Short_Description,
                        ImageUrl = imageUrl,
                        PublishDate = item.Publish_Date
                    };
                }).ToList();

            // Main widget ViewModel
            var viewModel = new AnnouncementsWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionHeading = properties.SectionHeading,
                ShowViewAllButton = properties.ShowViewAllButton,
                Announcements = announcements
            };

            return View("~/Components/Widgets/AnnouncementsWidget/_AnnouncementsWidget.cshtml", viewModel);
        }
    }
}

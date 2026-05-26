using CMS.ContentEngine;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.Instructors",
    viewComponentType: typeof(Edukate.Components.Widgets.InstructorsWidget.InstructorsWidgetViewComponent),
    name: "Instructors Widget",
    propertiesType: typeof(Edukate.Components.Widgets.InstructorsWidget.InstructorsWidgetProperties),
    Description = "Displays a list of instructors/team members",
    IconClass = "xp-users")]

namespace Edukate.Components.Widgets.InstructorsWidget
{
    public class InstructorsWidgetViewComponent : ViewComponent
    {
        private readonly IContentQueryExecutor contentQueryExecutor;

        public InstructorsWidgetViewComponent(
            IContentQueryExecutor contentQueryExecutor)
        {
            this.contentQueryExecutor = contentQueryExecutor;
        }

        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<InstructorsWidgetProperties> model)
        {
            var properties = model.Properties;

            var query = new ContentItemQueryBuilder()
                .ForContentType(
                    InstructorItem.CONTENT_TYPE_NAME,
                    config =>
                    {
                        config
                            .TopN(properties.NumberOfInstructors)
                            .WithLinkedItems(2);
                    });

            var result = await contentQueryExecutor.GetMappedResult<InstructorItem>(query);

            // Map instructor items
            var instructors = result.Select(item =>
            {
                string imageUrl = string.Empty;

                // Get first image
                var imageItem = item.Photo?.FirstOrDefault();

                if (imageItem?.ImageFile != null)
                {
                    imageUrl = imageItem.ImageFile.Url;
                }

                return new InstructorItemViewModel
                {
                    Name = item.Name,
                    Designation = item.Designation,
                    Bio = item.Bio,
                    ImageUrl = imageUrl,
                    FacebookURL = item.FacebookURL,
                    TwitterURL = item.TwitterURL,
                    LinkedInURL = item.LinkedInURL,
                    InstagramURL = item.InstagramURL,
                    YoutubeURL = item.YoutubeURL
                };
            }).ToList();

            // Main widget ViewModel
            var viewModel = new InstructorsWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionHeading = properties.SectionHeading,
                ShowAllButton = properties.ShowAllButton,
                Instructors = instructors
            };

            return View("~/Components/Widgets/InstructorsWidget/_InstructorsWidget.cshtml", viewModel);
        }
    }
}

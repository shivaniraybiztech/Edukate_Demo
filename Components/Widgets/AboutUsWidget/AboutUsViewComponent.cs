using Edukate.Components.Widgets.AboutUsWidget;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.AboutUs",
    viewComponentType: typeof(AboutUsViewComponent),
    name: "About Us",
    propertiesType: typeof(AboutUsWidgetProperties),
    Description = "About Us section with heading and description",
    IconClass = "xp-picture")]


namespace Edukate.Components.Widgets.AboutUsWidget
{
    public class AboutUsViewComponent : ViewComponent
    {
        private readonly IContentRetriever contentRetriever;


        /// <summary>
        /// Creates an instance of <see cref="AboutUsViewComponent"/> class.
        /// </summary>
        /// <param name="contentRetriever">Content retriever.</param>
        public AboutUsViewComponent(IContentRetriever contentRetriever)
        {
            this.contentRetriever = contentRetriever;
        }
        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<AboutUsWidgetProperties> model)
        {
            var image = await GetImage(model.Properties);

            var viewModel = new AboutUsWidgetViewModel
            {
                Title = model.Properties.Title,
                Subtitle = model.Properties.Description,
                Description = model.Properties.MetaTitle,
                ButtonText = model.Properties.ButtonText,
                ButtonLink = model.Properties.ButtonLink,
                ImageUrl = image?.ImageFile?.Url ?? string.Empty
            };

            return View(
                "~/Components/Widgets/AboutUsWidget/_AboutUsWidget.cshtml",
                viewModel
            );
        }

        private async Task<Images> GetImage(AboutUsWidgetProperties properties)
        {
            var image = properties.Image?.FirstOrDefault();

            if (image == null)
            {
                return null;
            }

            var result = await contentRetriever.RetrieveContentByGuids<Images>(
                new[] { image.Identifier },
                HttpContext.RequestAborted
            );

            return result.FirstOrDefault();
        }




    }
}

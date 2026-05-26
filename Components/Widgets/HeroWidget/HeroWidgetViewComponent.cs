using Edukate.Components.Widgets.HeroWidget;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.Home",
    viewComponentType: typeof(HeroWidgetViewComponent),
    name: "Hero Banner",
    propertiesType: typeof(HeroWidgetProperties),
    Description = "Hero banner with heading and CTA buttons",
    IconClass = "xp-picture")]


namespace Edukate.Components.Widgets.HeroWidget
{
    public class HeroWidgetViewComponent : ViewComponent
    {
        private readonly IContentRetriever contentRetriever;


        /// <summary>
        /// Creates an instance of <see cref="HeroWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="contentRetriever">Content retriever.</param>
        public HeroWidgetViewComponent(IContentRetriever contentRetriever)
        {
            this.contentRetriever = contentRetriever;
        }
        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<HeroWidgetProperties> model)
        {
            var image = await GetImage(model.Properties);

            var viewModel = new HeroWidgetViewModel
            {
                Title = model.Properties.Title,
                MetaDescription = model.Properties.MetaDescription,
                ButtonText = model.Properties.ButtonText,
                ButtonLink = model.Properties.ButtonLink,
                ImageUrl = image?.ImageFile?.Url ?? string.Empty
            };

            return View(
                "~/Components/Widgets/HeroWidget/_HeroWidget.cshtml",
                viewModel
            );
        }

        private async Task<Images> GetImage(HeroWidgetProperties properties)
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

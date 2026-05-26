using Edukate.Components.Widgets.WhyChooseUsWidget;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.WhyChooseUs",
    viewComponentType: typeof(WhyChooseUsWidgetViewComponent),
    name: "Why Choose Us",
    propertiesType: typeof(WhyChooseUsWidgetProperties),
    Description = "Display features section explaining why users should choose your platform",
    IconClass = "xp-list-ul")]

namespace Edukate.Components.Widgets.WhyChooseUsWidget
{
    public class WhyChooseUsWidgetViewComponent : ViewComponent
    {
        private readonly IContentRetriever contentRetriever;

        /// <summary>
        /// Creates an instance of <see cref="WhyChooseUsWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="contentRetriever">Content retriever.</param>
        public WhyChooseUsWidgetViewComponent(IContentRetriever contentRetriever)
        {
            this.contentRetriever = contentRetriever;
        }

        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<WhyChooseUsWidgetProperties> model)
        {
            var image = await GetImage(model.Properties);

            var viewModel = new WhyChooseUsWidgetViewModel
            {
                SectionSubtitle = model.Properties.SectionSubtitle,
                SectionTitle = model.Properties.SectionTitle,
                IntroText = model.Properties.IntroText,

                // Feature 1
                Feature1Icon = model.Properties.Feature1Icon,
                Feature1BgColor = model.Properties.Feature1BgColor,
                Feature1Title = model.Properties.Feature1Title,
                Feature1Description = model.Properties.Feature1Description,

                // Feature 2
                Feature2Icon = model.Properties.Feature2Icon,
                Feature2BgColor = model.Properties.Feature2BgColor,
                Feature2Title = model.Properties.Feature2Title,
                Feature2Description = model.Properties.Feature2Description,

                // Feature 3
                Feature3Icon = model.Properties.Feature3Icon,
                Feature3BgColor = model.Properties.Feature3BgColor,
                Feature3Title = model.Properties.Feature3Title,
                Feature3Description = model.Properties.Feature3Description,

                FeatureImageUrl = image?.ImageFile?.Url ?? string.Empty
            };

            return View(
                "~/Components/Widgets/WhyChooseUsWidget/_WhyChooseUsWidget.cshtml",
                viewModel
            );
        }

        private async Task<Images> GetImage(WhyChooseUsWidgetProperties properties)
        {
            var image = properties.FeatureImage?.FirstOrDefault();

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

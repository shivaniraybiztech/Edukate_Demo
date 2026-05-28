using CMS.ContentEngine;
using Edukate.Components.Widgets.HeroWidget;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
          //  var image = await GetImage(model.Properties);

            var slide1Image = await GetImage(model.Properties.Image);
            var slide2Image = await GetImage(model.Properties.Slide2Image);

            var viewModel = new HeroWidgetViewModel();

            viewModel.Slides.Add(new HeroSlide
            {
                Title = model.Properties.Title,
                MetaDescription = model.Properties.MetaDescription,
                ButtonText = model.Properties.ButtonText,
                ButtonLink = model.Properties.ButtonLink,
                ImageUrl = slide1Image?.ImageFile?.Url ?? ""
            });

            viewModel.Slides.Add(new HeroSlide
            {
                Title = model.Properties.Slide2Title,
                MetaDescription = model.Properties.Slide2MetaDescription,
                ButtonText = model.Properties.Slide2ButtonText,
                ButtonLink = model.Properties.Slide2ButtonLink,
                ImageUrl = slide2Image?.ImageFile?.Url ?? ""
            });

            return View(
                "~/Components/Widgets/HeroWidget/_HeroWidget.cshtml",
                viewModel
            );
        }
        private async Task<Images> GetImage(IEnumerable<ContentItemReference> images)
        {
            var image = images?.FirstOrDefault();

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

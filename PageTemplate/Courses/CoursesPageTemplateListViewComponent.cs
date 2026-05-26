using CMS.ContentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Edukate.PageTemplate.Courses
{
    [ViewComponent(Name = "CoursesPageTemplateList")]
    public class CoursesPageTemplateListViewComponent : ViewComponent
    {
        private readonly IContentQueryExecutor contentQueryExecutor;

        public CoursesPageTemplateListViewComponent(IContentQueryExecutor contentQueryExecutor)
        {
            this.contentQueryExecutor = contentQueryExecutor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var queryBuilder = new ContentItemQueryBuilder()
                .ForContentType(
                    Edukate.CourseItem.CONTENT_TYPE_NAME,
                    config => config.WithLinkedItems(2)
                );

            var result = await contentQueryExecutor.GetMappedResult<Edukate.CourseItem>(queryBuilder);

            var courses = result.Select(item =>
            {
                string imageUrl = string.Empty;
                var imageItem = item.CourseImage?.FirstOrDefault();

                if (imageItem?.ImageFile != null)
                {
                    imageUrl = imageItem.ImageFile.Url;
                }

                return new CourseListItemViewModel
                {
                    CourseName = item.CourseTitle,
                    Description = item.CourseData,
                    Duration = item.Duration,
                    //Department = string.Empty,
                    Fees = 0,
                    ImageUrl = imageUrl,
                    Instructor = item.Instructor,
                    Rating = 4.5m,
                    ReviewCount = 250,
                    CourseUrl = item.SlugURL
                };
            }).ToList();

            var viewModel = new CoursesPageTemplateViewModel
            {
                Courses = courses,
                SectionTitle = "Our Courses",
                SectionHeading = "Checkout New Releases Of Our Courses"
            };

            return View("~/PageTemplate/Courses/_CoursesPageTemplateList.cshtml", viewModel);
        }
    }
}

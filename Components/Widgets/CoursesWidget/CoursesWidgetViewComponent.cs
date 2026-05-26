using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.Websites;
using CMS.Websites.Routing;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using System.CodeDom.Compiler;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.Courses",
    viewComponentType: typeof(Edukate.Components.Widgets.CoursesWidget.CoursesWidgetViewComponent),
    name: "Courses Widget",
    propertiesType: typeof(Edukate.Components.Widgets.CoursesWidget.CoursesWidgetProperties),
    Description = "Displays a list of courses",
    IconClass = "xp-list")]

namespace Edukate.Components.Widgets.CoursesWidget
{
    public class CoursesWidgetViewComponent : ViewComponent
    {
        private readonly IContentQueryExecutor contentQueryExecutor;

        private readonly IWebPageQueryResultMapper webPageMapper;

        public CoursesWidgetViewComponent(
            IContentQueryExecutor contentQueryExecutor,
            IWebPageQueryResultMapper webPageMapper)
        {
            this.contentQueryExecutor = contentQueryExecutor;
            this.webPageMapper = webPageMapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<CoursesWidgetProperties> model)
        {
            //// ✅ Fetch data from CMS
            //var queryBuilder = new ContentItemQueryBuilder()
            //    .ForContentType(
            //        Course.CONTENT_TYPE_NAME,
            //        config => config.TopN(model.Properties.NumberOfCourses)
            //    );

            //var result = await contentQueryExecutor.GetMappedWebPageResult<Course>(queryBuilder);
            //var courses = result.ToList();




            var properties = model.Properties;

            var query = new ContentItemQueryBuilder()
                .ForContentType(
                    CourseItem.CONTENT_TYPE_NAME,
                    config =>
                    {
                        config
                    .TopN(properties.NumberOfCourses)
                    .WithLinkedItems(2);
                    });

            var result = await contentQueryExecutor.GetMappedResult<CourseItem>(query);
            // Map course items
            var courses = result.Select(item =>
            {
                string imageUrl = string.Empty;

                // Get first image
                var imageItem = item.CourseImage?.FirstOrDefault();

                if (imageItem?.ImageFile != null)
                {
                    imageUrl = imageItem.ImageFile.Url;
                }

                return new CourseItemViewModel
                {
                    CourseName = item.CourseTitle,
                    Title = item.Title,
                    Description = item.CourseData,
                    Duration = item.Duration,
                    //Department = item.Department,
                    //Fees = item.Fees,
                    ImageUrl = imageUrl,

                    Instructor = item.Instructor,
                    Rating = 4.5m,
                    //ReviewCount = item.Duration,
                    CourseUrl = item.SlugURL
                };
            }).ToList();

            // Main widget ViewModel
            var viewModel = new CoursesWidgetViewModel
            {
                SectionTitle = properties.SectionTitle,
                SectionHeading = properties.SectionHeading,
                ShowPagination = properties.ShowPagination,
                Courses = courses
            };

            return View(
                "~/Components/Widgets/CoursesWidget/_CoursesWidget.cshtml",
                viewModel
            );
        }
    }
}

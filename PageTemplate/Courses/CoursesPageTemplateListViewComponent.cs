using CMS.ContentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
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
            int page = 1;

            if (Request.Query.ContainsKey("page"))
            {
                int.TryParse(Request.Query["page"], out page);

                if (page <= 0)
                {
                    page = 1;
                }
            }

            int pageSize = 6;

            var queryBuilder = new ContentItemQueryBuilder()
                .ForContentType(
                    Edukate.CourseItem.CONTENT_TYPE_NAME,
                    config => config.WithLinkedItems(2)
                );

            var result = await contentQueryExecutor.GetMappedResult<Edukate.CourseItem>(queryBuilder);

            int totalCourses = result.Count();

            var pagedCourses = result
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var courses = pagedCourses.Select(item =>
            {
                string imageUrl = string.Empty;
                var imageItem = item.CourseImage?.FirstOrDefault();

                if (imageItem?.ImageFile != null)
                {
                    imageUrl = imageItem.ImageFile.Url;
                }

                return new CourseListItemViewModel
                {
                    Title = item.Title,
                    CourseName = item.CourseTitle,
                    Description = item.CourseData,
                    Duration = item.Duration,
                    Fees = 0,
                    ImageUrl = imageUrl,
                    Instructor = item.Instructor,
                    Rating = 4.5m,
                    ReviewCount = 250,
                    CourseUrl = item.SlugURL
                };
            }).ToList();

            int totalPages = (int)Math.Ceiling((double)totalCourses / pageSize);

            var viewModel = new CoursesPageTemplateViewModel
            {
                Courses = courses,
                SectionTitle = "Our Courses",
                SectionHeading = "Checkout New Releases Of Our Courses",
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View("~/PageTemplate/Courses/_CoursesPageTemplateList.cshtml", viewModel);
        }
    }

}

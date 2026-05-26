using Edukate.Components.Widgets.CoursesWidget;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.Courses",
    viewComponentType: typeof(CoursesWidgetViewComponent),
    name: "Courses Widget",
    propertiesType: typeof(CoursesWidgetProperties),
    Description = "Displays a list of courses with images, descriptions, and ratings",
    IconClass = "xp-list")]

namespace Edukate.Components.Widgets.CoursesWidget
{
    public class CoursesWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Creates an instance of <see cref="CoursesWidgetViewComponent"/> class.
        /// </summary>
        public CoursesWidgetViewComponent()
        {
        }

        public Task<IViewComponentResult> InvokeAsync(ComponentViewModel<CoursesWidgetProperties> model)
        {
            var viewModel = new CoursesWidgetViewModel
            {
                SectionTitle = model.Properties.SectionTitle,
                SectionHeading = model.Properties.SectionHeading,
                ShowPagination = model.Properties.ShowPagination,
                Courses = new System.Collections.Generic.List<CourseItemViewModel>()
            };

            // Add sample courses for demonstration
            for (int i = 1; i <= model.Properties.NumberOfCourses; i++)
            {
                viewModel.Courses.Add(new CourseItemViewModel
                {
                    CourseName = "Web design & development courses for beginners",
                    Description = "Learn the fundamentals of web design and development",
                    Duration = "4 weeks",
                    Department = "Computer Science",
                    Fees = 299,
                    ImageUrl = $"~/img/courses-{((i - 1) % 6) + 1}.jpg",
                    CourseUrl = "#",
                    Instructor = "Jhon Doe",
                    Rating = 4.5m,
                    ReviewCount = 250
                });
            }

            return Task.FromResult<IViewComponentResult>(View(
                "~/Components/Widgets/CoursesWidget/_CoursesWidget.cshtml",
                viewModel
            ));
        }
    }
}

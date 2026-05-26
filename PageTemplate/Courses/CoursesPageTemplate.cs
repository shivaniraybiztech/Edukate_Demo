using Edukate;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

[assembly: RegisterPageTemplate(
    identifier: "Edukate.Courses",
    name: "Courses Listing Page Template",
    customViewName: "~/PageTemplate/Courses/_CoursesPageTemplate.cshtml",
    ContentTypeNames = [CourseItem.CONTENT_TYPE_NAME],
    Description = "Courses listing page template for Edukate displaying course listings with pagination",
    IconClass = "xp-list"
)]

namespace Edukate.PageTemplate.Courses;

public class CoursesPageTemplate
{
    public const string IDENTIFIER = "Edukate.Courses";
}




using Edukate;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

[assembly: RegisterPageTemplate(
    identifier: "Edukate.CourseItem",
    name: "Course Item Page Template",
    customViewName: "~/PageTemplate/CourseItem/_CourseItemPageTemplate.cshtml",
    ContentTypeNames = new[] { CourseItem.CONTENT_TYPE_NAME },
    Description = "Course item page template for Edukate displaying individual course details",
    IconClass = "xp-list"
)]

namespace Edukate.PageTemplate.CourseItem;

public class CourseItemPageTemplate
{
    public const string IDENTIFIER = "Edukate.CourseItem";
}


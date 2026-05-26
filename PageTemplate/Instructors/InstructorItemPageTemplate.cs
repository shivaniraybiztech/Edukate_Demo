using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Edukate;

[assembly: RegisterPageTemplate(
    identifier: "Edukate.InstructorItem",
    name: "Instructor Detail Page Template",
    customViewName: "~/PageTemplate/Instructors/_InstructorItemPageTemplate.cshtml",
    ContentTypeNames = new[] { InstructorItem.CONTENT_TYPE_NAME },
    Description = "Instructor item page template for Edukate displaying individual instructor details",
    IconClass = "xp-user"
)]

namespace Edukate.PageTemplate.Instructors
{
    public class InstructorItemPageTemplate
    {
        public const string IDENTIFIER = "Edukate.InstructorItem";
    }
}

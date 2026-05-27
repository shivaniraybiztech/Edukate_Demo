using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Edukate;

[assembly: RegisterPageTemplate(
    identifier: "Edukate.Instructors",
    name: "Instructors Page for all Instructors Template",
    customViewName: "~/PageTemplate/Instructors/_InstructorsPageTemplate.cshtml",
    ContentTypeNames = new[] { InstructorPage.CONTENT_TYPE_NAME },
    Description = "Instructors page template for Edukate displaying all instructors",
    IconClass = "xp-users"
)]

namespace Edukate.PageTemplate.Instructors
{
    public class InstructorsPageTemplate
    {
        public const string IDENTIFIER = "Edukate.Instructors";
    }
}

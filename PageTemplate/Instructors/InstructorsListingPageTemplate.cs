using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Edukate;

[assembly: RegisterPageTemplate(
    identifier: "Edukate.InstructorsListing",
    name: "Instructors Listing Page Template",
    customViewName: "~/PageTemplate/Instructors/_InstructorsListingPageTemplate.cshtml",
    ContentTypeNames = new[] { Home.CONTENT_TYPE_NAME, About.CONTENT_TYPE_NAME },
    Description = "Instructors listing page template for Edukate displaying all team members",
    IconClass = "xp-users"
)]

namespace Edukate.PageTemplate.Instructors
{
    public class InstructorsListingPageTemplate
    {
        public const string IDENTIFIER = "Edukate.InstructorsListing";
    }
}

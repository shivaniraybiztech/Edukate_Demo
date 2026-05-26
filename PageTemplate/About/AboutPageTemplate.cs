using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Edukate;



[assembly: RegisterPageTemplate(
    identifier: "Edukate.About",
    name: "About Page Template",
    customViewName: "~/PageTemplate/About/_AboutPageTemplate.cshtml",
    ContentTypeNames = [About.CONTENT_TYPE_NAME],
    Description = "About page template for Edukate with editable hero, news, about, and content areas",
    IconClass = "xp-home"
)]



namespace Edukate.PageTemplate.About
{
    public class AboutPageTemplate
    {
        public const string IDENTIFIER = "Edukate.About";
    }
}




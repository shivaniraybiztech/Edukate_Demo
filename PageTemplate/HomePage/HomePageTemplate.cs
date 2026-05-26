
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Edukate;

[assembly: RegisterPageTemplate(
    identifier: "Edukate.Home",
    name: "Home Page Template",
    customViewName: "~/PageTemplate/HomePage/_HomePageTemplate.cshtml",
    ContentTypeNames = [Home.CONTENT_TYPE_NAME],
    Description = "Home page template for Edukate with editable hero, news, about, and content areas",
    IconClass = "xp-home"
)]


namespace Edukate.PageTemplate.HomePage;

public class HomePageTemplate
{
    public const string IDENTIFIER = "Edukate.Home";
}

using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Edukate;



[assembly: RegisterPageTemplate(
    identifier: "Edukate.Admission",
    name: "Admission Page Template",
    customViewName: "~/PageTemplate/Admission/_AdmissionPageTemplate.cshtml",
    ContentTypeNames = [Admission.CONTENT_TYPE_NAME],
    Description = "Admission page template for Edukate with form submission area",
    IconClass = "xp-form"
)]



namespace Edukate.PageTemplate.Admission
{
    public class AdmissionPageTemplate
    {
        public const string IDENTIFIER = "Edukate.Admission";
    }
}

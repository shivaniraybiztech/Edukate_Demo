using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.AdmissionFormWidget",
    viewComponentType: typeof(Edukate.Components.Widgets.AdmissionFormWidget.AdmissionFormWidgetViewComponent),
    name: "Admission Form",
    propertiesType: typeof(Edukate.Components.Widgets.AdmissionFormWidget.AdmissionFormWidgetProperties),
    Description = "Displays an admission form for student applications",
    IconClass = "icon-form")]

namespace Edukate.Components.Widgets.AdmissionFormWidget
{
    public class AdmissionFormWidgetViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(ComponentViewModel<AdmissionFormWidgetProperties> componentViewModel)
        {
            var properties = componentViewModel.Properties;

            var model = new AdmissionFormWidgetViewModel
            {
                FormTitle = properties.FormTitle ?? "Admission Form",
                FormDescription = properties.FormDescription ?? "Fill out the form below to apply for admission.",
                SuccessMessage = properties.SuccessMessage ?? "Thank you for your application! We will contact you soon.",
                SubmitButtonText = properties.SubmitButtonText ?? "Submit Application",
                IsSubmitted = false
            };

            return Task.FromResult<IViewComponentResult>(View("~/Components/Widgets/AdmissionFormWidget/_AdmissionFormWidget.cshtml", model));
        }
    }
}

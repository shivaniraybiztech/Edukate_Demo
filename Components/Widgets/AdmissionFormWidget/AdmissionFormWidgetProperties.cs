using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Edukate.Components.Widgets.AdmissionFormWidget
{
    public class AdmissionFormWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Form Title", Order = 1)]
        public string FormTitle { get; set; } = "Admission Form";

        [TextAreaComponent(Label = "Form Description", Order = 2)]
        public string FormDescription { get; set; } = "Fill out the form below to apply for admission.";

        [TextAreaComponent(Label = "Success Message", Order = 3)]
        public string SuccessMessage { get; set; } = "Thank you for your application! We will contact you soon.";

        [TextInputComponent(Label = "Submit Button Text", Order = 4)]
        public string SubmitButtonText { get; set; } = "Submit Application";
    }
}

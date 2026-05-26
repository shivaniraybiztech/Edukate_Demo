using CMS.ContentEngine;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using System.Collections.Generic;

namespace Edukate.Components.Widgets.InstructorsWidget
{
    public class InstructorsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Expert Instructors";

        [TextInputComponent(Label = "Section Heading", Order = 2)]
        public string SectionHeading { get; set; } = "Meet Our Expert Instructors";

        [NumberInputComponent(Label = "Number of Instructors to Display", Order = 3)]
        public int NumberOfInstructors { get; set; } = 8;

        [CheckBoxComponent(Label = "Show All Button", Order = 4)]
        public bool ShowAllButton { get; set; } = true;
    }
}

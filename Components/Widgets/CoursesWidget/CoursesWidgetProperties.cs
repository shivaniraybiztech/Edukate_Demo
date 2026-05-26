using CMS.ContentEngine;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using System.Collections.Generic;

namespace Edukate.Components.Widgets.CoursesWidget
{
    public class CoursesWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Our Courses";

        [TextInputComponent(Label = "Section Heading", Order = 2)]
        public string SectionHeading { get; set; } = "Checkout New Releases Of Our Courses";

        [NumberInputComponent(Label = "Number of Courses to Display", Order = 3)]
        public int NumberOfCourses { get; set; } = 6;

        [CheckBoxComponent(Label = "Show Pagination", Order = 4)]
        public bool ShowPagination { get; set; } = true;

        [ContentItemSelectorComponent(
          Images.CONTENT_TYPE_NAME,
          Label = "Feature Image",
          MaximumItems = 20,
          Order = 16)]
        public IEnumerable<ContentItemReference> Image { get; set; }
    }
}

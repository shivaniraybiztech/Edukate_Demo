using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Edukate.Components.Widgets.AnnouncementsWidget
{
    public class AnnouncementsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Title", Order = 1)]
        public string SectionTitle { get; set; } = "Announcements";

        [TextInputComponent(Label = "Section Heading", Order = 2)]
        public string SectionHeading { get; set; } = "Latest Announcements";

        [NumberInputComponent(Label = "Number of Announcements to Display", Order = 3)]
        public int NumberOfAnnouncements { get; set; } = 4;

        [CheckBoxComponent(Label = "Show View All Button", Order = 4)]
        public bool ShowViewAllButton { get; set; } = false;
    }
}

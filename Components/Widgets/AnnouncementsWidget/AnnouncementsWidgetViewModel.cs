using System;
using System.Collections.Generic;

namespace Edukate.Components.Widgets.AnnouncementsWidget
{
    public class AnnouncementsWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionHeading { get; set; }
        public List<AnnouncementItemViewModel> Announcements { get; set; } = new List<AnnouncementItemViewModel>();
        public bool ShowViewAllButton { get; set; }
    }

    public class AnnouncementItemViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

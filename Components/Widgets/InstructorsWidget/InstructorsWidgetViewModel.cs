using System.Collections.Generic;

namespace Edukate.Components.Widgets.InstructorsWidget
{
    public class InstructorsWidgetViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionHeading { get; set; }
        public List<InstructorItemViewModel> Instructors { get; set; } = new List<InstructorItemViewModel>();
        public bool ShowAllButton { get; set; }
    }

    public class InstructorItemViewModel
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedInURL { get; set; }
        public string InstagramURL { get; set; }
        public string YoutubeURL { get; set; }
        public string SlugUrl { get; set; }
    }
}

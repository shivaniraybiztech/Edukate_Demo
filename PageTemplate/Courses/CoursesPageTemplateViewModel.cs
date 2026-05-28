using System.Collections.Generic;

namespace Edukate.PageTemplate.Courses
{
    public class CoursesPageTemplateViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionHeading { get; set; }
        public List<CourseListItemViewModel> Courses { get; set; } = new List<CourseListItemViewModel>();
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }

    public class CourseListItemViewModel
    {
        public string Title { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Department { get; set; }
        public int Fees { get; set; }
        public string ImageUrl { get; set; }
        public string CourseUrl { get; set; }
        public string Instructor { get; set; } = "Jhon Doe";
        public decimal Rating { get; set; } = 4.5m;
        public int ReviewCount { get; set; } = 250;
    }
}

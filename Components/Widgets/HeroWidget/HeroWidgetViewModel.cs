//namespace Edukate.Components.Widgets.HeroWidget
//{
//    public class HeroWidgetViewModel
//    {
//        public string Title { get; set; }
//        public string MetaDescription { get; set; }
//        public string ButtonText { get; set; }
//        public string ButtonLink { get; set; }
//        public string ImageUrl { get; set; }
//    }
//}


using System.Collections.Generic;

namespace Edukate.Components.Widgets.HeroWidget
{
    public class HeroWidgetViewModel
    {
        public List<HeroSlide> Slides { get; set; } = new();
    }
}
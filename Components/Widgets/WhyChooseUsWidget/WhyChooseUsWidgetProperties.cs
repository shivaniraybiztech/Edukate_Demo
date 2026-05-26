using CMS.ContentEngine;
using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;
using System.Collections.Generic;

namespace Edukate.Components.Widgets.WhyChooseUsWidget
{
    public class WhyChooseUsWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Section Subtitle", Order = 1)]
        public string SectionSubtitle { get; set; } = "Why Choose Us?";

        [TextInputComponent(Label = "Section Title", Order = 2)]
        public string SectionTitle { get; set; } = "Why You Should Start Learning with Us?";

        [TextAreaComponent(Label = "Introduction Text", Order = 3)]
        public string IntroText { get; set; }

        // Feature 1
        [TextInputComponent(Label = "Feature 1 - Icon Class", Order = 4)]
        public string Feature1Icon { get; set; } = "fa fa-graduation-cap";

        [TextInputComponent(Label = "Feature 1 - Background Color", Order = 5)]
        public string Feature1BgColor { get; set; } = "primary";

        [TextInputComponent(Label = "Feature 1 - Title", Order = 6)]
        public string Feature1Title { get; set; } = "Skilled Instructors";

        [TextAreaComponent(Label = "Feature 1 - Description", Order = 7)]
        public string Feature1Description { get; set; }

        // Feature 2
        [TextInputComponent(Label = "Feature 2 - Icon Class", Order = 8)]
        public string Feature2Icon { get; set; } = "fa fa-certificate";

        [TextInputComponent(Label = "Feature 2 - Background Color", Order = 9)]
        public string Feature2BgColor { get; set; } = "secondary";

        [TextInputComponent(Label = "Feature 2 - Title", Order = 10)]
        public string Feature2Title { get; set; } = "International Certificate";

        [TextAreaComponent(Label = "Feature 2 - Description", Order = 11)]
        public string Feature2Description { get; set; }

        // Feature 3
        [TextInputComponent(Label = "Feature 3 - Icon Class", Order = 12)]
        public string Feature3Icon { get; set; } = "fa fa-book-reader";

        [TextInputComponent(Label = "Feature 3 - Background Color", Order = 13)]
        public string Feature3BgColor { get; set; } = "warning";

        [TextInputComponent(Label = "Feature 3 - Title", Order = 14)]
        public string Feature3Title { get; set; } = "Online Classes";

        [TextAreaComponent(Label = "Feature 3 - Description", Order = 15)]
        public string Feature3Description { get; set; }

        [ContentItemSelectorComponent(
            Images.CONTENT_TYPE_NAME,
            Label = "Feature Image",
            MaximumItems = 1,
            Order = 16)]
        public IEnumerable<ContentItemReference> FeatureImage { get; set; }
    }
}

using CMS.ContentEngine;
using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;
using System.Collections.Generic;



namespace Edukate.Components.Widgets.HeroWidget
{

   
    public class HeroWidgetProperties : IWidgetProperties
    {


        [TextInputComponent(Label = "Title", Order = 1)]
    public string Title { get; set; }

        [TextAreaComponent(Label = "MetaDescription", Order = 2)]
        public string MetaDescription { get; set; }

        [TextInputComponent(Label = "Button Text", Order = 3)]
        public string ButtonText { get; set; }

        [TextInputComponent(Label = "Button Link", Order = 4)]
        public string ButtonLink { get; set; }


        [ContentItemSelectorComponent(
            Images.CONTENT_TYPE_NAME,
            Label = "Hero Image",
            MaximumItems = 5)]
        public IEnumerable<ContentItemReference> Image { get; set; }

    }

    }

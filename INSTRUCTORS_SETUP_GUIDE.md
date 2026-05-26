# Instructors Page & Widget - Setup Guide

## Overview
This implementation adds an Instructors/Team page and widget to your Edukate project, matching the exact design from the Edukate theme (https://themewagon.github.io/Edukate/team.html).

## ✅ Files Created

### Content Type Model
- `PageContentTypes\Edukate\InstructorItem\InstructorItem.generated.cs`

### Page Template  
- `PageTemplate\Instructors\InstructorsPageTemplate.cs`
- `PageTemplate\Instructors\_InstructorsPageTemplate.cshtml`

### Widget Components
- `Components\Widgets\InstructorsWidget\InstructorsWidgetProperties.cs`
- `Components\Widgets\InstructorsWidget\InstructorsWidgetViewModel.cs`
- `Components\Widgets\InstructorsWidget\InstructorsWidgetViewComponent.cs`
- `Components\Widgets\InstructorsWidget\_InstructorsWidget.cshtml`

---

## 🚀 Setup Instructions

### Step 1: Create Content Type in Kentico Admin

1. **Navigate to Content Types**
   - Go to Kentico Admin → **Content types**
   - Click **Create new** → **Page content type**

2. **Configure Content Type**
   - **Name**: `InstructorItem`
   - **Namespace**: `Edukate`
   - **Code name**: `Edukate.InstructorItem` (must match exactly)

3. **Add Fields**

   | Field Name    | Field Type    | Required | Settings                                    |
   |---------------|---------------|----------|---------------------------------------------|
   | Name          | Text          | ✅ Yes   | Max length: 200                             |
   | Designation   | Text          | ✅ Yes   | Max length: 200 (e.g., "Web Design & Development") |
   | Bio           | Rich text     | ❌ No    | For detailed instructor bio                 |
   | Photo         | Content items | ❌ No    | Allowed types: `Edukate.Images`, Max: 1     |
   | FacebookURL   | Text          | ❌ No    | Max length: 500                             |
   | TwitterURL    | Text          | ❌ No    | Max length: 500                             |
   | LinkedInURL   | Text          | ❌ No    | Max length: 500                             |
   | InstagramURL  | Text          | ❌ No    | Max length: 500                             |
   | YoutubeURL    | Text          | ❌ No    | Max length: 500                             |

4. **Save** the content type

---

### Step 2: Restart Your Application

**Important:** Since we've added new page templates and widgets with assembly-level attributes, you need to restart the application.

```powershell
# Stop the application if running
# Then restart it
```

---

### Step 3: Create Instructor Content

1. **Create Instructors**
   - Go to **Content** → **Pages**
   - Click **Create** → Select **InstructorItem**

2. **Fill in Details** (Example):
   - **Name**: "John Smith"
   - **Designation**: "Web Design & Development"
   - **Bio**: (Optional) "Expert web developer with 10+ years experience..."
   - **Photo**: Upload instructor photo (recommended: 500x500px square image)
   - **Social URLs**: (Optional)
	 - Twitter: `https://twitter.com/username`
	 - Facebook: `https://facebook.com/username`
	 - LinkedIn: `https://linkedin.com/in/username`
	 - Instagram: `https://instagram.com/username`
	 - YouTube: `https://youtube.com/@channel`

3. **Configure Page Settings**
   - Go to **Page** tab
   - Select **Instructors Page Template** (if creating standalone page)
   - Set URL slug (e.g., `/instructors/john-smith`)

4. **Publish** the page

5. **Repeat** to create multiple instructors (recommended: at least 4-6 for carousel effect)

---

### Step 4: Use the Instructors Widget

#### Option A: Add to Homepage or Any Page

1. Open any page in **Edit mode**
2. Navigate to an editable area
3. Click **+ Add widget**
4. Select **Instructors Widget**
5. Configure settings:
   - **Section Title**: `Instructors` (small text above heading)
   - **Section Heading**: `Meet Our Instructors` (main heading)
   - **Number of Instructors to Display**: `8` (or any number)
   - **Show All Button**: `true/false` (currently not used in carousel version)
6. **Save** the widget

#### Option B: Create Dedicated Instructors Page

1. Create a new page (any content type)
2. In **Page** tab, select **Instructors Page Template**
3. In the editable area, add the **Instructors Widget**
4. Set higher display count (e.g., 12-20 instructors)

---

## 🎨 Design Features

### Owl Carousel Integration
- ✅ **Responsive carousel** - Already initialized in `main.js`
- ✅ **Auto-play** enabled (1 second smart speed)
- ✅ **Navigation arrows** (left/right)
- ✅ **30px margin** between items
- ✅ **Responsive breakpoints**:
  - Mobile (0-575px): 1 item
  - Tablet (576-767px): 1 item  
  - Medium (768-991px): 2 items
  - Desktop (992px+): 3 items

### Social Media Icons
The widget displays social icons in this order (if URLs provided):
1. 🐦 Twitter
2. 📘 Facebook
3. 💼 LinkedIn
4. 📷 Instagram
5. 📺 YouTube

Icons use Font Awesome (already included in your project).

---

## 📋 Widget Configuration Options

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| Section Title | Text | "Expert Instructors" | Small uppercase text above heading |
| Section Heading | Text | "Meet Our Expert Instructors" | Main section heading |
| Number of Instructors | Number | 8 | How many instructors to fetch and display |
| Show All Button | Boolean | true | (Reserved for future use) |

---

## 🔧 Customization

### Change Carousel Settings

Edit `wwwroot\js\main.js` (lines 90-110):

```javascript
$(".team-carousel").owlCarousel({
	autoplay: true,        // Enable/disable autoplay
	smartSpeed: 1000,      // Animation speed (ms)
	margin: 30,            // Space between items
	dots: false,           // Show/hide dots
	loop: true,            // Enable infinite loop
	nav: true,             // Show/hide arrows
	responsive: {
		992: { items: 3 }  // Change number of items per breakpoint
	}
});
```

### Update Styling

Key CSS classes (in `wwwroot\css\style.css`):
- `.team-carousel` - Carousel container
- `.team-item` - Individual instructor card
- `.section-title` - Section heading styles
- Font Awesome icons automatically styled

### Add More Social Networks

1. **Update Model** (`InstructorItem.generated.cs`):
```csharp
public string TikTokURL { get; set; }
```

2. **Update ViewModel** (`InstructorsWidgetViewModel.cs`):
```csharp
public string TikTokURL { get; set; }
```

3. **Update View Component** (`InstructorsWidgetViewComponent.cs`):
```csharp
TikTokURL = item.TikTokURL
```

4. **Update View** (`_InstructorsWidget.cshtml`):
```html
@if (!string.IsNullOrWhiteSpace(instructor.TikTokURL))
{
	<a class="mx-1 p-1" href="@instructor.TikTokURL" target="_blank">
		<i class="fab fa-tiktok"></i>
	</a>
}
```

5. **Add field** to Kentico content type (Step 1)

---

## 📸 Image Guidelines

### Recommended Specifications
- **Format**: JPG or PNG
- **Size**: 500x500px (square)
- **Aspect Ratio**: 1:1
- **File Size**: < 500KB (optimized)
- **Background**: Professional, neutral, or transparent

### Upload Process
1. Go to **Content** → **Assets** or use inline upload
2. Upload images to `Edukate.Images` content type
3. Link to instructor via **Photo** field

---

## 🐛 Troubleshooting

### Widget Not Appearing
- ✅ Verify content type code name: `Edukate.InstructorItem`
- ✅ Restart the application (required for new widgets)
- ✅ Check if instructors are published (not just saved as draft)

### Carousel Not Working
- ✅ Ensure jQuery is loaded before `main.js`
- ✅ Verify Owl Carousel library is included (check `_Layout.cshtml`)
- ✅ Check browser console for JavaScript errors
- ✅ Ensure `.team-carousel` class is present in HTML

### Images Not Displaying
- ✅ Verify `Edukate.Images` content type exists
- ✅ Check image URLs in browser dev tools (Network tab)
- ✅ Ensure images are published
- ✅ Check asset URL configuration in Kentico

### Social Icons Not Showing
- ✅ Verify Font Awesome is loaded in layout
- ✅ Check if URLs are provided (icons only show if URL exists)
- ✅ URLs must include protocol: `https://...`

---

## 📚 Technical Details

### Dependencies
- **CMS.ContentEngine** - Content querying
- **Kentico.PageBuilder.Web.Mvc** - Widget framework
- **Kentico.Content.Web.Mvc** - Content retrieval
- **Owl Carousel 2.x** - Carousel functionality (already included)
- **Font Awesome 5.x** - Social icons (already included)

### Content Query
The widget uses `IContentQueryExecutor` to fetch instructors:
- Content type: `Edukate.InstructorItem`
- Linked items depth: 2 (for images)
- Ordering: Default (can be customized)
- TopN: Configurable via widget properties

### Performance
- Content is fetched server-side (no client-side API calls)
- Images are linked content items (efficient)
- Carousel initialized once on page load

---

## 📖 Reference

**Original Theme**: https://themewagon.github.io/Edukate/team.html

**Kentico Documentation**:
- Content Types: https://docs.xperience.io/
- Page Builder Widgets: https://docs.xperience.io/
- Content Querying: https://docs.xperience.io/

---

## ✨ Usage Examples

### Homepage Showcase (4 instructors)
```
Section Title: "Expert Instructors"
Section Heading: "Meet Our Team"
Number of Instructors: 4
```

### Full Team Page (All instructors)
```
Section Title: "Our Instructors"
Section Heading: "Meet Our Expert Instructors"  
Number of Instructors: 20
```

### About Page Section (6 instructors)
```
Section Title: "Team"
Section Heading: "The People Behind Edukate"
Number of Instructors: 6
```

---

## 🎯 Next Steps

1. ✅ Create content type in Kentico (Step 1)
2. ✅ Restart application
3. ✅ Create at least 4 instructor items (Step 3)
4. ✅ Add widget to homepage or create instructors page (Step 4)
5. ✅ Test carousel functionality
6. ✅ Customize text and settings as needed

---

**Need Help?**
- Check Kentico logs in `App_Data\CMSModules\WebFarm\`
- Review browser console for JavaScript errors
- Verify all files are included in the project
- Ensure application has been restarted after adding new widgets

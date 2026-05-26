# Instructors Implementation - Quick Reference

## What Was Created

### ✅ Complete Implementation
- **InstructorItem Content Type** - For storing instructor data
- **Instructors Page Template** - Dedicated instructors listing page
- **Instructors Widget** - Reusable component with Owl Carousel

## Design Match
✅ **Exact match** to https://themewagon.github.io/Edukate/team.html
- Owl Carousel with navigation arrows
- Responsive (1-3 items based on screen size)
- Social media icons (Twitter, Facebook, LinkedIn, Instagram, YouTube)
- Auto-play enabled

## Quick Start

### 1. Create Content Type in Kentico
```
Name: InstructorItem
Namespace: Edukate  
Code Name: Edukate.InstructorItem

Fields:
- Name (Text, Required)
- Designation (Text, Required)
- Bio (Rich text)
- Photo (Content items - Edukate.Images)
- FacebookURL (Text)
- TwitterURL (Text)
- LinkedInURL (Text)
- InstagramURL (Text)
- YoutubeURL (Text)
```

### 2. Restart Application
**Important!** New widgets require app restart.

### 3. Create Instructor Content
- Go to Content → Pages → Create
- Select InstructorItem
- Fill in name, designation, upload photo
- Add social media URLs (optional)
- Publish

### 4. Add Widget to Page
- Edit any page
- Add "Instructors Widget"
- Configure:
  - Section Title: "Instructors"
  - Section Heading: "Meet Our Instructors"
  - Number to Display: 8

## File Locations

```
PageContentTypes/Edukate/InstructorItem/
├── InstructorItem.generated.cs

PageTemplate/Instructors/
├── InstructorsPageTemplate.cs
└── _InstructorsPageTemplate.cshtml

Components/Widgets/InstructorsWidget/
├── InstructorsWidgetProperties.cs
├── InstructorsWidgetViewModel.cs
├── InstructorsWidgetViewComponent.cs
└── _InstructorsWidget.cshtml
```

## Carousel Already Configured

The team carousel is already initialized in `wwwroot/js/main.js`:
- Auto-play: ✅
- Navigation: ✅
- Responsive: ✅ (1/1/2/3 items)
- Speed: 1000ms

No additional JavaScript needed!

## Social Media Icons Order

When URLs are provided, icons appear in this order:
1. 🐦 Twitter
2. 📘 Facebook  
3. 💼 LinkedIn
4. 📷 Instagram
5. 📺 YouTube

## Common Issues

| Issue | Solution |
|-------|----------|
| Widget not appearing | Restart application after creating content type |
| Carousel not working | Check jQuery and Owl Carousel are loaded |
| Images not showing | Verify Edukate.Images content type exists |
| No instructors displayed | Ensure instructors are published (not draft) |

## Full Documentation
See `INSTRUCTORS_SETUP_GUIDE.md` for detailed instructions.

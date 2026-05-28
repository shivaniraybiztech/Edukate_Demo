using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: RegisterWidget(
    identifier: "Edukate.AdmissionFormWidget",
    viewComponentType: typeof(Edukate.Components.Widgets.AdmissionFormWidget.AdmissionFormWidgetViewComponent),
    name: "Admission Form",
    propertiesType: typeof(Edukate.Components.Widgets.AdmissionFormWidget.AdmissionFormWidgetProperties),
    Description = "Displays an admission form for student applications",
    IconClass = "icon-form")]

namespace Edukate.Components.Widgets.AdmissionFormWidget
{
    public class AdmissionFormWidgetViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public AdmissionFormWidgetViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<AdmissionFormWidgetProperties> componentViewModel)
        {
            var properties = componentViewModel.Properties;
            var courseData = await GetCoursesListAsync();
            var model = new AdmissionFormWidgetViewModel
            {
                FormTitle = properties.FormTitle ?? "Admission Form",
                FormDescription = properties.FormDescription ?? "Fill out the form below to apply for admission.",
                SuccessMessage = properties.SuccessMessage ?? "Thank you for your application! We will contact you soon.",
                SubmitButtonText = properties.SubmitButtonText ?? "Submit Application",
                IsSubmitted = false,
                Courses = courseData
            };

            return View("~/Components/Widgets/AdmissionFormWidget/_AdmissionFormWidget.cshtml", model);
        }
    


        private async Task<List<CourseItem>> GetCoursesListAsync()
        {
            var courseList = new List<CourseItem>();

            string connectionString = _configuration.GetConnectionString("CMSConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT ContentItemDataID, Title, CourseTitle, SlugURL FROM Edukate_CourseItem";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            courseList.Add(new CourseItem
                            {
                                //Id = Convert.ToInt32(reader["ContentItemDataID"]),
                                Title = reader["Title"].ToString(),
                                CourseTitle = reader["CourseTitle"].ToString(),
                                SlugURL = reader["SlugURL"].ToString()
                            });
                        }
                    }
                }
            }
            return courseList;
        }
    }
}

using CMS.OnlineForms;
using CMS.OnlineForms.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Edukate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        [HttpPost("submit")]
        public IActionResult Submit([FromForm] AdmissionFormData formData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, message = "Please fill in all required fields." });
                }

                // Create new form item
                var formItem = new Form_2026_05_27_16_08_51_576Item
                {
                    Student_Name = formData.Student_Name,
                    Email = formData.Email,
                    Mobile = formData.Mobile,
                    Courses = formData.Courses
                };

                // Save the form submission
                formItem.Insert();

                return Ok(new { success = true, message = "Thank you for your application! We will contact you soon." });
            }
            catch (Exception ex)
            {
                // Log the exception here if you have a logging service
                return StatusCode(500, new { success = false, message = "An error occurred while processing your application. Please try again later." });
            }
        }
    }

    public class AdmissionFormData
    {
        public string Student_Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Courses { get; set; }
    }
}

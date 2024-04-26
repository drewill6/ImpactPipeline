using DataImpact.Interfaces;
using DataImpact.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataImpact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IUserService _userService; // Assuming you have a service to handle user data

        public PersonalInfoController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonalInfoModel personalInfo, [FromForm] IFormFile resume)
        {
            try
            {
                if (personalInfo == null || resume == null)
                {
                    return BadRequest("Invalid request: Personal information and resume are required.");
                }

                // Save personalInfo and resume to the database using _userService
                await _userService.SavePersonalInfoAsync(personalInfo);

                // Process the resume file (save it, send it to cloud storage, etc.)
                // You can use 'resume' which is of type IFormFile to handle the uploaded file

                return Ok("Form submitted successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

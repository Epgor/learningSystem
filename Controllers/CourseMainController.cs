using Microsoft.AspNetCore.Mvc;
using learningSystem.Models;
using learningSystem.Services;
using Microsoft.AspNetCore.Authorization;
using learningSystem.Entities;

namespace learningSystem.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseMainController : ControllerBase
    {
        private readonly ICourseMainService _courseMainService;
        public CourseMainController(ICourseMainService courseMainService)
        {
            _courseMainService = courseMainService;
        }

        [HttpGet]
        public ActionResult<List<CourseMain>> GetAll()
        {
            var courses = _courseMainService.GetAll();
            return Ok(courses);
        }
    }
}

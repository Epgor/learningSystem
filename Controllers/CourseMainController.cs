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

        [HttpGet("{id}")]
        public ActionResult<CourseMain> Get(int id)
        {
            var course = _courseMainService.Get(id);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _courseMainService.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public ActionResult Add([FromBody]CourseMain courseMain)
        {
            int id = _courseMainService.Add(courseMain);
            return Created($"/api/course/{id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id,[FromBody]CourseMain course)
        {
            _courseMainService.Update(id, course);
            return Ok();
        }

    }
}

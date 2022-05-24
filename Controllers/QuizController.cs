using Microsoft.AspNetCore.Mvc;
using learningSystem.Models;
using learningSystem.Services;
using Microsoft.AspNetCore.Authorization;
using learningSystem.Entities;

namespace learningSystem.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<QuizDto>> GetAll([FromRoute] int id)
        {
            var quiz = _quizService.GetAll(id);
            return Ok(quiz);
        }
        [HttpGet("{id}/questions")]
        public ActionResult<List<QuestionDto>> GetQuizQuestions([FromRoute] int id)
        {
            var questions = _quizService.GetQuestions(id);
            return Ok(questions);
        }
        [HttpPost("{id}/check")]
        public ActionResult<ScoreDto> CheckAnswers([FromRoute] int id, [FromBody] List<QuestionDto> dto)
        {
            var score = _quizService.CheckAnswers(dto, id);
            return Ok(score);

        }
        /*
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
        */
    }
}

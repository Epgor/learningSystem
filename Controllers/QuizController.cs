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
        [HttpPost("{courseId}")]
        public ActionResult Create([FromRoute] int courseId, [FromBody] QuizDto quizDto)
        {
            int id= _quizService.Add(courseId, quizDto);
            return Created($"/api/quiz/{id}", null);
        }

        [HttpPut("{quizId}")]
        public ActionResult Update([FromRoute] int quizId, [FromBody] QuizDto quizDto)
        {
            _quizService.Update(quizId, quizDto);
            return Ok();
        }

        [HttpDelete("{quizId}")]
        public ActionResult Delete([FromRoute] int quizId)
        {
            _quizService.Delete(quizId);
            return NoContent();
        }
    }
}

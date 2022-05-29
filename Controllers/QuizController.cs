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


        [HttpPost("{quizId}/questions")] 
        public ActionResult CreateQuestion([FromRoute]int quizId, [FromBody]QuestionDto questionDto)
        {
            var questionId = _quizService.AddQuestion(quizId, questionDto);
            return Created($"/api/quiz/{quizId}/questions/{questionId}", null);
        }

        [HttpGet("{quizId}/questions")]
        public ActionResult<List<QuestionDto>> GetQuizQuestions([FromRoute] int quizId)
        {
            var questions = _quizService.GetQuestions(quizId);
            return Ok(questions);
        }
        [HttpPost("{quizId}/check")]
        public ActionResult<ScoreDto> CheckAnswers([FromRoute] int quizId, [FromBody] List<QuestionDto> dto)
        {
            var score = _quizService.CheckAnswers(dto, quizId);
            return Ok(score);

        }
        [HttpPut("questions/{questionId}")]
        public ActionResult UpdateQuestion([FromRoute]int questionId, [FromBody] QuestionDto dto)
        {
            _quizService.UpdateQuestion(questionId, dto);
            return Ok();
        }
        [HttpDelete("questions/{questionId}")]
        public ActionResult DeleteQuestion([FromRoute] int questionId)
        {
            _quizService.DeleteQuestion(questionId);
            return NoContent();
        }



        [HttpPost("{courseId}")]
        public ActionResult Create([FromRoute] int courseId, [FromBody] QuizDto quizDto)
        {
            int id= _quizService.Add(courseId, quizDto);
            return Created($"/api/quiz/{id}", null);
        }
        [HttpGet("{courseId}")]
        public ActionResult<List<QuizDto>> GetAll([FromRoute] int courseId)
        {
            var quiz = _quizService.GetAll(courseId);
            return Ok(quiz);
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

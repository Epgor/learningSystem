using Microsoft.AspNetCore.Mvc;
using learningSystem.Models;
using learningSystem.Services;
using Microsoft.AspNetCore.Authorization;
using learningSystem.Entities;

namespace learningSystem.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public ActionResult<List<ArticleDto>> GetAll([FromRoute] int id)
        {
            var article = _articleService.GetAll(id);
            return Ok(article);
        }

        [HttpGet("blocks/{id}")]
        public ActionResult<List<ArticleBlockDto>> GetBlocks([FromRoute] int id)
        {
            var article = _articleService.GetArticleBlocks(id);
            return Ok(article);
        }

        [HttpPost("{courseId}")]
        public ActionResult Create([FromRoute] int courseId, [FromBody] ArticleDto articleDto)
        {
            int id = _articleService.Add(courseId, articleDto);
            return Created($"/api/article/{id}", null);
        }

        [HttpPut("{articleId}")]
        public ActionResult Update([FromRoute] int articleId, [FromBody] ArticleDto articleDto)
        {
            _articleService.Update(articleId, articleDto);
            return Ok();
        }

        [HttpDelete("{articleId}")]
        public ActionResult Delete([FromRoute] int articleId)
        {
            _articleService.Delete(articleId);
            return NoContent();
        }
    }
}

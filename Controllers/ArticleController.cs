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

        [HttpPost("{courseId}")]
        public ActionResult Create([FromRoute] int courseId, [FromBody] ArticleDto articleDto)
        {
            int id = _articleService.Add(courseId, articleDto);
            return Created($"/api/article/{id}", null);
        }

        [HttpGet("{id}")]
        public ActionResult<List<ArticleDto>> GetAll([FromRoute] int id)
        {
            var article = _articleService.GetAll(id);
            return Ok(article);
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
        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="articleBlockDto"></param>
        /// <returns></returns>
        [HttpPost("blocks/{articleId}")]
        public ActionResult CreateBlock([FromRoute]int articleId, [FromBody] ArticleBlockDto articleBlockDto)
        {
            var block = _articleService.CreateBlock(articleId, articleBlockDto);
            return Created($"/api/article/{block}", null);
        }

        [HttpGet("blocks/{articleId}")]
        public ActionResult<List<ArticleBlockDto>> GetBlocks([FromRoute] int articleId)
        {
            var articleBlocks = _articleService.GetArticleBlocks(articleId);
            return Ok(articleBlocks);
        }

        [HttpPut("blocks")]
        public ActionResult UpdateBlock([FromBody] ArticleBlockDto articleBlockDto)
        {
            _articleService.UpdateBlock(articleBlockDto);
            return NoContent();
        }
        [HttpPatch("blocks")]
        public ActionResult MoveBlocks([FromBody] List<ArticleBlockDto> articleBlocks)
        {
            _articleService.MoveBlock(articleBlocks);
            return Ok();
        }

        [HttpDelete("blocks/{blockId}")]
        public ActionResult DeleteBlock([FromRoute] int blockId)
        {
            _articleService.DeleteBlock(blockId);
            return NoContent();
        }



    }
}

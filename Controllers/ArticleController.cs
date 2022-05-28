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
    }
}

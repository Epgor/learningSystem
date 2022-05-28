using AutoMapper;
using Microsoft.AspNetCore.Authorization;

using learningSystem.Exceptions;
using learningSystem.Entities;

namespace learningSystem.Services
{
    public interface IArticleService
    {
        public List<ArticleDto> GetAll(int id);
        public List<ArticleBlockDto> GetArticleBlocks(int articleId);

        public void Update(int id, ArticleDto articleDto);
        public void Delete(int id);
        public int Add(int courseId, ArticleDto articleDto);

    }

    public class ArticleService : IArticleService
    {
        private readonly LearningSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public ArticleService(LearningSystemDbContext dbContext, IMapper mapper,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Add(int courseId, ArticleDto articleDto)
        {
            if (articleDto is null)
                throw new BadRequestException("Got wrong input data, operation - CREATE Article");

            CourseMain course = _dbContext.CoursesMain.First(x => x.Id == courseId);

            if (course is null)
                throw new NotFoundException("Course with provided Id does not exist, operation - CREATE Article");

            Article article = new Article()
            {
                Text = articleDto.text,
                LearningType = articleDto.learningType,
                Course = course,
            };
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
            return article.Id;
        }

        public List<ArticleDto> GetAll(int courseId)
        {
            var articles = _dbContext
                .Articles
                .Where(x => x.CourseId == courseId)
                .ToList();

            if (articles is null)
                throw new NotFoundException("Content not found");

            var articlesDto = _mapper.Map<List<ArticleDto>>(articles); 

            return articlesDto;
        }
        
        public List<ArticleBlockDto> GetArticleBlocks(int articleId)
        {
            var blocks = _dbContext
                .ArticleBlocks
                .Where(x => x.ArticleId == articleId)
                .ToList();

            if (blocks is null)
                throw new NotFoundException("Content not found");

            var blocksDto = _mapper.Map<List<ArticleBlockDto>>(blocks);

            return blocksDto;
        }
        /// to check
        public void Delete(int id)
        {

            var article = _dbContext
                .Articles
                .FirstOrDefault(r => r.Id == id);

            if (article is null)
                throw new NotFoundException("Article not found");

            //authorize 
            var blocks = _dbContext
                .ArticleBlocks
                .Where(block => block.ArticleId == article.Id);

            if (blocks is not null)
                _dbContext.ArticleBlocks.RemoveRange(blocks);//delete blocks of that article

            _dbContext.Articles.Remove(article);//delete article         
            _dbContext.SaveChanges();
        }

        public void Update(int id, ArticleDto articleDto)
        {
            var article = _dbContext.Articles.FirstOrDefault(c => c.Id == id);

            if (article is null)
                throw new NotFoundException("Article Not Found");

            article.Text = articleDto.text;

            _dbContext.SaveChanges();
        }
    }
}

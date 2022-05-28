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

        //public void Update(int id, CourseMain mainObj);
        //public void Delete(int id);
        //public int Add(CourseMain mainObj);

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
        public void Delete(int id)
        {

            var course = _dbContext
                .CoursesMain
                .FirstOrDefault(r => r.Id == id);

            if (course is null)
                throw new NotFoundException("Course not found");

            //authorize 

            _dbContext.CoursesMain.Remove(course);
            _dbContext.SaveChanges();
        }

        public void Update(int id, CourseMain mainObj)
        {
            var course = _dbContext.CoursesMain.FirstOrDefault(c => c.Id == id);

            if (course is null)
                throw new NotFoundException("Course Not Found");

            course.Title = mainObj.Title;
            course.Desc = mainObj.Desc;

            _dbContext.SaveChanges();
        }
    }
}

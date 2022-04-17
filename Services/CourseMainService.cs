using AutoMapper;
using learningSystem.Entities;
using Microsoft.AspNetCore.Authorization;

namespace learningSystem.Services
{
    public interface ICourseMainService
    {
        public List<CourseMain> GetAll();
    }

    public class CourseMainService : ICourseMainService
    {
        private readonly LearningSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public CourseMainService(LearningSystemDbContext dbContext, IMapper mapper,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        public List<CourseMain> GetAll()
        {
            var courses = _dbContext
                .CoursesMain
                .ToList();

            return courses;
        }
    }
}

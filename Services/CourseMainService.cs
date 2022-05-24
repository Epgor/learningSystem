using AutoMapper;
using Microsoft.AspNetCore.Authorization;

using learningSystem.Exceptions;
using learningSystem.Entities;

namespace learningSystem.Services
{
    public interface ICourseMainService
    {
        public List<CourseMain> GetAll();
        public CourseMain Get(int id);
        public void Update(int id, CourseMain mainObj);
        public void Delete(int id);
        public int Add(CourseMain mainObj);

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

        public CourseMain Get(int id)
        {
            var course = _dbContext
                .CoursesMain
                .FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new NotFoundException("No Course");
            }
            return course;
        }
        //nooby code 
        public int Add(CourseMain mainObj) 
        {
            var course = _mapper.Map<Entities.CourseMain>(mainObj);
            _dbContext.Add(course);
            _dbContext.SaveChanges();
            return course.Id;
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

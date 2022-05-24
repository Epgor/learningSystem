using AutoMapper;
using Microsoft.AspNetCore.Authorization;

using learningSystem.Exceptions;
using learningSystem.Entities;

namespace learningSystem.Services
{
    public interface IQuizService
    {
        public List<QuizDto> GetAll(int id);
        public List<QuestionDto> GetQuestions(int quizId);
        public ScoreDto CheckAnswers(List<QuestionDto> Answers, int id);
        //public void Update(int id, CourseMain mainObj);
        //public void Delete(int id);
        //public int Add(CourseMain mainObj);

    }

    public class QuizService : IQuizService
    {
        private readonly LearningSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public QuizService(LearningSystemDbContext dbContext, IMapper mapper,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        public List<QuizDto> GetAll(int courseId)
        {
            var quizzes = _dbContext
                .Quizes
                .Where(x => x.CourseId == courseId)
                .ToList();

            var quizzesDto = _mapper.Map<List<QuizDto>>(quizzes); 

            return quizzesDto;
        }

        public List<QuestionDto> GetQuestions(int quizId)
        {
            var quiz = _dbContext
                .Quizes
                .FirstOrDefault(c => c.Id == quizId);
            if (quiz == null)
            {
                throw new NotFoundException("No Quiz");
            }
            List<Question> questions = _dbContext
                .Questions
                .Where(r => r.quiz == quiz)
                .ToList();

            if (questions == null)
            {
                throw new NotFoundException("No Questions");
            }

            List<QuestionDto> questionsDto = new List<QuestionDto>();
            //dodawanie pytań do quizu - ręczne mapowanie
            foreach(var question in questions)
            {
                if (question.Text is not null)
                {
                    QuestionDto tempQuestionDto = new QuestionDto();
                    tempQuestionDto.questionText = question.Text;

                    List<Answer> answers = _dbContext
                        .Answers
                        .Where(x => x.question == question)
                        .ToList();

                    if (answers != null)
                    {
                        List<AnswerDto> answersDto = new List<AnswerDto>();
                        //dodawanie odpowiedzi do pytania
                        foreach (var answer in answers)
                        {
                            if (answer.Text is not null)
                            {
                                AnswerDto tempAnswer = new AnswerDto();
                                tempAnswer.text = answer.Text;

                                answersDto.Add(tempAnswer);
                            }

                        }
                        tempQuestionDto.answers = answersDto;

                    }
                    questionsDto.Add(tempQuestionDto);
                }
            }
            
            //zwróć pytania z odpowiedziami
            return questionsDto;
        }
        //nooby code // to delete
        public ScoreDto CheckAnswers(List<QuestionDto> Answers, int id) 
        {
            //var course = _mapper.Map<Entities.CourseMain>(mainObj);
            ScoreDto score = new ScoreDto();
            var quiz = _dbContext
                .Quizes
                .FirstOrDefault(c => c.Id == id);
            if (quiz == null)
            {
                throw new NotFoundException("No Quiz");
            }
            List<Question> questions = _dbContext
                .Questions
                .Where(r => r.quiz == quiz)
                .ToList();


            foreach(var question in questions)
            {
                QuestionDto givenQuestion = Answers.Find(r => r.questionText == question.Text);
                if (givenQuestion == null)
                {
                    throw new BadRequestException("Incorrect format of Answers for that Question");
                }
                List<Answer> _answers = _dbContext
                    .Answers
                    .Where(x => x.question == question)
                    .ToList();

                foreach(var answer in _answers)
                {
                    AnswerDto givenAnswer = givenQuestion.answers.Find(r => r.text == answer.Text);
                    if (givenAnswer is null)
                        continue;

                    if (answer.IsCorrect)
                    {
                        if (givenAnswer.IsChecked == true)
                            score.score += 1;
                        score.maxScore += 1;
                        continue;
                    }
                    if (givenAnswer.IsChecked == true)
                        score.score -= 1;
                }
            }
            if (score.score < 0)
                score.score = 0;

            return score;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using learningSystem.Entities;

namespace learningSystem
{
    public class LearningSystemSeeder
    {
        private readonly LearningSystemDbContext _dbContext;

        public LearningSystemSeeder(LearningSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                /*
                if (!_dbContext.Users.Any())
                {
                    var accounts = GetAccounts();
                    _dbContext.Users.AddRange(accounts);
                    _dbContext.SaveChanges();
                }
                */
                if (!_dbContext.Tasks.Any())
                {
                    var taksk = GetTasks();
                    _dbContext.Tasks.AddRange(taksk);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.CoursesMain.Any())
                {
                    var courses = GetCourses();
                    _dbContext.CoursesMain.AddRange(courses);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Articles.Any())
                {
                    var articles = GetArticles();
                    _dbContext.Articles.AddRange(articles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Quizes.Any())
                {
                    var quizzes = GetQuizzes();
                    _dbContext.Quizes.AddRange(quizzes);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Questions.Any())
                {
                    var questions = GetQuestions();
                    _dbContext.Questions.AddRange(questions);
                    _dbContext.SaveChanges();
                }
                
                if (!_dbContext.Answers.Any())
                {
                    var answers = GetAnswers();
                    _dbContext.Answers.AddRange(answers);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.ArticleBlocks.Any())
                {
                    var blocks = GetBlocks();
                    _dbContext.ArticleBlocks.AddRange(blocks);
                    _dbContext.SaveChanges();
                }
                
            }
        }

        private IEnumerable<ArticleBlock> GetBlocks()
        {
            var blocks = new List<ArticleBlock>()
            {
                
                new ArticleBlock()
                {
                    title = "Pierwszy blok",
                    type = 1,
                    content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                    "Phasellus sed augue in lorem convallis suscipit vitae in odio." +
                    " Praesent facilisis venenatis nunc, et tincidunt tellus. " +
                    "Nullam a est eu erat euismod egestas. Aliquam molestie convallis mattis." +
                    " Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; " +
                    "Vivamus efficitur lectus sit amet neque commodo tristique. " +
                    "Sed massa libero, lobortis non dolor sed, egestas semper neque. " +
                    "Integer id massa vehicula est vestibulum laoreet.",
                    ArticleId = 1,
                },
                new ArticleBlock()
                {
                    title = "Drugi blok",
                    type =1,
                    content = "In lectus neque, viverra ut tempor quis, tincidunt id velit. " +
                    "Fusce mauris lorem, finibus a pulvinar sit amet, suscipit sed mauris." +
                    " Morbi faucibus diam diam, porta tempus diam auctor ac. Praesent ut tincidunt massa." +
                    " Aenean at mi ante. Nunc a odio malesuada, scelerisque velit eget, gravida elit." +
                    " Maecenas quam risus, consequat ac quam porta, fermentum faucibus eros. " +
                    "Maecenas ornare dolor erat, nec dapibus eros interdum sed.",
                    ArticleId = 1,
                },
                new ArticleBlock()
                {
                    title = "Trzeci blok",
                    type=1,
                    content = "Fusce bibendum suscipit odio. " +
                    "Integer ornare, nisi et viverra gravida, odio lacus posuere nisi, et sodales mauris nisi quis lacus." +
                    " Nulla vulputate massa blandit tellus bibendum consequat." +
                    " Morbi lorem enim, iaculis et scelerisque et, luctus congue turpis." +
                    " Duis nec lorem nec tellus vestibulum porttitor ac sed lacus." +
                    " Integer ligula orci, posuere sit amet mauris a, ullamcorper ullamcorper lectus." +
                    " Maecenas non quam felis.",
                    ArticleId = 1,
                },
                new ArticleBlock()
                {
                    title = "Foto blok",
                    type = 2,
                    content = "https://localhost:7038/image/image2.jpg",
                    ArticleId = 1,
                },
                new ArticleBlock()
                {
                    title = "Trzeci piąty",
                    type=1,
                    content = "Fusce bibendum suscipit odio. " +
                    "Integer ornare, nisi et viverra gravida, odio lacus posuere nisi, et sodales mauris nisi quis lacus." +
                    " Nulla vulputate massa blandit tellus bibendum consequat." +
                    " Morbi lorem enim, iaculis et scelerisque et, luctus congue turpis." +
                    " Duis nec lorem nec tellus vestibulum porttitor ac sed lacus." +
                    " Integer ligula orci, posuere sit amet mauris a, ullamcorper ullamcorper lectus." +
                    " Maecenas non quam felis.",
                    ArticleId = 1,
                },
                new ArticleBlock()
                {
                    title = "Foto blok",
                    type = 2,
                    content = "https://localhost:7038/image/image3.jpg",
                    ArticleId = 1,
                },
                new ArticleBlock()
                {
                    title = "Trzeci piąty",
                    type=1,
                    content = "Fusce bibendum suscipit odio. " +
                    "Integer ornare, nisi et viverra gravida, odio lacus posuere nisi, et sodales mauris nisi quis lacus." +
                    " Nulla vulputate massa blandit tellus bibendum consequat." +
                    " Maecenas non quam felis.",
                    ArticleId = 1,
                },
                
                new ArticleBlock()
                {
                    title = "Pdf blok",
                    type = 3,
                    content = "https://localhost:7038/file/111.pdf",
                    ArticleId = 1,
                },
            };
            return blocks;
        }

        private IEnumerable<Answer> GetAnswers()
        {
            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Text = "Dobra odpowiedz 1/1",
                    IsCorrect = true,
                    questionId = 1,
                },
                
                new Answer()
                {
                    Text = "Zla odpowiedz 1/2",
                    IsCorrect = false,
                    questionId = 1,
                },
                new Answer()
                {
                    Text = "Dobra odpowiedz 1/3",
                    IsCorrect = true,
                    questionId = 1,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 1/4",
                    IsCorrect = false,
                    questionId = 1,
                },
                new Answer()
                {
                    Text = "Dobra odpowiedz 1/5",
                    IsCorrect = true,
                    questionId = 1,
                },
                
                //pytanie 2
                 new Answer()
                {
                    Text = "Dobra odpowiedz 2/1",
                    IsCorrect = true,
                    questionId = 2,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 2/2",
                    IsCorrect = false,
                    questionId = 2,
                },
                new Answer()
                {
                    Text = "Dobra odpowiedz 2/3",
                    IsCorrect = true,
                    questionId = 2,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 2/4",
                    IsCorrect = false,
                    questionId = 2,
                },
                //pytanie 3
                new Answer()
                {
                    Text = "Dobra odpowiedz 3/1",
                    IsCorrect = true,
                    questionId = 3,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 3/2",
                    IsCorrect = false,
                    questionId = 3,
                },
                new Answer()
                {
                    Text = "Dobra odpowiedz 3/3",
                    IsCorrect = true,
                    questionId = 3,
                },
                //pytanie 4
                new Answer()
                {
                    Text = "Dobra odpowiedz 4/1",
                    IsCorrect = true,
                    questionId = 4,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 4/2",
                    IsCorrect = false,
                    questionId = 4,
                },
                //pytanie 5
                new Answer()
                {
                    Text = "Dobra odpowiedz 5/1",
                    IsCorrect = true,
                    questionId = 5,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 5/2",
                    IsCorrect = false,
                    questionId = 5,
                },
                //pytanie 1 css
                new Answer()
                {
                    Text = "Dobra odpowiedz 6/1",
                    IsCorrect = true,
                    questionId = 6,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 6/2",
                    IsCorrect = false,
                    questionId = 6,
                },
                //pytanie 2 css
                new Answer()
                {
                    Text = "Dobra odpowiedz 7/1",
                    IsCorrect = true,
                    questionId = 7,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 7/2",
                    IsCorrect = false,
                    questionId = 7,
                },
                //pytanie 3 css
                new Answer()
                {
                    Text = "Dobra odpowiedz 8/1",
                    IsCorrect = true,
                    questionId = 8,
                },
                new Answer()
                {
                    Text = "Zla odpowiedz 8/2",
                    IsCorrect = false,
                    questionId = 8,
                },
                
            };
            return answers;
        }

        private IEnumerable<Question> GetQuestions()
        {
            var questions = new List<Question>()
            {
                new Question()
                {
                    Text = "Pierwsze pytanie HTML q1",
                    quizId = 1, 
                },
                new Question()
                {
                    Text = "Drugie pytanie HTML q1",
                    quizId = 1,
                },
                new Question()
                {
                    Text = "Trzecie pytanie HTML q1",
                    quizId = 1,
                },
                new Question()
                {
                    Text = "Czwarte pytanie HTML q1",
                    quizId = 1,
                },
                new Question()
                {
                    Text = "Piąte pytanie HTML q1",
                    quizId = 1,
                },
                new Question()
                {
                    Text = "Pierwsze pytanie CSS q1",
                    quizId = 7,
                },
                new Question()
                {
                    Text = "Drugie pytanie CSS q1",
                    quizId = 7,
                },
                new Question()
                {
                    Text = "Trzecie pytanie CSS q1",
                    quizId = 7,
                },
            };
            return questions;
        }

        private IEnumerable<Quiz> GetQuizzes()
        {
            var quizzes = new List<Quiz>()
            {
                new Quiz()
                {
                    Text = "Mój Pierwszy Quiz HTML",
                    CourseId = 1,
                },
                new Quiz()
                {
                    Text = "Mój Drugi Quiz HTML",
                    CourseId = 1,
                },
                new Quiz()
                {
                    Text = "Mój trzeci Quiz HTML",
                    CourseId = 1,
                },
                new Quiz()
                {
                    Text = "Mój Pierwszy Quiz CSS",
                    CourseId = 2,
                },
                new Quiz()
                {
                    Text = "Mój Drugi Quiz CSS",
                    CourseId = 2,
                },


            };
            return quizzes;
        }

        private IEnumerable<Article> GetArticles()
        {
            var articles = new List<Article>()
            {
                /*
                new Article()
                {
                    Text = "Przykładowy tytuł lekcji ",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Przykładowy tytuł lekcji ",
                    CourseId = 2,
                },
                new Article()
                {
                    Text = "Przykładowy tytuł lekcji ",
                    CourseId = 3,
                    
                },
                */
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 2,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 2,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 2,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 2,
                },
                new Article()
                {
                    Text = "Lorem Ipsum, dolor est",
                    CourseId = 2,
                },
            };
            //var arti = _dbContext.Articles.Where(a => a.CourseId == 1 );//exampole linq
        return articles;
        }


        private IEnumerable<CourseMain> GetCourses()
        {
            var courses = new List<CourseMain>()
            {
                
                    


                
                new CourseMain()
                {
                    Title = "Wprowadzający HTML",
                    Desc = "Kurs wprowadzający w temat HTML", 
                    LogoURL = "",

                },
                new CourseMain()
                {
                   Title= "Wprowadzający CSS", Desc= "Kurs wprowadzający w temat CSS", LogoURL= "null"
                },
                new CourseMain()
                {  Title= "Wprowadzający JS", Desc= "Kurs wprowadzający w temat JavaScript", LogoURL= "null"},
                new CourseMain()
                {
                   Title= "Podstawy HTML", Desc= "Kurs rozwijający temat HTML", LogoURL= "null"
                },
                new CourseMain()
                {
                   Title= "Podstawy CSS", Desc= "Kurs rozwijający temat CSS", LogoURL= "null"
                },
                new CourseMain() { Title= "Podstawy JS", Desc= "Kurs rozwijający temat JavaScript", LogoURL= "null"},
                new CourseMain() { Title= "Podstawy cz.2 HTML", Desc= "Kurs rozwijający temat HTML", LogoURL= "null"},
                new CourseMain() { Title= "Podstawy cz.2 CSS", Desc= "Kurs rozwijający temat CSS", LogoURL= "null"},
                new CourseMain() { Title= "Podstawy cz.2 JS", Desc= "Kurs rozwijający temat JavaScript", LogoURL= "null"},
                new CourseMain() { Title= "Zaawansowany HTML", Desc= "Kurs rozwijający wiedzę z zakresu HTML", LogoURL= "null"},
                new CourseMain() { Title= "Zaawansowany CSS", Desc= "Kurs rozwijający wiedzę z zakresu CSS", LogoURL= "null"},
                new CourseMain() { Title= "Zaawansowany JS", Desc= "Kurs rozwijający wiedzę z zakresu JavaScript", LogoURL= "null"},
                new CourseMain() { Title= "Node.js", Desc= "Kurs wprowadzający w temat Node.js", LogoURL= "null"},
                new CourseMain() { Title= "Npm", Desc= "Kurs wprowadzający w temat Npm", LogoURL= "null"},
                new CourseMain() { Title= "Frameworki JS", Desc= "Kurs wprowadzający w temat Frameworków JS", LogoURL= "null"},
                new CourseMain() { Title= "Angular", Desc= "Kurs wprowadzający w temat frameworku Angular", LogoURL= "null"},
            };
            return courses;
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Teacher"
            },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }

        private IEnumerable<User> GetAccounts()
        {
            var accounts = new List<User>()
            {
                new User()
                {
                    Name = "Admin",
                    Email = "admin@local.com",
                    DateOfBirth = DateTime.Now.AddYears(30),
                    PasswordHash = "P@ssword12",
                    RoleId = 3
                },
                new User()
                {
                    Name = "User",
                    Email = "user@somepage.com",
                    DateOfBirth = DateTime.Now.AddYears(25),
                    PasswordHash= "P@ssword12",
                    RoleId = 1
                }

            };
            return accounts;

        }

        private IEnumerable<Entities.Task> GetTasks()
        {
            var tasks = new List<Entities.Task>()
            {
                new Entities.Task()
                {
                    Name = "First",
                    Description = "Not Important",
                    Reminder = false,
                    CreatorId = 1,
                },
                new Entities.Task()
                {
                    Name = "Second",
                    Description = "Important",
                    Reminder = true,
                    CreatorId = 1,
                },
                new Entities.Task()
                {
                    Name = "Third",
                    Description = "Not Important",
                    Reminder = true,
                    CreatorId = 1,
                }
            };
            return tasks;
        }
    }
}

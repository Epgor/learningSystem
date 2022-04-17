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
                if (!_dbContext.CoursesDetail.Any())
                {
                    var courses = GetCourseDetails();
                    _dbContext.CoursesDetail.AddRange(courses);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Articles.Any())
                {
                    var articles = GetArticles();
                    _dbContext.Articles.AddRange(articles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Article> GetArticles()
        {
            var articles = new List<Article>()
            {
                new Article()
                {
                    Text = "Jestem tekstem dla wzorkowca",
                    CourseId = 1,
                },
                new Article()
                {
                    Text = "Jestem tekstem dla słuchowca",
                    CourseId = 2,
                },
                new Article()
                {
                    Text = "Jestem tekstem dla działaniowca",
                    CourseId = 3,
                    
                },
                
            };
            //var arti = _dbContext.Articles.Where(a => a.CourseId == 1 );//exampole linq
        return articles;
        }

        private IEnumerable<CourseDetail> GetCourseDetails()
        {
            var courseDetails = new List<CourseDetail>() 
            {
                new CourseDetail()
                {
                    Text = "Jestem Wzrokowcem"
                },
                new CourseDetail()
                {
                    Text = "Jestem Słuchowcem"
                },
                new CourseDetail()
                {
                    Text = "Jestem Działaniowcem"
                }
            };
            return courseDetails;

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

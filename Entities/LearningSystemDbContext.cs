using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace learningSystem.Entities
{
    public class LearningSystemDbContext : DbContext
    {
        //local db
        private string _connectionString =
            "Server=(LocalDB)\\MSSQLLocalDB;Database=LearningServiceDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<CourseDetail> CoursesDetail {  get; set; }
        public DbSet<CourseMain> CoursesMain { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CourseFile> CourseFiles { get; set; }

        public DbSet<ArticleBlock> ArticleBlocks { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Role>()
                    .Property(x => x.Name)
                    .IsRequired();

                modelBuilder.Entity<User>()
                    .Property(x => x.Email)
                    .IsRequired();

                modelBuilder.Entity<Task>()
                    .Property(x => x.Name)
                    .IsRequired();

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
}
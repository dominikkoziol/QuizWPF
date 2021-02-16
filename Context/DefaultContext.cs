using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quiz.Context
{
    public class DefaultContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlitePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"QuizDb.db");
            optionsBuilder.UseSqlite(@"Data Source=" + sqlitePath);
        }
    }
}

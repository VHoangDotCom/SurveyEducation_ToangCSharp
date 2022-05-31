using SurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SurveyAPI.Data
{
    public class DBConnection : DbContext
    {
        public DBConnection() : base("name=SurveyDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSurvey> UserSurveys { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerSubmit> Answers { get; set; }
        public DbSet<OptionQuestion> OptionQuestions { get; set; }
        public DbSet<TextAnswer> TextAnswers { get; set; }

    }
}
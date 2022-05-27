using EducationSurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationSurveyAPI.Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=SchoolContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
    }
}
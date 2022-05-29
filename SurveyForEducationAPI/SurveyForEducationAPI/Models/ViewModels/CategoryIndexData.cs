using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyForEducationAPI.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Survey> Surveys { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAPI.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string Required { get; set; }

        //Foreign key
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }

        public ICollection<OptionQuestion> OptionQuestions { get; set; }
        public ICollection<AnswerSubmit> AnswerSubmits { get; set; }

        public Question()
        {
            this.QuestionText = "";
            this.Required = "";
            this.OptionQuestions = new HashSet<OptionQuestion>();
            this.AnswerSubmits = new HashSet<AnswerSubmit>();
        }

    }
}
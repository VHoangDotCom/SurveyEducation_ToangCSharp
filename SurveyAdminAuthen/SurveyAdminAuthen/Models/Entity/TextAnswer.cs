using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAdminAuthen.Models.Entity
{
    public class TextAnswer
    {
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        //Foreign key
        public int AnswerSubmitID { get; set; }
        public AnswerSubmit AnswerSubmit { get; set; }

        public TextAnswer()
        {
            this.Question = "";
            this.Answer = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAPIAuthen.Models
{
    public class AnswerSubmit
    {
        [Key]
        public int ID { get; set; }

        //Foreign key
        public int QuestionID { get; set; }
        public virtual Survey Survey { get; set; }

        public ICollection<TextAnswer> TextAnswers { get; set; }

        public AnswerSubmit()
        {
            this.TextAnswers = new HashSet<TextAnswer>();
        }
    }
}
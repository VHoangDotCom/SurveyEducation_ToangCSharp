using SurveyForEducationAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyForEducationAPI.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayFormat(NullDisplayText = "Status not set")]
        public Status? Status { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Question()
        {

        }
        public Question(QuestionViewModel qv)
        {
            this.Id = qv.ID;
            this.Title = qv.Title;
        }
    }
}
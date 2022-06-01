using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAdminAuthen.Models.Entity
{
    public enum Status
    {
        pending, being_used, reported, deleted
    }
    public class Survey
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime EndDate { get; set; }

        [DisplayFormat(NullDisplayText = "Status not set")]
        public Status? Status { get; set; }

        //Foreign key
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<UserSurvey> UserSurveys { get; set; }
        public ICollection<AnswerSubmit> AnswerSubmits { get; set; }

        public Survey()
        {
            this.Title = "";
            this.Description = "";
            this.CreatedAt = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.Questions = new HashSet<Question>();
            this.UserSurveys = new HashSet<UserSurvey>();
            this.AnswerSubmits = new HashSet<AnswerSubmit>();
        }
    }
}
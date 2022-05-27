using SurveyForEducationAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyForEducationAPI.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [DisplayFormat(NullDisplayText = "Status not set")]
        public Status? Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Survey()
        {

        }
        public Survey(SurveyViewModel svm)
        {
            this.Id = svm.ID;
            this.Title = svm.Title;
        }
    }
}
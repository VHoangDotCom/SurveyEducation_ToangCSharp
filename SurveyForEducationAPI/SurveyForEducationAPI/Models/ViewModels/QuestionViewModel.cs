using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyForEducationAPI.Models.ViewModels
{
    public class QuestionViewModel
    {
        //ID
        [Display(Name = "Question ID")]
        public int ID { get; set; }

        //LastName
        [DisplayName("Question title")]
        [Required(ErrorMessage = "Please enter title !")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "The length is between 2 and 200 characters ! !")]
        public string Title { get; set; }

        public QuestionViewModel()
        {

        }
        public QuestionViewModel(Question qs)
        {
            this.ID = qs.Id;
            this.Title = qs.Title;
        }
    }
}
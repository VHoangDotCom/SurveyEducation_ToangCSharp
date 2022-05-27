using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationSurveyAPI.Models.ViewModels
{
    public class SurveyViewModel
    {
        //ID
        [Display(Name = "Survey ID")]
        public int ID { get; set; }

        [DisplayName("Survey title")]
        [Required(ErrorMessage = "Please enter Survey title !")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "The length is between 2 and 300 characters ! !")]
        public string Title { get; set; }

        public SurveyViewModel()
        {

        }
        public SurveyViewModel(Survey sr)
        {
            this.ID = sr.Id;
            this.Title = sr.Title;
        }
    }
}
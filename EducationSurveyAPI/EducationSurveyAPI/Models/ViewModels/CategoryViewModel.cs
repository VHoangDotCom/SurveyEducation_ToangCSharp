using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationSurveyAPI.Models.ViewModels
{
    public class CategoryViewModel
    {
        //ID
        [Display(Name = "Category ID")]
        public int ID { get; set; }

        //LastName
        [DisplayName("Category name")]
        [Required(ErrorMessage = "Please enter Category name !")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "The length is between 1 and 50 characters !")]
        public string Name { get; set; }

        public CategoryViewModel()
        {

        }

        public CategoryViewModel(Category cate)
        {
            this.ID = cate.Id;
            this.Name = cate.Name;
        }

    }
}
using SurveyForEducationAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyForEducationAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

        public Category()
        {

        }

        public Category(CategoryViewModel catevm)
        {
            this.Id = catevm.ID;
            this.Name = catevm.Name;
        }
    }
}
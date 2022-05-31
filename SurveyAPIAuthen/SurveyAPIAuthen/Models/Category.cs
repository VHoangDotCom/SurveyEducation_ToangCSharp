using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAPIAuthen.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Survey> Surveys { get; set; }

        public Category()
        {
            this.Name = "";
            this.Surveys = new HashSet<Survey>();
        }
    }
}
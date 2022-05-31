using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAPI.Models
{
    public class OptionQuestion
    {
        [Key]
        public int ID { get; set; }
        public string OptionType { get; set; }

        //Foreign key
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        public OptionQuestion()
        {
            this.OptionType = "";

        }
    }
}
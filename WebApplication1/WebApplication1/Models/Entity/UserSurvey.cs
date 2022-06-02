using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entity
{
    public class UserSurvey
    {
        [Key]
        public int ID { get; set; }

        //foreign key
        public int ApplicationUserID { get; set; }
        public int SurveyID { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public UserSurvey()
        {

        }
    }
}
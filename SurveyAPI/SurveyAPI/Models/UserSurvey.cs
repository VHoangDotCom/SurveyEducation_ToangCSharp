using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAPI.Models
{
    public class UserSurvey
    {
        [Key]
        public int ID { get; set; }

        //foreign key
        public int UserID { get; set; }
        public int SurveyID { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual User User { get; set; }

        public UserSurvey()
        {

        }
    }
}
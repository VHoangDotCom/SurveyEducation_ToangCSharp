using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public string Status { get; set; }

        public ICollection<UserSurvey> UserSurveys { get; set; }

        public User()
        {
            this.Username = "";
            this.Email = "";
            this.PhoneNumber = "";
            this.Role = 1;
            this.Status = "";
            this.UserSurveys = new HashSet<UserSurvey>();
        }
    }
}
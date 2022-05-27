using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyForEducationAPI.Models
{
    public enum Type
    {
        radio, text, checkbox
    }

    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

        [DisplayFormat(NullDisplayText = "Type not set")]
        public Type? Type { get; set; }

        [DisplayFormat(NullDisplayText = "Status not set")]
        public Status? Status { get; set; }

        public virtual Question Question { get; set; }
    }
}
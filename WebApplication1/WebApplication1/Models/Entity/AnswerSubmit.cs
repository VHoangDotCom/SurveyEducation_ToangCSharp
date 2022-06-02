﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entity
{
    public class AnswerSubmit
    {
        [Key]
        public int ID { get; set; }

        //Foreign key
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }

        public ICollection<TextAnswer> TextAnswers { get; set; }

        public AnswerSubmit()
        {
            this.TextAnswers = new HashSet<TextAnswer>();
        }
    }
}
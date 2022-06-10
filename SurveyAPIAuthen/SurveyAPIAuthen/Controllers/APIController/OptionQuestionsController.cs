using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SurveyAPIAuthen.Models;

namespace SurveyAPIAuthen.Controllers.APIController
{
    public class OptionQuestionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/OptionQuestions
        public IQueryable<OptionQuestion> GetOptionQuestions()
        {
            return db.OptionQuestions;
        }

        // GET: api/OptionQuestions/5
        [ResponseType(typeof(OptionQuestion))]
        public IHttpActionResult GetOptionQuestion(int id)
        {
            OptionQuestion optionQuestion = db.OptionQuestions.Find(id);
            if (optionQuestion == null)
            {
                return NotFound();
            }

            return Ok(optionQuestion);
        }

        // PUT: api/OptionQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOptionQuestion(int id, OptionQuestion optionQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != optionQuestion.ID)
            {
                return BadRequest();
            }

            db.Entry(optionQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OptionQuestions
        [ResponseType(typeof(OptionQuestion))]
        public IHttpActionResult PostOptionQuestion(OptionQuestion optionQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OptionQuestions.Add(optionQuestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = optionQuestion.ID }, optionQuestion);
        }

        // DELETE: api/OptionQuestions/5
        [ResponseType(typeof(OptionQuestion))]
        public IHttpActionResult DeleteOptionQuestion(int id)
        {
            OptionQuestion optionQuestion = db.OptionQuestions.Find(id);
            if (optionQuestion == null)
            {
                return NotFound();
            }

            db.OptionQuestions.Remove(optionQuestion);
            db.SaveChanges();

            return Ok(optionQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OptionQuestionExists(int id)
        {
            return db.OptionQuestions.Count(e => e.ID == id) > 0;
        }
    }
}
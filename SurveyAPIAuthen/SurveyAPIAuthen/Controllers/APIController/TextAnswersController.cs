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
    public class TextAnswersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TextAnswers
        public IQueryable<TextAnswer> GetTextAnswers()
        {
            return db.TextAnswers;
        }

        // GET: api/TextAnswers/5
        [ResponseType(typeof(TextAnswer))]
        public IHttpActionResult GetTextAnswer(int id)
        {
            TextAnswer textAnswer = db.TextAnswers.Find(id);
            if (textAnswer == null)
            {
                return NotFound();
            }

            return Ok(textAnswer);
        }

        // PUT: api/TextAnswers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTextAnswer(int id, TextAnswer textAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != textAnswer.ID)
            {
                return BadRequest();
            }

            db.Entry(textAnswer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextAnswerExists(id))
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

        // POST: api/TextAnswers
        [ResponseType(typeof(TextAnswer))]
        public IHttpActionResult PostTextAnswer(TextAnswer textAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TextAnswers.Add(textAnswer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = textAnswer.ID }, textAnswer);
        }

        // DELETE: api/TextAnswers/5
        [ResponseType(typeof(TextAnswer))]
        public IHttpActionResult DeleteTextAnswer(int id)
        {
            TextAnswer textAnswer = db.TextAnswers.Find(id);
            if (textAnswer == null)
            {
                return NotFound();
            }

            db.TextAnswers.Remove(textAnswer);
            db.SaveChanges();

            return Ok(textAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TextAnswerExists(int id)
        {
            return db.TextAnswers.Count(e => e.ID == id) > 0;
        }
    }
}
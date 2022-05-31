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
    public class AnswerSubmitsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AnswerSubmits
        public IQueryable<AnswerSubmit> GetAnswers()
        {
            return db.Answers;
        }

        // GET: api/AnswerSubmits/5
        [ResponseType(typeof(AnswerSubmit))]
        public IHttpActionResult GetAnswerSubmit(int id)
        {
            AnswerSubmit answerSubmit = db.Answers.Find(id);
            if (answerSubmit == null)
            {
                return NotFound();
            }

            return Ok(answerSubmit);
        }

        // PUT: api/AnswerSubmits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnswerSubmit(int id, AnswerSubmit answerSubmit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerSubmit.ID)
            {
                return BadRequest();
            }

            db.Entry(answerSubmit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerSubmitExists(id))
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

        // POST: api/AnswerSubmits
        [ResponseType(typeof(AnswerSubmit))]
        public IHttpActionResult PostAnswerSubmit(AnswerSubmit answerSubmit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Answers.Add(answerSubmit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = answerSubmit.ID }, answerSubmit);
        }

        // DELETE: api/AnswerSubmits/5
        [ResponseType(typeof(AnswerSubmit))]
        public IHttpActionResult DeleteAnswerSubmit(int id)
        {
            AnswerSubmit answerSubmit = db.Answers.Find(id);
            if (answerSubmit == null)
            {
                return NotFound();
            }

            db.Answers.Remove(answerSubmit);
            db.SaveChanges();

            return Ok(answerSubmit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerSubmitExists(int id)
        {
            return db.Answers.Count(e => e.ID == id) > 0;
        }
    }
}
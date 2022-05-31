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
    public class UserSurveysController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserSurveys
        public IQueryable<UserSurvey> GetUserSurveys()
        {
            return db.UserSurveys;
        }

        // GET: api/UserSurveys/5
        [ResponseType(typeof(UserSurvey))]
        public IHttpActionResult GetUserSurvey(int id)
        {
            UserSurvey userSurvey = db.UserSurveys.Find(id);
            if (userSurvey == null)
            {
                return NotFound();
            }

            return Ok(userSurvey);
        }

        // PUT: api/UserSurveys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserSurvey(int id, UserSurvey userSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSurvey.ID)
            {
                return BadRequest();
            }

            db.Entry(userSurvey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSurveyExists(id))
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

        // POST: api/UserSurveys
        [ResponseType(typeof(UserSurvey))]
        public IHttpActionResult PostUserSurvey(UserSurvey userSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserSurveys.Add(userSurvey);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userSurvey.ID }, userSurvey);
        }

        // DELETE: api/UserSurveys/5
        [ResponseType(typeof(UserSurvey))]
        public IHttpActionResult DeleteUserSurvey(int id)
        {
            UserSurvey userSurvey = db.UserSurveys.Find(id);
            if (userSurvey == null)
            {
                return NotFound();
            }

            db.UserSurveys.Remove(userSurvey);
            db.SaveChanges();

            return Ok(userSurvey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserSurveyExists(int id)
        {
            return db.UserSurveys.Count(e => e.ID == id) > 0;
        }
    }
}
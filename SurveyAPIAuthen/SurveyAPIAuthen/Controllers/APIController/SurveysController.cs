using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SurveyAPIAuthen.Models;

namespace SurveyAPIAuthen.Controllers.APIController
{
    public class SurveysController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Surveys
        public IQueryable<Survey> GetSurveys()
        {
            return db.Surveys;
        }

        // GET: api/Surveys/5
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> GetSurvey(int id)
        {
            Survey surveyOne = db.Surveys.Find(id);
           var datajoin = await db.Surveys.Where(s => s.ID == id)
                .Join(
                db.Questions, 
                survey => survey.ID,
                question => question.SurveyID,
                (survey, question)=> new {
                    ID = question.ID,
                    SurveyID = question.SurveyID,
                    QuestionText = question.QuestionText,
                    QuestionType = question.QuestionType
                }
                ).ToListAsync();


            return Ok(new{ survey= surveyOne, questions= datajoin });
        }

        [HttpGet]
        [Route("api/Surveys/questionId/{id}")]
        public async Task<IHttpActionResult> GetSurveyQuestionId(int id)
        {
           Survey surveyOne = db.Surveys.Find(id);

            var datajoin_v1 = await db.Surveys.Where(s => s.ID == id)
                .Join(
                db.Questions,
                survey => survey.ID,
                question => question.SurveyID,
                (survey, question) => new {
                    ID = question.ID,
                    Question = question.QuestionText
                }).ToListAsync();

            return Ok(new { survey = surveyOne, questions = datajoin_v1});

           
        }


        // PUT: api/Surveys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSurvey(int id, Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.ID)
            {
                return BadRequest();
            }

            db.Entry(survey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(id))
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

        // POST: api/Surveys
        [ResponseType(typeof(Survey))]
        public IHttpActionResult PostSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Surveys.Add(survey);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = survey.ID }, survey);
        }

        // DELETE: api/Surveys/5
        [ResponseType(typeof(Survey))]
        public IHttpActionResult DeleteSurvey(int id)
        {
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return NotFound();
            }

            db.Surveys.Remove(survey);
            db.SaveChanges();

            return Ok(survey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyExists(int id)
        {
            return db.Surveys.Count(e => e.ID == id) > 0;
        }
    }
}
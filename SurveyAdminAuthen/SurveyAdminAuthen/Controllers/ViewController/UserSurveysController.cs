using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyAdminAuthen.Models;
using SurveyAdminAuthen.Models.Entity;

namespace SurveyAdminAuthen.Controllers.ViewController
{
    public class UserSurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserSurveys
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userSurveys = db.UserSurveys.Include(u => u.Survey);
            return View(userSurveys.ToList());
        }

        // GET: UserSurveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSurvey userSurvey = db.UserSurveys.Find(id);
            if (userSurvey == null)
            {
                return HttpNotFound();
            }
            return View(userSurvey);
        }

        // GET: UserSurveys/Create
        public ActionResult Create()
        {
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title");
            return View();
        }

        // POST: UserSurveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,SurveyID")] UserSurvey userSurvey)
        {
            if (ModelState.IsValid)
            {
                db.UserSurveys.Add(userSurvey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title", userSurvey.SurveyID);
            return View(userSurvey);
        }

        // GET: UserSurveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSurvey userSurvey = db.UserSurveys.Find(id);
            if (userSurvey == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title", userSurvey.SurveyID);
            return View(userSurvey);
        }

        // POST: UserSurveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,SurveyID")] UserSurvey userSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSurvey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title", userSurvey.SurveyID);
            return View(userSurvey);
        }

        // GET: UserSurveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSurvey userSurvey = db.UserSurveys.Find(id);
            if (userSurvey == null)
            {
                return HttpNotFound();
            }
            return View(userSurvey);
        }

        // POST: UserSurveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserSurvey userSurvey = db.UserSurveys.Find(id);
            db.UserSurveys.Remove(userSurvey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

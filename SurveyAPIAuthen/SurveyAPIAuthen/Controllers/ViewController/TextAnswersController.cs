using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyAPIAuthen.Models;

namespace SurveyAPIAuthen.Controllers.ViewController
{
    public class TextAnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TextAnswers
        public ActionResult Index()
        {
            var textAnswers = db.TextAnswers.Include(t => t.AnswerSubmit);
            return View(textAnswers.ToList());
        }

        // GET: TextAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAnswer textAnswer = db.TextAnswers.Find(id);
            if (textAnswer == null)
            {
                return HttpNotFound();
            }
            return View(textAnswer);
        }

        // GET: TextAnswers/Create
        public ActionResult Create()
        {
            ViewBag.AnswerSubmitID = new SelectList(db.Answers, "ID", "ID");
            return View();
        }

        // POST: TextAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Question,Answer,AnswerSubmitID")] TextAnswer textAnswer)
        {
            if (ModelState.IsValid)
            {
                db.TextAnswers.Add(textAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnswerSubmitID = new SelectList(db.Answers, "ID", "ID", textAnswer.AnswerSubmitID);
            return View(textAnswer);
        }

        // GET: TextAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAnswer textAnswer = db.TextAnswers.Find(id);
            if (textAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerSubmitID = new SelectList(db.Answers, "ID", "ID", textAnswer.AnswerSubmitID);
            return View(textAnswer);
        }

        // POST: TextAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Question,Answer,AnswerSubmitID")] TextAnswer textAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerSubmitID = new SelectList(db.Answers, "ID", "ID", textAnswer.AnswerSubmitID);
            return View(textAnswer);
        }

        // GET: TextAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAnswer textAnswer = db.TextAnswers.Find(id);
            if (textAnswer == null)
            {
                return HttpNotFound();
            }
            return View(textAnswer);
        }

        // POST: TextAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextAnswer textAnswer = db.TextAnswers.Find(id);
            db.TextAnswers.Remove(textAnswer);
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

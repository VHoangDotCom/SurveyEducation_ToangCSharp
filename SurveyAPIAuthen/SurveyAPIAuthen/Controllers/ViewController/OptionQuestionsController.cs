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
    public class OptionQuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OptionQuestions
        public ActionResult Index()
        {
            var optionQuestions = db.OptionQuestions.Include(o => o.Question);
            return View(optionQuestions.ToList());
        }

        // GET: OptionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionQuestion optionQuestion = db.OptionQuestions.Find(id);
            if (optionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(optionQuestion);
        }

        // GET: OptionQuestions/Create
        public ActionResult Create()
        {
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "QuestionText");
            return View();
        }

        // POST: OptionQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OptionText,QuestionID")] OptionQuestion optionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.OptionQuestions.Add(optionQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "QuestionText", optionQuestion.QuestionID);
            return View(optionQuestion);
        }

        // GET: OptionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionQuestion optionQuestion = db.OptionQuestions.Find(id);
            if (optionQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "QuestionText", optionQuestion.QuestionID);
            return View(optionQuestion);
        }

        // POST: OptionQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OptionText,QuestionID")] OptionQuestion optionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "ID", "QuestionText", optionQuestion.QuestionID);
            return View(optionQuestion);
        }

        // GET: OptionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionQuestion optionQuestion = db.OptionQuestions.Find(id);
            if (optionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(optionQuestion);
        }

        // POST: OptionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionQuestion optionQuestion = db.OptionQuestions.Find(id);
            db.OptionQuestions.Remove(optionQuestion);
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

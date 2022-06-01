﻿using System;
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
    public class AnswerSubmitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnswerSubmits
        public ActionResult Index()
        {
            return View(db.Answers.ToList());
        }

        // GET: AnswerSubmits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerSubmit answerSubmit = db.Answers.Find(id);
            if (answerSubmit == null)
            {
                return HttpNotFound();
            }
            return View(answerSubmit);
        }

        // GET: AnswerSubmits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnswerSubmits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuestionID")] AnswerSubmit answerSubmit)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answerSubmit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(answerSubmit);
        }

        // GET: AnswerSubmits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerSubmit answerSubmit = db.Answers.Find(id);
            if (answerSubmit == null)
            {
                return HttpNotFound();
            }
            return View(answerSubmit);
        }

        // POST: AnswerSubmits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuestionID")] AnswerSubmit answerSubmit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerSubmit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(answerSubmit);
        }

        // GET: AnswerSubmits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerSubmit answerSubmit = db.Answers.Find(id);
            if (answerSubmit == null)
            {
                return HttpNotFound();
            }
            return View(answerSubmit);
        }

        // POST: AnswerSubmits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerSubmit answerSubmit = db.Answers.Find(id);
            db.Answers.Remove(answerSubmit);
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

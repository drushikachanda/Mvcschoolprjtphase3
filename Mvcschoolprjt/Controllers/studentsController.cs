﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvcschoolprjt;

namespace Mvcschoolprjt.Controllers
{
    public class studentsController : Controller
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: students
        public ActionResult Index()
        {
            var students = db.students.Include(s => s.Class1).Include(s => s.Subject);
            return View(students.ToList());
        }

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Class1, "classId", "className");
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentId,StudentName,TeacherName,ClassId,SubjectID")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Class1, "classId", "className", student.ClassId);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", student.SubjectID);
            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Class1, "classId", "className", student.ClassId);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", student.SubjectID);
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,StudentName,TeacherName,ClassId,SubjectID")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Class1, "classId", "className", student.ClassId);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", student.SubjectID);
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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

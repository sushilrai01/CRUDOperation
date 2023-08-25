using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDOperation.Models;

namespace CRUDOperation.Controllers
{
    public class STDxController : Controller
    {
        private TestStudentxxlEntities1 db = new TestStudentxxlEntities1();

        // GET: STDx
        public ActionResult Index()
        {
            var studentDetails = db.StudentDetails.Include(s => s.ClassDetail);
            return View(studentDetails.OrderBy(s => s.Id).ToList());
        }

        // GET: STDx/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            return View(studentDetail);
        }

        // GET: STDx/Create
        public ActionResult Create()
        {
            ViewBag.Grade = new SelectList(db.ClassDetails, "Class", "Teacher");
            return View();
        }

        // POST: STDx/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Grade")] StudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                db.StudentDetails.Add(studentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Grade = new SelectList(db.ClassDetails, "Class", "Teacher", studentDetail.Grade);
            return View(studentDetail);
        }

        // GET: STDx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Grade = new SelectList(db.ClassDetails, "Class", "Teacher", studentDetail.Grade);
            return View(studentDetail);
        }

        // POST: STDx/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Grade")] StudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grade = new SelectList(db.ClassDetails, "Class", "Teacher", studentDetail.Grade);
            return View(studentDetail);
        }

        // GET: STDx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            return View(studentDetail);
        }

        // POST: STDx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            db.StudentDetails.Remove(studentDetail);
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

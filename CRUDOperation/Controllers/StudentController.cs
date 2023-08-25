using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using CRUDOperation.Models;


namespace CRUDOperation.Controllers
{
    public class StudentController : Controller
    {
        private TestStudentxxlEntities1 db = new TestStudentxxlEntities1();
        // GET: Student
        public ActionResult Index()
        {
            var studentDetails = db.StudentDetails.Include(s => s.ClassDetail);
            return View(studentDetails.OrderBy(std => std.Id).ToList());
        }

        // GET: Student/Details/id
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetail studentDetail = db.StudentDetails.Find(id);
            if(studentDetail == null)
            {
                return HttpNotFound();
            }
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

    }
}
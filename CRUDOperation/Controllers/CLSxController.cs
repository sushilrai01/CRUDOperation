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
    public class CLSxController : Controller
    {
        private TestStudentxxlEntities1 db = new TestStudentxxlEntities1();

        // GET: CLSx
        public ActionResult Index()
        {
            return View(db.ClassDetails.ToList());
        }

        // GET: CLSx/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetail classDetail = db.ClassDetails.Find(id);
            if (classDetail == null)
            {
                return HttpNotFound();
            }
            return View(classDetail);
        }

        // GET: CLSx/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLSx/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Class,Teacher,Total")] ClassDetail classDetail)
        {
            if (ModelState.IsValid)
            {
                db.ClassDetails.Add(classDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classDetail);
        }

        // GET: CLSx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetail classDetail = db.ClassDetails.Find(id);
            if (classDetail == null)
            {
                return HttpNotFound();
            }
            return View(classDetail);
        }

        // POST: CLSx/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Class,Teacher,Total")] ClassDetail classDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classDetail);
        }

        // GET: CLSx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetail classDetail = db.ClassDetails.Find(id);
            if (classDetail == null)
            {
                return HttpNotFound();
            }
            return View(classDetail);
        }

        // POST: CLSx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassDetail classDetail = db.ClassDetails.Find(id);
            db.ClassDetails.Remove(classDetail);
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

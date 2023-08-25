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
    public class XstudentController : Controller
    {
        private TestStudentxxlEntities1 db = new TestStudentxxlEntities1();
        // GET: Combine
        public  ActionResult Index()
        {
            var customData = from studentDetail in db.StudentDetails
                             join classDetail in db.ClassDetails on studentDetail.Grade equals classDetail.Class
                             join genderDetail in db.GenderDetails on studentDetail.gender equals genderDetail.Gid
                             select new StudentInfoModel
                             {
                               Id = studentDetail.Id,
                               Name = studentDetail.Name,
                               Gender  = genderDetail.Gender,
                               Class = studentDetail.Grade,
                               Teacher = classDetail.Teacher,
                               Total = (int)classDetail.Total,
                             };

            //var Xabc = db.ClassDetails.Where(x => x.Class == 112).Select(x => new StudentInfoModel
            //{
            //    Gender=x.Total.ToString(),
            //});

            //StudentInfoModel studentInfo = new StudentInfoModel();

            //Console.WriteLine(studentInfo.Id);

            return View(customData.ToList()) ;
            //return View();
        }
    }
}
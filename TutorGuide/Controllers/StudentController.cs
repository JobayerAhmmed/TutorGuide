using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;
using TutorGuide.Repository;

namespace TutorGuide.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(StudentProfile student)
        {
            _dbContext.StudentProfiles.Add(student);
            _dbContext.SaveChanges();
             
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SearchTutor()
        {
            return View();
        }

        public JsonResult GetAllTutor()
        {
            var tutors = _dbContext.TutorProfiles.ToList();
            return Json(tutors, JsonRequestBehavior.AllowGet);
        }
    }
}
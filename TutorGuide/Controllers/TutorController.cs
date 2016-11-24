using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;
using TutorGuide.Repository;

namespace TutorGuide.Controllers
{
    public class TutorController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: Tutor
        public ActionResult Index()
        {
            var tutors = _dbContext.TutorProfiles.ToList();
            return View(tutors);
        }

        [HttpGet]
        public ActionResult RegisterTutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterTutor(TutorProfile tutor)
        {
            _dbContext.TutorProfiles.Add(tutor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
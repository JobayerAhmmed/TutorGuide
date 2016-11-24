using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;
using TutorGuide.Repository;

namespace TutorGuide.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Post()
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
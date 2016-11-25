using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;
using TutorGuide.Models.ViewModel;
using TutorGuide.Repository;
using TutorGuide.ViewModels;

namespace TutorGuide.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var postVM = (from post in _dbContext.Posts
                join student in _dbContext.StudentProfiles on post.StudentId equals student.Id
                select new PostIndexViewModel
                {
                    Id = post.Id,
                    InstituteName = student.InstituteName,
                    Class = student.Class,
                    Version = student.Version,
                    Salary = post.Salary,
                    DaysPerWeek = post.DaysPerWeek,
                    Subjects = post.Subjects
                }).ToList();

            
            return View(postVM);
        }

        public ActionResult Details(int id)
        {
            Post post = _dbContext.Posts.Find(id);
            StudentProfile student = _dbContext.StudentProfiles.Find(post.StudentId);

            if (post == null || student == null)
            {
                return HttpNotFound();
            }

            PostDetailsViewModel model = new PostDetailsViewModel();
            model.Class = student.Class;
            model.DaysPerWeek = post.DaysPerWeek;
            model.InstituteName = student.InstituteName;
            model.IsNegotiable = post.IsNegotiable;
            model.Name = student.Name;
            model.PresentAddress = student.PresentAddress;
            model.Salary = post.Salary;
            model.Subjects = post.Subjects;
            model.Version = student.Version;

            return View(model);
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                Post p = new Post();
                p.DaysPerWeek = post.DaysPerWeek;
                p.IsNegotiable = post.IsNegotiable;
                p.Salary = post.Salary;
                p.Subjects = post.Subjects;
                p.StudentId = 1;

                _dbContext.Posts.Add(post);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Post");
            }
            return View(post);
        }

        public ActionResult SearchPost()
        {
            return View();
        }

        public JsonResult GetAllPost()
        {
            var postVM = (from post in _dbContext.Posts
                          join student in _dbContext.StudentProfiles on post.StudentId equals student.Id
                          select new PostViewModel
                          {
                              Name = student.Name,
                              InstituteName = student.InstituteName,
                              Class = student.Class,
                              Version = student.Version,
                              Salary = post.Salary,
                              IsNegotiable = post.IsNegotiable,
                              DaysPerWeek = post.DaysPerWeek,
                              Subjects = post.Subjects,
                              PresentAddress = student.PresentAddress
                          }).ToList();
            return Json(postVM, JsonRequestBehavior.AllowGet);
        }
    }
}
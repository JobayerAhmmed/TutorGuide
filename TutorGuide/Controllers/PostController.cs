using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;
using TutorGuide.Models.ViewModel;
using TutorGuide.Repository;

namespace TutorGuide.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public ActionResult Index()
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
                    PresentAddress = student.PresentAddress,
                    Date = post.Date
                }).ToList();

            
            return View(postVM);
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            int studentId= 0;
            post.StudentId = studentId;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}
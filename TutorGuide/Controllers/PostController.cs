using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        public ActionResult MyPost()
        {
            var userId = User.Identity.GetUserId();
            var studentProfile = _dbContext.StudentProfiles.Where(s => s.UserId == userId).FirstOrDefault();

            var postVM = (from post in _dbContext.Posts
                          where post.StudentId == studentProfile.Id
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

        public JsonResult InterestedTutor(int id)
        {
            var tutors = (from com in _dbContext.Communications
                          where com.PostId == id
                          join tutor in _dbContext.TutorProfiles on com.TutorId equals tutor.Id
                          select new
                          {
                              Id = tutor.Id,
                              Name = tutor.Name,
                              Department = tutor.Department,
                              PhoneNumber = tutor.PhoneNumber
                          }).ToList();

            return Json(tutors, JsonRequestBehavior.AllowGet);
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
            model.Id = post.Id;
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

        public ActionResult ShowInterest(int postId)
        {
            string userId = User.Identity.GetUserId();
            TutorProfile tutor = _dbContext.TutorProfiles.Where(t => t.UserId == userId).FirstOrDefault();
            int tutorId = tutor.Id;

            var model = new Communication
            {
                PostId = postId,
                TutorId = tutorId

            };
            var isExist = _dbContext.Communications.FirstOrDefault(s => s.PostId == model.PostId && s.TutorId == model.TutorId);

            if (isExist == null)
            {
                _dbContext.Communications.Add(model);
                _dbContext.SaveChanges();
            }
            

            string msg = "Your interest has been saved.";
            return RedirectToAction("Index", "Home", new { message = msg });
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
                var userId = User.Identity.GetUserId();
                var student = _dbContext.StudentProfiles.Where(s => s.UserId == userId).FirstOrDefault();

                p.DaysPerWeek = post.DaysPerWeek;
                p.IsNegotiable = post.IsNegotiable;
                p.Salary = post.Salary;
                p.Subjects = post.Subjects;
                p.StudentId = student.Id;
                //p.StudentId = 0;

                _dbContext.Posts.Add(p);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Post");
            }
            return View(post);
        }

        public ActionResult SearchPost()
        {
            return View();
        }

        //public ActionResult ShowInterest(int tutorId, int postId)
        //{

        //}

        public JsonResult GetAllPost()
        {
            var postVM = (from post in _dbContext.Posts
                          join student in _dbContext.StudentProfiles on post.StudentId equals student.Id
                          select new PostViewModel
                          {
                              Id = post.Id,
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
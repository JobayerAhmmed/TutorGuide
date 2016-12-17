using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Repository;
using TutorGuide.ViewModels;

namespace TutorGuide.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;

            HomeIndexViewModel model = new HomeIndexViewModel();

            List<TutorIndexViewModel> tutorVM = new List<TutorIndexViewModel>();
            TutorIndexViewModel vm = new TutorIndexViewModel();
            var tutors = _dbContext.TutorProfiles.OrderByDescending(s=> s.Id).Take(10).ToList();

            foreach (var tutor in tutors)
            {
                vm.Id = tutor.Id;
                vm.Name = tutor.Name;
                vm.ImagePath = tutor.ImagePath;
                vm.Department = tutor.Department;
                vm.CurrentYear = tutor.CurrentYear;
                vm.ExpectedSalaryRange = tutor.ExpectedSalaryRange;
                vm.InterestedClass = tutor.InterestedClass;
                vm.InterestedSubject = tutor.InterestedSubject;
                vm.InterestedArea = tutor.InterestedArea;

                tutorVM.Add(vm);
                vm = new TutorIndexViewModel();
            }

            model.Tutors = tutorVM;

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
                              Subjects = post.Subjects,
                              PresentAddress = student.PresentAddress
                          }).OrderByDescending(s => s.Id).Take(10).ToList();

            model.Posts = postVM;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }
    }
}
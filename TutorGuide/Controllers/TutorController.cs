using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;
using TutorGuide.Repository;
using TutorGuide.ViewModels;

namespace TutorGuide.Controllers
{
    public class TutorController : Controller
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

        // GET: Tutor
        public ActionResult Index(string message)
        {
            List<TutorIndexViewModel> model = new List<TutorIndexViewModel>();
            TutorIndexViewModel vm = new TutorIndexViewModel();
            var tutors = _dbContext.TutorProfiles.ToList();

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

                model.Add(vm);
                vm = new TutorIndexViewModel();
            }
            ViewBag.Message = message;
            return View(model.ToList());
        }

        public ActionResult Details(int id)
        {
            TutorProfile tutor = _dbContext.TutorProfiles.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }

            TutorViewModel model = new TutorViewModel();
            model.Name = tutor.Name;
            model.ImagePath = tutor.ImagePath;
            model.Department = tutor.Department;
            model.CurrentYear = tutor.CurrentYear;
            model.AdmissionSession = tutor.AdmissionSession;
            model.ExpectedSalaryRange = tutor.ExpectedSalaryRange;
            model.Hall = tutor.Hall;
            model.InterestedArea = tutor.InterestedArea;
            model.InterestedClass = tutor.InterestedClass;
            model.InterestedSubject = tutor.InterestedSubject;
            model.PermanentAddress = tutor.ParmanentAddress;
            model.PresentAddress = tutor.PresentAddress;

            return View(model);
        }

        [HttpGet]
        public ActionResult RegisterTutor()
        {
            Data data = new Data();
            RegisterTutorViewModel model = new RegisterTutorViewModel();

            model.Departments = data.Subjects;
            model.Years = data.Years;

            var classes = new List<CheckBoxListItem>();
            //var departments = new List<CheckBoxListItem>();
            var areas = new List<CheckBoxListItem>();

            foreach (var item in data.Classes)
            {
                classes.Add(new CheckBoxListItem()
                {
                    Value = item,
                    Text = item,
                    IsChecked = false
                });
            }
            //foreach (var item in data.Subjects)
            //{
            //    departments.Add(new CheckBoxListItem()
            //    {
            //        Value = item,
            //        Text = item,
            //        IsChecked = false
            //    });
            //}
            foreach (var item in data.Areas)
            {
                areas.Add(new CheckBoxListItem()
                {
                    Value = item,
                    Text = item,
                    IsChecked = false
                });
            }

            model.Classes = classes;
            //model.Subjects = departments;
            model.Areas = areas;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult RegisterTutor([Bind(Exclude = "DepartmentList, YearList")]RegisterTutorViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (file != null && file.ContentLength > 0)
                {
                    if (file.ContentType.Contains("image"))
                    {
                        fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                        file.SaveAs(HttpContext.Server.MapPath("~/Content/UserImage/")
                            + fileName);
                    }
                    else
                        ModelState.AddModelError("ImagePath", "Unsupported image format");
                }

                var user = new ApplicationUser();
                user.UserName = model.PhoneNumber;
                user.PhoneNumber = model.PhoneNumber;
                user.PhoneNumberConfirmed = true;

                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    TutorProfile tutor = new TutorProfile();
                    tutor.AdmissionSession = model.AdmissionSession;
                    tutor.CurrentYear = model.CurrentYear;
                    tutor.Department = model.Department;
                    tutor.ExpectedSalaryRange = model.ExpectedSalaryRange;
                    tutor.Hall = model.Hall;
                    tutor.ImagePath = fileName;
                    tutor.Name = model.Name;
                    tutor.ParmanentAddress = model.PermanentAddress;
                    tutor.PhoneNumber = model.PhoneNumber;
                    tutor.PresentAddress = model.PresentAddress;
                    tutor.RegistrationNo = model.RegistrationNo;
                    tutor.UserId = user.Id;
                    tutor.InterestedSubject = model.InterestedSubjects;

                    string classes = "";
                    foreach (var item in model.Classes)
                    {
                        if (item.IsChecked)
                        {
                            classes = classes + item.Value + ",";
                        }
                    }
                    tutor.InterestedClass = classes;

                    string areas = "";
                    foreach (var item in model.Areas)
                    {
                        if (item.IsChecked)
                        {
                            areas = areas + item.Value + ",";
                        }
                    }
                    tutor.InterestedArea = areas;

                    _dbContext.TutorProfiles.Add(tutor);
                    _dbContext.SaveChanges();

                    string msg = "Registration successful. Please log in to continue.";

                    return RedirectToAction("Index", "Tutor", new { message = msg });
                }
                AddErrors(result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
﻿using Microsoft.AspNet.Identity;
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
            var tutors = _dbContext.TutorProfiles.OrderByDescending(s => s.Id).ToList();

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

        public ActionResult InterestedTution()
        {
            var userId = User.Identity.GetUserId();
            var tutorId = _dbContext.TutorProfiles.Where(s => s.UserId == userId).FirstOrDefault().Id;

            var tutions = from tution in _dbContext.Communications
                          where tution.TutorId == tutorId
                          join post in _dbContext.Posts on tution.PostId equals post.Id
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
                          };
            return View(tutions);
        }

        //public JsonResult MyTution()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var tutorId = _dbContext.TutorProfiles.Where(s => s.UserId == userId).FirstOrDefault().Id;

        //    var tutions = from tution in _dbContext.Communications
        //                  where tution.TutorId == tutorId
        //                  join post in _dbContext.Posts on tution.PostId equals post.Id
        //                  join student in _dbContext.StudentProfiles on post.StudentId equals student.Id
        //                  select new
        //                  {
        //                      Id = post.Id,
        //                      InstituteName = student.InstituteName,
        //                      Class = student.Class,
        //                      Version = student.Version,
        //                      Salary = post.Salary,
        //                      DaysPerWeek = post.DaysPerWeek,
        //                      Subjects = post.Subjects
        //                  };
        //    return Json(tutions, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult RegisterTutor()
        {
            Data data = new Data();
            RegisterTutorViewModel model = new RegisterTutorViewModel();

            var departments = _dbContext.Departments.ToList();
            model.Departments = departments;
            model.Years = _dbContext.Years.ToList();

            var classes = new List<CheckBoxListItem>();
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
            model.Areas = areas;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult RegisterTutor(RegisterTutorViewModel model, HttpPostedFileBase file)
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
                    UserManager.AddToRole(user.Id, "Tutor");

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

                    SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    string msg = "";

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
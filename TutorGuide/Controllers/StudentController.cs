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
    public class StudentController : Controller
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

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            //Data data = new Data();
            RegisterStudentViewModel model = new RegisterStudentViewModel();

            //model.Versions = _dbContext.Versions.ToList();
            //model.Classes = _dbContext.Classes.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult RegisterStudent(RegisterStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.PhoneNumber;
                user.PhoneNumber = model.PhoneNumber;
                user.PhoneNumberConfirmed = true;

                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Student");

                    StudentProfile student = new StudentProfile();
                    student.Name = model.Name;
                    student.PhoneNumber = model.PhoneNumber;
                    student.ParmanentAddress = model.PermanentAddress;
                    student.PresentAddress = model.PresentAddress;
                    student.InstituteName = model.InstituteName;
                    student.FatherName = model.FatherName;
                    student.FatherOccupation = model.FatherOccupation;
                    student.RegisterDate = DateTime.Now;
                    student.Version = model.Version;
                    student.Class = model.Class;
                    student.UserId = user.Id;

                    _dbContext.StudentProfiles.Add(student);
                    _dbContext.SaveChanges();
                    SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    
                    //string msg = "Registration successful. Please log in to continue.";
                    string msg = "";


                    return RedirectToAction("Index", "Home", new { message = msg });
                }
                AddErrors(result);
            }

            return View(model);
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorGuide.Models;

namespace TutorGuide.ViewModels
{
    public class RegisterTutorViewModel
    {
        [Required(ErrorMessage = "Please enter name.")]
        [StringLength(100, ErrorMessage = "Name must be at least 5 characters long.", MinimumLength = 5)]
        [RegularExpression(@"([a-zA-Z][a-zA-Z\.\'\-\s]+)", ErrorMessage = "Please enter valid name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [StringLength(14, ErrorMessage = "Please enter valid phone number.", MinimumLength = 3)]
        [RegularExpression(@"(\+?[0-9]+)", ErrorMessage = "Phone number can only contains digits and a plus symbol.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Please select department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please enter hall name")]
        public string Hall { get; set; }

        [Required(ErrorMessage = "Please enter hall name")]
        public string AdmissionSession { get; set; }

        [Required(ErrorMessage = "Please select current year")]
        public string CurrentYear { get; set; }

        [Required(ErrorMessage = "Please enter registration no.")]
        public string RegistrationNo { get; set; }

        [Required(ErrorMessage = "Please enter permanent address")]
        public string PermanentAddress { get; set; }

        [Required(ErrorMessage = "Please enter present address")]
        public string PresentAddress { get; set; }
        public string ExpectedSalaryRange { get; set; }

        //public string InterestedClasses { get; set; }
        public string InterestedSubjects { get; set; }
        //public string InterestedAreas { get; set; }

        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Year> Years { get; set; }
        public List<CheckBoxListItem> Classes { get; set; }
        //public List<CheckBoxListItem> Subjects { get; set; }
        public List<CheckBoxListItem> Areas { get; set; }

        public IEnumerable<SelectListItem> DepartmentList
        {
            get
            {
                var departments = Departments.Select(d => new SelectListItem
                {
                    Value = d.Name,
                    Text = d.Name,
                    Selected = false
                });
                return departments;
            }
        }
        public IEnumerable<SelectListItem> YearList
        {
            get
            {
                var years = Years.Select(d => new SelectListItem
                {
                    Value = d.Name,
                    Text = d.Name,
                    Selected = false
                });
                return years.ToList();
            }
        }
        public RegisterTutorViewModel()
        {
            Classes = new List<CheckBoxListItem>();
            //Subjects = new List<CheckBoxListItem>();
            Areas = new List<CheckBoxListItem>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorGuide.ViewModels
{
    public class RegisterStudentViewModel
    {
        [Required(ErrorMessage = "Please enter name.")]
        [StringLength(100, ErrorMessage = "Name must be at least 5 characters long.", MinimumLength = 5)]
        [RegularExpression(@"([a-zA-Z][a-zA-Z\.\'\-\s]+)", ErrorMessage = "Please enter valid name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [StringLength(14, ErrorMessage = "Please enter valid phone number.", MinimumLength = 3)]
        [RegularExpression(@"(\+?[0-9]+)", ErrorMessage = "Phone number can only contains digits and a plus symbol.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter Institution name")]
        [StringLength(100, ErrorMessage = "Name must be at least 5 characters long.", MinimumLength = 5)]
        [Display(Name = "School / College")]
        public string InstituteName { get; set; }

        public string Version { get; set; }

        [Required(ErrorMessage = "Please select class")]
        public string Class { get; set; }

        [StringLength(100, ErrorMessage = "Name must be at least 5 characters long", MinimumLength = 5)]
        [RegularExpression(@"([a-zA-Z][a-zA-Z\.\'\-\s]+)", ErrorMessage = "Please enter valid name")]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        [StringLength(100, ErrorMessage = "Occupation must be at least 3 characters long", MinimumLength = 3)]
        [RegularExpression(@"([a-zA-Z][a-zA-Z\.\'\-\s]+)", ErrorMessage = "Please enter valid name")]
        [Display(Name = "Father's Occupation")]
        public string FatherOccupation { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public IEnumerable<string> Versions { get; set; }
        public IEnumerable<string> Classes { get; set; }

        public IEnumerable<SelectListItem> VersionList
        {
            get
            {
                var versions = Versions.Select(d => new SelectListItem
                {
                    Value = d,
                    Text = d,
                    Selected = false
                });
                return versions.ToList();
            }
        }
        public IEnumerable<SelectListItem> ClassList
        {
            get
            {
                var classes = Classes.Select(d => new SelectListItem
                {
                    Value = d,
                    Text = d,
                    Selected = false
                });
                return classes.ToList();
            }
        }
    }
}
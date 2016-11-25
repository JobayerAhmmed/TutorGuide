using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorGuide.ViewModels
{
    public class TutorViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Department { get; set; }
        public string Hall { get; set; }
        public string AdmissionSession { get; set; }
        public string CurrentYear { get; set; }
        public string RegistrationNo { get; set; }

        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }

        public string ExpectedSalaryRange { get; set; }
        public string InterestedClass { get; set; }
        public string InterestedSubject { get; set; }
        public string InterestedArea { get; set; }
    }
}
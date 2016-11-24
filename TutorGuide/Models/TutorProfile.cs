using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorGuide.Models
{
    [Table("TutorProfile")]
    public class TutorProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Hall { get; set; }
        public string AdmissionSession { get; set; }
        public int CurrentYear { get; set; }
        public int VarsityRegistrationNo { get; set; }

        public string ParmanentAddress { get; set; }
        public string PresentAddress { get; set; }

        public string ExpectedSalaryRange { get; set; }
        public string InterestedClass { get; set; }
        public string InterestedSubject { get; set; }
        public string InterestedArea { get; set; }
    }
}
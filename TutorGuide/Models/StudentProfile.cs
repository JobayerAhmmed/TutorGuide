using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorGuide.Models
{
    [Table("StudentProfile")]
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ParmanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }

        public string InstituteName{ get; set; }
        public string Class { get; set; }
        public string Version { get; set; }

        public DateTime RegisterDate { get; set; }
        

    }
}
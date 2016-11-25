using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorGuide.ViewModels
{
    public class TutorIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Department { get; set; }
        public string CurrentYear { get; set; }
        public string ExpectedSalaryRange { get; set; }
        public string InterestedClass { get; set; }
        public string InterestedSubject { get; set; }
        public string InterestedArea { get; set; }
    }
}
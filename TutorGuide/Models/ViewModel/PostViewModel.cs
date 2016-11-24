using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorGuide.Models.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Salary { get; set; }
        public bool IsNegotiable { get; set; }
        public int DaysPerWeek { get; set; }
        public string Subjects { get; set; }

        public string Name { get; set; }
        public string PresentAddress { get; set; }
        public string InstituteName { get; set; }
        public string Class { get; set; }
        public string Version { get; set; }
    }
}
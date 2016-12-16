using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorGuide.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<TutorIndexViewModel> Tutors { get; set; }
        public IEnumerable<PostIndexViewModel> Posts { get; set; }
    }
}
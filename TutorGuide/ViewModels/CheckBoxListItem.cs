using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorGuide.ViewModels
{
    public class CheckBoxListItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
}
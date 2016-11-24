using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorGuide.Models
{
    [Table("Post")]
    public class Post
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Salary { get; set; }
        public bool IsNegotiable { get; set; }
        public int DaysPerWeek { get; set; }
        public string Subjects { get; set; }
    }
}
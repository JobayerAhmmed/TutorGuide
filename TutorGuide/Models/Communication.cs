using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorGuide.Models
{
    [Table("Communication")]
    public class Communication
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TutorId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
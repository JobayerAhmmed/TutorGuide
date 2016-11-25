using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorGuide.ViewModels
{
    public class Data
    {
        public List<string> Versions
        {
            get
            {
                List<string> versions = new List<string>
                {
                    "Bangla",
                    "English",
                    "English Medium"
                };
                return versions;
            }
        }
        public List<string> Classes
        {
            get
            {
                List<string> classes = new List<string>
                {
                    "Class I",
                    "Class II",
                    "Class III",
                    "Class IV",
                    "Class V",
                    "Class VI",
                    "Class VII",
                    "Class VIII",
                    "Class IX",
                    "Class X",
                    "Class XI",
                    "Class XII",
                    "O' Level",
                    "A' Level"
                };
                return classes.ToList();
            }
        }
        public List<string> Subjects
        {
            get
            {
                List<string> subjects = new List<string>
                {
                    "Bengali",
                    "English",
                    "History",
                    "Finance",
                    "Accounting",
                    "Marketing",
                    "Banking",
                    "Management Studies",
                    "Tourism and Hospitality Management",
                    "Botany",
                    "Soil, Water and Environment",
                    "Microbiology",
                    "Biochemistry and Molecular Biology",
                    "Fisheries",
                    "Genetic Engineering and Bio-technology",
                    "Psychology",
                    "Zoology",
                    "Electrical and Electronic Engineering",
                    "Applied Chemistry and Chemical Engineering",
                    "Computer Science and Engineering",
                    "Nuclear Engineering",
                    "Graphic Design",
                    "Drawing and Painting",
                    "Law",
                    "Pharmacy",
                    "Mathematics",
                    "Applied Mathematics",
                    "Physics",
                    "Statistics",
                    "Chemistry",
                    "Economics",
                    "Sociology",
                    "Geography",
                    "Statistical Research and Training",
                    "Business Administration",
                    "Nutrition and Food Science",
                    "Information Technology",
                    "Leather Engineering and Technology"
                };
                return subjects.OrderBy(s => s).ToList();
            }
        }
        public List<string> Areas
        {
            get
            {
                List<string> areas = new List<string>
                {
                    "Badda",
                    "Bangshal",
                    "Dhanmondi",
                    "Azimpur",
                    "Hazaribag",
                    "Gulshan",
                    "Jatrabari",
                    "Kalabagan",
                    "Lalbag",
                    "Mirpur",
                    "Mohammadpur",
                    "Motijheel",
                    "New Market",
                    "Paltan",
                    "Ramna",
                    "Rampura",
                    "Shahbag",
                    "Tejgaon",
                    "Uttara",
                    "Firmgate",
                    "Segunbagicha",
                    "Mohakhali"
                };
                return areas.OrderBy(s => s).ToList();
            }
        }
        public List<string> Years
        {
            get
            {
                List<string> years = new List<string>
                {
                    "1st Year",
                    "2nd Year",
                    "3rd Year",
                    "4th Year",
                    "MS 1st Year",
                    "Ms 2nd Year"
                };
                return years.ToList();
            }
        }
    }

    public class Message
    {
        public string Value { get; set; }
    }
}
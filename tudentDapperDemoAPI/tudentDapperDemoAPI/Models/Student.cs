using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDapperDemoAPI.Models
{
    public class Student
    {
        public int StudId { get; set; }
        public string StudName { get; set; }
        public string StudAddress { get; set; }
        public string StudGender { get; set; }
        public string StudClass { get; set; }
        public string StudFatherName { get; set; }
        public string StudMotherName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public ICollection<CourseList> CourseLists { get; set; }
    }
}
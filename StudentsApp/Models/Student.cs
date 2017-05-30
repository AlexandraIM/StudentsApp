using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Studen Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Studen E-mail")]
        public string Email { get; set; }

        public ICollection<CourseList> CourseLists { get; set; }
    }
}
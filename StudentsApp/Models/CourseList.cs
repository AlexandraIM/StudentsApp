using System;

namespace StudentsApp.Models
{
    public class CourseList
    {

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int Durtation { get; set; }
        public DateTime HolidayStartDay { get; set; }
        public DateTime HolidayEndDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}
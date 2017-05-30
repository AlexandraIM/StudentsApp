using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Models
{
    public class CourseList
    {

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public int Durtation { get; set; }
        [Display(Name = "Course Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Course End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Holiday Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? HolidayStartDay { get; set; }
        [Display(Name = "Holiday End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? HolidayEndDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}
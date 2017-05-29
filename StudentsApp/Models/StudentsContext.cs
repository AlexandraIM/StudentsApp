using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base("StudentsDB")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Corses { get; set; }
        public DbSet<CourseList> CorsesList { get; set; }

    }
}
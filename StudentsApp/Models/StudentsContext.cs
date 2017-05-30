using StudentsApp.Models.DbInitializer;
using System.Data.Entity;

namespace StudentsApp.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base("StudentsDB")
        {
            Database.SetInitializer(new StudentsDbInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Corses { get; set; }
        public DbSet<CourseList> CorsesList { get; set; }

    }
}
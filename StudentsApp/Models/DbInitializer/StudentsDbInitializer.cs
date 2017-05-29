using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsApp.Models.DbInitializer
{
    public class StudentsDbInitializer: DropCreateDatabaseAlways<StudentsContext>
    {
        protected override void Seed(StudentsContext context)
        {
            var students = new List<Student>
            {
                new Student{FullName ="Alex", Email ="test@test.test"},
                new Student{FullName ="Max", Email ="test@test.test"},
                new Student{FullName ="Rob", Email ="test@test.test"},
                new Student{FullName ="Bob", Email ="test@test.test"},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{ Id= 1111, CourseName ="New Course", StartDate = DateTime.Parse("01.10.2017"), EndDate = DateTime.Parse("07.10.2017") },
                new Course{ Id= 1121, CourseName ="New Course 2", StartDate = DateTime.Parse("01.10.2017"), EndDate = DateTime.Parse("07.10.2017") },
                new Course{ Id= 1131, CourseName ="New Course 3", StartDate = DateTime.Parse("01.10.2017"), EndDate = DateTime.Parse("07.10.2017") },
                new Course{ Id= 1141, CourseName ="New Course 4", StartDate = DateTime.Parse("01.10.2017"), EndDate = DateTime.Parse("07.10.2017") }
            };
            courses.ForEach(c => context.Corses.Add(c));
            context.SaveChanges();

            var coursesList = new List<CourseList>
            {
                new CourseList{StudentId = 1, CourseId = 1111, Durtation = 1},
                new CourseList{StudentId = 1, CourseId = 1121, Durtation = 1},
                new CourseList{StudentId = 2, CourseId = 1111, Durtation = 1},
                new CourseList{StudentId = 2, CourseId = 1131, Durtation = 1},
                new CourseList{StudentId = 3, CourseId = 1131, Durtation = 1},
                new CourseList{StudentId = 3, CourseId = 1141, Durtation = 1},
            };
            coursesList.ForEach(cl => context.CorsesList.Add(cl));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
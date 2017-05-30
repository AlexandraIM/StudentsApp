using System;
using System.Collections.Generic;
using System.Data.Entity;

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
                new Course{ Id= 1111, CourseName ="New Course"},
                new Course{ Id= 1121, CourseName ="New Course 2"  },
                new Course{ Id= 1131, CourseName ="New Course 3"  },
                new Course{ Id= 1141, CourseName ="New Course 4" }
            };
            courses.ForEach(c => context.Corses.Add(c));
            context.SaveChanges();

           
            base.Seed(context);
        }
    }
}
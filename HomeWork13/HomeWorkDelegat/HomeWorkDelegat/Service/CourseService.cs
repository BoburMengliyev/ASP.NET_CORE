using HomeWorkDelegat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkDelegat.Service
{
    public class CourseService
    {
        public delegate void CourseRegistrationHandler(Student student, Course course);

        public void RegisterCourse(Student student, Course course) 
        {
            Console.WriteLine($" {student.Name} - {course.Title} kursiga ro`yhatdan o`tdingiz.");
        }
    }
}

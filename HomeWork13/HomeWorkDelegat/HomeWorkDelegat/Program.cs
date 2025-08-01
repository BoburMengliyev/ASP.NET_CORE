using HomeWorkDelegat.Models;
using HomeWorkDelegat.Service;
using static HomeWorkDelegat.Service.CourseService;

namespace HomeWorkDelegat
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1 - topshiriq:

            var student = new Student { Id = 1, Name = "Bobur" };
            var course = new Course { Id = 101, Title = "C# Asoslari" };

            var courseService = new CourseService();

            CourseRegistrationHandler handler = courseService.RegisterCourse;
            handler(student, course);

            Console.WriteLine();
            Console.WriteLine("#################################\n");

            // 2 - topshiriq:

            var formatService = new FormatterService();
            Func<Student, string> format = s => $"O`quvchi: {s.Name}, ID {s.Id}";
            formatService.PrintStudentInfo(format, student);

            Console.WriteLine();
            Console.WriteLine("#################################\n");

            // 3 - topshiriq:

            var libraryService = new LibraryService();

            Action<Student> action1 = libraryService.RegisterStudent;
            Action<Student> action2 = LibraryService.SendWelcomeMessage;
            Action<Student> combined = action1 + action2;

            combined(student);

            Console.WriteLine();
            Console.WriteLine("#################################\n");

            // 4 - topshiriq:

            Predicate<Student> predicat = p => p.Name.Length > 5;

            var studnets = new List<Student> 
            {
                new Student { Id = 3, Name = "Aloidin"},
                new Student { Id = 1, Name = "Bobur"},
                new Student { Id = 2, Name = "Mustafo"},
                new Student { Id = 4, Name = "Oybek"},
                new Student { Id = 5, Name = "Jasur"},
                new Student { Id = 6, Name = "Muhammad"}
            };

            var filtir = studnets.FindAll(predicat);

            foreach (var s in filtir) 
            {
                Console.WriteLine($"Name: {s.Name} - ID: {s.Id}");
            }
        }
    }   
}

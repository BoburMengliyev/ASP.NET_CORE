using HomeWorkDelegat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkDelegat.Service
{
    public class LibraryService
    {
        public void RegisterStudent(Student student) 
        {
            Console.WriteLine($"{student.Name} kutubhonaga ro`yhatdan o`tdingiz");
        }

        public static void SendWelcomeMessage(Student student)
        {
            Console.WriteLine($" Xush kelibsiz, {student.Name}!");
        }
    }
}

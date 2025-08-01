using HomeWorkDelegat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkDelegat.Service
{
    public class FormatterService
    {
        public void PrintStudentInfo(Func<Student, string> format, Student student) 
        {
            string result = format(student);
            Console.WriteLine(result);
        }
    }
}

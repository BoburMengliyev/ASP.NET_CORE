using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperOrm.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int PassportId { get; set; }

        public Passport Passport { get; set; } = new();
    }
}

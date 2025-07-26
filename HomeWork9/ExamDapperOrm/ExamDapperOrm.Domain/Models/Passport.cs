using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperOrm.Domain.Models
{
    public class Passport
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}

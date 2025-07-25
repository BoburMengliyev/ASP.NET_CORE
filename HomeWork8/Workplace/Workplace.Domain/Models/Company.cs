using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workplace.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}

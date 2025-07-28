using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workplace.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public Department Department { get; set; } = default!;
        public Branch Branch { get; set; } = default!;
        public Company Company { get; set; } = default!;

    }
}

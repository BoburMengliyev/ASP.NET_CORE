using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workplace.Domain.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public Company Company { get; set; } = default!;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

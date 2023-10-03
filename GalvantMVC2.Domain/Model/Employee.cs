using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
    }
}

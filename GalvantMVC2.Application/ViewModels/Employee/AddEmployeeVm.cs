using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Employee
{
    public class AddEmployeeVm
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
    }
}

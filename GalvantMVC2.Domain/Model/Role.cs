using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

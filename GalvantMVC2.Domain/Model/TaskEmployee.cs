using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class TaskEmployee
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

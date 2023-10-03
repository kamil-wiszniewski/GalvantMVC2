﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartamentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

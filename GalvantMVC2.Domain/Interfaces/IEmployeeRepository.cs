using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Department> GetAllDepartments();

        IQueryable<Role> GetAllRoles();

        int AddEmployee(Employee employee);

        IQueryable<Employee> GetAllEmployees();
    }
}

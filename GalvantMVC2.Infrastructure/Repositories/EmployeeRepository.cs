using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Department> GetAllDepartments()
        {
            var departments = _context.Departments;
            return departments;
        }

        public IQueryable<Role> GetAllRoles()
        {
            var roles = _context.Roles;
            return roles;
        }

        public int AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.EmployeeId;
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            var employees = _context.Employees;
            return employees;
        }
    }
}

using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Employee;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GalvantMVC2.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public int AddEmployee(AddEmployeeVm model)
        {
            var employee = new Employee
            {
                EmployeeId = model.EmployeeId,
                Name = model.Name,
                LastName = model.LastName,
                DepartmentId = model.DepartmentId,
                RoleId = model.RoleId,                
            };
            _employeeRepo.AddEmployee(employee);

            return employee.EmployeeId;
        }

        public List<DepartmentsVm> GetAllDepartments()
        {
            var departments = _employeeRepo.GetAllDepartments();
            var departmentsVmList = new List<DepartmentsVm>();
            foreach (var department in departments)
            {
                var departmentsVm = new DepartmentsVm
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartamentName
                };
                departmentsVmList.Add(departmentsVm);
            }
            return departmentsVmList;
        }

        public List<RolesVm> GetAllRoles()
        {
            var roles = _employeeRepo.GetAllRoles();
            var rolesVmList = new List<RolesVm>();
            foreach (var role in roles)
            {
                var rolesVm = new RolesVm
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName
                };
                rolesVmList.Add(rolesVm);
            }
            return rolesVmList;
        }

        public async Task<List<string>> GetSuggestions(string searchText)
        {
            var employees = _employeeRepo.GetAllEmployees();

            var suggestionsQuery = employees
                .Where(e => e.LastName.Contains(searchText))
                .Select(e => e.LastName);

            var suggestions = await suggestionsQuery.ToListAsync();

            return suggestions;
        }
    }
}

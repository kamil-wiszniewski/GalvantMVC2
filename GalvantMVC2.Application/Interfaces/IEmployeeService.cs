using GalvantMVC2.Application.ViewModels.Employee;
using GalvantMVC2.Application.ViewModels.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Interfaces
{
    public interface IEmployeeService
    {
        List<DepartmentsVm> GetAllDepartments();

        List<RolesVm> GetAllRoles();

        int AddEmployee(AddEmployeeVm model);

        Task<List<string>> GetSuggestions(string searchText);
    }
}

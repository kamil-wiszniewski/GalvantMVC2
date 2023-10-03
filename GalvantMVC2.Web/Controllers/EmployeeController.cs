using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.Services;
using GalvantMVC2.Application.ViewModels.Employee;
using GalvantMVC2.Application.ViewModels.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GalvantMVC2.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("employee")]
        public IActionResult Index()
        {
            return View(new SearchLastNameVm());
        }

        [Route("add-employee")]
        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<DepartmentsVm> departments = _employeeService.GetAllDepartments();
            ViewBag.Departments = departments;

            List<RolesVm> roles = _employeeService.GetAllRoles();
            ViewBag.Roles = roles;

            return View();
        }

        [Route("add-employee")]
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeVm model)
        {
            var id = _employeeService.AddEmployee(model);
            return RedirectToAction("Index", "Employee");
        }

        [Route("get-suggestions")]
        [HttpPost]
        public async Task<IActionResult> GetSuggestions(string searchText)
        {
            if (string.IsNullOrEmpty(searchText) || searchText.Length < 3)
                return BadRequest();

            var suggestions = await _employeeService.GetSuggestions(searchText);

            return Ok(suggestions);
        }
    }
}

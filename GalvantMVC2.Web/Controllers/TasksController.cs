using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.Services;
using GalvantMVC2.Application.ViewModels.AdditionalFields;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GalvantMVC2.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITagService _tagService;
        private readonly ITaskService _taskService;
        public TasksController(ITagService tagService, ITaskService taskService)
        {
            _tagService = tagService;
            _taskService = taskService;
        }

        [Route("tasks")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("tasks/filtered-tasks")]
        public IActionResult FilteredTasks(string tag)
        {
            var model = _taskService.GetFilteredTasksForList(tag);
            return PartialView("_FilteredTasks", model);
        }

        [Route("add-task")]
        [HttpGet]
        public IActionResult AddTask()
        {
            //List<TypesVm> types = _typeService.GetAllTypes();
            //ViewBag.Types = types;
            List<TagsVm> tags = _tagService.GetAllTags();
            ViewBag.Tags = tags;


            return View();
        }

        [Route("add-task")]
        [HttpPost]
        public IActionResult AddTask(AddTaskVm model)
        {
            var id = _taskService.AddTask(model);
            return RedirectToAction("Index");
        }

        [Route("add-task/GetSecondDropdownOptions")]
        [HttpGet]
        public IActionResult GetSecondDropdownOptions(string firstDropdownVal)
        {
            var location1s = _taskService.GetDataForSecondDropdown(firstDropdownVal);
            return Json(location1s);
        }

        [Route("add-task/GetThirdDropdownOptions")]
        [HttpGet]
        public IActionResult GetThirdDropdownOptions(string firstDropdownVal, int secondDropdownVal)
        {
            var types = _taskService.GetDataForThirdDropdown(firstDropdownVal, secondDropdownVal);
            return Json(types);
        }

        [Route("add-task/GetFourthDropdownOptions")]
        [HttpGet]
        public IActionResult GetFourthDropdownOptions(string firstDropdownVal, int secondDropdownVal, int thirdDropdownVal)
        {
            var equipment = _taskService.GetDataForFourthDropdown(firstDropdownVal, secondDropdownVal, thirdDropdownVal);
            return Json(equipment);
        }

        [Route("zgloszenie1")]
        [HttpGet]
        public IActionResult ZgloszenieStep1()
        {
            return View();
        }

        [Route("zgloszenie2")]
        [HttpGet]
        public IActionResult ZgloszenieStep2()
        {
            return View();
        }

        [Route("zgloszenie3")]
        [HttpGet]
        public IActionResult ZgloszenieStep3()
        {
            return View();
        }

        [Route("zgloszenie4")]
        [HttpGet]
        public IActionResult ZgloszenieStep4()
        {
            return View();
        }
    }
}

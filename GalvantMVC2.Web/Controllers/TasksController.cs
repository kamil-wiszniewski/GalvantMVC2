using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.Services;
using GalvantMVC2.Application.ViewModels.AdditionalFields;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.Tasks;
using GalvantMVC2.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GalvantMVC2.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITagService _tagService;
        private readonly ITaskService _taskService;
        private readonly ITypeService _typeService;
        private readonly ILocation2Service _location2Service;
        public TasksController(ITagService tagService, ITaskService taskService, ITypeService typeService, ILocation2Service location2Service)
        {
            _tagService = tagService;
            _taskService = taskService;
            _typeService = typeService;
            _location2Service = location2Service;
        }

        [Route("tasks")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("tasks/index2")]
        public IActionResult Index2()
        {
            ViewBag.Location1s = new List<string>()
            {
                "Czarna Białostocka",
                "Wyszków"
            };

            List<TypesVm> types = _typeService.GetAllTypes();
            ViewBag.Types = types;

            List<Location2Vm> location2s = _location2Service.GetAllLocations2();
            ViewBag.Location2s = location2s;

            List<TagsVm> tags = _tagService.GetAllTags();
            ViewBag.Tags = tags;

            List<StatusesVm> statuses = _taskService.GetAllStatuses();
            ViewBag.Statuses = statuses;

            ViewBag.Priorities = Enum.GetValues(typeof(PriorityEnum)).Cast<PriorityEnum>().ToList();

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
            List<TagsVm> tags = _tagService.GetAllTags();
            ViewBag.Tags = tags;
            List<StatusesVm> statuses = _taskService.GetAllStatuses();
            ViewBag.Statuses = statuses;

            return View();
        }

        [Route("add-task")]
        [HttpPost]
        public IActionResult AddTask(AddTaskVm model)
        {
            var id = _taskService.AddTask(model);
            return RedirectToAction("Index2");
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

        [Route("tasks/search")]
        [HttpPost]
        public ActionResult Search(string location1, int type, int location2, int status, int tag, string priority, int pageNumber = 1, int pageSize = 20)
        {
            var result = _taskService.Search(location1, type, location2, status, tag, priority, pageNumber = 1, pageSize = 20);
            
            return PartialView("_TaskSearchResults", result);
        }
    }
}

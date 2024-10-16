using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.AdditionalFields;
using GalvantMVC2.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace GalvantMVC2.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly ILocation2Service _location2Service;
        private readonly IEquipmentService _equipmentService;
        private readonly IFileService _fileService;
        public EquipmentController(ITypeService typeService, ILocation2Service location2Service, IEquipmentService equipmentService, IFileService fileService)
        {
            _typeService = typeService;
            _location2Service = location2Service;
            _equipmentService = equipmentService;
            _fileService = fileService;
        }

        [Route("/")]
        [Route("equipment")]
        public IActionResult Index(string? selectedLocation1, int? selectedType, int? selectedLocation2)
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

            var model = _equipmentService.GetAllEquipmentForList(selectedLocation1, selectedType, selectedLocation2);

            return View(model);
        }

        [Route("add-equipment")]
        [HttpGet]
        public IActionResult AddEquipment()
        {            
            List<TypesVm> types = _typeService.GetAllTypes();
            ViewBag.Types = types;
            List<Location2Vm> locations = _location2Service.GetAllLocations2();
            ViewBag.Locations = locations;
            return View();
        }

        [Route("add-equipment")]
        [HttpPost]
        public IActionResult AddEquipment(AddEquipmentVm model, AdditionalFieldsVm additionalFieldsModel)
        {
            var equipmentId = _equipmentService.AddEquipment(model, additionalFieldsModel);
            return Redirect($"/add-files/{equipmentId}");
        }
    
        [Route("add-equipment/AdditionalFields")]
        public IActionResult AdditionalFields(int selectedTypeId)
        {
            string partialViewName = _equipmentService.GetProperAdditionalFieldsPartialViewName(selectedTypeId);            
            
            return PartialView(partialViewName);
        }

        [HttpPost]
        [Route("add-equipment/upload-files")]
        [RequestSizeLimit(50 * 1024 * 1024)]    
        public async Task<IActionResult> UploadFiles(List<IFormFile> files, int categoryId, int equipmentId)
        {
            if (files.Count > 5)
            {
                Console.WriteLine("Ponad 5 plików");
                this.ModelState.AddModelError("files", "You cannot upload more than 5 images");
                return this.View();
            }

            if (files.Any(i => i.Length > 10 * 1024 * 1024))
            {
                this.ModelState.AddModelError("files", "The size of your image cannot be more than 10 MB");
                return this.View();
            }

            _fileService.Upload(files, categoryId, equipmentId);

            return Json(new { success = true, message = "Pliki przesłane pomyślnie."});
        }


        [Route("edit-equipment/{equipmentId}")]       
        [HttpGet]
        public IActionResult EditEquipment(int equipmentId)
        {
            var equipment = _equipmentService.GetEquipmentSharedFieldsForEdit(equipmentId);
            var additionalFields = _equipmentService.GetEquipmenmtAdditionalFieldsForEdit(equipmentId);

            var editEquipmentVm = new EditEquipmentVm
            {
                AddEquipmentVm = equipment,
                AdditionalFieldsVm = additionalFields
            };

            List<Location2Vm> location2s = _location2Service.GetAllLocations2();
            ViewBag.Location2s = location2s.Select(c => new SelectListItem()
            {
                Text = c.Location2Name,
                Value = c.Location2Id.ToString()
            });

            List<TypesVm> types = _typeService.GetAllTypes();
            ViewBag.Types = types.Select(c => new SelectListItem()
            {
                Text = c.TypeName,
                Value = c.TypeId.ToString()
            });

            return View(editEquipmentVm);
        }

        [Route("equipment-details/{equipmentId}")]
        [HttpGet]
        public IActionResult EquipmentDetails(int equipmentId)
        {
            var equipment = _equipmentService.GetEquipmentSharedFieldsForDetails(equipmentId);
            var additionalFields = _equipmentService.GetEquipmenmtAdditionalFieldsForEdit(equipmentId);

            var equipmentDetailsVm = new EquipmentDetailsVm
            {
                EquipmentDetailsSharedVm = equipment,
                AdditionalFieldsVm = additionalFields
            };            

            return View(equipmentDetailsVm);
        }

        [Route("add-files/{equipmentid}")]
        [HttpGet]
        public IActionResult AddFiles(int equipmentId)
        {
            ViewBag.EquipmentId = equipmentId;
            List<CategoriesVm> categories = _fileService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        [Route("add-files/GetFilesByCategory")]
        [HttpGet]
        public ActionResult GetFilesByCategory(int categoryId, int equipmentId)
        {
            List<FileVm> fileModels = _fileService.GetFilesByCategory(categoryId, equipmentId);           

            return PartialView("_FileTable", fileModels);
        }

        [Route("download-file/{fileId}")]
        [HttpGet]
        public IActionResult DownloadFile(int fileId)
        {
            // Pobierz plik z bazy danych na podstawie identyfikatora
            byte[] fileBytes = _fileService.GetFileBytesById(fileId);            

            // Utwórz odpowiedź HTTP z plikiem do pobrania
            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = _fileService.GetFileNameByFileId(fileId), // Ustaw nazwę pliku tutaj
                Inline = true  // Ustaw na true, jeśli chcesz otworzyć plik w przeglądarce, zamiast pobierać go
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            Response.Headers.Add("Content-Type", "application/pdf");

            return File(fileBytes, "application/pdf"); // Zwróć plik jako odpowiedź do przeglądarki
        }

        [Route("delete-file/{fileId}")]
        [HttpGet]
        public ActionResult DeleteFile(int fileId)
        {
            int categoryId = _fileService.GetCategoryIdByFileId(fileId);
            _fileService.DeleteFile(fileId);

            return Json(new { success = true, categoryId, message = "Plik został pomyślnie usunięty." });
        }

    }
}

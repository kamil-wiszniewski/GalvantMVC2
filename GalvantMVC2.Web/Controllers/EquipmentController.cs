using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Application.ViewModels.AdditionalFields;
using GalvantMVC2.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var id = _equipmentService.AddEquipment(model, additionalFieldsModel);
            return RedirectToAction("Index");
        }
    

        [Route("add-equipment/AdditionalFields")]
        public IActionResult AdditionalFields(int selectedTypeId)
        {
            string partialViewName = _equipmentService.GetProperAdditionalFieldsPartialViewName(selectedTypeId);            
            
            return PartialView(partialViewName);
        }

        [HttpPost]
        [Route("add-equipment/upload-files")]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                // Ścieża do folderu, gdzie pliki zostaną zapisane (zmodyfikuj ją według swoich potrzeb)
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Sprawdź, czy folder istnieje, jeśli nie, utwórz go
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileNames = new List<string>();

                // Iteruj przez przesłane pliki
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Unikalna nazwa dla każdego pliku, aby uniknąć kolizji
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        // Pełna ścieżka do pliku
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Zapisz plik na dysku
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Dodaj nazwę pliku do listy
                        fileNames.Add(fileName);
                    }
                }

                // Zwróć odpowiedź JSON z nazwami zapisanych plików
                return Json(new { success = true, message = "Pliki przesłane pomyślnie.", fileNames });
            }
            catch (Exception ex)
            {
                // Obsługa błędów
                return Json(new { success = false, message = "Wystąpił błąd podczas przesyłania plików." });
            }
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

        [Route("add-files")]
        [HttpGet]
        public IActionResult AddFiles()
        {
            List<CategoriesVm> categories = _fileService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }
    }
}

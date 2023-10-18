using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IEquipmentRepository _equipmentRepo;

        public FileService(IEquipmentRepository equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;
        }

        public List<CategoriesVm> GetAllCategories()
        {
            var categories = _equipmentRepo.GetAllCategories();
            var categoriesVmList = new List<CategoriesVm>();
            foreach (var category in categories)
            {
                var categoriesVm = new CategoriesVm
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName                    
                };
                categoriesVmList.Add(categoriesVm);
            }
            return categoriesVmList;
        }        
    }
}

using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public void Upload(List<IFormFile> files, int categoryId)
        {
            foreach (var file in files)
            {
                Domain.Model.File newFile = new()
                {
                    EquipmentId = 1,
                    CategoryId = categoryId,
                    FileName = file.FileName,
                    FileSize = file.Length,
                    FileExtension = Path.GetExtension(file.FileName),
                    FileData = GetBytesFromIFormFile(file)
                };
                _equipmentRepo.AddFile(newFile);
            }
        }

        public List<FileVm> GetFilesByCategory(int categoryId)
        {
            var files = _equipmentRepo.GetAllFiles().Where(f => f.CategoryId == categoryId).ToList();
            List<FileVm> fileModels = new List<FileVm>();

            foreach (var file in files)
            {
                FileVm fileVm = new FileVm
                {
                    FileName = file.FileName,
                    FileExtension = Path.GetExtension(file.FileName),
                    FileSize = file.FileSize
                };
                fileModels.Add(fileVm);
            }
            return fileModels;
        }

        public byte[] GetBytesFromIFormFile(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Kopiuj dane pliku do MemoryStream
                file.CopyTo(memoryStream);

                // Pobierz tablicę bajtów z MemoryStream
                byte[] fileBytes = memoryStream.ToArray();

                return fileBytes;
            }
        }        
    }
}

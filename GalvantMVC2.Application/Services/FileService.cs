using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public void Upload(List<IFormFile> files, int categoryId, int equipmentId)
        {
            foreach (var file in files)
            {
                Domain.Model.File newFile = new()
                {
                    EquipmentId = equipmentId,
                    CategoryId = categoryId,
                    FileName = file.FileName,
                    FileSize = file.Length,
                    FileExtension = Path.GetExtension(file.FileName),
                    FileData = GetBytesFromIFormFile(file)
                };
                _equipmentRepo.AddFile(newFile);
            }
        }

        public List<FileVm> GetFilesByCategory(int categoryId, int equipmentId)
        {
            var files = _equipmentRepo.GetAllFiles().Where(f => f.EquipmentId == equipmentId && f.CategoryId == categoryId).ToList();
            List<FileVm> fileModels = new List<FileVm>();

            foreach (var file in files)
            {
                FileVm fileVm = new FileVm
                {
                    FileId = file.FileId,
                    FileName = Path.GetFileNameWithoutExtension(file.FileName),
                    FileExtension = Path.GetExtension(file.FileName),
                    FileSize = Math.Round((double)file.FileSize / (1024 * 1024), 2)
                };
                fileModels.Add(fileVm);
            }
            return fileModels;
        }

        public byte[] GetFileBytesById(int fileId)
        {            
            var file = _equipmentRepo.GetFileByFileId(fileId);          
                        
            if (file != null)
            {                
                return file.FileData;
            }            
            return null;
        }

        public string GetFileNameByFileId(int fileId)
        {
            var file = _equipmentRepo.GetFileByFileId(fileId);
            return file.FileName;
        }

        public void DeleteFile(int fileId)
        {            
            _equipmentRepo.DeleteFile(fileId);            
        }

        public int GetCategoryIdByFileId(int fileId)
        {
            var file = _equipmentRepo.GetFileByFileId(fileId);
            return file.CategoryId;
        }

        public byte[] GetBytesFromIFormFile(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {                
                file.CopyTo(memoryStream);
                
                byte[] fileBytes = memoryStream.ToArray();

                return fileBytes;
            }
        }        
    }
}

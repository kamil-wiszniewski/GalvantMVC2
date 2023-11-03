using GalvantMVC2.Application.Services;
using GalvantMVC2.Application.ViewModels.Equipment;
using GalvantMVC2.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Interfaces
{
    public interface IFileService
    {
        List<CategoriesVm> GetAllCategories();
        void Upload(List<IFormFile> files, int categoryId, int equipmentId);

        List<FileVm> GetFilesByCategory(int categoryId, int equipmentId);

        byte[] GetFileBytesById(int fileId);

        string GetFileNameByFileId(int fileId);

        void DeleteFile(int fileId);

        int GetCategoryIdByFileId(int fileId);
    }
}

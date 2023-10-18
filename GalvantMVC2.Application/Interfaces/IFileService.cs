using GalvantMVC2.Application.ViewModels.Equipment;
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
    }
}

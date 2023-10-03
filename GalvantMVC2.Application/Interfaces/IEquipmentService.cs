using GalvantMVC2.Application.ViewModels.AdditionalFields;
using GalvantMVC2.Application.ViewModels.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.Interfaces
{
    public interface IEquipmentService
    {
        string GetProperAdditionalFieldsPartialViewName(int typeId);        

        int AddEquipment(AddEquipmentVm model, AdditionalFieldsVm additionalFieldsModell);

        List<EquipmentListVm> GetAllEquipmentForList(string? selectedLocation1, int? selectedType, int? selectedLocation2);

        AddEquipmentVm GetEquipmentSharedFieldsForEdit(int id);

        AdditionalFieldsVm GetEquipmenmtAdditionalFieldsForEdit(int id);
    }
}

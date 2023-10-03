using GalvantMVC2.Application.ViewModels.AdditionalFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Equipment
{
    public class EditEquipmentVm
    {
        public AddEquipmentVm AddEquipmentVm { get; set; }
        public AdditionalFieldsVm AdditionalFieldsVm { get; set; }
    }
}

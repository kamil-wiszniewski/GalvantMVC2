using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Equipment
{
    public class EquipmentListVm
    {
        public int EquipmentId { get; set; }
        public string? Type { get; set; }
        public string? Location1 { get; set; }
        public string? Location2 { get; set; }
        public string? Location3 { get; set; }
        public string? InventoryNumber { get; set; }

    }
}

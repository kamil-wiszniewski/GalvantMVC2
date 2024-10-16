using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Equipment
{
    public class EquipmentDetailsSharedVm
    {
        public int EquipmentId { get; set; }
        public string? Location1 { get; set; }
        public string? Location2Name { get; set; }
        public string? Location3 { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string? Notes { get; set; }
    }
}


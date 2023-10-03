using GalvantMVC2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Equipment
{
    public class AddEquipmentVm
    {
        public int EquipmentId { get; set; }
        public string? Location1 { get; set; }
        public int? Location2Id { get; set; }
        public string? Location3 { get; set; }
        public int TypeId { get; set; }
        public string? Notes { get; set; }
    }
}


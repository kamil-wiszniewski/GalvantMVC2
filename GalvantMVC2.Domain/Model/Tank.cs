using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Tank
    {
        public int TankId { get; set; }
        public string? Type { get; set; }
        public string? Producer { get; set; }
        public string? ProductionYear { get; set; }
        public string? FactoryNumber { get; set; }
        public string? UDTNumber { get; set; }
        public string? InventoryNumber { get; set; }
        public decimal? Capacity { get; set; }
        public decimal? PermissiblePressure { get; set; }

        //PLIKI
        //dokumentacja techniczno ruchowa
        //schemat elektryczny
        //(inne)

        public DateTime? UDTExpiryDate { get; set; }
        public DateTime? ElectricalExpiryDate { get; set; }
        public DateTime? ResursDate { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}

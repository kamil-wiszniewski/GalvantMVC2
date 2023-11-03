using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Equipment
    {
        public int EquipmentId { get; set; }        
        public string? Location1  { get; set; }
        public int? Location2Id { get; set; }
        public string? Location3 { get; set; }
        public int TypeId { get; set; }
        public string? Notes { get; set; }
        public virtual Type Type { get; set; }
        public virtual Location2 Location { get; set; }        
        public Gantry Gantry { get; set; }
        public Forklift Forklift { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

    }
}

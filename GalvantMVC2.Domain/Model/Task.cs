using GalvantMVC2.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Task
    {
        public int TaskId { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }        
        public string? Title { get; set; }
        public string? Description { get; set; }        
        public DateTime? DueDate { get; set; }       
        public PriorityEnum? Priority { get; set; }
        public double? Cost { get; set; }
        public string? Notes { get; set; }   
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int? EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }        
        public int? TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ICollection<TaskEmployee> TaskEmployee { get; set; }
        public virtual ICollection<TaskFile>? TaskFiles { get; set; }
    }
}

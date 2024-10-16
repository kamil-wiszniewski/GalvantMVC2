using GalvantMVC2.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Tasks
{
    public class AddTaskVm
    {
        public int TaskId { get; set; }
        public DateTime? CreatedAt { get; set; }        
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityEnum? Priority { get; set; }
        public double? Cost { get; set; }
        public string? Notes { get; set; }
        public int? StatusId { get; set; }
        public int? EquipmentId { get; set; }
        public int? TagId { get; set; }
    }
}

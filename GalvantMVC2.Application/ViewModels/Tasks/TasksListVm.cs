using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Tasks
{
    public class TasksListVm
    {
        public int TaskId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? TagName { get; set; }
        public string? Description { get; set; }
        public string? Equipment { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

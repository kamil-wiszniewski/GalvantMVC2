using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Tasks
{
    public class TasksSearchResultVm
    {
        public int TaskId { get; set; }
        public string? Type { get; set; }
        public string? Location2 { get; set; }
        public string? Status { get; set; }
        public string? Tag { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Title { get; set; }
    }
}

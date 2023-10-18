using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Tasks
{
    public class ReportVm
    {
        public string ReportType { get; set; }
        public string Description { get; set; }
        public Stream Images { get; set; }
    }
}

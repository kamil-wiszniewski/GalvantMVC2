using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Equipment
{
    public class FileVm
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileExtension { get; set; }
    }
}

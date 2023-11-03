using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Equipment
{
    public class FileVm
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public string FileExtension { get; set; }
    }
}

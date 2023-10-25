using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class File
    {
        public int FileId { get; set; }
        public int EquipmentId { get; set; }
        public int CategoryId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileData { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual Equipment Equipment { get; set; }

    }
}

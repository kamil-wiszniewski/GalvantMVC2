using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class TaskFile
    {
        public int TaskFileId { get; set; }
        public int TaskId { get; set; }        
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileData { get; set; }
        
        public virtual Task Task { get; set; }
    }
}

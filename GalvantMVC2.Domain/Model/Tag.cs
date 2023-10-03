using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Domain.Model
{
    public class Location2
    {
        public int Location2Id { get; set; }
        public string Location2Name { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}

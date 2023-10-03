using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC2.Application.ViewModels.Employee
{
    public class SearchLastNameVm
    {
        public string SearchText { get; set; }
        public List<string> Suggestions { get; set; }
    }
}

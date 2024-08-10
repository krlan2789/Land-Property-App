using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land_Property_App.Models
{
    public class Property
    {
        public required string DefaultImage { get; set; }
        public required string Address { get; set; }
        public long Price { get; set; }
        public List<string>? Images { get; set; }
    }
}

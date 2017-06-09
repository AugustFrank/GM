using GM011.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM11.Models
{
    public class Parts
    {
        public int PartsID { get; set; }
        public int PartID { get; set; }
        public int ServiceID { get; set; }

        public Part Part { get; set; }
        public Service Service { get; set; }

    }
}

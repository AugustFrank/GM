using GM011.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM11.Models.GMViewModels
{
    public class CarIndexData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<CarType> CarTypes { get; set; }
        public IEnumerable<Service> Services { get; set; }

    }
}

using GM011.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM11.Models.GMViewModels
{
    public class CarIndexData
    {
        // for testing the index form in Enquery
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Costumer> Costumers { get; set; }


        public IEnumerable<GM011.Models.CarIndexData> Cars { get; set; }
        public IEnumerable<CarType> CarTypes { get; set; }
        public IEnumerable<Service> Services { get; set; }

    }
}

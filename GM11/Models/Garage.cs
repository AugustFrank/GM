using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GM011.Models
{
    public class Garage
    {
        public int GarageID { get; set; }

        public string GarageName { get; set; }
        public string Address { get; set; }
        public int Tlf { get; set; }
        public string ContactName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }

       
        public ICollection<Service> Services { get; set; }

    }
}

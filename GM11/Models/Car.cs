using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GM011.Models
{
    public class CarIndexData
    { // make requirements and annotations and add cms to update the site

        public int CarID { get; set; }
        public string RegNo { get; set; }
        public int CarTypeID { get; set; }
        public int ServiceID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }
        public int CurrentMilage { get; set; }
        public int NextServiceMilage { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public string Fuel { get; set; } //find better solution?
        [Display(Name = "Fuel Consumption L/Km")]
        public string FuelPerKM { get; set; }

        public string Transmission { get; set; }



        public CarType CarType { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Service> Services { get; set; }

    }
}

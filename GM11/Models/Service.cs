using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GM11.Models;

namespace GM011.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int GarageID { get; set; }
        public int PartsID { get; set; }

        public int ServiceMilage { get; set; }
        public decimal ServiceCost { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ServiceDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }

        public Car Car { get; set; }
        public ICollection<Parts> Parts { get; set; }
        public Garage Garage { get; set; }
    }
}

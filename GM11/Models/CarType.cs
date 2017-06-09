using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GM011.Models
{
    public class CarType
    {
        public int CarTypeID { get; set; }
        [Display(Name = "Make")]
        public string Make { get; set; }       
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public string ImagePath { get; set; }

        public  ICollection<CarIndexData> Cars { get; set; }
    }
}

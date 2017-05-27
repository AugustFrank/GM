using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GM11.Models;

namespace GM011.Models
{
    public class Part
    {
        public int PartID { get; set; }
        public int? PartCode { get; set; }
        public string PartName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }
        [DataType(DataType.Currency)]
        public decimal? PartCost { get; set; }

        public ICollection<Parts> Parts { get; set; }
    }
}

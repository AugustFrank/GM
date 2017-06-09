using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GM011.Models
{
    public enum OrderStatus
    {
        Paid, NotPaid, SpecialOrder, SeeDiscription
    }
    public class Order
    {
        public int OrderID { get; set; }
        public int CarID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOut { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateIN { get; set; }
        public int MileageOut { get; set; }
        public int MileageIn { get; set; }
        public int MileageAllowance { get; set; }
        public int ExcessMileage { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }

        public Car Car { get; set; }
        public Costumer Costumer { get; set; }

    }
}

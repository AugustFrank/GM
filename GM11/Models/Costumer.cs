using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GM011.Models
{
    public class Costumer
    {
        public int CostumerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + ", " + LastName; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Age { get; set; }
        [Required]
        public int YearsWithLicenns { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}

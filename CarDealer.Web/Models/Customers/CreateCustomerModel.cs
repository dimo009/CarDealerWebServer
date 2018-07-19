using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Customers
{
    public class CreateCustomerModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Young driver")]
        public bool IsYoungDriver { get; set; }
    }
}

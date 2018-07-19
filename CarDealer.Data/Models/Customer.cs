using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new List<Sale>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsYoung { get; set; }

        public List<Sale> Sales { get; set; }
    }
}

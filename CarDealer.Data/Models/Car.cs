using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Sales = new List<Sale>();
            this.Parts = new List<PartCar>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model  { get; set; }

        [Range(0,long.MaxValue)]
        public long Distance { get; set; }

        public List<Sale> Sales { get; set; }

        public List<PartCar> Parts { get; set; }
    }
}

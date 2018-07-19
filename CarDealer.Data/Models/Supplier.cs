using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Parts = new List<Part>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public List<Part> Parts { get; set; }
    }
}

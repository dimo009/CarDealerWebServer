using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class PartListingModel:PartModel
    {
        public int Id { get; set;
        }
        public int Qualtity { get; set; }

        public string SupplierName { get; set; }
    }
}

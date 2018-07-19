using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsYoung { get; set; }
    }
}

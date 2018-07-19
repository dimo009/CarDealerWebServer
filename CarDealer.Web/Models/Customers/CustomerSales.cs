using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Customers
{
    public class CustomerSales
    {
        public string Name { get; set; }

        public int TotalSales { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}

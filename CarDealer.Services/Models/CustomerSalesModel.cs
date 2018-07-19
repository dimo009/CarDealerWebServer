using CarDealer.Services.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CustomerSalesModel
    {
        public string Name { get; set; }

        

        public bool IsYoungDriver { get; set; }

       

        public IEnumerable <CarPriceModel> BoughtCars {get;set;}

       

        public decimal TotalPrice
        {
            get
            {
                return this.BoughtCars.Sum(c => c.Price * (1 - (decimal)c.Discount))
                    *(this.IsYoungDriver ? 0.95m:1);
            }
        }



        //public decimal TotalPrice { get; set; }
    }
}

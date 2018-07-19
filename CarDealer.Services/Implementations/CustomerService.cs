

namespace CarDealer.Services.Implementations
{
    using System;
    using Data;
    using System.Collections.Generic;
    using System.Text;
    using CarDealer.Services.Models;
    using System.Linq;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Data.Models;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        

        public IEnumerable<CustomerModel> Ordered(OrderingType order)
        {
            var customerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderingType.Ascending:
                    customerQuery = customerQuery.OrderBy(c => c.Birthday).ThenBy(c=>c.Name);
                    break;
                case OrderingType.Descending:
                    customerQuery = customerQuery.OrderByDescending(c => c.Birthday).ThenBy(c => c.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid ordering type: {order}.");
                    
            }

            return customerQuery
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    Birthday = c.Birthday,
                    IsYoung = c.IsYoung
                }).ToList();
        }

        public CustomerSalesModel TotalSalesByCustomer(int custId)
        {
            var result = this.db.Customers.Where(c => c.Id == custId)
                .Select(c => new CustomerSalesModel
                {
                    Name = c.Name,

                    IsYoungDriver = c.IsYoung,
                    BoughtCars = c.Sales.Select(s => new CarPriceModel
            
                    {
                        Price = s.Car.Parts.Sum(p=>p.Part.Price),
                        Discount = s.Discount
                    })
                    

                }).FirstOrDefault();
            return result;

        //    var customerName = this.db.Customers.FirstOrDefault(c => c.Id == custId).Name;

        //    var totalSales = this.db.Sales.Where(c => c.CustomerId == custId).Count();

        //    var sales = this.db.Sales.ToList().FindAll(c=>c.CustomerId == custId);
        //    decimal sumSpent = 0;

        //    foreach (var sale in sales)
        //    {
        //        var result = this.db
        //        .Cars
        //        .Where(c => c.Id == sale.CarId)
        //        .Select(c => new CarPartsModel
        //        {

        //            Parts = c.Parts.Select(p => new PartModel
        //            {
        //                Name = p.Part.Name,
        //                Price = p.Part.Price
        //            })
 
        //        }).ToList();

        //        foreach (var item in result)
        //        {
        //            sumSpent += item.Parts.Sum(p => p.Price);
        //        }
        //    }

          
        //    var customer = new CustomerSalesModel()
        //    {
        //        Name = customerName,
        //        TotalSales = totalSales,
        //        TotalPrice = sumSpent
        //    };

        //    return customer;
        }

        
    }
}

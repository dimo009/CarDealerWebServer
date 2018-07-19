

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

      

        public void Create(string name, DateTime birthday, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                Birthday = birthday,
                IsYoung = isYoungDriver
            };
            this.db.Add(customer);
            this.db.SaveChanges();
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
                    Id = c.Id,
                    Name = c.Name,
                    Birthday = c.Birthday,
                    IsYoung = c.IsYoung
                }).ToList();
        }



        //get the customer who will be editted

        public CustomerModel ById(int id)
            => this.db.Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerModel

            {
                Id = c.Id,
                Name = c.Name,
                Birthday = c.Birthday,
                IsYoung = c.IsYoung
            })
            .FirstOrDefault();
        

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

        }

        public void Edit(int id, string name, DateTime birthday, bool isYoungDriver)
        {
            var customer = this.db.Customers.Find(id);

            if (customer==null)
            {
                return;
            }

            customer.Name = name;
            customer.Birthday = birthday;
            customer.IsYoung = isYoungDriver;

            this.db.SaveChanges();

        }

        public bool Exists(int id) => this.db.Customers.Any(c => c.Id == id);
        
    }
}

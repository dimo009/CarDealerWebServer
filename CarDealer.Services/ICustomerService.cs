using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
   public interface ICustomerService
    {
        IEnumerable <CustomerModel> Ordered(OrderingType order);

        CustomerSalesModel TotalSalesByCustomer (int custId);


        void Create(string name, DateTime Birthday, bool IsYoungDriver);

        void Edit(int id, string name, DateTime birthday, bool isYoungDriver);

        CustomerModel ById(int id);

        bool Exists(int id);
    }
}

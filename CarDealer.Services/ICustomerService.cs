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

    }
}

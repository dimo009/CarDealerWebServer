

namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models;
    using Models.Customers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("customers")]
    public class CustomerController:Controller
    {
        private readonly ICustomerService customers;

        public CustomerController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            var orderingType = order.ToLower() == "descending" ? OrderingType.Descending : OrderingType.Ascending;

            var customers = this.customers.Ordered(orderingType);

            return View(new AllCustomersModel
            {
                Customers = customers,
                OrderingType = orderingType
            });
        }

        [Route("{id}")]
        public IActionResult AllSales(int id)
        {
            var cust = this.customers.TotalSalesByCustomer(id);

            return View(new CustomerSales
            {
                Name = cust.Name,
                TotalSales = cust.BoughtCars.Count(),
                TotalPrice = cust.TotalPrice
                

            });
        }
    }
}

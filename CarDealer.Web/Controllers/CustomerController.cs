

namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models;
    using Models.Customers;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customers;

        public CustomerController(ICustomerService customers)
        {
            this.customers = customers;
        }

        //Create customer

        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CreateCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.customers.Create(model.Name, model.Birthday, model.IsYoungDriver);

            return this.RedirectToAction(nameof(All), new { order = OrderingType.Ascending });

        }


        //edit customer
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {

           var customer = this.customers.ById(id);

            if (customer==null)
            {
                return NotFound();
            }

            return View(new EditCustomerModel
            {
                Name = customer.Name,
                Birthday = customer.Birthday,
                IsYoungDriver = customer.IsYoung

            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, EditCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerExists = this.customers.Exists(id);

            if (!customerExists)
            {
                return NotFound();
            }

            this.customers.Edit(id,model.Name, model.Birthday, model.IsYoungDriver);

            return this.RedirectToAction(nameof(All), new { order = OrderingType.Ascending });

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
